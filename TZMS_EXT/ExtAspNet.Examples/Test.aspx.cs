using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Com.iFlytek.OA.MUDCommon;

namespace TZMS.Web
{
    public partial class Test : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            MUDFilesCtrl fileCtrl = new MUDFilesCtrl();
            fileCtrl.AcceptFiles(string.Empty, "测试", "123", "属性");
            //this.BindAttachsRecordInfo(true);
            this.MUDAttachment.ShowAddBtn = "true";
            this.MUDAttachment.ShowDelBtn = "true";
            this.MUDAttachment.SystemName = "测试";
            this.MUDAttachment.RecordID = "123";
            this.MUDAttachment.AttributeName = "属性";
            //MUDFilesCtrl fileCtrl1 = new MUDFilesCtrl();
            //fileCtrl1.ResetFiles(string.Empty, "测试", "123", "属性");
        }
    }
}