using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using com.TZMS.Model;
using com.TZMS.Business;
using ExtAspNet;

namespace TZMS.Web
{
    public partial class LeaveApp : BasePage
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
                dpkStartTime.SelectedDate = dpkEndTime.SelectedDate = DateTime.Now;

                //请假申请 新增按钮
                wndLeaveApp.Title = "请假申请";
                btnNewApp.OnClientClick = wndLeaveApp.GetShowReference("LeaveAppNew.aspx?Type=Add") + "return false;";
                //btnNewApp.OnClientClick = wndLeaveApp.GetShowReference("../../Test.aspx") + "return false;";
                wndLeaveApp.OnClientCloseButtonClick = wndLeaveApp.GetHidePostBackReference();

                // 绑定数据到列表.
                BindGrid();
            }
        }

        #region 私有方法

        /// <summary>
        /// 绑定列表
        /// </summary>
        /// <param name="strLeaveState">申请单状态</param>
        /// <param name="nDateRange">日期范围</param>
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
            strCondition.Append(" IsDelete<>1 and Type <> '调休'");
            strCondition.Append(" and UserObjectID ='" + CurrentUser.ObjectId.ToString() + "'");
            strCondition.Append(" and state =" + Convert.ToInt32(ddlappState.SelectedValue));

            // 日期范围.
            strCondition.Append(" and WriteTime between '" + startTime.ToString("yyyy-MM-dd 00:00") + "' and '" + endTime.ToString("yyyy-MM-dd 23:59") + "'");

            //DateTime dateTimeNow = DateTime.Now;

            //switch (nDateRange)
            //{
            //    // 一个月内.
            //    case 1:
            //        strCondition.Append(" and WriteTime >= '" + dateTimeNow.AddMonths(-1).ToString("yyyy-MM-dd") + "'");
            //        break;

            //    // 三个月内.
            //    case 2:
            //        strCondition.Append(" and WriteTime >= '" + dateTimeNow.AddMonths(-3).ToString("yyyy-MM-dd") + "'");
            //        break;

            //    // 半年内.
            //    case 3:
            //        strCondition.Append(" and WriteTime >= '" + dateTimeNow.AddMonths(-6).ToString("yyyy-MM-dd") + "'");
            //        break;

            //    // 一年内.
            //    case 4:
            //        strCondition.Append(" and WriteTime >= '" + dateTimeNow.AddMonths(-12).ToString("yyyy-MM-dd") + "'");
            //        break;
            //}

            #endregion

            // 获取
            LeaveAppManage leaveAppManage = new LeaveAppManage();
            List<LeaveInfo> lstLeaveInfo = leaveAppManage.GetLeaveInfosByCondition(strCondition.ToString());
            gridLeave.RecordCount = lstLeaveInfo.Count;
            gridLeave.PageSize = PageCounts;
            int currentIndex = gridLeave.PageIndex;

            // 计算当前页面显示行数据
            if (lstLeaveInfo.Count > gridLeave.PageSize)
            {
                if (lstLeaveInfo.Count > (currentIndex + 1) * gridLeave.PageSize)
                {
                    lstLeaveInfo.RemoveRange((currentIndex + 1) * gridLeave.PageSize, lstLeaveInfo.Count - (currentIndex + 1) * gridLeave.PageSize);
                }
                lstLeaveInfo.RemoveRange(0, currentIndex * gridLeave.PageSize);
            }
            this.gridLeave.DataSource = lstLeaveInfo;
            this.gridLeave.DataBind();
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
        /// 我要请假 页面关闭时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void wndLeaveApp_Close(object sender, ExtAspNet.WindowCloseEventArgs e)
        {
            BindGrid();
        }

        /// <summary>
        /// 数据行点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridLeave_RowCommand(object sender, ExtAspNet.GridCommandEventArgs e)
        {
            string strLeaveID = ((GridRow)gridLeave.Rows[e.RowIndex]).Values[0];

            if (e.CommandName == "View")
            {
                wndLeaveApp.IFrameUrl = "LeaveAppNew.aspx?Type=View&LeaveID=" + strLeaveID;
                wndLeaveApp.Hidden = false;
            }

            if (e.CommandName == "Edit")
            {
                wndLeaveApp.IFrameUrl = "LeaveAppNew.aspx?Type=Edit&LeaveID=" + strLeaveID;
                wndLeaveApp.Hidden = false;
            }

            if (e.CommandName == "Delete")
            {
                LeaveAppManage _leaveManage = new LeaveAppManage();
                LeaveInfo _leaveInfo = _leaveManage.GetLeaveInfoByObjectID(strLeaveID);
                if (_leaveInfo != null)
                {
                    _leaveInfo.IsDelete = true;
                    int result = _leaveManage.UpdateLeaveInfo(_leaveInfo);

                    BindGrid();
                }
            }
        }

        /// <summary>
        /// 数据行绑定事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridLeave_RowDataBound(object sender, ExtAspNet.GridRowEventArgs e)
        {
            LeaveInfo leaveInfo = (LeaveInfo)e.DataItem;
            if (leaveInfo != null)
            {
                // 去掉日期中时、分、秒.
                e.Values[1] = DateTime.Parse(e.Values[1].ToString()).ToString("yyyy-MM-dd HH:mm");
                e.Values[2] = DateTime.Parse(e.Values[2].ToString()).ToString("yyyy-MM-dd HH:00");
                e.Values[3] = DateTime.Parse(e.Values[3].ToString()).ToString("yyyy-MM-dd HH:00");

                // 设置时长.
                DateTime startTime = DateTime.Parse(e.Values[2].ToString());
                DateTime endTime = DateTime.Parse(e.Values[3].ToString());
                e.Values[4] = ((TimeSpan)(endTime - startTime)).TotalHours.ToString();

                // 设置编辑按钮.
                //if (Convert.ToInt32(e.Values[8].ToString()) != 3)
                //{
                e.Values[10] = "<span class=\"gray\">编辑</span>";
                e.Values[11] = "<span class=\"gray\">删除</span>";
                //}

                // 设置请假申请单状态.
                switch (Convert.ToInt32(e.Values[8].ToString()))
                {
                    case 1:
                        e.Values[8] = "审批中";
                        break;
                    case 2:
                        e.Values[8] = "归档";
                        break;
                    case 3:
                        e.Values[8] = "被打回";
                        break;
                    default:
                        break;
                }

                // 获取审批人的值.
                UserManage _userManage = new UserManage();
                UserInfo _userInfo = _userManage.GetUserByObjectID(leaveInfo.ApproverId.ToString());
                if (_userInfo != null)
                {
                    e.Values[7] = _userInfo.Name;
                }
            }
        }

        /// <summary>
        /// 翻页事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridLeave_PageIndexChange(object sender, ExtAspNet.GridPageEventArgs e)
        {
            gridLeave.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        #endregion
    }
}