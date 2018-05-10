using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YTMS.BLL.Room
{
    public interface IOwnerServer
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        long Add(OwnerDto dto);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        bool Edit(OwnerDto dto);

        /// <summary>
        /// 修改客房数量
        /// </summary>
        /// <param name="id"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        bool EditRoomNun(long id, int num);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Deleted(long id);

        /// <summary>
        /// 获取信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        OwnerDto Get(long id);

        /// <summary>
        /// 获取业主列表
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        List<OwnerDto> List(OwnerQueryFilter filter);
    }
}
