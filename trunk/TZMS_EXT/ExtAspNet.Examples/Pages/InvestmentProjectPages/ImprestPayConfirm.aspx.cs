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
        public string OperateType
        {
            get
            {
                if (ViewState["OperateType"] == null)
                {
                    return null;
                }

                return ViewState["OperateType"].ToString();
            }
            set
            {
                ViewState["OperateType"] = value;
            }
        }

        /// <summary>
        ///  ObjectID
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


            if (!IsPostBack)
            {
                string strID = Request.QueryString["ID"];
                ObjectID = strID;
                OperateType = Request.QueryString["Type"];

                bindUserInterface(strID);
                BindHistory();

                // 绑定审批人.
              //  ApproveUser();
               // BindNext();
            }
            InitControl();
        }

        private void InitControl()
        {
            this.btnClose.OnClientClick = ActiveWindow.GetConfirmHidePostBackReference();
            hlPrinter.NavigateUrl = "ImprestPayConfirmPrinter.aspx?ID=" + ObjectID;
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
                if (!string.IsNullOrEmpty(OperateType) && OperateType.Equals("View"))
                {
                   // this.btnDismissed.Hidden = true;
                    this.btnSave.Hidden = true;
                    this.taAccountingRemark.Text = _info.AccountingRemark;
                    this.taAccountingRemark.Enabled = false;

                  //  this.ddlstApproveUser.Items.Add(new ListItem() { Text = _info.NextOperaterName, Value = "0", Selected = true });
                //   this.ddlstNext.Enabled = false;
                 //   this.ddlstApproveUser.Enabled = false;
                }

                this.tbProjectName.Text = _info.ProjectName;
                this.tbImplementationPhase.Text = _info.Use;
                this.tbAmountExpended.Text = _info.AmountExpendedFlag+_info.AmountExpended.ToString();
                this.tbImprestAmount.Text = _info.ImprestAmountFlag+_info.ImprestAmount.ToString();
                this.taRemark.Text = _info.ImprestRemark;

                //  if (DateTime.Compare(_info.ExpendedTime, DateTime.Parse("1900-1-1 12:00")) != 0)
                //  {
                this.dpExpendedTime.Text = _info.ExpendedTime;
                //     }
                this.taAuditOpinion.Text = _info.AuditOpinion;

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

            _Info.IsPassImprest = true;
            //下一步审核人
            //_Info.NextOperaterName = this.ddlstApproveUser.SelectedText;
            //_Info.NextOperaterId = new Guid(this.ddlstApproveUser.SelectedValue);
            _Info.NextOperaterName = _Info.FirstOperaterName;
            _Info.NextOperaterId = _Info.FirstOperaterID;

            _Info.SubmitTime = DateTime.Now;

            //审批人
            if (!_Info.Adulters.Contains(this.CurrentUser.ObjectId.ToString()))
            {
                _Info.Adulters = _Info.Adulters + this.CurrentUser.ObjectId.ToString() + ";";
            }
            // 执行操作.
            int result = 3;

            result = manage.UpdateProcess(_Info);
            if (result == -1)
            {
                #region cashflow
                int itmp = new CashFlowManage().Add(new CashFlowStatementInfo()
                {
                    ObjectId = Guid.NewGuid(),
                    Amount = _Info.AmountExpended,
                    DateFor = DateTime.Now,
                    FlowDirection = Common.FlowDirection.Payment,
                    FlowType = "",
                    Biz = Common.Biz.InvestmentProject,
                    ProjectName = _Info.ProjectName,
                    IsAccountingAudit = 1
                });
                if (itmp != -1)
                {
                    _Info.Status = 4;
                    manage.UpdateProcess(_Info);
                    Alert.Show("操作失败!");
                    return;
                }
                #endregion

                #region 调用发送消息
                List<Guid> receives = new List<Guid>();
                receives.Add(_Info.CreaterId);
                string strTitle = "投资部项目实施备用金支付提醒";
                string strContent = string.Format("{0}-{1}备用金{2}元已通过领导审核确认支付，谢谢", _Info.ProjectName, _Info.ImplementationPhase, _Info.PrepaidAmount);
                new MessageManage().SendMessage(Guid.NewGuid(), this.CurrentUser.ObjectId, receives, strTitle, strContent);
                #endregion

                string statusName = "已确认";//(status == 2) ? "不同意" : (status == 3) ? "同意" : "待会计审核";
                manage.AddHistory(true, _Info.ObjectId, "会计审核", string.Format("出纳确认-{0}", statusName), this.CurrentUser.AccountNo, this.CurrentUser.Name, DateTime.Now, _Info.AccountingRemark);

                //提醒申请人，审核通过，会计已确认
                //ResultMsgMore(_Info.CreaterId.ToString(), _Info.CreaterName, "您有1条备用金申请（集团外项目），会计已确认！");

                ResultMsgMore(_Info.FirstOperaterID.ToString(), _Info.FirstOperaterName, string.Format("{0}，您好！进展审核列表（集团外项目）中，您有一条 待审核 信息！", _Info.FirstOperaterName));

                //Alert.Show("操作成功!");
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