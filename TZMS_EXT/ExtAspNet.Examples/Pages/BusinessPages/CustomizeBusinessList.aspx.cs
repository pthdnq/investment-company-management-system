using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.TZMS.Business;
using com.TZMS.Model;
using System.Text;
using ExtAspNet;
using com.TZMS.Business.BusinessManage;

namespace TZMS.Web
{
    public partial class CustomizeBusinessList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CurrentLevel = GetCurrentLevel("dzywcj");

                dpkStartTime.SelectedDate = DateTime.Now.AddMonths(-1);
                dpkEndTime.SelectedDate = DateTime.Now;

                wndNewCustomizeBusiness.OnClientCloseButtonClick = wndNewCustomizeBusiness.GetHidePostBackReference();
                btnNewNormalBusiness.OnClientClick = wndNewCustomizeBusiness.GetShowReference("NewCustomizeBusiness.aspx?Type=Add") + "return false;";

                BindGrid();

                if (CurrentLevel == VisitLevel.View)
                {
                    btnNewNormalBusiness.Enabled = false;
                }
            }
        }

        #region 私有方法

        /// <summary>
        /// 判断某用户是否包含某特定角色
        /// </summary>
        /// <param name="strObjectID"></param>
        /// <param name="roleType"></param>
        /// <returns></returns>
        public bool ContainsRole(string strObjectID, RoleType roleType)
        {
            bool isContain = false;

            if (!string.IsNullOrEmpty(strObjectID))
            {
                RolesManage _rolesManage = new RolesManage();
                UserRoles _userRoles = _rolesManage.GetRolesByObjectID(strObjectID);
                if (_userRoles != null)
                {
                    string[] roles = _userRoles.Roles.Split(',');
                    foreach (string role in roles)
                    {
                        if (!string.IsNullOrEmpty(role))
                        {
                            if (role == ((int)roleType).ToString())
                            {
                                isContain = true;
                                break;
                            }
                        }
                    }
                }
            }

            return isContain;
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
            strCondition.Append(" IsDelete <> 1 and BusinessType = 1");
            if (!this.ContainsRole(CurrentUser.ObjectId.ToString(), RoleType.YWZJ))
            {
                strCondition.Append(" and CreaterID ='" + CurrentUser.ObjectId.ToString() + "'");
            }
            if (!string.IsNullOrEmpty(tbxSearch.Text.Trim()))
            {
                strCondition.Append(" and CompanyName Like '%" + tbxSearch.Text.Trim() + "%'");
            }

            strCondition.Append(" and State = " + Convert.ToInt32(ddlstAproveState.SelectedValue));
            strCondition.Append(" and CreateTime between '" + startTime.ToString("yyyy-MM-dd 00:00") + "' and '" + endTime.ToString("yyyy-MM-dd 23:59") + "'");

            #endregion

            List<BusinessInfo> lstApply = new BusinessManage().GetBusinessByCondition(strCondition.ToString());
            this.gridCustomizeBusiness.RecordCount = lstApply.Count;
            this.gridCustomizeBusiness.PageSize = PageCounts;
            int currentIndex = this.gridCustomizeBusiness.PageIndex;
            //计算当前页面显示行数据
            if (lstApply.Count > this.gridCustomizeBusiness.PageSize)
            {
                if (lstApply.Count > (currentIndex + 1) * this.gridCustomizeBusiness.PageSize)
                {
                    lstApply.RemoveRange((currentIndex + 1) * this.gridCustomizeBusiness.PageSize, lstApply.Count - (currentIndex + 1) * this.gridCustomizeBusiness.PageSize);
                }
                lstApply.RemoveRange(0, currentIndex * this.gridCustomizeBusiness.PageSize);
            }
            this.gridCustomizeBusiness.DataSource = lstApply;
            this.gridCustomizeBusiness.DataBind();
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
        protected void gridCustomizeBusiness_PageIndexChange(object sender, ExtAspNet.GridPageEventArgs e)
        {
            gridCustomizeBusiness.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        /// <summary>
        /// 数据行点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridCustomizeBusiness_RowCommand(object sender, ExtAspNet.GridCommandEventArgs e)
        {
            string strApplyID = ((GridRow)gridCustomizeBusiness.Rows[e.RowIndex]).Values[0];
            if (e.CommandName == "View")
            {
                wndNewCustomizeBusiness.IFrameUrl = "NewCustomizeBusiness.aspx?Type=View&ID=" + strApplyID;
                wndNewCustomizeBusiness.Hidden = false;
            }

            if (e.CommandName == "Edit")
            {
                wndNewCustomizeBusiness.IFrameUrl = "NewCustomizeBusiness.aspx?Type=Edit&ID=" + strApplyID;
                wndNewCustomizeBusiness.Hidden = false;
            }

            if (e.CommandName == "Change")
            {
                wndNewCustomizeBusiness.IFrameUrl = "NewCustomizeBusiness.aspx?Type=Change&ID=" + strApplyID;
                wndNewCustomizeBusiness.Hidden = false;
            }

            if (e.CommandName == "Delete")
            {
                BusinessManage _manage = new BusinessManage();
                BusinessInfo _info = _manage.GetBusinessByObjectID(strApplyID);
                if (_info != null)
                {
                    _info.IsDelete = true;
                    _manage.UpdateBusiness(_info);

                    BindGrid();
                }
            }
        }

        /// <summary>
        /// 数据行绑定事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridCustomizeBusiness_RowDataBound(object sender, ExtAspNet.GridRowEventArgs e)
        {
            if (e.DataItem != null)
            {
                BusinessManage _manage = new BusinessManage();
                BusinessRecordInfo _recordInfo = _manage.GetBusinessRecordByObjectID(e.Values[4].ToString());
                if (_recordInfo != null)
                {
                    e.Values[4] = _manage.ConvertBusinessTypeToString(false, _recordInfo.CurrentBusiness);
                }

                switch (e.Values[5].ToString())
                {
                    case "0":
                        e.Values[5] = "未完成";
                        e.Values[9] = "<span class=\"gray\">删除</span>";
                        if (!this.ContainsRole(CurrentUser.ObjectId.ToString(), RoleType.YWZJ))
                        {
                            e.Values[7] = "<span class=\"gray\">成本变更</span>";
                        }

                        break;
                    case "1":
                        e.Values[5] = "已完成";
                        e.Values[7] = "<span class=\"gray\">成本变更</span>";
                        e.Values[8] = "<span class=\"gray\">编辑</span>";
                        break;
                    case "2":
                        e.Values[5] = "异常终止";
                        e.Values[7] = "<span class=\"gray\">成本变更</span>";
                        break;
                    default:
                        break;
                }

                if (CurrentLevel == VisitLevel.View)
                {
                    e.Values[7] = "<span class=\"gray\">成本变更</span>";
                    e.Values[8] = "<span class=\"gray\">编辑</span>";
                    e.Values[9] = "<span class=\"gray\">删除</span>";
                }
            }
        }

        /// <summary>
        /// 创建窗口关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void wndNewCustomizeBusiness_Close(object sender, ExtAspNet.WindowCloseEventArgs e)
        {
            BindGrid();
        }

        #endregion
    }
}