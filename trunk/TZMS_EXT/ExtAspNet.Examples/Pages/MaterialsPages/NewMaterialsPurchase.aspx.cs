using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExtAspNet;
using System.Text;
using com.TZMS.Model;
using com.TZMS.Business;

namespace TZMS.Web
{
    public partial class NewMaterialsPurchase : BasePage
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
                string strOperatorType = Request.QueryString["Type"];
                string strApplyID = Request.QueryString["ID"];

                switch (strOperatorType)
                {
                    case "Add":
                        {
                            OperatorType = strOperatorType;
                            tabApproveHistory.Hidden = true;
                            lblName.Text = CurrentUser.Name;
                            lblApplyTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
                            // 绑定下一步.
                            BindNext();
                            // 绑定审批人.
                            ApproveUser();
                            BindType();
                        }
                        break;
                    case "View":
                        {
                            OperatorType = strOperatorType;
                            ApplyID = strApplyID;

                            // 绑定下一步.
                            BindNext();
                            // 绑定审批人.
                            ApproveUser();
                            BindType();
                            // 绑定申请单信息.
                            BindApplyInfo();
                            // 绑定审批历史.
                            BindApproveHistory();
                            // 禁用所有控件.
                            DisableAllControls();
                        }
                        break;
                    case "Edit":
                        {
                            OperatorType = strOperatorType;
                            ApplyID = strApplyID;

                            // 绑定下一步.
                            BindNext();
                            // 绑定审批人.
                            ApproveUser();
                            BindType();
                            // 绑定申请单信息.
                            BindApplyInfo();
                            // 绑定审批历史.
                            BindApproveHistory();
                        }
                        break;
                    default:
                        break;
                }

