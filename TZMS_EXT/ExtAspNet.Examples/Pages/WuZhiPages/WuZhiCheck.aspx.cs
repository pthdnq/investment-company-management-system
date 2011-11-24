using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExtAspNet;
using com.TZMS.Model;
using com.TZMS.Business;
using System.Text;

namespace TZMS.Web
{
    public partial class WuZhiCheck : BasePage
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

            ddlstApproveUser.SelectedIndex = 0;
        }

        /// <summary>
        /// 绑定报销申请单信息
        /// </summary>
        private void BindApplyInfo()
        {
            if (!string.IsNullOrEmpty(ApplyID))
            {
                WuZhiInfo _info = new WuZhiManage().GetWuZhiByObjectID(ApplyID);
                if (_info != null)
                {
                    lblUser.Text = _info.UserName;
                    lblApplyDate.Text = _info.ApplyTime.ToString("yyyy-MM-dd HH:mm");
                    lblWuZhiType.Text = _info.Type == 0 ? "一般物资" : "固定物资";
                    lblTitle.Text = _info.Title;
                    taaSument.Text = _info.Sument;
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
            strCondition.Append(" and  (Checkstate <> 0 or (Checkstate = 0 and CheckOp = '0'))");
            List<WuzhiCheckInfo> lstBaoxiaoCheckInfo = new WuZhiManage().GetWuZhiCheckByCondition(strCondition.ToString());

            lstBaoxiaoCheckInfo.Sort(delegate(WuzhiCheckInfo x, WuzhiCheckInfo y) { return DateTime.Compare(y.CheckDateTime, x.CheckDateTime); });

            // 绑定列表.
            gridApproveHistory.RecordCount = lstBaoxiaoCheckInfo.Count;
            this.gridApproveHistory.DataSource = lstBaoxiaoCheckInfo;
            this.gridApproveHistory.DataBind();
        }

        #endregion

        /// <summary>
        /// 关闭
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
            WuZhiManage _manage = new WuZhiManage();
            WuZhiInfo _applyInfo = _manage.GetWuZhiByObjectID(ApplyID);
            WuzhiCheckInfo _currentApproveInfo = _manage.GetWuZhiCheckByObjectID(ApproveID);
            if (_applyInfo != null && _currentApproveInfo != null)
            {
                #region 审批

                if (ddlstNext.SelectedText == "审批")
                {
                    // 更新报销申请单记录.
                    _applyInfo.CurrentCheckerId = new Guid(ddlstApproveUser.SelectedValue);
                    result = _manage.UpdateWuZhi(_applyInfo);

                    // 更新现有审批记录.
                    _currentApproveInfo.Checkstate = 1;
                    _currentApproveInfo.Result = "0";
                    _currentApproveInfo.CheckDateTime = DateTime.Now;
                    _currentApproveInfo.CheckSugest = string.IsNullOrEmpty(taaApproveSugest.Text.Trim()) ? "同意" : taaApproveSugest.Text.Trim();
                    _currentApproveInfo.CheckOp = "1";
                    _manage.UpdateWuZhiCheck(_currentApproveInfo);

                    // 插入下一个审批记录.
                    WuzhiCheckInfo _nextApproveInfo = new WuzhiCheckInfo();
                    UserInfo _nextCheckUserInfo = new UserManage().GetUserByObjectID(ddlstApproveUser.SelectedValue);
                    _nextApproveInfo.ObjectId = Guid.NewGuid();
                    _nextApproveInfo.CheckerName = ddlstApproveUser.SelectedText;
                    _nextApproveInfo.CheckerId = new Guid(ddlstApproveUser.SelectedValue);
                    _nextApproveInfo.CheckrDept = _nextCheckUserInfo.Dept;
                    _nextApproveInfo.CheckDateTime = ACommonInfo.DBEmptyDate;
                    _nextApproveInfo.Checkstate = 0;
                    _nextApproveInfo.ApplyId = _currentApproveInfo.ApplyId;
                    _manage.AddNewWuZhiCheck(_nextApproveInfo);
                }
                #endregion

                #region 归档

                if (ddlstNext.SelectedText == "归档")
                {
                    // 修改申请单信息.
                    _applyInfo.State = 2;
                    _applyInfo.CurrentCheckerId = SystemUser.ObjectId;
                    result = _manage.UpdateWuZhi(_applyInfo);

                    // 更新现有审批记录.
                    _currentApproveInfo.Checkstate = 1;
                    _currentApproveInfo.Result = "0";
                    _currentApproveInfo.CheckDateTime = DateTime.Now;
                    _currentApproveInfo.CheckSugest = string.IsNullOrEmpty(taaApproveSugest.Text.Trim()) ? "同意" : taaApproveSugest.Text.Trim();
                    _currentApproveInfo.CheckOp = "1";
                    _manage.UpdateWuZhiCheck(_currentApproveInfo);

                    // 插入归档记录.
                    WuzhiCheckInfo _archiveApproveInfo = new WuzhiCheckInfo();
                    _archiveApproveInfo.ObjectId = Guid.NewGuid();
                    _archiveApproveInfo.CheckerId = SystemUser.ObjectId;
                    _archiveApproveInfo.CheckerName = SystemUser.Name;
                    _archiveApproveInfo.CheckDateTime = _currentApproveInfo.CheckDateTime.AddSeconds(1);
                    _archiveApproveInfo.Checkstate = 1;
                    _archiveApproveInfo.CheckOp = "3";
                    _archiveApproveInfo.ApplyId = _applyInfo.ObjectId;
                    _manage.AddNewWuZhiCheck(_archiveApproveInfo);
                }

                #endregion
            }
            if (result == -1)
            {
                Alert.Show(ddlstNext.SelectedText + "成功!");
                btnPass.Enabled = false;
                btnRefuse.Enabled = false;
                BindApproveHistory();
            }
            else
            {
                Alert.Show(ddlstNext.SelectedText + "失败!");
            }
        }

        /// <summary>
        /// 打回事件
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

            WuZhiManage _manage = new WuZhiManage();
            WuZhiInfo _applyInfo = _manage.GetWuZhiByObjectID(ApplyID);
            if (_applyInfo != null)
            {
                WuzhiCheckInfo _currentApproveInfo = _manage.GetWuZhiCheckByObjectID(ApproveID);

                //更新报销申请单信息.
                _applyInfo.State = 1;
                int result = _manage.UpdateWuZhi(_applyInfo);

                // 更新报销流程表信息.
                _currentApproveInfo.CheckDateTime = DateTime.Now;
                _currentApproveInfo.Checkstate = 1;
                _currentApproveInfo.Result = "1";
                _currentApproveInfo.CheckSugest = taaApproveSugest.Text.Trim();
                _currentApproveInfo.CheckOp = "2";
                _manage.UpdateWuZhiCheck(_currentApproveInfo);

                if (result == -1)
                {
                    Alert.Show("打回成功!");

                    // 重新设置按钮状态并刷新审批历史.
                    btnPass.Enabled = false;
                    btnRefuse.Enabled = false;
                    BindApproveHistory();
                }
                else
                {
                    Alert.Show("打回失败!");
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
                btnPass.Text = "归档";
            }
            else
            {
                ddlstApproveUser.Hidden = false;
                ddlstApproveUser.Required = true;
                ddlstApproveUser.ShowRedStar = true;
                ddlstApproveUser.Enabled = true;
                btnPass.Text = "通过";
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
                        e.Values[2] = "审批";
                        break;
                    case "2":
                        e.Values[2] = "打回修改";
                        break;
                    case "3":
                        e.Values[2] = "归档";
                        break;
                    default:
                        break;
                }
            }
        }
    }
}