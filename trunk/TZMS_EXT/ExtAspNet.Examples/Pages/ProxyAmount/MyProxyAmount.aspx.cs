using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.TZMS.Model;
using ExtAspNet;
using System.Text;
using com.TZMS.Business.ProxyAmount;
using Aspose.Cells;
using System.Drawing;
using System.IO;

namespace TZMS.Web
{
    public partial class MyProxyAmount : BasePage
    {
        /// <summary>
        /// Data Source
        /// </summary>
        public List<ProxyAmountInfo> DataSource
        {
            get
            {
                if (ViewState["ProxyAmountData"] == null)
                {
                    return new List<ProxyAmountInfo>();
                }

                return (List<ProxyAmountInfo>)ViewState["ProxyAmountData"];
            }
            set
            {
                ViewState["ProxyAmountData"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CurrentLevel = GetCurrentLevel("wddzd");

                dpkStartTime.SelectedDate = DateTime.Now.AddMonths(-1);
                dpkEndTime.SelectedDate = DateTime.Now;

                BindGrid();

                if (CurrentLevel == VisitLevel.View)
                {
                    btnPrint.Enabled = false;
                }
            }
            else
            {
                System.Diagnostics.Debug.WriteLine(Request.Form["__EVENTTARGET"]);

                if (Request.Form["__EVENTTARGET"].Contains("btnDynamic"))
                    GenerateStyle(DataSource);
            }
        }

        #region 私有方法

        /// <summary>
        /// 绑定数据
        /// </summary>
        public void BindGrid()
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

            strCondition.Append(" IsDelete <> 1 and ProxyAmounterID = '" + CurrentUser.ObjectId.ToString() + "'");
            if (!string.IsNullOrEmpty(tbxSearch.Text.Trim()))
            {
                strCondition.Append(" and ProxyAmountUnitName Like '%" + tbxSearch.Text.Trim() + "%'");
            }

            strCondition.Append(" and OpeningDate between '" + startTime.ToString("yyyy-MM-dd 00:00") + "' and '" + endTime.ToString("yyyy-MM-dd 23:59") + "'");
            strCondition.Append(" order by State asc, OpeningDate desc ");
            #endregion

            List<ProxyAmountInfo> lstProxyAmount = new ProxyAmountManage().GetProxyAmountByCondition(strCondition.ToString());

            DataSource = lstProxyAmount;
            // 生成页面样式.
            GenerateStyle(DataSource);
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        /// <param name="lstProxyAmount"></param>
        private void GenerateStyle(List<ProxyAmountInfo> lstProxyAmount)
        {
            if (lstProxyAmount.Count == 0)
                return;

            pelPrint.Items.Clear();

            int i = 0;
            foreach (ProxyAmountInfo info in lstProxyAmount)
            {
                ExtAspNet.Panel panel = new ExtAspNet.Panel();
                panel.ShowBorder = false;
                panel.ShowHeader = false;
                panel.EnableBackgroundColor = true;
                panel.Layout = Layout.Column;

                #region 代帐单

                ExtAspNet.Form form = new Form();
                form.EnableBackgroundColor = false;
                form.BodyPadding = "10px";
                form.LabelWidth = 55;
                form.ShowHeader = false;
                form.ShowBorder = true;
                form.Height = 150;
                form.Width = 500;

                // 第一行.
                FormRow row = new FormRow();
                row.ColumnWidths = "60%";

                ExtAspNet.Label label = new ExtAspNet.Label();
                label.Label = "交款单位";
                label.Text = info.ProxyAmountUnitName;

                row.Items.Add(label);
                form.Rows.Add(row);

                // 第二行.
                row = new FormRow();
                row.ColumnWidths = "50% 50%";
                label = new ExtAspNet.Label();
                label.Label = "大写金额";
                label.Text = info.CNMoney;
                row.Items.Add(label);
                label = new ExtAspNet.Label();
                label.Label = "小写金额";
                label.Text =info.ENMoneyFlag+ info.ENMoney.ToString();
                row.Items.Add(label);

                form.Rows.Add(row);

                // 第三行.
                row = new FormRow();
                row.ColumnWidths = "60%";
                label = new ExtAspNet.Label();
                label.Label = "收款事由";
                label.Text = info.Sument;

                row.Items.Add(label);
                form.Rows.Add(row);

                // 第四行.
                row = new FormRow();
                row.ColumnWidths = "50% 50%";
                label = new ExtAspNet.Label();
                label.Label = "收款方式";
                label.Text = info.CollectMethod;
                row.Items.Add(label);
                label = new ExtAspNet.Label();
                label.Label = "开票日期";
                label.Text = info.OpeningDate.ToString("yyyy-MM-dd");
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

                panel.Items.Add(form);

                #endregion

                #region 是否上交

                ExtAspNet.Form form2 = new Form();
                form2.EnableBackgroundColor = false;
                form2.BodyPadding = "10px";
                form2.LabelWidth = 55;
                form2.ShowHeader = false;
                form2.ShowBorder = true;
                form2.Height = 150;
                form2.Width = 100;

                ExtAspNet.FormRow row2 = new FormRow();
                ExtAspNet.Label label2 = new ExtAspNet.Label();
                row2.Items.Add(label2);
                form2.Rows.Add(row2);

                row2 = new FormRow();
                label2 = new ExtAspNet.Label();
                row2.Items.Add(label2);
                form2.Rows.Add(row2);

                row2 = new FormRow();
                row2.ColumnWidths = "100%";
                label2 = new ExtAspNet.Label();
                label2.ID = "lblDynamic" + i;
                label2.ShowLabel = false;
                label2.CssStyle = "TEXT-ALIGN:center";
                label2.Width = 100;
                label2.Text = info.State == 0 ? "待上交" : "已上交";
                row2.Items.Add(label2);
                form2.Rows.Add(row2);

                row2 = new FormRow();
                label2 = new ExtAspNet.Label();
                row2.Items.Add(label2);
                form2.Rows.Add(row2);

                row2 = new FormRow();
                label2 = new ExtAspNet.Label();
                row2.Items.Add(label2);
                form2.Rows.Add(row2);

                panel.Items.Add(form2);

                #endregion

                #region 出纳是否收到收款

                ExtAspNet.Form form3 = new Form();
                form3.EnableBackgroundColor = false;
                form3.BodyPadding = "10px";
                form3.LabelWidth = 55;
                form3.ShowHeader = false;
                form3.ShowBorder = true;
                form3.Height = 150;
                form3.Width = 100;

                ExtAspNet.FormRow row3 = new FormRow();
                ExtAspNet.Label label3 = new ExtAspNet.Label();
                row3.Items.Add(label3);
                form3.Rows.Add(row3);

                row3 = new FormRow();
                label3 = new ExtAspNet.Label();
                row3.Items.Add(label3);
                form3.Rows.Add(row3);

                row3 = new FormRow();
                row3.ColumnWidths = "100%";
                label3 = new ExtAspNet.Label();
                label3.ShowLabel = false;
                label3.CssStyle = "TEXT-ALIGN:center";
                label3.Width = 100;
                label3.Text = info.State == 2 ? "出纳已收到收款" : "出纳未收到收款";
                row3.Items.Add(label3);
                form3.Rows.Add(row3);

                row3 = new FormRow();
                label3 = new ExtAspNet.Label();
                row3.Items.Add(label3);
                form3.Rows.Add(row3);

                row3 = new FormRow();
                label3 = new ExtAspNet.Label();
                row3.Items.Add(label3);
                form3.Rows.Add(row3);

                panel.Items.Add(form3);

                #endregion

                #region 按钮

                ExtAspNet.Form form4 = new Form();
                form4.EnableBackgroundColor = false;
                form4.BodyPadding = "10px";
                form4.LabelWidth = 55;
                form4.ShowHeader = false;
                form4.ShowBorder = true;
                form4.Height = 150;
                form4.Width = 100;

                ExtAspNet.FormRow row4 = new FormRow();
                ExtAspNet.Label label4 = new ExtAspNet.Label();
                row4.Items.Add(label4);
                form4.Rows.Add(row4);

                row4 = new FormRow();
                label4 = new ExtAspNet.Label();
                row4.Items.Add(label4);
                form4.Rows.Add(row4);

                row4 = new FormRow();
                row4.ColumnWidths = "100%";
                ExtAspNet.Button btnButton = new ExtAspNet.Button();
                btnButton.ID = "btnDynamic" + i;
                btnButton.Text = "上交代账费";
                btnButton.Click += new EventHandler(btnButton_Click);
                if (info.State != 0)
                {
                    btnButton.Enabled = false;
                }

                if (CurrentLevel == VisitLevel.View)
                {
                    btnButton.Enabled = false;
                }

                row4.Items.Add(btnButton);
                form4.Rows.Add(row4);

                panel.Items.Add(form4);

                ++i;

                #endregion

                pelPrint.Items.Add(panel);
            }
        }

        void btnButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Event");

            ExtAspNet.Button btnButton = (ExtAspNet.Button)sender;
            int index = Convert.ToInt32(btnButton.ID.Replace("btnDynamic", ""));
            if (DataSource.Count > 0 && (DataSource.Count - 1 >= index))
            {
                ProxyAmountManage _manage = new ProxyAmountManage();
                ProxyAmountInfo _info = DataSource[index];
                _info.State = 1;
                _manage.UpdateProxyAmount(_info);

                btnButton.Enabled = false;
                ExtAspNet.Form form = ((ExtAspNet.Panel)pelPrint.Items[index]).Items[1] as ExtAspNet.Form;
                ExtAspNet.FormRow row = form.Rows[2];
                ExtAspNet.Label lblDynamic = (row.Items[0] as ExtAspNet.Label);
                lblDynamic.Text = "已上交";
                //BindGrid();

                //GenerateStyle(DataSource);
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
            BindGrid();
        }

        /// <summary>
        /// 打印事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnPrint_Click(object sender, EventArgs e)
        {
            List<ProxyAmountInfo> lstAttendInfo = (List<ProxyAmountInfo>)DataSource;
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
            int rows = lstAttendInfo.Count * 7;
            //cells["A1"].PutValue("编号");
            //cells["B1"].PutValue("姓名");
            //cells["C1"].PutValue("部门");
            //cells["D1"].PutValue("刷卡日期");
            //cells["E1"].PutValue("星期");
            //cells["F1"].PutValue("上班");
            //cells["G1"].PutValue("下班");
            //cells["H1"].PutValue("备注");
            //6列,rows行
            cells.SetColumnWidth(0, 40);
            cells.SetColumnWidth(1, 35);

            for (int i = 0; i < rows; i++)
            {
                if (i > 0 && i % 7 == 0)
                {
                    continue;
                }

                pointX = 'A' - 1;
                for (int j = 0; j < 2; j++)
                {
                    pointY = 2 + i;
                    pointX++;
                    string strValue = string.Empty;
                    switch (pointX)
                    {
                        case 65:
                            if (i % 7 == 1)
                            {
                                cells.Merge(i, 0, 1, 2);
                                cells.SetRowHeight(i, 40);
                                Aspose.Cells.Style style = cells.Rows[i].Style;
                                StyleFlag flag = new StyleFlag();

                                style.HorizontalAlignment = TextAlignmentType.Center;
                                style.Font.IsBold = true;

                                flag.HorizontalAlignment = true;
                                flag.Font = true;

                                cells.ApplyRowStyle(i, style, flag);
                                //cells.CreateRange(i, 0, 1, 2);
                                strValue = "收款单据";
                            }
                            else if (i % 7 == 2)
                            {
                                cells.Merge(i, 0, 1, 2);
                                cells.SetRowHeight(i, 20);

                                Cell cell = cells[i, j];
                                Aspose.Cells.Style style = cell.Style;
                                style.Borders[BorderType.TopBorder].LineStyle = CellBorderType.Thin;
                                style.Borders[BorderType.TopBorder].Color = Color.Black;
                                style.Borders[BorderType.LeftBorder].LineStyle = CellBorderType.Thin;
                                style.Borders[BorderType.LeftBorder].Color = Color.Black;
                                cell.SetStyle(style);

                                strValue = "交款单位:" + lstAttendInfo[i / 7].ProxyAmountUnitName;
                            }
                            else if (i % 7 == 3)
                            {
                                cells.SetRowHeight(i, 20);
                                Cell cell = cells[i, j];
                                Aspose.Cells.Style style = cell.Style;
                                style.Borders[BorderType.LeftBorder].LineStyle = CellBorderType.Thin;
                                style.Borders[BorderType.LeftBorder].Color = Color.Black;
                                cell.SetStyle(style);
                                strValue = "金额(大写):" + lstAttendInfo[i / 7].CNMoney;
                            }
                            else if (i % 7 == 4)
                            {
                                cells.Merge(i, 0, 1, 2);
                                cells.SetRowHeight(i, 20);
                                Cell cell = cells[i, j];
                                Aspose.Cells.Style style = cell.Style;
                                style.Borders[BorderType.LeftBorder].LineStyle = CellBorderType.Thin;
                                style.Borders[BorderType.LeftBorder].Color = Color.Black;
                                cell.SetStyle(style);
                                strValue = "收款事由:" + lstAttendInfo[i / 7].Sument;

                            }
                            else if (i % 7 == 5)
                            {
                                cells.SetRowHeight(i, 20);
                                Cell cell = cells[i, j];
                                Aspose.Cells.Style style = cell.Style;
                                style.Borders[BorderType.LeftBorder].LineStyle = CellBorderType.Thin;
                                style.Borders[BorderType.LeftBorder].Color = Color.Black;
                                style.Borders[BorderType.BottomBorder].LineStyle = CellBorderType.Thin;
                                style.Borders[BorderType.BottomBorder].Color = Color.Black;
                                cell.SetStyle(style);
                                strValue = "收款方式:" + lstAttendInfo[i / 7].CollectMethod;
                            }
                            else if (i % 7 == 6)
                            {
                            }

                            break;
                        case 66:
                            if (i % 7 == 1)
                            {
                            }
                            else if (i % 7 == 2)
                            {
                                Cell cell = cells[i, j];
                                Aspose.Cells.Style style = cell.Style;
                                style.Borders[BorderType.TopBorder].LineStyle = CellBorderType.Thin;
                                style.Borders[BorderType.TopBorder].Color = Color.Black;
                                style.Borders[BorderType.RightBorder].LineStyle = CellBorderType.Thin;
                                style.Borders[BorderType.RightBorder].Color = Color.Black;
                                cell.SetStyle(style);
                            }
                            else if (i % 7 == 3)
                            {
                                Cell cell = cells[i, j];
                                Aspose.Cells.Style style = cell.Style;
                                style.Borders[BorderType.RightBorder].LineStyle = CellBorderType.Thin;
                                style.Borders[BorderType.RightBorder].Color = Color.Black;
                                cell.SetStyle(style);
                                strValue = "￥"+lstAttendInfo[i / 7].ENMoneyFlag.ToString() + lstAttendInfo[i / 7].ENMoney.ToString();
                            }
                            else if (i % 7 == 4)
                            {
                                Cell cell = cells[i, j];
                                Aspose.Cells.Style style = cell.Style;
                                style.Borders[BorderType.RightBorder].LineStyle = CellBorderType.Thin;
                                style.Borders[BorderType.RightBorder].Color = Color.Black;
                                cell.SetStyle(style);
                            }
                            else if (i % 7 == 5)
                            {
                                Cell cell = cells[i, j];
                                Aspose.Cells.Style style = cell.Style;
                                style.Borders[BorderType.BottomBorder].LineStyle = CellBorderType.Thin;
                                style.Borders[BorderType.BottomBorder].Color = Color.Black;
                                style.Borders[BorderType.RightBorder].LineStyle = CellBorderType.Thin;
                                style.Borders[BorderType.RightBorder].Color = Color.Black;
                                cell.SetStyle(style);
                                strValue = "开票日期:" + lstAttendInfo[i / 7].OpeningDate.ToString("yyyy年-MM月-dd日");
                            }
                            else if (i % 7 == 6)
                            {
                                cells.SetRowHeight(i, 20);
                                strValue = "收款单位:合肥吉信财务管理有限公司";
                            }
                            break;
                    }

                    cells[i, j].PutValue(strValue);
                    //cells[cellName].PutValue(strValue);
                }
            }
            //保存文件
            string fileName = HttpUtility.UrlEncode("收款收据.xls", System.Text.Encoding.UTF8);
            workbook.Save(fileName, FileFormatType.Excel2003, SaveType.OpenInExcel, HttpContext.Current.Response, System.Text.Encoding.UTF8);
            //关闭流
            Response.End();
        }

        #endregion
    }
}