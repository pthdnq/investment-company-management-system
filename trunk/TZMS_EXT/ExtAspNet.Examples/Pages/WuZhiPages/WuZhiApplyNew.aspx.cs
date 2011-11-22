using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExtAspNet;
using System.Text;
using com.TZMS.Model;
using com.TZMS.Business;

namespace TZMS.Web
{
    public partial class WuZhiApplyNew : BasePage
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
        /// WuZhiID
        /// </summary>
        public string WuZhiID
        {
            get
            {
                if (ViewState["WuZhiID"] == null)
                {
                    return null;
                }

                return ViewState["WuZhiID"].ToString();
            }
            set
            {
                ViewState["WuZhiID"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
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
                                tabApproveHistory.Hidden = true;

                                lblUser.Text = CurrentUser.Name;
                                lblApplyDate.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm");

                                // 绑定下一步.
                                BindNext();
                                // 绑定类型.
                                BindWuZhiType();
                                // 绑定审批人.
                                ApproveUser();
                            }
                            break;
                        case "View":
                            {
                                OperatorType = strOperatorType;
                                WuZhiID = strApplyID;

                                // 绑定下一步.
                                BindNext();
                                // 绑定类型.
                                BindWuZhiType();
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
                                WuZhiID = strApplyID;

                                // 绑定下一步.
                                BindNext();
                                // 绑定类型.
                                BindWuZhiType();
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

                    if (ddlstApproveUser.SelectedItem == null)
                    {
                        Alert.Show("您的“执行人”为空，请在我的首页设置我的审批人！");
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
        /// 绑定物资类型
        /// </summary>
        private void BindWuZhiType()
        {
            ddlstWuZhiType.Items.Add(new ExtAspNet.ListItem("一般物资", "0"));
            foreach (RoleType roleType in CurrentRoles)
            {
                if (roleType == RoleType.WZSQ_GD)
                {
                    ddlstWuZhiType.Items.Add(new ExtAspNet.ListItem("固定物资", "1"));
                    break;
                }
            }
            ddlstWuZhiType.SelectedIndex = 0;
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
            WuZhiInfo _applyInfo = null;
            WuZhiManage _manage = new WuZhiManage();
            UserInfo _currentUser = CurrentUser;
            int result = 3;

            #region 添加申请单

            if (OperatorType == "Add")
            {
                // 创建报销单实例.

                _applyInfo = new WuZhiInfo();
                _applyInfo.ObjectId = Guid.NewGuid();
                _applyInfo.UserId = _currentUser.ObjectId;
                _applyInfo.UserJobNo = _currentUser.JobNo;
                _applyInfo.UserAccountNo = _currentUser.AccountNo;
                _applyInfo.UserName = _currentUser.Name;
                _applyInfo.Type = short.Parse(ddlstWuZhiType.SelectedValue);
                _applyInfo.Title = tbxTitle.Text.Trim();
                _applyInfo.Sument = taaSument.Text.Trim();
                _applyInfo.Other = taaOther.Text.Trim();
                _applyInfo.State = 0;
                _applyInfo.CurrentCheckerId = new Guid(ddlstApproveUser.SelectedValue);
                _applyInfo.Isdelete = false;

                // 插入新报销单.
                result = _manage.AddNewWuZhi(_applyInfo);

                // 插入起草记录到代帐费审批流程表.
                WuzhiCheckInfo _approveInfo = new WuzhiCheckInfo();
                _approveInfo.ObjectId = Guid.NewGuid();
                _approveInfo.CheckerId = _currentUser.ObjectId;
                _approveInfo.CheckerName = _currentUser.Name;
                _approveInfo.CheckrDept = _currentUser.Dept;
                _approveInfo.CheckDateTime = DateTime.Now;
                _approveInfo.Checkstate = 0;
                _approveInfo.CheckOp = "0";
                _approveInfo.ApplyId = _applyInfo.ObjectId;
                _manage.AddNewWuZhiCheck(_approveInfo);

                // 插入待审批记录到报销审批流程表.
                _approveInfo = new WuzhiCheckInfo();
                UserInfo _approveUser = new UserManage().GetUserByObjectID(ddlstApproveUser.SelectedValue);
                _approveInfo.ObjectId = Guid.NewGuid();
                _approveInfo.CheckerId = _approveUser.ObjectId;
                _approveInfo.CheckerName = _approveUser.Name;
                _approveInfo.CheckrDept = _approveUser.Dept;
                _approveInfo.CheckDateTime = ACommonInfo.DBEmptyDate;
                _approveInfo.Checkstate = 0;
                _approveInfo.ApplyId = _applyInfo.ObjectId;

                _manage.AddNewWuZhiCheck(_approveInfo);

            }
            #endregion

            #region 编辑申请单

            if (OperatorType == "Edit")
            {
                _applyInfo = _manage.GetWuZhiByObjectID(WuZhiID);
                if (_applyInfo != null)
                {
                    // 更新申请单中的数据.

                    _applyInfo.Type = short.Parse(ddlstWuZhiType.SelectedValue);
                    _applyInfo.Title = tbxTitle.Text.Trim();
                    _applyInfo.Sument = taaSument.Text.Trim();
                    _applyInfo.Other = taaOther.Text.Trim();
                    _applyInfo.State = 0;
                    _applyInfo.CurrentCheckerId = new Guid(ddlstApproveUser.SelectedValue);
                    _applyInfo.Isdelete = false;

                    result = _manage.UpdateWuZhi(_applyInfo);

                    // 插入待审批记录到报销审批流程表.
                    WuzhiCheckInfo _approveInfo = new WuzhiCheckInfo();
                    UserInfo _approveUser = new UserManage().GetUserByObjectID(ddlstApproveUser.SelectedValue);
                    _approveInfo.ObjectId = Guid.NewGuid();
                    _approveInfo.CheckerId = _approveUser.ObjectId;
                    _approveInfo.CheckerName = _approveUser.Name;
                    _approveInfo.CheckrDept = _approveUser.Dept;
                    _approveInfo.CheckDateTime = ACommonInfo.DBEmptyDate;
                    _approveInfo.Checkstate = 0;
                    _approveInfo.ApplyId = _applyInfo.ObjectId;

                    _manage.AddNewWuZhiCheck(_approveInfo);
                }
            }

            #endregion

            if (result == -1)
            {
                Alert.Show("申请提交成功!");
                btnSubmit.Enabled = false;
                tabApproveHistory.Hidden = false;
                WuZhiID = _applyInfo.ObjectId.ToString();
                BindApproveHistory();
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
            WuZhiManage _manage = new WuZhiManage();
            WuZhiInfo _info = _manage.GetWuZhiByObjectID(WuZhiID);
            if (_info != null)
            {
                lblUser.Text = _info.UserName;
                lblApplyDate.Text = _info.ApplyTime.ToString("yyyy-MM-dd HH:mm");
                ddlstWuZhiType.SelectedValue = _info.Type.ToString();
                tbxTitle.Text = _info.Title;
                taaSument.Text = _info.Sument;
                taaOther.Text = _info.Other;

                // 查找最早的审批记录.
                List<WuzhiCheckInfo> lstCheck = _manage.GetWuZhiCheckByCondition(" ApplyID = '" + WuZhiID + "' and CheckOp <> '0'");
                if (lstCheck.Count == 1)
                {
                    ddlstApproveUser.SelectedValue = lstCheck[0].CheckerId.ToString();
                }
                else
                {
                    lstCheck.Sort(delegate(WuzhiCheckInfo x, WuzhiCheckInfo y) { return DateTime.Compare(x.CheckDateTime, y.CheckDateTime); });
                    foreach (var item in lstCheck)
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
            tbxTitle.Required = false;
            tbxTitle.ShowRedStar = false;
            tbxTitle.Enabled = false;
            taaSument.Required = false;
            taaSument.ShowRedStar = false;
            taaSument.Enabled = false;
            taaOther.Enabled = false;
        }

        /// <summary>
        /// 绑定审批历史
        /// </summary>
        private void BindApproveHistory()
        {
            if (WuZhiID == null)
                return;
            // 获取数据.
            StringBuilder strCondition = new StringBuilder();
            strCondition.Append(" ApplyID = '" + WuZhiID + "'");
            strCondition.Append(" and  (Checkstate <> 0 or (Checkstate = 0 and CheckOp = '0'))");
            List<WuzhiCheckInfo> lstWuZhiCheckInfo = new WuZhiManage().GetWuZhiCheckByCondition(strCondition.ToString());

            lstWuZhiCheckInfo.Sort(delegate(WuzhiCheckInfo x, WuzhiCheckInfo y) { return DateTime.Compare(y.CheckDateTime, x.CheckDateTime); });

            // 绑定列表.
            gridApproveHistory.RecordCount = lstWuZhiCheckInfo.Count;
            this.gridApproveHistory.DataSource = lstWuZhiCheckInfo;
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

        #endregion
    }
}