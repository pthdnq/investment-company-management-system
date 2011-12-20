using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExtAspNet;
using com.TZMS.Business;
using com.TZMS.Model;

namespace TZMS.Web
{
    public partial class ChuRuApply : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblName.Text = CurrentUser.Name;
                lblTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            }
        }

        #region 页面事件

        /// <summary>
        /// 登记时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ChuRuManage _manage = new ChuRuManage();
            ChuRuInfo _info = new ChuRuInfo();
            _info.ObjectID = Guid.NewGuid();
            _info.UserID = CurrentUser.ObjectId;
            _info.UserName = CurrentUser.Name;
            _info.UserJobNo = CurrentUser.JobNo;
            _info.UserDept = CurrentUser.Dept;
            _info.OutTime = DateTime.Now;
            _info.OutReason = taaReason.Text.Trim();
            _info.State = 0;

            int result = _manage.AddNewChuRu(_info);
            if (result == -1)
            {
                this.btnClose_Click(null, null);
            }
            else
            {
                Alert.Show("出门登记失败!");
            }
        }

        /// <summary>
        /// 关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnClose_Click(object sender, EventArgs e)
        {
            PageContext.RegisterStartupScript(ExtAspNet.ActiveWindow.GetHidePostBackReference());
        }

        #endregion
    }
}