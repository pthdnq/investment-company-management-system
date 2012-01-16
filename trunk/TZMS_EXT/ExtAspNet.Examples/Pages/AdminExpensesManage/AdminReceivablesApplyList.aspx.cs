using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.TZMS.Business;
using com.TZMS.Model;
using ExtAspNet;
using System.Text;

namespace TZMS.Web.Pages.AdminExpensesManage
{
    public partial class AdminReceivablesApplyList : BasePage
    {
        #region viewstate
        /// <summary>
        /// 用于存储状态的ViewState.
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
                // 绑定控件
                InitControl();
                // 绑定列表.
                BindGridData(ViewStateState, ViewStateSearchText);
            }
        }

        /// <summary>
        /// 绑定 
        /// </summary>
        private void InitControl()
        {
            this.btnNew.OnClientClick = wndNew.GetShowReference("AdminReceivablesApply.aspx?Type=Add", "新增 - 收款上交申请");
            this.wndNew.OnClientCloseButtonClick = wndNew.GetHidePostBackReference();

            CurrentLevel = GetCurrentLevel("xzsksjsq");
            if (this.CurrentLevel.Equals(VisitLevel.View))
            {
                btnNew.Hidden = true;
            }

            dpkStartTime.SelectedDate = DateTime.Now.AddMonths(-1);
            dpkEndTime.SelectedDate = DateTime.Now;
            ViewStateState = ddlstState.SelectedValue;
            ViewStateSearchText = ttbSearch.Text.Trim();
        }

        /// <summary>
        /// 绑定列表
        /// </summary>
        private void BindGridData(string state, string searchText)
        {
            #region 条件
            StringBuilder strCondtion = new StringBuilder();
            strCondtion.Append("  CreaterID = '" + this.CurrentUser.ObjectId + "' ");
            // strCondtion.Append(" AND Status<>9 "); 

            if (!string.IsNullOrEmpty(state))
            {
                //strCondtion.Append(" Status " + (state == "待审核" ? " = 1 " : " <> 1 ") + " AND ");
                // 申请状态.
                switch (state)
                {
                    case "0":
                        //  strCondtion.Append(" AND Status = 1 ");
                        break;
                    case "1":
                        strCondtion.Append(" AND Status = 1 ");
                        break;
                    case "2":
                        strCondtion.Append(" AND (Status = 2 OR Status = 11 ) ");
                        break;
                    case "3":
                        strCondtion.Append(" AND  Status = 3   ");
                        break;
                    case "4":
                        strCondtion.Append(" AND Status = 4 ");
                        break;
                    case "5":
                        strCondtion.Append(" AND Status = 5 ");
                        break;
                    case "7":
                        strCondtion.Append(" AND Status = 7 ");
                        break;
                    case "8":
                        strCondtion.Append(" AND Status = 8 ");
                        break;
                    case "9":
                        strCondtion.Append(" AND Status = 9 ");
                        break;
                    default:
                        break;
                }
            }
            if (!string.IsNullOrEmpty(searchText))
            {
                strCondtion.Append(" AND (ProjectName LIKE '%" + searchText + "%' )  ");
            }
            //时间
            DateTime startTime = Convert.ToDateTime(dpkStartTime.SelectedDate);
            DateTime endTime = Convert.ToDateTime(dpkEndTime.SelectedDate);
            if (DateTime.Compare(startTime, endTime) == 1)
            {
                Alert.Show("结束日期不可小于开始日期!");
                return;
            }
            strCondtion.Append(" AND CreateTime BETWEEN '" + startTime.ToString("yyyy-MM-dd 00:00") + "' AND '" + endTime.ToString("yyyy-MM-dd 23:59") + "'");
            strCondtion.Append(" ORDER BY CreateTime DESC");
            #endregion

            //获得员工
            List<AdminReceivablesInfo> lstInfo = new AdminReceivablesManage().GetUsersByCondtion(strCondtion.ToString());
            this.gridData.RecordCount = lstInfo.Count;
            this.gridData.PageSize = PageCounts;
            int currentIndex = this.gridData.PageIndex;
            //计算当前页面显示行数据
            if (lstInfo.Count > this.gridData.PageSize)
            {
                if (lstInfo.Count > (currentIndex + 1) * this.gridData.PageSize)
                {
                    lstInfo.RemoveRange((currentIndex + 1) * this.gridData.PageSize, lstInfo.Count - (currentIndex + 1) * this.gridData.PageSize);
                }
                lstInfo.RemoveRange(0, currentIndex * this.gridData.PageSize);
            }
            this.gridData.DataSource = lstInfo;
            this.gridData.DataBind();
        }

        #endregion

        #region 页面操作
        /// <summary>
        /// 行绑定事件.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridData_RowDataBound(object sender, GridRowEventArgs e)
        {
            AdminReceivablesInfo _Info = (AdminReceivablesInfo)e.DataItem;

            //  if (_Info.Status != 1 && _Info.Status != 2)
            if (_Info.Status != 2 || this.CurrentLevel.Equals(VisitLevel.View))
            {
                e.Values[9] = "<span class=\"gray\">编辑</span>";
                e.Values[10] = "<span class=\"gray\">删除</span>";
            }
        }

        /// <summary>
        /// 操作事件.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridData_RowCommand(object sender, GridCommandEventArgs e)
        {
            AdminReceivablesManage userManage = new AdminReceivablesManage();
            string iiD = ((GridRow)gridData.Rows[e.RowIndex]).Values[0];

            AdminReceivablesInfo info = userManage.GetUserByObjectID(iiD);

            if (e.CommandName == "Delete")
            {
                // 删除
                info.Status = 9;
            }

            userManage.Update(info);

            BindGridData(ViewStateState, ViewStateSearchText);
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
            BindGridData(ViewStateState, ViewStateSearchText);
        }

        /// <summary>
        /// 查询事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ttbSearch_Trigger1Click(object sender, EventArgs e)
        {
            ViewStateState = this.ddlstState.SelectedValue;
            ViewStateSearchText = this.ttbSearch.Text.Trim();
            BindGridData(ViewStateState, ViewStateSearchText);
        }


        /// <summary>
        /// 状态变动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlstState_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewStateState = this.ddlstState.SelectedValue;
            BindGridData(ViewStateState, ViewStateSearchText);
        }

        /// <summary>
        /// 关闭新增员工页面. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void wndNew_Close(object sender, WindowCloseEventArgs e)
        {
            BindGridData(ViewStateState, ViewStateSearchText);
        }

        #endregion

        #region 自定义状态方法
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
                    StrStatusName = "已确认";
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