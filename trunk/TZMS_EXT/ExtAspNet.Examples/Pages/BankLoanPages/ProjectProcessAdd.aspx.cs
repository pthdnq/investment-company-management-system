using System;
using System.Collections.Generic;
using com.TZMS.Business;
using com.TZMS.Model;
using ExtAspNet;
using System.Text;

namespace TZMS.Web.Pages.BankLoanPages
{
    /// <summary>
    /// ProjectProcessAdd
    /// </summary>
    public partial class ProjectProcessAdd : BasePage
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
        ///  ForOrObjectID
        /// </summary>
        public string ForOrObjectID
        {
            get
            {
                if (ViewState["ForOrObjectID"] == null)
                {
                    return null;
                }

                return ViewState["ForOrObjectID"].ToString();
            }
            set
            {
                ViewState["ForOrObjectID"] = value;
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
                ForOrObjectID = strID;

                OperateType = Request.QueryString["Type"];
                tabHistory.Hidden = true;
                if (!string.IsNullOrEmpty(OperateType) && !OperateType.Equals("Add"))
                {
                    bindInterface(strID);
                    tabHistory.Hidden = false;
                }

                // 绑定下一步.
                BindNext();
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
        /// 绑定指定 ID的数据到界面.
        /// </summary>
        /// <param name="strID"> ID</param>
        private void bindInterface(string strID)
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
                if (OperateType.Equals("View"))
                {
                    SetContrl(true);
                    this.btnSave.Hidden = true;
                    this.ddlstApproveUser.Enabled = false;
                    this.ddlstNext.Enabled = false;
                }
                else if (OperateType.Equals("Edit"))
                {
                    SetContrl(_info.IsPassImprest || !(_info.NeedImprest == 1), false);
                }

                #region 下一步方式
                //投资部总监归档
                //if (CurrentRoles.Contains(RoleType.TZZJ))
                //{
                //    BindNext(true);
                //}
                //else if (CurrentRoles.Contains(RoleType.ZJL))
                //{      //大于30w且当前审批人不是董事长，不显示下一步会计审核选项
                //    if (_info.AmountExpended >= 300000)
                //    { BindNext(false); HighMoneyTips.Text = "提醒：本次操作资金总额大于30W。"; }
                //    else
                //    { BindNext(true); }
                //}
                //else
                //{
                //   BindNext();
                //   }
                #endregion

                this.taImplementationPhase.Text = _info.ImplementationPhase;

                this.tbAmountExpended.Text = _info.AmountExpended.ToString();
                this.tbImprestAmount.Text = _info.ImprestAmount.ToString();
                this.taRemark.Text = _info.Remark;
                this.tbUse.Text = _info.Use;

                this.tbImprestRemark.Text = _info.ImprestRemark;
                // if (DateTime.Compare(_info.ExpendedTime, DateTime.Parse("1900-1-1 12:00")) != 0)
                //   {
                this.tbExpendedTime.Text = _info.ExpendedTime;
                //   }

            }
        }

        private void SetContrl(bool IsPassImprest, bool isContentDisabled = true)
        {
            if (isContentDisabled)
            {
                this.taImplementationPhase.Enabled = false;
                this.taRemark.Enabled = false;
            }

            this.cbIsAmountExpended.Enabled = false;

            if (IsPassImprest)
            {
                //如果通过了备用金审核，不能编辑
                this.tbAmountExpended.Enabled = false;
                this.tbImprestAmount.Enabled = false;
                this.tbExpendedTime.Enabled = false;
                tbUse.Enabled = false;
                tbImprestRemark.Enabled = false;
            }

            tbImprestAmount.Hidden = false;
            tbAmountExpended.Hidden = false;
            tbExpendedTime.Hidden = false;
            tbUse.Hidden = false;
            tbImprestRemark.Hidden = false;
        }

        /// <summary>
        /// 绑定历史
        /// </summary>
        private void BindHistory()
        {
            if (ForOrObjectID == null)
                return;
            // 获取数据.
            StringBuilder strCondition = new StringBuilder();
            strCondition.Append("ForId = '" + ForOrObjectID + "'");
            strCondition.Append(" ORDER BY OperationTime DESC");
            List<BankLoanProjectProcessHistoryInfo> lstInfo = new BankLoanManage().GetProcessHistoryByCondtion(strCondition.ToString());
            //lstInfo.Sort(delegate(BaoxiaoCheckInfo x, BaoxiaoCheckInfo y) { return DateTime.Compare(y.CheckDateTime, x.CheckDateTime); });

            gridHistory.RecordCount = lstInfo.Count;
            this.gridHistory.DataSource = lstInfo;
            this.gridHistory.DataBind();
        }
        #endregion

