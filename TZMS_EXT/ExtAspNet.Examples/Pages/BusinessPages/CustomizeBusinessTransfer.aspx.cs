using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExtAspNet;
using com.TZMS.Business.BusinessManage;
using com.TZMS.Model;
using com.TZMS.Business;

namespace TZMS.Web
{
    public partial class CustomizeBusinessTransfer : BasePage
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
                RecordID = Request.QueryString["RecordID"];
                BusinessID = Request.QueryString["BusinessID"];

                BindNext();
                BindApprover();
                BindBusinessInfo();
                BindOperateHistory();
                DisableAllControls();
            }
        }

        #region 私有方法

        /// <summary>
        /// 绑定下一步
        /// </summary>
        private void BindNext()
        {
            BusinessManage _manage = new BusinessManage();
            BusinessRecordInfo _recordInfo = _manage.GetBusinessRecordByObjectID(RecordID);
            if (_recordInfo != null)
            {
                ddlstNext.Items.Add(new ExtAspNet.ListItem(_manage.ConvertBusinessTypeToString(false, _recordInfo.CurrentBusiness),
                    _recordInfo.CurrentBusiness.ToString()));
            }
        }

        /// <summary>
        /// 绑定负责人
        /// </summary>
        private void BindApprover()
        {
            ddlstApproveUser.Items.Clear();

            foreach (UserInfo user in CurrentChecker)
            {
                ddlstApproveUser.Items.Add(new ExtAspNet.ListItem(user.Name, user.ObjectId.ToString()));
            }

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
                tbxSumMoney.Text = _info.SumMoneyFlag + _info.SumMoney.ToString();
                tbxPreMoney.Text = _info.PreMoneyFlag + _info.PreMoney.ToString();
                tbxBalanceMoney.Text = _info.BalanceMoneyFlag + _info.BalanceMoney.ToString();
                tbxContact.Text = _info.Contact;
                tbxContactPhoneNumber.Text = _info.ContactPhoneNumber;
                tbxCostMoney.Text = _info.CostMoneyFlag + _info.CostMoney.ToString();
                tbxOtherMoney.Text = _info.OtherMoneyFlag + _info.OtherMoney.ToString();
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
            ddlstNext.Required = false;
            ddlstNext.ShowRedStar = false;
            ddlstNext.Enabled = false;
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
            taaOtherMoneyExplain.Enabled = false;
            taaContent.Required = false;
            taaContent.ShowRedStar = false;
            taaContent.Enabled = false;
            taaOther.Enabled = false;
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
        /// 确认转移事件 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(BusinessID) || string.IsNullOrEmpty(RecordID))
                return;
            BusinessManage _manage = new BusinessManage();
            BusinessInfo _info = _manage.GetBusinessByObjectID(BusinessID);
            BusinessRecordInfo _recordInfo = _manage.GetBusinessRecordByObjectID(RecordID);
            int result = 3;
            if (_info != null && _recordInfo != null)
            {
                _recordInfo.CheckDateTime = DateTime.Now;
                _recordInfo.Explain = _manage.ConvertBusinessTypeToString(false, _recordInfo.CurrentBusiness) + "由"
                    + _recordInfo.CheckerName + "转移到" + ddlstApproveUser.SelectedText;
                _recordInfo.CurrentBusiness = -1;
                _recordInfo.CheckerID = CurrentUser.ObjectId;
                _recordInfo.CheckerName = CurrentUser.Name;
                _recordInfo.CheckrDept = CurrentUser.Dept;
                _recordInfo.CostMoney = 0;
                _recordInfo.OtherMoney = 0;
                _recordInfo.State = 2;
                _manage.UpdateBusinessRecord(_recordInfo);

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

            if (result == -1)
            {
                //CheckMsg(ddlstApproveUser.SelectedValue.ToString(), ddlstApproveUser.SelectedText, "定制业务转移(来自吉信企业管理公司)");
                ResultMsgMore(ddlstApproveUser.SelectedValue.ToString(), ddlstApproveUser.SelectedText, "定制业务转移(来自吉信企业管理公司)中，您有一条 转移待办理 信息！");
                this.btnClose_Click(null, null);
            }
            else
            {
                Alert.Show("业务转移失败!");
            }
        }

        /// <summary>
        /// 数据行绑定事件
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

        #endregion
    }
}