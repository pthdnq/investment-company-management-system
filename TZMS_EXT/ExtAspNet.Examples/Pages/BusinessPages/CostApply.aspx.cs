using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExtAspNet;
using com.TZMS.Business.BusinessManage;
using com.TZMS.Model;
using System.Text;
using com.TZMS.Business;

namespace TZMS.Web
{
    public partial class CostApply : BasePage
    {
        /// <summary>
        /// 操作类型
        /// </summary>
        public string OperatorType
        {
            get
            {
                if (ViewState["OperatorType"] == null)
                {
                    return null;
                }

                return ViewState["OperatorType"].ToString();
            }
            set
            {
                ViewState["OperatorType"] = value;
            }
        }

        /// <summary>
        /// 报销单ID
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
                OperatorType = Request.QueryString["Type"];
                ApplyID = Request.QueryString["ID"];

                switch (OperatorType)
                {
                    case "Add":
                        BindNext();
                        BindApprover();
                        BindCompanyName();
                        this.ddlstCompanyname_SelectedIndexChanged(null, null);
                        tabApproveHistory.Hidden = true;
                        dpkPayDate.SelectedDate = DateTime.Now;
                        break;
                    case "Edit":
                        BindNext();
                        BindApprover();
                        BindCompanyName();
                        BindApplyInfo();
                        BindApproveHistory();

                        break;
                    case "View":
                        BindNext();
                        BindApprover();
                        BindCompanyName();
                        BindApplyInfo();
                        BindApproveHistory();
                        SetAllControlsDisable();

                        break;
                    default:
                        break;
                }
            }
        }

        #region 私有方法

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
        /// 绑定下一步
        /// </summary>
        private void BindNext()
        {
            ddlstNext.Items.Add(new ExtAspNet.ListItem("出纳确认", "0"));
            ddlstNext.SelectedIndex = 0;
        }

        /// <summary>
        /// 绑定审批人
        /// </summary>
        private void BindApprover()
        {
            ddlstApproveUser.Items.Clear();
            List<UserRoles> lstRoles = GetUsersByRole(RoleType.YWFYSQCNQR);

            foreach (UserRoles role in lstRoles)
            {
                ddlstApproveUser.Items.Add(new ExtAspNet.ListItem(role.Name, role.UserObjectId.ToString()));
            }

            ddlstApproveUser.SelectedIndex = 0;
        }

        /// <summary>
        /// 绑定公司名称
        /// </summary>
        private void BindCompanyName()
        {
            BusinessManage _manage = new BusinessManage();
            List<BusinessInfo> lstBusiness = _manage.GetBusinessByCondition(" IsDelete = 0 and State = 0");
            foreach (BusinessInfo info in lstBusiness)
            {
                ddlstCompanyname.Items.Add(new ExtAspNet.ListItem(info.CompanyName, info.ObjectID.ToString()));
            }
            ddlstCompanyname.SelectedIndex = 0;
        }

        /// <summary>
        /// 绑定申请单信息
        /// </summary>
        private void BindApplyInfo()
        {
            if (string.IsNullOrEmpty(ApplyID) || string.IsNullOrEmpty(OperatorType))
                return;
            BusinessManage _manage = new BusinessManage();
            BusinessCostApplyInfo _applyInfo = _manage.GetCostApplyByObjectID(ApplyID);
            if (_applyInfo != null)
            {
                ddlstCompanyname.SelectedValue = _applyInfo.BusinessID.ToString();
                ddlstCostType.SelectedValue = _applyInfo.CostType.ToString();
                ddlstPayType.SelectedValue = _applyInfo.PayType.ToString();
                lblApplyMoney.Text = _applyInfo.ApplyMoney.ToString();
                dpkPayDate.SelectedDate = _applyInfo.PayDate;
                taaOther.Text = _applyInfo.Other;

                // 查找最早的审批记录.
                List<BusinessCostApproveInfo> lstApprove = _manage.GetCostApproveByCondition(" ApplyID = '" + ApplyID + "'");
                if (lstApprove.Count == 1)
                {
                    ddlstApproveUser.SelectedValue = lstApprove[0].ApproverID.ToString();
                }
                else
                {
                    lstApprove.Sort(delegate(BusinessCostApproveInfo x, BusinessCostApproveInfo y) { return DateTime.Compare(x.ApproveTime, y.ApproveTime); });
                    foreach (var item in lstApprove)
                    {
                        if (DateTime.Compare(item.ApproveTime, ACommonInfo.DBEmptyDate) != 0)
                        {
                            ddlstApproveUser.SelectedValue = item.ApproverID.ToString();
                            break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 绑定审批历史
        /// </summary>
        private void BindApproveHistory()
        {
            if (string.IsNullOrEmpty(ApplyID))
                return;
            // 获取数据.
            StringBuilder strCondition = new StringBuilder();
            strCondition.Append("ApplyID = '" + ApplyID + "'");
            strCondition.Append(" and ApproveState = 1");
            List<BusinessCostApproveInfo> lstBaoxiaoCheckInfo = new BusinessManage().GetCostApproveByCondition(strCondition.ToString());

            lstBaoxiaoCheckInfo.Sort(delegate(BusinessCostApproveInfo x, BusinessCostApproveInfo y) { return DateTime.Compare(y.ApproveTime, x.ApproveTime); });

            // 绑定列表.
            gridApproveHistory.RecordCount = lstBaoxiaoCheckInfo.Count;
            this.gridApproveHistory.DataSource = lstBaoxiaoCheckInfo;
            this.gridApproveHistory.DataBind();
        }

        /// <summary>
        /// 禁用所有控件
        /// </summary>
        private void SetAllControlsDisable()
        {
            btnSubmit.Enabled = false;
            ddlstNext.Required = false;
            ddlstNext.ShowRedStar = false;
            ddlstNext.Enabled = false;
            ddlstApproveUser.Required = false;
            ddlstApproveUser.ShowRedStar = false;
            ddlstApproveUser.Enabled = false;
            ddlstCompanyname.Required = false;
            ddlstCompanyname.ShowRedStar = false;
            ddlstCompanyname.Enabled = false;
            ddlstCostType.Required = false;
            ddlstCostType.ShowRedStar = false;
            ddlstCostType.Enabled = false;
            ddlstPayType.Required = false;
            ddlstPayType.ShowRedStar = false;
            ddlstPayType.Enabled = false;
            lblApplyMoney.ShowRedStar = false;
            dpkPayDate.Required = false;
            dpkPayDate.ShowRedStar = false;
            dpkPayDate.Enabled = false;
            taaOther.Enabled = false;
        }

        /// <summary>
        /// 保存表单信息.
        /// </summary>
        private void SaveApplyInfo()
        {
            if (string.IsNullOrEmpty(OperatorType))
                return;

            BusinessManage _manage = new BusinessManage();
            BusinessCostApplyInfo _applyInfo = null;
            int result = 3;
            if (OperatorType == "Add")
            {
                _applyInfo = new BusinessCostApplyInfo();
                _applyInfo.ObjectID = Guid.NewGuid();
                _applyInfo.UserID = CurrentUser.ObjectId;
                _applyInfo.UserName = CurrentUser.Name;
                _applyInfo.UserDept = CurrentUser.Dept;
                _applyInfo.UserAccountNo = CurrentUser.AccountNo;
                _applyInfo.ApplyTime = DateTime.Now;
                _applyInfo.BusinessID = new Guid(ddlstCompanyname.SelectedValue);
                _applyInfo.CompanyName = ddlstCompanyname.SelectedText;
                _applyInfo.CostType = Convert.ToInt16(ddlstCostType.SelectedValue);
                _applyInfo.ApplyMoney = Convert.ToDecimal(lblApplyMoney.Text.Trim());
                _applyInfo.PayType = Convert.ToInt16(ddlstPayType.SelectedValue);
                _applyInfo.PayDate = Convert.ToDateTime(dpkPayDate.SelectedDate);
                _applyInfo.Other = taaOther.Text.Trim();
                _applyInfo.State = 0;
                _applyInfo.ApproverID = new Guid(ddlstApproveUser.SelectedValue);
                _applyInfo.IsDelete = false;

                result = _manage.AddNewCostApply(_applyInfo);

                // 插入起草记录.
                BusinessCostApproveInfo _draftApproveInfo = new BusinessCostApproveInfo();
                _draftApproveInfo.ObjectID = Guid.NewGuid();
                _draftApproveInfo.ApproverID = CurrentUser.ObjectId;
                _draftApproveInfo.ApproverName = CurrentUser.Name;
                _draftApproveInfo.ApproverDept = CurrentUser.Dept;
                _draftApproveInfo.ApproveState = 1;
                _draftApproveInfo.ApproveTime = _applyInfo.ApplyTime.AddSeconds(1);
                _draftApproveInfo.ApproveOp = 0;
                _draftApproveInfo.ApplyID = _applyInfo.ObjectID;

                _manage.AddNewCostApprove(_draftApproveInfo);

                // 插入待审批记录.
                BusinessCostApproveInfo _approveInfo = new BusinessCostApproveInfo();
                UserInfo _approveUser = new UserManage().GetUserByObjectID(ddlstApproveUser.SelectedValue);
                if (_approveUser != null)
                {
                    _approveInfo.ObjectID = Guid.NewGuid();
                    _approveInfo.ApproverID = _approveUser.ObjectId;
                    _approveInfo.ApproverName = _approveUser.Name;
                    _approveInfo.ApproverDept = _approveUser.Dept;
                    _approveInfo.ApproveState = 0;
                    _approveInfo.ApplyID = _applyInfo.ObjectID;

                    _manage.AddNewCostApprove(_approveInfo);
                }
            }

            if (OperatorType == "Edit")
            {
                _applyInfo = _manage.GetCostApplyByObjectID(ApplyID);
                if (_applyInfo != null)
                {
                    _applyInfo.BusinessID = new Guid(ddlstCompanyname.SelectedValue);
                    _applyInfo.CompanyName = ddlstCompanyname.SelectedText;
                    _applyInfo.CostType = Convert.ToInt16(ddlstCostType.SelectedValue);
                    _applyInfo.ApplyMoney = Convert.ToDecimal(lblApplyMoney.Text.Trim());
                    _applyInfo.PayType = Convert.ToInt16(ddlstPayType.SelectedValue);
                    _applyInfo.PayDate = Convert.ToDateTime(dpkPayDate.SelectedDate);
                    _applyInfo.Other = taaOther.Text.Trim();
                    _applyInfo.State = 0;
                    _applyInfo.ApproverID = new Guid(ddlstApproveUser.SelectedValue);
                    _applyInfo.IsDelete = false;

                    result = _manage.UpdateCostApply(_applyInfo);

                    // 插入待审批记录.
                    BusinessCostApproveInfo _approveInfo = new BusinessCostApproveInfo();
                    UserInfo _approveUser = new UserManage().GetUserByObjectID(ddlstApproveUser.SelectedValue);
                    if (_approveUser != null)
                    {
                        _approveInfo.ObjectID = Guid.NewGuid();
                        _approveInfo.ApproverID = _approveUser.ObjectId;
                        _approveInfo.ApproverName = _approveUser.Name;
                        _approveInfo.ApproverDept = _approveUser.Dept;
                        _approveInfo.ApproveState = 0;
                        _approveInfo.ApplyID = _applyInfo.ObjectID;

                        _manage.AddNewCostApprove(_approveInfo);
                    }
                }
            }

            if (result == -1)
            {
                CheckMsg(ddlstApproveUser.SelectedValue.ToString(), ddlstApproveUser.SelectedText, "业务费用收取出纳确认(来自吉信企业管理公司)");

                this.btnClose_Click(null, null);
            }
            else
            {
                Alert.Show("申请提交失败!");
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
        /// 提交事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SaveApplyInfo();
        }

        /// <summary>
        /// 公司名称变更事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlstCompanyname_SelectedIndexChanged(object sender, EventArgs e)
        {
            BusinessManage _manage = new BusinessManage();
            if (ddlstCompanyname.Items.Count == 0)
                return;
            BusinessInfo _info = _manage.GetBusinessByObjectID(ddlstCompanyname.SelectedValue);
            if (_info != null)
            {
                if (ddlstCostType.SelectedIndex == 0)
                {
                    lblApplyMoney.Text = _info.PreMoney.ToString();
                }
                else
                {
                    lblApplyMoney.Text = _info.BalanceMoney.ToString();
                }
            }
        }

        /// <summary>
        /// 费用类型变更事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlstCostType_SelectedIndexChanged(object sender, EventArgs e)
        {
            BusinessManage _manage = new BusinessManage();
            BusinessInfo _info = _manage.GetBusinessByObjectID(ddlstCompanyname.SelectedValue);
            if (_info != null)
            {
                if (ddlstCostType.SelectedIndex == 0)
                {
                    lblApplyMoney.Text = _info.PreMoney.ToString();
                }
                else
                {
                    lblApplyMoney.Text = _info.BalanceMoney.ToString();
                }
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

        #endregion
    }
}