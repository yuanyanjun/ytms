using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using YTMS.Domain;
using YTMS.DAL;
using YTMS.Common.Core;
namespace YTMS.BLL.Order
{
    public class RoomOrderServer : IRoomOrderServer
    {
        private static object reserveLock = new object();
        private static object checkInLock = new object();


        public bool Reserve(RoomReserveDto reserve, List<RoomReserveItemDto> rooms)
        {
            if (reserve == null)
                throw new CustomerException("预定信息为null");
            if (rooms == null || rooms.Count == 0)
                throw new CustomerException("请选择需要预定的客房");

            if (string.IsNullOrWhiteSpace(reserve.UserName))
                throw new CustomerException("客人姓名不能为空");

            if (string.IsNullOrWhiteSpace(reserve.UserPhone))
                throw new CustomerException("客人联系电话不能为空");

            if (!reserve.ArrvingTime.HasValue)
                throw new CustomerException("预抵时间不能为空");
            if (!reserve.LeavingTime.HasValue)
                throw new CustomerException("预离时间不能为空");

            if (reserve.ArrvingTime.Value.Ticks >= reserve.LeavingTime.Value.Ticks)
                throw new CustomerException("预离时间必须晚于预抵时间");

            if (reserve.Days == 0)
                throw new CustomerException("预定天数必须大于零");

            //验证客房是否可预定

            lock (reserveLock)
            {
                using (var db = DBManager.GetInstance())
                {
                    var objs = rooms.Select(row => new T_Room_Records
                    {
                        ArrvingTime = reserve.ArrvingTime,
                        CardNo = reserve.CardNo,
                        CardType = reserve.CardType,
                        CreateBy = reserve.CreateBy,
                        CreateTime = reserve.CreateTime,
                        Days = reserve.Days,
                        ExpiredTime = reserve.ExpiredTime,
                        IsDeleted = false,
                        LeavingTime = reserve.LeavingTime,
                        RoomPrice = row.RoomPrice,
                        RoomId = row.Id,
                        Status = (int)RecordStatus.Reserve,
                        UserName = reserve.UserName,
                        UserPhone = reserve.UserPhone,
                        Deposit = row.Deposit,
                        LastModifyBy = reserve.LastModifyBy,
                        LastModifyTime = reserve.LastModifyTime
                    });

                    try
                    {
                        db.Ado.BeginTran();

                        var count = db.Insertable<T_Room_Records>(objs).ExecuteCommand();

                        db.Ado.CommitTran();

                        return count > 0;
                    }
                    catch (Exception ex)
                    {
                        db.Ado.RollbackTran();
                        throw ex;
                    }
                }
            }
        }

        public bool CheckIn(RoomCheckInDto checkin)
        {
            if (checkin == null)
                throw new CustomerException("入住信息为null");

            if (string.IsNullOrWhiteSpace(checkin.UserPhone))
                throw new CustomerException("客人联系电话不能为空");

            if (!checkin.ArrvingTime.HasValue)
                throw new CustomerException("预抵时间不能为空");
            if (!checkin.LeavingTime.HasValue)
                throw new CustomerException("预离时间不能为空");

            if (checkin.ArrvingTime.Value.Ticks >= checkin.LeavingTime.Value.Ticks)
                throw new CustomerException("预离时间必须晚于预抵时间");

            if (checkin.Days == 0)
                throw new CustomerException("入住天数必须大于零");

            using (var db = DBManager.GetInstance())
            {
                var obj = new T_Room_Records()
                {
                    ArrvingTime = checkin.ArrvingTime,
                    CardNo = checkin.CardNo,
                    CardType = checkin.CardType,
                    CreateBy = checkin.CreateBy,
                    CreateTime = checkin.CreateTime,
                    Days = checkin.Days,
                    ExpiredTime = checkin.ExpiredTime,
                    IsDeleted = false,
                    LeavingTime = checkin.LeavingTime,
                    RoomPrice = checkin.RoomPrice,
                    RoomId = checkin.RoomId,
                    Status = (int)RecordStatus.CheckIn,
                    UserName = checkin.UserName,
                    UserPhone = checkin.UserPhone,
                    Deposit = checkin.Deposit,
                    LastModifyBy = checkin.LastModifyBy,
                    LastModifyTime = checkin.LastModifyTime
                };

                var count = 0;
                //直接入住
                if (!checkin.ReserveId.HasValue)
                {
                    count = db.Insertable(obj).ExecuteCommand();
                }
                else//预定转入住
                {
                    var lst = new List<string>() { "Id", "CreateBy", "CreateTime" };
                    count = db.Updateable(obj).IgnoreColumns(it => lst.Contains(it)).Where(w => w.Id == checkin.ReserveId.Value).ExecuteCommand();
                }

                return count > 0;
            }
        }

        public List<RoomRecordsDto> GetRecordList(RecordQueryFilter filter)
        {
            if (filter == null)
                return null;
            using (var db = DBManager.GetInstance())
            {
                var q = db.Queryable<T_Room_Records>().Where(w => w.IsDeleted == false);

                var start = filter.StartTime.ToCurrentDayMinVal();
                var end = filter.EndTime.ToCurrentDayMaxVal();

                q = q.Where(w => w.ArrvingTime >= start && w.LeavingTime <= end);

                if (filter.RoomIds != null && filter.RoomIds.Count > 0)
                    q = q.Where(w => filter.RoomIds.Contains(w.RoomId));

                return q.ToList().MapToList<RoomRecordsDto>();
            }
        }

        public bool CheckOut(long recordId, decimal thirdPercent, List<RoomCheckOutDto> checkouts)
        {
            if (checkouts == null && checkouts.Count == 0)
                throw new CustomerException("未产生任何房费");

            using (var db = DBManager.GetInstance())
            {
                var record = db.Queryable<T_Room_Records>().Where(w => w.Id == recordId).Single();
                if (record == null || record.IsDeleted)
                    throw new CustomerException("入住记录不存在，操作失败");

                if (record.Status != (int)RecordStatus.CheckIn)
                    throw new CustomerException("该客房还未入住货已退房，操作失败");

                try
                {
                    db.Ado.BeginTran();

                    //修改记录状态
                    var status = (int)RecordStatus.CheckOut;
                    db.Updateable<T_Room_Records>(new
                    {
                        Status = status
                    }).Where(w => w.Id == recordId).ExecuteCommand();

                    //写入消费记录
                    var objs = checkouts.MapToList<T_Room_Consumed_Records>();
                    db.Insertable(objs).ExecuteCommand();

                    //写入退房结算记录 跨月拆分结算记录
                    var settlesList = checkouts.GroupBy(i => new { i.Year, i.Month }).Select(group => new T_Room_Checkout_Settles()
                    {
                        RecordId = recordId,
                        Year = group.Key.Year,
                        Month = group.Key.Month,
                        RoomId = record.RoomId,
                        TotalAmount = group.Sum(item => item.Monetary),
                        ThirdPercent = thirdPercent,
                        WastageAmount = group.Sum(item => item.WastageFee),
                        ExtraFee = group.Sum(item => item.ExtraFee)
                    }).ToList();

                    settlesList.ForEach(item =>
                    {
                        item.ThirdFee = item.TotalAmount * item.ThirdPercent;
                        item.ActualAmount = item.TotalAmount - item.ThirdFee - item.WastageAmount;
                    });

                    db.Insertable(settlesList).ExecuteCommand();
                    db.Ado.CommitTran();

                    return true;
                }
                catch (Exception ex)
                {
                    db.Ado.RollbackTran();
                    throw ex;
                }
            }
        }
    }
}
