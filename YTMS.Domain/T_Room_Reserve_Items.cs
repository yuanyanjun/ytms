using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YTMS.Domain
{
    public class T_Room_Reserve_Items
    {
        /// <summary>
        /// 记录ID
        /// </summary>
        public long RecordId { get; set; }

        /// <summary>
        /// 客房ID
        /// </summary>
        public long RoomId { get; set; }

        /// <summary>
        /// 项目key 如：20180512
        /// </summary>
        public string ItemKey { get; set; }

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
        /// 预定时房价
        /// </summary>
        public decimal RoomPrice { get; set; }
    }
}
