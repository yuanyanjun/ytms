using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace YTMS.BLL.Order
{
    public interface IRoomOrderServer
    {
        /// <summary>
        /// 客房预定
        /// </summary>
        /// <returns></returns>
        bool Reserve(RoomReserveDto reserve, List<RoomReserveItemDto> rooms);

        /// <summary>
        /// 入住
        /// </summary>
        /// <returns></returns>
        bool CheckIn(RoomCheckInDto checkin);

        /// <summary>
        /// 退房
        /// </summary>
        /// <returns></returns>
        //bool CheckOut();
    }
}
