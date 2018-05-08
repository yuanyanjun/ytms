using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YTMS.Common.Core
{
    public static class DateTimeExt
    {
        /// <summary>
        /// 将日期时间置为当天最小时间
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static DateTime ToCurrentDayMinVal(this DateTime d)
        {
            return new DateTime(d.Year, d.Month, d.Day, 0, 0, 0);
        }

        /// <summary>
        /// 将日期时间置为当天最大时间
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static DateTime ToCurrentDayMaxVal(this DateTime d)
        {
            return new DateTime(d.Year, d.Month, d.Day, 23, 59, 59);
        }
    }
}
