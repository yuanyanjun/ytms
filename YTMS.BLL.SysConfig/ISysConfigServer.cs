using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using YTMS.Domain;
namespace YTMS.BLL.SysConfig
{
    public interface ISysConfigServer
    {
        /// <summary>
        /// 获取系统设置信息
        /// </summary>
        /// <returns></returns>
        SysConfigDto Get();

        /// <summary>
        /// 保存配置信息
        /// </summary>
        /// <param name="opt"></param>
        /// <returns></returns>
        bool Set(SysConfigDto opt);
    }
}
