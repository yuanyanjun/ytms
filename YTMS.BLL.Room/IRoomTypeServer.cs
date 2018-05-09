using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YTMS.BLL.Room
{
    public interface IRoomTypeServer
    {
        /// <summary>
        /// 新增房型
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        int Add(RoomTypeDto dto);

        /// <summary>
        /// 修改房型
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        bool Edit(RoomTypeDto dto);

        /// <summary>
        /// 删除房型
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Remove(int id);

        /// <summary>
        /// 获取房型
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        RoomTypeDto Get(int id);

        /// <summary>
        /// 获取房型列表
        /// </summary>
        /// <returns></returns>
        List<RoomTypeDto> List();

        /// <summary>
        /// 获取房型列表
        /// </summary>
        /// <returns></returns>
        List<RoomTypeDto> List(List<int> ids);


        /// <summary>
        /// 验证名称是否存在
        /// </summary>
        /// <param name="name"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        bool ExistName(string name, int? id);
    }
}
