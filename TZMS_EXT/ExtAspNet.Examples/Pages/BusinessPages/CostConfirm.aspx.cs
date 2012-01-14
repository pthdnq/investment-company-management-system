using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.TZMS.Business.BusinessManage;
using com.TZMS.Model;
using System.Text;
using ExtAspNet;
using com.TZMS.Business;

namespace TZMS.Web
{
    public partial class CostConfirm : BasePage
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
            ddlstNext.Items.Clear();
            ddlstNext.Items.Add(new ExtAspNet.ListItem("确认", "0"));
            BusinessManage _manage = new BusinessManage();
            BusinessCostApplyInfo _applyInfo = _manage.GetCostApplyByObjectID(ApplyID);
            if (_applyInfo != null)
            {
                if (_applyInfo.ActualMoney >= 300000)
                {
                    if (CurrentRoles.Contains(RoleType.YWFYSQQRGDDY30W))
                    {
                        ddlstNext.Items.Add(new ExtAspNet.ListItem("归档", "1"));
                    }
                }
                else
                {
                    if (CurrentRoles.Contains(RoleType.YWFYSQQRGDXY30W))
                    {
                        ddlstNext.Items.Add(new ExtAspNet.ListItem("归档", "1"));
                    }
                }
            }
        }

        /// <summary>
        /// 绑定执行人
        /// </summary>
        private void BindApproveUser()
        {
            ddlstApproveUser.Items.Clear();
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
            if (string.IsNullOrEmpty(ApplyID))
                return;
            BusinessManage _manage = new BusinessManage();
            BusinessCostApplyInfo _applyInfo = _manage.GetCostApplyByObjectID(ApplyID);
            if (_applyInfo != null)
            {
                ddlstCompanyname.Items.Clear();
                ddlstCompanyname.Items.Add(new ExtAspNet.ListItem(_applyInfo.CompanyName, _applyInfo.BusinessID.ToString()));
                ddlstCostType.SelectedValue = _applyInfo.CostType.ToString();
                ddlstPayType.SelectedValue = _applyInfo.PayType.ToString();
                lblApplyMoney.Text = _applyInfo.ApplyMoney.ToString();
                dpkPayDate.SelectedDate = _applyInfo.PayDate;
                taaOther.Text = _applyInfo.Other;
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
            strCondition.Append(" and ApproveState <> 0");
            List<BusinessCostApproveInfo> lstBaoxiaoCheckInfo = new BusinessManage().GetCostApproveByCondition(strCondition.ToString());

            lstBaoxiaoCheckInfo.Sort(delegate(BusinessCostApproveInfo x, BusinessCostApproveInfo y) { return DateTime.Compare(y.ApproveTime, x.ApproveTime); });

            // 绑定列表.
            gridCostApproveHistory.RecordCount = lstBaoxiaoCheckInfo.Count;
            this.gridCostApproveHistory.DataSource = lstBaoxiaoCheckInfo;
            this.gridCostApproveHistory.DataBind();
        }

        /// <summary>
        /// 设置面板状态
        /// </summary>
        private void SetPanelState()
        {
            if (string.IsNullOrEmpty(ApproveID))
                return;
            BusinessManage _manage = new BusinessManage();
            BusinessCostApproveInfo _approveInfo = _manage.GetCostApproveByObjectID(ApproveID);
            if (_approveInfo != null)
            {
                if (_approveInfo.ApproveState == 1)
                {
                    btnPass.Hidden = true;
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
        /// 确认事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnPass_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ApplyID) || string.IsNullOrEmpty(ApproveID))
                return;
            BusinessManage _manage = new BusinessManage();
            BusinessCostApplyInfo _applyInfo = _manage.GetCostApplyByObjectID(ApplyID);
            BusinessCostApproveInfo _approveInfo = _manage.GetCostApproveByObjectID(ApproveID);
            int result = 3;
            if (_applyInfo != null && _approveInfo != null)
            {
                if (ddlstNext.SelectedIndex == 0)
                {
                    _applyInfo.ApproverID = new Guid(ddlstApproveUser.SelectedValue);
                    result = _manage.UpdateCostApply(_applyInfo);

                    // 更新确认信息.
                    _approveInfo.ApproveState = 1;
                    _approveInfo.ApproveTime = DateTime.Now;
                    _approveInfo.ApproverSugest = string.IsNullOrEmpty(taaApproveSugest.Text.Trim()) ? "同意" : taaApproveSugest.Text.Trim();
                    _manage.UpdateCostApprove(_approveInfo);

                    // 插入下条确认信息.
                    BusinessCostApproveInfo _archiverApproveInfo = new BusinessCostApproveInfo();
                    UserInfo _approveUser = new UserManage().GetUserByObjectID(ddlstApproveUser.SelectedValue);
                    if (_approveUser != null)
                    {
                        _archiverApproveInfo.ObjectID = Guid.NewGuid();
                        _archiverApproveInfo.ApproverID = _approveUser.ObjectId;
                        _archiverApproveInfo.ApproverName = _approveUser.Name;
                        _archiverApproveInfo.ApproverDept = _approveUser.Dept;
                        _archiverApproveInfo.ApproveState = 0;
                        _archiverApproveInfo.ApproveOp = 2;
                        _archiverApproveInfo.ApplyID = _applyInfo.ObjectID;

                        _manage.AddNewCostApprove(_archiverApproveInfo);
                    }
                }

                if (ddlstNext.SelectedIndex == 1)
                {
                    _applyInfo.State = 2;
                    _applyInfo.ApproverID = SystemUser.ObjectId;
                    result = _manage.UpdateCostApply(_applyInfo);

                    _approveInfo.ApproveState = 1;
                    _approveInfo.ApproveTime = DateTime.Now;
                    _approveInfo.ApproverSugest = string.IsNullOrEmpty(taaApproveSugest.Text.Trim()) ? "同意" : taaApproveSugest.Text.Trim();
                    _manage.UpdateCostApprove(_approveInfo);

                    BusinessCostApproveInfo _archiverApproveInfo = new BusinessCostApproveInfo();
                    _archiverApproveInfo.ObjectID = Guid.NewGuid();
                    _archiverApproveInfo.ApproverID = SystemUser.ObjectId;
                    _archiverApproveInfo.ApproverName = SystemUser.Name;
                    _archiverApproveInfo.ApproverDept = SystemUser.Dept;
                    _archiverApproveInfo.ApproveState = 1;
                    _archiverApproveInfo.ApproveOp = 4;
                    _archiverApproveInfo.ApproveTime = DateTime.Now;
                    _archiverApproveInfo.ApplyID = _applyInfo.ObjectID;
                    _manage.AddNewCostApprove(_archiverApproveInfo);
                }
            }

            if (result == -1)
            {
                this.btnClose_Click(null, null);
            }
            else
            {
                Alert.Show(ddlstNext.SelectedText + "失败!");
            }
        }

        /// <summary>
        /// 数据行绑定事件
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
                        e.Values[2] = "出纳确认";
                        break;
                    case "2":
                        e.Values[2] = "费用确认";
                        break;
                    case "4":
                        e.Values[2] = "归档";
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// 下一步变动选择事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlstNext_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlstNext.SelectedIndex == 0)
            {
                ddlstApproveUser.Hidden = false;
                ddlstApproveUser.Required = true;
                ddlstApproveUser.ShowRedStar = true;
                ddlstApproveUser.Enabled = true;
                btnPass.Text = "确认";
                btnPass.Text = "您确定确认吗?";
            }
            else if (ddlstNext.SelectedIndex == 1)
            {
                ddlstApproveUser.Hidden = true;
                ddlstApproveUser.Required = false;
                ddlstApproveUser.ShowRedStar = false;
                ddlstApproveUser.Enabled = false;
                btnPass.Text = "归档";
                btnPass.ConfirmText = "您确定归档吗?";

            }
        }

        #endregion
    }
}