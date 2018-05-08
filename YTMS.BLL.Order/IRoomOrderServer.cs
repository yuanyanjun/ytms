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
        /// 获取记录列表
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        List<RoomRecordsDto> GetRecordList(RecordQueryFilter filter);

        /// <summary>
        /// 退房
        /// </summary>
        /// <param name="recordId"></param>
        /// <param name="thirdPercent"></param>
        /// <param name="checkouts"></param>
        /// <returns></returns>
        bool CheckOut(long recordId, decimal thirdPercent, List<RoomCheckOutDto> checkouts);
    }
}
