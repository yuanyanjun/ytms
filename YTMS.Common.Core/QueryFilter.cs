using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YTMS.Common.Core
{
    public class QueryFilter
    {
        /// <summary>
        /// 关键字
        /// </summary>
        public string Keywords { get; set; }
    }

    public class QueryPageFilter : QueryFilter
    {
        private int _pageIndex = 1;
        private int _pageSize = 20;

        /// <summary>
        /// 当前页码
        /// </summary>
        public int PageIndex
        {
            get
            {
                return _pageIndex;
            }
            set
            {
                _pageIndex = value;
            }
        }

        /// <summary>
        /// 单次获取记录数
        /// </summary>
        public int PageSize
        {

            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = value;
            }
        }

        /// <summary>
        /// 总记录数
        /// </summary>
        public int TotalCount { get; set; }
    }
}
