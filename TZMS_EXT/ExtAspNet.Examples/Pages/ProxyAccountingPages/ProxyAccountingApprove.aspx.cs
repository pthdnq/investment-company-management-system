using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.TZMS.Model;
using System.Text;
using com.TZMS.Business;
using ExtAspNet;

namespace TZMS.Web
{
    public partial class ProxyAccountingApprove : BasePage
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
                if (roleType == RoleType.DZFGD)
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
                ProxyAccountingApplyInfo _info = new ProxyAccountingManage().GetApplyByObjectID(ApplyID);
                if (_info != null)
                {
                    lblUnit.Text = _info.PayUnitName;
                    lblCNMoney.Text = _info.CNMoney;
                    lblENMoney.Text = _info.ENMoney + "元";
                    lblSument.Text = _info.Sument;
                    lblCollectMethod.Text = _info.CollectMethod;
                    lblOpeningDate.Text = _info.OpeningDate.ToString("yyyy年-MM月-dd日");
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
            strCondition.Append(" and  (ApproveState <> 0 or (ApproveState = 0 and ApproveOp = 0))");
            List<ProxyAccountingApproveInfo> lstBaoxiaoCheckInfo = new ProxyAccountingManage().GetApproveByCondition(strCondition.ToString());

            lstBaoxiaoCheckInfo.Sort(delegate(ProxyAccountingApproveInfo x, ProxyAccountingApproveInfo y) { return DateTime.Compare(y.ApproveDate, x.ApproveDate); });

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
            ProxyAccountingManage _manage = new ProxyAccountingManage();
            ProxyAccountingApproveInfo _approveInfo = _manage.GetApproveByObjectID(ApproveID);
            if (_approveInfo != null && _approveInfo.ApproveState == 1)
            {
                btnPass.Hidden = true;
                btnRefuse.Hidden = true;
                mainForm2.Hidden = true;
                //// 查找最早的审批记录.
                //List<ProxyAccountingApproveInfo> lstApprove = _manage.GetApproveByCondition(" ApplyID = '" + ApplyID + "' and ApproveOp <> 0 and ApproveDate > '"
                //    + _approveInfo.ApproveDate.ToString() + "'");
                //if (lstApprove.Count > 0)
                //{
                //    lstApprove.Sort(delegate(ProxyAccountingApproveInfo x, ProxyAccountingApproveInfo y) { return DateTime.Compare(y.ApproveDate, x.ApproveDate); });
                //    ddlstApproveUser.SelectedValue = lstApprove[0].ApproverID.ToString();
                //    if (lstApprove[0].ApproveOp <= 1)
                //    {
                //        ddlstNext.SelectedValue = "0";
                //    }
                //    else if (lstApprove[0].ApproveOp == 3)
                //    {
                //        ddlstNext.SelectedValue = "1";
                //        ddlstNext_SelectedIndexChanged(null, null);
                //    }
                //}

                //taaApproveSugest.Text = _approveInfo.Sugest;
                //btnPass.Enabled = false;
                //btnRefuse.Enabled = false;
                //ddlstNext.Required = false;
                //ddlstNext.ShowRedStar = false;
                //ddlstNext.Enabled = false;
                //ddlstApproveUser.Enabled = false;
                //ddlstApproveUser.ShowRedStar = false;
                //ddlstApproveUser.Enabled = false;
                //taaApproveSugest.Enabled = false;
            }
        }

        #endregion

        #region 页面事件

        /// <summary>
        /// 审批历史绑定事件
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

