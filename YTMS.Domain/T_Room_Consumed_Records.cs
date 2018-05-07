using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YTMS.Domain
{
    public class T_Room_Consumed_Records
    {
        [SqlSugar.SugarColumn(IsOnlyIgnoreInsert = true)]
        public long? Id { get; set; }

        /// <summary>
        /// 记录ID
        /// </summary>
        public long RecordId { get; set; }

        /// <summary>
        /// 消费记录key 如 20180510
        /// </summary>
        public string ItemKey { get; set; }

        /// <summary>
        /// 消费记录描述
        /// </summary>
        public string ItemDesc { get; set; }

        /// <summary>
        /// 年
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// 月
        /// </summary>
        public int Month { get; set; }

        /// <summary>
        /// 日
        /// </summary>
        public int Day { get; set; }

        /// <summary>
        /// 消费金额
        /// </summary>
        public decimal Monetary { get; set; }

        /// <summary>
        /// 固定损耗
        /// </summary>
        public decimal WastageFee { get; set; }

        /// <summary>
        /// 附加费用
        /// </summary>
        public decimal ExtraFee { get; set; }
    }
}
