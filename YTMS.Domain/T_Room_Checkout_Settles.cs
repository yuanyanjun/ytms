using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YTMS.Domain
{
    public class T_Room_Checkout_Settles
    {
        [SqlSugar.SugarColumn(IsOnlyIgnoreInsert = true)]
        public long? Id { get; set; }

        /// <summary>
        /// 记录ID
        /// </summary>
        public long RecordId { get; set; }

        /// <summary>
        /// 客房ID
        /// </summary>
        public long RoomId { get; set; }

        /// <summary>
        /// 年
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// 月
        /// </summary>
        public int Month { get; set; }

        /// <summary>
        /// 入住产生总收入
        /// </summary>
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// 总的固定损耗
        /// </summary>
        public decimal WastageAmount { get; set; }

        /// <summary>
        /// 附加费用
        /// </summary>
        public decimal ExtraFee { get; set; }

        /// <summary>
        /// 第三方平台费用
        /// </summary>
        public decimal ThirdFee { get; set; }

        /// <summary>
        ///实际盈利 = 总收入 - 固定损耗 - 第三方费用
        /// </summary>
        public decimal ActualAmount { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public string CreateBy { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}
