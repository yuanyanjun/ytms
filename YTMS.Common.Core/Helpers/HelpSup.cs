using System;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace YTMS.Common.Core
{
    public class HelpSup
    {
       
        public static string Get32bitMd5(string str)
        {
            string cl = str;
            string pwd = "";
            MD5 md5 = MD5.Create();//实例化一个md5对像
            // 加密后是一个字节类型的数组，这里要注意编码UTF8/Unicode等的选择　
            byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(cl));
            // 通过使用循环，将字节类型的数组转换为字符串，此字符串是常规字符格式化所得
            for (int i = 0; i < s.Length; i++)
            {
                // 将得到的字符串使用十六进制类型格式。格式后的字符是小写的字母，如果使用大写（X）则格式后的字符是大写字符  X2 防止字节位数不够
                pwd = pwd + s[i].ToString("X2");
            }
            return pwd;
        }

        /// <summary>
        /// 获取十位时间戳   某时间距1970年的时间差秒数
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static string Get10BitTimeStamp(System.DateTime time)
        {
            DateTime startTime = DateTime.Parse("01/01/1970");
            return Convert.ToInt64((time - startTime).TotalSeconds).ToString();
        }

        /// <summary>
        /// 获取十位时间戳   某时间距1970年的时间差秒数
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static long Get10BitTimeStamp2(System.DateTime time)
        {
            DateTime startTime = DateTime.Parse("01/01/1970");
            return Convert.ToInt64((time - startTime).TotalSeconds);
        }

        /// <summary>
        /// 获取验证码
        /// </summary>
        /// <param name="count">验证码位数</param>
        /// <param name="min">随机数下限</param>
        /// <param name="max">随机数上限</param>
        /// <returns></returns>
        public static string GetRdmNum(int count, int min, int max)
        {
            var builder = new StringBuilder();
            for (var i = 0; i < count; i++)
            {
                builder.Append(new Random(Guid.NewGuid().GetHashCode()).Next(min, max));
            }
            return builder.ToString();
        }

        /// <summary>
        /// 生成订单号，格式：年数末2位+从1970年开始到现在的总秒数后8位+随机3位数，总共13位
        /// </summary>
        /// <returns></returns>
        public static string GenerateOrderNo()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            var year = DateTime.Now.ToString("yy");
            var timespan = Convert.ToInt64(ts.TotalSeconds).ToString().Substring(2, 8);
            var random = new Random().Next(100, 999);
            return year + timespan + random;
        }
    }
}