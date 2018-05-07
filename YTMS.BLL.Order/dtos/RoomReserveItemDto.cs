using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YTMS.BLL.Order
{
    public class RoomReserveItemDto
    {
        /// <summary>
        /// 客房ID
        /// </summary>
        public long Id { get; set; }

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
