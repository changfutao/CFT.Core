using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFT.Core.Common.Helpers
{
    /// <summary>
    /// 字符串帮助类
    /// </summary>
    public class StringHelper
    {
        private static readonly char[] _contant = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

        /// <summary>
        /// 生成随机字符串, 默认32位
        /// </summary>
        /// <param name="length">随机数的长度</param>
        /// <returns></returns>
        public static string GenerateRandom(int length = 32)
        {
            StringBuilder newRandom = new StringBuilder();
            var rd = new Random();
            for (int i = 0; i < length; i++)
            {
                newRandom.Append(_contant[rd.Next(_contant.Length)]);
            }
            return newRandom.ToString();
        }

        /// <summary>
        /// 生成随机字符串,只包含数字
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string GenerateRandomNumber(int length = 6)
        {
            var newRandom = new StringBuilder();
            var rd = new Random();
            for (int i = 0; i < length; i++)
            {
                newRandom.Append(rd.Next(10));
            }
            return newRandom.ToString();
        }

        public static string Format(string str, object obj)
        {

            return string.Empty;
        }
    }
}
