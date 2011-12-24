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
                DataGrid();
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
            ddlstDept.Items.Add(new ExtAspNet.ListItem(TZMS.Common.DEPT.ZJB, "4"));
            ddlstDept.Items.Add(new ExtAspNet.ListItem(TZMS.Common.DEPT.JSZX, "5"));

            // 设置默认值.
            ddlstDept.SelectedIndex = 0;
        }

        /// <summary>
        /// 绑定列表
        /// </summary>
        private void DataGrid()
        {
            #region 条件

            StringBuilder strCondtion = new StringBuilder();
            if (ddlstDept.SelectedIndex != 0)
            {
                strCondtion.Append(" dept='" + ddlstDept.SelectedText + "' and ");
            }

            strCondtion.Append(" state=" + ddlstState.SelectedValue + " and ");
            if (!string.IsNullOrEmpty(tbxSearch.Text.Trim()))
            {
                strCondtion.Append(" (name like '%" + tbxSearch.Text.Trim() + "%' or AccountNo like '%" + tbxSearch.Text.Trim() + "%') and ");
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
            DataGrid();
        }

        /// <summary>
        /// 查询事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            DataGrid();
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
            else if (e.CommandName == "Menu")
            {
                wndMenu.IFrameUrl = "Menu.aspx?ID=" + userID;
                wndMenu.Hidden = false;
                return;
            }
            userManage.UpdateUser(user);

            DataGrid();
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
                e.Values[11] = "<span class=\"gray\">权限</span>";
                e.Values[12] = "<span class=\"gray\">离职</span>";
            }
            else
            {
                e.Values[12] = e.Values[12].ToString().Replace("msg:'确定该员工离职?'", "msg:'确定" + e.Values[2].ToString() + "离职?'");
                e.Values[13] = e.Values[13].ToString().Replace("msg:'确定删除该员工?'", "msg:'确定删除" + e.Values[2].ToString() + "?'");
            }
        }

        /// <summary>
        /// 关闭新增员工页面. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void wndNewUser_Close(object sender, WindowCloseEventArgs e)
        {
            DataGrid();
        }

        /// <summary>
        /// 菜单关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void wndMenu_Close(object sender, WindowCloseEventArgs e)
        {

        }

        #endregion
    }
}