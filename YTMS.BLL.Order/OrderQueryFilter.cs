using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YTMS.BLL.Order
{
    public class OrderQueryFilter
    {
        public string Keyword { get; set; }

        public string Phone { get; set; }

        public string CardNo { get; set; }

        public string CardType { get; set; }

        public DateTime? EtaDate { get; set; }

        public DateTime? DueoutDate { get; set; }

        public OrderStatus? OrderStatus { get; set; }
    }
}
