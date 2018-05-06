using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YTMS.Domain
{
    public class T_Orders
    {
        [SqlSugar.SugarColumn(IsOnlyIgnoreInsert = true)]
        public int? Id { get; set; }

        public string OrderNo { get; set; }

        public string CustomerName { get; set; }

        public string CustomerMobileNo { get; set; }

        public string CardNo { get; set; }

        public int CardType { get; set; }

        public DateTime EtaDate { get; set; }

        public DateTime DueoutDate { get; set; }

        public int OrderStatus { get; set; }

        public int OrderType { get; set; }

        /// <summary>
        /// 押金
        /// </summary>
        public decimal Deposit { get; set; }

        public decimal OrderAmount { get; set; }

        public decimal OrderDisCount { get; set; }

        public string OrderRemark { get; set; }

        public string CreateBy { get; set; }

        public DateTime CreateTime { get; set; }

        public string LastModifyBy { get; set; }

        public DateTime LastModifyTime { get; set; }
    }
}
