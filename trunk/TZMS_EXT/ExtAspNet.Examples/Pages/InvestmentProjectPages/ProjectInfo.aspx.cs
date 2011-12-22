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
        #region viewstate
        /// <summary>
        /// 用于存储部门名称的ViewState.
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

                string strID = Request.QueryString["ID"];
                string type = Request.QueryString["Type"];
                if (!string.IsNullOrEmpty(type))
                {
                    if (type.Equals("View"))
                    {
                        this.btnNew.Hidden = true;
                    }
                }

                ForID = strID;

                InitControl();
                // 绑定下拉框.
                //    BindDDL();
                // 绑定列表.
                BindGridData(ForID, ViewStateState, ViewStateSearchText);
            }
        }

        private void InitControl()
        {
            this.btnClose.OnClientClick = ActiveWindow.GetConfirmHidePostBackReference();

            this.btnNew.OnClientClick = wndNew.GetShowReference("ProjectProcessAdd.aspx?ID=" + ForID, "新增 - 进展");
            this.wndNew.OnClientCloseButtonClick = wndNew.GetHideReference();

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

            //ForID = ddlstDept.SelectedText;
            //ViewStateState = ddlstState.SelectedText;
            //ViewStateSearchText = ttbSearch.Text.Trim();
        }

        /// <summary>
        /// 绑定列表
        /// </summary>
        private void BindGridData(string forID, string state, string searchText)
        {
            searchText = string.Empty;
            forID = ForID;
            state = string.Empty;
            #region 条件

            StringBuilder strCondtion = new StringBuilder();
            if (!string.IsNullOrEmpty(forID) && forID != "全部")
            {
                strCondtion.Append(" ForID='" + forID + "' and ");
            }
            if (!string.IsNullOrEmpty(state))
            {
                strCondtion.Append(" Status=" + (state == "在职" ? 1 : 0) + " and ");
            }
            if (!string.IsNullOrEmpty(searchText))
            {
                strCondtion.Append(" (ProjectName like '%" + searchText + "%' or AccountNo like '%" + searchText + "%') and ");
            }
            //未删除
            strCondtion.Append(" Status<>9 ");

            #endregion

            List<com.TZMS.Model.ProjectProcessInfo> lstUserInfo = new InvestmentProjectManage().GetProcessByCondtion(strCondtion.ToString());
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

        #region 页面事件
        /// <summary>
        /// 保存员工
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            // saveUserInfo();
        }

        /// <summary>
        /// 翻页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridData_PageIndexChange(object sender, ExtAspNet.GridPageEventArgs e)
        {
            this.gridData.PageIndex = e.NewPageIndex;
            BindGridData(ForID, ViewStateState, ViewStateSearchText);
        }

        /// <summary>
        /// 查询事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ttbSearch_Trigger1Click(object sender, EventArgs e)
        {
            //  ViewStateSearchText = this.ttbSearch.Text.Trim();
            BindGridData(ForID, ViewStateState, ViewStateSearchText);
        }

        /// <summary>
        /// 部门变动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlstDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            // ForID = this.ddlstDept.SelectedText;
            BindGridData(ForID, ViewStateState, ViewStateSearchText);
        }

        /// <summary>
        /// 状态变动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlstState_SelectedIndexChanged(object sender, EventArgs e)
        {
            //   ViewStateState = this.ddlstState.SelectedText;
            BindGridData(ForID, ViewStateState, ViewStateSearchText);
        }

        /// <summary>
        /// 操作事件.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridData_RowCommand(object sender, GridCommandEventArgs e)
        {
            InvestmentProjectManage manage = new InvestmentProjectManage();
            string objectID = ((GridRow)gridData.Rows[e.RowIndex]).Values[0];

            com.TZMS.Model.ProjectProcessInfo info = manage.GetProcessByObjectID(objectID);

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

            manage.UpdateProcess(info);

            BindGridData(ForID, ViewStateState, ViewStateSearchText);
        }

        /// <summary>
        /// 行绑定事件.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridData_RowDataBound(object sender, GridRowEventArgs e)
        {
            com.TZMS.Model.ProjectProcessInfo _Info = (com.TZMS.Model.ProjectProcessInfo)e.DataItem;

            if (_Info.Status != 1)
            {
                e.Values[8] = "<span class=\"gray\">删除</span>";
            }
        }

        /// <summary>
        /// 关闭新增员工页面. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void wndNew_Close(object sender, WindowCloseEventArgs e)
        {
            BindGridData(ForID, ViewStateState, ViewStateSearchText);
        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获取状态名字
        /// </summary>
        /// <param name="strStatus"></param>
        /// <returns></returns>
        protected string GetStatusName(string strStatus)
        {
            string StrStatusName = string.Empty;
            switch (strStatus)
            {
                case "0":
                    //  strCondtion.Append(" AND Status = 1 ");
                    break;
                case "1":
                    StrStatusName = "待审核";
                    break;
                case "2":
                    StrStatusName = "未通过";
                    break;
                case "3":
                    StrStatusName = "审核中";
                    break;
                case "4":
                    StrStatusName = "已通过";
                    break;
                case "5":
                    StrStatusName = "待审核";
                    break;
                case "6":
                    StrStatusName = "已通过";
                    break;
                case "9":
                    StrStatusName = "已删除";
                    break;
                default:
                    break;
            }
            return StrStatusName;
        }
        #endregion
    }
}