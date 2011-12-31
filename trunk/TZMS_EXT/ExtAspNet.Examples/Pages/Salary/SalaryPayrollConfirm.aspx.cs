using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExtAspNet;
using com.TZMS.Model;
using com.TZMS.Business;
using System.Data;
using Aspose.Cells;
using System.IO;

namespace TZMS.Web
{
    public partial class SalaryPayrollConfirm : BasePage
    {
        /// <summary>
        /// ApplyID
        /// </summary>
        public string ApplyID
        {
            get
            {
                if (ViewState["ApplyID"] == null)
                {
                    return null;
                }
                return ViewState["ApplyID"].ToString();
            }

            set
            {
                ViewState["ApplyID"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ApplyID = Request.QueryString["ID"];

                BindSalaryMsgInfo();
            }
        }

        #region 私有方法

        private void BindSalaryMsgInfo()
        {
            if (string.IsNullOrEmpty(ApplyID))
                return;
            SalaryManage _manage = new SalaryManage();
            SalaryMsgInfo _info = _manage.GetSalaryMsgByObjectID(ApplyID);
            if (_info != null)
            {
                lblYear.Text = _info.Year.ToString();
                lblMonth.Text = _info.Month.ToString();
                lblSumMoney.Text = _info.SumMoney.ToString();
                BindWorkerSalaryMsgGrid();
                SetControlState(_info);
            }
        }

        /// <summary>
        /// 绑定员工薪资信息列表
        /// </summary>
        private void BindWorkerSalaryMsgGrid()
        {
            if (string.IsNullOrEmpty(ApplyID))
                return;

            List<WorkerSalaryMsgInfo> lstWorkerSalaryMsgInfo = new SalaryManage().GetWorkerSalaryMsgByCondition(" SalaryMsgID = '" + ApplyID + "' order by Dept desc");
            gridWorkerSalaryMsg.RecordCount = lstWorkerSalaryMsgInfo.Count;
            this.gridWorkerSalaryMsg.DataSource = lstWorkerSalaryMsgInfo;
            this.gridWorkerSalaryMsg.DataBind();
        }

        /// <summary>
        /// 根据
        /// </summary>
        /// <param name="info"></param>
        private void SetControlState(SalaryMsgInfo info)
        {
            if (info != null)
            {
                if (info.State == 3)
                    btnSubmit.Enabled = false;
            }
        }

        /// <summary>
        /// 导出工资单
        /// </summary>
        private void ExportSalary()
        {
            if (string.IsNullOrEmpty(ApplyID))
                return;

            List<WorkerSalaryMsgInfo> lstWorkerSalary = new SalaryManage().GetWorkerSalaryMsgByCondition(" SalaryMsgID ='" + ApplyID + "' order by Dept desc");
            if (lstWorkerSalary.Count == 0)
            {
                Alert.Show("无数据可供导出!");
                return;
            }

            //实例化一个 workbook
            Workbook workbook = new Workbook();
            //打开模板(在服务器上)
            string path = System.Web.HttpContext.Current.Server.MapPath(Page.Request.ApplicationPath).TrimEnd('\\');
            path += @"\Template\工资表.xls";
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
            worksheet.Name = "工资单";
            //获得worksheet中的cell集合
            Cells cells = worksheet.Cells;
            cells.Clear();
            //向打开的worksheet中填充值
            string cellName = string.Empty;
            int pointX;
            int pointY;
            int rows = lstWorkerSalary.Count * 4;
            //6列,rows行
            cells.SetColumnWidth(0, 12);
            cells.SetColumnWidth(1, 10);
            cells.SetColumnWidth(2, 8.5);
            cells.SetColumnWidth(3, 37.25);
            cells.SetColumnWidth(4, 9.5);
            cells.SetColumnWidth(5, 23.5);
            cells.SetColumnWidth(6, 12.75);
            cells.SetColumnWidth(7, 13.88);
            cells.SetColumnWidth(8, 10.88);
            cells.SetColumnWidth(9, 10.88);
            cells.SetColumnWidth(10, 10.88);
            cells.SetColumnWidth(11, 10.25);
            cells.SetColumnWidth(12, 6);
            cells.SetColumnWidth(13, 6);
            cells.SetColumnWidth(14, 6);
            cells.SetColumnWidth(15, 6);
            cells.SetColumnWidth(16, 6);
            cells.SetColumnWidth(17, 6);
            cells.SetColumnWidth(18, 6);
            cells.SetColumnWidth(19, 7.5);
            cells.SetColumnWidth(20, 7.5);
            cells.SetColumnWidth(21, 10.63);

            for (int i = 0; i < rows; i++)
            {
                if (i > 0 && i % 4 == 0)
                {
                    continue;
                }

                pointX = 'A' - 1;
                for (int j = 0; j < 21; j++)
                {
                    pointY = 2 + i;
                    pointX++;
                    string strValue = string.Empty;
                    switch (pointX)
                    {
                        case 65:
                            if (i % 4 == 1)
                            {
                                cells.Merge(i, 0, 2, 1);
                                cells.SetRowHeight(i, 22);

                            }
                            else if (i % 4 == 3)
                            { }

                            //if (i % 7 == 1)
                            //{
                            //    cells.Merge(i, 0, 1, 2);
                            //    cells.SetRowHeight(i, 40);
                            //    Aspose.Cells.Style style = cells.Rows[i].Style;
                            //    StyleFlag flag = new StyleFlag();

                            //    style.HorizontalAlignment = TextAlignmentType.Center;
                            //    style.Font.IsBold = true;

                            //    flag.HorizontalAlignment = true;
                            //    flag.Font = true;

                            //    cells.ApplyRowStyle(i, style, flag);
                            //    //cells.CreateRange(i, 0, 1, 2);
                            //    strValue = "收款单据";
                            //}
                            //else if (i % 7 == 2)
                            //{
                            //    cells.Merge(i, 0, 1, 2);
                            //    cells.SetRowHeight(i, 20);

                            //    Cell cell = cells[i, j];
                            //    Aspose.Cells.Style style = cell.Style;
                            //    style.Borders[BorderType.TopBorder].LineStyle = CellBorderType.Thin;
                            //    style.Borders[BorderType.TopBorder].Color = Color.Black;
                            //    style.Borders[BorderType.LeftBorder].LineStyle = CellBorderType.Thin;
                            //    style.Borders[BorderType.LeftBorder].Color = Color.Black;
                            //    cell.SetStyle(style);

                            //    strValue = "交款单位:" + lstAttendInfo[i / 7].PayUnitName;
                            //}
                            //else if (i % 7 == 3)
                            //{
                            //    cells.SetRowHeight(i, 20);
                            //    Cell cell = cells[i, j];
                            //    Aspose.Cells.Style style = cell.Style;
                            //    style.Borders[BorderType.LeftBorder].LineStyle = CellBorderType.Thin;
                            //    style.Borders[BorderType.LeftBorder].Color = Color.Black;
                            //    cell.SetStyle(style);
                            //    strValue = "金额(大写):" + lstAttendInfo[i / 7].CNMoney;
                            //}
                            //else if (i % 7 == 4)
                            //{
                            //    cells.Merge(i, 0, 1, 2);
                            //    cells.SetRowHeight(i, 20);
                            //    Cell cell = cells[i, j];
                            //    Aspose.Cells.Style style = cell.Style;
                            //    style.Borders[BorderType.LeftBorder].LineStyle = CellBorderType.Thin;
                            //    style.Borders[BorderType.LeftBorder].Color = Color.Black;
                            //    cell.SetStyle(style);
                            //    strValue = "收款事由:" + lstAttendInfo[i / 7].Sument;

                            //}
                            //else if (i % 7 == 5)
                            //{
                            //    cells.SetRowHeight(i, 20);
                            //    Cell cell = cells[i, j];
                            //    Aspose.Cells.Style style = cell.Style;
                            //    style.Borders[BorderType.LeftBorder].LineStyle = CellBorderType.Thin;
                            //    style.Borders[BorderType.LeftBorder].Color = Color.Black;
                            //    style.Borders[BorderType.BottomBorder].LineStyle = CellBorderType.Thin;
                            //    style.Borders[BorderType.BottomBorder].Color = Color.Black;
                            //    cell.SetStyle(style);
                            //    strValue = "收款方式:" + lstAttendInfo[i / 7].CollectMethod;
                            //}
                            //else if (i % 7 == 6)
                            //{
                            //}

                            break;
                        case 66:
                            //if (i % 7 == 1)
                            //{
                            //}
                            //else if (i % 7 == 2)
                            //{
                            //    Cell cell = cells[i, j];
                            //    Aspose.Cells.Style style = cell.Style;
                            //    style.Borders[BorderType.TopBorder].LineStyle = CellBorderType.Thin;
                            //    style.Borders[BorderType.TopBorder].Color = Color.Black;
                            //    style.Borders[BorderType.RightBorder].LineStyle = CellBorderType.Thin;
                            //    style.Borders[BorderType.RightBorder].Color = Color.Black;
                            //    cell.SetStyle(style);
                            //}
                            //else if (i % 7 == 3)
                            //{
                            //    Cell cell = cells[i, j];
                            //    Aspose.Cells.Style style = cell.Style;
                            //    style.Borders[BorderType.RightBorder].LineStyle = CellBorderType.Thin;
                            //    style.Borders[BorderType.RightBorder].Color = Color.Black;
                            //    cell.SetStyle(style);
                            //    strValue = "￥" + lstAttendInfo[i / 7].ENMoney.ToString();
                            //}
                            //else if (i % 7 == 4)
                            //{
                            //    Cell cell = cells[i, j];
                            //    Aspose.Cells.Style style = cell.Style;
                            //    style.Borders[BorderType.RightBorder].LineStyle = CellBorderType.Thin;
                            //    style.Borders[BorderType.RightBorder].Color = Color.Black;
                            //    cell.SetStyle(style);
                            //}
                            //else if (i % 7 == 5)
                            //{
                            //    Cell cell = cells[i, j];
                            //    Aspose.Cells.Style style = cell.Style;
                            //    style.Borders[BorderType.BottomBorder].LineStyle = CellBorderType.Thin;
                            //    style.Borders[BorderType.BottomBorder].Color = Color.Black;
                            //    style.Borders[BorderType.RightBorder].LineStyle = CellBorderType.Thin;
                            //    style.Borders[BorderType.RightBorder].Color = Color.Black;
                            //    cell.SetStyle(style);
                            //    strValue = "开票日期:" + lstAttendInfo[i / 7].OpeningDate.ToString("yyyy年-MM月-dd日");
                            //}
                            //else if (i % 7 == 6)
                            //{
                            //    cells.SetRowHeight(i, 20);
                            //    strValue = "收款单位:合肥吉信财务管理有限公司";
                            //}
                            break;
                    }

                    cells[i, j].PutValue(strValue);
                    //cells[cellName].PutValue(strValue);
                }
            }
            //保存文件
            string fileName = HttpUtility.UrlEncode("工资单.xls", System.Text.Encoding.UTF8);
            workbook.Save(fileName, FileFormatType.Excel2003, SaveType.OpenInExcel, HttpContext.Current.Response, System.Text.Encoding.UTF8);
            //关闭流
            Response.End();
            //btnExport.Enabled = true;
        }

        #endregion

        #region 页面事件

        /// <summary>
        /// 关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnClose_Click(object sender, EventArgs e)
        {
            PageContext.RegisterStartupScript(ExtAspNet.ActiveWindow.GetHidePostBackReference());
        }

        /// <summary>
        /// 确认发放
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ApplyID))
                return;
            SalaryManage _manage = new SalaryManage();
            SalaryMsgInfo _info = _manage.GetSalaryMsgByObjectID(ApplyID);
            int result = 3;
            if (_info != null)
            {
                _info.State = 3;
                result = _manage.UpdateSalaryMsg(_info);
                if (result == -1)
                {
                    CashFlowManage _cashFlowManage = new CashFlowManage();
                    _cashFlowManage.Add(_info.SumMoney, DateTime.Now, "Payment", _info.Year + "年" + _info.Month + "月发放工资", TZMS.Common.Biz.SalaryPayroll, string.Empty);
                }
            }

