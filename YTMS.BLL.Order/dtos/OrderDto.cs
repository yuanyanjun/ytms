using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YTMS.BLL.Order
{
    public class OrderDto : YTMS.Domain.T_Orders
    {
    }

    public class OrderDetailsDto : OrderDto
    {
        public List<OrderProductDto> ProductList { get; set; }
    }
}
