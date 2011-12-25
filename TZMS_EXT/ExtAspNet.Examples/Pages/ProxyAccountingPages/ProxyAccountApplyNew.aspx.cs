using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Text.RegularExpressions;
using ExtAspNet;
using com.TZMS.Model;
using com.TZMS.Business;

namespace TZMS.Web
{
    public partial class ProxyAccountApplyNew : BasePage
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
                    case "Add":
                        {
                            OperatorType = strOperatorType;
                            dpkOpeningDate.SelectedDate = DateTime.Now;
                            tabApproveHistory.Hidden = true;
                            // 绑定下一步.
                            BindNext();
                            // 绑定单位.
                            BindUnit();
                            // 绑定审批人.
                            ApproveUser();
                        }
                        break;
                    case "View":
                        {
                            OperatorType = strOperatorType;
                            ApplyID = strApplyID;

                            // 绑定下一步.
                            BindNext();
                            // 绑定单位.
                            BindUnit();
                            // 绑定审批人.
                            ApproveUser();
                            // 绑定申请单信息.
                            BindApplyInfo();
                            // 绑定审批历史.
                            BindApproveHistory();
                            // 禁用所有控件.
                            DisableAllControls();
                        }
                        break;
                    case "Edit":
                        {
                            OperatorType = strOperatorType;
                            ApplyID = strApplyID;

                            // 绑定下一步.
                            BindNext();
                            // 绑定单位.
                            BindUnit();
                            // 绑定审批人.
                            ApproveUser();
                            // 绑定申请单信息.
                            BindApplyInfo();
                            // 绑定审批历史.
                            BindApproveHistory();
                        }
                        break;
                    default:
                        break;
                }

                if (ddlstApproveUser.SelectedItem == null)
                {
                    Alert.Show("您的“执行人”为空，请在我的首页设置我的审批人！");
                }
            }
        }

        #region 私有方法

        /// <summary>
        /// 绑定下一步
        /// </summary>
        private void BindNext()
        {
            ddlstNext.Items.Add(new ExtAspNet.ListItem("审批", "0"));
            ddlstNext.SelectedIndex = 0;
        }

        /// <summary>
        /// 绑定单位
        /// </summary>
        private void BindUnit()
        {
            ProxyAccountingManage _manage = new ProxyAccountingManage();
            List<ProxyAccountingUnitInfo> lstUnit = _manage.GetUnitByCondition(" IsDelete <> 1 and AccountancyID = '" + CurrentUser.ObjectId.ToString() + "'");
            foreach (var unit in lstUnit)
            {
                ddlstUnit.Items.Add(new ExtAspNet.ListItem(unit.UnitName, unit.ObjectID.ToString()));
            }

            ddlstUnit.SelectedIndex = 0;
        }

        /// <summary>
        /// 绑定审批人
        /// </summary>
        private void ApproveUser()
        {
            foreach (UserInfo user in CurrentChecker)
            {
                ddlstApproveUser.Items.Add(new ExtAspNet.ListItem(user.Name, user.ObjectId.ToString()));
            }

            ddlstApproveUser.SelectedIndex = 0;
        }

        /// <summary>
        /// 提交报销申请单
        /// </summary>
        private void SaveApply()
        {
            if (OperatorType == null)
                return;
            ProxyAccountingApplyInfo _applyInfo = null;
            ProxyAccountingUnitInfo _unitInfo = null;
            ProxyAccountingManage _manage = new ProxyAccountingManage();
            int result = 3;

            _unitInfo = _manage.GetUnitByObjectID(ddlstUnit.SelectedValue);

            #region 添加申请单

            if (OperatorType == "Add" && _unitInfo != null)
            {
                // 创建报销单实例.

                _applyInfo = new ProxyAccountingApplyInfo();
                _applyInfo.ObjectID = Guid.NewGuid();
                _applyInfo.PayUnitID = new Guid(ddlstUnit.SelectedValue);
                _applyInfo.PayUnitName = ddlstUnit.SelectedText;
                _applyInfo.CNMoney = lblCNMoney.Text;
                _applyInfo.ENMoney = Convert.ToDecimal(tbxMoney.Text.Trim());
                _applyInfo.Sument = tbxSument.Text.Trim();
                _applyInfo.OpeningDate = Convert.ToDateTime(dpkOpeningDate.SelectedDate);
                _applyInfo.CollectMethod = ddlstCollectMethod.SelectedText;
                _applyInfo.ProxyAccountingID = _unitInfo.AccountancyID;
                _applyInfo.ProxyAccountingName = _unitInfo.AccountancyName;
                _applyInfo.State = 0;
                _applyInfo.ApproverID = new Guid(ddlstApproveUser.SelectedValue);
                _applyInfo.IsDelete = false;

                // 插入新报销单.
                result = _manage.AddNewApply(_applyInfo);

                // 插入起草记录到代帐费审批流程表.
                UserInfo _draftUser = new UserManage().GetUserByObjectID(_unitInfo.AccountancyID.ToString());
                ProxyAccountingApproveInfo _approveInfo = new ProxyAccountingApproveInfo();
                _approveInfo.ObjectID = Guid.NewGuid();
                _approveInfo.ApproverID = _draftUser.ObjectId;
                _approveInfo.ApproverName = _draftUser.Name;
                _approveInfo.ApproverDept = _draftUser.Dept;
                _approveInfo.ApproveDate = DateTime.Now;
                _approveInfo.ApproveState = 0;
                _approveInfo.ApproveOp = 0;
                _approveInfo.ApplyID = _applyInfo.ObjectID;
                _manage.AddNewApprove(_approveInfo);

                // 插入待审批记录到报销审批流程表.
                _approveInfo = new ProxyAccountingApproveInfo();
                UserInfo _approveUser = new UserManage().GetUserByObjectID(ddlstApproveUser.SelectedValue);
                _approveInfo.ObjectID = Guid.NewGuid();
                _approveInfo.ApproverID = _approveUser.ObjectId;
                _approveInfo.ApproverName = _approveUser.Name;
                _approveInfo.ApproverDept = _approveUser.Dept;
                _approveInfo.ApproveDate = ACommonInfo.DBEmptyDate;
                _approveInfo.ApproveState = 0;
                _approveInfo.ApplyID = _applyInfo.ObjectID;

                _manage.AddNewApprove(_approveInfo);

            }
            #endregion

            #region 编辑申请单

            if (OperatorType == "Edit" && _unitInfo != null)
            {
                _applyInfo = _manage.GetApplyByObjectID(ApplyID);
                if (_applyInfo != null)
                {
                    // 更新申请单中的数据.
                    _applyInfo.PayUnitID = new Guid(ddlstUnit.SelectedValue);
                    _applyInfo.PayUnitName = ddlstUnit.SelectedText;
                    _applyInfo.CNMoney = lblCNMoney.Text;
                    _applyInfo.ENMoney = Convert.ToDecimal(tbxMoney.Text.Trim());
                    _applyInfo.Sument = tbxSument.Text.Trim();
                    _applyInfo.OpeningDate = Convert.ToDateTime(dpkOpeningDate.SelectedDate);
                    _applyInfo.CollectMethod = ddlstCollectMethod.SelectedText;
                    _applyInfo.ProxyAccountingID = _unitInfo.AccountancyID;
                    _applyInfo.ProxyAccountingName = _unitInfo.AccountancyName;
                    _applyInfo.State = 0;
                    _applyInfo.ApproverID = new Guid(ddlstApproveUser.SelectedValue);

                    result = _manage.UpdateApply(_applyInfo);

                    // 插入待审批记录到报销审批流程表.
                    ProxyAccountingApproveInfo _approveInfo = new ProxyAccountingApproveInfo();
                    UserInfo _approveUser = new UserManage().GetUserByObjectID(ddlstApproveUser.SelectedValue);
                    _approveInfo.ObjectID = Guid.NewGuid();
                    _approveInfo.ApproverID = _approveUser.ObjectId;
                    _approveInfo.ApproverName = _approveUser.Name;
                    _approveInfo.ApproverDept = _approveUser.Dept;
                    _approveInfo.ApproveDate = ACommonInfo.DBEmptyDate;
                    _approveInfo.ApproveState = 0;
                    _approveInfo.ApplyID = _applyInfo.ObjectID;

                    _manage.AddNewApprove(_approveInfo);
                }
            }

            #endregion

            if (result == -1)
            {
                //Alert.Show("申请提交成功!");
                //btnSubmit.Enabled = false;
                //tabApproveHistory.Hidden = false;
                //ApplyID = _applyInfo.ObjectID.ToString();
                //BindApproveHistory();

                this.btnClose_Click(null, null);
            }
            else
            {
                Alert.Show("申请提交失败!");
            }

        }

        /// <summary>
        /// 绑定报销单申请信息
        /// </summary>
        private void BindApplyInfo()
        {
            ProxyAccountingManage _manage = new ProxyAccountingManage();
            ProxyAccountingApplyInfo _info = _manage.GetApplyByObjectID(ApplyID);
            if (_info != null)
            {
                ddlstUnit.SelectedValue = _info.PayUnitID.ToString();
                lblCNMoney.Text = _info.CNMoney;
                tbxMoney.Text = _info.ENMoney.ToString();
                tbxSument.Text = _info.Sument;
                ddlstCollectMethod.SelectedValue = _info.CollectMethod;
                dpkOpeningDate.SelectedDate = _info.OpeningDate;

                // 查找最早的审批记录.
                List<ProxyAccountingApproveInfo> lstApprove = _manage.GetApproveByCondition(" ApplyID = '" + ApplyID + "' and ApproveOp <> 0");
                if (lstApprove.Count == 1)
                {
                    ddlstApproveUser.SelectedValue = lstApprove[0].ApproverID.ToString();
                }
                else
                {
                    lstApprove.Sort(delegate(ProxyAccountingApproveInfo x, ProxyAccountingApproveInfo y) { return DateTime.Compare(x.ApproveDate, y.ApproveDate); });
                    foreach (var item in lstApprove)
                    {
                        if (DateTime.Compare(item.ApproveDate, ACommonInfo.DBEmptyDate) != 0)
                        {
                            ddlstApproveUser.SelectedValue = item.ApproverID.ToString();
                            break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 禁用所有控件.
        /// </summary>
        private void DisableAllControls()
        {
            ddlstUnit.Required = false;
            ddlstUnit.ShowRedStar = false;
            ddlstUnit.Enabled = false;
            btnSubmit.Enabled = false;
            ddlstNext.Required = false;
            ddlstNext.ShowRedStar = false;
            ddlstNext.Enabled = false;
            ddlstApproveUser.Required = false;
            ddlstApproveUser.ShowRedStar = false;
            ddlstApproveUser.Enabled = false;
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
        /// 绑定审批历史
        /// </summary>
        private void BindApproveHistory()
        {
            if (ApplyID == null)
                return;
            // 获取数据.
            StringBuilder strCondition = new StringBuilder();
            strCondition.Append(" ApplyID = '" + ApplyID + "'");
            strCondition.Append(" and  (ApproveState <> 0 or (ApproveState = 0 and ApproveOp = 0))");
            List<ProxyAccountingApproveInfo> lstBaoxiaoCheckInfo = new ProxyAccountingManage().GetApproveByCondition(strCondition.ToString());

            lstBaoxiaoCheckInfo.Sort(delegate(ProxyAccountingApproveInfo x, ProxyAccountingApproveInfo y) { return DateTime.Compare(y.ApproveDate, x.ApproveDate); });

            // 绑定列表.
            gridApproveHistory.RecordCount = lstBaoxiaoCheckInfo.Count;
            this.gridApproveHistory.DataSource = lstBaoxiaoCheckInfo;
            this.gridApproveHistory.DataBind();
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
        /// 金额变动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void tbxMoney_TextChanged(object sender, EventArgs e)
        {
            double money;
            if (double.TryParse(tbxMoney.Text.Trim(), out money))
            {
                lblCNMoney.Text = Format(money);
                if (!this.ckYear.Checked)
                {
                    tbxSument.Text = Convert.ToDateTime(dpkOpeningDate.SelectedDate).ToString("yyyy年MM月dd日代账") + tbxMoney.Text.Trim() + "元";
                }
                else
                {
                    tbxSument.Text = Convert.ToDateTime(dpkOpeningDate.SelectedDate).ToString("yyyy年MM月dd日年检") + tbxMoney.Text.Trim() + "元";
                }
            }
        }

        /// <summary>
        /// 开票日期变动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void dpkOpeningDate_TextChanged(object sender, EventArgs e)
        {
            tbxSument.Text = Convert.ToDateTime(dpkOpeningDate.SelectedDate).ToString("yyyy年MM月dd日代账") + tbxMoney.Text.Trim() + "元";
        }

        /// <summary>
        /// 数据行绑定事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridApproveHistory_RowDataBound(object sender, ExtAspNet.GridRowEventArgs e)
        {
            if (e.DataItem != null)
            {
                e.Values[1] = DateTime.Parse(e.Values[1].ToString()).ToString("yyyy-MM-dd HH:mm");
                switch (e.Values[2].ToString())
                {
                    case "0":
                        e.Values[2] = "起草";
                        break;
                    case "1":
                        e.Values[2] = "审批-通过";
                        break;
                    case "2":
                        e.Values[2] = "审批-不通过";
                        break;
                    case "3":
                        e.Values[2] = "归档";
                        break;
                    default:
                        break;
                }
            }
        }

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
        /// 提交事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SaveApply();
        }

        #endregion
    }
}