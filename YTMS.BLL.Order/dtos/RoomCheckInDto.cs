using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YTMS.BLL.Order
{
    public class RoomCheckInDto : RoomReserveDto
    {
        public long? ReserveId { get; set; }

        public long RoomId { get; set; }

        /// <summary>
        /// 客房价格
        /// </summary>
        public decimal RoomPrice { get; set; }

        /// <summary>
        /// 押金
        /// </summary>
        public decimal Deposit { get; set; }
    }
}
