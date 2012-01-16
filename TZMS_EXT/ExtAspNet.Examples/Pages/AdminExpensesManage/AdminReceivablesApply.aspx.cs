using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.TZMS.Business;
using com.TZMS.Model;
using ExtAspNet;
using System.Text;

namespace TZMS.Web.Pages.AdminExpensesManage
{
    public partial class AdminReceivablesApply : BasePage
    {
        #region 属性
        /// <summary>
        /// 操作类型
        /// </summary>
        public string OperateType
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
        /// ObjectID
        /// </summary>
        public string ObjectID
        {
            get
            {
                if (ViewState["ObjectID"] == null)
                {
                    return null;
                }

                return ViewState["ObjectID"].ToString();
            }
            set
            {
                ViewState["ObjectID"] = value;
            }
        }
        #endregion

        #region 页面加载及数据初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            InitControl();

            if (!IsPostBack)
            {
                ObjectID = Request.QueryString["ID"];
                OperateType = Request.QueryString["Type"];

                if (!string.IsNullOrEmpty(ObjectID))
                {
                    bindUserInterface(ObjectID);
                    BindHistory();
                }
                else
                {
                    ApproveUser();
                    this.tabHistory.Hidden = true;
                }
                BindNext(false);
            }
        }

        private void InitControl()
        {
            this.btnClose.OnClientClick = ActiveWindow.GetConfirmHidePostBackReference();
        }

        /// <summary>
        /// 绑定指定 ID的数据到界面.
        /// </summary>
        /// <param name="strID"> ID</param>
        private void bindUserInterface(string strID)
        {
            if (string.IsNullOrEmpty(strID))
            {
                return;
            }
            AdminReceivablesInfo _Info = new AdminReceivablesManage().GetUserByObjectID(ObjectID);

            #region View

            if (OperateType.Equals("View"))
            {
                this.btnSave.Hidden = true;

                this.btnDismissed.Hidden = true;
                this.ddlstApproveUser.Items.Add(new ExtAspNet.ListItem() { Text = _Info.NextOperaterName, Value = "0", Selected = true });
                this.ddlstNext.ShowRedStar = false;
                this.ddlstNext.Required = false;
                this.ddlstApproveUser.ShowRedStar = false;
                this.ddlstApproveUser.Required = false;
                this.ddlstNext.Enabled = false;
                this.ddlstApproveUser.Enabled = false;
            }
            else
            {
                // 绑定审批人.
                ApproveUser();
            }
            #endregion

            #region 绑定下一步
            //if (CurrentRoles.Contains(RoleType.DSZ))
            //{
            //    BindNext(true);
            //}
            //else if (_Info.PrepaidAmount < 10000 && CurrentRoles.Contains(RoleType.ZJL))
            //{
            //    //大于1w总经理，小于1w财务总监；不显示下一步会计审核选项
            //    BindNext(true);
            //}
            //else
            //{ 
            //  BindNext(false);
            //  }
            if (OperateType.Equals("Edit"))
            {
                BindNext(false);
            }
            else
            {
                BindNext(true);
            }
            #endregion

            this.tbRemark.Text = _Info.Remark;
            this.tbCompany.Text = _Info.Company;
            this.taCause.Text = _Info.Cause;
            this.tbAmountOfReceivables.Text = _Info.AmountOfReceivables.ToString();
            this.dpDateFor.SelectedDate = _Info.DateFor;

            this.tbProjectName.Text = _Info.ProjectName;

            //  taAuditOpinion.Text = _Info.AuditOpinion;
        }

        /// <summary>
        /// 绑定历史
        /// </summary>
        private void BindHistory()
        {
            if (ObjectID == null)
                return;
            // 获取数据.
            StringBuilder strCondition = new StringBuilder();
            strCondition.Append("ForId = '" + ObjectID + "'");
            strCondition.Append(" ORDER BY OperationTime DESC");
            List<AdminReceivablesHistoryInfo> lstInfo = new AdminReceivablesManage().GetHistoryByCondtion(strCondition.ToString());
            //lstInfo.Sort(delegate(BaoxiaoCheckInfo x, BaoxiaoCheckInfo y) { return DateTime.Compare(y.CheckDateTime, x.CheckDateTime); });

            gridHistory.RecordCount = lstInfo.Count;
            this.gridHistory.DataSource = lstInfo;
            this.gridHistory.DataBind();
        }

