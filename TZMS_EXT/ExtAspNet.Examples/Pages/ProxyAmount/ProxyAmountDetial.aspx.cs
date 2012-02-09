using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.TZMS.Business.ProxyAmount;
using com.TZMS.Model;
using ExtAspNet;
using System.Text;
using System.Text.RegularExpressions;

namespace TZMS.Web
{
    public partial class ProxyAmountDetial : BasePage
    {
        /// <summary>
        /// 操作类型
        /// </summary>
        public string OperatorType
        {
            get
            {
                if (ViewState["OperatorType"] == null)
                {
                    return null;
                }

                return ViewState["OperatorType"].ToString();
            }
            set
            {
                ViewState["OperatorType"] = value;
            }
        }

        /// <summary>
        /// 报销单ID
        /// </summary>
        public string ApplyID
        {
            get
            {
                if (ViewState["ApplyID"] == null)
                {
                    return null;
                }

                return ViewState["ApplyID"].ToString();
            }
            set
            {
                ViewState["ApplyID"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string strOperatorType = Request.QueryString["Type"];
                string strApplyID = Request.QueryString["ID"];

                switch (strOperatorType)
                {
                    case "View":
                        {
                            OperatorType = strOperatorType;
                            ApplyID = strApplyID;

                            BindApplyInfo();
                            // 禁用所有控件.
                            DisableAllControls();
                        }
                        break;
                    case "Edit":
                        {
                            OperatorType = strOperatorType;
                            ApplyID = strApplyID;

                            BindApplyInfo();
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        #region 私有方法

        /// <summary>
        /// 提交报销申请单
        /// </summary>
        private void SaveApply()
        {
            if (OperatorType == null)
                return;
            ProxyAmountInfo _applyInfo = null;
            ProxyAmountManage _manage = new ProxyAmountManage();
            int result = 3;

            _applyInfo = _manage.GetProxyAmountByObjectID(ApplyID);
            if (_applyInfo != null)
            {
                // 更新申请单中的数据.
                _applyInfo.CNMoney = lblCNMoney.Text;
                _applyInfo.ENMoney = Convert.ToDecimal(tbxMoney.Text.Trim());
                _applyInfo.Sument = tbxSument.Text.Trim();
                _applyInfo.OpeningDate = Convert.ToDateTime(dpkOpeningDate.SelectedDate);
                _applyInfo.CollectMethod = ddlstCollectMethod.SelectedText;
                _applyInfo.State = 0;

                result = _manage.UpdateProxyAmount(_applyInfo);
            }

            if (result == -1)
            {
                this.btnClose_Click(null, null);
            }
            else
            {
                Alert.Show("编辑代帐单失败!");
            }
        }

        /// <summary>
        /// 绑定报销单申请信息
        /// </summary>
        private void BindApplyInfo()
        {
            ProxyAmountManage _manage = new ProxyAmountManage();
            ProxyAmountInfo _info = _manage.GetProxyAmountByObjectID(ApplyID);
            if (_info != null)
            {
                lblAmountType.Text = _info.ProxyAmountType == 0 ? "代帐费" : "年检费";
                lblUnitName.Text = _info.ProxyAmountUnitName;
                lblCNMoney.Text = _info.CNMoney;
                tbxMoney.Text = _info.ENMoney.ToString();
                ddlstCollectMethod.SelectedValue = _info.CollectMethod;
                tbxSument.Text = _info.Sument;
                ddlstCollectMethod.SelectedValue = _info.CollectMethod;
                dpkOpeningDate.SelectedDate = _info.OpeningDate;
            }
        }

        /// <summary>
        /// 禁用所有控件.
        /// </summary>
        private void DisableAllControls()
        {
            btnSubmit.Enabled = false;
            tbxMoney.Required = false;
            tbxMoney.ShowRedStar = false;
            tbxMoney.Enabled = false;
            tbxSument.Required = false;
            tbxSument.ShowRedStar = false;
            tbxSument.Enabled = false;
            ddlstCollectMethod.Required = false;
            ddlstCollectMethod.ShowRedStar = false;
            ddlstCollectMethod.Enabled = false;
            dpkOpeningDate.Required = false;
            dpkOpeningDate.ShowRedStar = false;
            dpkOpeningDate.Enabled = false;
        }

        /// <summary>
        /// 格式化（小写转大写）
        /// </summary>
        /// <param name="numRMB"></param>
        /// <returns></returns>
        public static string Format(double numRMB)
        {
            try
            {
                if (0 == numRMB)
                    return "零元整";

                StringBuilder szRMB = new StringBuilder();

                //乘100以格式成整型，便于处理
                ulong iRMB = Convert.ToUInt64(numRMB * 100);

                szRMB.Insert(0, ToUpper(Convert.ToInt32(iRMB % 100), -2));

                //去掉原来的小数位
                iRMB = iRMB / 100;

                int iUnit = 0;

                //以每4位为一个单位段进行处理，所以下边除以10000
                while (iRMB != 0)
                {
                    szRMB.Insert(0, ToUpper(Convert.ToInt32(iRMB % 10000), iUnit));
                    iRMB = iRMB / 10000;
                    iUnit += 4;
                }

                string strRMB = szRMB.ToString();

                //格式修正
                strRMB = Regex.Replace(strRMB, "零+", "零");
                strRMB = strRMB.Replace("元零整", "元整");
                strRMB = strRMB.Replace("零元", "元");

                return strRMB.Trim('零');
            }
            catch
            {
                return "";
            }
        }

        /// <summary>
        /// 计算表达式（小写数值求大写字符串）
        /// </summary>
        /// <param name="numRMB"></param>
        /// <param name="iUnit"></param>
        /// <returns></returns>
        private static string ToUpper(int numRMB, int iUnit)
        {
            try
            {
                if (0 == numRMB)
                {
                    if (iUnit == -2)
                    {
                        return "整";
                    }

                    if (iUnit == 0)
                    {
                        return "元";
                    }

                    return "零";
                }

                StringBuilder szRMB = new StringBuilder();

                string strRMB = "";

                #region 对角/分做特殊处理

                if (iUnit == -2)
                {
                    int jiao = numRMB / 10;
                    int fen = numRMB % 10;

                    if (jiao > 0)
                    {
                        szRMB.Append(jiao);
                        szRMB.Append(GetUnit(-1));

                        if (fen > 0)
                        {
                            szRMB.Append(fen);
                            szRMB.Append(GetUnit(-2));
                        }
                    }
                    else
                    {
                        szRMB.Append(fen);
                        szRMB.Append(GetUnit(-2));
                    }

                    return Replace(szRMB.ToString(), true);
                }

                #endregion

                #region 以下为整数部分正常处理

                strRMB = numRMB.ToString("0000");

                //前一位是否是0
                bool hasZero = false;

                for (int i = 0; i < strRMB.Length; i++)
                {
                    //只有四位，最高位为‘千’，所以下边的3-i为单位修正
                    if ((3 - i) > 0)
                    {
                        if ('0' != strRMB[i])
                        {
                            szRMB.Append(strRMB[i]);
                            szRMB.Append(GetUnit(3 - i));
                            hasZero = false;
                        }
                        else
                        {
                            if (!hasZero)
                                szRMB.Append(strRMB[i]);

                            hasZero = true;
                        }
                    }
                    //最后一位，特别格式处理
                    //如最后一位是零，则单位应在零之前
                    else
                    {
                        if ('0' != strRMB[i])
                        {
                            szRMB.Append(strRMB[i]);
                            szRMB.Append(GetUnit(iUnit));
                            hasZero = false;
                        }
                        else
                        {
                            if (hasZero)
                            {
                                szRMB.Insert(szRMB.Length - 1, GetUnit(iUnit));
                            }
                            else
                            {
                                szRMB.Append(GetUnit(iUnit));
                                szRMB.Append(strRMB[i]);
                            }
                        }
                    }
                }

                //转换大写后返回
                return Replace(szRMB.ToString(), true);

                #endregion
            }
            catch
            {
                return "";
            }
        }

        /// <summary>
        /// 获取单位名称
        /// </summary>
        /// <param name="iCode"></param>
        /// <returns></returns>
        private static string GetUnit(int iCode)
        {
            switch (iCode)
            {
                case -2:
                    return "分";
                case -1:
                    return "角";
                case 0:
                    return "元";
                case 1:
                    return "拾";
                case 2:
                    return "佰";
                case 3:
                    return "仟";
                case 4:
                    return "萬";
                case 8:
                    return "亿";
                default:
                    return "";
            }
        }

        /// <summary>
        /// 将中文大写换成阿拉伯数字
        /// </summary>
        /// <param name="strRMB"></param>
        /// <param name="toUpper">true--转换为大写/false--转换为小写</param>
        /// <returns></returns>
        private static string Replace(string strRMB, bool toUpper)
        {
            if (toUpper)
            {
                strRMB = strRMB.Replace("0", "零");
                strRMB = strRMB.Replace("1", "壹");
                strRMB = strRMB.Replace("2", "贰");
                strRMB = strRMB.Replace("3", "叁");
                strRMB = strRMB.Replace("4", "肆");
                strRMB = strRMB.Replace("5", "伍");
                strRMB = strRMB.Replace("6", "陆");
                strRMB = strRMB.Replace("7", "柒");
                strRMB = strRMB.Replace("8", "捌");
                strRMB = strRMB.Replace("9", "玖");
            }
            else
            {
                strRMB = strRMB.Replace("零", "0");
                strRMB = strRMB.Replace("壹", "1");
                strRMB = strRMB.Replace("贰", "2");
                strRMB = strRMB.Replace("叁", "3");
                strRMB = strRMB.Replace("肆", "4");
                strRMB = strRMB.Replace("伍", "5");
                strRMB = strRMB.Replace("陆", "6");
                strRMB = strRMB.Replace("柒", "7");
                strRMB = strRMB.Replace("捌", "8");
                strRMB = strRMB.Replace("玖", "9");
            }
            return strRMB;
        }

        #endregion

        #region 页面事件

        /// <summary>
        /// 关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnClose_Click(object sender, EventArgs e)
        {
            PageContext.RegisterStartupScript(ExtAspNet.ActiveWindow.GetHidePostBackReference());
        }

        /// <summary>
        /// 保存事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SaveApply();
        }

        /// <summary>
        /// 小写金额变动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void tbxMoney_TextChanged(object sender, EventArgs e)
        {
            double money;
            if (double.TryParse(tbxMoney.Text.Trim(), out money))
            {
                lblCNMoney.Text = Format(money);
            }
        }

        /// <summary>
        /// 开票日期变动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void dpkOpeningDate_TextChanged(object sender, EventArgs e)
        {
            double money;
            if (double.TryParse(tbxMoney.Text.Trim(), out money))
            {
                lblCNMoney.Text = Format(money);
                if (lblAmountType.Text == "代帐费")
                {
                    tbxSument.Text = Convert.ToDateTime(dpkOpeningDate.SelectedDate).ToString("yyyy年MM月代账") + tbxMoney.Text.Trim() + "元";
                }
                else
                {
                    tbxSument.Text = Convert.ToDateTime(dpkOpeningDate.SelectedDate).ToString("yyyy年年检") + tbxMoney.Text.Trim() + "元";
                }
            }
            //tbxSument.Text = Convert.ToDateTime(dpkOpeningDate.SelectedDate).ToString("yyyy年MM月dd日代账") + tbxMoney.Text.Trim() + "元";
        }

        #endregion
    }
}