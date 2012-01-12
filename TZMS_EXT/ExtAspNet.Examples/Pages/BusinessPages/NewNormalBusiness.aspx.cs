using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExtAspNet;
using com.TZMS.Model;
using com.TZMS.Business.BusinessManage;

namespace TZMS.Web
{
    public partial class NewNormalBusiness : BasePage
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
                OperatorType = Request.QueryString["Type"];
                ApplyID = Request.QueryString["ID"];

                switch (OperatorType)
                {
                    case "Add":
                        tabOperateHistory.Hidden = true;
                        BindSigner();
                        imgBalanceMoney.Hidden = true;
                        imgPreMoney.Hidden = true;
                        dpkSignTime.SelectedDate = DateTime.Now;
                        tbxCostMoney.Enabled = false;
                        tbxOtherMoney.Enabled = false;
                        taaOtherMoneyExplain.Enabled = false;
                        break;

                    case "View":
                        BindSigner();
                        BindBusinessInfo();
                        BindOperateHistory();
                        DisableAllControls();
                        break;

                    case "Change":
                        BindSigner();
                        BindBusinessInfo();
                        BindOperateHistory();
                        DisableAllControls();
                        btnSubmit.Enabled = true;
                        tbxCostMoney.Enabled = true;
                        tbxOtherMoney.Enabled = true;
                        taaOtherMoneyExplain.Enabled = false;
                        break;

                    case "Edit":
                        BindSigner();
                        BindBusinessInfo();
                        BindOperateHistory();
                        tbxCostMoney.Enabled = false;
                        tbxOtherMoney.Enabled = false;
                        taaOtherMoneyExplain.Enabled = false;
                        break;

                    default:
                        break;
                }
            }
        }

        #region 私有方法

        /// <summary>
        /// 绑定签订人
        /// </summary>
        private void BindSigner()
        {
            ddlstSigner.Items.Clear();

            if (!CurrentChecker.Contains(CurrentUser))
            {
                ddlstSigner.Items.Add(new ExtAspNet.ListItem(CurrentUser.Name, CurrentUser.ObjectId.ToString()));
            }

            foreach (UserInfo user in CurrentChecker)
            {
                ddlstSigner.Items.Add(new ExtAspNet.ListItem(user.Name, user.ObjectId.ToString()));
            }

            ddlstSigner.SelectedIndex = 0;
        }

        /// <summary>
        /// 绑定业务信息
        /// </summary>
        private void BindBusinessInfo()
        {
            if (string.IsNullOrEmpty(ApplyID))
                return;

            BusinessManage _manage = new BusinessManage();
            BusinessInfo _info = _manage.GetBusinessByObjectID(ApplyID);
            if (_info != null)
            {
                ddlstSigner.SelectedValue = _info.SignerID.ToString();
                dpkSignTime.SelectedDate = _info.SignTime;
                tbxCompanyName.Text = _info.CompanyName;
                tbxRegisteredMoney.Text = _info.RegisteredMoney.ToString();
                ddlstCZType.SelectedValue = _info.CZType.ToString();
                ddlstCompanyType.SelectedValue = _info.CompanyType.ToString();
                ddlstCompanyNameType.SelectedValue = _info.CompanyNameType.ToString();
                tbxSumMoney.Text = _info.SumMoney.ToString();
                tbxPreMoney.Text = _info.PreMoney.ToString();
                tbxBalanceMoney.Text = _info.BalanceMoney.ToString();
                tbxContact.Text = _info.Contact;
                tbxContactPhoneNumber.Text = _info.ContactPhoneNumber;
                tbxCostMoney.Text = _info.CostMoney.ToString();
                tbxOtherMoney.Text = _info.OtherMoney.ToString();
                taaOtherMoneyExplain.Text = _info.OtherMoneyExplain;
                taaContent.Text = _info.Content;
                taaOther.Text = _info.Other;

                if (_info.BalanceMoneyType != 1)
                    imgBalanceMoney.Hidden = true;
                if (_info.PreMoneyType != 1)
                    imgPreMoney.Hidden = true;

                // 杂项.
                if (!string.IsNullOrEmpty(_info.CheckOther))
                {
                    string[] arrayOther = _info.CheckOther.Split(',');
                    foreach (string strOther in arrayOther)
                    {
                        if (!string.IsNullOrEmpty(strOther))
                        {
                            switch (strOther)
                            {
                                case "1":
                                    CheckBox1.Checked = true;
                                    break;
                                case "2":
                                    CheckBox2.Checked = true;
                                    break;
                                case "3":
                                    CheckBox3.Checked = true;
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 绑定操作历史
        /// </summary>
        private void BindOperateHistory()
        {
            if (string.IsNullOrEmpty(ApplyID))
                return;
            BusinessManage _manage = new BusinessManage();
            List<BusinessRecordInfo> lstRecord = _manage.GetBusinessRecordByCondition(" BusinessID = '" + ApplyID + "' and State >= 1 order by CheckDateTime desc");

            lstRecord.Sort(delegate(BusinessRecordInfo x, BusinessRecordInfo y) { return DateTime.Compare(y.CheckDateTime, x.CheckDateTime); });

            // 绑定列表.
            gridoperateHistory.RecordCount = lstRecord.Count;
            this.gridoperateHistory.DataSource = lstRecord;
            this.gridoperateHistory.DataBind();

        }

        /// <summary>
        /// 禁用所有控件
        /// </summary>
        private void DisableAllControls()
        {
            btnSubmit.Enabled = false;
            ddlstSigner.Required = false;
            ddlstSigner.ShowRedStar = false;
            ddlstSigner.Enabled = false;
            dpkSignTime.Required = false;
            dpkSignTime.ShowRedStar = false;
            dpkSignTime.Enabled = false;
            tbxCompanyName.Required = false;
            tbxCompanyName.ShowRedStar = false;
            tbxCompanyName.Enabled = false;
            tbxRegisteredMoney.Enabled = false;
            ddlstCZType.Enabled = false;
            ddlstCompanyType.Enabled = false;
            ddlstCompanyNameType.Enabled = false;
            tbxContact.Enabled = false;
            tbxContactPhoneNumber.Enabled = false;
            tbxSumMoney.Required = false;
            tbxSumMoney.ShowRedStar = false;
            tbxSumMoney.Enabled = false;
            tbxPreMoney.Required = false;
            tbxPreMoney.ShowRedStar = false;
            tbxPreMoney.Enabled = false;
            tbxBalanceMoney.Required = false;
            tbxBalanceMoney.ShowRedStar = false;
            tbxBalanceMoney.Enabled = false;
            CheckBox1.Enabled = false;
            CheckBox2.Enabled = false;
            CheckBox3.Enabled = false;
            tbxCostMoney.Enabled = false;
            tbxOtherMoney.Enabled = false;
            taaOtherMoneyExplain.Enabled = false;
            taaContent.Required = false;
            taaContent.ShowRedStar = false;
            taaContent.Enabled = false;
            taaOther.Enabled = false;
        }

        /// <summary>
        /// 保存普通业务信息
        /// </summary>
        private void SaveBusinessInfo()
        {
            if (string.IsNullOrEmpty(OperatorType))
                return;
            BusinessManage _manage = new BusinessManage();
            BusinessInfo _info = null;
            int result = 3;
            if (OperatorType == "Add")
            {
                // 创建业务实例.
                _info = new BusinessInfo();
                _info.ObjectID = Guid.NewGuid();
                _info.CreaterID = CurrentUser.ObjectId;
                _info.CreaterName = CurrentUser.Name;
                _info.CreaterAccountNo = CurrentUser.AccountNo;
                _info.CreaterDept = CurrentUser.Dept;
                _info.CreateTime = DateTime.Now;
                _info.SignerID = new Guid(ddlstSigner.SelectedValue);
                _info.SignerName = ddlstSigner.SelectedText;
                _info.SignTime = Convert.ToDateTime(dpkSignTime.SelectedDate);
                _info.CompanyName = tbxCompanyName.Text.Trim();
                _info.RegisteredMoney = string.IsNullOrEmpty(tbxRegisteredMoney.Text.Trim()) ? 0 : Convert.ToDecimal(tbxRegisteredMoney.Text.Trim());
                _info.CZType = short.Parse(ddlstCZType.SelectedValue);
                _info.CompanyType = short.Parse(ddlstCompanyType.SelectedValue);
                _info.CompanyNameType = short.Parse(ddlstCompanyNameType.SelectedValue);
                _info.SumMoney = Convert.ToDecimal(tbxSumMoney.Text.Trim());
                _info.PreMoney = Convert.ToDecimal(tbxPreMoney.Text.Trim());
                _info.BalanceMoney = Convert.ToDecimal(tbxBalanceMoney.Text.Trim());
                _info.Contact = tbxContact.Text.Trim();
                _info.ContactPhoneNumber = tbxContactPhoneNumber.Text.Trim();
                _info.CostMoney = 0;
                _info.OtherMoney = 0;
                _info.OtherMoneyExplain = "";
                _info.Content = taaContent.Text.Trim();
                _info.Other = taaOther.Text.Trim();
                _info.State = 0;
                _info.CurrentUserID = CurrentUser.ObjectId;
                _info.IsDelete = false;
                _info.BusinessType = 0;

                // 杂项.
                if (CheckBox1.Checked)
                    _info.CheckOther += "1,";
                if (CheckBox2.Checked)
                    _info.CheckOther += "2,";
                if (CheckBox3.Checked)
                    _info.CheckOther += "3,";

                // 创建签订记录.
                BusinessRecordInfo _recordInfo = new BusinessRecordInfo();
                _recordInfo.ObjectID = Guid.NewGuid();
                _recordInfo.CheckerID = CurrentUser.ObjectId;
                _recordInfo.CheckerName = CurrentUser.Name;
                _recordInfo.CheckDateTime = _info.CreateTime;
                _recordInfo.State = 1;
                _recordInfo.CurrentBusiness = 0;
                _recordInfo.BusinessID = _info.ObjectID;

                _manage.AddNewBusinessRecord(_recordInfo);

                // 创建待办理记录.
                _recordInfo = new BusinessRecordInfo();
                _recordInfo.ObjectID = Guid.NewGuid();
                _recordInfo.CheckerID = CurrentUser.ObjectId;
                _recordInfo.CheckerName = CurrentUser.Name;
                _recordInfo.State = 0;
                _recordInfo.CurrentBusiness = 1;
                _recordInfo.BusinessID = _info.ObjectID;

                _manage.AddNewBusinessRecord(_recordInfo);

                _info.CurrentBusinessRecordID = _recordInfo.ObjectID;
                result = _manage.AddNewBusiness(_info);
            }
            else if (OperatorType == "Edit")
            {
                _info = _manage.GetBusinessByObjectID(ApplyID);
                if (_info != null)
                {
                    _info.SignerID = new Guid(ddlstSigner.SelectedValue);
                    _info.SignerName = ddlstSigner.SelectedText;
                    _info.SignTime = Convert.ToDateTime(dpkSignTime.SelectedDate);
                    _info.CompanyName = tbxCompanyName.Text.Trim();
                    _info.RegisteredMoney = string.IsNullOrEmpty(tbxRegisteredMoney.Text.Trim()) ? 0 : Convert.ToDecimal(tbxRegisteredMoney.Text.Trim());
                    _info.CZType = short.Parse(ddlstCZType.SelectedValue);
                    _info.CompanyType = short.Parse(ddlstCompanyType.SelectedValue);
                    _info.CompanyNameType = short.Parse(ddlstCompanyNameType.SelectedValue);
                    _info.SumMoney = Convert.ToDecimal(tbxSumMoney.Text.Trim());
                    _info.PreMoney = Convert.ToDecimal(tbxPreMoney.Text.Trim());
                    _info.BalanceMoney = Convert.ToDecimal(tbxBalanceMoney.Text.Trim());
                    _info.Contact = tbxContact.Text.Trim();
                    _info.ContactPhoneNumber = tbxContactPhoneNumber.Text.Trim();
                    _info.CostMoney = 0;
                    _info.OtherMoney = 0;
                    _info.OtherMoneyExplain = "";
                    _info.Content = taaContent.Text.Trim();
                    _info.Other = taaOther.Text.Trim();
                    _info.State = 0;
                    _info.CurrentUserID = CurrentUser.ObjectId;
                    _info.IsDelete = false;
                    _info.BusinessType = 0;

                    _info.CheckOther = "";
                    if (CheckBox1.Checked)
                        _info.CheckOther += "1,";
                    if (CheckBox2.Checked)
                        _info.CheckOther += "2,";
                    if (CheckBox3.Checked)
                        _info.CheckOther += "3,";

                    // 创建待办理记录.
                    BusinessRecordInfo _recordInfo = new BusinessRecordInfo();
                    _recordInfo.ObjectID = Guid.NewGuid();
                    _recordInfo.CheckerID = CurrentUser.ObjectId;
                    _recordInfo.CheckerName = CurrentUser.Name;
                    _recordInfo.State = 0;
                    _recordInfo.CurrentBusiness = 1;
                    _recordInfo.BusinessID = _info.ObjectID;

                    _manage.AddNewBusinessRecord(_recordInfo);

                    _info.CurrentBusinessRecordID = _recordInfo.ObjectID;
                    result = _manage.UpdateBusiness(_info);
                }
            }
            else if (OperatorType == "Change")
            {
                _info = _manage.GetBusinessByObjectID(ApplyID);
                if (_info != null)
                {
                    string strExplain = string.Empty;
                    strExplain = "业务总监" + CurrentUser.Name;
                    if (Decimal.Compare(_info.CostMoney, Convert.ToDecimal(tbxCostMoney.Text.Trim())) != 0)
                    {
                        _info.CostMoney = Convert.ToDecimal(tbxCostMoney.Text.Trim());
                        strExplain += "变更成本金额为" + _info.CostMoney.ToString() + "元";
                    }

                    if (Decimal.Compare(_info.OtherMoney, Convert.ToDecimal(tbxOtherMoney.Text.Trim())) != 0)
                    {
                        if (strExplain != "业务总监" + CurrentUser.Name)
                        {
                            strExplain += ",";
                        }
                        _info.OtherMoney = Convert.ToDecimal(tbxOtherMoney.Text.Trim());
                        strExplain += "变更其它金额为" + _info.OtherMoney.ToString() + "元";
                    }

                    if (strExplain != "业务总监" + CurrentUser.Name)
                    {
                        strExplain += ";";
                        taaOtherMoneyExplain.Text += strExplain;
                        _info.OtherMoneyExplain += strExplain;
                    }

                    result = _manage.UpdateBusiness(_info);
                }
            }

            if (result == -1)
            {
                this.btnClose_Click(null, null);
            }
            else
            {
                Alert.Show("创建普通业务失败!");
            }
        }

        #endregion

        #region 页面事件

        /// <summary>
        /// 操作历史数据行绑定事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridoperateHistory_RowDataBound(object sender, ExtAspNet.GridRowEventArgs e)
        {
            if (e.DataItem != null)
            {
                e.Values[1] = DateTime.Parse(e.Values[1].ToString()).ToString("yyyy-MM-dd HH:mm");
                e.Values[2] = new BusinessManage().ConvertBusinessTypeToString(true, Convert.ToInt32(e.Values[2].ToString()));
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
        /// 创建事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SaveBusinessInfo();
        }

        #endregion
    }
}