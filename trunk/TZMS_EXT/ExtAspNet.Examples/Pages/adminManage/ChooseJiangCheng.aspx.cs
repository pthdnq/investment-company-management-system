using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.TZMS.Model;
using ExtAspNet;
using com.TZMS.Business;

namespace TZMS.Web
{
    public partial class ChooseJiangCheng : BasePage
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
                if (ViewState["lstSelectedUser"] == null)
                {
                    return new List<UserInfo>();
                }

                return (List<UserInfo>)ViewState["lstSelectedUser"];
            }
            set
            {
                ViewState["lstSelectedUser"] = value;
            }
        }

        /// <summary>
        /// ID
        /// </summary>
        private string JiangChengID
        {
            get
            {
                if (ViewState["JiangChengID"] == null)
                {
                    return string.Empty;
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
                JiangChengID = Request.QueryString["ID"];
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

            List<UserInfo> lstUnSelect = new List<UserInfo>();
            List<UserInfo> lstSelected = new List<UserInfo>();
            string strJC = string.Empty;

            if (!string.IsNullOrEmpty(JiangChengID))
            {
                JiangChengInfo _info = new JiangChengManage().GetJiangChengByObjectID(JiangChengID);
                if (_info != null)
                {
                    strJC = _info.UserID.ToString();
                }
            }

            bool bContain;
            foreach (UserInfo use in lstUserInfo)
            {
                bContain = false;
                if (strJC == use.ObjectId.ToString())
                {
                    bContain = true;
                    break;
                }

                if (bContain)
                {
                    lstSelected.Add(use);
                }
                else
                {
                    lstUnSelect.Add(use);
                }
            }

            lstSelected.Sort(delegate(UserInfo x, UserInfo y) { return string.Compare(x.Dept, y.Dept); });
            lstUnSelect.Sort(delegate(UserInfo x, UserInfo y) { return string.Compare(x.Dept, y.Dept); });

            this.gridUnSelectUser.DataSource = lstUnSelect;
            this.gridUnSelectUser.DataBind();

            this.gridSelectdUsers.DataSource = lstSelected;
            this.gridSelectdUsers.DataBind();

            UnSelectUser = lstUnSelect;
            SelectedUser = lstSelected;
        }

        /// <summary>
        /// 保存事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            List<UserInfo> lstSelected = SelectedUser;

            if (lstSelected.Count == 0)
            {
                Alert.Show("请选择奖惩人!");
                return;
            }
            PageContext.RegisterStartupScript(ExtAspNet.ActiveWindow.GetHidePostBackReference(lstSelected[0].ObjectId.ToString() + "," + lstSelected[0].Name));
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
                Alert.Show("请在左边选择奖惩人！");
                return;
            }

            int index = gridUnSelectUser.SelectedRowIndexArray[0];

            List<UserInfo> lstSelected = SelectedUser;
            List<UserInfo> lstUnSelect = UnSelectUser;

            UserInfo user = UnSelectUser[index];
            lstUnSelect.RemoveAt(index);
            if (lstSelected.Count > 0)
            {
                lstUnSelect.Add(lstSelected[0]);
                lstSelected.Clear();
            }
            lstSelected.Add(user);


            lstSelected.Sort(delegate(UserInfo x, UserInfo y) { return string.Compare(x.Dept, y.Dept); });
            lstUnSelect.Sort(delegate(UserInfo x, UserInfo y) { return string.Compare(x.Dept, y.Dept); });

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
                Alert.Show("请选择要移除的奖惩人！");
                return;
            }
            int index = gridSelectdUsers.SelectedRowIndexArray[0];

            List<UserInfo> lstSelected = SelectedUser;
            List<UserInfo> lstUnSelect = UnSelectUser;

            UserInfo user = SelectedUser[index];
            lstUnSelect.Add(user);
            lstSelected.RemoveAt(index);

            lstSelected.Sort(delegate(UserInfo x, UserInfo y) { return string.Compare(x.Dept, y.Dept); });
            lstUnSelect.Sort(delegate(UserInfo x, UserInfo y) { return string.Compare(x.Dept, y.Dept); });

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
    }
}