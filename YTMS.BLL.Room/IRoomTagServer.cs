using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace YTMS.BLL.Room
{
    public interface IRoomTagServer
    {
        /// <summary>
        /// 新增标签
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        int Add(RoomTagDto dto);

        /// <summary>
        /// 修改标签
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        bool Edit(RoomTagDto dto);

        /// <summary>
        /// 删除标签
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Remove(int id);

        /// <summary>
        /// 获取标签
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        RoomTagDto Get(int id);

        /// <summary>
        /// 获取标签列表
        /// </summary>
        /// <returns></returns>
        List<RoomTagDto> List();

        /// <summary>
        /// 获取标签列表
        /// </summary>
        /// <returns></returns>
        List<RoomTagDto> List(List<int> ids);


        /// <summary>
        /// 验证名称是否存在
        /// </summary>
        /// <param name="name"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        bool ExistName(string name, int? id);
    }
}
