using System;
using System.Collections.Generic;
using com.TZMS.Business;
using com.TZMS.Model;
using ExtAspNet;
using System.Text;

namespace TZMS.Web.Pages.InvestmentProjectPages
{
    public partial class ProjectApplyEditBA : BasePage
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
                BindHistory();
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
            MUDAttachment.RecordID = _Info.ObjectId.ToString();

            //if (_Info.Status == 2 || _Info.BAStatus != 2)
            if (_Info.BAStatus == 2)
            {
                this.btnSave.Hidden = false;
            }
            #region 下一步方式
            if (CurrentRoles.Contains(RoleType.HSKJ))
            {
                BindNext(true);
            }
            //else if (CurrentRoles.Contains(RoleType.ZJL))
            //{      //大于30w且当前审批人不是董事长，不显示下一步会计审核选项
            //    if (_Info.ContractAmount >= 300000)
            //    { BindNext(false); HighMoneyTips.Text = "提醒：本次操作资金总额大于30W。"; }
            //    else
            //    { BindNext(true); }
            //}
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

        /// <summary>
        /// 绑定历史
        /// </summary>
        private void BindHistory()
        {
            if (ObjectID == null)
                return;
            // 获取数据.
            StringBuilder strCondition = new StringBuilder();
            strCondition.Append("ForId = '" + ObjectID + "'");
            strCondition.Append(" ORDER BY OperationTime DESC");
            List<AccountantAuditHistoryInfo> lstInfo = new CashFlowManage().GetHistoryByCondtion(strCondition.ToString());
            //lstInfo.Sort(delegate(BaoxiaoCheckInfo x, BaoxiaoCheckInfo y) { return DateTime.Compare(y.CheckDateTime, x.CheckDateTime); });
            for (int i = 0; i < lstInfo.Count; i++)
            {
                if (lstInfo[i].OperationType == "编辑")
                {
                    lstInfo[i].Remark = "";
                }
            }
            gridHistory.RecordCount = lstInfo.Count;
            this.gridHistory.DataSource = lstInfo;
            this.gridHistory.DataBind();
        }
        #endregion

        #region 页面及控件事件
        protected void btnDismissed_Click(object sender, EventArgs e)
        {
            saveInfo(1);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            saveInfo(1);
            // saveInfo(3);
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

            _Info.Remark = this.tbRemark.Text.Trim();
            //_Info.AuditOpinion = this.tbAuditOpinion.Text.Trim();
            _Info.BAStatus = status;
            //补充申请人及下一步审核人信息
            _Info.SubmitBATime = DateTime.Now;
            _Info.NextBAOperaterName = this.ddlstApproveUser.SelectedText;
            _Info.NextBAOperaterId = new Guid(this.ddlstApproveUser.SelectedValue);

            // 出生日期.
            //if (dpkBirthday.SelectedDate is DateTime)
            //{
            //    _userInfo.Birthday = Convert.ToDateTime(dpkBirthday.SelectedDate);
            //} 

            int result = 3;

            result = manage.Update(_Info);

            if (result == -1)
            {
                string statusName = "修改后重新提交";// (status == 2) ? "不同意" : (status == 3) ? "同意，继续审核" : "同意，归档";
                new CashFlowManage().AddHistory(_Info.ObjectId, "编辑", string.Format("{0}", statusName), this.CurrentUser.AccountNo, this.CurrentUser.Name, DateTime.Now, _Info.Remark, "InvestmentProject");

                CheckMsg(ddlstApproveUser.SelectedValue.ToString(), ddlstApproveUser.SelectedText, "项目实施会计核算");

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
                // ddlstNext.Items.Add(new ExtAspNet.ListItem("归档", "1"));
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