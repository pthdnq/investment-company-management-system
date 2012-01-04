using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExtAspNet;
using com.TZMS.Model;
using com.TZMS.Business;

namespace TZMS.Web
{
    public partial class ChooseZJ : BasePage
    {
        /// <summary>
        /// 未选择员工
        /// </summary>
        private List<UserRoles> UnSelectUser
        {
            get
            {
                if (ViewState["UnSelectUser"] == null)
                {
                    return new List<UserRoles>();
                }

                return (List<UserRoles>)ViewState["UnSelectUser"];
            }
            set
            {
                ViewState["UnSelectUser"] = value;
            }
        }

        /// <summary>
        /// 以选择审批人
        /// </summary>
        private List<UserRoles> SelectedUser
        {
            get
            {
                if (ViewState["lstSelectedUser"] == null)
                {
                    return new List<UserRoles>();
                }

                return (List<UserRoles>)ViewState["lstSelectedUser"];
            }
            set
            {
                ViewState["lstSelectedUser"] = value;
            }
        }

        /// <summary>
        /// ID
        /// </summary>
        public string JiangChengID
        {
            get
            {
                if (ViewState["JiangChengID"] == null)
                {
                    return null;
                }

                return ViewState["JiangChengID"].ToString();
            }
            set
            {
                ViewState["JiangChengID"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                JiangChengID = Page.Request.QueryString["ID"];
                BindUnSelectUsers();
            }
        }

        /// <summary>
        /// 绑定为选择的用户
        /// </summary>
        private void BindUnSelectUsers()
        {
            //获得员工
            RolesManage _rolesManage = new RolesManage();
            List<UserRoles> lstUserRoles = _rolesManage.GerRolesByCondition("1 = 1");
            string strAccountancyID = string.Empty;

            if (!string.IsNullOrEmpty(JiangChengID))
            {
                JiangChengInfo _info = new JiangChengManage().GetJiangChengByObjectID(JiangChengID);
                if (_info != null)
                {
                    strAccountancyID = _info.ZjID.ToString();
                }
            }

            List<UserRoles> lstUnSelect = new List<UserRoles>();
            List<UserRoles> lstSelected = new List<UserRoles>();
            bool isContains = false;
            string[] arrayRoles = { };
            foreach (var user in lstUserRoles)
            {
                isContains = false;
                arrayRoles = user.Roles.Split(',');
                for (int i = 0; i < arrayRoles.Length; i++)
                {
                    if (arrayRoles[i] == "4" || arrayRoles[i] == "5" || arrayRoles[i] == "6" || arrayRoles[i] == "7")
                    {
                        isContains = true;
                        break;
                    }
                }

                if (isContains)
                {
                    if (user.UserObjectId.ToString() == strAccountancyID)
                    {
                        lstSelected.Add(user);
                    }
                    else
                    {
                        lstUnSelect.Add(user);
                    }
                }
            }

            lstSelected.Sort(delegate(UserRoles x, UserRoles y) { return string.Compare(x.JobNo, y.JobNo); });
            lstUnSelect.Sort(delegate(UserRoles x, UserRoles y) { return string.Compare(x.JobNo, y.JobNo); });

            this.gridUnSelectUser.DataSource = lstUnSelect;
            this.gridUnSelectUser.DataBind();

            this.gridSelectdUsers.DataSource = lstSelected;
            this.gridSelectdUsers.DataBind();

            UnSelectUser = lstUnSelect;
            SelectedUser = lstSelected;
        }

        /// <summary>
        /// 禁用所有控件
        /// </summary>
        private void DisabledAllControls()
        {
            btnSave.Enabled = false;
            btnSelect.Enabled = false;
            btnUnselect.Enabled = false;
        }

        /// <summary>
        /// 保存事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            List<UserRoles> lstSelected = SelectedUser;

            if (lstSelected.Count == 0)
            {
                Alert.Show("请选择部门领导!");
                return;
            }

            PageContext.RegisterStartupScript(ExtAspNet.ActiveWindow.GetHidePostBackReference(lstSelected[0].UserObjectId.ToString() + "," + lstSelected[0].Name));
        }

        /// <summary>
        /// 选中事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSelect_Click(object sender, EventArgs e)
        {
            // 获取选中一行.
            if (gridUnSelectUser.SelectedRowIndexArray.Length == 0)
            {
                Alert.Show("请在左边选择部门领导！");
                return;
            }

            int index = gridUnSelectUser.SelectedRowIndexArray[0];

            List<UserRoles> lstSelected = SelectedUser;
            List<UserRoles> lstUnSelect = UnSelectUser;

            UserRoles user = UnSelectUser[index];
            lstUnSelect.RemoveAt(index);
            if (lstSelected.Count > 0)
            {
                lstUnSelect.Add(lstSelected[0]);
                lstSelected.Clear();
            }
            lstSelected.Add(user);


            lstSelected.Sort(delegate(UserRoles x, UserRoles y) { return string.Compare(x.JobNo, y.JobNo); });
            lstUnSelect.Sort(delegate(UserRoles x, UserRoles y) { return string.Compare(x.JobNo, y.JobNo); });

            this.gridUnSelectUser.DataSource = lstUnSelect;
            this.gridUnSelectUser.DataBind();

            this.gridSelectdUsers.DataSource = lstSelected;
            this.gridSelectdUsers.DataBind();

            SelectedUser = lstSelected;
            UnSelectUser = lstUnSelect;
        }

        /// <summary>
        /// 取消事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnUnselect_Click(object sender, EventArgs e)
        {
            // 获取选中一行.
            if (gridSelectdUsers.SelectedRowIndexArray.Length == 0)
            {
                Alert.Show("请选择要移除的部门领导！");
                return;
            }
            int index = gridSelectdUsers.SelectedRowIndexArray[0];

            List<UserRoles> lstSelected = SelectedUser;
            List<UserRoles> lstUnSelect = UnSelectUser;

            UserRoles user = SelectedUser[index];
            lstUnSelect.Add(user);
            lstSelected.RemoveAt(index);

            lstSelected.Sort(delegate(UserRoles x, UserRoles y) { return string.Compare(x.JobNo, y.JobNo); });
            lstUnSelect.Sort(delegate(UserRoles x, UserRoles y) { return string.Compare(x.JobNo, y.JobNo); });

            this.gridUnSelectUser.DataSource = UnSelectUser;
            this.gridUnSelectUser.DataBind();

            this.gridSelectdUsers.DataSource = SelectedUser;
            this.gridSelectdUsers.DataBind();

            SelectedUser = lstSelected;
            UnSelectUser = lstUnSelect;
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

        /// <summary>
        /// 未选中列表数据行绑定事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridUnSelectUser_RowDataBound(object sender, GridRowEventArgs e)
        {
            if (e.DataItem != null)
            {
                UserInfo _info = new UserManage().GetUserByObjectID(e.Values[0].ToString());
                if (_info != null)
                {
                    e.Values[3] = _info.Dept;
                }
            }
        }

        /// <summary>
        /// 已选中列表数据行绑定事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridSelectdUsers_RowDataBound(object sender, GridRowEventArgs e)
        {
            if (e.DataItem != null)
            {
                UserInfo _info = new UserManage().GetUserByObjectID(e.Values[0].ToString());
                if (_info != null)
                {
                    e.Values[3] = _info.Dept;
                }
            }
        }
    }
}