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
        bool AddOrder(OrderDto order, List<OrderProductDto> items);


        OrderDto Get(string orderNo);

        List<OrderDto> List(OrderQueryFilter filter);
    }
}
