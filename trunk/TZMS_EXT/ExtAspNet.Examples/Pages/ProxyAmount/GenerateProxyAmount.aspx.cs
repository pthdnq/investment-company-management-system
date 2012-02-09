using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.TZMS.Model;
using com.TZMS.Business;
using com.TZMS.Business.ProxyAmount;
using ExtAspNet;
using System.Text;

namespace TZMS.Web
{
    public partial class GenerateProxyAmount : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CurrentLevel = GetCurrentLevel("dzdgl");

                dpkStartTime.SelectedDate = DateTime.Now;
                dpkEndTime.SelectedDate = DateTime.Now;
                dpkGenerateDZDate.SelectedDate = DateTime.Now;
                dpkGenerateNJDate.SelectedDate = DateTime.Now;

                wndProxyAmount.OnClientCloseButtonClick = wndProxyAmount.GetHidePostBackReference();

                BindProxyAmounter();
                BindGrid();

                if (CurrentLevel == VisitLevel.View)
                {
                    btnGenerateDZ.Enabled = false;
                    dpkGenerateDZDate.Enabled = false;
                    btnGenerateNJ.Enabled = false;
                    dpkGenerateNJDate.Enabled = false;
                }
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
            strCondition.Append(" IsDelete <> 1");
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
        /// 代帐费生成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnGenerateDZ_Click(object sender, EventArgs e)
        {
            ProxyAmountManage _manage = new ProxyAmountManage();
            List<ProxyAmountTemplateApplyInfo> lstTemplate = _manage.GetTemplateApplyByCondition(" IsDelete = 0 and State = 3 and TemplateType = 0");
            foreach (ProxyAmountTemplateApplyInfo info in lstTemplate)
            {
                DateTime selectDate = Convert.ToDateTime(dpkGenerateDZDate.SelectedDate);
                List<ProxyAmountInfo> lstProxyAmount = _manage.GetProxyAmountByCondition(" ProxyAmountType = 0 and  ProxyAmounterID ='" + info.ProxyAmounterID.ToString()
                    + "' and Sument Like '%" + selectDate.Year + "年" + selectDate.Month + "月份%' and IsDelete = 0 ");
                if (lstProxyAmount.Count == 0)
                {
                    ProxyAmountInfo _info = new ProxyAmountInfo();
                    _info.ObjectID = Guid.NewGuid();
                    _info.CreaterID = CurrentUser.ObjectId;
                    _info.CreateName = CurrentUser.Name;
                    _info.CreateTime = DateTime.Now;
                    _info.ProxyAmountID = info.ProxyAmountUnitID;
                    _info.ProxyAmountUnitName = info.ProxyAmountUnitName;
                    _info.ProxyAmounterID = info.ProxyAmounterID;
                    _info.ProxyAmounterName = info.ProxyAmounterName;
                    _info.CNMoney = info.CNMoney;
                    _info.ENMoney = info.ENMoney;
                    _info.Sument = selectDate.Year + "年" + selectDate.Month + "月份代帐费" + info.ENMoney.ToString() + "元";
                    _info.OpeningDate = DateTime.Now;
                    _info.CollectMethod = info.CollectMethod;
                    _info.CollecterName = "合肥吉信财务管理有限公司";
                    _info.State = 0;
                    _info.IsDelete = false;
                    _info.ProxyAmountType = 0;

                    _manage.AddNewProxyAmount(_info);
                    _info = null;
                }
            }

            BindGrid();
        }

        /// <summary>
        /// 年检费生成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnGenerateNJ_Click(object sender, EventArgs e)
        {
            ProxyAmountManage _manage = new ProxyAmountManage();
            List<ProxyAmountTemplateApplyInfo> lstTemplate = _manage.GetTemplateApplyByCondition(" IsDelete = 0 and State = 3 and TemplateType = 1");
            foreach (ProxyAmountTemplateApplyInfo info in lstTemplate)
            {
                DateTime selectDate = Convert.ToDateTime(dpkGenerateNJDate.SelectedDate);
                List<ProxyAmountInfo> lstProxyAmount = _manage.GetProxyAmountByCondition(" ProxyAmountType = 1 and  ProxyAmounterID ='" + info.ProxyAmounterID.ToString()
                    + "' and Sument Like '%" + selectDate.Year + "年%'");
                if (lstProxyAmount.Count == 0)
                {
                    ProxyAmountInfo _info = new ProxyAmountInfo();
                    _info.ObjectID = Guid.NewGuid();
                    _info.CreaterID = CurrentUser.ObjectId;
                    _info.CreateName = CurrentUser.Name;
                    _info.CreateTime = DateTime.Now;
                    _info.ProxyAmountID = info.ProxyAmountUnitID;
                    _info.ProxyAmountUnitName = info.ProxyAmountUnitName;
                    _info.ProxyAmounterID = info.ProxyAmounterID;
                    _info.ProxyAmounterName = info.ProxyAmounterName;
                    _info.CNMoney = info.CNMoney;
                    _info.ENMoney = info.ENMoney;
                    _info.Sument = selectDate.Year + "年年检费" + info.ENMoney.ToString() + "元";
                    _info.OpeningDate = DateTime.Now;
                    _info.CollectMethod = info.CollectMethod;
                    _info.CollecterName = "合肥吉信财务管理有限公司";
                    _info.State = 0;
                    _info.IsDelete = false;
                    _info.ProxyAmountType = 1;

                    _manage.AddNewProxyAmount(_info);
                    _info = null;
                }
            }

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
                wndProxyAmount.IFrameUrl = "ProxyAmountDetial.aspx?Type=View&ID=" + strApplyID;
                wndProxyAmount.Hidden = false;
            }

            if (e.CommandName == "Edit")
            {
                wndProxyAmount.IFrameUrl = "ProxyAmountDetial.aspx?Type=Edit&ID=" + strApplyID;
                wndProxyAmount.Hidden = false;
            }

            if (e.CommandName == "Delete")
            {
                ProxyAmountManage _manage = new ProxyAmountManage();
                ProxyAmountInfo _info = _manage.GetProxyAmountByObjectID(strApplyID);
                if (_info != null)
                {
                    _info.IsDelete = true;
                    _manage.UpdateProxyAmount(_info);

                    BindGrid();
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
                e.Values[2] = e.Values[2].ToString() == "0" ? "代帐费" : "年检费";
                e.Values[9] = DateTime.Parse(e.Values[9].ToString()).ToString("yyyy-MM-dd");
                switch (e.Values[11].ToString())
                {
                    case "0":
                        e.Values[11] = "待上交";
                        break;
                    case "1":
                        e.Values[11] = "待出纳确认";
                        e.Values[13] = "<span class=\"gray\">编辑</span>";
                        e.Values[14] = "<span class=\"gray\">删除</span>";
                        break;
                    case "2":
                        e.Values[11] = "出纳已确认";
                        e.Values[13] = "<span class=\"gray\">编辑</span>";
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// 代帐单窗口关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void wndProxyAmount_Close(object sender, ExtAspNet.WindowCloseEventArgs e)
        {
            BindGrid();
        }

        #endregion
    }
}