        #region 页面及控件事件
        /// <summary>
        /// 保存员工
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            saveInfo();
        }

        protected void cbIsAmountExpended_OnCheckedChanged(object sender, EventArgs e)
        {
            if (cbIsAmountExpended.Checked)
            {
                //    gpAmount.Hidden = false;
                tbImprestAmount.Hidden = false;
                tbAmountExpended.Hidden = false;
                tbExpendedTime.Hidden = false;
                tbUse.Hidden = false;
                tbImprestRemark.Hidden = false;
            }
            else
            {
                //   gpAmount.Hidden = true;
                tbImprestAmount.Hidden = true;
                tbAmountExpended.Hidden = true;
                tbExpendedTime.Hidden = true;
                tbUse.Hidden = true;
                tbImprestRemark.Hidden = true;
            }
        }
        #endregion

        #region 自定义方法
        /// <summary>
        /// 保存用户信息.
        /// </summary>
        private void saveInfo()
        {
            com.TZMS.Model.BankLoanProjectProcessInfo _Info = null;
            BankLoanManage manage = new BankLoanManage();
            //  ID.
            if (OperateType.Equals("Edit"))
            {
                _Info = manage.GetProcessByObjectID(ForOrObjectID);

                _Info.Status = _Info.NeedImprest == 1 ? 1 : 5;
            }
            else
            {
                _Info = new com.TZMS.Model.BankLoanProjectProcessInfo();
                _Info.ObjectId = Guid.NewGuid();
                _Info.ForId = new Guid(ForOrObjectID);

                var bankloan = manage.GetUserByObjectID(ForOrObjectID);
                _Info.ProjectName = bankloan.ProjectName;
                _Info.GuaranteeCompany = bankloan.CollateralCompany;

                if (cbIsAmountExpended.Checked)
                {
                    _Info.Status = 1;
                    _Info.NeedImprest = 1;
                }
                else
                {
                    _Info.Status = 5;
                    _Info.NeedImprest = 0;
                }

                //创建人
                _Info.CreateTime = DateTime.Now;
                _Info.CreaterAccount = this.CurrentUser.AccountNo;
                _Info.CreaterId = this.CurrentUser.ObjectId;
                _Info.CreaterName = this.CurrentUser.Name;
            }

            _Info.ImplementationPhase = this.taImplementationPhase.Text.Trim();
            _Info.Remark = taRemark.Text.Trim();

            //备用金部分
            if (!string.IsNullOrEmpty(tbImprestAmount.Text))
            {
                _Info.ImprestAmount = Decimal.Parse(tbImprestAmount.Text.Trim());
            }

            if (!string.IsNullOrEmpty(tbAmountExpended.Text))
            {
                _Info.AmountExpended = Decimal.Parse(tbAmountExpended.Text.Trim());
            }

            _Info.ExpendedTime = this.tbExpendedTime.Text;
            _Info.Use = this.tbUse.Text.Trim();
            _Info.ImprestRemark = this.tbImprestRemark.Text.Trim();
            //下一步
            _Info.SubmitTime = DateTime.Now;
            _Info.NextOperaterId = new Guid(this.ddlstApproveUser.SelectedValue);
            _Info.NextOperaterName = this.ddlstApproveUser.SelectedText;

            // 执行操作.
            int result = 3;
            if (OperateType.Equals("Edit"))
            {
                result = manage.UpdateProcess(_Info);
            }
            else
            {
                result = manage.AddProcess(_Info);
            }
            if (result == -1)
            {
                string strOpertationType = OperateType.Equals("Edit") ? "编辑" : "新增";
                string strDesc = string.Format("进展{0}-{1}备用金", strOpertationType, (_Info.NeedImprest == 1) ? "申请" : "无");
                manage.AddHistory(true, _Info.ObjectId, strOpertationType, strDesc, this.CurrentUser.AccountNo, this.CurrentUser.Name, DateTime.Now, _Info.Remark);

                Alert.Show("添加成功!");
                PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
            }
            else
            {
                Alert.Show("添加失败!");
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