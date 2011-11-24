using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.TZMS.Business;
using com.TZMS.Model;
using ExtAspNet;

namespace TZMS.Web
{
    public partial class ProxyAccountingUnitNew : BasePage
    {
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
                wndAccountancy.OnClientCloseButtonClick = wndAccountancy.GetHidePostBackReference();

                OperatorType = Page.Request.QueryString["Type"];
                UnitID = Page.Request.QueryString["ID"];

                switch (OperatorType)
                {
                    case "Add":
                        {

                        }
                        break;
                    case "View":
                        {
                            BindUnitInfo();
                            DisableAllControls();
                            btnSetAccountancy.Hidden = true;
                        }
                        break;
                    case "Edit":
                        {
                            BindUnitInfo();
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        #region 私有方法

        private void BindUnitInfo()
        {
            if (string.IsNullOrEmpty(UnitID))
                return;

            ProxyAccountingManage _manage = new ProxyAccountingManage();
            ProxyAccountingUnitInfo _info = _manage.GetUnitByObjectID(UnitID);
            if (_info != null)
            {
                tbxUnitName.Text = _info.UnitName;
                lblAccountancy.Text = _info.AccountancyName;
                tbxTitle.Text = _info.UnitAddress;
                taaOther.Text = _info.Other;

            }
        }

        private void DisableAllControls()
        {
            btnSave.Enabled = false;
            btnSetAccountancy.Enabled = false;
            tbxTitle.Required = false;
            tbxTitle.ShowRedStar = false;
            tbxTitle.Enabled = false;
            tbxUnitName.Required = false;
            tbxUnitName.ShowRedStar = false;
            tbxUnitName.Enabled = false;
            taaOther.Required = false;
            taaOther.ShowRedStar = false;
            taaOther.Enabled = false;
            lblAccountancy.ShowRedStar = false;
            lblAccountancy.Required = false;
            lblAccountancy.Enabled = false;
        }

        private void SaveInfo()
        {
            ProxyAccountingManage _manage = new ProxyAccountingManage();
            ProxyAccountingUnitInfo _info = null;

            if (Session["Accountancy:" + CurrentUser.ObjectId.ToString()] == null)
            {
                Alert.Show("代账会计尚未设置!");
                return;
            }

            if (OperatorType == "Add")
            {
                _info = new ProxyAccountingUnitInfo();
                _info.ObjectID = Guid.NewGuid();
                _info.UnitName = tbxUnitName.Text.Trim();
                _info.UnitAddress = tbxTitle.Text.Trim();
                _info.Other = taaOther.Text.Trim();
                _info.AccountancyID = new Guid(Session["Accountancy:" + CurrentUser.ObjectId.ToString()].ToString().Split(',')[0]);
                _info.AccountancyName = Session["Accountancy:" + CurrentUser.ObjectId.ToString()].ToString().Split(',')[1];

                int result = _manage.AddNewUnit(_info);
                if (result == -1)
                {
                    //Alert.Show("添加单位成功!");
                    //btnSave.Enabled = false;
                    //btnSetAccountancy.Enabled = false;

                    this.btnClose_Click(null, null);
                }
                else
                {
                    Alert.Show("添加单位失败!");
                }
            }

            if (OperatorType == "Edit")
            {
                _info = _manage.GetUnitByObjectID(UnitID);
                _info.UnitName = tbxUnitName.Text.Trim();
                _info.UnitAddress = tbxTitle.Text.Trim();
                _info.Other = taaOther.Text.Trim();
                _info.AccountancyID = new Guid(Session["Accountancy:" + CurrentUser.ObjectId.ToString()].ToString().Split(',')[0]);
                _info.AccountancyName = Session["Accountancy:" + CurrentUser.ObjectId.ToString()].ToString().Split(',')[1];

                int result = _manage.UpdateUnit(_info);
                if (result == -1)
                {
                    //Alert.Show("编辑单位成功!");
                    //btnSave.Enabled = false;
                    //btnSetAccountancy.Enabled = false;
                    //btnSetAccountancy.Hidden = true;
                    this.btnClose_Click(null, null);
                }
                else
                {
                    Alert.Show("编辑单位失败!");
                }
            }
        }

        #endregion

        #region 页面事件

        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnClose_Click(object sender, EventArgs e)
        {
            PageContext.RegisterStartupScript(ExtAspNet.ActiveWindow.GetHidePostBackReference());
        }

        /// <summary>
        /// 保存事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            SaveInfo();
        }

        /// <summary>
        /// 设置代帐用户事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSetAccountancy_Click(object sender, EventArgs e)
        {
            if (OperatorType == "Add")
            {
                wndAccountancy.IFrameUrl = "SelectAccountancy.aspx?Type=Add";
                wndAccountancy.Hidden = false;
            }

            if (OperatorType == "View")
            {
                wndAccountancy.IFrameUrl = "SelectAccountancy.aspx?Type=View&ID=" + UnitID;
                wndAccountancy.Hidden = false;
            }

            if (OperatorType == "Edit")
            {
                wndAccountancy.IFrameUrl = "SelectAccountancy.aspx?Type=Edit&ID=" + UnitID;
                wndAccountancy.Hidden = false;
            }
        }

        /// <summary>
        /// 代帐关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void wndAccountancy_Close(object sender, WindowCloseEventArgs e)
        {
            if (Session["Accountancy:" + CurrentUser.ObjectId.ToString()] != null)
            {
                lblAccountancy.Text = Session["Accountancy:" + CurrentUser.ObjectId.ToString()].ToString().Split(',')[1];
            }
        }

        #endregion
    }
}