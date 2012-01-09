using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.TZMS.Business.BusinessManage;
using com.TZMS.Model;
using System.Text;
using ExtAspNet;

namespace TZMS.Web
{
    public partial class CostConfirm : BasePage
    {
        /// <summary>
        /// ApproveID
        /// </summary>
        public string ApproveID
        {
            get
            {
                if (ViewState["ApproveID"] == null)
                {
                    return null;
                }
                return ViewState["ApproveID"].ToString();
            }

            set
            {
                ViewState["ApproveID"] = value;
            }
        }

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
                ApproveID = Request.QueryString["ApproveID"];
                ApplyID = Request.QueryString["ApplyID"];

                BindApplyInfo();
                BindApproveHistory();
                SetPanelState();
            }
        }

        #region 私有方法

        /// <summary>
        /// 绑定报销申请单信息
        /// </summary>
        private void BindApplyInfo()
        {
            if (string.IsNullOrEmpty(ApplyID))
                return;
            BusinessManage _manage = new BusinessManage();
            BusinessCostApplyInfo _applyInfo = _manage.GetCostApplyByObjectID(ApplyID);
            if (_applyInfo != null)
            {
                ddlstCompanyname.Items.Clear();
                ddlstCompanyname.Items.Add(new ExtAspNet.ListItem(_applyInfo.CompanyName, _applyInfo.BusinessID.ToString()));
                ddlstCostType.SelectedValue = _applyInfo.CostType.ToString();
                ddlstPayType.SelectedValue = _applyInfo.PayType.ToString();
                lblApplyMoney.Text = _applyInfo.ApplyMoney.ToString();
                dpkPayDate.SelectedDate = _applyInfo.PayDate;
                taaOther.Text = _applyInfo.Other;
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
            List<BusinessCostApproveInfo> lstBaoxiaoCheckInfo = new BusinessManage().GetCostApproveByCondition(strCondition.ToString());

            lstBaoxiaoCheckInfo.Sort(delegate(BusinessCostApproveInfo x, BusinessCostApproveInfo y) { return DateTime.Compare(y.ApproveTime, x.ApproveTime); });

            // 绑定列表.
            gridCostApproveHistory.RecordCount = lstBaoxiaoCheckInfo.Count;
            this.gridCostApproveHistory.DataSource = lstBaoxiaoCheckInfo;
            this.gridCostApproveHistory.DataBind();
        }

        /// <summary>
        /// 设置面板状态
        /// </summary>
        private void SetPanelState()
        {
            if (string.IsNullOrEmpty(ApproveID))
                return;
            BusinessManage _manage = new BusinessManage();
            BusinessCostApproveInfo _approveInfo = _manage.GetCostApproveByObjectID(ApproveID);
            if (_approveInfo != null)
            {
                if (_approveInfo.ApproveState == 1)
                {
                    btnPass.Hidden = true;
                    mainForm2.Hidden = true;
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
        /// 确认事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnPass_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ApplyID) || string.IsNullOrEmpty(ApproveID))
                return;
            BusinessManage _manage = new BusinessManage();
            BusinessCostApplyInfo _applyInfo = _manage.GetCostApplyByObjectID(ApplyID);
            BusinessCostApproveInfo _approveInfo = _manage.GetCostApproveByObjectID(ApproveID);
            int result = 3;
            if (_applyInfo != null && _approveInfo != null)
            {
                BusinessInfo _info = _manage.GetBusinessByObjectID(_applyInfo.BusinessID.ToString());
                if (_info != null)
                {
                    if (_applyInfo.CostType == 0)
                    {
                        _info.PreMoney = Convert.ToDecimal(tbxActualMoney.Text.Trim());
                        _info.PreMoneyType = 1;
                    }
                    else if (_applyInfo.CostType == 1)
                    {
                        _info.BalanceMoney = Convert.ToDecimal(tbxActualMoney.Text.Trim());
                        _info.BalanceMoneyType = 1;
                    }

                    _manage.UpdateBusiness(_info);
                }

                // 更新现有申请信息.
                _applyInfo.ActualMoney = Convert.ToDecimal(tbxActualMoney.Text.Trim());
                _applyInfo.State = 1;
                result = _manage.UpdateCostApply(_applyInfo);

                // 更新现有审批信息.
                _approveInfo.ApproveState = 1;
                _approveInfo.ApproveTime = DateTime.Now;
                _approveInfo.ApproveOp = 4;
                _manage.UpdateCostApprove(_approveInfo);
            }

            if (result == -1)
            {
                this.btnClose_Click(null, null);
            }
            else
            {
                Alert.Show("确认失败!");
            }
        }

        /// <summary>
        /// 数据行绑定事件
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
                        e.Values[2] = "已确认";
                        break;
                    default:
                        break;
                }
            }
        }

        #endregion
    }
}