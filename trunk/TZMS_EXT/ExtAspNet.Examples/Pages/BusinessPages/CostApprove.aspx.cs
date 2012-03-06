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
    public partial class CostApprove : BasePage
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
            ddlstNext.Items.Add(new ExtAspNet.ListItem("确认", "0"));
            //foreach (RoleType roleType in CurrentRoles)
            //{
            //    if (roleType == RoleType.HSKJ)
            //    {
            //        ddlstNext.Items.Add(new ExtAspNet.ListItem("会计核算", "1"));
            //        break;
            //    }
            //}
            ddlstNext.SelectedIndex = 0;
        }

        /// <summary>
        /// 绑定审批人
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
        /// 绑定确认人
        /// </summary>
        private void BindConfirmUser()
        {
            ddlstApproveUser.Items.Clear();
            BusinessManage _manage = new BusinessManage();
            BusinessCostApplyInfo _applyInfo = _manage.GetCostApplyByObjectID(ApplyID);
            if (_applyInfo != null)
            {
                List<UserRoles> lstRoles = null;
                if (_applyInfo.ApplyMoney >= 300000)
                {
                    lstRoles = this.GetUsersByRole(RoleType.DSZ);
                }
                else
                {
                    lstRoles = this.GetUsersByRole(RoleType.ZJL);
                }

                foreach (UserRoles role in lstRoles)
                {
                    ddlstApproveUser.Items.Add(new ExtAspNet.ListItem(role.Name, role.UserObjectId.ToString()));
                }

                ddlstApproveUser.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// 根据角色类型来获取用户
        /// </summary>
        /// <param name="roleType">角色类型</param>
        /// <returns>用户集合</returns>
        private List<UserRoles> GetUsersByRole(RoleType roleType)
        {
            List<UserRoles> lstUserRoles = new List<UserRoles>();
            List<UserRoles> lstRoles = new RolesManage().GerRolesByCondition("1 = 1");
            if (lstRoles.Count > 0)
            {
                string[] arrayRoles = { };
                bool isContain = false;
                foreach (UserRoles role in lstRoles)
                {
                    isContain = false;
                    arrayRoles = role.Roles.Split(',');
                    foreach (string strRole in arrayRoles)
                    {
                        if (string.IsNullOrEmpty(strRole))
                            continue;
                        if ((int)roleType == Convert.ToInt32(strRole))
                        {
                            isContain = true;
                            break;
                        }
                    }

                    if (isContain)
                    {
                        lstUserRoles.Add(role);
                    }
                }
            }

            return lstUserRoles;
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
                //ddlstCompanyname.SelectedValue = _applyInfo.BusinessID.ToString();
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
        /// 同意事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnPass_Click(object sender, EventArgs e)
        {
            if (ApproveID == null || ApplyID == null)
                return;

            BusinessManage _manage = new BusinessManage();

            // 更新申请表.
            BusinessCostApplyInfo _applyInfo = _manage.GetCostApplyByObjectID(ApplyID);
            _applyInfo.State = 1;
            _applyInfo.ActualMoney = Convert.ToDecimal(tbxActualMoney.Text.Trim());
            _applyInfo.ApproverID = new Guid(ddlstApproveUser.SelectedValue);
            int result = _manage.UpdateCostApply(_applyInfo);

            // 更新请假申请流程表.
            BusinessCostApproveInfo _approveInfo = _manage.GetCostApproveByObjectID(ApproveID);
            _approveInfo.ApproveTime = DateTime.Now;
            _approveInfo.ApproveState = 1;
            _approveInfo.ApproveOp = 1;
            _approveInfo.ApproverSugest = "实际收取业务费用" + tbxActualMoney.Text + "元";
            _manage.UpdateCostApprove(_approveInfo);

            BusinessInfo _info = _manage.GetBusinessByObjectID(_applyInfo.BusinessID.ToString());
            if (_info != null)
            {
                if (_applyInfo.CostType == 0)
                {
                    _info.PreMoney = Convert.ToDecimal(tbxActualMoney.Text.Trim());
                    _info.PreMoneyType = 1;
                }
                else if (_applyInfo.CostType == 1)
                {
                    _info.BalanceMoney = Convert.ToDecimal(tbxActualMoney.Text.Trim());
                    _info.BalanceMoneyType = 1;
                }

                _manage.UpdateBusiness(_info);
            }

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

            CashFlowManage _cashFlowManage = new CashFlowManage();
            _cashFlowManage.Add(_applyInfo.ActualMoney, DateTime.Now, TZMS.Common.FlowDirection.Receive, TZMS.Common.Biz.BusinessCost, 
                _applyInfo.CompanyName + "的" + (_applyInfo.CostType == 0 ? "预收定金" : "业务尾款") + "收取", string.Empty);

            //// 插入新的记录到流程申请表.
            //if (ddlstNext.SelectedText == "审批")
            //{
            //    BusinessCostApproveInfo _nextApproveInfo = new BusinessCostApproveInfo();
            //    UserInfo _approveUser = new UserManage().GetUserByObjectID(ddlstApproveUser.SelectedValue);
            //    if (_approveUser != null)
            //    {
            //        _nextApproveInfo.ObjectID = Guid.NewGuid();
            //        _nextApproveInfo.ApproverID = _approveUser.ObjectId;
            //        _nextApproveInfo.ApproverName = _approveUser.Name;
            //        _nextApproveInfo.ApproverDept = _approveUser.Dept;
            //        _nextApproveInfo.ApproveState = 0;
            //        _nextApproveInfo.ApplyID = _applyInfo.ObjectID;

            //        _manage.AddNewCostApprove(_nextApproveInfo);
            //    }
            //}
            //else if (ddlstNext.SelectedText == "会计核算")
            //{
            //    if (string.IsNullOrEmpty(tbxActualMoney.Text.Trim()))
            //    {
            //        Alert.Show("实际金额不可为空!");
            //        return;
            //    }

            //}

            if (result == -1)
            {
                CheckMsg(ddlstApproveUser.SelectedValue.ToString(), ddlstApproveUser.SelectedText, "业务费用收取确认(来自吉信企业管理公司)");

                this.btnClose_Click(null, null);
            }
            else
            {
                Alert.Show("审批失败(同意)!");
            }
        }

        /// <summary>
        /// 不同意事件
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
            BusinessCostApplyInfo _applyInfo = _manage.GetCostApplyByObjectID(ApplyID);
            if (_applyInfo != null)
            {
                BusinessCostApproveInfo _currentApproveInfo = _manage.GetCostApproveByObjectID(ApproveID);

                //更新报销申请单信息.
                _applyInfo.State = 2;
                int result = _manage.UpdateCostApply(_applyInfo);

                // 更新报销流程表信息.
                _currentApproveInfo.ApproveTime = DateTime.Now;
                _currentApproveInfo.ApproveState = 1;
                _currentApproveInfo.ApproverSugest = taaApproveSugest.Text.Trim();
                _currentApproveInfo.ApproveOp = 2;
                _manage.UpdateCostApprove(_currentApproveInfo);

                if (result == -1)
                {
                    this.btnClose_Click(null, null);
                }
                else
                {
                    Alert.Show("审批失败(不同意)!");
                }
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
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlstNext_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlstNext.SelectedIndex == 1)
            {
                BindConfirmUser();
                btnPass.Text = "会计核算";
                btnPass.ConfirmText = "您确认会计核算吗?";
                tbxActualMoney.Hidden = false;
            }
            else
            {
                BindApproveUser();
                btnPass.Text = "同意";
                btnPass.Text = "您确认同意吗?";
                tbxActualMoney.Hidden = true;
            }
        }

        #endregion
    }
}