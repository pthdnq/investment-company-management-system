using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using ExtAspNet;
using com.TZMS.Business;
using com.TZMS.Model;

namespace TZMS.Web
{
    public partial class WorkerAttend : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dpkStartTime.SelectedDate = dpkEndTime.SelectedDate = DateTime.Now;

                // 点击导入按钮触发事件.
                btnImport.OnClientClick = wndImportAttend.GetShowReference("ImportWorkerAttend.aspx") + "return false;";
                wndImportAttend.OnClientCloseButtonClick = wndImportAttend.GetHidePostBackReference();

                BindGrid();
            }
        }

        #region 私有方法

        /// <summary>
        /// 绑定Grid
        /// </summary>
        private void BindGrid()
        {
            #region 查询事件

            DateTime startTime = Convert.ToDateTime(dpkStartTime.SelectedDate);
            DateTime endTime = Convert.ToDateTime(dpkEndTime.SelectedDate);

            if (DateTime.Compare(startTime, endTime) == 1)
            {
                Alert.Show("结束日期不可小于开始日期!");
                return;
            }

            StringBuilder strCondition = new StringBuilder();

            if (!string.IsNullOrEmpty(ttbSearch.Text.Trim()))
            {
                strCondition.Append(" (Name Like '%" + ttbSearch.Text.Trim() + "%' or AccountNo Like '%" + ttbSearch.Text.Trim() + "%') and");
            }

            strCondition.Append(" PushTime1 between '" + startTime.ToString("yyyy-MM-dd 00:00") + "' and '" + endTime.ToString("yyyy-MM-dd 23:59") + "'");
            strCondition.Append(" order by PushTime1 asc");

            #endregion

            WorkerAttendManage _manage = new WorkerAttendManage();
            List<AttendInfo> lstAttendInfo = _manage.GetAttendInfoByCondition(strCondition.ToString());
            gridAttend.RecordCount = lstAttendInfo.Count;
            gridAttend.PageSize = PageCounts;
            int currentIndex = gridAttend.PageIndex;

            // 计算当前页面显示行数据
            if (lstAttendInfo.Count > gridAttend.PageSize)
            {
                if (lstAttendInfo.Count > (currentIndex + 1) * gridAttend.PageSize)
                {
                    lstAttendInfo.RemoveRange((currentIndex + 1) * gridAttend.PageSize, lstAttendInfo.Count - (currentIndex + 1) * gridAttend.PageSize);
                }
                lstAttendInfo.RemoveRange(0, currentIndex * gridAttend.PageSize);
            }
            this.gridAttend.DataSource = lstAttendInfo;
            this.gridAttend.DataBind();
        }

        #endregion

        #region 页面事件

        /// <summary>
        /// 查询事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ttbSearch_Trigger1Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        /// <summary>
        /// 翻页事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridAttend_PageIndexChange(object sender, ExtAspNet.GridPageEventArgs e)
        {
            gridAttend.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        /// <summary>
        /// 数据行绑定事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridAttend_RowDataBound(object sender, ExtAspNet.GridRowEventArgs e)
        {
            if (e.DataItem != null)
            {
                AttendInfo _info = (AttendInfo)e.DataItem;
                e.Values[0] = _info.PushTime1.ToString("yyyy-MM-dd");
                e.Values[1] = _info.JobNo;
                e.Values[2] = _info.Name;
                e.Values[3] = _info.AccountNo;
                int i = (int)_info.PushTime1.DayOfWeek;
                switch (i)
                {
                    case 0:
                        e.Values[4] = "星期天";
                        break;
                    case 1:
                        e.Values[4] = "星期一";
                        break;
                    case 2:
                        e.Values[4] = "星期二";
                        break;
                    case 3:
                        e.Values[4] = "星期三";
                        break;
                    case 4:
                        e.Values[4] = "星期四";
                        break;
                    case 5:
                        e.Values[4] = "星期五";
                        break;
                    case 6:
                        e.Values[4] = "星期六";
                        break;
                    default:
                        break;
                }
                e.Values[5] = (_info.PushTime1.ToString("HH:mm") == "00:00" ? "" : _info.PushTime1.ToString("HH:mm"));
                e.Values[6] = (_info.PushTime2.ToString("HH:mm") == "00:00" ? "" : _info.PushTime2.ToString("HH:mm"));

                if (e.Values[5] == "" || e.Values[6] == "")
                {
                    e.Values[7] = "缺勤一天";
                }
            }
        }

        /// <summary>
        /// 导入窗口关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void wndImportAttend_Close(object sender, ExtAspNet.WindowCloseEventArgs e)
        {
            BindGrid();
        }

        #endregion
    }
}