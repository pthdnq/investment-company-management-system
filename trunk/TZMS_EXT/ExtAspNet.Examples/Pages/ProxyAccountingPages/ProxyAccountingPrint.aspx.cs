using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExtAspNet;
using System.Text;
using com.TZMS.Model;
using com.TZMS.Business;

namespace TZMS.Web
{
    public partial class ProxyAccountingPrint : BasePage
    {
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

        #endregion
    }
}