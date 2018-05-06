using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YTMS.BLL.Order
{
    public enum OrderStatus
    {
        /// <summary>
        /// 预定
        /// </summary>
        Reserve=0,

        /// <summary>
        /// 入住
        /// </summary>
        CheckIn=1,

        /// <summary>
        /// 退房
        /// </summary>
        CheckOut=2,


        /// <summary>
        /// 结算
        /// </summary>
        Settlement = 3,

        /// <summary>
        /// 取消
        /// </summary>
        Canceled =4,

        
    }


    public enum OrderType
    {
        /// <summary>
        /// 普通
        /// </summary>
        Normal=0,

        /// <summary>
        /// 会员
        /// </summary>
        Member=1,

        /// <summary>
        /// 团购
        /// </summary>
        TeamOrder=2
    }
}
