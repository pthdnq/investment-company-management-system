using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using com.TZMS.Model;
using com.TZMS.Business;
using ExtAspNet;

namespace TZMS.Web
{
    public partial class BaoXiaoPinZhengApply : BasePage
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
                            ApplyID = strApplyID;
                            lblName.Text = CurrentUser.Name;
                            lblApplyTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
                            tabApproveHistory.Hidden = true;
                            // 绑定下一步.
                            BindNext();
                            // 绑定审批人.
                            ApproveUser();
                            // 绑定报销信息.
                            BindBaoxiaoInfo();
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
                            // 绑定申请单信息.
                            BindApplyInfo();
                            // 绑定审批历史.
                            BindApproveHistory();
                        }
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
            if (string.IsNullOrEmpty(OperatorType) || string.IsNullOrEmpty(ApplyID))
                return;

            BaoxiaoManage _manage = new BaoxiaoManage();
            BaoXiaoPinZhengApplyInfo _applyInfo = null;
            int result = 3;

            _applyInfo = _manage.GetPinZhengApplyByObjectID(ApplyID);
            if (_applyInfo != null)
            {
                // 更新申请单中的数据.

                _applyInfo.UserID = CurrentUser.ObjectId;
                _applyInfo.UserName = CurrentUser.Name;
                _applyInfo.UserJobNo = CurrentUser.JobNo;
                _applyInfo.UserAccountNo = CurrentUser.AccountNo;
                _applyInfo.UserDept = CurrentUser.Dept;
                _applyInfo.Title = tbxTitle.Text.Trim();
                _applyInfo.Report = taaReport.Text.Trim();
                _applyInfo.ApplyTime = DateTime.Now;
                _applyInfo.State = 0;
                _applyInfo.CurrentApproverID = new Guid(ddlstApproveUser.SelectedValue);

                result = _manage.UpdatePinZhengApply(_applyInfo);

                // 插入起草信息.
                if (OperatorType == "Add")
                {
                    BaoXiaoPinZhengApproveInfo _draftApproveInfo = new BaoXiaoPinZhengApproveInfo();
                    _draftApproveInfo.ObjectID = Guid.NewGuid();
                    _draftApproveInfo.ApproverID = CurrentUser.ObjectId;
                    _draftApproveInfo.ApproverName = CurrentUser.Name;
                    _draftApproveInfo.ApproverDept = CurrentUser.Dept;
                    _draftApproveInfo.ApproveTime = DateTime.Now;
                    _draftApproveInfo.ApproveState = 1;
                    _draftApproveInfo.ApproveOp = 0;
                    _draftApproveInfo.ApplyID = _applyInfo.ObjectID;
                    _manage.AddNewPinZhengApprove(_draftApproveInfo);
                }

                // 插入待审批记录到报销审批流程表.
                BaoXiaoPinZhengApproveInfo _approveInfo = new BaoXiaoPinZhengApproveInfo();
                UserInfo _approveUser = new UserManage().GetUserByObjectID(ddlstApproveUser.SelectedValue);
                _approveInfo.ObjectID = Guid.NewGuid();
                _approveInfo.ApproverID = _approveUser.ObjectId;
                _approveInfo.ApproverName = _approveUser.Name;
                _approveInfo.ApproverDept = _approveUser.Dept;
                _approveInfo.ApproveTime = ACommonInfo.DBMAXDate;
                _approveInfo.ApproveState = 0;
                _approveInfo.ApplyID = _applyInfo.ObjectID;

                _manage.AddNewPinZhengApprove(_approveInfo);
            }

            if (result == -1)
            {
                this.btnClose_Click(null, null);
            }
            else
            {
                Alert.Show("凭证提交失败!");
            }

        }

        /// <summary>
        /// 绑定报销单申请信息
        /// </summary>
        private void BindApplyInfo()
        {
            if (string.IsNullOrEmpty(ApplyID))
                return;

            BaoxiaoManage _manage = new BaoxiaoManage();
            BaoXiaoPinZhengApplyInfo _applyInfo = _manage.GetPinZhengApplyByObjectID(ApplyID);
            if (_applyInfo != null)
            {
                // 绑定申请单信息.
                lblName.Text = _applyInfo.UserName;
                lblApplyTime.Text = _applyInfo.ApplyTime.ToString("yyyy-MM-dd HH:mm");
                tbxTitle.Text = _applyInfo.Title;
                taaReport.Text = _applyInfo.Report;

                BindBaoxiaoInfo();

                // 查找最早的审批记录.
                List<BaoXiaoPinZhengApproveInfo> lstApprove = _manage.GetPinZhengApproveByCondition(" ApplyID = '" + ApplyID + "' and ApproveOp <> 0");
                if (lstApprove.Count == 1)
                {
                    ddlstApproveUser.SelectedValue = lstApprove[0].ApproverID.ToString();
                }
                else
                {
                    lstApprove.Sort(delegate(BaoXiaoPinZhengApproveInfo x, BaoXiaoPinZhengApproveInfo y) { return DateTime.Compare(x.ApproveTime, y.ApproveTime); });
                    foreach (var item in lstApprove)
                    {
                        if (DateTime.Compare(item.ApproveTime, ACommonInfo.DBMAXDate) != 0)
                        {
                            ddlstApproveUser.SelectedValue = item.ApproverID.ToString();
                            break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 绑定报销信息
        /// </summary>
        private void BindBaoxiaoInfo()
        {
            if (string.IsNullOrEmpty(ApplyID))
                return;

            BaoxiaoManage _manage = new BaoxiaoManage();
            BaoXiaoPinZhengApplyInfo _applyInfo = _manage.GetPinZhengApplyByObjectID(ApplyID);
            if (_applyInfo != null)
            {
                // 绑定报销信息.
                BaoxiaoInfo _baoxiaoInfo = _manage.GetBaoxiaoByObjectID(_applyInfo.BaoXiaoID.ToString());
                if (_baoxiaoInfo != null)
                {
                    lblBaoXiaoName.Text = _baoxiaoInfo.UserName;
                    lblBaoXiaoApplyTime.Text = _baoxiaoInfo.ApplyTime.ToString("yyyy-MM-dd HH:mm");
                    lblStartTime.Text = _baoxiaoInfo.StartTime.ToString("yyyy-MM-dd");
                    lblEndTime.Text = _baoxiaoInfo.EndTime.ToString("yyyy-MM-dd");
                    lblMoney.Text = _baoxiaoInfo.Money.ToString() + "元";
                    taaSument.Text = _baoxiaoInfo.Sument;
                    taaOther.Text = _baoxiaoInfo.Other;
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
            tbxTitle.Required = false;
            tbxTitle.ShowRedStar = false;
            tbxTitle.Enabled = false;
            taaReport.Required = false;
            taaReport.ShowRedStar = false;
            taaReport.Enabled = false;
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
            List<BaoXiaoPinZhengApproveInfo> lstBaoxiaoCheckInfo = new BaoxiaoManage().GetPinZhengApproveByCondition(strCondition.ToString());

            lstBaoxiaoCheckInfo.Sort(delegate(BaoXiaoPinZhengApproveInfo x, BaoXiaoPinZhengApproveInfo y) { return DateTime.Compare(y.ApproveTime, x.ApproveTime); });

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