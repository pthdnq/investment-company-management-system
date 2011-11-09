using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using com.TZMS.Business;
using com.TZMS.Model;
using ExtAspNet;

namespace TZMS.Web
{
    public partial class AttendToFile : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dpkStartTime.SelectedDate = DateTime.Now;
                dpkEndTime.SelectedDate = DateTime.Now;

                // 绑定列表.
                BindGrid();
            }
        }

        #region 私有方法

        private void BindGrid()
        {
            DateTime startTime = Convert.ToDateTime(dpkStartTime.SelectedDate);
            DateTime endTime = Convert.ToDateTime(dpkEndTime.SelectedDate);

            if (DateTime.Compare(startTime, endTime) == 1)
            {
                Alert.Show("结束日期不可小于开始日期!");
                return;
            }

            #region 查询出条件

            StringBuilder strCondition = new StringBuilder();
            strCondition.Append(" ApproverID = '" + CurrentUser.ObjectId.ToString() + "'");

            // 归档状态.
            if (ddlstArchiveState.SelectedIndex == 0)
            {
                strCondition.Append(" and ApproveResult = 3");
            }
            else
            {
                strCondition.Append(" and ApproveResult = 4");
            }

            // 时间范围.

            strCondition.Append(" and (ApproveTime between '" + startTime.ToString("yyyy-MM-dd 00:00") + "' and '" + endTime.ToString("yyyy-MM-dd 23:59") + "' or ApproveTime = '1900-01-01 12:00:00.000')");

            #endregion

            LeaveAppManage leaveAppManage = new LeaveAppManage();
            List<LeaveApproveInfo> lstLeaveInfo = leaveAppManage.GetLeaveApprovesByCondition(strCondition.ToString());
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
        /// 翻页事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridLeave_PageIndexChange(object sender, ExtAspNet.GridPageEventArgs e)
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
            string strApproveID = ((GridRow)gridLeave.Rows[e.RowIndex]).Values[0];
            string strApproveResult = ((GridRow)gridLeave.Rows[e.RowIndex]).Values[8];
            if (!string.IsNullOrEmpty(strApproveID))
            {
                LeaveAppManage leaveAppManage = new LeaveAppManage();
                LeaveApproveInfo _approveInfo = leaveAppManage.GetLeaveApproveInfoByObjectID(strApproveID);
                LeaveInfo _leaveInfo = leaveAppManage.GetLeaveInfoByObjectID(_approveInfo.LeaveId.ToString());

                // 设置归档信息.
                _approveInfo.ApproveResult = 4;
                _approveInfo.ApproveTime = DateTime.Now;
                leaveAppManage.UpdateLeaveApprove(_approveInfo);

                // 设置申请单信息.
                if (strApproveResult == "同意")
                {
                    _leaveInfo.State = 2;
                }
                else
                {
                    _leaveInfo.State = 3;
                }

                leaveAppManage.UpdateLeaveInfo(_leaveInfo);

                BindGrid();
            }
        }

        /// <summary>
        /// 数据行绑定事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridLeave_RowDataBound(object sender, ExtAspNet.GridRowEventArgs e)
        {
            if (e.DataItem != null)
            {
                LeaveApproveInfo _approveInfo = (LeaveApproveInfo)e.DataItem;
                LeaveAppManage leaveAppManage = new LeaveAppManage();
                LeaveInfo _leaveInfo = leaveAppManage.GetLeaveInfoByObjectID(_approveInfo.LeaveId.ToString());
                if (_leaveInfo != null)
                {
                    List<LeaveApproveInfo> lstLeaveApproveInfo = leaveAppManage.GetLeaveApprovesByCondition("LeaveID='" + _leaveInfo.ObjectId.ToString()
                        + "' and (ApproveResult = 1 or ApproveResult = 2) order by ApproveTime desc");

                    e.Values[0] = _approveInfo.ObjectId.ToString();
                    e.Values[1] = _leaveInfo.WriteTime.ToString("yyyy-MM-dd HH:mm");
                    e.Values[2] = _leaveInfo.StartTime.ToString("yyyy-MM-dd HH:00");
                    e.Values[3] = _leaveInfo.StopTime.ToString("yyyy-MM-dd HH:00");
                    e.Values[4] = ((TimeSpan)(DateTime.Parse(e.Values[3].ToString()) - DateTime.Parse(e.Values[2].ToString()))).TotalHours.ToString();
                    e.Values[5] = _leaveInfo.Type;
                    e.Values[6] = _leaveInfo.Reason;
                    e.Values[7] = lstLeaveApproveInfo[0].ApproverName;
                    e.Values[8] = lstLeaveApproveInfo[0].ApproveResult == 1 ? "同意" : "不同意";
                    e.Values[9] = _approveInfo.ApproveResult == 3 ? "待归档" : "已归档";
                    if (_approveInfo.ApproveResult == 4)
                    {
                        e.Values[10] = "<span class=\"gray\">归档</span>";
                    }
                }
            }
        }
        #endregion
    }
}