            if (result == -1)
            {
                this.btnClose_Click(null, null);
            }
            else
            {
                Alert.Show("确认支付失败!");
            }

        }

        /// <summary>
        /// 导出工资单事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnExport_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ApplyID))
                return;
            CommSelect _commSelect = new CommSelect();
            ComHelp _comHelp = new ComHelp();
            _comHelp.TableName = "WorkerSalaryView";
            _comHelp.SelectList = "*";
            _comHelp.SearchCondition = " SalaryMsgID = '" + ApplyID + "'";
            _comHelp.PageSize = Int32.MaxValue;
            _comHelp.PageIndex = 0;
            _comHelp.OrderExpression = "Dept desc";

            DataTable dtbWorkerSalary = _commSelect.ComSelect(ref _comHelp);
            WorkbookDesigner designer = new WorkbookDesigner();
            dtbWorkerSalary.TableName = "Salary";
            string path = System.Web.HttpContext.Current.Server.MapPath(Page.Request.ApplicationPath).TrimEnd('\\');
            path += @"\Template\工资表.xls";
            if (!System.IO.File.Exists(path))
            {
                Alert.Show("下载失败，服务器中模板丢失!");
                return;
            }
            designer.Open(path);

            Aspose.Cells.Worksheet w = designer.Workbook.Worksheets[0];

            for (int i = 0; i < dtbWorkerSalary.Rows.Count; i++)
            {
                if (i > 0)
                {
                    // 设置标题头内容
                    w.Cells[i * 4 + 1, 0].PutValue("月份");
                    w.Cells[i * 4 + 1, 1].PutValue("姓名");
                    w.Cells[i * 4 + 1, 2].PutValue("应发款");
                    w.Cells[i * 4 + 1, 10].PutValue("应发工资");
                    w.Cells[i * 4 + 1, 11].PutValue("代扣款");
                    w.Cells[i * 4 + 1, 21].PutValue("实发工资");
                    w.Cells[i * 4 + 2, 2].PutValue("基本工资");
                    w.Cells[i * 4 + 2, 3].PutValue("工龄工资");
                    w.Cells[i * 4 + 2, 4].PutValue("试用期补发工资");
                    w.Cells[i * 4 + 2, 5].PutValue("年终奖");
                    w.Cells[i * 4 + 2, 6].PutValue("奖励工资");
                    w.Cells[i * 4 + 2, 7].PutValue("考核工资");
                    w.Cells[i * 4 + 2, 8].PutValue("餐补");
                    w.Cells[i * 4 + 2, 9].PutValue("交通补助");
                    w.Cells[i * 4 + 2, 11].PutValue("迟到");
                    w.Cells[i * 4 + 2, 12].PutValue("早退");
                    w.Cells[i * 4 + 2, 13].PutValue("旷工");
                    w.Cells[i * 4 + 2, 14].PutValue("事假");
                    w.Cells[i * 4 + 2, 15].PutValue("病假");
                    w.Cells[i * 4 + 2, 16].PutValue("社保");
                    w.Cells[i * 4 + 2, 17].PutValue("罚款");
                    w.Cells[i * 4 + 2, 18].PutValue("餐费");
                    w.Cells[i * 4 + 2, 19].PutValue("保洁费");
                    w.Cells[i * 4 + 2, 20].PutValue("旅游费");

                    // 合并.
                    w.Cells.Merge(i * 4 + 1, 0, 2, 1);
                    w.Cells.Merge(i * 4 + 1, 1, 2, 1);
                    w.Cells.Merge(i * 4 + 1, 2, 1, 8);
                    w.Cells.Merge(i * 4 + 1, 10, 2, 1);
                    w.Cells.Merge(i * 4 + 1, 11, 1, 10);
                    w.Cells.Merge(i * 4 + 1, 21, 2, 1);

                    // 设置标题头样式
                    for (int j = 1; j < 5; j++)
                    {
                        for (int k = 0; k < 22; k++)
                        {
                            w.Cells[i * 4 + j, k].Style = w.Cells[j, k].Style;
                        }
                    }

                    //w.Cells[i * 4 + 1, 0].Style = w.Cells[1, 0].Style;
                    //w.Cells[i * 4 + 1, 1].Style = w.Cells[1, 1].Style;
                    //w.Cells[i * 4 + 1, 2].Style = w.Cells[1, 2].Style;
                    //w.Cells[i * 4 + 1, 10].Style = w.Cells[1, 10].Style;
                    //w.Cells[i * 4 + 1, 11].Style = w.Cells[1, 11].Style;
                    //w.Cells[i * 4 + 1, 21].Style = w.Cells[1, 21].Style;
                    //w.Cells[i * 4 + 2, 2].Style = w.Cells[2, 2].Style;
                    //w.Cells[i * 4 + 2, 3].Style = w.Cells[2, 3].Style;
                    //w.Cells[i * 4 + 2, 4].Style = w.Cells[2, 4].Style;
                    //w.Cells[i * 4 + 2, 5].Style = w.Cells[2, 5].Style;
                    //w.Cells[i * 4 + 2, 6].Style = w.Cells[2, 6].Style;
                    //w.Cells[i * 4 + 2, 7].Style = w.Cells[2, 7].Style;
                    //w.Cells[i * 4 + 2, 8].Style = w.Cells[2, 8].Style;
                    //w.Cells[i * 4 + 2, 9].Style = w.Cells[2, 9].Style;
                    //w.Cells[i * 4 + 2, 11].Style = w.Cells[2, 11].Style;
                    //w.Cells[i * 4 + 2, 12].Style = w.Cells[2, 12].Style;
                    //w.Cells[i * 4 + 2, 13].Style = w.Cells[2, 13].Style;
                    //w.Cells[i * 4 + 2, 14].Style = w.Cells[2, 14].Style;
                    //w.Cells[i * 4 + 2, 15].Style = w.Cells[2, 15].Style;
                    //w.Cells[i * 4 + 2, 16].Style = w.Cells[2, 16].Style;
                    //w.Cells[i * 4 + 2, 17].Style = w.Cells[2, 17].Style;
                    //w.Cells[i * 4 + 2, 18].Style = w.Cells[2, 18].Style;
                    //w.Cells[i * 4 + 2, 19].Style = w.Cells[2, 19].Style;
                    //w.Cells[i * 4 + 2, 20].Style = w.Cells[2, 20].Style;
                }
            }

            string[] arrayDate = new string[dtbWorkerSalary.Rows.Count];
            for (int i = 0; i < dtbWorkerSalary.Rows.Count; i++)
            {
                arrayDate[i] = dtbWorkerSalary.Rows[0]["Year"] + "." + dtbWorkerSalary.Rows[0]["Month"];
            }
            designer.SetDataSource(dtbWorkerSalary);
            designer.SetDataSource("Date", arrayDate);
            designer.SetDataSource("Title", "吉信投资集团" + dtbWorkerSalary.Rows[0]["Year"] + "年"
                + dtbWorkerSalary.Rows[0]["Month"] + "月份工资表（共计：" + dtbWorkerSalary.Rows[0]["SumMoney"] + "元）");

            designer.Process();
            string name = HttpUtility.UrlEncode("吉信投资集团" + lblYear.Text + "年"
                + lblMonth.Text + "月份工资单.xls", System.Text.Encoding.UTF8);

            designer.Save(string.Format(name), SaveType.OpenInExcel, FileFormatType.Excel2003, Response);
            Response.End();
        }

        /// <summary>
        /// 数据行绑定事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridWorkerSalaryMsg_RowDataBound(object sender, GridRowEventArgs e)
        {

        }

        #endregion
    }
}