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

            strCondition.Append(" IsDelete <> 1");
            if (!string.IsNullOrEmpty(tbxSearch.Text.Trim()))
            {
                strCondition.Append(" and ProxyAmountUnitName Like '%" + tbxSearch.Text.Trim() + "%'");
            }

            strCondition.Append(" and OpeningDate between '" + startTime.ToString("yyyy-MM-dd 00:00") + "' and '" + endTime.ToString("yyyy-MM-dd 23:59") + "'");

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
                label.Text = info.ENMoney.ToString();
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
                label3.Text = info.State == 2 ? "出纳已到收款" : "出纳未到收款";
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
                btnButton.Text = "上交代帐费";
                btnButton.Click += new EventHandler(btnButton_Click);
                if (info.State != 0)
                {
                    btnButton.Enabled = false;
                }
                row4.Items.Add(btnButton);
                form4.Rows.Add(row4);

                panel.Items.Add(form4);

                #endregion

                pelPrint.Items.Add(panel);
            }
        }

        void btnButton_Click(object sender, EventArgs e)
        {
            ExtAspNet.Button btnButton = (ExtAspNet.Button)sender;
            //Alert.Show(btnButton.ID);
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

        }

        #endregion
    }
}