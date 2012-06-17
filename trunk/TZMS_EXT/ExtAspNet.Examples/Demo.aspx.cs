using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

namespace TZMS.Web
{
    public partial class Demo : BasePage
    {


        private TZMS.Web.BasePage.ComSearchHelp searchHelp;

        public TZMS.Web.BasePage.ComSearchHelp SearchHelp
        {
            get
            {
                if (ViewState["ComSearchHelp!"] == null)
                {
                    ViewState["ComSearchHelp!"] = new ComSearchHelp();
                }
                return (ComSearchHelp)ViewState["ComSearchHelp!"];
            }
            set { ViewState["ComSearchHelp!"] = value; }
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
                ////判断页面是否可编辑（可查看不用考虑）
                //if (PageModel != VisitLevel.Edit && PageModel != VisitLevel.Both)
                //{
                //    btnNewUser.Enabled = false;
                //}

                //btnNewUser.OnClientClick = wndNewUser.GetShowReference("NewUser.aspx?Type=Add", "新增员工");
                //wndNewUser.OnClientCloseButtonClick = wndNewUser.GetHidePostBackReference();

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

        }

        /// <summary>
        /// 绑定列表
        /// </summary>
        private void DataGrid()
        {
            #region 条件

            StringBuilder strCondtion = new StringBuilder();

            //未删除
            strCondtion.Append(" state<>2 ");

            #endregion

            searchHelp = SearchHelp;
            searchHelp.Condition = strCondtion.ToString();
            searchHelp.TableName = "[UserInfo]";
            searchHelp.PageIndex = this.gridUser.PageIndex;
            searchHelp.PageSize = 10;
            searchHelp.SelectFiled = "*";
            searchHelp.Order = " name desc";

            DataTable table = TZMS.Web.BasePage.ComSearchManage.GetSearchResult(BoName, ref searchHelp);
            SearchHelp = searchHelp;

            ////获得员工
            //List<UserInfo> lstUserInfo = new UserManage().GetUsersByCondtion(strCondtion.ToString());
            //this.gridUser.RecordCount = searchHelp.TotalCount;
            //this.gridUser.PageSize = searchHelp.TotalPages;
            //int currentIndex = this.gridUser.PageIndex;
            ////计算当前页面显示行数据
            //if (lstUserInfo.Count > this.gridUser.PageSize)
            //{
            //    if (lstUserInfo.Count > (currentIndex + 1) * this.gridUser.PageSize)
            //    {
            //        lstUserInfo.RemoveRange((currentIndex + 1) * this.gridUser.PageSize, lstUserInfo.Count - (currentIndex + 1) * this.gridUser.PageSize);
            //    }
            //    lstUserInfo.RemoveRange(0, currentIndex * this.gridUser.PageSize);
            //}

            //lstUserInfo.Sort(delegate(UserInfo x, UserInfo y) { return Convert.ToInt32(x.JobNo) - Convert.ToInt32(y.JobNo); });

            //this.gridUser.RecordCount = searchHelp.TotalCount;
            this.gridUser.PageSize = searchHelp.PageSize;
            this.gridUser.DataSource = table;
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


        #endregion

        protected void btnSearch_Click1(object sender, EventArgs e)
        {
            this.gridUser.PageIndex = int.Parse(this.txtIndex.Text);
            DataGrid();
        }
    }
}