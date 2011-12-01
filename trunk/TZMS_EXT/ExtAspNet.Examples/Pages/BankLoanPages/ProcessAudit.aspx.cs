using System;
using System.Collections.Generic;
using com.TZMS.Business;
using com.TZMS.Model;
using ExtAspNet;
using System.Text;

namespace TZMS.Web.Pages.BankLoanPages
{
    /// <summary>
    /// ProcessAudit
    /// </summary>
    public partial class ProcessAudit : BasePage
    {
        #region 属性
        /// <summary>
        ///  ID
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
                string strID = Request.QueryString["ID"];
                ObjectID = strID;

                bindUserInterface(strID);
                // 绑定审批人.
                ApproveUser();
                BindHistory();
            }
        }

        private void InitControl()
        {
            this.btnClose.OnClientClick = ActiveWindow.GetConfirmHidePostBackReference();
        }

        /// <summary>
        /// 绑定指定用户ID的数据到界面.
        /// </summary>
        /// <param name="strID">用户ID</param>
        private void bindUserInterface(string strID)
        {
            if (string.IsNullOrEmpty(strID))
            {
                return;
            }

            // 通过 ID获取 信息实例.
            com.TZMS.Model.BankLoanProjectProcessInfo _info = new BankLoanManage().GetProcessByObjectID(strID);

            // 绑定数据.
            if (_info != null)
            {
                #region 下一步方式
                if (CurrentRoles.Contains(RoleType.DSZ))
                {
                    BindNext(true);
                }
                else if (CurrentRoles.Contains(RoleType.ZJL))
                {      //大于30w且当前审批人不是董事长，不显示下一步会计审核选项
                    if (_info.AmountExpended > 3000000)
                    { BindNext(false); HighMoneyTips.Text = "提醒：本次操作资金总额大于30W。"; }
                    else
                    { BindNext(true); }
                }
                else
                {
                    BindNext(false);
                }
                #endregion

                this.taImplementationPhase.Text = _info.ImplementationPhase;
                this.tbAmountExpended.Text = _info.AmountExpended.ToString();
                this.tbImprestAmount.Text = _info.ImprestAmount.ToString();
                this.taRemark.Text = _info.Remark;

                if (DateTime.Compare(_info.ExpendedTime, DateTime.Parse("1900-1-1 12:00")) != 0)
                {
                    this.dpExpendedTime.SelectedDate = _info.ExpendedTime;
                }

            }
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
            List<BankLoanProjectProcessHistoryInfo> lstInfo = new BankLoanManage().GetProcessHistoryByCondtion(strCondition.ToString());
            //lstInfo.Sort(delegate(BaoxiaoCheckInfo x, BaoxiaoCheckInfo y) { return DateTime.Compare(y.CheckDateTime, x.CheckDateTime); });

            gridHistory.RecordCount = lstInfo.Count;
            this.gridHistory.DataSource = lstInfo;
            this.gridHistory.DataBind();
        }
        #endregion

        #region 页面及控件事件
        protected void btnDismissed_Click(object sender, EventArgs e)
        {
            saveInfo(2);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (this.ddlstNext.SelectedValue.Equals(0))
            {
                //同意，继续审核
                saveInfo(3);
            }
            else
            {
                //待会计审核/支付确认
                saveInfo(4);
            }
        }
        #endregion

        #region 自定义方法
        /// <summary>
        /// 保存 信息.
        /// </summary>
        private void saveInfo(int status)
        {
            BankLoanManage manage = new BankLoanManage();

            com.TZMS.Model.BankLoanProjectProcessInfo _Info = manage.GetProcessByObjectID(ObjectID);
            _Info.AuditOpinion = this.taAuditOpinion.Text.Trim();
            _Info.Status = status;

            // 执行操作.
            int result = 3;

            result = manage.UpdateProcess(_Info);
            if (result == -1)
            {
                string statusName = (status == 2) ? "不同意" : (status == 3) ? "同意" : "同意，待会计审核";
                manage.AddHistory(_Info.ObjetctId, "审批", string.Format("借款审批:{0}", statusName), this.CurrentUser.AccountNo, this.CurrentUser.Name, DateTime.Now, _Info.AuditOpinion);

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
            ddlstNext.Items.Add(new ExtAspNet.ListItem("审批", "0"));
            if (needAccountant)
            {
                ddlstNext.Items.Add(new ExtAspNet.ListItem("会计审核", "1"));
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