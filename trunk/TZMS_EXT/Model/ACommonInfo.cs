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
        /// 数据库空字符串
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
    }
}
