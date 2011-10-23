using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using Nii.JSON;

namespace ExtAspNet.Examples
{
    public partial class ajax : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            string content = ReadFile("~/config/ajax_properties.txt");
            Dictionary<string, JSONObject> allControls = new Dictionary<string, JSONObject>();
            List<string> publicControls = new List<string>();
            JSONArray ja = new JSONArray(content);
            foreach (JSONObject jo in ja.getArrayList())
            {
                if (jo.getBool("public"))
                {
                    publicControls.Add(jo.getString("name"));
                }
                allControls.Add(jo.getString("name"), jo);
            }
            publicControls.Sort();

            StringBuilder sb = new StringBuilder();
            sb.Append("<table border=\"0\">");
            sb.Append("<tr>");
            for (int i = 0, count = publicControls.Count; i < count; i++)
            {
                string name = publicControls[i];

                sb.Append("<td>");
                sb.AppendFormat("<div class=\"head\">{0}</div>", name);

                // 计算控件name的所有AJAX属性
                List<string> ajaxProperties = new List<string>();

                string parentControlName = name;
                do
                {
                    JSONObject control = allControls[parentControlName];
                    foreach (string property in control.getJSONArray("ajax").getArrayList())
                    {
                        if (!ajaxProperties.Contains(property))
                        {
                            ajaxProperties.Add(property);
                        }
                    }
                    parentControlName = control.getString("parent");

                } while (!String.IsNullOrEmpty(parentControlName));

                ajaxProperties.Sort();


                sb.Append("<ul class=\"ajax\">");
                foreach (string property in ajaxProperties)
                {
                    sb.AppendFormat("<li>{0}</li>", property);
                }
                sb.Append("</ul>");

                sb.Append("</td>");

                if ((i + 1) % 6 == 0)
                {
                    sb.Append("</tr><tr>");
                }
            }
            sb.Append("</tr>");
            sb.Append("</table>");

            litResult.Text = sb.ToString();
        }

        private string ReadFile(string filePath)
        {
            string content = String.Empty;

            using (System.IO.StreamReader sr = new System.IO.StreamReader(Server.MapPath(filePath)))
            {
                content = sr.ReadToEnd();
            }

            return content;
        }
    }
}
