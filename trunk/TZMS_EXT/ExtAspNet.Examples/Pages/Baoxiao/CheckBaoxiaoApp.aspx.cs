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
    public partial class CheckBaoxiaoApp : BasePage
    {
        /// <summary>
        /// BaoxiaoID
        /// </summary>
        public string BaoxiaoID
        {
            get
            {
                if (ViewState["BaoxiaoID"] == null)
                {
                    return null;
                }
                return ViewState["BaoxiaoID"].ToString();
            }

            set
            {
                ViewState["BaoxiaoID"] = value;
            }
        }

        /// <summary>
        /// BaoxiaoCheckID
        /// </summary>
        public string BaoxiaoCheckID
        {
            get
            {
                if (ViewState["BaoxiaoCheckID"] == null)
                {
                    return null;
                }
                return ViewState["BaoxiaoCheckID"].ToString();
            }

            set
            {
                ViewState["BaoxiaoCheckID"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BaoxiaoID = Request.QueryString["BaoxiaoID"];
                BaoxiaoCheckID = Request.QueryString["BaoxiaoCheckID"];

                BindNext();
                BindApproveUser();
                BindBaoxiaoInfo();
                BindApproveHistory();
                SetPanelState();
            }
        }

        /// <summary>
        /// 绑定下一步
        /// </summary>
        private void BindNext()
        {
            ddlstNext.Items.Add(new ExtAspNet.ListItem("审批", "0"));
            foreach (RoleType roleType in CurrentRoles)
            {
                if (roleType == RoleType.CNKJ)
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
        /// 绑定报销申请单信息
        /// </summary>
        private void BindBaoxiaoInfo()
        {
            if (!string.IsNullOrEmpty(BaoxiaoID))
            {
                BaoxiaoInfo _baoxiaoInfo = new BaoxiaoManage().GetBaoxiaoByObjectID(BaoxiaoID);
                if (_baoxiaoInfo != null)
                {
                    lblName.Text = _baoxiaoInfo.UserName;
                    lblAppDate.Text = _baoxiaoInfo.ApplyTime.ToString("yyyy-MM-dd HH:mm");
                    lblStartTime.Text = _baoxiaoInfo.StartTime.ToString("yyyy-MM-dd");
                    lblEndTime.Text = _baoxiaoInfo.EndTime.ToString("yyyy-MM-dd");
                    tbxMoney.Text = _baoxiaoInfo.Money.ToString() + "元";
                    taaSument.Text = _baoxiaoInfo.Sument;
                    taaOther.Text = _baoxiaoInfo.Other;
                }
            }
        }

        /// <summary>
        /// 绑定审批历史
        /// </summary>
        private void BindApproveHistory()
        {
            if (BaoxiaoID == null)
                return;
            // 获取数据.
            StringBuilder strCondition = new StringBuilder();
            strCondition.Append("ApplyID = '" + BaoxiaoID + "'");
            strCondition.Append(" and (Checkstate <> 0 or (Checkstate = 0 and CheckOp = '0'))");
            List<BaoxiaoCheckInfo> lstBaoxiaoCheckInfo = new BaoxiaoManage().GetBaoxiaoCheckByCondition(strCondition.ToString());

            lstBaoxiaoCheckInfo.Sort(delegate(BaoxiaoCheckInfo x, BaoxiaoCheckInfo y) { return DateTime.Compare(y.CheckDateTime, x.CheckDateTime); });

            // 绑定列表.
            gridApproveHistory.RecordCount = lstBaoxiaoCheckInfo.Count;
            this.gridApproveHistory.DataSource = lstBaoxiaoCheckInfo;
            this.gridApproveHistory.DataBind();
        }

        /// <summary>
        /// 设置面板状态
        /// </summary>
        private void SetPanelState()
        {
            if (string.IsNullOrEmpty(BaoxiaoCheckID))
                return;
            BaoxiaoManage _manage = new BaoxiaoManage();
            BaoxiaoCheckInfo _checkInfo = _manage.GetBaoxiaoCheckByObjectID(BaoxiaoCheckID);
            if (_checkInfo != null)
            {
                if (_checkInfo.Checkstate == 1)
                {
                    mainForm2.Hidden = true;
                    btnPass.Hidden = true;
                    btnRefuse.Hidden = true;
                }
            }
        }

        /// <summary>
        /// 弹出窗口关闭事件
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
            if (BaoxiaoCheckID == null || BaoxiaoID == null)
                return;
            int result = 3;
            BaoxiaoManage _manage = new BaoxiaoManage();
            BaoxiaoInfo _baoxiaoInfo = _manage.GetBaoxiaoByObjectID(BaoxiaoID);
            BaoxiaoCheckInfo _currentCheckInfo = _manage.GetBaoxiaoCheckByObjectID(BaoxiaoCheckID);
            if (_currentCheckInfo != null && _baoxiaoInfo != null)
            {
                #region 审批

                if (ddlstNext.SelectedText == "审批")
                {
                    // 更新报销申请单记录.
                    _baoxiaoInfo.CheckerId = new Guid(ddlstApproveUser.SelectedValue);
                    result = _manage.UpdateBaoxiao(_baoxiaoInfo);

                    // 更新现有审批记录.
                    _currentCheckInfo.Checkstate = 1;
                    _currentCheckInfo.Result = "0";
                    _currentCheckInfo.CheckDateTime = DateTime.Now;
                    _currentCheckInfo.CheckSugest = string.IsNullOrEmpty(taaCheckSugest.Text.Trim()) ? "同意" : taaCheckSugest.Text.Trim();
                    _currentCheckInfo.CheckOp = "1";
                    _manage.UpdateBaoxiaoCheck(_currentCheckInfo);

                    // 插入下一个审批记录.
                    BaoxiaoCheckInfo _nextCheckInfo = new BaoxiaoCheckInfo();
                    UserInfo _nextCheckUserInfo = new UserManage().GetUserByObjectID(ddlstApproveUser.SelectedValue);
                    _nextCheckInfo.ObjectId = Guid.NewGuid();
                    _nextCheckInfo.CheckerName = ddlstApproveUser.SelectedText;
                    _nextCheckInfo.CheckerId = new Guid(ddlstApproveUser.SelectedValue);
                    _nextCheckInfo.CheckrDept = _nextCheckUserInfo.Dept;
                    _nextCheckInfo.CheckDateTime = ACommonInfo.DBEmptyDate;
                    _nextCheckInfo.Checkstate = 0;
                    _nextCheckInfo.ApplyId = _currentCheckInfo.ApplyId;
                    _manage.AddNewBaoxiaoCheck(_nextCheckInfo);
                }
                #endregion

                #region 归档

                if (ddlstNext.SelectedText == "同意并归档")
                {
                    // 修改申请单信息.
                    _baoxiaoInfo.State = 2;
                    _baoxiaoInfo.CheckerId = SystemUser.ObjectId;
                    result = _manage.UpdateBaoxiao(_baoxiaoInfo);

                    // 更新现有审批记录.
                    _currentCheckInfo.Checkstate = 1;
                    _currentCheckInfo.Result = "0";
                    _currentCheckInfo.CheckDateTime = DateTime.Now;
                    _currentCheckInfo.CheckSugest = string.IsNullOrEmpty(taaCheckSugest.Text.Trim()) ? "同意" : taaCheckSugest.Text.Trim();
                    _currentCheckInfo.CheckOp = "1";
                    _manage.UpdateBaoxiaoCheck(_currentCheckInfo);

                    // 插入归档记录.
                    BaoxiaoCheckInfo _archiveCheckInfo = new BaoxiaoCheckInfo();
                    _archiveCheckInfo.ObjectId = Guid.NewGuid();
                    _archiveCheckInfo.CheckerId = SystemUser.ObjectId;
                    _archiveCheckInfo.CheckerName = SystemUser.Name;
                    _archiveCheckInfo.CheckDateTime = _currentCheckInfo.CheckDateTime.AddSeconds(1);
                    _archiveCheckInfo.Checkstate = 1;
                    _archiveCheckInfo.CheckOp = "3";
                    _archiveCheckInfo.ApplyId = _baoxiaoInfo.ObjectId;
                    _manage.AddNewBaoxiaoCheck(_archiveCheckInfo);

                    // 插入报销凭证信息.
                    BaoXiaoPinZhengApplyInfo _PingZhengApplyInfo = new BaoXiaoPinZhengApplyInfo();
                    _PingZhengApplyInfo.ObjectID = Guid.NewGuid();
                    _PingZhengApplyInfo.Title = _baoxiaoInfo.UserName + "的网络报销单";
                    _PingZhengApplyInfo.State = -1;
                    _PingZhengApplyInfo.IsDelete = false;
                    _PingZhengApplyInfo.ApplyTime = ACommonInfo.DBMAXDate;
                    _PingZhengApplyInfo.BaoXiaoID = _baoxiaoInfo.ObjectId;

                    _manage.AddNewPinZhengApply(_PingZhengApplyInfo);

                    // 插入出纳记录.
                    CashFlowManage _cashFlowManage = new CashFlowManage();
                    _cashFlowManage.Add(_baoxiaoInfo.Money, DateTime.Now, "Payment", TZMS.Common.Biz.BaoXiao, _baoxiaoInfo.UserName + "的财务报销", string.Empty);
                }

                #endregion
            }
            if (result == -1)
            {
                //Alert.Show(ddlstNext.SelectedText + "成功!");
                //btnPass.Enabled = false;
                //btnRefuse.Enabled = false;
                //BindApproveHistory();
                if (ddlstNext.SelectedText == "审批")
                {
                    CheckMsg(ddlstApproveUser.SelectedValue.ToString(), ddlstApproveUser.SelectedText, "报销审批（来自财务报销）");
                }
                else
                {
                    ResultMsgMore(_baoxiaoInfo.UserId.ToString(), _baoxiaoInfo.UserName, "您有1条报销申请（来自费用管理），已通过审核并归档！");
                }

                this.btnClose_Click(null, null);
            }
            else
            {
                Alert.Show("审批失败(" + ddlstNext.SelectedText + ")!");
            }
        }

        /// <summary>
        /// 打回事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnRefuse_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(taaCheckSugest.Text.Trim()))
            {
                Alert.Show("审批意见不可为空!");
                return;
            }

            if (BaoxiaoID == null || BaoxiaoCheckID == null)
                return;

            BaoxiaoManage _manage = new BaoxiaoManage();
            BaoxiaoInfo _currentInfo = _manage.GetBaoxiaoByObjectID(BaoxiaoID);
            if (_currentInfo != null)
            {
                BaoxiaoCheckInfo _currentCheckInfo = _manage.GetBaoxiaoCheckByObjectID(BaoxiaoCheckID);

                //更新报销申请单信息.
                _currentInfo.State = 1;
                int result = _manage.UpdateBaoxiao(_currentInfo);

                // 更新报销流程表信息.
                _currentCheckInfo.CheckDateTime = DateTime.Now;
                _currentCheckInfo.Checkstate = 1;
                _currentCheckInfo.Result = "1";
                _currentCheckInfo.CheckSugest = taaCheckSugest.Text.Trim();
                _currentCheckInfo.CheckOp = "2";
                _manage.UpdateBaoxiaoCheck(_currentCheckInfo);

                if (result == -1)
                {
                    //Alert.Show("打回成功!");

                    //// 重新设置按钮状态并刷新审批历史.
                    //btnPass.Enabled = false;
                    //btnRefuse.Enabled = false;
                    //BindApproveHistory();

                    this.btnClose_Click(null, null);
                }
                else
                {
                    Alert.Show("审批失败(不同意)!");
                }

            }
        }

        /// <summary>
        /// 下一步下拉框变动事件
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
                btnPass.ConfirmText = "您确定同意并归档吗?";
            }
            else
            {
                ddlstApproveUser.Hidden = false;
                ddlstApproveUser.Required = true;
                ddlstApproveUser.ShowRedStar = true;
                ddlstApproveUser.Enabled = true;
                btnPass.Text = "同意";
                btnPass.ConfirmText = "您确定同意吗?";
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
    }
}