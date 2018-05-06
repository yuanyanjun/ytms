using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using YTMS.DAL;
using YTMS.Domain;
using YTMS.Common.Core;
namespace YTMS.BLL.Order
{
    public class OrderServer : IOrderServer
    {
        private static object _lock = new object();
        public string AddOrder(OrderDto order, List<OrderProductDto> items)
        {
            lock (_lock)
            {
                order.OrderNo = HelpSup.GenerateOrderNo();
                using (var db = DBManager.GetInstance())
                {
                    try
                    {
                        db.Ado.BeginTran();
                        var obj = order.MapTo<T_Orders>();
                        order.Id = db.Insertable<T_Orders>(obj).ExecuteReturnIdentity();

                        if (items != null && items.Count > 0)
                        {
                            var obj_items = items.MapToList<T_Order_Products>();

                            db.Insertable(obj_items).ExecuteCommand();
                        }

                        db.Ado.CommitTran();

                        return order.OrderNo;
                    }
                    catch (Exception ex)
                    {
                        db.Ado.RollbackTran();
                        throw ex;
                    }
                }
            }
        }

        public OrderDto Get(string orderNo)
        {
            if (string.IsNullOrWhiteSpace(orderNo))
                return null;

            using (var db = DBManager.GetInstance())
            {
                return db.Queryable<T_Orders>().Where(w => w.OrderNo == orderNo).Single().MapTo<OrderDto>();
            }
        }

        public List<OrderDto> List(OrderQueryFilter filter)
        {
            throw new NotImplementedException();
        }

        public bool Update(OrderDto order)
        {
            using (var db = DBManager.GetInstance())
            {
                return db.Updateable<T_Orders>(new
                {
                    CustomerName = order.CustomerName,
                    CustomerMobileNo = order.CustomerMobileNo,
                    CardNo = order.CardNo,
                    CardType = order.CardType,
                    EtaDate = order.EtaDate,
                    DueoutDate = order.DueoutDate,
                    Deposit = order.Deposit,
                    OrderRemark = order.OrderRemark,
                    LastModifyBy = order.LastModifyBy,
                    LastModifyTime = order.LastModifyTime

                }).Where(w => w.OrderNo == order.OrderNo).ExecuteCommand() > 0;
            }
        }

        public bool UpdateOrderStatus(string orderNo, OrderStatus status)
        {
            using (var db = DBManager.GetInstance())
            {
                var s = (int)status;
                db.Updateable<T_Orders>(new
                {
                    OrderStatus = s
                }).Where(w => w.OrderNo == orderNo).ExecuteCommand();

                return true;
            }
        }
    }
}
