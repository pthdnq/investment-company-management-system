using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.TZMS.Model;
using com.TZMS.Business;
using System.Text;
using ExtAspNet;

namespace TZMS.Web.Pages
{
    public partial class SelectReceivers : BasePage
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
        public string SentMessageID
        {
            get
            {
                if (ViewState["SentMessageID"] == null)
                {
                    return null;
                }

                return ViewState["SentMessageID"].ToString();
            }
            set
            {
                ViewState["SentMessageID"] = value;
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
                            SentMessageID = strSentMessageID;
                            BindUnSelectUsers();
                            DisabledAllControls();
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
            List<UserInfo> lstUserInfo = new UserManage().GetAllWorkUsers();

            List<UserInfo> lstUnSelect = new List<UserInfo>();
            List<UserInfo> lstSelected = new List<UserInfo>();
            string[] arrayRecevicers = { };
            if (OperatorType == "View")
            {
                SentMessageInfo _info = new MessageManage().GetSentMessageByObjectID(SentMessageID);
                if (_info != null)
                {
                    arrayRecevicers = _info.Recevicer.Split('|');
                }
            }

            if (OperatorType == "Add")
            {
                if (Session[CurrentUser.ObjectId.ToString()] != null)
                {
                    arrayRecevicers = Session[CurrentUser.ObjectId.ToString()].ToString().Split('|');
                }
            }

            bool bContain;
            foreach (UserInfo use in lstUserInfo)
            {
                bContain = false;
                //不能显示自己
                if (use.ObjectId != CurrentUser.ObjectId)
                {
                    foreach (string strObjectID in arrayRecevicers)
                    {
                        if (strObjectID.Split(',')[0] == use.ObjectId.ToString())
                        {
                            bContain = true;
                            break;
                        }
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
            }

            lstSelected.Sort(delegate(UserInfo x, UserInfo y) { return string.Compare(x.JobNo, y.JobNo); });
            lstUnSelect.Sort(delegate(UserInfo x, UserInfo y) { return string.Compare(x.JobNo, y.JobNo); });

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
            List<UserInfo> lstSelected = SelectedUser;

            if (lstSelected.Count == 0)
            {
                Alert.Show("请选择收信人!");
                return;
            }

            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < lstSelected.Count; i++)
            {
                if (i != 0)
                {
                    stringBuilder.Append("|" + lstSelected[i].ObjectId.ToString() + "," + lstSelected[i].Name);
                }
                else
                {
                    stringBuilder.Append(lstSelected[i].ObjectId.ToString() + "," + lstSelected[i].Name);
                }
            }

            Session[CurrentUser.ObjectId.ToString()] = stringBuilder.ToString();
            Alert.Show("设置收信人成功!");
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

            List<UserInfo> lstSelected = SelectedUser;
            List<UserInfo> lstUnSelect = UnSelectUser;

            for (int i = 0; i < gridUnSelectUser.SelectedRowIndexArray.Length; i++)
            {
                int index = gridUnSelectUser.SelectedRowIndexArray[i];

                UserInfo user = UnSelectUser[index];
                lstSelected.Add(user);
            }

            for (int i = gridUnSelectUser.SelectedRowIndexArray.Length -1; i >= 0; --i)
            {
                int index = gridUnSelectUser.SelectedRowIndexArray[i];
                lstUnSelect.RemoveAt(index);
            }

            lstSelected.Sort(delegate(UserInfo x, UserInfo y) { return string.Compare(x.JobNo, y.JobNo); });
            lstUnSelect.Sort(delegate(UserInfo x, UserInfo y) { return string.Compare(x.JobNo, y.JobNo); });

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
                Alert.Show("请选择要移除的收信人！");
                return;
            }

            List<UserInfo> lstSelected = SelectedUser;
            List<UserInfo> lstUnSelect = UnSelectUser;

            for (int i = 0; i < gridSelectdUsers.SelectedRowIndexArray.Length; i++)
            {
                int index = gridSelectdUsers.SelectedRowIndexArray[i];
                UserInfo user = SelectedUser[index];
                lstUnSelect.Add(user);
            }

            for (int i = gridSelectdUsers.SelectedRowIndexArray.Length - 1; i >= 0; --i)
            {
                int index = gridSelectdUsers.SelectedRowIndexArray[i];
                lstSelected.RemoveAt(index);
            }

            lstSelected.Sort(delegate(UserInfo x, UserInfo y) { return string.Compare(x.JobNo, y.JobNo); });
            lstUnSelect.Sort(delegate(UserInfo x, UserInfo y) { return string.Compare(x.JobNo, y.JobNo); });

            this.gridUnSelectUser.DataSource = UnSelectUser;
            this.gridUnSelectUser.DataBind();

            this.gridSelectdUsers.DataSource = SelectedUser;
            this.gridSelectdUsers.DataBind();

            SelectedUser = lstSelected;
            UnSelectUser = lstUnSelect;
        }

        /// <summary>
        /// 关闭窗口事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnClose_Click(object sender, EventArgs e)
        {
            PageContext.RegisterStartupScript(ExtAspNet.ActiveWindow.GetHidePostBackReference());
        }
    }
}