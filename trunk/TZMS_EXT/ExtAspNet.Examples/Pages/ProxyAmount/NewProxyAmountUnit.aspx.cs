using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExtAspNet;
using com.TZMS.Business.ProxyAmount;
using com.TZMS.Model;

namespace TZMS.Web
{
    public partial class NewProxyAmountUnit : BasePage
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

        public string Accountancy
        {
            get
            {
                if (ViewState["Accountancy"] == null)
                {
                    return null;
                }

                return ViewState["Accountancy"].ToString();
            }
            set
            {
                ViewState["Accountancy"] = value;
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

            ProxyAmountManage _manage = new ProxyAmountManage();
            ProxyAmountUnitInfo _info = _manage.GetUnitByObjectID(UnitID);
            if (_info != null)
            {
                tbxUnitName.Text = _info.UnitName;
                lblAccountancy.Text = _info.UserName;
                tbxTitle.Text = _info.UnitAddress;
                taaOther.Text = _info.Other;
                tbxSMDJNumber.Text = _info.SMDJNumber;
                tbxDSBumber.Text = _info.DSNumber;
                tbxFRSFZ.Text = _info.FRSFZNumber;
                tbxKHHYZH.Text = _info.KHHJAccountNo;
                tbxContactPhoneNumber.Text = _info.ContactPhoneNumber;
                tbxGSManager.Text = _info.GSManager;
                tbxDSManager.Text = _info.DSManager;
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
            tbxSMDJNumber.Enabled = false;
            tbxDSBumber.Enabled = false;
            tbxFRSFZ.Enabled = false;
            tbxKHHYZH.Enabled = false;
            tbxContactPhoneNumber.Enabled = false;
            tbxGSManager.Enabled = false;
            tbxDSManager.Enabled = false;
            lblAccountancy.ShowRedStar = false;
            lblAccountancy.Required = false;
            lblAccountancy.Enabled = false;
        }

        private void SaveInfo()
        {
            ProxyAmountManage _manage = new ProxyAmountManage();
            ProxyAmountUnitInfo _info = null;

            if (string.IsNullOrEmpty(Accountancy))
            {
                Alert.Show("代账会计尚未设置!");
                return;
            }

            if (OperatorType == "Add")
            {
                _info = new ProxyAmountUnitInfo();
                _info.ObjectID = Guid.NewGuid();
                _info.UnitName = tbxUnitName.Text.Trim();
                _info.UnitAddress = tbxTitle.Text.Trim();
                _info.Other = taaOther.Text.Trim();
                _info.SMDJNumber = tbxSMDJNumber.Text.Trim();
                _info.DSNumber = tbxDSBumber.Text.Trim();
                _info.FRSFZNumber = tbxFRSFZ.Text.Trim();
                _info.KHHJAccountNo = tbxKHHYZH.Text.Trim();
                _info.ContactPhoneNumber = tbxContactPhoneNumber.Text.Trim();
                _info.GSManager = tbxGSManager.Text.Trim();
                _info.DSManager = tbxDSManager.Text.Trim();
                _info.UserID = new Guid(Accountancy.Split(',')[0]);
                _info.UserName = Accountancy.Split(',')[1];

                int result = _manage.AddNewUnit(_info);
                if (result == -1)
                {
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
                _info.SMDJNumber = tbxSMDJNumber.Text.Trim();
                _info.DSNumber = tbxDSBumber.Text.Trim();
                _info.FRSFZNumber = tbxFRSFZ.Text.Trim();
                _info.KHHJAccountNo = tbxKHHYZH.Text.Trim();
                _info.ContactPhoneNumber = tbxContactPhoneNumber.Text.Trim();
                _info.GSManager = tbxGSManager.Text.Trim();
                _info.DSManager = tbxDSManager.Text.Trim();
                _info.UserID = new Guid(Accountancy.Split(',')[0]);
                _info.UnitName = Accountancy.Split(',')[1];

                int result = _manage.UpdateUnit(_info);
                if (result == -1)
                {
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
        /// 关闭事件
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
        /// 设置代帐人
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSetAccountancy_Click(object sender, EventArgs e)
        {
            if (OperatorType == "Add")
            {
                wndAccountancy.IFrameUrl = "SelectProxyAmounter.aspx?Type=Add";
                wndAccountancy.Hidden = false;
            }

            if (OperatorType == "View")
            {
                wndAccountancy.IFrameUrl = "SelectProxyAmounter.aspx?Type=View&ID=" + UnitID;
                wndAccountancy.Hidden = false;
            }

            if (OperatorType == "Edit")
            {
                wndAccountancy.IFrameUrl = "SelectProxyAmounter.aspx?Type=Edit&ID=" + UnitID;
                wndAccountancy.Hidden = false;
            }
        }

        /// <summary>
        /// 代帐人窗口关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void wndAccountancy_Close(object sender, ExtAspNet.WindowCloseEventArgs e)
        {
            if (e.CloseArgument != "undefined")
            {
                Accountancy = e.CloseArgument;
                lblAccountancy.Text = e.CloseArgument.Split(',')[1];
            }
        }

        #endregion
    }
}