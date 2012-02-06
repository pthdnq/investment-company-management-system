using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExtAspNet;
using com.TZMS.Model;
using com.TZMS.Business.BusinessManage;
using com.TZMS.Business;
using System.Text.RegularExpressions;

namespace TZMS.Web
{
    public partial class OperatorCustomizeBusiness : BasePage
    {
        /// <summary>
        /// RecordID
        /// </summary>
        public string RecordID
        {
            get
            {
                if (ViewState["RecordID"] == null)
                {
                    return null;
                }

                return ViewState["RecordID"].ToString();
            }
            set
            {
                ViewState["RecordID"] = value;
            }
        }

        /// <summary>
        /// BusinessID
        /// </summary>
        public string BusinessID
        {
            get
            {
                if (ViewState["BusinessID"] == null)
                {
                    return null;
                }

                return ViewState["BusinessID"].ToString();
            }
            set
            {
                ViewState["BusinessID"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                wndSpecialMoney.OnClientCloseButtonClick = wndSpecialMoney.GetHidePostBackReference();

                RecordID = Request.QueryString["RecordID"];
                BusinessID = Request.QueryString["BusinessID"];

                BindNext();
                BindApprover();
                BindBusinessInfo();
                BindOperateHistory();
                DisableAllControls();
                SetPanelState();
            }
        }

        #region 私有方法

        /// <summary>
        /// 绑定下一步
        /// </summary>
        private void BindNext()
        {
            if (string.IsNullOrEmpty(BusinessID))
                return;
            BusinessManage _manage = new BusinessManage();
            BusinessInfo _info = _manage.GetBusinessByObjectID(BusinessID);
            if (_info != null)
            {
                string[] arrayCells = _info.BusinessCells.Split(',');
                foreach (string cell in arrayCells)
                {
                    if (!string.IsNullOrEmpty(cell))
                    {
                        ddlstNext.Items.Add(new ExtAspNet.ListItem(_manage.ConvertBusinessTypeToString(false, Convert.ToInt32(cell)), cell));
                    }
                }
                ddlstNext.Items.Add(new ExtAspNet.ListItem("完成", "17"));
                ddlstNext.Items.Add(new ExtAspNet.ListItem("异常终止", "18"));
                ddlstNext.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// 绑定负责人
        /// </summary>
        private void BindApprover()
        {
            ddlstApproveUser.Items.Clear();

            //if (!CurrentChecker.Contains(CurrentUser))
            //{
                ddlstApproveUser.Items.Add(new ExtAspNet.ListItem(CurrentUser.Name, CurrentUser.ObjectId.ToString()));
            //}

            //foreach (UserInfo user in CurrentChecker)
            //{
            //    ddlstApproveUser.Items.Add(new ExtAspNet.ListItem(user.Name, user.ObjectId.ToString()));
            //}

            ddlstApproveUser.SelectedIndex = 0;
        }

        /// <summary>
        /// 绑定业务信息
        /// </summary>
        private void BindBusinessInfo()
        {
            if (string.IsNullOrEmpty(BusinessID))
                return;

            BusinessManage _manage = new BusinessManage();
            BusinessInfo _info = _manage.GetBusinessByObjectID(BusinessID);
            if (_info != null)
            {
                ddlstSigner.Items.Clear();
                ddlstSigner.Items.Add(new ExtAspNet.ListItem(_info.SignerName, _info.SignerID.ToString()));
                dpkSignTime.SelectedDate = _info.SignTime;
                tbxCompanyName.Text = _info.CompanyName;
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
                if (_info.CheckOther == "1")
                    CheckBox1.Checked = true;
            }
        }

        /// <summary>
        /// 绑定操作历史
        /// </summary>
        private void BindOperateHistory()
        {
            if (string.IsNullOrEmpty(BusinessID))
                return;
            BusinessManage _manage = new BusinessManage();
            List<BusinessRecordInfo> lstRecord = _manage.GetBusinessRecordByCondition(" BusinessID = '" + BusinessID + "' and State >= 1 order by CheckDateTime desc");

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
            ddlstSigner.Required = false;
            ddlstSigner.ShowRedStar = false;
            ddlstSigner.Enabled = false;
            dpkSignTime.Required = false;
            dpkSignTime.ShowRedStar = false;
            dpkSignTime.Enabled = false;
            tbxCompanyName.Required = false;
            tbxCompanyName.ShowRedStar = false;
            tbxCompanyName.Enabled = false;
            tbxContact.Enabled = false;
            tbxContactPhoneNumber.Enabled = false;
            tbxSumMoney.Enabled = false;
            tbxPreMoney.Enabled = false;
            tbxBalanceMoney.Enabled = false;
            CheckBox1.Enabled = false;
            tbxCostMoney.Enabled = false;
            tbxOtherMoney.Enabled = false;
            taaOtherMoneyExplain.Readonly = true;
            taaContent.Required = false;
            taaContent.ShowRedStar = false;
            taaContent.Enabled = false;
            taaOther.Enabled = false;
        }

        /// <summary>
        /// 保存业务信息
        /// </summary>
        private void SaveBusiness()
        {
            if (string.IsNullOrEmpty(BusinessID) || string.IsNullOrEmpty(RecordID))
                return;

            BusinessManage _manage = new BusinessManage();
            BusinessInfo _info = _manage.GetBusinessByObjectID(BusinessID);
            int result = 3;
            if (_info != null)
            {
                #region 完成

                // 完成.
                if (ddlstNext.SelectedValue == "17")
                {
                    if (_info.SumMoney != (_info.PreMoney + _info.BalanceMoney))
                    {
                        Alert.Show("已收取费用与合同金额不匹配，请检查业务费用!");
                        return;
                    }

                    if (_info.PreMoneyType != 1)
                    {
                        Alert.Show("预付金额尚未收取!");
                        return;
                    }

                    if (_info.BalanceMoneyType != 1)
                    {
                        Alert.Show("业务尾款金额尚未收取!");
                        return;
                    }

                    wndSpecialMoney.IFrameUrl = "SpecialMoney.aspx";
                    wndSpecialMoney.Hidden = false;
                    return;
                }

                #endregion

                #region 异常终止

                // 异常终止.
                if (ddlstNext.SelectedValue == "18")
                {
                    _info.State = 2;

                    // 更新现有记录.
                    BusinessRecordInfo _recordInfo = _manage.GetBusinessRecordByObjectID(RecordID);
                    if (_recordInfo != null)
                    {
                        _recordInfo.State = 1;
                        if (!string.IsNullOrEmpty(tbxCBJE.Text.Trim()))
                            _recordInfo.CostMoney = Convert.ToDecimal(tbxCBJE.Text.Trim());
                        if (!string.IsNullOrEmpty(tbxQTFY.Text.Trim()))
                            _recordInfo.OtherMoney = Convert.ToDecimal(tbxQTFY.Text.Trim());
                        _recordInfo.Explain = taaQTFYSM.Text.Trim();
                        _recordInfo.CheckDateTime = DateTime.Now;

                        _manage.UpdateBusinessRecord(_recordInfo);
                    }

                    // 插入下一步记录.
                    _recordInfo = new BusinessRecordInfo();
                    _recordInfo.ObjectID = Guid.NewGuid();
                    _recordInfo.CheckerID = CurrentUser.ObjectId;
                    _recordInfo.CheckerName = CurrentUser.Name;
                    _recordInfo.CheckrDept = CurrentUser.Dept;
                    _recordInfo.CheckDateTime = DateTime.Now;
                    _recordInfo.State = 1;
                    _recordInfo.CurrentBusiness = 18;
                    _recordInfo.BusinessID = _info.ObjectID;

                    _manage.AddNewBusinessRecord(_recordInfo);

                    _info.CurrentBusinessRecordID = _recordInfo.ObjectID;
                    result = _manage.UpdateBusiness(_info);

                    if (result == -1)
                    {
                        this.btnClose_Click(null, null);
                    }
                    else
                    {
                        Alert.Show("异常终止失败!");
                    }

                    return;
                }

                #endregion

                {
                    if (!string.IsNullOrEmpty(tbxCBJE.Text.Trim()))
                        _info.CostMoney += Convert.ToDecimal(tbxCBJE.Text.Trim());
                    if (!string.IsNullOrEmpty(tbxQTFY.Text.Trim()))
                        _info.OtherMoney += Convert.ToDecimal(tbxQTFY.Text.Trim());
                    if (!string.IsNullOrEmpty(taaQTFYSM.Text.Trim()))
                        _info.OtherMoneyExplain += "\r\n" + taaQTFYSM.Text.Trim();
                    _info.CurrentUserID = new Guid(ddlstApproveUser.SelectedValue);

                    // 更新现有记录.
                    BusinessRecordInfo _recordInfo = _manage.GetBusinessRecordByObjectID(RecordID);
                    if (_recordInfo != null)
                    {
                        _recordInfo.State = 1;
                        if (!string.IsNullOrEmpty(tbxCBJE.Text.Trim()))
                            _recordInfo.CostMoney = Convert.ToDecimal(tbxCBJE.Text.Trim());
                        if (!string.IsNullOrEmpty(tbxQTFY.Text.Trim()))
                            _recordInfo.OtherMoney = Convert.ToDecimal(tbxQTFY.Text.Trim());
                        _recordInfo.Explain = taaQTFYSM.Text.Trim();
                        _recordInfo.CheckDateTime = DateTime.Now;

                        _manage.UpdateBusinessRecord(_recordInfo);
                    }

                    // 插入下一步记录.
                    _recordInfo = new BusinessRecordInfo();
                    UserInfo _nextUser = new UserManage().GetUserByObjectID(ddlstApproveUser.SelectedValue);
                    if (_nextUser != null)
                    {
                        _recordInfo.ObjectID = Guid.NewGuid();
                        _recordInfo.CheckerID = _nextUser.ObjectId;
                        _recordInfo.CheckerName = _nextUser.Name;
                        _recordInfo.CheckrDept = _nextUser.Dept;
                        _recordInfo.State = 0;
                        _recordInfo.CurrentBusiness = Convert.ToInt32(ddlstNext.SelectedValue);
                        _recordInfo.BusinessID = _info.ObjectID;

                        _manage.AddNewBusinessRecord(_recordInfo);

                        _info.CurrentBusinessRecordID = _recordInfo.ObjectID;
                        result = _manage.UpdateBusiness(_info);
                    }
                }
            }

            if (result == -1)
            {
                this.btnClose_Click(null, null);
            }
            else
            {
                Alert.Show("办理失败!");
            }
        }

        /// <summary>
        /// 设置面板状态
        /// </summary>
        private void SetPanelState()
        {
            if (string.IsNullOrEmpty(RecordID))
                return;
            BusinessManage _manage = new BusinessManage();
            BusinessRecordInfo _approveInfo = _manage.GetBusinessRecordByObjectID(RecordID);
            if (_approveInfo != null)
            {
                if (_approveInfo.State != 0)
                {
                    btnSubmit.Hidden = true;
                    mainForm2.Hidden = true;
                }
            }
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
        /// 确认办理事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SaveBusiness();
        }

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
                e.Values[2] = new BusinessManage().ConvertBusinessTypeToString(false, Convert.ToInt32(e.Values[2].ToString()));
            }
        }

        /// <summary>
        /// 特殊费用窗口关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void wndSpecialMoney_Close(object sender, ExtAspNet.WindowCloseEventArgs e)
        {
            BusinessManage _manage = new BusinessManage();
            BusinessInfo _info = _manage.GetBusinessByObjectID(BusinessID);
            int result = 3;
            if (_info != null)
            {

                _info.State = 1;

                // 更新现有记录.
                BusinessRecordInfo _recordInfo = _manage.GetBusinessRecordByObjectID(RecordID);
                if (_recordInfo != null)
                {
                    _recordInfo.State = 1;
                    if (!string.IsNullOrEmpty(tbxCBJE.Text.Trim()))
                        _recordInfo.CostMoney = Convert.ToDecimal(tbxCBJE.Text.Trim());
                    if (!string.IsNullOrEmpty(tbxQTFY.Text.Trim()))
                        _recordInfo.OtherMoney = Convert.ToDecimal(tbxQTFY.Text.Trim());
                    _recordInfo.Explain = taaQTFYSM.Text.Trim();
                    _recordInfo.CheckDateTime = DateTime.Now;

                    _manage.UpdateBusinessRecord(_recordInfo);
                }


                if (e.CloseArgument == "undefined")
                {

                }
                else
                {
                    string[] arraySpcimalMoney = Regex.Split(e.CloseArgument, "--", RegexOptions.None);
                    if (!string.IsNullOrEmpty(arraySpcimalMoney[0]))
                        _info.OtherMoney += Convert.ToDecimal(arraySpcimalMoney[0]);
                    if (!string.IsNullOrEmpty(arraySpcimalMoney[1]))
                        _info.OtherMoneyExplain += "\r\n" + arraySpcimalMoney[1];
                }

                // 插入下一步记录.
                _recordInfo = new BusinessRecordInfo();
                _recordInfo.ObjectID = Guid.NewGuid();
                _recordInfo.CheckerID = CurrentUser.ObjectId;
                _recordInfo.CheckerName = CurrentUser.Name;
                _recordInfo.CheckrDept = CurrentUser.Dept;
                _recordInfo.CheckDateTime = DateTime.Now;
                _recordInfo.State = 1;
                _recordInfo.CurrentBusiness = 17;
                _recordInfo.BusinessID = _info.ObjectID;

                _manage.AddNewBusinessRecord(_recordInfo);

                _info.CurrentBusinessRecordID = _recordInfo.ObjectID;
                result = _manage.UpdateBusiness(_info);

                if (result == -1)
                {
                    this.btnClose_Click(null, null);
                }
                else
                {
                    Alert.Show("业务完成失败!");
                }
            }
        }

        /// <summary>
        /// 二次办理选中事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cbxSecond_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxSecond.Checked == true)
            {
                taaQTFYSM.Text += "\r\n此次办理是二次办理";
            }

        }

        #endregion
    }
}