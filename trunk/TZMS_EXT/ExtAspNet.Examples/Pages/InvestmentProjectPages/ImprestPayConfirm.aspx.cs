using System;
using System.Collections.Generic;
using com.TZMS.Business;
using com.TZMS.Model;
using ExtAspNet;
using System.Text;

namespace TZMS.Web.Pages.InvestmentProjectPages
{
    /// <summary>
    /// ImprestPayConfirm
    /// </summary>
    public partial class ImprestPayConfirm : BasePage
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
            com.TZMS.Model.ProjectProcessInfo _info = new InvestmentProjectManage().GetProcessByObjectID(strID);

            // 绑定数据.
            if (_info != null)
            {

                this.tbImplementationPhase.Text = _info.ImplementationPhase;
                this.tbAmountExpended.Text = _info.AmountExpended.ToString();
                this.tbImprestAmount.Text = _info.ImprestAmount.ToString();
                this.taRemark.Text = _info.Remark;

                if (DateTime.Compare(_info.ExpendedTime, DateTime.Parse("1900-1-1 12:00")) != 0)
                {
                    this.dpExpendedTime.SelectedDate = _info.ExpendedTime;
                }
             this.taAuditOpinion.Text=   _info.AuditOpinion;
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
            List<ProjectProcessHistoryInfo> lstInfo = new InvestmentProjectManage().GetProcessHistoryByCondtion(strCondition.ToString());
            //lstInfo.Sort(delegate(BaoxiaoCheckInfo x, BaoxiaoCheckInfo y) { return DateTime.Compare(y.CheckDateTime, x.CheckDateTime); });

            gridHistory.RecordCount = lstInfo.Count;
            this.gridHistory.DataSource = lstInfo;
            this.gridHistory.DataBind();
        }
        #endregion

        #region 页面及控件事件
        //protected void btnDismissed_Click(object sender, EventArgs e)
        //{
        //    saveInfo(2);
        //}

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //确认4
            saveInfo(5);
        }
        #endregion

        #region 自定义方法
        /// <summary>
        /// 保存 信息.
        /// </summary>
        private void saveInfo(int status)
        {
            InvestmentProjectManage manage = new InvestmentProjectManage();

            com.TZMS.Model.ProjectProcessInfo _Info = manage.GetProcessByObjectID(ObjectID);
            _Info.AccountingRemark = this.taAccountingRemark.Text.Trim();
            _Info.Status = status;

            // 执行操作.
            int result = 3;

            result = manage.UpdateProcess(_Info);
            if (result == -1)
            {
                string statusName = "已确认";//(status == 2) ? "不同意" : (status == 3) ? "同意" : "待会计审核";
                manage.AddHistory(_Info.ObjetctId, "会计审核", string.Format("审核:{0}", statusName), this.CurrentUser.AccountNo, this.CurrentUser.Name, DateTime.Now, _Info.AccountingRemark);

                Alert.Show("操作成功!");
                PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference("操作成功"));
     
            }
            else
            {
                Alert.Show("操作失败!");
            }
        }

        /// <summary>
        /// 绑定下一步
        /// </summary>
        private void BindNext()
        {
            ddlstNext.Items.Add(new ExtAspNet.ListItem("审批", "0"));
            //   ddlstNext.Items.Add(new ExtAspNet.ListItem("会计审核", "1"));
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