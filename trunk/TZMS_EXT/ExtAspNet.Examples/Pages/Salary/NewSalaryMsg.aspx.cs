using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExtAspNet;
using com.TZMS.Model;
using com.TZMS.Business;

namespace TZMS.Web
{
    public partial class NewSalaryMsg : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindYear();

                ddlstYear.SelectedValue = DateTime.Now.Year.ToString();
                ddlstMonth.SelectedValue = DateTime.Now.Month.ToString();
            }
        }

        #region 私有方法

        /// <summary>
        /// 绑定年
        /// </summary>
        private void BindYear()
        {
            int year = DateTime.Now.Year;
            string tempString = string.Empty;
            for (int i = -3; i < 2; i++)
            {
                tempString = (year + i).ToString();
                ddlstYear.Items.Add(new ExtAspNet.ListItem(tempString, tempString));
            }
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
        /// 保存事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SalaryManage _manage = new SalaryManage();
            List<SalaryMsgInfo> lstSalaryMsg = _manage.GetSalaryMsgByCondition(" Year = " + ddlstYear.SelectedValue + " and Month = " + ddlstMonth.SelectedValue);
            if (lstSalaryMsg.Count > 0)
            {
                Alert.Show("该日期的薪资信息已经存在!");
                return;
            }

            SalaryMsgInfo _salaryMsgInfo = new SalaryMsgInfo();
            _salaryMsgInfo.ObjectId = Guid.NewGuid();
            _salaryMsgInfo.Year = Convert.ToInt32(ddlstYear.SelectedValue);
            _salaryMsgInfo.Month = Convert.ToInt16(ddlstMonth.SelectedValue);
            _salaryMsgInfo.CreateTime = ACommonInfo.DBMAXDate;
            _salaryMsgInfo.CreaterId = CurrentUser.ObjectId;
            _salaryMsgInfo.Name = CurrentUser.Name;
            _salaryMsgInfo.State = -1;

            int result = _manage.AddNewSalaryMsg(_salaryMsgInfo);
            if (result == -1)
            {
                // 生成员工薪资信息.
                List<UserInfo> lstUser = new UserManage().GetUsersByCondtion(" State = 1");
                WorkerSalaryMsgInfo _workerSalaryInfo = null;
                foreach (UserInfo user in lstUser)
                {
                    _workerSalaryInfo = new WorkerSalaryMsgInfo();
                    _workerSalaryInfo.ObjectId = Guid.NewGuid();
                    _workerSalaryInfo.UserId = user.ObjectId;
                    _workerSalaryInfo.Name = user.Name;
                    _workerSalaryInfo.Dept = user.Dept;
                    //_workerSalaryInfo.BaseSalary = user.BaseSalary;
                    _workerSalaryInfo.Jbgz = user.BaseSalary.ToString();
                    _workerSalaryInfo.SalaryMsgId = _salaryMsgInfo.ObjectId;

                    _manage.AddNewWorkerSalaryMsg(_workerSalaryInfo);
                }

                this.btnClose_Click(null, null);
            }
            else
            {
                Alert.Show("薪资信息创建失败!");
            }
        }

        #endregion
    }
}