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
                // 绑定部门.
                BindDept();

                // 绑定用户.
                DataBindUsers(ViewState["Dept"].ToString(), ViewState["State"].ToString(), ViewState["SearchText"].ToString());
            }
        }

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

            ViewState["Dept"] = ddlstDept.SelectedText;
            ViewState["State"] = ddlstState.SelectedText;
            ViewState["SearchText"] = ttbSearch.Text.Trim();
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

        /// <summary>
        /// 翻页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridUser_PageIndexChange(object sender, ExtAspNet.GridPageEventArgs e)
        {
            this.gridUser.PageIndex = e.NewPageIndex;
            DataBindUsers(ViewState["Dept"].ToString(), ViewState["State"].ToString(), ViewState["SearchText"].ToString());
        }

        /// <summary>
        /// 查询事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ttbSearch_Trigger1Click(object sender, EventArgs e)
        {
            ViewState["SearchText"] = ttbSearch.Text.Trim();
            DataBindUsers(ViewState["Dept"].ToString(), ViewState["State"].ToString(), ViewState["SearchText"].ToString());
        }

        /// <summary>
        /// 部门变动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlstDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewState["Dept"] = ddlstDept.SelectedText;
            DataBindUsers(ViewState["Dept"].ToString(), ViewState["State"].ToString(), ViewState["SearchText"].ToString());
        }

        /// <summary>
        /// 状态变动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlstState_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewState["State"] = ddlstState.SelectedText;
            DataBindUsers(ViewState["Dept"].ToString(), ViewState["State"].ToString(), ViewState["SearchText"].ToString());
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
            userManage.UpdateUser(user);

            DataBindUsers(ViewState["Dept"].ToString(), ViewState["State"].ToString(), ViewState["SearchText"].ToString());
        }
    }
}