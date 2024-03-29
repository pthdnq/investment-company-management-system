﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.TZMS.Business;

namespace TZMS.Web.Pages.InvestmentProjectPages
{
    public partial class ImprestPayConfirmPrinter : System.Web.UI.Page
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
            com.TZMS.Model.ProjectProcessInfo _info = new InvestmentProjectManage().GetProcessByObjectID(strID);

            // 绑定数据.
            if (_info != null)
            {
                this.tbProjectName.Text = _info.ProjectName;
                this.lbImplementationPhase.Text = _info.Use;

                  Common.MoneyLowToUper common = new Common.MoneyLowToUper(); string uper = common.GetUperNumNames(_info.AmountExpended, string.Empty);
                lbLoanAmountUper.Text = uper;
                this.lbLoanAmount.Text = _info.AmountExpendedFlag+_info.AmountExpended.ToString();
              //  this.lbLoanDate.Text = _info.ExpendedTime.ToString();

                lbApplier.Text = _info.CreaterName;
                lbPaymenter.Text = _info.NextOperaterName;
                //     this.taRemark.Text = _info.Remark;
                //     this.taAuditOpinion.Text = _info.AuditOpinion;
                //if (DateTime.Compare(_info.ExpendedTime, DateTime.Parse("1900-1-1 12:00")) != 0)
                //{
                this.tbDate.Text = DateTime.Now.ToString("yyyy年MM月dd日");
                //    }
                string strCondition = string.Format("ForId = '{0}'  ORDER BY OperationTime ASC", _info.ObjectId);
                List<com.TZMS.Model.ProjectProcessHistoryInfo> lstInfo = new InvestmentProjectManage().GetProcessHistoryByCondtion(strCondition.ToString());
                System.Text.StringBuilder strHistory = new System.Text.StringBuilder();
                foreach (var info in lstInfo)
                {
                    strHistory.Append(string.Format("<br/>{1}于{0:yyyy年MM月dd日}{2}", info.OperationTime, info.OperationerName, info.OperationDesc));
                }
                lbHistory.Text = strHistory.ToString();
                lbOther.Text = _info.Remark.Trim();
            }
        }
        #endregion
    }
}