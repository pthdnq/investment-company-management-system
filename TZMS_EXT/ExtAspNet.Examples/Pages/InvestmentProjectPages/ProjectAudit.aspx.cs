using System;
using System.Collections.Generic;
using com.TZMS.Business;
using com.TZMS.Model;
using ExtAspNet;

namespace TZMS.Web.Pages.InvestmentProjectPages
{
    /// <summary>
    /// ProjectAudit
    /// </summary>
    public partial class ProjectAudit : BasePage
    {
        #region 属性
        /// <summary>
        /// ID
        /// </summary>
        public string ObjectID
        {
            get
            {
                if (ViewState["ObjectID"] == null)
                {
                    return null;
                }

                return ViewState["ObjectID"].ToString();
            }
            set
            {
                ViewState["ObjectID"] = value;
            }
        }
        #endregion

        #region 页面加载及数据初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            InitControl();
            if (!IsPostBack)
            {
                string strID = Request.QueryString["ID"];
                bindInterface(strID);
                // 绑定审批人.
                ApproveUser();
            }
        }

        private void InitControl()
        {
            this.btnClose.OnClientClick = ActiveWindow.GetConfirmHideReference();
        }


        /// <summary>
        /// 绑定指定用户ID的数据到界面.
        /// </summary>
        /// <param name="strID">用户ID</param>
        private void bindInterface(string strID)
        {
            if (string.IsNullOrEmpty(strID))
            {
                return;
            }
            ObjectID = strID;

            InvestmentProjectInfo _Info = new InvestmentProjectManage().GetUserByObjectID(strID);

            #region 下一步方式
            if (CurrentRoles.Contains(RoleType.DSZ))
            {
                BindNext(true);
            }
            else if (CurrentRoles.Contains(RoleType.ZJL))
            {      //大于30w且当前审批人不是董事长，不显示下一步会计审核选项
                if (_Info.ContractAmount > 3000000)
                { BindNext(false); HighMoneyTips.Text = "提醒：本次操作资金总额大于30W。"; }
                else
                { BindNext(true); }
            }
            else
            {
                BindNext(false);
            }
            #endregion  

            this.tbProjectName.Text = _Info.ProjectName;
            this.tbProjectOverview.Text = _Info.ProjectOverview;
            this.tbCustomerName.Text = _Info.CustomerName;

            this.tbContact.Text = _Info.Contact;
            this.tbContactPhone.Text = _Info.ContactPhone;
            this.tbContractAmount.Text = _Info.ContractAmount.ToString();
            this.tbDownPayment.Text = _Info.DownPayment.ToString();
            this.dpSignDate.SelectedDate = _Info.SignDate;
            this.tbRemark.Text = _Info.Remark;

        }
        #endregion

        #region 页面及控件事件
        protected void btnDismissed_Click(object sender, EventArgs e)
        {
            saveInfo(2);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            saveInfo(3);
        }
        #endregion

        #region 自定义方法
        /// <summary>
        /// 保存信息.
        /// </summary>
        private void saveInfo(int status)
        {
            InvestmentProjectManage manage = new InvestmentProjectManage();
            InvestmentProjectInfo _Info = manage.GetUserByObjectID(ObjectID);


            _Info.AuditOpinion = this.tbAuditOpinion.Text.Trim();
            _Info.Status = status;
            //补充申请人及下一步审核人信息
            _Info.SubmitTime = DateTime.Now;

            // 出生日期.
            //if (dpkBirthday.SelectedDate is DateTime)
            //{
            //    _userInfo.Birthday = Convert.ToDateTime(dpkBirthday.SelectedDate);
            //} 

            int result = 3;

            result = manage.Update(_Info);

            if (result == -1)
            {
                string statusName = (status == 2) ? "不同意" : (status == 3) ? "同意" : "待会计审核";
                manage.AddHistory(_Info.ObjetctId, "审批", string.Format("审批:{0}", statusName), this.CurrentUser.AccountNo, this.CurrentUser.Name, DateTime.Now, string.Empty);

                Alert.Show("操作成功!");
                PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
            }
            else
            {
                Alert.Show("操作失败!");
            }
        }


        /// <summary>
        /// 绑定下一步
        /// </summary>
        private void BindNext(bool needAccountant)
        {
            ddlstNext.Items.Add(new ExtAspNet.ListItem("审批", "0"));
            if (needAccountant)
            {
                ddlstNext.Items.Add(new ExtAspNet.ListItem("会计审核", "1"));
            }
            ddlstNext.SelectedIndex = 0;
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
        #endregion
    }
}