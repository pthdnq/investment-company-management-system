using System;
using System.Collections.Generic;
using System.Web;
using TZMS.Web.CommonControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using Com.iFlytek.OA.MUDCommon;

namespace TZMS
{
    public class Common
    {
        /// <summary>
        /// 最大金额
        /// </summary>
       public const Int64 MaxMoney = 9999999999999999;

        /// <summary>
        /// 部门
        /// </summary>
        public static class DEPT
        {
            /// <summary>
            /// 行政部 
            /// </summary>
            static public string XINGZHENG = "行政部";

            /// <summary>
            /// 财务部
            /// </summary>
            static public string CAIWU = "财务部";

            /// <summary>
            /// 投资部
            /// </summary>
            static public string TOUZI = "投资部";

            /// <summary>
            /// 业务部
            /// </summary>
            static public string YEWU = "业务部";

            /// <summary>
            /// 总经办
            /// </summary>
            static public string ZJB = "总经办";

            /// <summary>
            /// 结算中心
            /// </summary>
            static public string JSZX = "结算中心";

        }

        /// <summary>
        /// 资金流方向
        /// </summary>
        public static class FlowDirection
        {
            /// <summary>
            /// 支出 
            /// </summary>
            static public string Payment = "Payment";

            /// <summary>
            /// 收入
            /// </summary>
            static public string Receive = "Receive";
        }

        /// <summary>
        /// 业务类型
        /// </summary>
        public static class Biz
        {
            /// <summary>
            /// 投资部借款 
            /// </summary>
            public static string InvestmentLoan = "投资部借款";

            /// <summary>
            /// 项目实施 
            /// </summary>
            public static string InvestmentProject = "项目实施";

            /// <summary>
            /// 银行贷款 
            /// </summary>
            public static string BankLoan = "银行贷款";

            /// <summary>
            /// 民间融资 
            /// </summary>
            public static string FolkFinancing = "民间融资";

            /// <summary>
            /// 工资发放
            /// </summary>
            public static string SalaryPayroll = "工资发放";

            /// <summary>
            /// 财务报销
            /// </summary>
            public static string BaoXiao = "财务报销";

            /// <summary>
            /// 代帐费
            /// </summary>
            public static string ProxyAccounting = "代账费";

            /// <summary>
            /// 业务费用收取
            /// </summary>
            public static string BusinessCost = "业务费用收取";

            /// <summary>
            /// 行政部备用金
            /// </summary>
            public static string AdminImprest = "行政部备用金";

            /// <summary>
            /// 行政支付
            /// </summary>
            public static string AdminPayment = "行政支付";

            /// <summary>
            /// 行政部收款上交
            /// </summary>
            public static string AdminReceivables = "行政部收款上交";

            /// <summary>
            /// 物资采购
            /// </summary>
            public static string MaterialsPurchase = "物资采购";

            /// <summary>
            /// 业务部备用金
            /// </summary>
            public static string ImprestBussiness = "业务部备用金";
        }

        #region 附件
        /// <summary>
        /// 保存附件
        /// </summary>
        /// <param name="systemName">systemName</param>
        /// <param name="recordId">recordId</param>
        /// <param name="attributeName">attributeName</param>
        public static void SaveAttachs(string systemName, string recordId, string attributeName)
        {
            MUDFilesCtrl fileCtrl = new MUDFilesCtrl();
            fileCtrl.AcceptFiles(string.Empty, systemName, attributeName, recordId);
        }

        /// <summary>
        /// 保存附件(新ID替换临时ID)
        /// </summary>
        /// <param name="systemName">systemName</param>
        /// <param name="newId">newId</param>
        /// <param name="oldId">oldId</param>
        /// <param name="attributeName">attributeName</param>
        public static void SaveAttachs(string systemName, string newId, string oldId, string attributeName)
        {
            MUDFilesCtrl fileCtrl = new MUDFilesCtrl();
            fileCtrl.AcceptFiles(string.Empty, systemName, oldId, attributeName, newId, string.Empty);
        }

