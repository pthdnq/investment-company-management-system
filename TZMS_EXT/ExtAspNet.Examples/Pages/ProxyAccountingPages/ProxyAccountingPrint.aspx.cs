using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExtAspNet;
using System.Text;
using com.TZMS.Model;
using com.TZMS.Business;
using Aspose.Cells;
using System.IO;
using System.Data;

namespace TZMS.Web
{
    public partial class ProxyAccountingPrint : BasePage
    {
        /// <summary>
        /// 用于存储考勤信息的ViewState
        /// </summary>
        public List<ProxyAccountingApplyInfo> ViewStateProxyAccountingApplyInfo
        {
            get
            {
                if (ViewState["ProxyAccountingApplyInfo"] == null)
                {
                    return new List<ProxyAccountingApplyInfo>();
                }

                return (List<ProxyAccountingApplyInfo>)ViewState["ProxyAccountingApplyInfo"];
            }
            set
            {
                List<ProxyAccountingApplyInfo> lstAttendInfo = ViewStateProxyAccountingApplyInfo;
                if (lstAttendInfo.Count > 0)
                {
                    lstAttendInfo.Clear();
                }
                lstAttendInfo.AddRange(value);
                ViewState["ProxyAccountingApplyInfo"] = lstAttendInfo;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dpkStartTime.SelectedDate = DateTime.Now.AddMonths(-1);
                dpkEndTime.SelectedDate = DateTime.Now;

                BindProxyAccounting();
            }
        }

        #region 私有方法

        /// <summary>
        /// 绑定代帐单
        /// </summary>
        private void BindProxyAccounting()
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

            strCondition.Append(" IsDelete <> 1");
            strCondition.Append(" and state = 2");
            if (!string.IsNullOrEmpty(tbxSearch.Text.Trim()))
            {
                strCondition.Append(" and PayUnitName Like '%" + tbxSearch.Text.Trim() + "%'");
            }
            strCondition.Append(" and OpeningDate between '" + startTime.ToString("yyyy-MM-dd 00:00") + "' and '" + endTime.ToString("yyyy-MM-dd 23:59") + "'");

            #endregion

            List<ProxyAccountingApplyInfo> lstApply = new ProxyAccountingManage().GetApplyByCondition(strCondition.ToString());
            AddProxyAccounting(lstApply);
            ViewStateProxyAccountingApplyInfo = lstApply;
        }

        /// <summary>
        /// 生成代帐单
        /// </summary>
        /// <param name="lstProxy"></param>
        private void AddProxyAccounting(List<ProxyAccountingApplyInfo> lstProxy)
        {
            if (lstProxy == null || lstProxy.Count == 0)
                return;

            foreach (ProxyAccountingApplyInfo item in lstProxy)
            {
                ExtAspNet.Form form = new Form();
                form.EnableBackgroundColor = false;
                form.BodyPadding = "10px";
                form.LabelWidth = 55;
                form.ShowHeader = false;
                form.ShowBorder = true;
                form.Height = 150;
                form.Width = 600;

                // 第一行.
                FormRow row = new FormRow();
                row.ColumnWidths = "60%";

                ExtAspNet.Label label = new ExtAspNet.Label();
                label.Label = "交款单位";
                label.Text = item.PayUnitName;

                row.Items.Add(label);
                form.Rows.Add(row);

                // 第二行.
                row = new FormRow();
                row.ColumnWidths = "50% 50%";
                label = new ExtAspNet.Label();
                label.Label = "大写金额";
                label.Text = item.CNMoney;
                row.Items.Add(label);
                label = new ExtAspNet.Label();
                label.Label = "小写金额";
                label.Text = item.ENMoney.ToString();
                row.Items.Add(label);

                form.Rows.Add(row);

                // 第三行.
                row = new FormRow();
                row.ColumnWidths = "60%";
                label = new ExtAspNet.Label();
                label.Label = "收款事由";
                label.Text = item.Sument;

                row.Items.Add(label);
                form.Rows.Add(row);

                // 第四行.
                row = new FormRow();
                row.ColumnWidths = "50% 50%";
                label = new ExtAspNet.Label();
                label.Label = "收款方式";
                label.Text = item.CollectMethod;
                row.Items.Add(label);
                label = new ExtAspNet.Label();
                label.Label = "开票日期";
                label.Text = item.OpeningDate.ToString("yyyy-MM-dd");
                row.Items.Add(label);

                form.Rows.Add(row);

                // 第五行.
                row = new FormRow();
                row.ColumnWidths = "60%";
                label = new ExtAspNet.Label();
                label.Label = "收款单位";
                label.Text = "合肥吉信财务管理有限公司";
                row.Items.Add(label);
                form.Rows.Add(row);

                pelPrint.Items.Add(form);
            }
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
            BindProxyAccounting();
        }

