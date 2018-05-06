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
    public interface IOrderServer
    {
        string AddOrder(OrderDto order, List<OrderProductDto> items);


        bool Update(OrderDto order);

        bool UpdateOrderStatus(string orderNo, OrderStatus status);


        OrderDto Get(string orderNo);

        List<OrderDto> List(OrderQueryFilter filter);
    }
}
