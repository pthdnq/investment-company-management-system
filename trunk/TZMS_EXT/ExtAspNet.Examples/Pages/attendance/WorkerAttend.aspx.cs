using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using ExtAspNet;
using com.TZMS.Business;
using com.TZMS.Model;
using Aspose.Cells;
using System.IO;

namespace TZMS.Web
{
    public partial class WorkerAttend : BasePage
    {
        /// <summary>
        /// 页面权限模式（可查看，可编辑）
        /// </summary>
        private VisitLevel PageModel
        {
            get
            {
                if (ViewState["VisitLevel"] == null)
                {
                    ViewState["VisitLevel"] = GetCurrentLevel("ygkq");
                }
                return (VisitLevel)ViewState["VisitLevel"];
            }
        }
        /// <summary>
        /// 用于存储考勤信息的ViewState
        /// </summary>
        public List<AttendInfo> ViewStateAttendInfo
        {
            get
            {
                if (ViewState["AttendInfo"] == null)
                {
                    return new List<AttendInfo>();
                }

                return (List<AttendInfo>)ViewState["AttendInfo"];
            }
            set
            {
                List<AttendInfo> lstAttendInfo = ViewStateAttendInfo;
                if (lstAttendInfo.Count > 0)
                {
                    lstAttendInfo.Clear();
                }
                lstAttendInfo.AddRange(value);
                ViewState["AttendInfo"] = lstAttendInfo;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //判断页面是否可编辑（可查看不用考虑）
                if (PageModel != VisitLevel.Edit && PageModel != VisitLevel.Both)
                {
                    btnImport.Enabled = false;
                }

                dpkStartTime.SelectedDate = DateTime.Now.AddMonths(-1);
                dpkEndTime.SelectedDate = DateTime.Now;

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

            if (!string.IsNullOrEmpty(tbxSearch.Text.Trim()))
            {
                strCondition.Append(" (Name Like '%" + tbxSearch.Text.Trim() + "%' or AccountNo Like '%" + tbxSearch.Text.Trim() + "%') and");
            }

            strCondition.Append(" PushTime1 between '" + startTime.ToString("yyyy-MM-dd 00:00") + "' and '" + endTime.ToString("yyyy-MM-dd 23:59") + "'");
            strCondition.Append(" order by PushTime1 asc");

            #endregion

            WorkerAttendManage _manage = new WorkerAttendManage();
            List<AttendInfo> lstAttendInfo = _manage.GetAttendInfoByCondition(strCondition.ToString());
            ViewStateAttendInfo = lstAttendInfo;
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
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        /// <summary>
        /// 导出Excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnExport_Click(object sender, EventArgs e)
        {
            List<AttendInfo> lstAttendInfo = (List<AttendInfo>)ViewStateAttendInfo;
            if (lstAttendInfo.Count == 0)
            {
                Alert.Show("无数据可供导出!");
                return;
            }

            //实例化一个 workbook
            Workbook workbook = new Workbook();
            //打开模板(在服务器上)
            string path = System.Web.HttpContext.Current.Server.MapPath(Page.Request.ApplicationPath).TrimEnd('\\');
            path += @"\Template\考勤记录.xls";
            if (!System.IO.File.Exists(path))
            {
                Alert.Show("下载失败，服务器中模板丢失!");
                return;
            }
            FileAttributes fileAttribute = File.GetAttributes(path);
            if ((fileAttribute & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
            {
                File.SetAttributes(path, FileAttributes.Normal);
            }

            workbook.Open(path);
            //获得一个worksheet
            Worksheet worksheet = workbook.Worksheets[0];
            worksheet.Name = "员工考勤";
            //获得worksheet中的cell集合
            Cells cells = worksheet.Cells;
            cells.Clear();
            //向打开的worksheet中填充值
            string cellName = string.Empty;
            int pointX;
            int pointY;
            int rows = lstAttendInfo.Count;
            cells["A1"].PutValue("编号");
            cells["B1"].PutValue("姓名");
            cells["C1"].PutValue("部门");
            cells["D1"].PutValue("刷卡日期");
            cells["E1"].PutValue("星期");
            cells["F1"].PutValue("上班");
            cells["G1"].PutValue("下班");
            cells["H1"].PutValue("备注");
            //6列,rows行
            for (int i = 0; i < rows; i++)
            {
                pointX = 'A' - 1;
                for (int j = 0; j < 8; j++)
                {
                    pointY = 2 + i;
                    pointX++;
                    cellName = Convert.ToChar(pointX).ToString() + pointY.ToString();

                    string strValue = string.Empty;
                    switch (pointX)
                    {
                        case 65:
                            strValue = lstAttendInfo[i].JobNo;
                            break;
                        case 66:
                            strValue = lstAttendInfo[i].Name;
                            break;
                        case 67:
                            strValue = lstAttendInfo[i].Dept;
                            break;
                        case 68:
                            strValue = lstAttendInfo[i].PushTime1.ToString("yyyy/MM/dd");
                            break;
                        case 69:
                            strValue = GetCNWeek((int)lstAttendInfo[i].PushTime1.DayOfWeek);
                            break;
                        case 70:
                            {
                                string strPushTime1 = lstAttendInfo[i].PushTime1.ToString("HH:mm");
                                strValue = (strPushTime1 == "00:00" ? "" : strPushTime1);
                            }
                            break;
                        case 71:
                            {
                                string strPushTime2 = lstAttendInfo[i].PushTime2.ToString("HH:mm");
                                strValue = (strPushTime2 == "00:00" ? "" : strPushTime2);
                            }
                            break;
                        case 72:
                            {
                                //string strPushTime1 = lstAttendInfo[i].PushTime1.ToString("HH:mm");
                                //string strPushTime2 = lstAttendInfo[i].PushTime2.ToString("HH:mm");
                                //if (strPushTime1 == "00:00" || strPushTime1 == "00:00")
                                //{
                                //    strValue = "缺勤一天";
                                //}
                                strValue = lstAttendInfo[i].Other;
                            }
                            break;

                        default:
                            break;
                    }

                    cells[cellName].PutValue(strValue);
                }
            }
            //保存文件
            string fileName = HttpUtility.UrlEncode("考勤记录.xls", System.Text.Encoding.UTF8);
            workbook.Save(fileName, FileFormatType.Excel2003, SaveType.OpenInExcel, HttpContext.Current.Response, System.Text.Encoding.UTF8);
            //关闭流
            Response.End();
            btnExport.Enabled = true;
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
                e.Values[4] = GetCNWeek(i);
                e.Values[5] = (_info.PushTime1.ToString("HH:mm") == "00:00" ? "" : _info.PushTime1.ToString("HH:mm"));
                e.Values[6] = (_info.PushTime2.ToString("HH:mm") == "00:00" ? "" : _info.PushTime2.ToString("HH:mm"));

                //if (e.Values[5].ToString() == "" || e.Values[6].ToString() == "")
                //{
                //    e.Values[7] = "缺勤一天";
                //}
                e.Values[7] = _info.Other;
            }
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