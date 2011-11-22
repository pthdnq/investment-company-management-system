using System;
using System.Collections.Generic;
using com.TZMS.Business;
using com.TZMS.Model;
using ExtAspNet;
using System.Text;

namespace TZMS.Web.Pages.InvestmentProjectPages
{
    /// <summary>
    /// ProjectInfo进展
    /// </summary>
    public partial class ProjectInfo : BasePage
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

        /// <summary>
        /// 用于存储部门名称的ViewState.
        /// </summary>
        public string ViewStateDept
        {
            get
            {
                if (ViewState["Dept"] == null)
                {
                    return null;
                }

                return ViewState["Dept"].ToString();
            }
            set
            {
                ViewState["Dept"] = value;
            }
        }

        /// <summary>
        /// 用于存储员工状态的ViewState.
        /// </summary>
        public string ViewStateState
        {
            get
            {
                if (ViewState["State"] == null)
                {
                    return null;
                }

                return ViewState["State"].ToString();
            }
            set
            {
                ViewState["State"] = value;
            }
        }

        /// <summary>
        /// 用于存储搜索文本的ViewState.
        /// </summary>
        public string ViewStateSearchText
        {
            get
            {
                if (ViewState["SearchText"] == null)
                {
                    return null;
                }

                return ViewState["SearchText"].ToString();
            }
            set
            {
                ViewState["SearchText"] = value;
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
                        //    tbxJobNo.Text = new UserManage().GetNextJobNo();
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

            this.btnNew.OnClientClick = wndNew.GetShowReference("ProjectProcessAdd.aspx?Type=Add", "新增 - 项目进度");
            this.wndNew.OnClientCloseButtonClick = wndNew.GetHidePostBackReference();

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
               
                // 部门.
                ddlstDept.SelectedValue = _userInfo.Dept;
                // 职位.
          
                
            }
        }

        /// <summary>
        /// 绑定列表
        /// </summary>
        private void BindGridData(string dept, string state, string searchText)
        {
            #region 条件

            StringBuilder strCondtion = new StringBuilder();
            if (!string.IsNullOrEmpty(dept) && dept != "全部")
            {
                strCondtion.Append(" dept='" + dept + "' and ");
            }
            if (!string.IsNullOrEmpty(state))
            {
                strCondtion.Append(" state=" + (state == "在职" ? 1 : 0) + " and ");
            }
            if (!string.IsNullOrEmpty(searchText))
            {
                strCondtion.Append(" (name like '%" + searchText + "%' or AccountNo like '%" + searchText + "%') and ");
            }
            //未删除
            strCondtion.Append(" state<>2 ");

            #endregion

            //获得员工
            List<UserInfo> lstUserInfo = new UserManage().GetUsersByCondtion(strCondtion.ToString());
            this.gridData.RecordCount = lstUserInfo.Count;
            this.gridData.PageSize = PageCounts;
            int currentIndex = this.gridData.PageIndex;
            //计算当前页面显示行数据
            if (lstUserInfo.Count > this.gridData.PageSize)
            {
                if (lstUserInfo.Count > (currentIndex + 1) * this.gridData.PageSize)
                {
                    lstUserInfo.RemoveRange((currentIndex + 1) * this.gridData.PageSize, lstUserInfo.Count - (currentIndex + 1) * this.gridData.PageSize);
                }
                lstUserInfo.RemoveRange(0, currentIndex * this.gridData.PageSize);
            }
            this.gridData.DataSource = lstUserInfo;
            this.gridData.DataBind();
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

        /// <summary>
        /// 查询事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ttbSearch_Trigger1Click(object sender, EventArgs e)
        {
            ViewStateSearchText = this.ttbSearch.Text.Trim();
            BindGridData(ViewStateDept, ViewStateState, ViewStateSearchText);
        }

        /// <summary>
        /// 翻页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridData_PageIndexChange(object sender, ExtAspNet.GridPageEventArgs e)
        {
            this.gridData.PageIndex = e.NewPageIndex;
            BindGridData(ViewStateDept, ViewStateState, ViewStateSearchText);
        }

        /// <summary>
        /// 部门变动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlstDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewStateDept = this.ddlstDept.SelectedText;
            BindGridData(ViewStateDept, ViewStateState, ViewStateSearchText);
        }

        /// <summary>
        /// 状态变动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlstState_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewStateState = this.ddlstState.SelectedText;
            BindGridData(ViewStateDept, ViewStateState, ViewStateSearchText);
        }

        /// <summary>
        /// 操作事件.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridData_RowCommand(object sender, GridCommandEventArgs e)
        {
            UserManage userManage = new UserManage();
            string userID = ((GridRow)gridData.Rows[e.RowIndex]).Values[0];

            UserInfo user = userManage.GetUserByObjectID(userID);

            if (e.CommandName == "Leave")
            {
                // 离职
                user.State = 0;
            }
            else if (e.CommandName == "Delete")
            {
                // 删除
                user.State = 2;
            }
            else if (e.CommandName == "Edit")
            {
                this.wndNew.Title = "编辑员工";
                this.wndNew.IFrameUrl = "NewUser.aspx?Type=Edit&ID=" + userID;
                this.wndNew.Hidden = false;
                return;
            }
            userManage.UpdateUser(user);

            BindGridData(ViewStateDept, ViewStateState, ViewStateSearchText);
        }

        /// <summary>
        /// 行绑定事件.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridData_RowDataBound(object sender, GridRowEventArgs e)
        {
            UserInfo _userInfo = (UserInfo)e.DataItem;

            if (_userInfo.State == 0)
            {
                e.Values[9] = "<span class=\"gray\">权限</span>";
                e.Values[10] = "<span class=\"gray\">离职</span>";
            }
        }

        /// <summary>
        /// 关闭新增员工页面. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void wndNew_Close(object sender, WindowCloseEventArgs e)
        {
            BindGridData(ViewStateDept, ViewStateState, ViewStateSearchText);
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
        
            // 部门.
            _userInfo.Dept = ddlstDept.SelectedValue;
           
         
            //// 出生日期.
            //if (dpkBirthday.SelectedDate is DateTime)
            //{
            //    _userInfo.Birthday = Convert.ToDateTime(dpkBirthday.SelectedDate);
            //}
           
            //// 工作年限.
            //if (!string.IsNullOrEmpty(tbxWorkYear.Text.Trim()))
            //{
            //    _userInfo.WorkYear = short.Parse(tbxWorkYear.Text.Trim());
            //}
          

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