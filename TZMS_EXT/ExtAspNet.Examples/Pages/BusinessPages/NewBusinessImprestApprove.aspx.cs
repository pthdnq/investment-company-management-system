using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExtAspNet;
using com.TZMS.Model;
using com.TZMS.Business.BusinessManage;
using System.Text;
using com.TZMS.Business;

namespace TZMS.Web
{
    public partial class NewBusinessImprestApprove : BasePage
    {
        /// <summary>
        /// ApproveID
        /// </summary>
        public string ApproveID
        {
            get
            {
                if (ViewState["ApproveID"] == null)
                {
                    return null;
                }
                return ViewState["ApproveID"].ToString();
            }

            set
            {
                ViewState["ApproveID"] = value;
            }
        }

        /// <summary>
        /// ApplyID
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
                ApproveID = Request.QueryString["ApproveID"];
                ApplyID = Request.QueryString["ApplyID"];

                BindNext();
                BindApproveUser();
                BindApplyInfo();
                BindApproveHistory();
                SetPanelState();
            }
        }

        #region 私有方法

        /// <summary>
        /// 绑定下一步
        /// </summary>
        private void BindNext()
        {
            ddlstNext.Items.Add(new ExtAspNet.ListItem("审批", "0"));
            foreach (RoleType roleType in CurrentRoles)
            {
                if (roleType == RoleType.YWBBYJGD)
                {
                    ddlstNext.Items.Add(new ExtAspNet.ListItem("同意并归档", "1"));
                    break;
                }
            }
            ddlstNext.SelectedIndex = 0;
        }

        /// <summary>
        /// 绑定审批人
        /// </summary>
        private void BindApproveUser()
        {
            foreach (UserInfo item in CurrentChecker)
            {
                ddlstApproveUser.Items.Add(new ExtAspNet.ListItem(item.Name, item.ObjectId.ToString()));
            }

            ddlstApproveUser.SelectedIndex = 0;
        }

        /// <summary>
        /// 绑定报销申请单信息
        /// </summary>
        private void BindApplyInfo()
        {
            if (!string.IsNullOrEmpty(ApplyID))
            {
                BusinessManage _manage = new BusinessManage();
                BusinessImprestApplyInfo _info = _manage.GetImprestApplyByObjectID(ApplyID);
                if (_info != null)
                {
                    lblName.Text = _info.UserName;
                    lblApplyTime.Text = _info.ApplyTime.ToString("yyyy-MM-dd HH:mm");
                    lblMoney.Text = _info.SumMoney.ToString();
                    tbxSument.Text = _info.Sument;
                    lblBusinessName.Text = _info.BusinessName;
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
        /// 设置面板状态
        /// </summary>
        private void SetPanelState()
        {
            if (string.IsNullOrEmpty(ApproveID))
                return;
            BusinessManage _manage = new BusinessManage();
            BusinessImprestApproveInfo _info = _manage.GetImprestApproveByObjectID(ApproveID);
            if (_info != null)
            {
                if (_info.ApproveState == 1)
                {
                    btnPass.Hidden = true;
                    btnRefuse.Hidden = true;
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
        /// 通过事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnPass_Click(object sender, EventArgs e)
        {
            if (ApproveID == null || ApplyID == null)
                return;
            int result = 3;
            BusinessManage _manage = new BusinessManage();
            BusinessImprestApplyInfo _applyInfo = _manage.GetImprestApplyByObjectID(ApplyID);
            BusinessImprestApproveInfo _currentApproveInfo = _manage.GetImprestApproveByObjectID(ApproveID);
            if (_applyInfo != null && _currentApproveInfo != null)
            {
                #region 审批

                if (ddlstNext.SelectedText == "审批")
                {
                    // 更新报销申请单记录.
                    _applyInfo.ApproverID = new Guid(ddlstApproveUser.SelectedValue);
                    result = _manage.UpdateImprestApply(_applyInfo);

                    // 更新现有审批记录.
                    _currentApproveInfo.ApproveState = 1;
                    _currentApproveInfo.Result = 0;
                    _currentApproveInfo.ApproveTime = DateTime.Now;
                    _currentApproveInfo.ApproveSugest = string.IsNullOrEmpty(taaApproveSugest.Text.Trim()) ? "同意" : taaApproveSugest.Text.Trim();
                    _currentApproveInfo.ApproveOp = 1;
                    _manage.UpdateImprestApprove(_currentApproveInfo);

                    // 插入下一个审批记录.
                    BusinessImprestApproveInfo _nextApproveInfo = new BusinessImprestApproveInfo();
                    UserInfo _nextCheckUserInfo = new UserManage().GetUserByObjectID(ddlstApproveUser.SelectedValue);
                    _nextApproveInfo.ObjectID = Guid.NewGuid();
                    _nextApproveInfo.ApproverName = ddlstApproveUser.SelectedText;
                    _nextApproveInfo.ApproverID = new Guid(ddlstApproveUser.SelectedValue);
                    _nextApproveInfo.ApproverDept = _nextCheckUserInfo.Dept;
                    _nextApproveInfo.ApproveTime = ACommonInfo.DBMAXDate;
                    _nextApproveInfo.ApproveState = 0;
                    _nextApproveInfo.ApplyID = _currentApproveInfo.ApplyID;
                    _manage.AddNewImprestApprove(_nextApproveInfo);
                }
                #endregion

                #region 归档

                if (ddlstNext.SelectedText == "同意并归档")
                {
                    // 修改申请单信息.
                    _applyInfo.State = 2;
                    _applyInfo.ApproverID = SystemUser.ObjectId;
                    result = _manage.UpdateImprestApply(_applyInfo);

                    // 更新现有审批记录.
                    _currentApproveInfo.ApproveState = 1;
                    _currentApproveInfo.Result = 0;
                    _currentApproveInfo.ApproveTime = DateTime.Now;
                    _currentApproveInfo.ApproveSugest = string.IsNullOrEmpty(taaApproveSugest.Text.Trim()) ? "同意" : taaApproveSugest.Text.Trim();
                    _currentApproveInfo.ApproveOp = 1;
                    _manage.UpdateImprestApprove(_currentApproveInfo);

                    // 插入归档记录.
                    BusinessImprestApproveInfo _archiveApproveInfo = new BusinessImprestApproveInfo();
                    _archiveApproveInfo.ObjectID = Guid.NewGuid();
                    _archiveApproveInfo.ApproverID = SystemUser.ObjectId;
                    _archiveApproveInfo.ApproverName = SystemUser.Name;
                    _archiveApproveInfo.ApproveTime = _currentApproveInfo.ApproveTime.AddSeconds(1);
                    _archiveApproveInfo.ApproveState = 1;
                    _archiveApproveInfo.ApproveOp = 3;
                    _archiveApproveInfo.ApplyID = _applyInfo.ObjectID;
                    _manage.AddNewImprestApprove(_archiveApproveInfo);

                    // 流量记录.
                    CashFlowManage _cashFlowManage = new CashFlowManage();
                    _cashFlowManage.Add(_applyInfo.SumMoney, DateTime.Now, TZMS.Common.FlowDirection.Payment, TZMS.Common.Biz.ImprestBussiness,
                        _applyInfo.BusinessName + "的" + (_applyInfo.BusinessType == 0 ? "普通业务" : "定制业务") + "的备用金", string.Empty);
                }

                #endregion
            }
            if (result == -1)
            {
                if (ddlstNext.SelectedText == "审批")
                {
                    CheckMsg(ddlstApproveUser.SelectedValue.ToString(), ddlstApproveUser.SelectedText, "备用金审批(来自吉信企业管理公司)");
                }
                else
                {
                    ResultMsgMore(_applyInfo.UserID.ToString(), _applyInfo.UserName, "您有1条备用金申请(来自吉信企业管理公司)，已通过审核并归档！");
                }

                this.btnClose_Click(null, null);
            }
            else
            {
                Alert.Show("审批失败(" + ddlstNext.SelectedText + ")!");
            }
        }

        /// <summary>
        /// 不通过事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnRefuse_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(taaApproveSugest.Text.Trim()))
            {
                Alert.Show("审批意见不可为空!");
                return;
            }

            if (ApproveID == null || ApplyID == null)
                return;

            BusinessManage _manage = new BusinessManage();
            BusinessImprestApplyInfo _applyInfo = _manage.GetImprestApplyByObjectID(ApplyID);
            if (_applyInfo != null)
            {
                BusinessImprestApproveInfo _currentApproveInfo = _manage.GetImprestApproveByObjectID(ApproveID);

                //更新报销申请单信息.
                _applyInfo.State = 1;
                int result = _manage.UpdateImprestApply(_applyInfo);

                // 更新报销流程表信息.
                _currentApproveInfo.ApproveTime = DateTime.Now;
                _currentApproveInfo.ApproveState = 1;
                _currentApproveInfo.Result = 1;
                _currentApproveInfo.ApproveSugest = taaApproveSugest.Text.Trim();
                _currentApproveInfo.ApproveOp = 2;
                _manage.UpdateImprestApprove(_currentApproveInfo);

                if (result == -1)
                {
                    ResultMsgMore(_applyInfo.UserID.ToString(), _applyInfo.UserName, "您有1条备用金申请(来自吉信企业管理公司)，未通过审核！");
                    this.btnClose_Click(null, null);
                }
                else
                {
                    Alert.Show("审批失败(不同意)!");
                }
            }
        }

        /// <summary>
        /// 下一步变动事件
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
                btnPass.Text = "同意并归档";
                btnPass.ConfirmText = "您确认同意并归档吗?";
            }
            else
            {
                ddlstApproveUser.Hidden = false;
                ddlstApproveUser.Required = true;
                ddlstApproveUser.ShowRedStar = true;
                ddlstApproveUser.Enabled = true;
                btnPass.Text = "同意";
                btnPass.Text = "您确认同意吗?";
            }
        }

        /// <summary>
        /// 审批历史数据行绑定事件
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