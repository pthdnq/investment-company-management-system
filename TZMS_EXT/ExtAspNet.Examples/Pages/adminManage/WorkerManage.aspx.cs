using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.TZMS.Model;
using com.TZMS.Business;
using System.Text;
using ExtAspNet.Examples;
using ExtAspNet;
using System.Data;

namespace TZMS.Web
{
    public partial class WorkerManage : BasePage
    {
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

        /// <summary>
        /// 页面加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnNewUser.OnClientClick = wndNewUser.GetShowReference("NewUser.aspx?Type=Add", "新增员工");
                wndNewUser.OnClientCloseButtonClick = wndNewUser.GetHidePostBackReference();

                // 绑定部门.
                BindDept();

                // 绑定用户.
                DataBindUsers(ViewStateDept, ViewStateState, ViewStateSearchText);
            }
        }

        #region 私有方法

        /// <summary>
        /// 绑定部门.
        /// </summary>
        private void BindDept()
        {
            // 设置部门下拉框的值.
            ddlstDept.Items.Add(new ExtAspNet.ListItem("全部", "-1"));
            ddlstDept.Items.Add(new ExtAspNet.ListItem(TZMS.Common.DEPT.XINGZHENG, "0"));
            ddlstDept.Items.Add(new ExtAspNet.ListItem(TZMS.Common.DEPT.CAIWU, "1"));
            ddlstDept.Items.Add(new ExtAspNet.ListItem(TZMS.Common.DEPT.TOUZI, "2"));
            ddlstDept.Items.Add(new ExtAspNet.ListItem(TZMS.Common.DEPT.YEWU, "3"));

            // 设置默认值.
            ddlstDept.SelectedIndex = 0;

            ViewStateDept = ddlstDept.SelectedText;
            ViewStateState = ddlstState.SelectedText;
            ViewStateSearchText = ttbSearch.Text.Trim();
        }

        /// <summary>
        /// 绑定列表
        /// </summary>
        private void DataBindUsers(string dept, string state, string searchText)
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
            this.gridUser.RecordCount = lstUserInfo.Count;
            this.gridUser.PageSize = PageCounts;
            int currentIndex = this.gridUser.PageIndex;
            //计算当前页面显示行数据
            if (lstUserInfo.Count > this.gridUser.PageSize)
            {
                if (lstUserInfo.Count > (currentIndex + 1) * this.gridUser.PageSize)
                {
                    lstUserInfo.RemoveRange((currentIndex + 1) * this.gridUser.PageSize, lstUserInfo.Count - (currentIndex + 1) * this.gridUser.PageSize);
                }
                lstUserInfo.RemoveRange(0, currentIndex * this.gridUser.PageSize);
            }
            this.gridUser.DataSource = lstUserInfo;
            this.gridUser.DataBind();
        }

        #endregion

        #region 页面事件

        /// <summary>
        /// 翻页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridUser_PageIndexChange(object sender, ExtAspNet.GridPageEventArgs e)
        {
            this.gridUser.PageIndex = e.NewPageIndex;
            DataBindUsers(ViewStateDept, ViewStateState, ViewStateSearchText);
        }

        /// <summary>
        /// 查询事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ttbSearch_Trigger1Click(object sender, EventArgs e)
        {
            ViewStateSearchText = ttbSearch.Text.Trim();
            DataBindUsers(ViewStateDept, ViewStateState, ViewStateSearchText);
        }

        /// <summary>
        /// 部门变动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlstDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewStateDept = ddlstDept.SelectedText;
            DataBindUsers(ViewStateDept, ViewStateState, ViewStateSearchText);
        }

        /// <summary>
        /// 状态变动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlstState_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewStateState = ddlstState.SelectedText;
            DataBindUsers(ViewStateDept, ViewStateState, ViewStateSearchText);
        }

        /// <summary>
        /// 操作事件.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridUser_RowCommand(object sender, ExtAspNet.GridCommandEventArgs e)
        {
            UserManage userManage = new UserManage();
            string userID = ((GridRow)gridUser.Rows[e.RowIndex]).Values[0];
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
            else if (e.CommandName == "Role")
            {
                //wndRolesForUser.GetShowReference("RolesOfUser.aspx?ID=" + userID);
                wndRolesForUser.IFrameUrl = "RolesOfUser.aspx?ID=" + userID;
                wndRolesForUser.Hidden = false;
                return;
            }
            else if (e.CommandName == "Edit")
            {
                wndNewUser.Title = "编辑员工";
                wndNewUser.IFrameUrl = "NewUser.aspx?Type=Edit&ID=" + userID;
                wndNewUser.Hidden = false;
                return;
            }
            userManage.UpdateUser(user);

            DataBindUsers(ViewStateDept, ViewStateState, ViewStateSearchText);
        }

        /// <summary>
        /// 行绑定事件.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridUser_RowDataBound(object sender, GridRowEventArgs e)
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
        protected void wndNewUser_Close(object sender, WindowCloseEventArgs e)
        {
            DataBindUsers(ViewStateDept, ViewStateState, ViewStateSearchText);
        }

        #endregion
    }
}