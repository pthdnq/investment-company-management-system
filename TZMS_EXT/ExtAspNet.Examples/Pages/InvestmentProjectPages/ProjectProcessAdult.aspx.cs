using System;
using System.Collections.Generic;
using com.TZMS.Business;
using com.TZMS.Model;
using ExtAspNet;

namespace TZMS.Web.Pages.InvestmentProjectPages
{
    public partial class ProjectProcessAdult : BasePage
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

            }
        }
        #endregion

        #region 页面及控件事件
        protected void btnDismissed_Click(object sender, EventArgs e)
        {
            saveInfo(2);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            saveInfo(3);
        }
        #endregion

        #region 自定义方法
        /// <summary>
        /// 保存 信息.
        /// </summary>
        private void saveInfo(int status)
        {
            InvestmentProjectManage manage = new InvestmentProjectManage();

            com.TZMS.Model.ProjectProcessInfo _info = manage.GetProcessByObjectID(ObjectID);
            _info.AuditOpinion = this.taAuditOpinion.Text.Trim();
            _info.Status = status;

            // 执行操作.
            int result = 3;

            result = manage.UpdateProcess(_info);
            if (result == -1)
            {
                Alert.Show("编辑员工成功!");
            }
            else
            {
                Alert.Show("编辑员工失败!");
            }
        }


        #endregion
    }
}