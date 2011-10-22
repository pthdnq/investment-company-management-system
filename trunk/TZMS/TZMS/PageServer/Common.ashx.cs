using System;
using System.Collections.Generic;
using System.Web;
using System.Text;

namespace TZMS.PageServer
{
    /// <summary>
    /// Common 的摘要说明
    /// </summary>
    public class Common : IHttpHandler
    {

        /// <summary>
        /// 公共服务出来程序
        /// </summary>
        /// <param name="context"></param>
        public void ProcessRequest(HttpContext context)
        {
            if (context.Request.QueryString["op"] != null)
            {
                string strOP = context.Request.QueryString["op"].Trim();
                //获得所有部门
                if (strOP.ToLower() == "getdept")
                {
                    context.Response.Write(LoadDepts());
                    context.Response.End();
                }
            }
           
        }

        /// <summary>
        /// 加载部门
        /// </summary>
        /// <returns>部门json</returns>
        public string LoadDepts()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("[{value:0,text:'全部',selected:'True'},{value:1,text:'");
            stringBuilder.Append(TZMS.Common.DEPT.XINGZHENG);
            stringBuilder.Append("'},{value:2,text:'");
            stringBuilder.Append(TZMS.Common.DEPT.CAIWU);
            stringBuilder.Append("'},{value:3,text:'");
            stringBuilder.Append(TZMS.Common.DEPT.TOUZI);
            stringBuilder.Append("'},{value:4,text:'");
            stringBuilder.Append(TZMS.Common.DEPT.YEWU);
            stringBuilder.Append("'}]");
            return stringBuilder.ToString();
        }

        /// <summary>
        /// 是否允许
        /// </summary>
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}