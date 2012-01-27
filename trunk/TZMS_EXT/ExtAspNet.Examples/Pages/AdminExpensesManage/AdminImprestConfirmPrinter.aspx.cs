﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.TZMS.Business;
using com.TZMS.Model;
using System.Text;

namespace TZMS.Web.Pages.AdminExpensesManage
{
    public partial class AdminImprestConfirmPrinter : System.Web.UI.Page
    {
        #region 属性
        /// <summary>
        ///  ObjectID
        /// </summary>
        public string ObjectID
        {
            get
            {
                if (ViewState["ObjectID"] == null)
                {
                    return null;
                }

                return ViewState["ObjectID"].ToString();
            }
            set
            {
                ViewState["ObjectID"] = value;
            }
        }
        #endregion

        #region 初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string strID = Request.QueryString["ID"];
                ObjectID = strID;

                bindInterface(strID);
                //BindHistory();
            }
        }

        /// <summary>
        /// 绑定指定 ID的数据到界面.
        /// </summary>
        /// <param name="strID">用户ID</param>
        private void bindInterface(string strID)
        {
            if (string.IsNullOrEmpty(strID))
            {
                return;
            }

            // 通过 ID获取 信息实例.
            com.TZMS.Model.AdminImprestInfo _info = new AdminImprestManage().GetUserByObjectID(strID);

            // 绑定数据.
            if (_info != null)
            {
                this.tbProjectName.Text = _info.ProjectName;
                this.lbImplementationPhase.Text = _info.Use;
                string uper = Common.GetUperNumNames((int)_info.PrepaidAmount, string.Empty);
                lbLoanAmountUper.Text = uper;
                this.lbLoanAmount.Text = _info.PrepaidAmount.ToString();
                //this.lbLoanDate.Text = _info.ExpendedTime.ToString();

                lbApplier.Text = _info.CreaterName;
                lbPaymenter.Text = _info.AccountingName;

                this.tbDate.Text = _info.CreateTime.ToString("yyyy年MM月dd日");

                string strCondition = string.Format("ForId = '{0}'  ORDER BY OperationTime ASC", _info.ObjectId);
                List<com.TZMS.Model.AdminImprestHistoryInfo> lstInfo = new AdminImprestManage().GetHistoryByCondtion(strCondition.ToString());
                System.Text.StringBuilder strHistory = new System.Text.StringBuilder();
                foreach (var info in lstInfo)
                {
                    strHistory.Append(string.Format("<br/>{1}于{0:yyyy年MM月dd日}{2}", info.OperationTime, info.OperationerName, info.OperationDesc));
                }
                lbHistory.Text = strHistory.ToString();
            }
        }
        #endregion
    }
}