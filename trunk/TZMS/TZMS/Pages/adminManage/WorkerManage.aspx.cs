using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.TZMS.Model;
using com.TZMS.Business;
using System.Text;

namespace TZMS.Pages.adminManage
{
    public partial class WorkerManage : BaseWebPage
    {

        /// <summary>
        /// 页面加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            string strOP = Page.Request.QueryString["op"];
            switch (strOP)
            {
                case "getUser":
                    {
                        string strDept = Page.Request.QueryString["dept"];
                        string strState = Page.Request.QueryString["state"];
                        string strSearchText = Page.Request.QueryString["txt"];
                        LoadUsers(strDept, strState, strSearchText);
                    }
                    break;
                case "userLeave":
                    {
                        string strUserID = Page.Request.QueryString["ID"];
                        UserLeave(strUserID);
                    }
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 加载用户
        /// </summary>
        /// <param name="strDept">部门</param>
        /// <param name="strState">在职状态</param>
        /// <param name="strSearchText">查询文本</param>
        public void LoadUsers(string strDept, string strState, string strSearchText)
        {
            #region 条件

            StringBuilder strCondtion = new StringBuilder();
            if (!string.IsNullOrEmpty(strDept) && strDept != "全部")
            {
                strCondtion.Append(" dept='" + strDept + "' and ");
            }
            if (!string.IsNullOrEmpty(strState))
            {
                strCondtion.Append(" state=" + (strState == "在职" ? 1 : 0) + " and ");
            }
            if (!string.IsNullOrEmpty(strSearchText))
            {
                strCondtion.Append(" (name like '%" + strSearchText + "%' or AccountNo like '%" + strSearchText + "%') and ");
            }
            //未删除
            strCondtion.Append(" state<>2 ");

            #endregion

            //获得员工
            List<UserInfo> lstUserInfo = new UserManage().GetUsersByCondtion(strCondtion.ToString());

            //[{JobNo:'2001',Name:'测试1',AccountNo:'test1',Sex:'男',Dept:'行政部',PhoneNumber:'',State:'在职', ID:'d0cc3885-64b4-4099-aed1-045658cc910a'}]

            if (lstUserInfo.Count == 0)
            {
                Response.Write("{total:0,rows: undefined}");
                //Response.Write("{total:undefined,rows:undefined}");
                Response.End();
            }
            else
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append("{total:" + lstUserInfo.Count + ",rows: [");
                int index = 0;

                string simpleInfo = string.Empty;
                foreach (UserInfo info in lstUserInfo)
                {
                    index++;
                    // 关于隐藏列，源码中将数据解析成Table，
                    // 故无需修改前台页面，在后台输出中添加1列即可达到隐藏列的效果.
                    simpleInfo = String.Format("JobNo:'{0}',Name:'{1}',AccountNo:'{2}',Sex:'{3}',Dept:'{4}',PhoneNumber:'{5}',State:'{6}', ID:'{7}'",
                        info.JobNo,
                        info.Name,
                        info.AccountNo,
                        (info.Sex == true ? "男" : "女"),
                        info.Dept,
                        info.PhoneNumber,
                        (info.State == 1 ? "在职" : "离职"),
                        info.ObjectId.ToString());
                    if (index == lstUserInfo.Count)
                    {
                        stringBuilder.Append("{" + simpleInfo + "}");
                        break;
                    }
                    stringBuilder.Append("{" + simpleInfo + "},");
                }

                stringBuilder.Append("]}");

                Response.Write(stringBuilder.ToString());
                Response.Write("");
                Response.End();
            }
        }

        /// <summary>
        /// 员工离职事件.
        /// </summary>
        /// <param name="strUserID">员工</param>
        public void UserLeave(string strUserID)
        {
            if (string.IsNullOrEmpty(strUserID))
            {
                Response.End();
            }

            UserManage userManage = new UserManage();

            // 获取离职的员工实例.
            UserInfo leaveUser = userManage.GetUserByObjectID(strUserID);
            leaveUser.State = 0;
            Response.Write((userManage.UpdateUser(leaveUser)).ToString());
            Response.End();
        }
    }
}