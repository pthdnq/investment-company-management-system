using System;
using System.Collections.Generic;
using com.TZMS.Business;
using com.TZMS.Model;
using ExtAspNet;

namespace TZMS.Web.Pages.FolkFinancingPages
{
    /// <summary>
    /// LeaderAuditResultView
    /// </summary>
    public partial class LeaderAuditResultView : BasePage
    {
        #region 属性
        /// <summary>
        /// 操作类型
        /// </summary>
        public string OperatorType
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
        /// 用户ID
        /// </summary>
        public string UserID
        {
            get
            {
                if (ViewState["UserID"] == null)
                {
                    return null;
                }

                return ViewState["UserID"].ToString();
            }
            set
            {
                ViewState["UserID"] = value;
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

                string strOperatorType = Request.QueryString["Type"];
                string strUserID = Request.QueryString["ID"];
                switch (strOperatorType)
                {
                    case "Add":
                        {
                            OperatorType = strOperatorType;
                            // 设置新工号.
                            tbxJobNo.Text = new UserManage().GetNextJobNo();
                        }
                        break;
                    case "Edit":
                        {
                            OperatorType = strOperatorType;
                            UserID = strUserID;

                            bindUserInterface(strUserID);
                        }
                        break;
                    default:
                        break;
                }
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
            ddlstDept.Items.Add(new ExtAspNet.ListItem(TZMS.Common.DEPT.XINGZHENG, "行政部"));
            ddlstDept.Items.Add(new ExtAspNet.ListItem(TZMS.Common.DEPT.CAIWU, "财务部"));
            ddlstDept.Items.Add(new ExtAspNet.ListItem(TZMS.Common.DEPT.TOUZI, "投资部"));
            ddlstDept.Items.Add(new ExtAspNet.ListItem(TZMS.Common.DEPT.YEWU, "业务部"));

            // 设置默认值.
            ddlstDept.SelectedIndex = 0;
        }

        /// <summary>
        /// 绑定指定用户ID的数据到界面.
        /// </summary>
        /// <param name="strUserID">用户ID</param>
        private void bindUserInterface(string strUserID)
        {
            if (string.IsNullOrEmpty(strUserID))
            {
                return;
            }

            // 通过用户ID获取用户信息实例.
            UserInfo _userInfo = new UserManage().GetUserByObjectID(strUserID);

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
                // 学历.
                ddlstEducational.SelectedValue = _userInfo.Educational;
                // 工作年限.
                tbxWorkYear.Text = _userInfo.WorkYear == -1 ? "" : _userInfo.WorkYear.ToString();
                // 员工状态.
                rblState.SelectedIndex = _userInfo.State == 1 ? 0 : 1;
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
            if (string.IsNullOrEmpty(OperatorType))
            {
                return;
            }

            UserInfo _userInfo = null;
            UserManage _userManage = new UserManage();

            // 判断操作类型.
            if (OperatorType == "Add")
            {
                _userInfo = new UserInfo();

                // 用户ID.
                _userInfo.ObjectId = Guid.NewGuid();
            }
            else
            {
                _userInfo = _userManage.GetUserByObjectID(UserID);
                if (_userInfo == null)
                {
                    return;
                }
            }

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
            if (OperatorType == "Add")
            {
                result = _userManage.AddUser(_userInfo);
                if (result == -1)
                {
                    new RolesManage().AddRoles(new UserRoles()
                    {
                        UserObjectId = _userInfo.ObjectId,
                        AccountNo = _userInfo.AccountNo,
                        JobNo = _userInfo.JobNo,
                        Name = _userInfo.Name,
                        Roles = "12"
                    });
                    Alert.Show("添加员工成功!");
                }
                else
                {
                    Alert.Show("添加员工失败!");
                }
            }
            else
            {
                result = _userManage.UpdateUser(_userInfo);
                if (result == -1)
                {
                    Alert.Show("编辑员工成功!");
                }
                else
                {
                    Alert.Show("编辑员工失败!");
                }
            }
        }

        #endregion
    }
}