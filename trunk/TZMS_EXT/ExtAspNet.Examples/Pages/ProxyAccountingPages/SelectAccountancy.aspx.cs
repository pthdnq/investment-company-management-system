using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using com.TZMS.Model;
using com.TZMS.Business;
using ExtAspNet;

namespace TZMS.Web
{
    public partial class SelectAccountancy : BasePage
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
        /// 操作类型
        /// </summary>
        public string OperatorType
        {
            get
            {
                if (ViewState["OperatorType"] == null)
                {
                    return null;
                }

                return ViewState["OperatorType"].ToString();
            }
            set
            {
                ViewState["OperatorType"] = value;
            }
        }

        /// <summary>
        /// 发送消息ID
        /// </summary>
        public string UnitID
        {
            get
            {
                if (ViewState["UnitID"] == null)
                {
                    return null;
                }

                return ViewState["UnitID"].ToString();
            }
            set
            {
                ViewState["UnitID"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string strOperatorType = Page.Request.QueryString["Type"];
                string strSentMessageID = Page.Request.QueryString["ID"];

                switch (strOperatorType)
                {
                    case "Add":
                        {
                            OperatorType = strOperatorType;
                            BindUnSelectUsers();
                        }
                        break;
                    case "View":
                        {
                            OperatorType = strOperatorType;
                            UnitID = strSentMessageID;
                            BindUnSelectUsers();
                            DisabledAllControls();
                        }
                        break;
                    case "Edit":
                        {
                            OperatorType = strOperatorType;
                            UnitID = strSentMessageID;
                            BindUnSelectUsers();
                        }
                        break;
                    default:
                        break;
                }
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
            if (OperatorType != "Add")
            {
                ProxyAccountingUnitInfo _info = new ProxyAccountingManage().GetUnitByObjectID(UnitID);
                if (_info != null)
                {
                    strAccountancyID = _info.AccountancyID.ToString();
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
                    if (arrayRoles[i] == "14")
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
                Alert.Show("请选择代理会计!");
                return;
            }

            Session["Accountancy:" + CurrentUser.ObjectId.ToString()] = lstSelected[0].UserObjectId.ToString() + "," + lstSelected[0].Name;
            Alert.Show("保存代理会计成功!");
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
                Alert.Show("请在左边选择用户！");
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
                Alert.Show("请选择要移除的代理会计！");
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
    }
}