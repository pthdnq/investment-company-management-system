using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using com.TZMS.Model;
using com.TZMS.Business;
using ExtAspNet;

namespace TZMS.Web
{
    public partial class MaterialsPurchaseImport : BasePage
    {
        /// <summary>
        /// ApplyID
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

                BindApplyInfo();
                BindApproveHistory();
            }
        }

        #region 私有方法

        /// <summary>
        /// 绑定报销申请单信息
        /// </summary>
        private void BindApplyInfo()
        {
            if (!string.IsNullOrEmpty(ApplyID))
            {
                MaterialsManage _manage = new MaterialsManage();
                MaterialsPurchaseApplyInfo _info = _manage.GetPurchaseApplyByObjectID(ApplyID);
                if (_info != null)
                {
                    MaterialsManageInfo _manageInfo = _manage.GetMaterialByObjectID(_info.MaterialsID.ToString());
                    if (_manageInfo != null)
                    {
                        ddlstType.Text = _manageInfo.MaterialsType == 0 ? "办公用品" : "固定资产";
                        ddlstMaterialName.Text = _manageInfo.MaterialsName;
                    }
                    lblName.Text = _info.UserName;
                    lblApplyTime.Text = _info.ApplyTime.ToString("yyyy-MM-dd HH:mm");
                    tbxCount.Text = _info.Count.ToString();
                    tbxMoney.Text = _info.Money.ToString();
                    dpkNeedsDate.Text = _info.NeedsDate.ToString("yyyy-MM-dd");
                    taaSument.Text = _info.Sument;
                    taaOther.Text = _info.Other;

                    if (_info.HasImport)
                    {
                        btnPass.Enabled = false;
                    }
                }
            }
        }

        /// <summary>
        /// 绑定审批历史
        /// </summary>
        private void BindApproveHistory()
        {
            if (ApplyID == null)
                return;
            // 获取数据.
            StringBuilder strCondition = new StringBuilder();
            strCondition.Append(" ApplyID = '" + ApplyID + "'");
            strCondition.Append(" and ApproveState <> 0");
            List<MaterialsApproveInfo> lstBaoxiaoCheckInfo = new MaterialsManage().GetApproveByCondition(strCondition.ToString());

            lstBaoxiaoCheckInfo.Sort(delegate(MaterialsApproveInfo x, MaterialsApproveInfo y) { return DateTime.Compare(y.ApproveTime, x.ApproveTime); });

            // 绑定列表.
            gridApproveHistory.RecordCount = lstBaoxiaoCheckInfo.Count;
            this.gridApproveHistory.DataSource = lstBaoxiaoCheckInfo;
            this.gridApproveHistory.DataBind();
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
        /// 通过事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnPass_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ApplyID))
            {
                return;
            }

            MaterialsManage _manage = new MaterialsManage();
            MaterialsPurchaseApplyInfo _info = _manage.GetPurchaseApplyByObjectID(ApplyID);
            int result = 3;
            if (_info != null)
            {
                //int importCount = Convert.ToInt32(tbxImportCount.Text.Trim());
                //decimal importMoney = Convert.ToDecimal(tbxImportMoney.Text.Trim());

                //if (importCount > _info.Count)
                //{
                //    Alert.Show("入库数量不可大于申请数量!");
                //    return;
                //}

                //if (importMoney > _info.Money)
                //{
                //    Alert.Show("入库金额不可大于申请金额!");
                //    return;
                //}

                _info.HasImport = true;
                _info.ImportTime = DateTime.Now;
                result = _manage.UpdatePurchaseApply(_info);

                // 更新数量.
                MaterialsManageInfo _materialInfo = _manage.GetMaterialByObjectID(_info.MaterialsID.ToString());
                if (_materialInfo != null)
                {
                    _materialInfo.Numbers += _info.Count;
                    _manage.UpdateMaterial(_materialInfo);

                    // 资金流量.
                    CashFlowManage _cashFlowManage = new CashFlowManage();
                    _cashFlowManage.Add(_info.Money, DateTime.Now, TZMS.Common.FlowDirection.Payment, TZMS.Common.Biz.MaterialsPurchase, 
                        "采购" + (_materialInfo.MaterialsType == 0? "办公用品" : "固定资产") + _materialInfo.MaterialsName + " 数量" + _info.Count, string.Empty);
                }

                // 插入入库记录.
                MaterialsApproveInfo _archiveApproveInfo = new MaterialsApproveInfo();
                _archiveApproveInfo.ObjectID = Guid.NewGuid();
                _archiveApproveInfo.ApproverID = CurrentUser.ObjectId;
                _archiveApproveInfo.ApproverName = CurrentUser.Name;
                _archiveApproveInfo.ApproveTime = DateTime.Now;
                _archiveApproveInfo.ApproveState = 1;
                _archiveApproveInfo.ApproveOp = 5;
                _archiveApproveInfo.ApproveSugest = "数量:" + _info.Count + " 金额:" + _info.Money.ToString() + "元";  
                _archiveApproveInfo.ApplyID = _info.ObjectID;
                _manage.AddNewApprove(_archiveApproveInfo);
            }

            if (result == -1)
            {
                this.btnClose_Click(null, null);
            }
            else
            {
                Alert.Show("入库失败!");
            }
        }

        /// <summary>
        /// 审批历史数据行绑定事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridApproveHistory_RowDataBound(object sender, ExtAspNet.GridRowEventArgs e)
        {
            if (e.DataItem != null)
            {
                e.Values[1] = DateTime.Parse(e.Values[1].ToString()).ToString("yyyy-MM-dd HH:mm");
                switch (e.Values[2].ToString())
                {
                    case "0":
                        e.Values[2] = "起草";
                        break;
                    case "1":
                        e.Values[2] = "审批-通过";
                        break;
                    case "2":
                        e.Values[2] = "审批-不通过";
                        break;
                    case "4":
                        e.Values[2] = "归档";
                        break;
                    case "5":
                        e.Values[2] = "入库";
                        break;
                    default:
                        break;
                }
            }
        }

        #endregion
    }
}