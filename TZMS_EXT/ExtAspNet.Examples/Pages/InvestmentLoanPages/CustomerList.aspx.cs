﻿using System;
using System.Collections.Generic;
using com.TZMS.Business;
using com.TZMS.Model;
using ExtAspNet;
using System.Text;

namespace TZMS.Web.Pages.CashFlow
{
    public partial class CustomerList : BasePage
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
                //   this.btnNew.OnClientClick = wndNew.GetShowReference("CashFlowSetterInit.aspx?Type=Add", "初始化 - 资金");
                this.wndEdit.OnClientCloseButtonClick = wndEdit.GetHideReference();

                // 绑定下拉框.
                BindDDL();
                // 绑定列表.
                BindGridData(ViewStateState, ViewStateSearchText);

                this.CurrentLevel = GetCurrentLevel("khylb");
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
            //需要增加下一步审批人
            // strCondtion.Append("   NextOperaterId = '" + this.CurrentUser.ObjectId + "'  ");
            strCondtion.Append("   Status <> 9 ");

            if (!string.IsNullOrEmpty(searchText))
            {
                strCondtion.Append(" AND  (Name LIKE '%" + searchText + "%'  )  ");
            }

            #region status
            //if (!string.IsNullOrEmpty(state))
            //{ 
            //    //  状态.
            //    switch (state)
            //    {
            //        case "0":
            //            //  strCondtion.Append(" AND Status = 1 ");
            //            break;
            //        case "1":
            //            strCondtion.Append(" AND Status = 1 ");
            //            break;
            //        case "2":
            //            strCondtion.Append(" AND Status = 2 ");
            //            break;
            //        case "3":
            //            strCondtion.Append(" AND Status = 3  ");
            //            break;
            //        case "4":
            //            strCondtion.Append(" AND Status = 4 ");
            //            break;
            //        case "5":
            //            strCondtion.Append(" AND Status = 5 ");
            //            break;
            //        case "9":
            //            strCondtion.Append(" AND Status = 9 ");
            //            break;
            //        default:
            //            break;
            //    }
            //}
            #endregion

            //时间
            //DateTime startTime = Convert.ToDateTime(dpkStartTime.SelectedDate);
            //DateTime endTime = Convert.ToDateTime(dpkEndTime.SelectedDate);
            //if (DateTime.Compare(startTime, endTime) == 1)
            //{
            //    Alert.Show("结束日期不可小于开始日期!");
            //    return;
            //}
            //strCondtion.Append(" AND CreateTime BETWEEN '" + startTime.ToString("yyyy-MM-dd 00:00") + "' AND '" + endTime.ToString("yyyy-MM-dd 23:59") + "'");
            strCondtion.Append(" ORDER BY CreditScore DESC");
            #endregion

            List<com.TZMS.Model.CustomerInfo> lstInfo = new InvestmentLoanManage().GetCustomersByCondtion(strCondtion.ToString());
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
        /// 行绑定事件.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridData_RowDataBound(object sender, GridRowEventArgs e)
        {
            CustomerInfo _Info = (CustomerInfo)e.DataItem;
            int icount = Math.Abs(_Info.CreditScore) / 20;
            string strIcons = "";
            string strIconsType = (_Info.CreditScore > 0) ? "★" : "ㄣ";

            for (int i = 0; i < icount; i++)
            {
                strIcons += strIconsType;
            }

            e.Values[3] = string.Format("<span class=\"gray\">{0}</span>", strIcons);

            if (this.CurrentLevel.Equals(VisitLevel.View))
            {
                e.Values[7] = "<span class=\"gray\">编辑</span>";
            }
        }

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
            InvestmentLoanManage userManage = new InvestmentLoanManage();
            string iD = ((GridRow)gridData.Rows[e.RowIndex]).Values[0];

            CustomerInfo info = userManage.GetCustomerByObjectID(iD);

            if (e.CommandName == "Delete")
            {
                // 删除
                info.Status = 9;
            }

            userManage.UpdateCustomer(info);

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
    }
}