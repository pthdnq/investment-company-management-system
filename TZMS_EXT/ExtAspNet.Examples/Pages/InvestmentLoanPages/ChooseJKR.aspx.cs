using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.TZMS.Business;
using com.TZMS.Model;
using ExtAspNet;

namespace TZMS.Web.Pages.InvestmentLoanPages
{
    /// <summary>
    /// Choose借款人
    /// </summary>
    public partial class ChooseJKR : BasePage
    {
        #region 属性
        /// <summary>
        /// 未选择员工
        /// </summary>
        private List<CustomerInfo> UnSelectUser
        {
            get
            {
                if (ViewState["UnSelectUser"] == null)
                {
                    return new List<CustomerInfo>();
                }

                return (List<CustomerInfo>)ViewState["UnSelectUser"];
            }
            set
            {
                ViewState["UnSelectUser"] = value;
            }
        }

        /// <summary>
        /// 以选择审批人
        /// </summary>
        private List<CustomerInfo> SelectedUser
        {
            get
            {
                if (ViewState["lstSelectedUser"] == null)
                {
                    return new List<CustomerInfo>();
                }

                return (List<CustomerInfo>)ViewState["lstSelectedUser"];
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
        #endregion

        #region 初始化
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
 
            InvestmentLoanManage manage = new InvestmentLoanManage();
            List<CustomerInfo> lstUserRoles = manage.GetCustomersByCondtion("1 = 1");
            string strAccountancyID = string.Empty;

            //if (!string.IsNullOrEmpty(JiangChengID))
            //{
            //    JiangChengInfo _info = new JiangChengManage().GetJiangChengByObjectID(JiangChengID);
            //    if (_info != null)
            //    {
            //        strAccountancyID = _info.ZjID.ToString();
            //    }
            //}

            List<CustomerInfo> lstUnSelect = new List<CustomerInfo>();
            List<CustomerInfo> lstSelected = new List<CustomerInfo>();
           // bool isContains = false;
          //  string[] arrayRoles = { };
            foreach (var user in lstUserRoles)
            {
                //isContains = false;
                //arrayRoles = user.Roles.Split(',');
                //for (int i = 0; i < arrayRoles.Length; i++)
                //{
                //    if (arrayRoles[i] == "4" || arrayRoles[i] == "5" || arrayRoles[i] == "6" || arrayRoles[i] == "7")
                //    {
                //        isContains = true;
                //        break;
                //    }
                //}

                //if (isContains)
                //{
                //    if (user.UserObjectId.ToString() == strAccountancyID)
                //    {
                   //           lstSelected.Add(user);
                //    }
                //    else
                //    {
                  lstUnSelect.Add(user);
                //    }
                //}
            }

            lstSelected.Sort(delegate(CustomerInfo x, CustomerInfo y) { return string.Compare(x.Name, y.Name); });
            lstUnSelect.Sort(delegate(CustomerInfo x, CustomerInfo y) { return string.Compare(x.Name, y.Name); });

            this.gridUnSelectUser.DataSource = lstUnSelect;
            this.gridUnSelectUser.DataBind();

            this.gridSelectdUsers.DataSource = lstSelected;
            this.gridSelectdUsers.DataBind();

            UnSelectUser = lstUnSelect;
            SelectedUser = lstSelected;
        }
        #endregion 

        #region 控件事件
        /// <summary>
        /// 保存事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            List<CustomerInfo> lstSelected = SelectedUser;

            if (lstSelected.Count == 0)
            {
                Alert.Show("请选择借款人!");
                return;
            }

            PageContext.RegisterStartupScript(ExtAspNet.ActiveWindow.GetHidePostBackReference(lstSelected[0].ObjectId.ToString() + "," + lstSelected[0].Name + "," + lstSelected[0].MobilePhone));
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
                Alert.Show("请在左边选择借款人！");
                return;
            }

            int index = gridUnSelectUser.SelectedRowIndexArray[0];

            List<CustomerInfo> lstSelected = SelectedUser;
            List<CustomerInfo> lstUnSelect = UnSelectUser;

            CustomerInfo user = UnSelectUser[index];
            lstUnSelect.RemoveAt(index);
            if (lstSelected.Count > 0)
            {
                lstUnSelect.Add(lstSelected[0]);
                lstSelected.Clear();
            }
            lstSelected.Add(user);


            lstSelected.Sort(delegate(CustomerInfo x, CustomerInfo y) { return string.Compare(x.Name, y.Name); });
            lstUnSelect.Sort(delegate(CustomerInfo x, CustomerInfo y) { return string.Compare(x.Name, y.Name); });

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
                Alert.Show("请选择要移除的借款人！");
                return;
            }
            int index = gridSelectdUsers.SelectedRowIndexArray[0];

            List<CustomerInfo> lstSelected = SelectedUser;
            List<CustomerInfo> lstUnSelect = UnSelectUser;

            CustomerInfo user = SelectedUser[index];
            lstUnSelect.Add(user);
            lstSelected.RemoveAt(index);

            lstSelected.Sort(delegate(CustomerInfo x, CustomerInfo y) { return string.Compare(x.Name, y.Name); });
            lstUnSelect.Sort(delegate(CustomerInfo x, CustomerInfo y) { return string.Compare(x.Name, y.Name); });

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
                CustomerInfo _info = new InvestmentLoanManage().GetCustomerByObjectID(e.Values[0].ToString());
                if (_info != null)
                {
                    e.Values[4] = _info.Company;
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
                CustomerInfo _info = new InvestmentLoanManage().GetCustomerByObjectID(e.Values[0].ToString());
                if (_info != null)
                {
                    e.Values[4] = _info.Company;
                }
            }
        }
        #endregion

        #region 自定义事件
        /// <summary>
        /// 禁用所有控件
        /// </summary>
        private void DisabledAllControls()
        {
            btnSave.Enabled = false;
            btnSelect.Enabled = false;
            btnUnselect.Enabled = false;
        }
        #endregion
    }
}