using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YTMS.Common.Core
{
    /// <summary>
    /// 自定义异常类
    /// </summary>
    public class CustomerException : Exception
    {
        private int resultCode = 0;
        public CustomerException(string message) : base(message)
        {

        }

        public CustomerException(string message, int code) : base(message)
        {
            this.resultCode = code;
        }

        public int ResultCode
        {
            get { return resultCode; }
        }
    }
}
