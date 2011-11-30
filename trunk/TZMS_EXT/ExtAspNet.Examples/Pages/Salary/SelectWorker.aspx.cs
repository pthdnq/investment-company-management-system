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
    public partial class SelectWorker : BasePage
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
        ///  薪资信息ID
        /// </summary>
        public string ApplyID
        {
            get
            {
                if (ViewState["ApplyID"] == null)
                {
                    return null;
                }

                return ViewState["ApplyID"].ToString();
            }
            set
            {
                ViewState["ApplyID"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ApplyID = Request.QueryString["ID"];
                if (!string.IsNullOrEmpty(ApplyID))
                {
                    BindUnSelectUsers();
                }
            }
        }

        /// <summary>
        /// 绑定为选择的用户
        /// </summary>
        private void BindUnSelectUsers()
        {
            //获得员工
            UserManage _userManage = new UserManage();
            SalaryManage _salaryManage = new SalaryManage();
            List<UserInfo> lstTempUserInfo = _userManage.GetUsersByCondtion(" state <> 2");
            List<WorkerSalaryMsgInfo> lstWorkerSalaryMsgInfo = _salaryManage.GetWorkerSalaryMsgByCondition(" SalaryMsgID = '" + ApplyID + "'");

            List<UserInfo> lstUserInfo = new List<UserInfo>();
            List<UserInfo> lstUnSelect = new List<UserInfo>();
            List<UserInfo> lstSelected = new List<UserInfo>();

            string strChooseUser = string.Empty;
            if (Session["ChooseWorkerSalaryMsg" + CurrentUser.ObjectId.ToString()] != null)
            {
                strChooseUser = Session["ChooseWorkerSalaryMsg" + CurrentUser.ObjectId.ToString()].ToString();
            }

            bool bContain = false;

            // 筛选出未在员工薪资信息中的用户.
            foreach (UserInfo user in lstTempUserInfo)
            {
                bContain = false;
                foreach (WorkerSalaryMsgInfo info in lstWorkerSalaryMsgInfo)
                {
                    if (user.ObjectId == info.UserId)
                    {
                        bContain = true;
                        break;
                    }

                }

                if (!bContain)
                {
                    lstUserInfo.Add(user);
                }
            }

            // 分别筛选出已选择用户和未选择用户.
            foreach (UserInfo user in lstUserInfo)
            {
                bContain = false;

                if (user.ObjectId.ToString() == strChooseUser.Split(',')[0])
                {
                    bContain = true;
                }

                if (bContain)
                {
                    lstSelected.Add(user);
                }
                else
                {
                    lstUnSelect.Add(user);
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
                Alert.Show("请选择员工!");
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

            Session["ChooseWorkerSalaryMsg" + CurrentUser.ObjectId.ToString()] = stringBuilder.ToString();
            this.btnClose_Click(null, null);
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
                Alert.Show("请在左边选择员工！");
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
                Alert.Show("请选择要移除的员工！");
                return;
            }

            int index = gridSelectdUsers.SelectedRowIndexArray[0];

            List<UserInfo> lstSelected = SelectedUser;
            List<UserInfo> lstUnSelect = UnSelectUser;

            UserInfo user = SelectedUser[index];
            lstUnSelect.Add(user);
            lstSelected.RemoveAt(index);

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