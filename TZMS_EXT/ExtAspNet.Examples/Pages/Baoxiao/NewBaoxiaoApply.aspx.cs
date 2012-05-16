using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.TZMS.Model;
using ExtAspNet;
using com.TZMS.Business;
using System.Text;
using System.Data;

namespace TZMS.Web
{
    public partial class NewBaoxiaoApply : BasePage
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
        public string BaoxiaoObjectID
        {
            get
            {
                if (ViewState["BaoxiaoObjectID"] == null)
                {
                    return null;
                }

                return ViewState["BaoxiaoObjectID"].ToString();
            }
            set
            {
                ViewState["BaoxiaoObjectID"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string strOperatorType = Request.QueryString["Type"];
                string strBaoxiaoID = Request.QueryString["ID"];

                switch (strOperatorType)
                {
                    case "Add":
                        {
                            OperatorType = strOperatorType;

                            lblName.Text = CurrentUser.Name;
                            lblAppDate.Text = DateTime.Now.ToString("yyyy-MM-dd hh:mm");

                            dpkStartTime.SelectedDate = DateTime.Now;
                            dpkEndTime.SelectedDate = DateTime.Now;

                            tabApproveHistory.Hidden = true;
                            // 绑定下一步.
                            BindNext();
                            // 绑定审批人.
                            ApproveUser();
                        }
                        break;
                    case "View":
                        {
                            OperatorType = strOperatorType;
                            BaoxiaoObjectID = strBaoxiaoID;

                            // 绑定下一步.
                            BindNext();
                            // 绑定审批人.
                            ApproveUser();
                            // 绑定申请单信息.
                            BindBaoxiaoInfo();
                            // 绑定审批历史.
                            BindApproveHistory();
                            // 禁用所有控件.
                            DisableAllControls();
                        }
                        break;
                    case "Edit":
                        {
                            OperatorType = strOperatorType;
                            BaoxiaoObjectID = strBaoxiaoID;

                            // 绑定下一步.
                            BindNext();
                            // 绑定审批人.
                            ApproveUser();
                            // 绑定申请单信息.
                            BindBaoxiaoInfo();
                            // 绑定审批历史.
                            BindApproveHistory();
                        }
                        break;
                    default:
                        break;
                }

                if (ddlstApproveUser.SelectedItem == null)
                {
                    Alert.Show("您的“执行人”为空，请在我的首页设置我的审批人！");
                }
            }
        }

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
        private void SaveBaoxiao()
        {
            if (OperatorType == null)
                return;
            BaoxiaoInfo _baoxiaoInfo = null;
            BaoxiaoManage baoxiaoManage = new BaoxiaoManage();
            int result = 3;

            #region 添加申请单

            if (OperatorType == "Add")
            {
                // 创建报销单实例.
                UserInfo _currentUser = CurrentUser;
                _baoxiaoInfo = new BaoxiaoInfo();
                _baoxiaoInfo.ObjectId = Guid.NewGuid();
                _baoxiaoInfo.UserId = _currentUser.ObjectId;
                _baoxiaoInfo.UserName = _currentUser.Name;
                _baoxiaoInfo.UserJobNo = _currentUser.JobNo;
                _baoxiaoInfo.UserAccountNo = _currentUser.AccountNo;
                _baoxiaoInfo.Dept = _currentUser.Dept;
                _baoxiaoInfo.Sument = taaSument.Text.Trim();
                _baoxiaoInfo.Money = Decimal.Parse(tbxMoney.Text.Replace(BT, "").Trim());
                if (tbxMoney.Text.Contains(BT))
                {
                    _baoxiaoInfo.MoneyFlag = BT;
                }
                _baoxiaoInfo.Other = taaOther.Text.Trim();
                _baoxiaoInfo.ApplyTime = DateTime.Now;
                _baoxiaoInfo.State = 0;
                _baoxiaoInfo.Isdelete = false;
                _baoxiaoInfo.CheckerId = new Guid(ddlstApproveUser.SelectedValue);
                _baoxiaoInfo.StartTime = Convert.ToDateTime(dpkStartTime.SelectedDate);
                _baoxiaoInfo.EndTime = Convert.ToDateTime(dpkEndTime.SelectedDate);

                // 插入新报销单.
                result = baoxiaoManage.AddNewBaoxiao(_baoxiaoInfo);

                // 插入起草记录到报销审批流程表.
                BaoxiaoCheckInfo _baoxiaoCheckInfo = new BaoxiaoCheckInfo();
                _baoxiaoCheckInfo.ObjectId = Guid.NewGuid();
                _baoxiaoCheckInfo.CheckerId = _currentUser.ObjectId;
                _baoxiaoCheckInfo.CheckerName = _currentUser.Name;
                _baoxiaoCheckInfo.CheckrDept = _currentUser.Dept;
                _baoxiaoCheckInfo.CheckDateTime = _baoxiaoInfo.ApplyTime;
                _baoxiaoCheckInfo.Checkstate = 0;
                _baoxiaoCheckInfo.CheckOp = "0";
                _baoxiaoCheckInfo.ApplyId = _baoxiaoInfo.ObjectId;

                baoxiaoManage.AddNewBaoxiaoCheck(_baoxiaoCheckInfo);

                // 插入待审批记录到报销审批流程表.
                _baoxiaoCheckInfo = new BaoxiaoCheckInfo();
                UserInfo _approveUser = new UserManage().GetUserByObjectID(ddlstApproveUser.SelectedValue);
                _baoxiaoCheckInfo.ObjectId = Guid.NewGuid();
                _baoxiaoCheckInfo.CheckerId = _approveUser.ObjectId;
                _baoxiaoCheckInfo.CheckerName = _approveUser.Name;
                _baoxiaoCheckInfo.CheckrDept = _approveUser.Dept;
                _baoxiaoCheckInfo.CheckDateTime = ACommonInfo.DBEmptyDate;
                _baoxiaoCheckInfo.Checkstate = 0;
                _baoxiaoCheckInfo.CheckOp = "";
                _baoxiaoCheckInfo.ApplyId = _baoxiaoInfo.ObjectId;

                baoxiaoManage.AddNewBaoxiaoCheck(_baoxiaoCheckInfo);

            }
            #endregion

            #region 编辑申请单

            if (OperatorType == "Edit")
            {
                _baoxiaoInfo = baoxiaoManage.GetBaoxiaoByObjectID(BaoxiaoObjectID);
                if (_baoxiaoInfo != null)
                {
                    // 更新申请单中的数据.
                    _baoxiaoInfo.Money = Decimal.Parse(tbxMoney.Text.Replace(BT, "").Trim());

                    if (tbxMoney.Text.Contains(BT))
                    {
                        _baoxiaoInfo.MoneyFlag = BT;
                    }
                    _baoxiaoInfo.Sument = taaSument.Text.Trim();
                    _baoxiaoInfo.Other = taaOther.Text.Trim();
                    _baoxiaoInfo.ApplyTime = DateTime.Now;
                    _baoxiaoInfo.State = 0;
                    _baoxiaoInfo.CheckerId = new Guid(ddlstApproveUser.SelectedValue);
                    _baoxiaoInfo.StartTime = Convert.ToDateTime(dpkStartTime.SelectedDate);
                    _baoxiaoInfo.EndTime = Convert.ToDateTime(dpkEndTime.SelectedDate);

                    result = baoxiaoManage.UpdateBaoxiao(_baoxiaoInfo);

                    // 插入待审批记录到报销审批流程表.
                    BaoxiaoCheckInfo _baoxiaoCheckInfo = new BaoxiaoCheckInfo();
                    UserInfo _approveUser = new UserManage().GetUserByObjectID(ddlstApproveUser.SelectedValue);
                    _baoxiaoCheckInfo.ObjectId = Guid.NewGuid();
                    _baoxiaoCheckInfo.CheckerId = _approveUser.ObjectId;
                    _baoxiaoCheckInfo.CheckerName = _approveUser.Name;
                    _baoxiaoCheckInfo.CheckrDept = _approveUser.Dept;
                    _baoxiaoCheckInfo.CheckDateTime = ACommonInfo.DBEmptyDate;
                    _baoxiaoCheckInfo.Checkstate = 0;
                    _baoxiaoCheckInfo.CheckOp = "";
                    _baoxiaoCheckInfo.ApplyId = _baoxiaoInfo.ObjectId;

                    baoxiaoManage.AddNewBaoxiaoCheck(_baoxiaoCheckInfo);
                }
            }

            #endregion

            if (result == -1)
            {
                //Alert.Show("申请提交成功!");
                //btnSubmit.Enabled = false;
                //tabApproveHistory.Hidden = false;
                //BaoxiaoObjectID = _baoxiaoInfo.ObjectId.ToString();
                //BindApproveHistory();
                CheckMsg(ddlstApproveUser.SelectedValue.ToString(), ddlstApproveUser.SelectedText, "报销审批（来自财务报销）");

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
        private void BindBaoxiaoInfo()
        {
            BaoxiaoManage _manage = new BaoxiaoManage();
            BaoxiaoInfo _info = _manage.GetBaoxiaoByObjectID(BaoxiaoObjectID);
            if (_info != null)
            {
                lblName.Text = _info.UserName;
                lblAppDate.Text = _info.ApplyTime.ToString("yyyy-MM-dd HH:mm");
                dpkStartTime.SelectedDate = _info.StartTime;
                dpkEndTime.SelectedDate = _info.EndTime;
                tbxMoney.Text = _info.MoneyFlag + _info.Money.ToString();
                taaSument.Text = _info.Sument;
                taaOther.Text = _info.Other;

                // 查找最早的审批记录.
                List<BaoxiaoCheckInfo> lstApprove = _manage.GetBaoxiaoCheckByCondition(" ApplyID = '" + _info.ObjectId.ToString() +
                    "' and CheckOp <> '0'");
                if (lstApprove.Count == 1)
                {
                    ddlstApproveUser.SelectedValue = lstApprove[0].CheckerId.ToString();
                }
                else
                {
                    lstApprove.Sort(delegate(BaoxiaoCheckInfo x, BaoxiaoCheckInfo y) { return DateTime.Compare(x.CheckDateTime, y.CheckDateTime); });
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
            tbxMoney.Required = false;
            tbxMoney.ShowRedStar = false;
            tbxMoney.Enabled = false;
            taaSument.Required = false;
            taaSument.ShowRedStar = false;
            taaSument.Enabled = false;
            taaOther.Required = false;
            taaOther.ShowRedStar = false;
            taaOther.Enabled = false;
            dpkStartTime.Required = false;
            dpkStartTime.ShowRedStar = false;
            dpkStartTime.Enabled = false;
            dpkEndTime.Required = false;
            dpkEndTime.ShowRedStar = false;
            dpkEndTime.Enabled = false;
        }

        /// <summary>
        /// 绑定审批历史
        /// </summary>
        private void BindApproveHistory()
        {
            if (BaoxiaoObjectID == null)
                return;
            // 获取数据.
            StringBuilder strCondition = new StringBuilder();
            strCondition.Append("ApplyID = '" + BaoxiaoObjectID + "'");
            strCondition.Append(" and (Checkstate <> 0 or (Checkstate = 0 and CheckOp = '0'))");
            List<BaoxiaoCheckInfo> lstBaoxiaoCheckInfo = new BaoxiaoManage().GetBaoxiaoCheckByCondition(strCondition.ToString());

            lstBaoxiaoCheckInfo.Sort(delegate(BaoxiaoCheckInfo x, BaoxiaoCheckInfo y) { return DateTime.Compare(y.CheckDateTime, x.CheckDateTime); });

            // 绑定列表.
            gridApproveHistory.RecordCount = lstBaoxiaoCheckInfo.Count;
            this.gridApproveHistory.DataSource = lstBaoxiaoCheckInfo;
            this.gridApproveHistory.DataBind();
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
            DateTime startTime = Convert.ToDateTime(dpkStartTime.SelectedDate);
            DateTime endTime = Convert.ToDateTime(dpkEndTime.SelectedDate);

            if (DateTime.Compare(startTime, endTime) > 1)
            {
                Alert.Show("结束日期不可小于开始日期!");
                return;
            }

            SaveBaoxiao();
        }
    }
}