        #region 删除附件
        /// <summary>
        /// 删除附件 by systemName And AttributeName
        /// </summary>
        /// <param name="systemName">systemName</param>
        /// <param name="attributeName">attributeName</param>
        public static void DeleteAttachs(string systemName, string attributeName)
        {
            string commondStr = "DELETE FROM MUDFiles WHERE ";

            if (!string.IsNullOrEmpty(systemName))
            {
                commondStr += " SystemName=" + systemName;
            }

            if (!string.IsNullOrEmpty(attributeName))
            {
                if (!string.IsNullOrEmpty(systemName))
                {
                    commondStr += " AND ";
                }
                commondStr += " AttributeName=" + attributeName;
            }

            SqlCommand sqlCommand = new SqlCommand(commondStr, mutiFilesConnection);
            try
            {
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                //throw new BizException("删除失败!" + e.Message);
            }
        }

        /// <summary>
        /// 删除附件 by recordId
        /// </summary>
        /// <param name="recordId">recordId</param>
        public static void DeleteAttachs(string recordId)
        {
            string commondStr = "DELETE FROM MUDFiles WHERE RecordID='" + recordId + "'";

            SqlCommand sqlCommand = new SqlCommand(commondStr, mutiFilesConnection);
            try
            {
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                //throw new BizException("删除失败!" + e.Message);
            }
        }

        /// <summary>
        /// 打开对附件数据库的连接
        /// </summary>
        public static void OpenMFConnection()
        {
            if (string.IsNullOrEmpty(mutiFilesConnection.ConnectionString))
            {
                mutiFilesConnection.ConnectionString = mutiFilesConnectionStr;
            }
            if (mutiFilesConnection.State != ConnectionState.Open)
            { //如果不是打开的状态，则打开
                mutiFilesConnection.Open();
            }
        }

        /// <summary>
        /// 关闭对附件数据库连接
        /// </summary>
        public static void CloseMFConnection()
        {
            mutiFilesConnection.Close();
        }

        /// <summary>
        /// 定义连接附件数据库的连接字符串
        /// </summary>
        private static string mutiFilesConnectionStr = ConfigurationManager.AppSettings["CONNECTIONSTRINGFORPROVINCE_EXPAND"].ToString();

        /// <summary>
        /// 共享的对多附件数据库的数据库联接
        /// </summary>
        private static SqlConnection mutiFilesConnection = new SqlConnection();

        #endregion

        /// <summary>
        /// 绑定附件列表
        /// </summary>
        /// <param name="control">control</param>
        /// <param name="systemName">systemName</param>
        /// <param name="recordId">recordId</param>
        /// <param name="attributeName">attributeName</param>
        /// <param name="canEdit">canEdit</param>
        public static void BindAttachsRecordInfo(MudFlexCtrl control, string systemName, string recordId, string attributeName, bool canEdit)
        {
            if (canEdit)
            {
                control.ShowAddBtn = "true";
                control.ShowDelBtn = "true";
            }
            else
            {
                control.ShowDelBtn = "false";
                control.ShowAddBtn = "false";
            }
            control.SystemName = systemName;
            control.RecordID = recordId;
            control.AttributeName = attributeName;

            MUDFilesCtrl fileCtrl = new MUDFilesCtrl();
            fileCtrl.ResetFiles(string.Empty, systemName, recordId, attributeName);
        }
        #endregion

