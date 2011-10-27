using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExtAspNet;

namespace TZMS.Web
{
    public partial class LeaveAppNew : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 发送申请
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (DatePicker2.SelectedDate is DateTime)
            {
                DateTime dt = DateTime.Parse(DatePicker2.SelectedDate.ToString());
                Alert.Show(dt.ToShortDateString());
            }

        }
    }
}