using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExtAspNet;
using com.TZMS.Business;
using com.TZMS.Model;

namespace TZMS.Web
{
    public partial class MaterialsSubComsume : BasePage
    {
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
                ApplyID = Request.QueryString["ID"];
                BindMaterialsInfo();
            }
        }

        #region 私有方法

        /// <summary>
        /// 绑定物资申请信息.
        /// </summary>
        private void BindMaterialsInfo()
        {
            if (string.IsNullOrEmpty(ApplyID))
                return;
            MaterialsManage _manage = new MaterialsManage();
            MaterialsApplyInfo _applyInfo = _manage.GetApplyByObjectID(ApplyID);
            if (_applyInfo != null)
            {
                lblName.Text = _applyInfo.UserName;
                lblApplyTime.Text = _applyInfo.ApplyTime.ToString("yyyy-MM-dd HH:mm");
                MaterialsManageInfo _manageInfo = _manage.GetMaterialByObjectID(_applyInfo.MaterialsID.ToString());
                if (_manageInfo != null)
                {
                    ddlstType.Text = _manageInfo.MaterialsType == 0 ? "办公用品" : "固定资产";
                    ddlstMaterials.Text = _manageInfo.MaterialsName;
                    lblTotalCount.Text = _manageInfo.Numbers.ToString();
                }
                tbxNumbers.Text = _applyInfo.ApplyCount.ToString();
                taaOther.Text = _applyInfo.Other;
            }
        }

        /// <summary>
        /// 领用事件
        /// </summary>
        private void SaveComsume()
        {
            if (string.IsNullOrEmpty(ApplyID))
                return;
            if (Convert.ToInt32(tbxActualCount.Text.Trim()) > Convert.ToInt32(lblTotalCount.Text.Trim()))
            {
                Alert.Show("领用数量不可超过物资总数量!");
                return;
            }

            MaterialsManage _manage = new MaterialsManage();
            MaterialsApplyInfo _applyInfo = _manage.GetApplyByObjectID(ApplyID);
            int result = 3;
            if (_applyInfo != null)
            {
                // 更新申请信息.
                _applyInfo.State = 3;
                _applyInfo.ActualCount = Convert.ToInt32(tbxActualCount.Text.Trim());
                result = _manage.UpdateApply(_applyInfo);

                // 更新物资管理信息.
                MaterialsManageInfo _manageInfo = _manage.GetMaterialByObjectID(_applyInfo.MaterialsID.ToString());
                if (_manageInfo != null)
                {
                    _manageInfo.Numbers -= _applyInfo.ActualCount;
                    _manageInfo.CurrentNumbers -= 1;
                    _manage.UpdateMaterial(_manageInfo);
                }

                // 更新审批信息.
                MaterialsApproveInfo _approveInfo = new MaterialsApproveInfo();
                _approveInfo.ObjectID = Guid.NewGuid();
                _approveInfo.ApproverID = CurrentUser.ObjectId;
                _approveInfo.ApproverName = CurrentUser.Name;
                _approveInfo.ApproverDept = CurrentUser.Dept;
                _approveInfo.ApproveState = 1;
                _approveInfo.ApproveOp = 4;
                _approveInfo.ApproveTime = DateTime.Now;
                _approveInfo.ApproveSugest = string.IsNullOrEmpty(taaApproveSugest.Text.Trim()) ? "确认领用" : taaApproveSugest.Text.Trim();
                _approveInfo.ApplyID = _applyInfo.ObjectID;

                _manage.AddNewApprove(_approveInfo);
            }

            if (result == -1)
            {
                this.btnClose_Click(null, null);
            }
            else
            {
                Alert.Show("领用失败!");
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
        /// 领用事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnPass_Click(object sender, EventArgs e)
        {
            SaveComsume();
        }

        #endregion
    }
}