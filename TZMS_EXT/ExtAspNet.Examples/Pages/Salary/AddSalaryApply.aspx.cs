using System;
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
    public partial class AddSalaryApply : BasePage
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
        /// 申请单ID
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
                        OperatorType = strOperatorType;
                        ApplyID = strApplyID;
                        lblName.Text = CurrentUser.Name;
                        lblApplyTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
                        lblBaseSalary.Text = CurrentUser.BaseSalary.ToString();
                        tabApproveHistory.Hidden = true;
                        BindNext();
                        ApproveUser();
                        break;
                    case "View":
                        OperatorType = strOperatorType;
                        ApplyID = strApplyID;
                        BindNext();
                        ApproveUser();
                        BindApplyInfo();
                        BindApproveHistory();
                        DisableAllControls();
                        break;
                    case "Edit":
                        OperatorType = strOperatorType;
                        ApplyID = strApplyID;
                        BindNext();
                        ApproveUser();
                        BindApplyInfo();
                        BindApproveHistory();
                        break;
                    default:
                        break;
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
            AddSalaryInfo _applyInfo = null;
            SalaryManage _manage = new SalaryManage();
            int result = 3;

            #region 添加申请单

            if (OperatorType == "Add")
            {
                // 创建报销单实例.

                _applyInfo = new AddSalaryInfo();
                _applyInfo.ObjectId = Guid.NewGuid();
                _applyInfo.UserId = CurrentUser.ObjectId;
                _applyInfo.Name = CurrentUser.Name;
                _applyInfo.Dept = CurrentUser.Dept;
                _applyInfo.BaseSalary = Convert.ToDecimal(lblBaseSalary.Text);
                _applyInfo.ExamSalary = Convert.ToDecimal(tbxExamSalary.Text.Trim());
                _applyInfo.Context = taaReason.Text.Trim();
                _applyInfo.State = 0;
                _applyInfo.CurrentCheckerId = new Guid(ddlstApproveUser.SelectedValue);
                _applyInfo.ApplyTime = DateTime.Now;

                // 插入新报销单.
                result = _manage.AddNewAddSalary(_applyInfo);

                // 插入起草记录到代帐费审批流程表.
                SalaryCheckInfo _approveInfo = new SalaryCheckInfo();
                _approveInfo.ObjectId = Guid.NewGuid();
                _approveInfo.CheckerId = CurrentUser.ObjectId;
                _approveInfo.CheckerName = CurrentUser.Name;
                _approveInfo.CheckrDept = CurrentUser.Dept;
                _approveInfo.CheckDateTime = DateTime.Now;
                _approveInfo.Checkstate = 1;
                _approveInfo.CheckOp = "0";
                _approveInfo.ApplyId = _applyInfo.ObjectId;
                _manage.AddNewSalaryCheck(_approveInfo);

                // 插入待审批记录到报销审批流程表.
                _approveInfo = new SalaryCheckInfo();
                UserInfo _approveUser = new UserManage().GetUserByObjectID(ddlstApproveUser.SelectedValue);
                _approveInfo.ObjectId = Guid.NewGuid();
                _approveInfo.CheckerId = _approveUser.ObjectId;
                _approveInfo.CheckerName = _approveUser.Name;
                _approveInfo.CheckrDept = _approveUser.Dept;
                _approveInfo.CheckDateTime = ACommonInfo.DBMAXDate;
                _approveInfo.Checkstate = 0;
                _approveInfo.ApplyId = _applyInfo.ObjectId;

                _manage.AddNewSalaryCheck(_approveInfo);

            }
            #endregion

            #region 编辑申请单

            if (OperatorType == "Edit")
            {
                _applyInfo = _manage.GetAddSalaryByObjectID(ApplyID);
                if (_applyInfo != null)
                {
                    // 更新申请单中的数据.
                    _applyInfo.ExamSalary = Convert.ToDecimal(tbxExamSalary.Text.Trim());
                    _applyInfo.State = 0;
                    _applyInfo.CurrentCheckerId = new Guid(ddlstApproveUser.SelectedValue);

                    result = _manage.UpdateAddSalary(_applyInfo);

                    // 插入待审批记录到报销审批流程表.
                    SalaryCheckInfo _approveInfo = new SalaryCheckInfo();
                    UserInfo _approveUser = new UserManage().GetUserByObjectID(ddlstApproveUser.SelectedValue);
                    _approveInfo.ObjectId = Guid.NewGuid();
                    _approveInfo.CheckerId = _approveUser.ObjectId;
                    _approveInfo.CheckerName = _approveUser.Name;
                    _approveInfo.CheckrDept = _approveUser.Dept;
                    _approveInfo.CheckDateTime = ACommonInfo.DBMAXDate;
                    _approveInfo.Checkstate = 0;
                    _approveInfo.ApplyId = _applyInfo.ObjectId;

                    _manage.AddNewSalaryCheck(_approveInfo);
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
            SalaryManage _manage = new SalaryManage();
            AddSalaryInfo _info = _manage.GetAddSalaryByObjectID(ApplyID);
            if (_info != null)
            {
                lblName.Text = _info.Name;
                lblApplyTime.Text = _info.ApplyTime.ToString("yyyy-MM-dd HH:mm");
                lblBaseSalary.Text = _info.BaseSalary.ToString();
                tbxExamSalary.Text = _info.ExamSalary.ToString();
                taaReason.Text = _info.Context;

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
            tbxExamSalary.Required = false;
            tbxExamSalary.ShowRedStar = false;
            tbxExamSalary.Enabled = false;
            taaReason.Required = false;
            taaReason.ShowRedStar = false;
            taaReason.Enabled = false;
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
            strCondition.Append(" and Checkstate <> 0");
            List<SalaryCheckInfo> lstBaoxiaoCheckInfo = new SalaryManage().GetSalaryCheckByCondition(strCondition.ToString());

            lstBaoxiaoCheckInfo.Sort(delegate(SalaryCheckInfo x, SalaryCheckInfo y) { return DateTime.Compare(y.CheckDateTime, x.CheckDateTime); });

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
        /// 审批历史关闭事件
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