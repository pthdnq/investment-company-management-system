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
    public partial class MaterialsComsume : BasePage
    {
        /// <summary>
        /// MaterialObjectID
        /// </summary>
        public string MaterialObjectID
        {
            get
            {
                if (ViewState["MaterialObjectID"] == null)
                {
                    return null;
                }
                return ViewState["MaterialObjectID"].ToString();
            }

            set
            {
                ViewState["MaterialObjectID"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                wndComsume.OnClientCloseButtonClick = wndComsume.GetHidePostBackReference();

                MaterialObjectID = Request.QueryString["ID"];
                BindComsumeGrid();
                BindComsumeHistory();
            }
        }

        #region 私有方法

        /// <summary>
        /// 绑定领用列表
        /// </summary>
        private void BindComsumeGrid()
        {
            if (string.IsNullOrEmpty(MaterialObjectID))
                return;
            MaterialsManage _manage = new MaterialsManage();
            List<MaterialsApplyInfo> lstApplyInfo = _manage.GetApplyByCondition(" MaterialsID = '" + MaterialObjectID + "' and State = 2");
            gridApply.RecordCount = lstApplyInfo.Count;
            this.gridApply.DataSource = lstApplyInfo;
            this.gridApply.DataBind();
        }

        /// <summary>
        /// 绑定领用历史
        /// </summary>
        private void BindComsumeHistory()
        {
            if (string.IsNullOrEmpty(MaterialObjectID))
                return;
            MaterialsManage _manage = new MaterialsManage();
            List<MaterialsApplyInfo> lstApplyInfo = _manage.GetApplyByCondition(" MaterialsID = '" + MaterialObjectID + "' and State = 3");
            gridApply.RecordCount = lstApplyInfo.Count;
            this.gridComsumeHistory.DataSource = lstApplyInfo;
            this.gridComsumeHistory.DataBind();
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
        /// 数据行点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridApply_RowCommand(object sender, ExtAspNet.GridCommandEventArgs e)
        {
            string strApplyID = ((GridRow)gridApply.Rows[e.RowIndex]).Values[0];
            switch (e.CommandName)
            {
                case "Comsume":
                    wndComsume.IFrameUrl = "MaterialsSubComsume.aspx?ID=" + strApplyID;
                    wndComsume.Hidden = false;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 数据行绑定事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridApply_RowDataBound(object sender, ExtAspNet.GridRowEventArgs e)
        {
            if (e.DataItem != null)
            {
                e.Values[5] = DateTime.Parse(e.Values[5].ToString()).ToString("yyyy-MM-dd HH:mm");
            }
        }

        /// <summary>
        /// 数据行绑定事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridComsumeHistory_RowDataBound(object sender, ExtAspNet.GridRowEventArgs e)
        {
            if (e.DataItem != null)
            {
                MaterialsApplyInfo _applyInfo = (MaterialsApplyInfo)e.DataItem;
                MaterialsManage _manage = new MaterialsManage();
                List<MaterialsApproveInfo> lstApproveInfo = _manage.GetApproveByCondition(" ApplyID = '" + _applyInfo.ObjectID.ToString() + "' and ApproveOp = 4");
                if (lstApproveInfo.Count > 0)
                {
                    e.Values[4] = lstApproveInfo[0].ApproveTime.ToString("yyyy-MM-dd HH:mm");
                }
            }
        }

        /// <summary>
        /// 物资领用窗口关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void wndComsume_Close(object sender, WindowCloseEventArgs e)
        {
            BindComsumeGrid();
            BindComsumeHistory();
        }

        #endregion
    }
}