        #region money转大写（整数部分）
        public class MoneyLowToUper
        {
            /// <summary>
            ///  获取money大写（两位小数）
            /// </summary>
            /// <param name="origanDec">两位小数</param>
            /// <param name="origanString">origanString</param>
            /// <returns>大写</returns>
            public string GetUperNumNames(decimal origanDec, string origanString = "")
            {
                origanString = GetUperNumNames((long)origanDec);
                long afterPoint = (long)((origanDec - (long)origanDec) * 100);
                // afterPoint = afterPoint.Split('.')[0];
                //小数部分 
                if (afterPoint.Equals(0))
                {
                    origanString += "整";
                }
                else
                {
                    long afterPoint1 = afterPoint / 10;
                    if (!afterPoint1.Equals(0))
                    {
                        origanString += string.Format("{0}角", GetUperSingleNumName(afterPoint1));
                    }
                    long afterPoint2 = afterPoint - afterPoint1 * 10;
                    if (!afterPoint2.Equals(0))
                    {
                        origanString += string.Format("{0}分", GetUperSingleNumName(afterPoint2));
                    }
                }
                return origanString;
            }
            /// <summary>
            /// 获取money大写（整数部分）
            /// </summary>
            /// <param name="origanDec">money int</param>
            /// <param name="origanString">大写字符串</param>
            /// <param name="NZero">位数</param>
            /// <returns>money大写字符串</returns>
            public string GetUperNumNames(long origanDec, string origanString = "", int NZero = 0)
            {
                origanString = origanString.Replace("零零", "零");
                if (origanDec == 0)
                {
                    // GetUperSingleNumName(origanDec) + origanString; 
                    return origanString.Replace("零零", "零").Replace("零元", "元").Replace("零万", "万").Replace("零亿", "亿");
                }
                else
                {
                    string tmp = GetUperSingleNumName(origanDec - origanDec / 10 * 10);
                    if (!tmp.Equals("零"))
                    {
                        tmp += GetNZeroName(NZero);
                    }
                    else if (NZero == 0 || NZero == 4 || NZero == 8)
                    {
                        tmp = GetNZeroName(NZero);
                    }
                    origanString = tmp + origanString;
                    return GetUperNumNames(origanDec / 10, origanString, ++NZero);
                }
            }

            /// <summary>
            /// 获取money大写（整数部分）
            /// </summary>
            /// <param name="origanDec">money int</param>
            /// <param name="origanString">大写字符串</param>
            /// <param name="NZero">位数</param>
            /// <returns>money大写字符串</returns>
            public string GetUperNumNames(int origanDec, string origanString = "", int NZero = 0)
            {
                origanString = origanString.Replace("零零", "零");
                if (origanDec == 0)
                {
                    // GetUperSingleNumName(origanDec) + origanString; 
                    return origanString.Replace("零零", "零").Replace("零元", "元").Replace("零万", "万").Replace("零亿", "亿");
                }
                else
                {
                    string tmp = GetUperSingleNumName(origanDec - origanDec / 10 * 10);
                    if (!tmp.Equals("零"))
                    {
                        tmp += GetNZeroName(NZero);
                    }
                    else if (NZero == 0 || NZero == 4 || NZero == 8)
                    {
                        tmp = GetNZeroName(NZero);
                    }
                    origanString = tmp + origanString;
                    return GetUperNumNames(origanDec / 10, origanString, ++NZero);
                }
            }

            /// <summary>
            /// 获取单个数字大写
            /// </summary>
            /// <param name="lowerNum">数字</param>
            /// <returns>大写</returns>
            private string GetUperSingleNumName(long lowerNum)
            {
                string UperNumName = string.Empty;
                switch (lowerNum)
                {
                    case 0: UperNumName = "零"; break;
                    case 1: UperNumName = "壹"; break;
                    case 2: UperNumName = "贰"; break;
                    case 3: UperNumName = "叁"; break;
                    case 4: UperNumName = "肆"; break;
                    case 5: UperNumName = "伍"; break;
                    case 6: UperNumName = "陆"; break;
                    case 7: UperNumName = "柒"; break;
                    case 8: UperNumName = "捌"; break;
                    case 9: UperNumName = "玖"; break;
                    default: break;
                }
                return UperNumName;
            }

            /// <summary>
            /// 获取位数单位
            /// </summary>
            /// <param name="NZero">几个零</param>
            /// <returns>单位</returns>
            private string GetNZeroName(int NZero)
            {
                string name = string.Empty;
                switch (NZero)
                {
                    case 0: name = "元"; break;
                    case 1: name = "拾"; break;
                    case 2: name = "佰"; break;
                    case 3: name = "仟"; break;
                    case 4: name = "万"; break;
                    case 5: name = "拾"; break;
                    case 6: name = "佰"; break;
                    case 7: name = "仟"; break;
                    case 8: name = "亿"; break;
                    case 9: name = "拾"; break;
                    case 10: name = "佰"; break;
                    default: name = ""; break;
                }
                return name;
            }
        }

        #endregion

    }
}