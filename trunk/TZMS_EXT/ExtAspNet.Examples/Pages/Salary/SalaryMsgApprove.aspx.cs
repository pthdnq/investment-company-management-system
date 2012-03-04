﻿using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.TZMS.Model;
using com.TZMS.Business;
using ExtAspNet;
using System.Text;

namespace TZMS.Web
{
    public partial class SalaryMsgApprove : BasePage
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
                BindWorkerSalaryMsgGrid();
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
                if (roleType == RoleType.XZGLGD)
                {
                    ddlstNext.Items.Add(new ExtAspNet.ListItem("同意并发放", "1"));
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
            if (ApplyID == null)
                return;
            // 获取数据.
            StringBuilder strCondition = new StringBuilder();
            strCondition.Append(" ApplyID = '" + ApplyID + "'");
            strCondition.Append(" and  (Checkstate <> 0 or (Checkstate = 0 and CheckOp = '0'))");
            List<SalaryCheckInfo> lstBaoxiaoCheckInfo = new SalaryManage().GetSalaryCheckByCondition(strCondition.ToString());

            lstBaoxiaoCheckInfo.Sort(delegate(SalaryCheckInfo x, SalaryCheckInfo y) { return DateTime.Compare(y.CheckDateTime, x.CheckDateTime); });

            // 绑定列表.
            gridApproveHistory.RecordCount = lstBaoxiaoCheckInfo.Count;
            this.gridApproveHistory.DataSource = lstBaoxiaoCheckInfo;
            this.gridApproveHistory.DataBind();
        }

        /// <summary>
        /// 绑定员工薪资信息列表
        /// </summary>
        private void BindWorkerSalaryMsgGrid()
        {
            if (string.IsNullOrEmpty(ApplyID))
                return;

            List<WorkerSalaryMsgInfo> lstWorkerSalaryMsgInfo = new SalaryManage().GetWorkerSalaryMsgByCondition(" SalaryMsgID = '" + ApplyID + "' order by Dept desc");
            gridWorkerSalaryMsg.RecordCount = lstWorkerSalaryMsgInfo.Count;
            this.gridWorkerSalaryMsg.DataSource = lstWorkerSalaryMsgInfo;
            this.gridWorkerSalaryMsg.DataBind();
        }

        /// <summary>
        /// 设置面板状态
        /// </summary>
        private void SetPanelState()
        {
            if (string.IsNullOrEmpty(ApproveID))
                return;
            SalaryManage _manage = new SalaryManage();
            SalaryCheckInfo _approveInfo = _manage.GetSalaryCheckByObjectID(ApproveID);
            if (_approveInfo != null)
            {
                if (_approveInfo.Checkstate == 1)
                {
                    mainForm2.Hidden = true;
                    btnPass.Hidden = true;
                    btnRefuse.Hidden = true;
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
            if (ApproveID == null || ApplyID == null)
                return;
            int result = 3;
            SalaryManage _manage = new SalaryManage();
            UserManage _userManage = new UserManage();
            SalaryMsgInfo _applyInfo = _manage.GetSalaryMsgByObjectID(ApplyID);
            SalaryCheckInfo _currentApproveInfo = _manage.GetSalaryCheckByObjectID(ApproveID);
            if (_applyInfo != null && _currentApproveInfo != null)
            {
                #region 审批

                if (ddlstNext.SelectedText == "审批")
                {
                    // 更新报销申请单记录.
                    _applyInfo.CurrentCheckerId = new Guid(ddlstApproveUser.SelectedValue);
                    result = _manage.UpdateSalaryMsg(_applyInfo);

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

                if (ddlstNext.SelectedText == "同意并发放")
                {
                    // 修改申请单信息.
                    _applyInfo.State = 2;
                    _applyInfo.CurrentCheckerId = SystemUser.ObjectId;

                    // 更新员工信息表中的基本工资.
                    List<WorkerSalaryMsgInfo> lstWorkerSalaryIMsgInfo = _manage.GetWorkerSalaryMsgByCondition(" SalaryMsgID = '" + _applyInfo.ObjectId.ToString() + "'");
                    //UserInfo _tempUserInfo = null;
                    foreach (WorkerSalaryMsgInfo item in lstWorkerSalaryIMsgInfo)
                    {
                        //_tempUserInfo = _userManage.GetUserByObjectID(item.UserId.ToString());
                        //if (_tempUserInfo != null)
                        //{
                        //    _tempUserInfo.BaseSalary = item.BaseSalary;
                        //    _userManage.UpdateUser(_tempUserInfo);
                        //}
                        _applyInfo.SumMoney += Convert.ToDecimal(item.Sfgz);
                    }

                    result = _manage.UpdateSalaryMsg(_applyInfo);

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
                if (ddlstNext.SelectedText == "审批")
                {
                    CheckMsg(ddlstApproveUser.SelectedValue.ToString(), ddlstApproveUser.SelectedText, "薪资信息审批（来自薪资管理）");
                }
                else
                {
                    ResultMsgMore(_applyInfo.CreaterId.ToString(), _applyInfo.Name, "您有1条薪资信息申请（来自薪资管理），已通过审核并归档！");
                }
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
                    ResultMsgMore(_applyInfo.CreaterId.ToString(), _applyInfo.Name, "您有1条薪资信息申请（来自薪资管理），未通过审核！");

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
                btnPass.Text = "同意并发放";
                btnPass.ConfirmText = "您确认同意并发放吗?";
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
        /// 员工薪资绑定事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridWorkerSalaryMsg_RowDataBound(object sender, ExtAspNet.GridRowEventArgs e)
        {

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