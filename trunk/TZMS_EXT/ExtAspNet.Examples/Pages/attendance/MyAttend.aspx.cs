using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.TZMS.Model;
using ExtAspNet;
using System.Text;
using com.TZMS.Business;

namespace TZMS.Web
{
    public partial class MyAttend : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dpkStartTime.SelectedDate = DateTime.Now.AddMonths(-1);
                dpkEndTime.SelectedDate = DateTime.Now;

                BindGrid();
            }
        }

        #region 私有方法

        /// <summary>
        /// 绑定列表
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
            strCondition.Append("JobNo='" + CurrentUser.JobNo + "'");
            strCondition.Append(" and AccountNo = '" + CurrentUser.AccountNo + "'");
            strCondition.Append(" and Name='" + CurrentUser.Name + "'");
            strCondition.Append(" and PushTime1 between '" + startTime.ToString("yyyy-MM-dd 00:00") + "' and '" + endTime.ToString("yyyy-MM-dd 23:59") + "'");
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

        /// <summary>
        /// 获取中文星期
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        private string GetCNWeek(int i)
        {
            string strWeek = string.Empty;

            switch (i)
            {
                case 0:
                    strWeek = "星期天";
                    break;
                case 1:
                    strWeek = "星期一";
                    break;
                case 2:
                    strWeek = "星期二";
                    break;
                case 3:
                    strWeek = "星期三";
                    break;
                case 4:
                    strWeek = "星期四";
                    break;
                case 5:
                    strWeek = "星期五";
                    break;
                case 6:
                    strWeek = "星期六";
                    break;
                default:
                    break;
            }

            return strWeek;
        }

        #endregion

        /// <summary>
        /// 查询时间
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
        protected void gridAttend_PageIndexChange(object sender, ExtAspNet.GridPageEventArgs e)
        {
            gridAttend.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        /// <summary>
        /// 数据绑定事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridAttend_RowDataBound(object sender, ExtAspNet.GridRowEventArgs e)
        {
            if (e.DataItem != null)
            {
                AttendInfo _info = (AttendInfo)e.DataItem;
                e.Values[0] = _info.PushTime1.ToString("yyyy-MM-dd");
                int i = (int)_info.PushTime1.DayOfWeek;
                e.Values[1] = GetCNWeek(i);
                e.Values[2] = (_info.PushTime1.ToString("HH:mm") == "00:00" ? "" : _info.PushTime1.ToString("HH:mm"));
                e.Values[3] = (_info.PushTime2.ToString("HH:mm") == "00:00" ? "" : _info.PushTime2.ToString("HH:mm"));

                if (e.Values[2].ToString() == "" || e.Values[3].ToString() == "")
                {
                    e.Values[4] = "缺勤一天";
                }
            }
        }
    }
}