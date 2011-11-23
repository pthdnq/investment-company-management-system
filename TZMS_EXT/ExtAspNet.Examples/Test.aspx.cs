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
            //MUDFilesCtrl fileCtrl = new MUDFilesCtrl();
            //fileCtrl.AcceptFiles(string.Empty, "测试", "123", "12345");
            //this.BindAttachsRecordInfo(true);
            //隐藏按钮
            //this.MUDAttachment.ShowAddBtn = "true";
            //this.MUDAttachment.ShowDelBtn = "true";
            //系统名称和属性
            //this.MUDAttachment.SystemName = "测试";
            //this.MUDAttachment.AttributeName = "属性";
            ////这个表单的唯一ID 即可（支持多附件）
            //this.MUDAttachment.RecordID = "12345";
       
            //MUDFilesCtrl fileCtrl1 = new MUDFilesCtrl();
            //fileCtrl1.ResetFiles(string.Empty, "测试", "123", "属性");
        }
    }
}