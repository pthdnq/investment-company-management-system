﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.TZMS.Model;
using System.Text;
using com.TZMS.Business;
using ExtAspNet;

namespace TZMS.Web
{
    public partial class MaterialsApply : BasePage
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
            if (CurrentRoles.Contains(RoleType.WZSQ_GD))
            {
                ddlstType.Items.Add(new ExtAspNet.ListItem("固定资产", "1"));
            }

            ddlstType.SelectedIndex = 0;

            BindMaterials();
        }

        /// <summary>
        /// 绑定物资
        /// </summary>
        private void BindMaterials()
        {
            ddlstMaterials.Items.Clear();
            MaterialsManage _manage = new MaterialsManage();
            List<MaterialsManageInfo> lstMaterials = _manage.GetMaterialsByCondition(" MaterialsType = " + ddlstType.SelectedValue);
            foreach (MaterialsManageInfo info in lstMaterials)
            {
                ddlstMaterials.Items.Add(new ExtAspNet.ListItem(info.MaterialsName, info.ObjectID.ToString()));
            }

            if (ddlstMaterials.Items.Count > 0)
            {
                BindTotalCount(ddlstMaterials.Items[0].Value);
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

            if (Convert.ToInt32(tbxNumbers.Text.Trim()) > Convert.ToInt32(lblTotalCount.Text.Trim()))
            {
                Alert.Show("申请数量不可超过库存数量!");
                return;
            }

            MaterialsApplyInfo _applyInfo = null;
            MaterialsManage _manage = new MaterialsManage();
            int result = 3;

            #region 添加申请单

            if (OperatorType == "Add")
            {
                // 创建报销单实例.

                _applyInfo = new MaterialsApplyInfo();
                _applyInfo.ObjectID = Guid.NewGuid();
                _applyInfo.UserID = CurrentUser.ObjectId;
                _applyInfo.UserName = CurrentUser.Name;
                _applyInfo.UserJobNo = CurrentUser.JobNo;
                _applyInfo.UserAccountNo = CurrentUser.AccountNo;
                _applyInfo.UserDept = CurrentUser.Dept;
                _applyInfo.ApplyTime = DateTime.Now;
                _applyInfo.MaterialsID = new Guid(ddlstMaterials.SelectedValue);
                _applyInfo.ApplyCount = Convert.ToInt32(tbxNumbers.Text.Trim());
                _applyInfo.Other = taaOther.Text.Trim();
                _applyInfo.State = 0;
                _applyInfo.CurrentApproverID = new Guid(ddlstApproveUser.SelectedValue);
                _applyInfo.IsDelete = false;

                // 插入新报销单.
                result = _manage.AddNewApply(_applyInfo);

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
                _applyInfo = _manage.GetApplyByObjectID(ApplyID);
                if (_applyInfo != null)
                {
                    // 更新申请单中的数据.
                    _applyInfo.MaterialsID = new Guid(ddlstMaterials.SelectedValue);
                    _applyInfo.ApplyCount = Convert.ToInt32(tbxNumbers.Text.Trim());
                    _applyInfo.Other = taaOther.Text.Trim();
                    _applyInfo.State = 0;
                    _applyInfo.CurrentApproverID = new Guid(ddlstApproveUser.SelectedValue);

                    result = _manage.UpdateApply(_applyInfo);

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
            MaterialsApplyInfo _info = _manage.GetApplyByObjectID(ApplyID);
            if (_info != null)
            {
                MaterialsManageInfo _manageInfo = _manage.GetMaterialByObjectID(_info.MaterialsID.ToString());
                if (_manageInfo != null)
                {
                    ddlstType.SelectedValue = _manageInfo.MaterialsType.ToString();
                    ddlstMaterials.SelectedValue = _manageInfo.ObjectID.ToString();
                    BindTotalCount(ddlstMaterials.SelectedValue);
                }
                lblName.Text = _info.UserName;
                lblApplyTime.Text = _info.ApplyTime.ToString("yyyy-MM-dd HH:mm");
                tbxNumbers.Text = _info.ApplyCount.ToString();
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
            ddlstMaterials.Required = false;
            ddlstMaterials.ShowRedStar = false;
            ddlstMaterials.Enabled = false;
            tbxNumbers.Required = false;
            tbxNumbers.ShowRedStar = false;
            tbxNumbers.Enabled = false;
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

        /// <summary>
        /// 绑定总数量
        /// </summary>
        /// <param name="strObjectID"></param>
        private void BindTotalCount(string strObjectID)
        {
            if (string.IsNullOrEmpty(strObjectID))
            {
                return;
            }

            MaterialsManage _manage = new MaterialsManage();
            MaterialsManageInfo _manageInfo = _manage.GetMaterialByObjectID(strObjectID);
            if (_manageInfo != null)
            {
                lblTotalCount.Text = _manageInfo.Numbers.ToString();
            }
        }

        #endregion

        #region 页面事件

        /// <summary>
        /// 物资类型变动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlstType_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindMaterials();
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
        /// 提交事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SaveApply();
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
                        e.Values[2] = "审批-通过";
                        break;
                    case "2":
                        e.Values[2] = "审批-不通过";
                        break;
                    case "3":
                        e.Values[2] = "批准领用";
                        break;
                    case "4":
                        e.Values[2] = "确认领用";
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// 物资名称变动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlstMaterials_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindTotalCount(ddlstMaterials.SelectedValue);
        }

        #endregion
    }
}