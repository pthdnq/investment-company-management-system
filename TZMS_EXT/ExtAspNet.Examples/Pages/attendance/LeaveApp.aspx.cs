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
        /// 请假申请单状态
        /// </summary>
        public int LeaveState
        {
            get
            {
                if (ViewState["LeaveState"] == null)
                {
                    return 0;
                }

                return Convert.ToInt32(ViewState["LeaveState"].ToString());
            }
            set
            {
                ViewState["LeaveState"] = value;
            }
        }

        /// <summary>
        /// 日期范围
        /// </summary>
        public int DateRange
        {
            get
            {
                if (ViewState["DateRange"] == null)
                {
                    return 1;
                }
                return Convert.ToInt32(ViewState["DateRange"].ToString());
            }
            set
            {
                ViewState["DateRange"] = value;
            }
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
                //请假申请 新增按钮
                wndLeaveApp.Title = "请假申请";
                btnNewApp.OnClientClick = wndLeaveApp.GetShowReference("LeaveAppNew.aspx?Type=Add") + "return false;";
                wndLeaveApp.OnClientCloseButtonClick = wndLeaveApp.GetHidePostBackReference();

                // 获取默认值.
                LeaveState = Convert.ToInt32(ddlappState.SelectedValue);
                DateRange = Convert.ToInt32(ddldateRange.SelectedValue);

                // 绑定数据到列表.
                DataBind(LeaveState, DateRange);
            }
        }

        #region 私有方法

        /// <summary>
        /// 绑定列表
        /// </summary>
        /// <param name="strLeaveState">申请单状态</param>
        /// <param name="nDateRange">日期范围</param>
        private void DataBind(int nLeaveState, int nDateRange)
        {
            #region 查询条件

            StringBuilder strCondition = new StringBuilder();
            strCondition.Append(" IsDelete<>1 and Type <> '调休'");
            strCondition.Append(" and UserObjectID ='" + CurrentUser.ObjectId.ToString() + "'");
            strCondition.Append(" and state =" + nLeaveState);

            DateTime dateTimeNow = DateTime.Now;

            switch (nDateRange)
            {
                // 一个月内.
                case 1:
                    strCondition.Append(" and WriteTime >= '" + dateTimeNow.AddMonths(-1).ToString("yyyy-MM-dd") + "'");
                    break;

                // 三个月内.
                case 2:
                    strCondition.Append(" and WriteTime >= '" + dateTimeNow.AddMonths(-3).ToString("yyyy-MM-dd") + "'");
                    break;

                // 半年内.
                case 3:
                    strCondition.Append(" and WriteTime >= '" + dateTimeNow.AddMonths(-6).ToString("yyyy-MM-dd") + "'");
                    break;

                // 一年内.
                case 4:
                    strCondition.Append(" and WriteTime >= '" + dateTimeNow.AddMonths(-12).ToString("yyyy-MM-dd") + "'");
                    break;
            }

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
        /// 我要请假 页面关闭时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void wndLeaveApp_Close(object sender, ExtAspNet.WindowCloseEventArgs e)
        {
            DataBind(LeaveState, DateRange);
        }

        /// <summary>
        /// 状态变动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlappState_SelectedIndexChanged(object sender, EventArgs e)
        {
            LeaveState = Convert.ToInt32(ddlappState.SelectedValue);
            DataBind(LeaveState, DateRange);
        }

        /// <summary>
        /// 日期范围变动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddldateRange_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateRange = Convert.ToInt32(ddldateRange.SelectedValue);
            DataBind(LeaveState, DateRange);
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

                    DataBind(LeaveState, DateRange);
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
                e.Values[1] = e.Values[1].ToString().Replace(" 0:00:00", "");
                e.Values[2] = e.Values[2].ToString().Replace(" 0:00:00", "");
                e.Values[3] = e.Values[3].ToString().Replace(" 0:00:00", "");

                // 设置编辑按钮.
                if (Convert.ToInt32(e.Values[7].ToString()) != 3)
                {
                    e.Values[9] = "<span class=\"gray\">编辑</span>";
                    e.Values[10] = "<span class=\"gray\">删除</span>";
                }

                // 设置请假申请单状态.
                switch (Convert.ToInt32(e.Values[7].ToString()))
                {
                    case 1:
                        e.Values[7] = "审批中";
                        break;
                    case 2:
                        e.Values[7] = "归档";
                        break;
                    case 3:
                        e.Values[7] = "被打回";
                        break;
                    default:
                        break;
                }

                // 获取审批人的值.
                UserManage _userManage = new UserManage();
                UserInfo _userInfo = _userManage.GetUserByObjectID(leaveInfo.ApproverId.ToString());
                if (_userInfo != null)
                {
                    e.Values[6] = _userInfo.Name;
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
            DataBind(LeaveState, DateRange);
        }

        #endregion
    }
}