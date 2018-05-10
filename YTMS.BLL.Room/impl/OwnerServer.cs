using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using YTMS.Domain;
using YTMS.DAL;
using YTMS.Common.Core;
using SqlSugar;
namespace YTMS.BLL.Room
{
    public class OwnerServer : IOwnerServer
    {
        public long Add(OwnerDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException("dto");

            using (var db = DBManager.GetInstance())
            {
                return db.Insertable<T_Owner>(dto).ExecuteReturnIdentity();
            }
        }

        public bool Deleted(long id)
        {
            using (var db = DBManager.GetInstance())
            {
                var dt = DateTime.Now;
                db.Updateable<T_Owner>(new
                {
                    DeletedTime = dt
                }).Where(w => w.Id == id).ExecuteCommand();

                return true;
            }
        }

        public bool Edit(OwnerDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException("dto");

            using (var db = DBManager.GetInstance())
            {
                var dt = DateTime.Now;
                db.Updateable<T_Owner>(new
                {
                    Name = dto.Name,
                    Sex = dto.Sex,
                    Phone = dto.Phone,
                    CardNo = dto.CardNo,
                    WxChat = dto.WxChat,
                    OpenId = dto.OpenId,
                    Img = dto.Img,
                    Address = dto.Address,
                    BankName = dto.BankName,
                    BankDeposit = dto.BankDeposit,
                    BankAccount = dto.BankAccount,
                    LastModifyTime = dt
                }).Where(w => w.Id == dto.Id).ExecuteCommand();

                return true;
            }
        }

        public bool EditRoomNun(long id, int num)
        {
            using (var db = DBManager.GetInstance())
            {
                var row = db.Queryable<T_Owner>().Single(w => w.Id == id);

                int _num = 0;
                if (row != null)
                    _num = row.RoomNum + num;

                db.Updateable<T_Owner>(new
                {
                    RoomNum = _num
                }).Where(w => w.Id == id).ExecuteCommand();

            }
            throw new NotImplementedException();
        }

        public OwnerDto Get(long id)
        {
            using (var db = DBManager.GetInstance())
            {
                return db.Queryable<T_Owner>().Single(w => w.Id == id).MapTo<OwnerDto>();
            }
        }

        public List<OwnerDto> List(OwnerQueryFilter filter)
        {
            if (filter == null)
                return null;

            using (var db = DBManager.GetInstance())
            {
                var q = db.Queryable<T_Owner>();

                if (!string.IsNullOrWhiteSpace(filter.Keywords))
                    q = q.Where(w => w.Name.Contains(filter.Keywords));

                if (!string.IsNullOrWhiteSpace(filter.Phone))
                    q = q.Where(w => SqlFunc.StartsWith(w.Phone, filter.Phone));

                if (!string.IsNullOrWhiteSpace(filter.CardNo))
                    q = q.Where(w => SqlFunc.StartsWith(w.CardNo, filter.CardNo));

                if (filter.IsDeleted.HasValue && filter.IsDeleted.Value)
                {
                    q = q.Where(w => !SqlFunc.IsNullOrEmpty(w.DeletedTime));
                }
                else
                {
                    //默认排除掉删除项目
                    q = q.Where(w => SqlFunc.IsNullOrEmpty(w.DeletedTime));
                }

                if (filter.OwnerIds != null && filter.OwnerIds.Count > 0)
                {
                    q = q.Where(w => filter.OwnerIds.Contains(w.Id.Value));
                }

                int total = 0;
                var data = q.ToPageList(filter.PageIndex, filter.PageSize, ref total).MapToList<OwnerDto>();
                filter.TotalCount = total;

                return data;
            }
        }
    }
}
