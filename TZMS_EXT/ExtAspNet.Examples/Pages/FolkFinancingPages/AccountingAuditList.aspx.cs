﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.TZMS.Business;
using com.TZMS.Model;
using ExtAspNet;

namespace TZMS.Web.Pages.FolkFinancingPages
{
    /// <summary>
    /// 会计审核列表
    /// </summary>
    public partial class AccountingAuditList : BasePage
    {
        #region viewstate
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

        #region 页面加载及初始化
        /// <summary>
        /// 页面加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
              //  this.btnNew.OnClientClick = wndNew.GetShowReference("FinancingApplyAdd.aspx?Type=Add", "新增 - 民间融资");
                this.wndNew.OnClientCloseButtonClick = wndNew.GetHideReference();

                // 绑定下拉框.
                //BindDDL();
                // 绑定列表.
                BindGridData(ViewStateDept, ViewStateState, ViewStateSearchText);
            }
        }

        /// <summary>
        /// 绑定下拉框.
        /// </summary>
        private void BindDDL()
        {
            // 设置部门下拉框的值.
            //this.ddlstDept.Items.Add(new ExtAspNet.ListItem("全部", "-1"));
            //this.ddlstDept.Items.Add(new ExtAspNet.ListItem(TZMS.Common.DEPT.XINGZHENG, "0"));
            //this.ddlstDept.Items.Add(new ExtAspNet.ListItem(TZMS.Common.DEPT.CAIWU, "1"));
            //this.ddlstDept.Items.Add(new ExtAspNet.ListItem(TZMS.Common.DEPT.TOUZI, "2"));
            //this.ddlstDept.Items.Add(new ExtAspNet.ListItem(TZMS.Common.DEPT.YEWU, "3"));

            //// 设置默认值.
            //this.ddlstDept.SelectedIndex = 0;

            ViewStateDept = ddlstDept.SelectedText;
            ViewStateState = ddlstState.SelectedText;
            ViewStateSearchText = ttbSearch.Text.Trim();
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
                strCondtion.Append(" Status='" + dept + "' and ");
            }
            if (!string.IsNullOrEmpty(state))
            {
                strCondtion.Append(" Status " + (state == "待审核" ? " = 1 " : " <> 1 ") + " and ");
            }
            if (!string.IsNullOrEmpty(searchText))
            {
                strCondtion.Append(" (ProjectName like '%" + searchText + "%' or BorrowerNameA like '%" + searchText + "%') and ");
            }
            //未删除
            strCondtion.Append(" Status<>9 ");
            strCondtion.Append(" AND NextOperaterId = '" + this.CurrentUser.ObjectId + "' "); 
            #endregion

            //获得员工
            List<FolkFinancingInfo> lstUserInfo = new FolkFinancingManage().GetUsersByCondtion(strCondtion.ToString());
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

        /// <summary>
        /// 行绑定事件.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridData_RowDataBound(object sender, GridRowEventArgs e)
        {
            //UserInfo _userInfo = (UserInfo)e.DataItem;

            //if (_userInfo.State == 0)
            //{
            //    e.Values[9] = "<span class=\"gray\">权限</span>";
            //    e.Values[10] = "<span class=\"gray\">离职</span>";
            //}
        }
        #endregion

        #region 页面事件

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
            FolkFinancingManage manage = new FolkFinancingManage();
            string userID = ((GridRow)gridData.Rows[e.RowIndex]).Values[0];

            FolkFinancingInfo info = manage.GetUserByObjectID(userID);

            if (e.CommandName == "Leave")
            {
                // 离职
                info.Status = 0;
            }
            else if (e.CommandName == "Delete")
            {
                // 删除
                info.Status = 9;
            }

            manage.Update(info);

            BindGridData(ViewStateDept, ViewStateState, ViewStateSearchText);
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
    }
}