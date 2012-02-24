using System;
using System.Collections.Generic;
using System.Text;

namespace com.TZMS.Model
{
    [Serializable]
    public class ACommonInfo
    {
        /// <summary>
        /// 数据库空字符串
        /// </summary>
        public const string DBEmptyString = "";

        /// <summary>
        /// 最小时间
        /// </summary>
        public static DateTime DBEmptyDate = DateTime.Parse("1900-1-1 12:00");

        /// <summary>
        /// 最大时间
        /// </summary>
        public static DateTime DBMAXDate = DateTime.Parse("9999-1-1 12:00");

        /// <summary>
        /// 数据库空tinyint
        /// </summary>
        public const char DBEmptyChar = (char)199;

        /// <summary>
        /// 数据库空short
        /// </summary>
        public const short DBEmptyShort = 199;

        /// <summary>
        ///数据库空Decimal
        /// </summary>
        public const Decimal DBEmptyDecimal = Decimal.Zero;

        /// <summary>
        /// 数据库空int
        /// </summary>
        public const int DBEmptyInt = -1;

        /// <summary>
        /// 数据库空int
        /// </summary>
        public const int DBEmptyTinyInt = 0;

        /// <summary>
        /// 将小数点后面的无效的0去掉
        /// </summary>
        /// <param name="temp"></param>
        /// <returns></returns>
        public Decimal GetDecimal(Decimal temp)
        {
            string strTemp = temp.ToString();
            string[] strs = strTemp.Split('.');
            if (strs.Length > 1)
            {
                string str = strs[1];
                if (str.Contains("00"))
                    return Decimal.Parse(strs[0]);
                if (strTemp.Contains(".0"))
                {
                    return temp;
                }
                if (str.Contains("0"))
                {
                    string ss = strTemp.Substring(0, strTemp.Length - 1);
                    return Decimal.Parse(ss);
                }
            }
            return temp;
        }
    }
}
