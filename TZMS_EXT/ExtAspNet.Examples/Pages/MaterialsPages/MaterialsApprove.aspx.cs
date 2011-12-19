using System;
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
    public partial class MaterialsApprove : BasePage
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
                if (roleType == RoleType.WZSPGD)
                {
                    ddlstNext.Items.Add(new ExtAspNet.ListItem("批准领用", "1"));
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
                MaterialsManage _manage = new MaterialsManage();
                MaterialsApplyInfo _info = _manage.GetApplyByObjectID(ApplyID);
                if (_info != null)
                {
                    MaterialsManageInfo _manageInfo = _manage.GetMaterialByObjectID(_info.MaterialsID.ToString());
                    if (_manageInfo != null)
                    {
                        ddlstType.Text = _manageInfo.MaterialsType == 0 ? "办公用品" : "固定资产";
                        ddlstMaterials.Text = _manageInfo.MaterialsName;
                    }
                    lblName.Text = _info.UserName;
                    lblApplyTime.Text = _info.ApplyTime.ToString("yyyy-MM-dd HH:mm");
                    tbxNumbers.Text = _info.ApplyCount.ToString();
                    taaOther.Text = _info.Other;
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
            strCondition.Append(" and ApproveState <> 0");
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
        /// 通过事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnPass_Click(object sender, EventArgs e)
        {
            if (ApproveID == null || ApplyID == null)
                return;
            int result = 3;
            MaterialsManage _manage = new MaterialsManage();
            MaterialsApplyInfo _applyInfo = _manage.GetApplyByObjectID(ApplyID);
            MaterialsApproveInfo _currentApproveInfo = _manage.GetApproveByObjectID(ApproveID);
            if (_applyInfo != null && _currentApproveInfo != null)
            {
                #region 审批

                if (ddlstNext.SelectedText == "审批")
                {
                    // 更新报销申请单记录.
                    _applyInfo.CurrentApproverID = new Guid(ddlstApproveUser.SelectedValue);
                    result = _manage.UpdateApply(_applyInfo);

                    // 更新现有审批记录.
                    _currentApproveInfo.ApproveState = 1;
                    _currentApproveInfo.Result = 0;
                    _currentApproveInfo.ApproveTime = DateTime.Now;
                    _currentApproveInfo.ApproveSugest = string.IsNullOrEmpty(taaApproveSugest.Text.Trim()) ? "同意" : taaApproveSugest.Text.Trim();
                    _currentApproveInfo.ApproveOp = 1;
                    _manage.UpdateApprove(_currentApproveInfo);

                    // 插入下一个审批记录.
                    MaterialsApproveInfo _nextApproveInfo = new MaterialsApproveInfo();
                    UserInfo _nextCheckUserInfo = new UserManage().GetUserByObjectID(ddlstApproveUser.SelectedValue);
                    _nextApproveInfo.ObjectID = Guid.NewGuid();
                    _nextApproveInfo.ApproverName = ddlstApproveUser.SelectedText;
                    _nextApproveInfo.ApproverID = new Guid(ddlstApproveUser.SelectedValue);
                    _nextApproveInfo.ApproverDept = _nextCheckUserInfo.Dept;
                    _nextApproveInfo.ApproveTime = ACommonInfo.DBMAXDate;
                    _nextApproveInfo.ApproveState = 0;
                    _nextApproveInfo.ApplyID = _currentApproveInfo.ApplyID;
                    _manage.AddNewApprove(_nextApproveInfo);
                }
                #endregion

                #region 归档

                if (ddlstNext.SelectedText == "批准领用")
                {
                    // 修改申请单信息.
                    _applyInfo.State = 2;
                    //_applyInfo.CurrentApproverID = SystemUser.ObjectId;
                    result = _manage.UpdateApply(_applyInfo);

                    // 更新物资信息.
                    MaterialsManageInfo _manageInfo = _manage.GetMaterialByObjectID(_applyInfo.MaterialsID.ToString());
                    _manageInfo.CurrentNumbers += 1;
                    _manage.UpdateMaterial(_manageInfo);

                    // 更新现有审批记录.
                    _currentApproveInfo.ApproveState = 1;
                    _currentApproveInfo.Result = 0;
                    _currentApproveInfo.ApproveTime = DateTime.Now;
                    _currentApproveInfo.ApproveSugest = string.IsNullOrEmpty(taaApproveSugest.Text.Trim()) ? "同意" : taaApproveSugest.Text.Trim();
                    _currentApproveInfo.ApproveOp = 1;
                    _manage.UpdateApprove(_currentApproveInfo);

                    // 插入归档记录.
                    MaterialsApproveInfo _archiveApproveInfo = new MaterialsApproveInfo();
                    _archiveApproveInfo.ObjectID = Guid.NewGuid();
                    _archiveApproveInfo.ApproverID = _currentApproveInfo.ApproverID;
                    _archiveApproveInfo.ApproverName = _currentApproveInfo.ApproverName;
                    _archiveApproveInfo.ApproveTime = _currentApproveInfo.ApproveTime.AddSeconds(1);
                    _archiveApproveInfo.ApproveState = 1;
                    _archiveApproveInfo.ApproveOp = 3;
                    _archiveApproveInfo.ApplyID = _applyInfo.ObjectID;
                    _manage.AddNewApprove(_archiveApproveInfo);
                }

                #endregion
            }
            if (result == -1)
            {
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

            MaterialsManage _manage = new MaterialsManage();
            MaterialsApplyInfo _applyInfo = _manage.GetApplyByObjectID(ApplyID);
            if (_applyInfo != null)
            {
                MaterialsApproveInfo _currentApproveInfo = _manage.GetApproveByObjectID(ApproveID);

                //更新报销申请单信息.
                _applyInfo.State = 1;
                int result = _manage.UpdateApply(_applyInfo);

                // 更新报销流程表信息.
                _currentApproveInfo.ApproveTime = DateTime.Now;
                _currentApproveInfo.ApproveState = 1;
                _currentApproveInfo.Result = 1;
                _currentApproveInfo.ApproveSugest = taaApproveSugest.Text.Trim();
                _currentApproveInfo.ApproveOp = 2;
                _manage.UpdateApprove(_currentApproveInfo);

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
                btnPass.Text = "批准领用";
                btnPass.ConfirmText = "您确认批准领用吗?";
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

        #endregion
    }
}