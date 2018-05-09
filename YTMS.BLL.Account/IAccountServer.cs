using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YTMS.BLL.Account
{
    public interface IAccountServer
    {
        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        long Add(AdminDto dto);


        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        bool Edit(AdminDto dto);

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="account"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        bool EditPassword(string account, string password);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Remove(long id);

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        AdminDto Get(long id);

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        AdminDto Get(string userName);

        /// <summary>
        /// 验证账号是否存在
        /// </summary>
        /// <param name="account"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        bool ExistName(string account, long? id);

        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        List<AdminDto> List(AdminQueryFilter filter);
    }
}
