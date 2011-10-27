using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.TZMS.Model;
using com.TZMS.Business;
using ExtAspNet;
using System.Text;

namespace TZMS.Web
{
    public partial class SetMyChecker : BasePage
    {
        /// <summary>
        /// 未选择员工
        /// </summary>
        private List<UserInfo> UnSelectUser
        {
            get
            {
                if (ViewState["UnSelectUser"] == null)
                {
                    return new List<UserInfo>();
                }

                return (List<UserInfo>)ViewState["UnSelectUser"];
            }
            set
            {
                ViewState["UnSelectUser"] = value;
            }
        }

        /// <summary>
        /// 以选择审批人
        /// </summary>
        private List<UserInfo> SelectedUser
        {
            get
            {
                if (ViewState["SelectedUser"] == null)
                {
                    return new List<UserInfo>();
                }

                return (List<UserInfo>)ViewState["SelectedUser"];
            }
            set
            {
                ViewState["SelectedUser"] = value;
            }
        }

        /// <summary>
        /// 页面加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindUnSelectUsers();
            }
        }

        /// <summary>
        /// 绑定为选择的用户
        /// </summary>
        private void BindUnSelectUsers()
        {
            //获得员工
            List<UserInfo> lstUserInfo = new UserManage().GetAllWorkUsers();
            CheckMange cm = new CheckMange();
            List<ComCheckerInfo> checkUsers = cm.GetComCheckersByUserID(CurrentUser.ObjectId.ToString());

            List<UserInfo> temp1 = new List<UserInfo>();
            List<UserInfo> temp2 = new List<UserInfo>();

            StringBuilder sb = new StringBuilder();
            foreach (ComCheckerInfo cci in checkUsers)
            {
                sb.Append(cci.CheckerObjectId + ",");
            }
            string checkers = sb.ToString();
            foreach (UserInfo use in lstUserInfo)
            {
                if (checkers.Contains(use.ObjectId.ToString()))
                {
                    temp2.Add(use);
                    continue;
                }
                //不能显示自己
                if (use.ObjectId != CurrentUser.ObjectId)
                {
                    temp1.Add(use);
                }
            }

            UnSelectUser = temp1;
            SelectedUser = temp2;
            this.gridUnSelectUser.DataSource = temp1;
            this.gridUnSelectUser.DataBind();

            this.gridSelectdUsers.DataSource = temp2;
            this.gridSelectdUsers.DataBind();
        }

        /// <summary>
        /// 选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSelect_Click(object sender, EventArgs e)
        {
            // 获取选中一行.
            if (gridUnSelectUser.SelectedRowIndexArray.Length == 0)
            {
                Alert.Show("请在左边选择用户！");
                return;
            }

            int index = gridUnSelectUser.SelectedRowIndexArray[0];

            UserInfo user = UnSelectUser[index];

            List<UserInfo> users = SelectedUser;
            users.Add(user);

            SelectedUser = users;

            UnSelectUser.RemoveAt(index);

            this.gridUnSelectUser.DataSource = UnSelectUser;
            this.gridUnSelectUser.DataBind();

            this.gridSelectdUsers.DataSource = users;
            this.gridSelectdUsers.DataBind();
        }

        /// <summary>
        /// 移除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnUnselect_Click(object sender, EventArgs e)
        {
            // 获取选中一行.
            if (gridSelectdUsers.SelectedRowIndexArray.Length == 0)
            {
                Alert.Show("请选择要移除的审批人！");
                return;
            }
            int index = gridSelectdUsers.SelectedRowIndexArray[0];

            UserInfo user = SelectedUser[index];

            List<UserInfo> users = UnSelectUser;
            users.Add(user);

            UnSelectUser = users;

            SelectedUser.RemoveAt(index);

            this.gridUnSelectUser.DataSource = UnSelectUser;
            this.gridUnSelectUser.DataBind();

            this.gridSelectdUsers.DataSource = SelectedUser;
            this.gridSelectdUsers.DataBind();

        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            //新数据
            CheckMange cm = new CheckMange();
            cm.Add(CurrentUser, SelectedUser);
            Alert.Show("设置审批人成功！");
        }
    }
}