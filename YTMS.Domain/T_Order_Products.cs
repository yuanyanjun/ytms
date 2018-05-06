using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YTMS.Domain
{
    public class T_Order_Products
    {
        [SqlSugar.SugarColumn(IsOnlyIgnoreInsert = true)]
        public int? Id { get; set; }

        public string OrderNo { get; set; }

        public string DateKey { get; set; }

        public int Year { get; set; }

        public int Month { get; set; }

        public int Day { get; set; }

        public int RoomId { get; set; }

        public decimal RoomPrice { get; set; }

        public decimal WastageAmount { get; set; }

        public decimal PlatformPointAmount { get; set; }

        public decimal Discount { get; set; }

        public decimal ActualAmount { get; set; }

        public bool IsSettle { get; set; }

        public DateTime? SettleTime { get; set; }

        public string SettleBy { get; set; }
    }
}
