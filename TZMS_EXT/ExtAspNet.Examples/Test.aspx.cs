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
            fileCtrl.AcceptFiles(string.Empty, "", "", "");
            //this.BindAttachsRecordInfo(true);
        }
    }
}