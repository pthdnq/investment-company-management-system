﻿using System;
using System.Collections.Generic;
using com.TZMS.Business;
using com.TZMS.Model;
using ExtAspNet;
using System.Text;

namespace TZMS.Web.Pages.InvestmentProjectPages
{
    /// <summary>
    /// ProjectAudit
    /// </summary>
    public partial class ProjectAudit : BasePage
    {
        #region 属性
        public string OperateType
        {
            get
            {
                if (ViewState["OperateType"] == null)
                {
                    return null;
                }

                return ViewState["OperateType"].ToString();
            }
            set
            {
                ViewState["OperateType"] = value;
            }
        }

        /// <summary>
        /// ObjectID
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
                OperateType = Request.QueryString["Type"];
                bindInterface(strID);
                // 绑定审批人.
              //  ApproveUser();
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
            #region View
            if (!string.IsNullOrEmpty(OperateType) && OperateType.Equals("View"))
            {
                this.btnDismissed.Hidden = true;
                this.btnSave.Hidden = true;
                this.tbAuditOpinion.Text = _Info.AuditOpinion;
                this.tbAuditOpinion.Enabled = false;

                this.ddlstApproveUser.Items.Add(new ListItem() { Text = _Info.NextOperaterName, Value = "0", Selected = true });
                this.ddlstNext.Enabled = false;
                this.ddlstApproveUser.Enabled = false;
            }
            else
            {
                // 绑定审批人.
                ApproveUser();
            }
            #endregion
            #region 下一步方式
            if (CurrentRoles.Contains(RoleType.DSZ))
            {
                BindNext(true);
            }
            else if (CurrentRoles.Contains(RoleType.ZJL))
            {      //大于30w且当前审批人不是董事长，不显示下一步会计审核选项
                if (_Info.ContractAmount >= 300000)
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
            List<InvestmentProjectHistoryInfo> lstInfo = new InvestmentProjectManage().GetHistoryByCondtion(strCondition.ToString());
            //lstInfo.Sort(delegate(BaoxiaoCheckInfo x, BaoxiaoCheckInfo y) { return DateTime.Compare(y.CheckDateTime, x.CheckDateTime); });

            gridHistory.RecordCount = lstInfo.Count;
            this.gridHistory.DataSource = lstInfo;
            this.gridHistory.DataBind();
        }
        #endregion

        #region 页面及控件事件
        protected void btnDismissed_Click(object sender, EventArgs e)
        {
            saveInfo(2);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (this.ddlstNext.SelectedValue.Equals("0"))
            {
                //同意，继续审核
                saveInfo(3);
            }
            else
            {
                //待会计审核/支付确认/归档
                saveInfo(4);
            }
        }

        /// <summary>
        /// 下一步下拉框变动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlstNext_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlstNext.SelectedIndex == 1)
            {
                ddlstApproveUser.Hidden = true;
                ddlstApproveUser.Required = false;
                ddlstApproveUser.ShowRedStar = false;
                ddlstApproveUser.Enabled = false;
                btnSave.Text = "同意并归档";
                btnSave.ConfirmText = "您确定同意并归档吗?";
            }
            else
            {
                ddlstApproveUser.Hidden = false;
                ddlstApproveUser.Required = true;
                ddlstApproveUser.ShowRedStar = true;
                ddlstApproveUser.Enabled = true;
                btnSave.Text = "同意";
                btnSave.ConfirmText = "您确定同意吗?";
            }
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
            //下一步操作
            if (status == 3)
            {
                _Info.NextOperaterName = this.ddlstApproveUser.SelectedText;
                _Info.NextOperaterId = new Guid(this.ddlstApproveUser.SelectedValue);
            }
            else
            {
                _Info.NextOperaterName = "";
                _Info.NextOperaterId = Guid.Empty;
            } 
            _Info.SubmitTime = DateTime.Now;
            //审批人
            if (!_Info.Adulters.Contains(this.CurrentUser.ObjectId.ToString()))
            {
                _Info.Adulters = _Info.Adulters + this.CurrentUser.ObjectId.ToString() + ";";
            }
            int result = 3;

            result = manage.Update(_Info);

            if (result == -1)
            {
                string statusName = (status == 2) ? "不同意" : (status == 3) ? "同意，继续审核" : "同意，归档";
                manage.AddHistory(_Info.ObjectId, "审批", string.Format("{0}", statusName), this.CurrentUser.AccountNo, this.CurrentUser.Name, DateTime.Now, _Info.AuditOpinion);

                if (status == 2)
                {
                    //不同意，发送消息给表单申请人
                    ResultMsg(_Info.CreaterId.ToString(), _Info.CreaterName, "项目申请", "未通过");
                }
                else if (status == 3)
                {
                    //继续审核，发消息给下一步执行人
                    CheckMsg(ddlstApproveUser.SelectedValue.ToString(), ddlstApproveUser.SelectedText, "项目审核列表");
                }
                else
                {
                    //CheckMsg(ddlstApproveUser.SelectedValue.ToString(), ddlstApproveUser.SelectedText, "项目确认列表");
                    //提醒申请人，审核通过并归档
                    ResultMsgMore(_Info.CreaterId.ToString(), _Info.CreaterName, "您有1条项目申请，已通过审核并归档！");
                }
                //Alert.Show("操作成功!");
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
                ddlstNext.Items.Add(new ExtAspNet.ListItem("归档", "1"));
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