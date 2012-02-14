using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.TZMS.Business;
using com.TZMS.Model;
using System.Text;
using ExtAspNet;

namespace TZMS.Web
{
    public partial class JingShengApprove : BasePage
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
                if (roleType == RoleType.KQGD)
                {
                    ddlstNext.Items.Add(new ExtAspNet.ListItem("归档", "1"));
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
        }

        /// <summary>
        /// 绑定归档人
        /// </summary>
        private void BindArchiver()
        {
            UserInfo _user = new UserManage().GetUserByObjectID(strArchiver);
            if (_user != null)
            {
                ddlstApproveUser.Items.Add(new ExtAspNet.ListItem(_user.Name, _user.ObjectId.ToString()));
            }
            else
            {
                ddlstApproveUser.Items.Add(new ExtAspNet.ListItem("", "-1"));
            }
        }

        /// <summary>
        /// 绑定报销申请单信息
        /// </summary>
        private void BindApplyInfo()
        {
            if (!string.IsNullOrEmpty(ApplyID))
            {
                JingShengApplyInfo _info = new JingShengManage().GetApplyByObjectID(ApplyID);
                if (_info != null)
                {
                    lblName.Text = _info.Name;
                    lblApplyTime.Text = _info.ApplyTime.ToString("yyyy-MM-dd HH:mm");
                    lblPosition.Text = _info.Position;
                    lblApplyPosition.Text = _info.ApplyPosition;
                    taaReason.Text = _info.Context;
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
            List<JingShengApproveInfo> lstApprove = new JingShengManage().GetApproveByCondition(strCondition.ToString());
            lstApprove.Sort(delegate(JingShengApproveInfo x, JingShengApproveInfo y) { return DateTime.Compare(y.ApproveTime, x.ApproveTime); });

            // 绑定列表.
            gridApproveHistory.RecordCount = lstApprove.Count;
            this.gridApproveHistory.DataSource = lstApprove;
            this.gridApproveHistory.DataBind();
        }

        private void SetPanelState()
        {
            if (string.IsNullOrEmpty(ApproveID))
                return;
            JingShengManage _manage = new JingShengManage();
            JingShengApproveInfo _approveInfo = _manage.GetApproveByObjectID(ApproveID);
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
        /// 通过事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnPass_Click(object sender, EventArgs e)
        {
            JingShengManage _manage = new JingShengManage();

            // 更新申请表.
            JingShengApplyInfo _applyInfo = _manage.GetApplyByObjectID(ApplyID);
            _applyInfo.ApproveID = new Guid(ddlstApproveUser.SelectedValue);
            int result = _manage.UpdateApply(_applyInfo);

            // 更新请假申请流程表.
            JingShengApproveInfo _approveInfo = _manage.GetApproveByObjectID(ApproveID);
            _approveInfo.ApproveTime = DateTime.Now;
            _approveInfo.ApproveState = 1;
            _approveInfo.Result = 0;
            _approveInfo.ApproveOp = 1;
            _approveInfo.Sugest = string.IsNullOrEmpty(taaApproveSugest.Text.Trim()) ? "同意" : taaApproveSugest.Text.Trim();
            _manage.UpdateApprove(_approveInfo);

            // 插入新的记录到流程申请表.
            if (ddlstNext.SelectedText == "审批")
            {
                JingShengApproveInfo _nextApproveInfo = new JingShengApproveInfo();
                UserInfo _approveUser = new UserManage().GetUserByObjectID(ddlstApproveUser.SelectedValue);
                if (_approveUser != null)
                {
                    _nextApproveInfo.ObjectID = Guid.NewGuid();
                    _nextApproveInfo.ApproverID = _approveUser.ObjectId;
                    _nextApproveInfo.ApproverName = _approveUser.Name;
                    _nextApproveInfo.ApproverDept = _approveUser.Dept;
                    _nextApproveInfo.ApproveState = 0;
                    _nextApproveInfo.ApplyID = _applyInfo.ObjectID;

                    _manage.AddNewApprove(_nextApproveInfo);
                }
            }
            else if (ddlstNext.SelectedText == "归档")
            {
                JingShengApproveInfo _archiverApproveInfo = new JingShengApproveInfo();
                UserInfo _approveUser = new UserManage().GetUserByObjectID(ddlstApproveUser.SelectedValue);
                if (_approveUser != null)
                {
                    _archiverApproveInfo.ObjectID = Guid.NewGuid();
                    _archiverApproveInfo.ApproverID = _approveUser.ObjectId;
                    _archiverApproveInfo.ApproverName = _approveUser.Name;
                    _archiverApproveInfo.ApproverDept = _approveUser.Dept;
                    _archiverApproveInfo.ApproveState = 0;
                    _archiverApproveInfo.ApproveOp = 3;
                    _archiverApproveInfo.ApplyID = _applyInfo.ObjectID;

                    _manage.AddNewApprove(_archiverApproveInfo);
                }
            }

            if (result == -1)
            {
                this.btnClose_Click(null, null);
            }
            else
            {
                Alert.Show("审批失败(同意)!");
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
            if (string.IsNullOrEmpty(strArchiver))
            {
                Alert.Show("请管理员配置行政归档员!");
                return;
            }

            JingShengManage _manage = new JingShengManage();

            // 更新申请表.
            JingShengApplyInfo _applyInfo = _manage.GetApplyByObjectID(ApplyID);
            UserInfo _archiveUser = new UserManage().GetUserByObjectID(strArchiver);
            if (_archiveUser == null)
            {
                Alert.Show("请管理员检查行政归档员是否存在!");
                return;
            }
            _applyInfo.ApproveID = _archiveUser.ObjectId;
            int result = _manage.UpdateApply(_applyInfo);

            // 更新请假申请流程表.
            JingShengApproveInfo _approveInfo = _manage.GetApproveByObjectID(ApproveID);
            _approveInfo.ApproveTime = DateTime.Now;
            _approveInfo.ApproveState = 1;
            _approveInfo.Result = 1;
            _approveInfo.ApproveOp = 2;
            _approveInfo.Sugest = taaApproveSugest.Text.Trim();
            _manage.UpdateApprove(_approveInfo);

            // 插入归档信息.
            JingShengApproveInfo _archiverApproveInfo = new JingShengApproveInfo();
            _archiverApproveInfo.ObjectID = Guid.NewGuid();
            _archiverApproveInfo.ApproverID = _archiveUser.ObjectId;
            _archiverApproveInfo.ApproverName = _archiveUser.Name;
            _archiverApproveInfo.ApproverDept = _archiveUser.Dept;
            _archiverApproveInfo.ApproveState = 0;
            _archiverApproveInfo.ApproveOp = 3;
            _archiverApproveInfo.ApplyID = _applyInfo.ObjectID;

            _manage.AddNewApprove(_archiverApproveInfo);

            if (result == -1)
            {
                this.btnClose_Click(null, null);
            }
            else
            {
                Alert.Show("审批失败(不同意)!");
            }
        }

        /// <summary>
        /// 下一步选择事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlstNext_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlstApproveUser.SelectedIndex = -1;
            ddlstApproveUser.Items.Clear();
            if (ddlstNext.SelectedIndex == 0)
            {
                BindApproveUser();
            }
            else if (ddlstNext.SelectedIndex == 1)
            {
                BindArchiver();
            }
        }

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