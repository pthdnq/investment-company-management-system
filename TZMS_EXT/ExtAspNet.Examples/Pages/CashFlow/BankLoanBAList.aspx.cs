﻿using System;
using System.Collections.Generic;
using com.TZMS.Business;
using com.TZMS.Model;
using ExtAspNet;
using System.Text;

namespace TZMS.Web.Pages.CashFlow
{
    /// <summary>
    /// BankLoanBAList
    /// </summary>
    public partial class BankLoanBAList : BasePage
    {
        #region viewstate

        /// <summary>
        /// 用于存储 状态的ViewState.
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
                //this.btnNew.OnClientClick = wndNew.GetShowReference("ProjectApplyAdd.aspx?Type=Add", "新增 - 项目申请");
                this.wndNew.OnClientCloseButtonClick = wndNew.GetHidePostBackReference();

                // 绑定下拉框.
                BindDDL();
                // 绑定列表.
                BindGridData(ViewStateState, ViewStateSearchText);
            }
        }

        /// <summary>
        /// 绑定下拉框.
        /// </summary>
        private void BindDDL()
        {
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
            if ((!string.IsNullOrEmpty(state)) && (state.Equals("4") || state.Equals("2")))
            {
                strCondtion.Append("   BAAdulters Like '%" + this.CurrentUser.ObjectId + "%' ");
            }
            else
            {
                strCondtion.Append("   NextBAOperaterId = '" + this.CurrentUser.ObjectId + "' ");
            }
            //  strCondtion.Append("   BAStatus<>9 "); 

            if (!string.IsNullOrEmpty(state))
            {
                //strCondtion.Append(" BAStatus " + (state == "待审核" ? " = 1 " : " <> 1 ") + " AND ");
                // 申请状态.
                switch (state)
                {
                    case "0":
                        //  strCondtion.Append(" AND BAStatus = 1 ");
                        break;
                    case "1":
                        strCondtion.Append(" AND (BAStatus = 1 OR BAStatus = 3) ");
                        break;
                    case "2":
                        strCondtion.Append(" AND BAStatus = 2 ");
                        break;
                    case "3":
                        strCondtion.Append(" AND BAStatus = 3  ");
                        break;
                    case "4":
                        strCondtion.Append(" AND (BAStatus = 4 OR BAStatus = 3) ");
                        break;
                    case "5":
                        strCondtion.Append(" AND BAStatus = 5 ");
                        break;
                    case "9":
                        strCondtion.Append(" AND BAStatus = 9 ");
                        break;
                    default:
                        break;
                }
            }
            if (!string.IsNullOrEmpty(searchText))
            {
                strCondtion.Append(" AND (CustomerName LIKE '%" + searchText + "%')  ");
            }
            //时间
            DateTime startTime = Convert.ToDateTime(dpkStartTime.SelectedDate);
            DateTime endTime = Convert.ToDateTime(dpkEndTime.SelectedDate);
            if (DateTime.Compare(startTime, endTime) == 1)
            {
                Alert.Show("结束日期不可小于开始日期!");
                return;
            }
            strCondtion.Append(" AND SubmitBATime BETWEEN '" + startTime.ToString("yyyy-MM-dd 00:00") + "' AND '" + endTime.ToString("yyyy-MM-dd 23:59") + "'");
            strCondtion.Append(" ORDER BY SubmitBATime DESC");
            #endregion

            List<BankLoanInfo> lstInfo = new BankLoanManage().GetUsersByCondtion(strCondtion.ToString());
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
        /// 操作事件.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridData_RowCommand(object sender, GridCommandEventArgs e)
        {
            BankLoanManage userManage = new BankLoanManage();
            string iD = ((GridRow)gridData.Rows[e.RowIndex]).Values[0];

            BankLoanInfo info = userManage.GetUserByObjectID(iD);

            if (e.CommandName == "Delete")
            {
                // 删除
                info.BAStatus = 9;
            }

            userManage.Update(info);

            BindGridData(ViewStateState, ViewStateSearchText);
        }

        /// <summary>
        /// 行绑定事件.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridData_RowDataBound(object sender, GridRowEventArgs e)
        {
            BankLoanInfo _Info = (BankLoanInfo)e.DataItem;

            if (!_Info.NextBAOperaterId.Equals(this.CurrentUser.ObjectId) || ddlstState.SelectedValue != "1")
            {
                e.Values[11] = "<span class=\"gray\">审核</span>"; 
            }
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

        #region 自定义方法
        /// <summary>
        /// 获取状态名字
        /// </summary>
        /// <param name="strStatus"></param>
        /// <returns></returns>
        protected string GetStatusName(string strStatus)
        {
            string StrStatusName = string.Empty;
            StrStatusName = this.ddlstState.SelectedText;
            //switch (strStatus)
            //{
            //    case "0":
            //        //  strCondtion.Append(" AND Status = 1 ");
            //        break;
            //    case "1":
            //        StrStatusName = "待审核";
            //        break;
            //    case "2":
            //        StrStatusName = "未通过";
            //        break;
            //    case "3":
            //        StrStatusName = "审核中";
            //        break;
            //    case "4":
            //        StrStatusName = "已通过";
            //        break;
            //    case "5":
            //        StrStatusName = "已确认";
            //        break;
            //    case "9":
            //        StrStatusName = "已删除";
            //        break;
            //    default:
            //        break;
            //}
            return StrStatusName;
        }
        #endregion

    }
}