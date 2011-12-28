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
    public partial class MyMessage : BasePage
    {
        /// <summary>
        /// 页面加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.btnSave.Enabled = false;
                BindDept();
                bindUserInterface();
                this.btnSave.Enabled = true;
            }
        }

        #region 私有方法

        /// <summary>
        /// 绑定部门.
        /// </summary>
        private void BindDept()
        {
            // 设置部门下拉框的值.
            ddlstDept.Items.Add(new ExtAspNet.ListItem(TZMS.Common.DEPT.XINGZHENG, "行政部"));
            ddlstDept.Items.Add(new ExtAspNet.ListItem(TZMS.Common.DEPT.CAIWU, "财务部"));
            ddlstDept.Items.Add(new ExtAspNet.ListItem(TZMS.Common.DEPT.TOUZI, "投资部"));
            ddlstDept.Items.Add(new ExtAspNet.ListItem(TZMS.Common.DEPT.YEWU, "业务部"));
            ddlstDept.Items.Add(new ExtAspNet.ListItem(TZMS.Common.DEPT.ZJB, "总经办"));
            ddlstDept.Items.Add(new ExtAspNet.ListItem(TZMS.Common.DEPT.JSZX, "结算中心"));

            // 设置默认值.
            ddlstDept.SelectedIndex = 0;
        }

        /// <summary>
        /// 绑定指定用户ID的数据到界面.
        /// </summary>
        private void bindUserInterface()
        {

            // 通过用户ID获取用户信息实例.
            UserInfo _userInfo = CurrentUser;

            // 绑定数据.
            if (_userInfo != null)
            {
                // 账号.
                tbxAccountNo.Text = _userInfo.AccountNo;
                // 工号. 
                tbxJobNo.Text = _userInfo.JobNo;
                // 姓名.        
                tbxName.Text = _userInfo.Name;
                // 性别.          
                rblSex.SelectedIndex = _userInfo.Sex ? 0 : 1;
                // 部门.
                ddlstDept.SelectedValue = _userInfo.Dept;
                // 职位.
                tbxPosition.Text = _userInfo.Position;
                // 入职时间.
                if (DateTime.Compare(_userInfo.EntryDate, DateTime.Parse("1900-1-1 12:00")) != 0)
                {
                    dpkEntryDate.SelectedDate = _userInfo.EntryDate;
                }
                // 出生日期.
                if (DateTime.Compare(_userInfo.Birthday, DateTime.Parse("1900-1-1 12:00")) != 0)
                {
                    dpkBirthday.SelectedDate = _userInfo.Birthday;
                }
                // 基本工资.
                tbxBaseSalary.Text = _userInfo.BaseSalary.ToString();
                // 学历.
                ddlstEducational.SelectedValue = _userInfo.Educational;
                // 工作年限.
                tbxWorkYear.Text = _userInfo.WorkYear == -1 ? "" : _userInfo.WorkYear.ToString();
                // 员工状态.
                rblState.SelectedIndex = _userInfo.State == 1 ? 0 : 1;
                // 转正状态.
                rblProbationState.SelectedIndex = _userInfo.IsProbation == true ? 0 : 1;
                if (rblProbationState.SelectedIndex != 0)
                {
                    dpbProbationTime.Hidden = true;
                }
                // 转正日期.
                if (DateTime.Compare(_userInfo.ProbationTime, ACommonInfo.DBMAXDate) != 0)
                {
                    dpbProbationTime.SelectedDate = _userInfo.ProbationTime;
                }
                //离职时间
                if (_userInfo.State != 0)
                {
                    dpkLeaveTime.Hidden = true;
                }
                else
                {
                    if (DateTime.Compare(_userInfo.LeaveTime, ACommonInfo.DBMAXDate) != 0)
                    {
                        dpkLeaveTime.SelectedDate = _userInfo.LeaveTime;
                    }
                }
                // 联系电话.
                tbxPhoneNumber.Text = _userInfo.PhoneNumber;
                // 备用联系电话.
                tbxBackupPhoneNumber.Text = _userInfo.BackIpPhoneNumber;
                // 电子邮箱.
                tbxEmail.Text = _userInfo.Email;
                // 住址.
                tbxAddress.Text = _userInfo.Address;
            }
        }

        /// <summary>
        /// 保存用户信息.
        /// </summary>
        private void saveUserInfo()
        {

            UserInfo _userInfo = CurrentUser;
            UserManage _userManage = new UserManage();

            // 账号.
            _userInfo.AccountNo = tbxAccountNo.Text.Trim();
            // 工号. 
            _userInfo.JobNo = tbxJobNo.Text.Trim();
            // 姓名.        
            _userInfo.Name = tbxName.Text.Trim();
            // 性别.          
            _userInfo.Sex = rblSex.SelectedIndex == 0 ? true : false;
            // 部门.
            _userInfo.Dept = ddlstDept.SelectedValue;
            // 职位.
            _userInfo.Position = tbxPosition.Text.Trim();
            // 入职时间.
            if (dpkEntryDate.SelectedDate is DateTime)
            {
                _userInfo.EntryDate = Convert.ToDateTime(dpkEntryDate.SelectedDate);
            }
            // 出生日期.
            if (dpkBirthday.SelectedDate is DateTime)
            {
                _userInfo.Birthday = Convert.ToDateTime(dpkBirthday.SelectedDate);
            }
            // 学历.
            _userInfo.Educational = ddlstEducational.SelectedValue;
            // 工作年限.
            if (!string.IsNullOrEmpty(tbxWorkYear.Text.Trim()))
            {
                _userInfo.WorkYear = short.Parse(tbxWorkYear.Text.Trim());
            }
            // 员工状态.
            _userInfo.State = rblState.SelectedIndex == 0 ? (short)1 : (short)0;
            // 联系电话.
            _userInfo.PhoneNumber = tbxPhoneNumber.Text.Trim();
            // 备用联系电话.
            _userInfo.BackIpPhoneNumber = tbxBackupPhoneNumber.Text.Trim();
            // 电子邮箱.
            _userInfo.Email = tbxEmail.Text.Trim();
            // 住址.
            _userInfo.Address = tbxAddress.Text.Trim();

            // 在数据库中查看具有相同工号或账号的用户，如果存在，则添加失败.
            List<UserInfo> lstSameUsers = _userManage.GetUsersByCondtion("ObjectID <> '" + _userInfo.ObjectId.ToString() +
                "' and (JobNo = '" + _userInfo.JobNo + "' or AccountNo = '" + _userInfo.AccountNo + "')");
            if (lstSameUsers.Count > 0)
            {
                Alert.Show("该账号或工号已存在!");
                return;
            }

            // 执行操作.
            int result = 3;

            result = _userManage.UpdateUser(_userInfo);
            if (result == -1)
            {
                CurrentUser = _userInfo;
                Alert.Show("保存成功!");
            }
            else
            {
                Alert.Show("保存成功失败!");
            }
        }
        #endregion

        #region

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
    }
}