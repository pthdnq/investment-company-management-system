using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.TZMS.Model;
using com.TZMS.Business.BusinessManage;
using ExtAspNet;
using com.TZMS.Business;

namespace TZMS.Web
{
    public partial class NormalBusinessTransfer : BasePage
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
            ddlstNext.Items.Add(new ExtAspNet.ListItem("业务转交", "1"));
            ddlstNext.Items.Add(new ExtAspNet.ListItem("核名", "2"));
            ddlstNext.Items.Add(new ExtAspNet.ListItem("刻章", "3"));
            ddlstNext.Items.Add(new ExtAspNet.ListItem("各类许可证", "4"));
            ddlstNext.Items.Add(new ExtAspNet.ListItem("开户", "5"));
            ddlstNext.Items.Add(new ExtAspNet.ListItem("验资报告", "6"));
            ddlstNext.Items.Add(new ExtAspNet.ListItem("营业执照", "7"));
            ddlstNext.Items.Add(new ExtAspNet.ListItem("办代码证", "8"));
            ddlstNext.Items.Add(new ExtAspNet.ListItem("办国地税", "9"));
            ddlstNext.Items.Add(new ExtAspNet.ListItem("转基本户", "10"));
            ddlstNext.Items.Add(new ExtAspNet.ListItem("税务备案", "11"));
            ddlstNext.Items.Add(new ExtAspNet.ListItem("增资(开户、验资报告、营业执照)", "12"));
            ddlstNext.Items.Add(new ExtAspNet.ListItem("完成", "13"));
            ddlstNext.Items.Add(new ExtAspNet.ListItem("异常终止", "14"));

            if (!string.IsNullOrEmpty(RecordID))
            {
                BusinessManage _manage = new BusinessManage();
                BusinessRecordInfo _recordInfo = _manage.GetBusinessRecordByObjectID(RecordID);
                if (_recordInfo != null)
                {
                    ddlstNext.SelectedValue = _recordInfo.CurrentBusiness.ToString();
                }
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
            tbxRegisteredMoney.Enabled = false;
            ddlstCZType.Enabled = false;
            ddlstCompanyType.Enabled = false;
            ddlstCompanyNameType.Enabled = false;
            tbxContact.Enabled = false;
            tbxContactPhoneNumber.Enabled = false;
            tbxSumMoney.Enabled = false;
            tbxPreMoney.Enabled = false;
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
        /// 转移事件
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
                _recordInfo.Explain = _manage.ConvertBusinessTypeToString(true, _recordInfo.CurrentBusiness) + "由"
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
                //CheckMsg(ddlstApproveUser.SelectedValue.ToString(), ddlstApproveUser.SelectedText, "普通业务转移(来自吉信企业管理公司)");
                ResultMsgMore(ddlstApproveUser.SelectedValue.ToString(), ddlstApproveUser.SelectedText, "普通业务转移(来自吉信企业管理公司)中，您有一条 转移待办理 信息！");
                this.btnClose_Click(null, null);
            }
            else
            {
                Alert.Show("业务转移失败!");
            }
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
                e.Values[2] = new BusinessManage().ConvertBusinessTypeToString(true, Convert.ToInt32(e.Values[2].ToString()));
            }
        }

        #endregion
    }
}