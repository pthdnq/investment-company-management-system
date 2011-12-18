using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExtAspNet;
using com.TZMS.Business;
using com.TZMS.Model;

namespace TZMS.Web
{
    public partial class NewMaterials : BasePage
    {
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
        /// MaterialsManageID
        /// </summary>
        public string MaterialsManageID
        {
            get
            {
                if (ViewState["MaterialsManageID"] == null)
                {
                    return null;
                }

                return ViewState["MaterialsManageID"].ToString();
            }
            set
            {
                ViewState["MaterialsManageID"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                OperatorType = Request.QueryString["Type"];
                MaterialsManageID = Request.QueryString["ID"];

                switch (OperatorType)
                {
                    case "Add":
                        BindType();
                        break;
                    case "Edit":
                        BindType();
                        BindMaterialsInfo();
                        break;
                    case "View":
                        BindType();
                        BindMaterialsInfo();
                        DisabledAllControlls();
                        break;
                    default:
                        break;
                }
            }
        }

        #region 私有方法

        /// <summary>
        /// 绑定类型
        /// </summary>
        private void BindType()
        {
            ddlstType.Items.Add(new ExtAspNet.ListItem("办公用品", "0"));
            ddlstType.Items.Add(new ExtAspNet.ListItem("固定资产", "1"));
        }

        /// <summary>
        /// 绑定物资信息
        /// </summary>
        private void BindMaterialsInfo()
        {
            if (string.IsNullOrEmpty(MaterialsManageID))
                return;
            MaterialsManage _manage = new MaterialsManage();
            MaterialsManageInfo _info = _manage.GetMaterialByObjectID(MaterialsManageID);
            if (_info != null)
            {
                ddlstType.SelectedValue = _info.MaterialsType.ToString();
                tbxMaterialName.Text = _info.MaterialsName;
                tbxNumbers.Text = _info.Numbers.ToString();
            }
        }

        /// <summary>
        /// 禁用所有控件
        /// </summary>
        private void DisabledAllControlls()
        {
            btnSubmit.Enabled = false;
            ddlstType.Required = false;
            ddlstType.ShowRedStar = false;
            ddlstType.Enabled = false;
            tbxMaterialName.Required = false;
            tbxMaterialName.ShowRedStar = false;
            tbxMaterialName.Enabled = false;
            tbxNumbers.Required = false;
            tbxNumbers.ShowRedStar = false;
            tbxNumbers.Enabled = false;
        }

        /// <summary>
        /// 保存物资信息.
        /// </summary>
        private void SaveMaterialsInfo()
        {
            if (OperatorType == null)
                return;

            MaterialsManage _manage = new MaterialsManage();
            MaterialsManageInfo _info = null;
            int result = 3;

            #region 添加物资

            if (OperatorType == "Add")
            {
                _info = new MaterialsManageInfo();
                _info.ObjectID = Guid.NewGuid();
                _info.MaterialsType = Convert.ToInt16(ddlstType.SelectedValue);
                _info.MaterialsName = tbxMaterialName.Text.Trim();
                _info.Numbers = Convert.ToInt32(tbxNumbers.Text.Trim());
                _info.CurrentNumbers = 0;

                result = _manage.AddNewMaterial(_info);
            }
            #endregion

            #region 编辑编辑

            if (OperatorType == "Edit")
            {
                _info = _manage.GetMaterialByObjectID(MaterialsManageID);
                if (_info != null)
                {
                    _info.MaterialsType = Convert.ToInt16(ddlstType.SelectedValue);
                    _info.MaterialsName = tbxMaterialName.Text.Trim();
                    _info.Numbers = Convert.ToInt32(tbxNumbers.Text.Trim());

                    result = _manage.UpdateMaterial(_info);
                }
            }

            #endregion

            if (result == -1)
            {
                this.btnClose_Click(null, null);
            }
            else
            {
                Alert.Show("物资保存失败!");
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
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SaveMaterialsInfo();
        }

        #endregion
    }
}