        /// <summary>
        /// 导出事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnPrint_Click(object sender, EventArgs e)
        {
            List<ProxyAccountingApplyInfo> lstAttendInfo = (List<ProxyAccountingApplyInfo>)ViewStateProxyAccountingApplyInfo;
            if (lstAttendInfo.Count == 0)
            {
                Alert.Show("无数据可供导出!");
                return;
            }

            //实例化一个 workbook
            Workbook workbook = new Workbook();
            //打开模板(在服务器上)
            string path = System.Web.HttpContext.Current.Server.MapPath(Page.Request.ApplicationPath).TrimEnd('\\');
            path += @"\Template\收款收据.xls";
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
            worksheet.Name = "收款收据";
            //获得worksheet中的cell集合
            Cells cells = worksheet.Cells;
            cells.Clear();
            //向打开的worksheet中填充值
            string cellName = string.Empty;
            int pointX;
            int pointY;
            int rows = lstAttendInfo.Count * 7 - 1;
            //cells["A1"].PutValue("编号");
            //cells["B1"].PutValue("姓名");
            //cells["C1"].PutValue("部门");
            //cells["D1"].PutValue("刷卡日期");
            //cells["E1"].PutValue("星期");
            //cells["F1"].PutValue("上班");
            //cells["G1"].PutValue("下班");
            //cells["H1"].PutValue("备注");
            //6列,rows行
            for (int i = 0; i < rows; i++)
            {
                if (i > 0 && i % 7 == 0)
                {
                    continue;
                }

                pointX = 'A' - 1;
                for (int j = 0; j < 4; j++)
                {
                    pointY = 2 + i;
                    pointX++;

                    string strValue = string.Empty;
                    switch (pointX)
                    {
                        //case 65:
                        //    strValue = lstAttendInfo[i].JobNo;
                        //    break;
                        //case 66:
                        //    strValue = lstAttendInfo[i].Name;
                        //    break;
                        //case 67:
                        //    strValue = lstAttendInfo[i].Dept;
                        //    break;
                        //case 68:
                        //    strValue = lstAttendInfo[i].PushTime1.ToString("yyyy/MM/dd");
                        //    break;
                        //case 69:
                        //    strValue = GetCNWeek((int)lstAttendInfo[i].PushTime1.DayOfWeek);
                        //    break;
                        //case 70:
                        //    {
                        //        string strPushTime1 = lstAttendInfo[i].PushTime1.ToString("HH:mm");
                        //        strValue = (strPushTime1 == "00:00" ? "" : strPushTime1);
                        //    }
                        //    break;
                        //case 71:
                        //    {
                        //        string strPushTime2 = lstAttendInfo[i].PushTime2.ToString("HH:mm");
                        //        strValue = (strPushTime2 == "00:00" ? "" : strPushTime2);
                        //    }
                        //    break;
                        //case 72:
                        //    {
                        //        string strPushTime1 = lstAttendInfo[i].PushTime1.ToString("HH:mm");
                        //        string strPushTime2 = lstAttendInfo[i].PushTime2.ToString("HH:mm");
                        //        if (strPushTime1 == "00:00" || strPushTime1 == "00:00")
                        //        {
                        //            strValue = "缺勤一天";
                        //        }
                        //    }
                        //    break;

                        //default:
                        //    break;
                    }

                    cells[cellName].PutValue(strValue);
                }
            }
            //保存文件
            string fileName = HttpUtility.UrlEncode("收款收据.xls", System.Text.Encoding.UTF8);
            workbook.Save(fileName, FileFormatType.Excel2003, SaveType.OpenInExcel, HttpContext.Current.Response, System.Text.Encoding.UTF8);
            //关闭流
            Response.End();
            //btnExport.Enabled = true;
        }

        #endregion
    }
}