        /// <summary>
        /// 下一步绑定事件
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
            ProxyAccountingManage _manage = new ProxyAccountingManage();
            ProxyAccountingApplyInfo _applyInfo = _manage.GetApplyByObjectID(ApplyID);
            ProxyAccountingApproveInfo _currentApproveInfo = _manage.GetApproveByObjectID(ApproveID);
            if (_applyInfo != null && _currentApproveInfo != null)
            {
                #region 审批

                if (ddlstNext.SelectedText == "审批")
                {
                    // 更新报销申请单记录.
                    _applyInfo.ApproverID = new Guid(ddlstApproveUser.SelectedValue);
                    result = _manage.UpdateApply(_applyInfo);

                    // 更新现有审批记录.
                    _currentApproveInfo.ApproveState = 1;
                    _currentApproveInfo.Result = 0;
                    _currentApproveInfo.ApproveDate = DateTime.Now;
                    _currentApproveInfo.Sugest = string.IsNullOrEmpty(taaApproveSugest.Text.Trim()) ? "同意" : taaApproveSugest.Text.Trim();
                    _currentApproveInfo.ApproveOp = 1;
                    _manage.UpdateApprove(_currentApproveInfo);

                    // 插入下一个审批记录.
                    ProxyAccountingApproveInfo _nextApproveInfo = new ProxyAccountingApproveInfo();
                    UserInfo _nextCheckUserInfo = new UserManage().GetUserByObjectID(ddlstApproveUser.SelectedValue);
                    _nextApproveInfo.ObjectID = Guid.NewGuid();
                    _nextApproveInfo.ApproverName = ddlstApproveUser.SelectedText;
                    _nextApproveInfo.ApproverID = new Guid(ddlstApproveUser.SelectedValue);
                    _nextApproveInfo.ApproverDept = _nextCheckUserInfo.Dept;
                    _nextApproveInfo.ApproveDate = ACommonInfo.DBMAXDate;
                    _nextApproveInfo.ApproveState = 0;
                    _nextApproveInfo.ApplyID = _currentApproveInfo.ApplyID;
                    _manage.AddNewApprove(_nextApproveInfo);
                }
                #endregion

                #region 归档

                if (ddlstNext.SelectedText == "同意并归档")
                {
                    // 修改申请单信息.
                    _applyInfo.State = 2;
                    _applyInfo.ApproverID = SystemUser.ObjectId;
                    result = _manage.UpdateApply(_applyInfo);

                    // 更新现有审批记录.
                    _currentApproveInfo.ApproveState = 1;
                    _currentApproveInfo.Result = 0;
                    _currentApproveInfo.ApproveDate = DateTime.Now;
                    _currentApproveInfo.Sugest = string.IsNullOrEmpty(taaApproveSugest.Text.Trim()) ? "同意" : taaApproveSugest.Text.Trim();
                    _currentApproveInfo.ApproveOp = 1;
                    _manage.UpdateApprove(_currentApproveInfo);

                    // 插入归档记录.
                    ProxyAccountingApproveInfo _archiveApproveInfo = new ProxyAccountingApproveInfo();
                    _archiveApproveInfo.ObjectID = Guid.NewGuid();
                    _archiveApproveInfo.ApproverID = SystemUser.ObjectId;
                    _archiveApproveInfo.ApproverName = SystemUser.Name;
                    _archiveApproveInfo.ApproveDate = _currentApproveInfo.ApproveDate.AddSeconds(1);
                    _archiveApproveInfo.ApproveState = 1;
                    _archiveApproveInfo.ApproveOp = 3;
                    _archiveApproveInfo.ApplyID = _applyInfo.ObjectID;
                    _manage.AddNewApprove(_archiveApproveInfo);

                    // 插入出纳记录.
                    CashFlowManage _cashFlowManage = new CashFlowManage();
                    _cashFlowManage.Add(_applyInfo.ENMoney, DateTime.Now, "Payment", TZMS.Common.Biz.ProxyAccounting, _applyInfo.PayUnitName + "的代账费", string.Empty);
                }

                #endregion
            }
            if (result == -1)
            {
                //Alert.Show(ddlstNext.SelectedText + "成功!");
                //btnPass.Enabled = false;
                //btnRefuse.Enabled = false;
                //BindApproveHistory();
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

            ProxyAccountingManage _manage = new ProxyAccountingManage();
            ProxyAccountingApplyInfo _applyInfo = _manage.GetApplyByObjectID(ApplyID);
            if (_applyInfo != null)
            {
                ProxyAccountingApproveInfo _currentApproveInfo = _manage.GetApproveByObjectID(ApproveID);

                //更新报销申请单信息.
                _applyInfo.State = 1;
                int result = _manage.UpdateApply(_applyInfo);

                // 更新报销流程表信息.
                _currentApproveInfo.ApproveDate = DateTime.Now;
                _currentApproveInfo.ApproveState = 1;
                _currentApproveInfo.Result = 1;
                _currentApproveInfo.Sugest = taaApproveSugest.Text.Trim();
                _currentApproveInfo.ApproveOp = 2;
                _manage.UpdateApprove(_currentApproveInfo);

                if (result == -1)
                {
                    // Alert.Show("打回成功!");

                    // 重新设置按钮状态并刷新审批历史.
                    //btnPass.Enabled = false;
                    // btnRefuse.Enabled = false;
                    // BindApproveHistory();

                    this.btnClose_Click(null, null);
                }
                else
                {
                    Alert.Show("审批失败(不同意)!");
                }
            }
        }

        #endregion
    }
}