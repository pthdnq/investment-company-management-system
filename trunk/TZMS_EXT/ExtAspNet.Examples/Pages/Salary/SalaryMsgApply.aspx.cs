using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.TZMS.Model;
using ExtAspNet;
using com.TZMS.Business;
using System.Text;

namespace TZMS.Web
{
    public partial class SalaryMsgApply : BasePage
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
            string strOperatorType = Request.QueryString["Type"];
            string strApplyID = Request.QueryString["ID"];

            switch (strOperatorType)
            {
                case "Add":
                    OperatorType = strOperatorType;
                    ApplyID = strApplyID;
                    BindNext();
                    ApproveUser();
                    BindWorkerSalaryMsgGrid();
                    BindApproveHistory();
                    break;
                case "View":
                    OperatorType = strOperatorType;
                    ApplyID = strApplyID;
                    BindNext();
                    ApproveUser();
                    BindApplyInfo();
                    BindWorkerSalaryMsgGrid();
                    BindApproveHistory();
                    DisableAllControls();
                    break;
                default:
                    break;
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
        private void ApproveUser()
        {
            foreach (UserInfo user in CurrentChecker)
            {
                ddlstApproveUser.Items.Add(new ExtAspNet.ListItem(user.Name, user.ObjectId.ToString()));
            }
        }

        /// <summary>
        /// 绑定报销单申请信息
        /// </summary>
        private void BindApplyInfo()
        {
            SalaryManage _manage = new SalaryManage();

            // 查找最早的审批记录.
            List<SalaryCheckInfo> lstApprove = _manage.GetSalaryCheckByCondition(" ApplyID = '" + ApplyID + "' and CheckOp <> '0'");
            if (lstApprove.Count == 1)
            {
                ddlstApproveUser.SelectedValue = lstApprove[0].CheckerId.ToString();
            }
            else
            {
                lstApprove.Sort(delegate(SalaryCheckInfo x, SalaryCheckInfo y) { return DateTime.Compare(x.CheckDateTime, y.CheckDateTime); });
                foreach (var item in lstApprove)
                {
                    if (DateTime.Compare(item.CheckDateTime, ACommonInfo.DBEmptyDate) != 0)
                    {
                        ddlstApproveUser.SelectedValue = item.CheckerId.ToString();
                        break;
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

            if (lstBaoxiaoCheckInfo.Count == 0)
            {
                tabApproveHistory.Hidden = true;
            }

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
        /// 保存
        /// </summary>
        private void SaveApply()
        {
            if (string.IsNullOrEmpty(OperatorType) || string.IsNullOrEmpty(ApplyID))
                return;

            SalaryManage _manage = new SalaryManage();
            UserManage _userManage = new UserManage();
            SalaryMsgInfo _applyInfo = _manage.GetSalaryMsgByObjectID(ApplyID);
            int result = 3;
            if (_applyInfo != null)
            {
                UserInfo _approveUser = _userManage.GetUserByObjectID(ddlstApproveUser.SelectedValue);
                if (_approveUser != null)
                {
                    // 更新薪资信息.
                    _applyInfo.State = 0;
                    _applyInfo.CreateTime = DateTime.Now;
                    _applyInfo.CurrentCheckerId = _approveUser.ObjectId;

                    result = _manage.UpdateSalaryMsg(_applyInfo);

                    if (((List<SalaryCheckInfo>)gridApproveHistory.DataSource).Count == 0)
                    {

                        // 插入起草记录.
                        SalaryCheckInfo _draftCheckInfo = new SalaryCheckInfo();
                        _draftCheckInfo.ObjectId = Guid.NewGuid();
                        _draftCheckInfo.CheckerId = CurrentUser.ObjectId;
                        _draftCheckInfo.CheckerName = CurrentUser.Name;
                        _draftCheckInfo.CheckrDept = CurrentUser.Dept;
                        _draftCheckInfo.CheckDateTime = DateTime.Now;
                        _draftCheckInfo.Checkstate = 0;
                        _draftCheckInfo.CheckOp = "0";
                        _draftCheckInfo.ApplyId = _applyInfo.ObjectId;

                        _manage.AddNewSalaryCheck(_draftCheckInfo);
                    }

                    // 插入待审批记录.
                    SalaryCheckInfo _nextCheckInfo = new SalaryCheckInfo();
                    _nextCheckInfo.ObjectId = Guid.NewGuid();
                    _nextCheckInfo.CheckerId = _approveUser.ObjectId;
                    _nextCheckInfo.CheckerName = _approveUser.Name;
                    _nextCheckInfo.CheckrDept = _approveUser.Dept;
                    _nextCheckInfo.CheckDateTime = ACommonInfo.DBMAXDate;
                    _nextCheckInfo.Checkstate = 0;
                    _nextCheckInfo.ApplyId = _applyInfo.ObjectId;

                    _manage.AddNewSalaryCheck(_nextCheckInfo);
                }
            }

            if (result == -1)
            {
                CheckMsg(ddlstApproveUser.SelectedValue.ToString(), ddlstApproveUser.SelectedText, "薪资信息审批（来自薪资管理）");

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
            SaveApply();
        }

        /// <summary>
        /// 薪资信息数据行绑定事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridWorkerSalaryMsg_RowDataBound(object sender, ExtAspNet.GridRowEventArgs e)
        {

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