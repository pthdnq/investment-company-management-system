using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Com.iFlytek.OA.MUDCommon;

namespace TZMS.Web
{
    public partial class NoAttend : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.MUDAttachment1.SystemName = "测试";
            this.MUDAttachment1.AttributeName = "属性";
            //这个表单的唯一ID 即可（支持多附件）
            this.MUDAttachment1.RecordID = "12345";
        }
    }
}