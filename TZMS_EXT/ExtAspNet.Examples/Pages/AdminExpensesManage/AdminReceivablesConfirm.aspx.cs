﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.TZMS.Business;
using com.TZMS.Model;
using ExtAspNet;
using System.Text;

namespace TZMS.Web.Pages.AdminExpensesManage
{
    public partial class AdminReceivablesConfirm : BasePage
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
            if (!IsPostBack)
            {
                string strID = Request.QueryString["ID"];
                ObjectID = strID;
                OperateType = Request.QueryString["Type"];

                bindUserInterface(strID);


                // 绑定审批人.
                //   ApproveUser();
                BindHistory(); 
            }
            InitControl();
        }

        private void InitControl()
        {
            this.btnClose.OnClientClick = ActiveWindow.GetConfirmHidePostBackReference();
            hlPrinter.NavigateUrl = "AdminReceivablesConfirmPrinter.aspx?ID=" + ObjectID;
        }

        /// <summary>
        /// 绑定指定用户ID的数据到界面.
        /// </summary>
        /// <param name="strUserID">用户ID</param>
        private void bindUserInterface(string strUserID)
        {
            if (string.IsNullOrEmpty(strUserID))
            {
                return;
            }
            AdminReceivablesInfo _Info = new AdminReceivablesManage().GetUserByObjectID(ObjectID);

            #region View
            if (!string.IsNullOrEmpty(OperateType) && OperateType.Equals("View"))
            {
                this.btnDismissed.Hidden = true;
                this.btnSave.Hidden = true;
                this.taAuditOpinion.Text = _Info.AuditOpinion;
                this.taAuditOpinion.Enabled = false;
                this.taAuditOpinion.Hidden = true;
                this.ToolbarSeparator1.Hidden = true;

                this.ddlstApproveUser.Items.Add(new ExtAspNet.ListItem() { Text = _Info.NextOperaterName, Value = "0", Selected = true });
                this.ddlstNext.ShowRedStar = false;
                this.ddlstNext.Required = false;
                this.ddlstApproveUser.ShowRedStar = false;
                this.ddlstApproveUser.Required = false;
                this.ddlstNext.Enabled = false;
                this.ddlstApproveUser.Enabled = false;
            }
            //else
            //{
            //    // 绑定审批人.
            ApproveUser();
            //}
            #endregion

            #region 下一步操作绑定
            //if (CurrentRoles.Contains(RoleType.XZBSKGD))
            //{
            //    BindNext(true);
            //}
            //else if (_Info.PrepaidAmount < 10000 && CurrentRoles.Contains(RoleType.XZBBYJGDXY1))
            //{
            //    BindNext(true);
            //}
            //else
            //{
            BindNext(false);
            //} 
            #endregion

            this.tbRemark.Text = _Info.Remark;
            this.tbCompany.Text = _Info.Company;
            this.taCause.Text = _Info.Cause;
            this.tbAmountOfReceivables.Text = _Info.AmountOfReceivables.ToString();
            this.dpDateFor.SelectedDate = _Info.DateFor;
            this.tbProjectName.Text = _Info.ProjectName;
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
            List<AdminReceivablesHistoryInfo> lstInfo = new AdminReceivablesManage().GetHistoryByCondtion(strCondition.ToString());
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
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDismissed_Click(object sender, EventArgs e)
        {
            //不同意，打回
            saveInfo(2);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //if (this.ddlstNext.SelectedValue.Equals("0"))
            //{
            //同意，继续审核
            saveInfo(3);
            //}
            //else
            //{
            //    //待会计审核/支付确认/归档
            //    saveInfo(4);
            //}
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
            AdminReceivablesManage manage = new AdminReceivablesManage();
            AdminReceivablesInfo _Info = manage.GetUserByObjectID(ObjectID);

            _Info.Status = status;
            _Info.AuditOpinion = this.taAuditOpinion.Text.Trim();

            //下一步操作人
            //if (status != 3)
            //{
            //   _Info.NextOperaterName = "";
            // _Info.NextOperaterId = Guid.Empty;
            //}
            //else
            //{
            _Info.NextOperaterName = this.ddlstApproveUser.SelectedText;
            _Info.NextOperaterId = new Guid(this.ddlstApproveUser.SelectedValue);
            //   }
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
                #region cashflow
                int itmp = new CashFlowManage().Add(new CashFlowStatementInfo()
                {
                    ObjectId = Guid.NewGuid(),
                    Amount = _Info.AmountOfReceivables,
                    DateFor = DateTime.Now,
                    FlowDirection = Common.FlowDirection.Receive,
                    FlowType = "",
                    Biz = Common.Biz.AdminReceivables,
                    ProjectName = _Info.ProjectName,
                    IsAccountingAudit = 1
                });
                if (itmp != -1)
                {
                    _Info.Status = 1;
                    manage.Update(_Info);
                    Alert.Show("操作失败!");
                    return;
                }
                #endregion

                string statusName = "出纳确认，提交领导确认";//(status == 2) ? "不同意" : (status == 3) ? "同意，继续确认" : "同意，归档";
                manage.AddHistory(_Info.ObjectId, "出纳确认", string.Format("{0}", statusName), this.CurrentUser.AccountNo, this.CurrentUser.Name, DateTime.Now, _Info.AuditOpinion);

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
            ddlstNext.Items.Add(new ExtAspNet.ListItem("领导确认", "0"));
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