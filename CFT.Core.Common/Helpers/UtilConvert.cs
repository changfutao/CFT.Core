using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFT.Core.Common.Helpers
{
    /// <summary>
    /// 数据类型转换
    /// </summary>
    public static class UtilConvert
    {
        public static int ToInt(this object thisValue)
        {
            int reval = 0;
            if (thisValue == null)
                return 0;
            if (thisValue != null && thisValue != DBNull.Value && int.TryParse(thisValue.ToString(), out reval))
            {
                return reval;
            }
            return reval;
        }

        public static int ToInt(this object thisValue, int errorValue)
        {
            int reval;
            if (thisValue != null && DBNull.Value != thisValue && int.TryParse(thisValue.ToString(), out reval))
            {
                return reval;
            }
            return errorValue;
        }

        public static long ToLong(this object s)
        {
            if(s == null || s == DBNull.Value)
            {
                return 0L;
            }

            long.TryParse(s.ToString(), out long result);
            return result;
        }

        public static double ToMoney(this object thisValue)
        {
            if(thisValue != null && thisValue != DBNull.Value && double.TryParse(thisValue.ToString(), out double reval))
            {
                return reval;
            }
            return 0;
        }

        public static double ToMoney(this object thisValue, double errorValue)
        {
            double reval;
            if (thisValue != null && thisValue != DBNull.Value && double.TryParse(thisValue.ToString(), out reval))
            {
                return reval;
            }
            return errorValue;
        }

        public static string ToString(this object thisValue)
        {
            if(thisValue != null)
            {
                return thisValue.ToString().Trim();
            }

            return string.Empty;
        }
    }
}
