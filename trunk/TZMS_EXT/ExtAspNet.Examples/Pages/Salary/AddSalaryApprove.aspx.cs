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
    public partial class AddSalaryApprove : BasePage
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
                if (roleType == RoleType.GXGD)
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
        /// 绑定审批历史
        /// </summary>
        private void BindApproveHistory()
        {
            if (string.IsNullOrEmpty(ApplyID))
                return;
            // 获取数据.
            StringBuilder strCondition = new StringBuilder();
            strCondition.Append(" ApplyID = '" + ApplyID + "'");
            strCondition.Append(" and Checkstate <> 0");
            List<SalaryCheckInfo> lstBaoxiaoCheckInfo = new SalaryManage().GetSalaryCheckByCondition(strCondition.ToString());

            lstBaoxiaoCheckInfo.Sort(delegate(SalaryCheckInfo x, SalaryCheckInfo y) { return DateTime.Compare(y.CheckDateTime, x.CheckDateTime); });

            // 绑定列表.
            gridApproveHistory.RecordCount = lstBaoxiaoCheckInfo.Count;
            this.gridApproveHistory.DataSource = lstBaoxiaoCheckInfo;
            this.gridApproveHistory.DataBind();
        }

        /// <summary>
        /// 绑定请求信息
        /// </summary>
        private void BindApplyInfo()
        {
            if (string.IsNullOrEmpty(ApplyID))
                return;

            AddSalaryInfo _info = new SalaryManage().GetAddSalaryByObjectID(ApplyID);
            if (_info != null)
            {
                lblName.Text = _info.Name;
                lblApplyTime.Text = _info.ApplyTime.ToString("yyyy-MM-dd HH:mm");
                lblBaseSalary.Text = _info.BaseSalary.ToString();
                lblExamSalary.Text = _info.ExamSalary.ToString();
                taaReason.Text = _info.Context;
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
            if (ApproveID == null || ApplyID == null)
                return;
            int result = 3;
            SalaryManage _manage = new SalaryManage();
            UserManage _userManage = new UserManage();
            AddSalaryInfo _applyInfo = _manage.GetAddSalaryByObjectID(ApplyID);
            SalaryCheckInfo _currentApproveInfo = _manage.GetSalaryCheckByObjectID(ApproveID);
            if (_applyInfo != null && _currentApproveInfo != null)
            {
                #region 审批

                if (ddlstNext.SelectedText == "审批")
                {
                    // 更新报销申请单记录.
                    _applyInfo.CurrentCheckerId = new Guid(ddlstApproveUser.SelectedValue);
                    _applyInfo.OtherSalary = Convert.ToDecimal(tbxOtherSalary.Text.Trim());
                    result = _manage.UpdateAddSalary(_applyInfo);

                    // 更新现有审批记录.
                    _currentApproveInfo.Checkstate = 1;
                    _currentApproveInfo.Result = "0";
                    _currentApproveInfo.CheckDateTime = DateTime.Now;
                    _currentApproveInfo.CheckSugest = string.IsNullOrEmpty(taaApproveSugest.Text.Trim()) ? "同意" : taaApproveSugest.Text.Trim();
                    _currentApproveInfo.CheckOp = "1";
                    _manage.UpdateSalaryCheck(_currentApproveInfo);

                    // 插入下一个审批记录.
                    SalaryCheckInfo _nextApproveInfo = new SalaryCheckInfo();
                    UserInfo _nextCheckUserInfo = new UserManage().GetUserByObjectID(ddlstApproveUser.SelectedValue);
                    _nextApproveInfo.ObjectId = Guid.NewGuid();
                    _nextApproveInfo.CheckerName = ddlstApproveUser.SelectedText;
                    _nextApproveInfo.CheckerId = new Guid(ddlstApproveUser.SelectedValue);
                    _nextApproveInfo.CheckrDept = _nextCheckUserInfo.Dept;
                    _nextApproveInfo.CheckDateTime = ACommonInfo.DBMAXDate;
                    _nextApproveInfo.Checkstate = 0;
                    _nextApproveInfo.ApplyId = _currentApproveInfo.ApplyId;
                    _manage.AddNewSalaryCheck(_nextApproveInfo);
                }
                #endregion

                #region 归档

                if (ddlstNext.SelectedText == "同意并归档")
                {
                    // 修改申请单信息.
                    _applyInfo.State = 2;
                    _applyInfo.OtherSalary = Convert.ToDecimal(tbxOtherSalary.Text.Trim());
                    _applyInfo.CurrentCheckerId = SystemUser.ObjectId;
                    result = _manage.UpdateAddSalary(_applyInfo);

                    // 更新员工信息表中的基本工资.
                    UserInfo _applyUser = _userManage.GetUserByObjectID(_applyInfo.UserId.ToString());
                    _applyUser.BaseSalary += _applyInfo.OtherSalary;
                    _userManage.UpdateUser(_applyUser);

                    // 更新现有审批记录.
                    _currentApproveInfo.Checkstate = 1;
                    _currentApproveInfo.Result = "0";
                    _currentApproveInfo.CheckDateTime = DateTime.Now;
                    _currentApproveInfo.CheckSugest = string.IsNullOrEmpty(taaApproveSugest.Text.Trim()) ? "同意" : taaApproveSugest.Text.Trim();
                    _currentApproveInfo.CheckOp = "1";
                    _manage.UpdateSalaryCheck(_currentApproveInfo);

                    // 插入归档记录.
                    SalaryCheckInfo _archiveApproveInfo = new SalaryCheckInfo();
                    _archiveApproveInfo.ObjectId = Guid.NewGuid();
                    _archiveApproveInfo.CheckerId = SystemUser.ObjectId;
                    _archiveApproveInfo.CheckerName = SystemUser.Name;
                    _archiveApproveInfo.CheckDateTime = _currentApproveInfo.CheckDateTime.AddSeconds(1);
                    _archiveApproveInfo.Checkstate = 1;
                    _archiveApproveInfo.CheckOp = "3";
                    _archiveApproveInfo.ApplyId = _applyInfo.ObjectId;
                    _manage.AddNewSalaryCheck(_archiveApproveInfo);
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

            SalaryManage _manage = new SalaryManage();
            SalaryMsgInfo _applyInfo = _manage.GetSalaryMsgByObjectID(ApplyID);
            if (_applyInfo != null)
            {
                SalaryCheckInfo _currentApproveInfo = _manage.GetSalaryCheckByObjectID(ApproveID);

                //更新报销申请单信息.
                _applyInfo.State = 1;
                int result = _manage.UpdateSalaryMsg(_applyInfo);

                // 更新报销流程表信息.
                _currentApproveInfo.CheckDateTime = DateTime.Now;
                _currentApproveInfo.Checkstate = 1;
                _currentApproveInfo.Result = "1";
                _currentApproveInfo.CheckSugest = taaApproveSugest.Text.Trim();
                _currentApproveInfo.CheckOp = "2";
                _manage.UpdateSalaryCheck(_currentApproveInfo);

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