        #endregion

        #region 页面及控件事件
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDismissed_Click(object sender, EventArgs e)
        {
            //不同意，打回
            saveInfo(2);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ObjectID))
            {
                saveInfo(1);
            }
            else
            {
                saveInfo(3);
            }
            //if (this.ddlstNext.SelectedValue.Equals("0"))
            //{
            //    //同意，继续审核
            //    saveInfo(3);
            //}
            //else
            //{
            //    //待会计审核/支付确认/归档
            //    saveInfo(4);
            //}
        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 保存信息.
        /// </summary>
        private void saveInfo(int status)
        {
            AdminReceivablesManage manage = new AdminReceivablesManage();
            AdminReceivablesInfo _Info = null;
            if (this.OperateType.Equals("Edit"))
            {
                _Info = manage.GetUserByObjectID(ObjectID);
            }
            else
            {
                _Info = new AdminReceivablesInfo();
                _Info.ObjectId = new Guid();
                _Info.AccountingName = this.ddlstApproveUser.SelectedText;
                _Info.AccountingId = new Guid(this.ddlstApproveUser.SelectedValue);

                _Info.CreaterId = this.CurrentUser.ObjectId;
                _Info.CreaterName = this.CurrentUser.Name;
                _Info.CreateTime = DateTime.Now;
            }

            _Info.Status = status;

            #region content

            _Info.ProjectName = this.tbProjectName.Text.Trim();


            _Info.Cause = this.taCause.Text.Trim();
            _Info.AmountOfReceivables = decimal.Parse(this.tbAmountOfReceivables.Text.Trim());
            _Info.Remark = this.tbRemark.Text.Trim();
            _Info.DateFor = this.dpDateFor.SelectedDate.Value;
            _Info.Company = this.tbCompany.Text;

            #endregion

            //下一步操作人
            //if (status == 4)
            //{
            //    _Info.NextOperaterName = "";
            //    _Info.NextOperaterId = Guid.Empty;
            //}
            //else
            //{
            _Info.NextOperaterName = this.ddlstApproveUser.SelectedText;
            _Info.NextOperaterId = new Guid(this.ddlstApproveUser.SelectedValue);

            // }
            _Info.SubmitTime = DateTime.Now;
            //审批人
            //if (!_Info.Adulters.Contains(this.CurrentUser.ObjectId.ToString()))
            //{
            //    _Info.Adulters = _Info.Adulters + this.CurrentUser.ObjectId.ToString() + ";";
            //}

            int result = 3;
            string statusName = "提交申请";
            string operationName = "新增";
            string remark = string.Empty;
            if (this.OperateType.Equals("Edit"))
            {
                result = manage.Update(_Info);
                statusName = "重新修改后提交";
                operationName = "编辑";
            }
            else
            {
                result = manage.Add(_Info);
            }
            if (result == -1)
            {
                //  string statusName = "重新修改后提交";//(status == 2) ? "不同意" : (status == 3) ? "同意，继续审核" : "同意,归档";
                manage.AddHistory(_Info.ObjectId, operationName, string.Format("{0}", statusName), this.CurrentUser.AccountNo, this.CurrentUser.Name, DateTime.Now, remark);

                Alert.Show("操作成功!");
                PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
            }
            else
            {
                Alert.Show("操作失败!");
            }
        }


        /// <summary>
        /// 绑定下一步
        /// </summary>
        private void BindNext(bool needAccountant)
        {
            if (needAccountant)
            {
                ddlstNext.Items.Add(new ExtAspNet.ListItem("出纳确认", "0"));
            }
            else
            {
                ddlstNext.Items.Add(new ExtAspNet.ListItem("审批", "0"));
            }
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
        #endregion
    }
}