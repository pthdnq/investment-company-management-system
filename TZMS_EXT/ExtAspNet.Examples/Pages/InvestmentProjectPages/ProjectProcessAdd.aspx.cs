﻿using System;
using System.Collections.Generic;
using com.TZMS.Business;
using com.TZMS.Model;
using ExtAspNet;
using System.Text;

namespace TZMS.Web.Pages.InvestmentProjectPages
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
                if (ViewState["ForID"] == null)
                {
                    return null;
                }

                return ViewState["ForID"].ToString();
            }
            set
            {
                ViewState["ForID"] = value;
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
                if (OperateType.Equals("Add"))
                {
                    SetImprestAmount(false);
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
            com.TZMS.Model.ProjectProcessInfo _Info = new InvestmentProjectManage().GetProcessByObjectID(strID);

            if (OperateType.Equals("View"))
            {
                SetContrl(true);
                this.btnSave.Hidden = true;

                this.ddlstApproveUser.Items.Add(new ListItem() { Text = _Info.NextOperaterName, Value = "0", Selected = true });
                this.ddlstApproveUser.Enabled = false;
                this.ddlstNext.Enabled = false;
            }
            else if (OperateType.Equals("Edit"))
            {
                SetContrl(_Info.IsPassImprest || !_Info.NeedImprest, false);
            }

            // 绑定数据.
            if (_Info != null)
            {
                #region 下一步方式
                //投资部总监可以归档
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
                // BindNext();
                //    }
                #endregion
                this.cbIsAmountExpended.Checked = _Info.NeedImprest;

                this.tbImplementationPhase.Text = _Info.ImplementationPhase;
                this.tbAmountExpended.Text = _Info.AmountExpended.ToString();
                this.tbImprestAmount.Text = _Info.ImprestAmount.ToString();
                this.taRemark.Text = _Info.Remark;

                //if (DateTime.Compare(_info.ExpendedTime, DateTime.Parse("1900-1-1 12:00")) != 0)
                //{
                this.tbExpendedTime.Text = _Info.ExpendedTime;

                this.tbUse.Text = _Info.Use;
                this.tbImprestRemark.Text = _Info.ImprestRemark;
                // } 
            }
        }

        private void SetContrl(bool IsPassImprest, bool isContentDisabled = true)
        {
            if (isContentDisabled)
            {
                this.tbImplementationPhase.Enabled = false;
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
            List<ProjectProcessHistoryInfo> lstInfo = new InvestmentProjectManage().GetProcessHistoryByCondtion(strCondition.ToString());
            //lstInfo.Sort(delegate(BaoxiaoCheckInfo x, BaoxiaoCheckInfo y) { return DateTime.Compare(y.CheckDateTime, x.CheckDateTime); });

            gridHistory.RecordCount = lstInfo.Count;
            this.gridHistory.DataSource = lstInfo;
            this.gridHistory.DataBind();
        }

        /// <summary>
        /// 设置备用金信息 标签是否必填（true：必填，false：不要求必须填写）
        /// </summary>
        /// <param name="flag"></param>
        private void SetImprestAmount(bool flag)
        {
            tbImprestAmount.Required = flag;
            tbAmountExpended.Required = flag;
            tbExpendedTime.Required = flag;
            tbUse.Required = flag;

        }

        #endregion

        #region 页面及控件事件

        /// <summary>
        /// 是否备用金
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            //SetImprestAmount(cbIsAmountExpended.Checked);
        }

        /// <summary>
        /// 保存员工
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (cbIsAmountExpended.Checked)
            {
                if (string.IsNullOrEmpty(tbImprestAmount.Text.Trim()))
                {
                    Alert.Show("备用金额 必填");
                    return;
                }
                if (string.IsNullOrEmpty(tbAmountExpended.Text.Trim()))
                {
                    Alert.Show("预支金额 必填");
                    return;
                }
                if (string.IsNullOrEmpty(tbExpendedTime.Text.Trim()))
                {
                    Alert.Show("支用时间 必填");
                    return;
                }
                if (string.IsNullOrEmpty(tbUse.Text.Trim()))
                {
                    Alert.Show("用途 必填");
                    return;
                }

                //有备用金
                saveInfo(1);
            }
            else
            {
                //无备用金
                saveInfo(5);
            }
        }
        #endregion

        #region 自定义方法
        /// <summary>
        /// 保存用户信息.
        /// </summary>
        private void saveInfo(int status)
        {
            com.TZMS.Model.ProjectProcessInfo _Info = null;
            InvestmentProjectManage manage = new InvestmentProjectManage();

            //  ID.
            if (OperateType.Equals("Edit"))
            {
                _Info = manage.GetProcessByObjectID(ForOrObjectID);

                _Info.Status = _Info.NeedImprest ? (_Info.IsPassImprest ? 5 : 1) : 5;
            }
            else
            {
                _Info = new com.TZMS.Model.ProjectProcessInfo();
                _Info.ObjectId = Guid.NewGuid();
                _Info.ForId = new Guid(ForOrObjectID);

                //创建人
                _Info.CreateTime = DateTime.Now;
                _Info.CreaterId = this.CurrentUser.ObjectId;
                _Info.CreaterName = this.CurrentUser.Name;
                _Info.CreaterAccount = this.CurrentUser.AccountNo;

                _Info.ProjectName = manage.GetUserByObjectID(ForOrObjectID).ProjectName;

                _Info.Status = status;
                _Info.NeedImprest = this.cbIsAmountExpended.Checked;
                //保存第一个审批人
                _Info.FirstOperaterID = new Guid(this.ddlstApproveUser.SelectedValue);
                _Info.FirstOperaterName = this.ddlstApproveUser.SelectedText;
            }



            _Info.ImplementationPhase = this.tbImplementationPhase.Text.Trim();
            _Info.Remark = taRemark.Text.Trim();

            _Info.ExpendedTime = this.tbExpendedTime.Text.Trim();
            _Info.Use = this.tbUse.Text.Trim();
            if (!string.IsNullOrEmpty(tbAmountExpended.Text))
            {
                _Info.AmountExpended = Decimal.Parse(tbAmountExpended.Text.Trim());
                _Info.PrepaidAmount = Decimal.Parse(tbAmountExpended.Text.Trim());
            }
            if (!string.IsNullOrEmpty(tbImprestAmount.Text))
            {
                _Info.ImprestAmount = Decimal.Parse(tbImprestAmount.Text.Trim());
            }
            _Info.ImprestRemark = this.tbImprestRemark.Text.Trim();



            //下一步操作
            _Info.NextOperaterName = this.ddlstApproveUser.SelectedText;
            _Info.NextOperaterId = new Guid(this.ddlstApproveUser.SelectedValue);
            _Info.SubmitTime = DateTime.Now;
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
                string strDesc = string.Format("进展{0}-{1}备用金", strOpertationType, (_Info.NeedImprest) ? "申请" : "无");

                manage.AddHistory(true, _Info.ObjectId, strOpertationType, strDesc, this.CurrentUser.AccountNo, this.CurrentUser.Name, DateTime.Now, _Info.Remark);


              //  if (cbIsAmountExpended.Checked)
                if (_Info.NeedImprest)
                {
                    //备用金审核
                    CheckMsg(ddlstApproveUser.SelectedValue.ToString(), ddlstApproveUser.SelectedText, "备用金审核列表（集团外项目）");
                }
                else
                {
                    //信息审核
                    CheckMsg(ddlstApproveUser.SelectedValue.ToString(), ddlstApproveUser.SelectedText, "进展审核列表（集团外项目）");
                }

                //Alert.Show("添加成功!");
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