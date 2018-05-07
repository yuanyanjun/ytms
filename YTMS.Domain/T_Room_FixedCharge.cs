using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YTMS.Domain
{
    public class T_Room_FixedCharge
    {
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
        /// 物业费
        /// </summary>
        public decimal PropertyFee { get; set; }

        /// <summary>
        /// 水费
        /// </summary>
        public decimal WaterFee { get; set; }

        /// <summary>
        /// 电费费
        /// </summary>
        public decimal PowerFee { get; set; }

        /// <summary>
        /// 燃气费
        /// </summary>
        public decimal GasFee { get; set; }

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
