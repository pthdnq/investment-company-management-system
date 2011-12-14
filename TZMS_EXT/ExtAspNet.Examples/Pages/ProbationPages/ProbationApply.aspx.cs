using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.TZMS.Model;
using com.TZMS.Business;
using System.Text;
using ExtAspNet;

namespace TZMS.Web
{
    public partial class ProbationApply : BasePage
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
        /// 转正申请ID
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
                ProbationApplyInfo _applyInfo = new ProbationManage().GetApplyByUserID(CurrentUser.ObjectId.ToString());
                if (_applyInfo == null)
                {
                    OperatorType = "Add";
                    lblName.Text = CurrentUser.Name;
                    lblAppDate.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
                    lblEntryDate.Text = CurrentUser.EntryDate.ToString("yyyy-MM-dd");
                    tabApproveHistory.Hidden = true;
                    BindNext();
                    BindApproveUser();
                }
                else
                {
                    ApplyID = _applyInfo.ObjectID.ToString();
                    switch (_applyInfo.State)
                    {
                        case 0:
                        case 1:
                            OperatorType = "View";
                            BindNext();
                            BindApproveUser();
                            BindProbationApplyInfo();
                            BindApproveHistory();
                            DisableAllControls();
                            break;
                        case 2:
                            OperatorType = "Edit";
                            BindNext();
                            BindApproveUser();
                            BindProbationApplyInfo();
                            BindApproveHistory();
                            break;
                        default:
                            break;
                    }
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
        /// 绑定审批人
        /// </summary>
        private void BindApproveUser()
        {
            foreach (UserInfo user in CurrentChecker)
            {
                ddlstApproveUser.Items.Add(new ExtAspNet.ListItem(user.Name, user.ObjectId.ToString()));
            }

            ddlstApproveUser.SelectedIndex = 0;
        }

        /// <summary>
        /// 绑定转正申请信息
        /// </summary>
        private void BindProbationApplyInfo()
        {
            ProbationManage _manage = new ProbationManage();
            ProbationApplyInfo _info = _manage.GetApplyByObjectID(ApplyID);
            if (_info != null)
            {
                lblName.Text = _info.UserName;
                lblAppDate.Text = _info.ApplyTime.ToString("yyyy-MM-dd HH:mm");
                lblEntryDate.Text = _info.UserEntryDate.ToString("yyyy-MM-dd");
                taaSument.Text = _info.Sument;
                taaOther.Text = _info.Other;

                // 查找最早的审批记录.
                List<ProbationApproveInfo> lstApprove = _manage.GetApproveByCondition(" ApplyID = '" + ApplyID + "' and ApproveOp <> 0");
                if (lstApprove.Count == 1)
                {
                    ddlstApproveUser.SelectedValue = lstApprove[0].ApproverID.ToString();
                }
                else
                {
                    lstApprove.Sort(delegate(ProbationApproveInfo x, ProbationApproveInfo y) { return DateTime.Compare(x.ApproveTime, y.ApproveTime); });
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
            strCondition.Append("ApplyID = '" + ApplyID + "'");
            //strCondition.Append(" and (ApproveState <> 0 or  ApproveOp = 0)");
            List<ProbationApproveInfo> lstApprove = new ProbationManage().GetApproveByCondition(strCondition.ToString());

            lstApprove.Sort(delegate(ProbationApproveInfo x, ProbationApproveInfo y)
            {

                return DateTime.Compare(y.ApproveTime, x.ApproveTime);
            });

            // 绑定列表.
            gridApproveHistory.RecordCount = lstApprove.Count;
            this.gridApproveHistory.DataSource = lstApprove;
            this.gridApproveHistory.DataBind();
        }

        #endregion

        #region 页面事件

        /// <summary>
        /// 提交事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (OperatorType == null)
                return;

            ProbationManage _manage = new ProbationManage();
            ProbationApplyInfo _applyInfo = null;
            int result;

            if (OperatorType == "Add")
            {
                // 插入申请单信息.
                _applyInfo = new ProbationApplyInfo();
                _applyInfo.ObjectID = Guid.NewGuid();
                _applyInfo.UserName = CurrentUser.Name;
                _applyInfo.UserJobNo = CurrentUser.JobNo;
                _applyInfo.UserID = CurrentUser.ObjectId;
                _applyInfo.UserAccountNo = CurrentUser.AccountNo;
                _applyInfo.UserDept = CurrentUser.Dept;
                _applyInfo.Sument = taaSument.Text.Trim();
                _applyInfo.Other = taaOther.Text.Trim();
                _applyInfo.ApplyTime = DateTime.Now;
                _applyInfo.CurrentApproverID = new Guid(ddlstApproveUser.SelectedValue);
                _applyInfo.State = 0;
                _applyInfo.IsDelete = false;
                _applyInfo.UserEntryDate = CurrentUser.EntryDate;

                result = _manage.AddNewProbationApply(_applyInfo);

                // 插入起草信息.
                ProbationApproveInfo _draftInfo = new ProbationApproveInfo();
                _draftInfo.ObjectID = Guid.NewGuid();
                _draftInfo.ApproverID = _applyInfo.UserID;
                _draftInfo.ApproverName = _applyInfo.UserName;
                _draftInfo.ApproverDept = _applyInfo.UserDept;
                _draftInfo.ApproveTime = _applyInfo.ApplyTime;
                _draftInfo.ApproveState = 0;
                _draftInfo.ApproveOp = 0;
                _draftInfo.ApplyID = _applyInfo.ObjectID;

                _manage.AddNewProbationApprove(_draftInfo);

                // 插入审批信息.
                ProbationApproveInfo _approveInfo = new ProbationApproveInfo();
                UserInfo _approveUser = new UserManage().GetUserByObjectID(ddlstApproveUser.SelectedValue);
                if (_approveUser != null)
                {
                    _approveInfo.ObjectID = Guid.NewGuid();
                    _approveInfo.ApproverID = _approveUser.ObjectId;
                    _approveInfo.ApproverName = _approveUser.Name;
                    _approveInfo.ApproverDept = _approveUser.Dept;
                    _approveInfo.ApproveState = 0;
                    _approveInfo.ApplyID = _applyInfo.ObjectID;

                    _manage.AddNewProbationApprove(_approveInfo);
                }

                if (result == -1)
                {
                    Alert.Show("转正申请单提交成功!");
                    ApplyID = _applyInfo.ObjectID.ToString();
                    tabApproveHistory.Hidden = false;
                    BindApproveHistory();
                    DisableAllControls();
                }
                else
                {
                    Alert.Show("转正申请单添加失败!");
                }
            }

            if (OperatorType == "Edit")
            {
                _applyInfo = _manage.GetApplyByObjectID(ApplyID);
                if (_applyInfo != null)
                {
                    // 更新申请单信息.
                    _applyInfo.Sument = taaSument.Text.Trim();
                    _applyInfo.Other = taaOther.Text.Trim();
                    _applyInfo.ApplyTime = DateTime.Now;
                    _applyInfo.CurrentApproverID = new Guid(ddlstApproveUser.SelectedValue);
                    _applyInfo.State = 0;
                    _applyInfo.IsDelete = false;

                    result = _manage.UpdateApply(_applyInfo);

                    // 重新插入审批信息.
                    ProbationApproveInfo _approveInfo = new ProbationApproveInfo();
                    UserInfo _approveUser = new UserManage().GetUserByObjectID(ddlstApproveUser.SelectedValue);
                    if (_approveUser != null)
                    {
                        _approveInfo.ObjectID = Guid.NewGuid();
                        _approveInfo.ApproverID = _approveUser.ObjectId;
                        _approveInfo.ApproverName = _approveUser.Name;
                        _approveInfo.ApproverDept = _approveUser.Dept;
                        _approveInfo.ApproveState = 0;
                        _approveInfo.ApplyID = _applyInfo.ObjectID;

                        _manage.AddNewProbationApprove(_approveInfo);
                    }

                    if (result == -1)
                    {
                        Alert.Show("转正申请单提交成功!");
                        tabApproveHistory.Hidden = false;
                        BindApproveHistory();
                        DisableAllControls();
                    }
                    else
                    {
                        Alert.Show("转正申请单添加失败!");
                    }
                }
            }
        }

        /// <summary>
        /// 审批历史绑定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridApproveHistory_RowDataBound(object sender, ExtAspNet.GridRowEventArgs e)
        {
            if (e.DataItem != null)
            {
                DateTime approveDate = DateTime.Parse(e.Values[1].ToString());
                if (DateTime.Compare(approveDate, ACommonInfo.DBMAXDate) == 0)
                {
                    e.Values[1] = "";
                    e.Values[2] = "审批中...";

                }
                else
                {
                    e.Values[1] = approveDate.ToString("yyyy-MM-dd HH:mm");
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
        }

        #endregion
    }
}