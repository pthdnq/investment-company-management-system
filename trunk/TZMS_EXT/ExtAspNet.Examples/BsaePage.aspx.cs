using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExtAspNet;
using System.Text;
using ExtAspNet.Examples;
using System.Data;
using System.Web.Configuration;

namespace TZMS.Web
{
    public partial class BasePage : System.Web.UI.Page
    {

        #region 配置信息

        /// <summary>
        /// TZMS数据库链接字符串
        /// </summary>
        public string BoName
        {
            get { return "CONNECTIONSTRINGFORPROVINCE"; }
        }

        /// <summary>
        /// 一般页面页大小
        /// </summary>
        protected int PageCounts
        {
            get { return int.Parse(WebConfigurationManager.AppSettings["PAGECOUNTS"].ToString()); }
        }

        /// <summary>
        /// 系统名称
        /// </summary>
        protected string SystemName
        {
            get { return WebConfigurationManager.AppSettings["SYSTEMNAME"].ToString(); }
        }
        #endregion

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            if (!IsPostBack)
            {
                if (PageManager.Instance != null)
                {
                    HttpCookie themeCookie = Request.Cookies["Theme"];
                    if (themeCookie != null)
                    {
                        string themeValue = themeCookie.Value;
                        PageManager.Instance.Theme = (Theme)Enum.Parse(typeof(Theme), themeValue, true);
                    }

                    HttpCookie langCookie = Request.Cookies["Language"];
                    if (langCookie != null)
                    {
                        string langValue = langCookie.Value;
                        PageManager.Instance.Language = (Language)Enum.Parse(typeof(Language), langValue, true);
                    }


                }
            }

        }

        #region Grid related section

        protected string HowManyRowsAreSelected(Grid grid)
        {
            StringBuilder sb = new StringBuilder();
            int selectedCount = grid.SelectedRowIndexArray.Length;
            if (selectedCount > 0)
            {
                sb.AppendFormat("Selected rows ({0}): ", selectedCount);
                sb.Append("<table class=\"result\"><tbody>");

                // Table header
                sb.Append("<tr><th>index</th>");
                foreach (string datakey in grid.DataKeyNames)
                {
                    sb.AppendFormat("<th>{0}</th>", datakey);
                }
                sb.Append("</tr>");

                for (int i = 0; i < selectedCount; i++)
                {
                    int rowIndex = grid.SelectedRowIndexArray[i];
                    sb.AppendFormat("<tr><td>{0}</td>", rowIndex);

                    // If allow paging, not database paging.
                    if (grid.AllowPaging && !grid.IsDatabasePaging)
                    {
                        rowIndex = grid.PageIndex * grid.PageSize + rowIndex;
                    }

                    foreach (object key in grid.DataKeys[rowIndex])
                    {
                        sb.AppendFormat("<td>{0}</td>", key);
                    }
                    sb.Append("</tr>");
                }
                sb.Append("</tbody></table>");
            }
            else
            {
                sb.Append("No row was selected.");
            }

            return sb.ToString();
        }

        protected DataTable GetDataTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add(new DataColumn("Id", typeof(int)));
            table.Columns.Add(new DataColumn("MyText", typeof(String)));
            table.Columns.Add(new DataColumn("MyValue", typeof(String)));
            table.Columns.Add(new DataColumn("Year", typeof(String)));
            table.Columns.Add(new DataColumn("MyCheckBox", typeof(bool)));

            DataRow row = table.NewRow();
            row[0] = 101;
            row[1] = "Nancy";
            row[2] = "1";
            row[3] = "2008";
            row[4] = true;
            table.Rows.Add(row);

            row = table.NewRow();
            row[0] = 102;
            row[1] = "Andrew";
            row[2] = "2";
            row[3] = "2007";
            row[4] = true;
            table.Rows.Add(row);

            row = table.NewRow();
            row[0] = 103;
            row[1] = "Janet";
            row[2] = "3";
            row[3] = "2006";
            row[4] = false;
            table.Rows.Add(row);

            row = table.NewRow();
            row[0] = 104;
            row[1] = "Margaret";
            row[2] = "4";
            row[3] = "2005";
            row[4] = false;
            table.Rows.Add(row);

            row = table.NewRow();
            row[0] = 105;
            row[1] = "Steven";
            row[2] = "5";
            row[3] = "2004";
            row[4] = true;
            table.Rows.Add(row);

            return table;
        }

        protected DataTable GetEmptyDataTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add(new DataColumn("Id", typeof(int)));
            table.Columns.Add(new DataColumn("MyText", typeof(String)));
            table.Columns.Add(new DataColumn("MyValue", typeof(String)));
            table.Columns.Add(new DataColumn("Year", typeof(String)));
            table.Columns.Add(new DataColumn("MyCheckBox", typeof(bool)));


            return table;
        }

        #endregion
    }
}