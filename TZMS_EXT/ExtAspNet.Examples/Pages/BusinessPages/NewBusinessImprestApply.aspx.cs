using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExtAspNet;
using System.Text;
using com.TZMS.Business.BusinessManage;
using com.TZMS.Model;
using com.TZMS.Business;
using System.Text.RegularExpressions;

namespace TZMS.Web
{
    public partial class NewBusinessImprestApply : BasePage
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
                            lblName.Text = CurrentUser.Name;
                            lblApplyTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
                            tabApproveHistory.Hidden = true;
                            // 绑定下一步.
                            BindNext();
                            BindBusinessType();
                            // 绑定审批人.
                            ApproveUser();
                            this.ddlstBusinessType_SelectedIndexChanged(null, null);
                        }
                        break;
                    case "View":
                        {
                            OperatorType = strOperatorType;
                            ApplyID = strApplyID;

                            // 绑定下一步.
                            BindNext();
                            BindBusinessType();
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
                            BindBusinessType();
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
            else
            {
                //if (Request.Form["__EVENTTARGET"] != "pelMain$Toolbar1$btnSubmit" && Request.Form["__EVENTTARGET"] != "pelMain_Toolbar1_btnClose")
                //{
                    if (ddlstBusinessType.SelectedIndex == 0)
                    {
                        GenerateNormalImprest();
                    }
                    else
                    {
                        GenerateCustomizeImprest();
                    }
                //}
            }
            //else
            //{
            //    if (Request.Form["__EVENTTARGET"].Contains("generate"))
            //    {
            //        if (Request.Form["__EVENTTARGET"].Contains("cbx"))
            //        {
            //            // 查找控件.
            //            string[] arrayControlsName = Request.Form["__EVENTTARGET"].Split('$');
            //            ExtAspNet.FormRow formRow = CustomizeForm.FindControl(arrayControlsName[arrayControlsName.Length - 2]) as ExtAspNet.FormRow;
            //            if (formRow != null)
            //            {
            //                ExtAspNet.CheckBox checkBox = formRow.FindControl(arrayControlsName[arrayControlsName.Length - 1]) as ExtAspNet.CheckBox;
            //                checkBox_CheckedChanged(checkBox, null);
            //            }
            //        }

            //        if (Request.Form["__EVENTTARGET"].Contains("tbx"))
            //        {
            //            // 查找控件.
            //            //string[] arrayControlsName = Request.Form["__EVENTTARGET"].Split('$');
            //            textbox_TextChanged(Request.Form["__EVENTTARGET"], null);
            //            //ExtAspNet.FormRow formRow = CustomizeForm.FindControl(arrayControlsName[arrayControlsName.Length - 2]) as ExtAspNet.FormRow;
            //            //if (formRow != null)
            //            //{
            //            //    ExtAspNet.TextBox textBox = formRow.FindControl(arrayControlsName[arrayControlsName.Length - 1]) as ExtAspNet.TextBox;
            //            //    textbox_TextChanged(textBox, null);
            //            //}
            //        }
            //    }
            //}
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
        /// 绑定业务类型.
        /// </summary>
        private void BindBusinessType()
        {
            ddlstBusinessType.Items.Clear();
            ddlstBusinessType.Items.Add(new ExtAspNet.ListItem("普通业务", "0"));
            ddlstBusinessType.Items.Add(new ExtAspNet.ListItem("定制业务", "1"));
            ddlstBusinessType.SelectedIndex = 0;
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
        /// 获取动态控件的值
        /// </summary>
        private string GetGenerateValue()
        {
            StringBuilder stringBuiler = new StringBuilder();
            int count = CustomizeForm.Rows.Count;
            string strTemp = string.Empty;
            for (int i = count - 1; i >= 0; --i)
            {
                strTemp = string.Empty;
                if (CustomizeForm.Rows[i].ID.Contains("generate"))
                {
                    if ((CustomizeForm.Rows[i].Items[0] as ExtAspNet.CheckBox).Checked)
                    {
                        strTemp += (CustomizeForm.Rows[i].Items[0] as ExtAspNet.CheckBox).Text + "$" + (CustomizeForm.Rows[i].Items[1] as ExtAspNet.TextBox).Text;
                    }
                }
                if (strTemp != string.Empty)
                    stringBuiler.Append(strTemp + "|");
            }

            return stringBuiler.ToString();
        }

        /// <summary>
        /// 绑定动态控件的值
        /// </summary>
        /// <param name="strSument"></param>
        private void BindGernrateValue(string strSument)
        {
            if (!string.IsNullOrEmpty(strSument))
            {
                int count = CustomizeForm.Rows.Count;
                string[] arraySuments = strSument.Split('|');
                foreach (string subSument in arraySuments)
                {
                    if (!string.IsNullOrEmpty(subSument))
                    {
                        for (int i = count - 1; i >= 0; --i)
                        {
                            if (CustomizeForm.Rows[i].ID.Contains("generate"))
                            {
                                if ((CustomizeForm.Rows[i].Items[0] as ExtAspNet.CheckBox).Text == subSument.Split('$')[0])
                                {
                                    (CustomizeForm.Rows[i].Items[0] as ExtAspNet.CheckBox).Checked = true;
                                    (CustomizeForm.Rows[i].Items[1] as ExtAspNet.TextBox).Text = subSument.Split('$')[1];
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 提交报销申请单
        /// </summary>
        private void SaveApply()
        {
            if (OperatorType == null)
                return;
            BusinessImprestApplyInfo _applyInfo = null;
            BusinessManage _manage = new BusinessManage();
            int result = 3;

            #region 添加申请单

            if (OperatorType == "Add")
            {
                // 创建报销单实例.

                _applyInfo = new BusinessImprestApplyInfo();
                _applyInfo.ObjectID = Guid.NewGuid();
                _applyInfo.UserID = CurrentUser.ObjectId;
                _applyInfo.UserName = CurrentUser.Name;
                _applyInfo.UserJobNo = CurrentUser.JobNo;
                _applyInfo.UserAccountNo = CurrentUser.AccountNo;
                _applyInfo.UserDept = CurrentUser.Dept;
                _applyInfo.BusinessID = new Guid(ddlstBusinessTitle.SelectedValue);
                _applyInfo.BusinessType = Convert.ToInt16(ddlstBusinessType.SelectedValue);
                _applyInfo.BusinessName = ddlstBusinessTitle.SelectedText;
                _applyInfo.ApplySument = GetGenerateValue();
                _applyInfo.Sument = tbxSument.Text.Trim();
                _applyInfo.SumMoney = Convert.ToDecimal(lblMoney.Text.Trim());
                _applyInfo.ApplyTime = DateTime.Now;
                _applyInfo.ApproverID = new Guid(ddlstApproveUser.SelectedValue);
                _applyInfo.State = 0;
                _applyInfo.IsDelete = false;

                // 插入新报销单.
                result = _manage.AddNewImprestApply(_applyInfo);

                // 插入起草记录到代帐费审批流程表.
                BusinessImprestApproveInfo _approveInfo = new BusinessImprestApproveInfo();
                _approveInfo.ObjectID = Guid.NewGuid();
                _approveInfo.ApproverID = CurrentUser.ObjectId;
                _approveInfo.ApproverName = CurrentUser.Name;
                _approveInfo.ApproverDept = CurrentUser.Dept;
                _approveInfo.ApproveTime = DateTime.Now;
                _approveInfo.ApproveState = 1;
                _approveInfo.ApproveOp = 0;
                _approveInfo.ApplyID = _applyInfo.ObjectID;
                _manage.AddNewImprestApprove(_approveInfo);

                // 插入待审批记录到报销审批流程表.
                _approveInfo = new BusinessImprestApproveInfo();
                UserInfo _approveUser = new UserManage().GetUserByObjectID(ddlstApproveUser.SelectedValue);
                _approveInfo.ObjectID = Guid.NewGuid();
                _approveInfo.ApproverID = _approveUser.ObjectId;
                _approveInfo.ApproverName = _approveUser.Name;
                _approveInfo.ApproverDept = _approveUser.Dept;
                _approveInfo.ApproveTime = ACommonInfo.DBMAXDate;
                _approveInfo.ApproveState = 0;
                _approveInfo.ApplyID = _applyInfo.ObjectID;

                _manage.AddNewImprestApprove(_approveInfo);

            }
            #endregion

            #region 编辑申请单

            if (OperatorType == "Edit")
            {
                _applyInfo = _manage.GetImprestApplyByObjectID(ApplyID);
                if (_applyInfo != null)
                {
                    // 更新申请单中的数据.
                    _applyInfo.BusinessID = new Guid(ddlstBusinessTitle.SelectedValue);
                    _applyInfo.BusinessType = Convert.ToInt16(ddlstBusinessType.SelectedValue);
                    _applyInfo.BusinessName = ddlstBusinessTitle.SelectedText;
                    _applyInfo.SumMoney = Convert.ToDecimal(lblMoney.Text.Trim());
                    _applyInfo.ApplySument = GetGenerateValue();
                    _applyInfo.Sument = tbxSument.Text.Trim();
                    _applyInfo.State = 0;
                    _applyInfo.ApproverID = new Guid(ddlstApproveUser.SelectedValue);

                    result = _manage.UpdateImprestApply(_applyInfo);

                    // 插入待审批记录到报销审批流程表.
                    BusinessImprestApproveInfo _approveInfo = new BusinessImprestApproveInfo();
                    UserInfo _approveUser = new UserManage().GetUserByObjectID(ddlstApproveUser.SelectedValue);
                    _approveInfo.ObjectID = Guid.NewGuid();
                    _approveInfo.ApproverID = _approveUser.ObjectId;
                    _approveInfo.ApproverName = _approveUser.Name;
                    _approveInfo.ApproverDept = _approveUser.Dept;
                    _approveInfo.ApproveTime = ACommonInfo.DBMAXDate;
                    _approveInfo.ApproveState = 0;
                    _approveInfo.ApplyID = _applyInfo.ObjectID;

                    _manage.AddNewImprestApprove(_approveInfo);
                }
            }

            #endregion

            if (result == -1)
            {
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
            BusinessManage _manage = new BusinessManage();
            BusinessImprestApplyInfo _info = _manage.GetImprestApplyByObjectID(ApplyID);
            if (_info != null)
            {
                lblName.Text = _info.UserName;
                lblApplyTime.Text = _info.ApplyTime.ToString("yyyy-MM-dd HH:mm");
                ddlstBusinessType.SelectedValue = _info.BusinessType.ToString();
                this.ddlstBusinessType_SelectedIndexChanged(null, null);
                ddlstBusinessTitle.SelectedValue = _info.BusinessID.ToString();
                lblMoney.Text = _info.SumMoney.ToString();
                tbxSument.Text = _info.Sument;
                BindGernrateValue(_info.ApplySument);

                // 查找最早的审批记录.
                List<BusinessImprestApproveInfo> lstApprove = _manage.GetImprestApproveByCondition(" ApplyID = '" + ApplyID + "' and ApproveOp <> 0");
                if (lstApprove.Count == 1)
                {
                    ddlstApproveUser.SelectedValue = lstApprove[0].ApproverID.ToString();
                }
                else
                {
                    lstApprove.Sort(delegate(BusinessImprestApproveInfo x, BusinessImprestApproveInfo y) { return DateTime.Compare(x.ApproveTime, y.ApproveTime); });
                    foreach (var item in lstApprove)
                    {
                        if (DateTime.Compare(item.ApproveTime, ACommonInfo.DBEmptyDate) != 0)
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
            btnSubmit.Enabled = false;
            ddlstNext.Required = false;
            ddlstNext.ShowRedStar = false;
            ddlstNext.Enabled = false;
            ddlstApproveUser.Required = false;
            ddlstApproveUser.ShowRedStar = false;
            ddlstApproveUser.Enabled = false;
            ddlstBusinessType.Required = false;
            ddlstBusinessType.ShowRedStar = false;
            ddlstBusinessType.Enabled = false;
            ddlstBusinessTitle.Required = false;
            ddlstBusinessTitle.ShowRedStar = false;
            ddlstBusinessTitle.Enabled = false;
            tbxSument.Required = false;
            tbxSument.ShowRedStar = false;
            tbxSument.Enabled = false;

            // 动态控件.
            int count = CustomizeForm.Rows.Count;
            for (int i = count - 1; i >= 0; --i)
            {
                if (CustomizeForm.Rows[i].ID.Contains("generate"))
                {
                    (CustomizeForm.Rows[i].Items[0] as ExtAspNet.CheckBox).Enabled = false;
                    (CustomizeForm.Rows[i].Items[1] as ExtAspNet.TextBox).Enabled = false;
                }
            }
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
            strCondition.Append(" and  ApproveState <> 0");
            List<BusinessImprestApproveInfo> lstBaoxiaoCheckInfo = new BusinessManage().GetImprestApproveByCondition(strCondition.ToString());

            lstBaoxiaoCheckInfo.Sort(delegate(BusinessImprestApproveInfo x, BusinessImprestApproveInfo y) { return DateTime.Compare(y.ApproveTime, x.ApproveTime); });

            // 绑定列表.
            gridApproveHistory.RecordCount = lstBaoxiaoCheckInfo.Count;
            this.gridApproveHistory.DataSource = lstBaoxiaoCheckInfo;
            this.gridApproveHistory.DataBind();
        }

        /// <summary>
        /// 绑定一般业务
        /// </summary>
        private void BindNormalBusiness()
        {
            ddlstBusinessTitle.Items.Clear();
            BusinessManage _manage = new BusinessManage();
            List<BusinessInfo> lstBusiness = _manage.GetBusinessByCondition(" IsDelete = 0 and BusinessType = 0 and State = 0");
            foreach (BusinessInfo info in lstBusiness)
            {
                ddlstBusinessTitle.Items.Add(new ExtAspNet.ListItem(info.CompanyName, info.ObjectID.ToString()));
            }

            ddlstBusinessTitle.SelectedIndex = 0;

            GenerateNormalImprest();
        }

        /// <summary>
        /// 绑定定制业务
        /// </summary>
        private void BindCustomizeBusiness()
        {
            ddlstBusinessTitle.Items.Clear();
            BusinessManage _manage = new BusinessManage();
            List<BusinessInfo> lstBusiness = _manage.GetBusinessByCondition(" IsDelete = 0 and BusinessType = 1 and State = 0");
            foreach (BusinessInfo info in lstBusiness)
            {
                ddlstBusinessTitle.Items.Add(new ExtAspNet.ListItem(info.CompanyName, info.ObjectID.ToString()));
            }

            ddlstBusinessTitle.SelectedIndex = 0;

            GenerateCustomizeImprest();
        }

        /// <summary>
        /// 生成普通业务的表单项.
        /// </summary>
        /// <param name="_manage"></param>
        private void GenerateNormalImprest()
        {
            // 设置表单.
            // 清空现有生成的表单行.
            int count = CustomizeForm.Rows.Count;
            for (int i = count - 1; i >= 0; --i)
            {
                if (CustomizeForm.Rows[i].ID.Contains("generate"))
                {
                    //(CustomizeForm.Rows[i].Items[0] as ExtAspNet.CheckBox).Checked = false;
                    //(CustomizeForm.Rows[i].Items[1] as ExtAspNet.TextBox).Text = "";
                    CustomizeForm.Rows.RemoveAt(i);
                }
            }

            BusinessManage _manage = new BusinessManage();

            // 生成普通业务表单行.
            for (int i = 0; i < 12; i++)
            {
                FormRow row = new FormRow();
                row.ID = "generateNormal" + i;
                row.ColumnWidths = "40% 60%";

                ExtAspNet.CheckBox checkBox = new ExtAspNet.CheckBox();
                checkBox.ID = "cbxNormal" + i;
                checkBox.ShowLabel = false;
                checkBox.Height = lblMoney.Height;
                checkBox.AutoPostBack = true;
                checkBox.Text = _manage.ConvertBusinessTypeToString(true, i + 1);
                checkBox.CheckedChanged += new EventHandler(checkBox_CheckedChanged);
                row.Items.Add(checkBox);

                ExtAspNet.TextBox textbox = new ExtAspNet.TextBox();
                textbox.ID = "tbxNormal" + i;
                textbox.AutoPostBack = true;
                textbox.TextChanged += new EventHandler(textbox_TextChanged);
                textbox.Label = "金额(元)";
                textbox.Regex = "^[0-9]*\\.?[0-9]{1,2}$";
                textbox.RegexMessage = "金额格式不正确!";
                row.Items.Add(textbox);

                CustomizeForm.Rows.Insert(CustomizeForm.Rows.Count - 1, row);
            }
        }

        /// <summary>
        /// 生成定制业务的表单项.
        /// </summary>
        private void GenerateCustomizeImprest()
        {

            // 设置表单.
            // 清空现有生成的表单行.
            int count = CustomizeForm.Rows.Count;
            for (int i = count - 1; i >= 0; --i)
            {
                if (CustomizeForm.Rows[i].ID.Contains("generate"))
                {
                    CustomizeForm.Rows.RemoveAt(i);
                }
            }

            BusinessManage _manage = new BusinessManage();
            BusinessInfo _info = _manage.GetBusinessByObjectID(ddlstBusinessTitle.SelectedValue);
            if (_info != null)
            {
                string[] arrayCells = _info.BusinessCells.Split(',');
                foreach (string cell in arrayCells)
                {
                    if (!string.IsNullOrEmpty(cell))
                    {
                        FormRow row = new FormRow();
                        row.ID = "generateCustomize" + cell;
                        row.ColumnWidths = "40% 60%";

                        ExtAspNet.CheckBox checkBox = new ExtAspNet.CheckBox();
                        checkBox.ID = "cbxCustomize" + cell;
                        checkBox.ShowLabel = false;
                        checkBox.Height = lblMoney.Height;
                        checkBox.AutoPostBack = true;
                        checkBox.Text = _manage.ConvertBusinessTypeToString(false, Convert.ToInt32(cell));
                        checkBox.CheckedChanged += new EventHandler(checkBox_CheckedChanged);
                        row.Items.Add(checkBox);

                        ExtAspNet.TextBox textbox = new ExtAspNet.TextBox();
                        textbox.ID = "tbxCustomize" + cell;
                        textbox.Label = "金额(元)";
                        textbox.Regex = "^[0-9]*\\.?[0-9]{1,2}$";
                        textbox.RegexMessage = "金额格式不正确!";
                        textbox.AutoPostBack = true;
                        textbox.TextChanged += new EventHandler(textbox_TextChanged);
                        row.Items.Add(textbox);

                        CustomizeForm.Rows.Insert(CustomizeForm.Rows.Count - 1, row);
                    }
                }
            }
        }

        #endregion

        #region 页面事件

        /// <summary>
        /// 文本变动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void textbox_TextChanged(object sender, EventArgs e)
        {
            //Alert.Show(((ExtAspNet.TextBox)sender).Label);

            ExtAspNet.TextBox tbxSelected = (ExtAspNet.TextBox)sender;
            if (tbxSelected != null)
            {
                StringBuilder stringBuilder = new StringBuilder();
                Decimal sumMoney = 0;
                foreach (ExtAspNet.FormRow formRow in CustomizeForm.Rows)
                {
                    if (formRow.ID.Contains("generate"))
                    {
                        ExtAspNet.CheckBox subCheckBox = formRow.FindControl(formRow.ID.Replace("generate", "cbx")) as ExtAspNet.CheckBox;
                        ExtAspNet.TextBox subTextBox = formRow.FindControl(formRow.ID.Replace("generate", "tbx")) as ExtAspNet.TextBox;
                        if (subCheckBox.Checked)
                        {
                            string money = string.IsNullOrEmpty(subTextBox.Text.Trim()) ? "0" : subTextBox.Text.Trim();
                            stringBuilder.AppendLine(subCheckBox.Text + "    " + money + "元");
                            sumMoney += Convert.ToDecimal(money);
                        }
                    }
                }

                tbxSument.Text = stringBuilder.ToString();
                lblMoney.Text = sumMoney.ToString();
            }
        }

        /// <summary>
        /// 复选框点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            ExtAspNet.CheckBox cbxSelected = (ExtAspNet.CheckBox)sender;
            if (cbxSelected != null)
            {
                StringBuilder stringBuilder = new StringBuilder();
                Decimal sumMoney = 0;
                foreach (ExtAspNet.FormRow formRow in CustomizeForm.Rows)
                {
                    if (formRow.ID.Contains("generate"))
                    {
                        ExtAspNet.CheckBox subCheckBox = formRow.FindControl(formRow.ID.Replace("generate", "cbx")) as ExtAspNet.CheckBox;
                        ExtAspNet.TextBox subTextBox = formRow.FindControl(formRow.ID.Replace("generate", "tbx")) as ExtAspNet.TextBox;
                        if (subCheckBox.Checked)
                        {
                            string money = string.IsNullOrEmpty(subTextBox.Text.Trim()) ? "0" : subTextBox.Text.Trim();
                            stringBuilder.AppendLine(subCheckBox.Text + "    " + money + "元");
                            sumMoney += Convert.ToDecimal(money);
                        }
                    }
                }

                tbxSument.Text = stringBuilder.ToString();
                lblMoney.Text = sumMoney.ToString();
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
            if ( Convert.ToDecimal(lblMoney.Text) == 0)
            {
                Alert.Show("总金额不可为零!");
                return;
            }

            SaveApply();
        }

        /// <summary>
        /// 业务类型选择事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlstBusinessType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //System.Diagnostics.Debug.WriteLine("---------------ddlstBusinessType_SelectedIndexChanged");

            if (ddlstBusinessType.SelectedIndex == 0)
            {
                BindNormalBusiness();
            }
            else
            {
                BindCustomizeBusiness();
            }

            lblMoney.Text = "0.00";
            tbxSument.Text = "";
            int count = CustomizeForm.Rows.Count;
            for (int i = count - 1; i >= 0; --i)
            {
                if (CustomizeForm.Rows[i].ID.Contains("generate"))
                {
                    (CustomizeForm.Rows[i].Items[0] as ExtAspNet.CheckBox).Checked = false;
                    (CustomizeForm.Rows[i].Items[1] as ExtAspNet.TextBox).Text = "";
                }
            }
        }

        /// <summary>
        /// 业务标题变动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlstBusinessTitle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlstBusinessType.SelectedIndex != 0)
            {
                GenerateCustomizeImprest();
            }
            else
            {
                GenerateNormalImprest();
            }
            lblMoney.Text = "0.00";
            tbxSument.Text = "";
            int count = CustomizeForm.Rows.Count;
            for (int i = count - 1; i >= 0; --i)
            {
                if (CustomizeForm.Rows[i].ID.Contains("generate"))
                {
                    (CustomizeForm.Rows[i].Items[0] as ExtAspNet.CheckBox).Checked = false;
                    (CustomizeForm.Rows[i].Items[1] as ExtAspNet.TextBox).Text = "";
                }
            }
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

        #endregion
    }
}