using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.TZMS.Model;
using com.TZMS.Business;
using System.Text;
using ExtAspNet.Examples;

namespace TZMS.Web
{
    public partial class WorkerManage : BasePage
    {

        /// <summary>
        /// 页面加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataBindUsers();
            }
        }

        /// <summary>
        /// 绑定列表
        /// </summary>
        private void DataBindUsers()
        {
            //获得员工
            List<UserInfo> lstUserInfo = new UserManage().GetUsersByCondtion(" 1= 1 ");
            this.gridUser.RecordCount = lstUserInfo.Count;
            this.gridUser.PageSize = PageCounts;      
            int currentIndex = this.gridUser.PageIndex;
            //计算当前页面显示行数据
            if (lstUserInfo.Count > this.gridUser.PageSize)
            {
                if(lstUserInfo.Count>(currentIndex+1)*this.gridUser.PageSize)
                {
                    lstUserInfo.RemoveRange((currentIndex+1) * this.gridUser.PageSize , lstUserInfo.Count - (currentIndex+1) * this.gridUser.PageSize );
                }
                lstUserInfo.RemoveRange(0, currentIndex * this.gridUser.PageSize );
            }
            this.gridUser.DataSource = lstUserInfo;
            this.gridUser.DataBind();
        }

        /// <summary>
        /// 翻页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridUser_PageIndexChange(object sender, ExtAspNet.GridPageEventArgs e)
        {
            this.gridUser.PageIndex = e.NewPageIndex;
            DataBindUsers();
        }
    }
}