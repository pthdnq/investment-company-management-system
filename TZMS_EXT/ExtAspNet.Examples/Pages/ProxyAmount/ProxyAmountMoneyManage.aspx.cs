using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExtAspNet;
using System.Text;
using com.TZMS.Model;
using com.TZMS.Business.ProxyAmount;
using com.TZMS.Business;

namespace TZMS.Web
{
    public partial class ProxyAmountMoneyManage : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CurrentLevel = GetCurrentLevel("dzdgl");

                dpkStartTime.SelectedDate = DateTime.Now;
                dpkEndTime.SelectedDate = DateTime.Now;

                BindProxyAmounter();
                BindGrid();
            }
        }

        #region 私有方法

        /// <summary>
        /// 根据角色类型来获取用户
        /// </summary>
        /// <param name="roleType">角色类型</param>
        /// <returns>用户集合</returns>
        private List<UserRoles> GetUsersByRole(RoleType roleType)
        {
            List<UserRoles> lstUserRoles = new List<UserRoles>();
            List<UserRoles> lstRoles = new RolesManage().GerRolesByCondition("1 = 1");
            if (lstRoles.Count > 0)
            {
                string[] arrayRoles = { };
                bool isContain = false;
                foreach (UserRoles role in lstRoles)
                {
                    isContain = false;
                    arrayRoles = role.Roles.Split(',');
                    foreach (string strRole in arrayRoles)
                    {
                        if (string.IsNullOrEmpty(strRole))
                            continue;
                        if ((int)roleType == Convert.ToInt32(strRole))
                        {
                            isContain = true;
                            break;
                        }
                    }

                    if (isContain)
                    {
                        lstUserRoles.Add(role);
                    }
                }
            }

            return lstUserRoles;
        }

        /// <summary>
        /// 绑定代帐会计
        /// </summary>
        private void BindProxyAmounter()
        {
            ddlstProxyAmounter.Items.Clear();
            ddlstProxyAmounter.Items.Add(new ExtAspNet.ListItem("全部", "0"));
            List<UserRoles> lstRoles = this.GetUsersByRole(RoleType.DZKJ);
            foreach (UserRoles role in lstRoles)
            {
                ddlstProxyAmounter.Items.Add(new ExtAspNet.ListItem(role.Name, role.UserObjectId.ToString()));
            }
            ddlstProxyAmounter.SelectedIndex = 0;
        }

        /// <summary>
        /// 绑定列表
        /// </summary>
        private void BindGrid()
        {
            #region 查询条件

            DateTime startTime = Convert.ToDateTime(dpkStartTime.SelectedDate);
            DateTime endTime = Convert.ToDateTime(dpkEndTime.SelectedDate);

            if (DateTime.Compare(startTime, endTime) == 1)
            {
                Alert.Show("结束日期不可小于开始日期!");
                return;
            }

            StringBuilder strCondition = new StringBuilder();
            strCondition.Append(" IsDelete <> 1 and State <> 0");
            if (!string.IsNullOrEmpty(tbxSearch.Text.Trim()))
            {
                strCondition.Append(" and ProxyAmountUnitName Like '%" + tbxSearch.Text.Trim() + "%'");
            }

            if (ddlstProxyAmounter.Items.Count > 0)
            {
                if (ddlstProxyAmounter.SelectedText != "全部")
                    strCondition.Append(" and ProxyAmounterID = '" + ddlstProxyAmounter.SelectedValue + "'");
            }

            strCondition.Append(" and Year(OpeningDate) = " + Convert.ToDateTime(dpkStartTime.SelectedDate).Year
                + "and Month(OpeningDate) = " + Convert.ToDateTime(dpkEndTime.SelectedDate).Month);

            #endregion

            List<ProxyAmountInfo> lstApply = new ProxyAmountManage().GetProxyAmountByCondition(strCondition.ToString());
            this.gridProxyAmount.RecordCount = lstApply.Count;
            this.gridProxyAmount.PageSize = PageCounts;
            int currentIndex = this.gridProxyAmount.PageIndex;
            //计算当前页面显示行数据
            if (lstApply.Count > this.gridProxyAmount.PageSize)
            {
                if (lstApply.Count > (currentIndex + 1) * this.gridProxyAmount.PageSize)
                {
                    lstApply.RemoveRange((currentIndex + 1) * this.gridProxyAmount.PageSize, lstApply.Count - (currentIndex + 1) * this.gridProxyAmount.PageSize);
                }
                lstApply.RemoveRange(0, currentIndex * this.gridProxyAmount.PageSize);
            }
            this.gridProxyAmount.DataSource = lstApply;
            this.gridProxyAmount.DataBind();
        }

        #endregion

        #region 页面事件

        /// <summary>
        /// 查询事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        /// <summary>
        /// 翻页事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridProxyAmount_PageIndexChange(object sender, ExtAspNet.GridPageEventArgs e)
        {
            gridProxyAmount.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        /// <summary>
        /// 数据行点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridProxyAmount_RowCommand(object sender, ExtAspNet.GridCommandEventArgs e)
        {
            string strApplyID = ((GridRow)gridProxyAmount.Rows[e.RowIndex]).Values[0];

            if (e.CommandName == "View")
            {
                if (CurrentRoles.Contains(RoleType.DZFSQCNQR))
                {
                    ProxyAmountManage _manage = new ProxyAmountManage();
                    ProxyAmountInfo _info = _manage.GetProxyAmountByObjectID(strApplyID);
                    if (_info != null)
                    {
                        _info.State = 2;
                        _manage.UpdateProxyAmount(_info);

                        CashFlowManage _cashFlowManage = new CashFlowManage();
                        if (_info.ProxyAmountType == 0)
                        {
                            _cashFlowManage.Add(_info.ENMoney, DateTime.Now, TZMS.Common.FlowDirection.Receive, TZMS.Common.Biz.ProxyAccounting,
                                _info.ProxyAmountUnitName + "的代账费收取", string.Empty);
                        }
                        if (_info.ProxyAmountType == 1)
                        {
                            _cashFlowManage.Add(_info.ENMoney, DateTime.Now, TZMS.Common.FlowDirection.Receive, TZMS.Common.Biz.ProxyAccounting,
                                _info.ProxyAmountUnitName + "的年检费收取", string.Empty);
                        }

                        BindGrid();
                    }
                }
            }
        }

        /// <summary>
        /// 数据行绑定事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridProxyAmount_RowDataBound(object sender, ExtAspNet.GridRowEventArgs e)
        {
            if (e.DataItem != null)
            {
                switch (e.Values[10].ToString())
                {
                    case "1":
                        e.Values[10] = "待收款";
                        if (CurrentLevel == VisitLevel.View)
                        {
                            e.Values[11] = "<span class=\"gray\">确认收款</span>";
                        }

                        if (!CurrentRoles.Contains(RoleType.DZFSQCNQR))
                        {
                            e.Values[11] = "<span class=\"gray\">确认收款</span>";
                        }

                        break;
                    case "2":
                        e.Values[10] = "已收款";
                        e.Values[11] = "<span class=\"gray\">确认收款</span>";
                        break;
                    default:
                        break;
                }
            }
        }

        #endregion
    }
}