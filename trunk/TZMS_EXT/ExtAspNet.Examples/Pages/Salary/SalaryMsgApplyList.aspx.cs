﻿using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using ExtAspNet;
using com.TZMS.Model;
using com.TZMS.Business;

namespace TZMS.Web
{
    public partial class SalaryMsgApplyList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindYear();

                ddlstYear.SelectedValue = DateTime.Now.Year.ToString();
                ddlstMonth.SelectedValue = DateTime.Now.Month.ToString();

                BindGrid();
            }
        }

        #region 私有方法

        /// <summary>
        /// 绑定年
        /// </summary>
        private void BindYear()
        {
            int year = DateTime.Now.Year;
            string tempString = string.Empty;
            for (int i = -3; i < 2; i++)
            {
                tempString = (year + i).ToString();
                ddlstYear.Items.Add(new ExtAspNet.ListItem(tempString, tempString));
            }
        }

        /// <summary>
        /// 绑定报销申请单列表
        /// </summary>
        private void BindGrid()
        {
            #region 查询条件

            DateTime startTime = Convert.ToDateTime(dpkStartTime.SelectedDate);
            DateTime endTime = Convert.ToDateTime(dpkEndTime.SelectedDate);

            if (DateTime.Compare(startTime, endTime) == 1)
            {
                Alert.Show("结束日期不可小于开始日期!");
                return;
            }

            StringBuilder strCondition = new StringBuilder();
            strCondition.Append(" CreaterID ='" + CurrentUser.ObjectId.ToString() + "'");

            // 申请状态.
            switch (Convert.ToInt32(ddlState.SelectedValue))
            {
                case 0:
                    strCondition.Append(" and (state = 0 or state = -1)");
                    break;
                case 1:
                    strCondition.Append(" and (state = 1 or state = -1)");
                    break;
                case 2:
                    strCondition.Append(" and (state = 2 or state = -1)");
                    break;
                default:
                    break;
            }

            strCondition.Append(" and Year = " + ddlstYear.SelectedValue);
            strCondition.Append(" and Month = " + ddlstMonth.SelectedValue);
            strCondition.Append(" and (CreateTime between '" + startTime.ToString("yyyy-MM-dd 00:00") + "' and '" + endTime.ToString("yyyy-MM-dd 23:59")
                + "' or CreateTime='" + ACommonInfo.DBMAXDate.ToString() + "')");

            #endregion

            //获得员工
            List<SalaryMsgInfo> lstSalaryMsgInfo = new SalaryManage().GetSalaryMsgByCondition(strCondition.ToString());
            this.gridApply.RecordCount = lstSalaryMsgInfo.Count;
            this.gridApply.PageSize = PageCounts;
            int currentIndex = this.gridApply.PageIndex;
            //计算当前页面显示行数据
            if (lstSalaryMsgInfo.Count > this.gridApply.PageSize)
            {
                if (lstSalaryMsgInfo.Count > (currentIndex + 1) * this.gridApply.PageSize)
                {
                    lstSalaryMsgInfo.RemoveRange((currentIndex + 1) * this.gridApply.PageSize, lstSalaryMsgInfo.Count - (currentIndex + 1) * this.gridApply.PageSize);
                }
                lstSalaryMsgInfo.RemoveRange(0, currentIndex * this.gridApply.PageSize);
            }
            this.gridApply.DataSource = lstSalaryMsgInfo;
            this.gridApply.DataBind();
        }

        #endregion

        #region 页面事件

        /// <summary>
        /// 查询事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        /// <summary>
        /// 申请窗口关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void wndApply_Close(object sender, ExtAspNet.WindowCloseEventArgs e)
        {
            BindGrid();
        }

        /// <summary>
        /// 翻页事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridApply_PageIndexChange(object sender, ExtAspNet.GridPageEventArgs e)
        {
            gridApply.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        /// <summary>
        /// 数据行点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridApply_RowCommand(object sender, ExtAspNet.GridCommandEventArgs e)
        {

        }

        /// <summary>
        /// 数据行绑定事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridApply_RowDataBound(object sender, ExtAspNet.GridRowEventArgs e)
        {
            if (e.DataItem != null)
            {
                e.Values[3] = DateTime.Parse(e.Values[3].ToString()).ToString("yyyy-MM-dd HH:mm");
                switch (e.Values[4].ToString())
                {
                    case "-1":
                        e.Values[4] = "未申请";
                        e.Values[5] = "";
                        e.Values[7] = "<span class=\"gray\">查看</span>";
                        break;
                    case "0":
                        e.Values[4] = "审批中";
                        {
                            UserInfo _approveUser = new UserManage().GetUserByObjectID(e.Values[5].ToString());
                            if (_approveUser != null)
                            {
                                e.Values[5] = _approveUser.Name;
                            }
                        }
                        e.Values[6] = "<span class=\"gray\">申请</span>";
                        break;
                    case "1":
                        e.Values[4] = "归档";
                        e.Values[5] = SystemUser.Name;
                        e.Values[6] = "<span class=\"gray\">申请</span>";
                        break;
                    case "2":
                        e.Values[4] = "未通过";
                        {
                            UserInfo _approveUser = new UserManage().GetUserByObjectID(e.Values[5].ToString());
                            if (_approveUser != null)
                            {
                                e.Values[5] = _approveUser.Name;
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        #endregion
    }
}