                if (ddlstApproveUser.SelectedItem == null)
                {
                    Alert.Show("您的“执行人”为空，请在我的首页设置我的审批人！");
                }
            }
        }

        #region 私有方法

        /// <summary>
        /// 绑定下一步
        /// </summary>
        private void BindNext()
        {
            ddlstNext.Items.Add(new ExtAspNet.ListItem("审批", "0"));
            ddlstNext.SelectedIndex = 0;
        }

        /// <summary>
        /// 绑定类型
        /// </summary>
        private void BindType()
        {
            ddlstType.Items.Add(new ExtAspNet.ListItem("办公用品", "0"));
            //if (CurrentRoles.Contains(RoleType.WZSQ_GD))
            //{
            ddlstType.Items.Add(new ExtAspNet.ListItem("固定资产", "1"));
            //}

            ddlstType.SelectedIndex = 0;

            BindMaterials();
        }

        /// <summary>
        /// 绑定物资
        /// </summary>
        private void BindMaterials()
        {
            MaterialsManage _manage = new MaterialsManage();
            ddlstMaterialName.Items.Clear();
            List<MaterialsManageInfo> lstMaterials = _manage.GetMaterialsByCondition(" MaterialsType = " + ddlstType.SelectedValue);
            foreach (MaterialsManageInfo info in lstMaterials)
            {
                ddlstMaterialName.Items.Add(new ExtAspNet.ListItem(info.MaterialsName, info.ObjectID.ToString()));
            }
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

        /// <summary>
        /// 提交报销申请单
        /// </summary>
        private void SaveApply()
        {
            if (OperatorType == null)
                return;

            MaterialsPurchaseApplyInfo _applyInfo = null;
            MaterialsManage _manage = new MaterialsManage();
            int result = 3;

            #region 添加申请单

            if (OperatorType == "Add")
            {
                // 创建报销单实例.

                _applyInfo = new MaterialsPurchaseApplyInfo();
                _applyInfo.ObjectID = Guid.NewGuid();
                _applyInfo.UserID = CurrentUser.ObjectId;
                _applyInfo.UserName = CurrentUser.Name;
                _applyInfo.UserJobNo = CurrentUser.JobNo;
                _applyInfo.UserAccountNo = CurrentUser.AccountNo;
                _applyInfo.UserDept = CurrentUser.Dept;
                _applyInfo.ApplyTime = DateTime.Now;
                _applyInfo.MaterialsID = new Guid(ddlstMaterialName.SelectedValue);
                _applyInfo.Count = Convert.ToInt32(tbxCount.Text.Trim());
                _applyInfo.Money = Convert.ToDecimal(tbxMoney.Text.Replace(BT, "").Trim());

                _applyInfo.MoneyFlag = "";
                if (tbxMoney.Text.Contains(BT))
                {
                    _applyInfo.MoneyFlag = BT;
                }

                _applyInfo.NeedsDate = Convert.ToDateTime(dpkNeedsDate.SelectedDate);
                _applyInfo.Sument = taaSument.Text.Trim();
                _applyInfo.Other = taaOther.Text.Trim();
                _applyInfo.State = 0;
                _applyInfo.ApproverID = new Guid(ddlstApproveUser.SelectedValue);
                _applyInfo.IsDelete = false;

                // 插入新报销单.
                result = _manage.AddNewPurchaseApply(_applyInfo);

                // 插入起草记录到代帐费审批流程表.
                MaterialsApproveInfo _approveInfo = new MaterialsApproveInfo();
                _approveInfo.ObjectID = Guid.NewGuid();
                _approveInfo.ApproverID = CurrentUser.ObjectId;
                _approveInfo.ApproverName = CurrentUser.Name;
                _approveInfo.ApproverDept = CurrentUser.Dept;
                _approveInfo.ApproveTime = DateTime.Now;
                _approveInfo.ApproveState = 1;
                _approveInfo.ApproveOp = 0;
                _approveInfo.ApplyID = _applyInfo.ObjectID;
                _manage.AddNewApprove(_approveInfo);

                // 插入待审批记录到报销审批流程表.
                _approveInfo = new MaterialsApproveInfo();
                UserInfo _approveUser = new UserManage().GetUserByObjectID(ddlstApproveUser.SelectedValue);
                _approveInfo.ObjectID = Guid.NewGuid();
                _approveInfo.ApproverID = _approveUser.ObjectId;
                _approveInfo.ApproverName = _approveUser.Name;
                _approveInfo.ApproverDept = _approveUser.Dept;
                _approveInfo.ApproveTime = ACommonInfo.DBMAXDate;
                _approveInfo.ApproveState = 0;
                _approveInfo.ApplyID = _applyInfo.ObjectID;

                _manage.AddNewApprove(_approveInfo);

            }
            #endregion

            #region 编辑申请单

            if (OperatorType == "Edit")
            {
                _applyInfo = _manage.GetPurchaseApplyByObjectID(ApplyID);
                if (_applyInfo != null)
                {
                    // 更新申请单中的数据.
                    _applyInfo.MaterialsID = new Guid(ddlstMaterialName.SelectedValue);
                    _applyInfo.Count = Convert.ToInt32(tbxCount.Text.Trim());
                    _applyInfo.Money = Convert.ToDecimal(tbxMoney.Text.Replace(BT, "").Trim());
                    _applyInfo.MoneyFlag = "";
                    if (tbxMoney.Text.Contains(BT))
                    {
                        _applyInfo.MoneyFlag = BT;
                    }
                    _applyInfo.NeedsDate = Convert.ToDateTime(dpkNeedsDate.SelectedDate);
                    _applyInfo.Sument = taaSument.Text.Trim();
                    _applyInfo.Other = taaOther.Text.Trim();
                    _applyInfo.State = 0;
                    _applyInfo.ApproverID = new Guid(ddlstApproveUser.SelectedValue);
                    result = _manage.UpdatePurchaseApply(_applyInfo);

                    // 插入待审批记录到报销审批流程表.
                    MaterialsApproveInfo _approveInfo = new MaterialsApproveInfo();
                    UserInfo _approveUser = new UserManage().GetUserByObjectID(ddlstApproveUser.SelectedValue);
                    _approveInfo.ObjectID = Guid.NewGuid();
                    _approveInfo.ApproverID = _approveUser.ObjectId;
                    _approveInfo.ApproverName = _approveUser.Name;
                    _approveInfo.ApproverDept = _approveUser.Dept;
                    _approveInfo.ApproveTime = ACommonInfo.DBMAXDate;
                    _approveInfo.ApproveState = 0;
                    _approveInfo.ApplyID = _applyInfo.ObjectID;

                    _manage.AddNewApprove(_approveInfo);
                }
            }

            #endregion

            if (result == -1)
            {
                CheckMsg(ddlstApproveUser.SelectedValue.ToString(), ddlstApproveUser.SelectedText, "物资采购审批（来自物资管理）");

                this.btnClose_Click(null, null);
            }
            else
            {
                Alert.Show("申请提交失败!");
            }

        }

        /// <summary>
        /// 绑定报销单申请信息
        /// </summary>
        private void BindApplyInfo()
        {
            MaterialsManage _manage = new MaterialsManage();
            MaterialsPurchaseApplyInfo _info = _manage.GetPurchaseApplyByObjectID(ApplyID);
            if (_info != null)
            {
                MaterialsManageInfo _manageInfo = _manage.GetMaterialByObjectID(_info.MaterialsID.ToString());
                if (_manageInfo != null)
                {
                    ddlstType.SelectedValue = _manageInfo.MaterialsType.ToString();
                    BindMaterials();
                    ddlstMaterialName.SelectedValue = _manageInfo.ObjectID.ToString();
                }
                lblName.Text = _info.UserName;
                lblApplyTime.Text = _info.ApplyTime.ToString("yyyy-MM-dd HH:mm");
                tbxCount.Text = _info.Count.ToString();
                tbxMoney.Text = _info.MoneyFlag + _info.Money.ToString();
                dpkNeedsDate.SelectedDate = _info.NeedsDate;
                taaSument.Text = _info.Sument;
                taaOther.Text = _info.Other;

                // 查找最早的审批记录.
                List<MaterialsApproveInfo> lstApprove = _manage.GetApproveByCondition(" ApplyID = '" + ApplyID + "' and ApproveOp <> 0");
                if (lstApprove.Count == 1)
                {
                    ddlstApproveUser.SelectedValue = lstApprove[0].ApproverID.ToString();
                }
                else
                {
                    lstApprove.Sort(delegate(MaterialsApproveInfo x, MaterialsApproveInfo y) { return DateTime.Compare(x.ApproveTime, y.ApproveTime); });
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
        /// 禁用所有控件.
        /// </summary>
        private void DisableAllControls()
        {
            btnSubmit.Enabled = false;
            ddlstNext.Required = false;
            ddlstNext.ShowRedStar = false;
            ddlstNext.Enabled = false;
            ddlstApproveUser.Required = false;
            ddlstApproveUser.ShowRedStar = false;
            ddlstApproveUser.Enabled = false;
            ddlstType.Required = false;
            ddlstType.ShowRedStar = false;
            ddlstType.Enabled = false;
            ddlstMaterialName.Required = false;
            ddlstMaterialName.ShowRedStar = false;
            ddlstMaterialName.Enabled = false;
            tbxCount.Required = false;
            tbxCount.ShowRedStar = false;
            tbxCount.Enabled = false;
            tbxMoney.Required = false;
            tbxMoney.ShowRedStar = false;
            tbxMoney.Enabled = false;
            dpkNeedsDate.Required = false;
            dpkNeedsDate.ShowRedStar = false;
            dpkNeedsDate.Enabled = false;
            taaSument.Required = false;
            taaSument.ShowRedStar = false;
            taaSument.Enabled = false;
            taaOther.Required = false;
            taaOther.ShowRedStar = false;
            taaOther.Enabled = false;
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
            strCondition.Append(" and  ApproveState <> 0 ");
            List<MaterialsApproveInfo> lstBaoxiaoCheckInfo = new MaterialsManage().GetApproveByCondition(strCondition.ToString());

            lstBaoxiaoCheckInfo.Sort(delegate(MaterialsApproveInfo x, MaterialsApproveInfo y) { return DateTime.Compare(y.ApproveTime, x.ApproveTime); });

            // 绑定列表.
            gridApproveHistory.RecordCount = lstBaoxiaoCheckInfo.Count;
            this.gridApproveHistory.DataSource = lstBaoxiaoCheckInfo;
            this.gridApproveHistory.DataBind();
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
            SaveApply();
        }

        /// <summary>
        /// 类型变动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlstType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlstMaterialName.SelectedItem != null)
                ddlstMaterialName.SelectedItem.Text = "";
            ddlstMaterialName.Items.Clear();
            BindMaterials();
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
                    case "4":
                        e.Values[2] = "归档";
                        break;
                    case "5":
                        e.Values[2] = "入库";
                        break;
                    default:
                        break;
                }
            }
        }

        #endregion
    }
}