using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.TZMS.Model;
using com.TZMS.Business;
using System.Text;
using ExtAspNet;
using System.Xml;

namespace TZMS.Web
{
    public partial class SetPersonOfXZ : BasePage
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

            List<UserInfo> temp1 = new List<UserInfo>();
            List<UserInfo> temp2 = new List<UserInfo>();

            string checkers = strArchiver;
            foreach (UserInfo use in lstUserInfo)
            {
                if (checkers.Contains(use.ObjectId.ToString()))
                {
                    temp2.Add(use);
                    continue;
                }
                //不能显示自己
                if (use.ObjectId.ToString() != strArchiver)
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
            if (SelectedUser.Count == 1)
            {
                Alert.Show("只能设置 1 位行政归档人！");
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
                Alert.Show("请选择要移除的行政归档人！");
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
            if (SelectedUser.Count == 0)
            {
                PageContext.RegisterStartupScript(ExtAspNet.ActiveWindow.GetHidePostBackReference());
                return;
            }
            UserInfo user = SelectedUser[0]; 
            //新数据
            string path = AppDomain.CurrentDomain.BaseDirectory;
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(path+"\\pages\\adminManage\\XZPerson.xml");
            //查找<Person></Person>  
            XmlNode root = xmlDoc.SelectSingleNode("Person"); 
            //将子节点类型转换为XmlElement类型  
            XmlElement xe = (XmlElement)root;
            xe.SetAttribute("id", user.ObjectId.ToString());  
            xe.SetAttribute("name", user.Name);
            xe.SetAttribute("deptname", user.Dept); 
            xmlDoc.Save(path + "\\pages\\adminManage\\XZPerson.xml");
            PageContext.RegisterStartupScript(ExtAspNet.ActiveWindow.GetHidePostBackReference());
            //Alert.Show("设置行政归档人成功！");
        }
    }
}