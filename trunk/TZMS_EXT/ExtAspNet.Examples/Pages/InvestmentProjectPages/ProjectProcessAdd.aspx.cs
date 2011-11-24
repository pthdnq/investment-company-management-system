using System;
using System.Collections.Generic;
using com.TZMS.Business;
using com.TZMS.Model;
using ExtAspNet;

namespace TZMS.Web.Pages.InvestmentProjectPages
{
    /// <summary>
    /// ProjectProcessAdd
    /// </summary>
    public partial class ProjectProcessAdd : BasePage
    {
        #region 属性

        /// <summary>
        ///  ID
        /// </summary>
        public string ForID
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
                BindDept();

                string strID = Request.QueryString["ID"];

                ForID = strID;

           
            }
        }

        private void InitControl()
        {
            this.btnClose.OnClientClick = ActiveWindow.GetConfirmHidePostBackReference();
        }

        /// <summary>
        /// 绑定部门.
        /// </summary>
        private void BindDept()
        {
            // 设置部门下拉框的值.
            //ddlstDept.Items.Add(new ExtAspNet.ListItem(TZMS.Common.DEPT.XINGZHENG, "行政部"));
            //ddlstDept.Items.Add(new ExtAspNet.ListItem(TZMS.Common.DEPT.CAIWU, "财务部"));
            //ddlstDept.Items.Add(new ExtAspNet.ListItem(TZMS.Common.DEPT.TOUZI, "投资部"));
            //ddlstDept.Items.Add(new ExtAspNet.ListItem(TZMS.Common.DEPT.YEWU, "业务部"));

            //// 设置默认值.
            //ddlstDept.SelectedIndex = 0;
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
            saveUserInfo();
        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 保存用户信息.
        /// </summary>
        private void saveUserInfo()
        {
            com.TZMS.Model.ProjectProcessInfo info = new com.TZMS.Model.ProjectProcessInfo();
            InvestmentProjectManage manage = new InvestmentProjectManage();

            //  ID.
            info.ObjetctId = Guid.NewGuid();
            info.ForId = new Guid(ForID);
             
            info.ProjectName = manage.GetUserByObjectID(ForID).ProjectName;
             
            if (dpExpendedTime.SelectedDate is DateTime)
            {
                info.ExpendedTime = this.dpExpendedTime.SelectedDate.Value;
            }

            if (!string.IsNullOrEmpty(tbAmountExpended.Text))
            {
                info.AmountExpended = Decimal.Parse(tbAmountExpended.Text.Trim());
            }
            if (!string.IsNullOrEmpty(tbImprestAmount.Text))
            {
                info.ImprestAmount = Decimal.Parse(tbImprestAmount.Text.Trim());
            }
            info.ImplementationPhase = this.tbImplementationPhase.Text.Trim();
            info.Remark = taRemark.Text.Trim();

            info.CreateTime = DateTime.Now;
            info.SubmitTime = DateTime.Now;
            info.Status = 1;


            // 执行操作.
            int result = 3;

            result = manage.AddProcess(info);
            if (result == -1)
            {
                Alert.Show("添加成功!");
                PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
            }
            else
            {
                Alert.Show("添加失败!");
            }

        }

        #endregion
    }
}