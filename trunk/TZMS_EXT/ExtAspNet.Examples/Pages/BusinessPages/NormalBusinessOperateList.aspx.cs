using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExtAspNet;
using System.Text;
using com.TZMS.Business;
using System.Data;
using com.TZMS.Model;
using com.TZMS.Business.BusinessManage;

namespace TZMS.Web
{
    public partial class NormalBusinessOperateList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CurrentLevel = GetCurrentLevel("ptywcz");

                dpkStartTime.SelectedDate = DateTime.Now.AddMonths(-1);
                dpkEndTime.SelectedDate = DateTime.Now;

                wndNewNormalBusiness.OnClientCloseButtonClick = wndNewNormalBusiness.GetHidePostBackReference();
                wndNormalBusinessTransfer.OnClientCloseButtonClick = wndNormalBusinessTransfer.GetHidePostBackReference();

                BindGrid();
            }
        }

        #region 私有方法

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
            strCondition.Append(" 1 = 1");
            if (!this.ContainsRole(CurrentUser.ObjectId.ToString(), RoleType.YWZY))
            {
                strCondition.Append(" and CheckerID = '" + CurrentUser.ObjectId.ToString() + "'");
            }
            strCondition.Append(" and CurrentBusiness <> 0 and CurrentBusiness <> 13 and CurrentBusiness <> 14 and BusinessType = 0");

            // 查询文本
            if (!string.IsNullOrEmpty(tbxSearch.Text.Trim()))
            {
                strCondition.Append("  and CompanyName like '%" + tbxSearch.Text.Trim() + "%'");
            }

            // 审批状态.
            strCondition.Append(" and State = " + ddlstAproveState.SelectedValue);
            strCondition.Append(" and (CheckDateTime between '" + startTime.ToString("yyyy-MM-dd 00:00") + "' and '"
                + endTime.ToString("yyyy-MM-dd 23:59") + "' or CheckDateTime='"
                + ACommonInfo.DBMAXDate.ToString() + "')");

            #endregion

            CommSelect _commSelect = new CommSelect();
            ComHelp _comHelp = new ComHelp();
            _comHelp.TableName = "BusinessOperateView";
            _comHelp.SelectList = "*";
            _comHelp.SearchCondition = strCondition.ToString();
            _comHelp.PageSize = PageCounts;
            _comHelp.PageIndex = gridBusiness.PageIndex;
            _comHelp.OrderExpression = "CheckDateTime desc";

            DataTable dtbLeaveApproves = _commSelect.ComSelect(ref _comHelp);
            gridBusiness.RecordCount = _comHelp.TotalCount;
            gridBusiness.PageSize = PageCounts;

            gridBusiness.DataSource = dtbLeaveApproves.Rows;
            gridBusiness.DataBind();
        }

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
        protected void gridBusiness_PageIndexChange(object sender, ExtAspNet.GridPageEventArgs e)
        {
            gridBusiness.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        /// <summary>
        /// 数据行点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridBusiness_RowCommand(object sender, ExtAspNet.GridCommandEventArgs e)
        {
            string strRecordID = ((GridRow)gridBusiness.Rows[e.RowIndex]).Values[0];
            string strBusinessID = ((GridRow)gridBusiness.Rows[e.RowIndex]).Values[1];
            if (e.CommandName == "View")
            {
                //if ((((GridRow)gridBusiness.Rows[e.RowIndex]).Values[6]).Contains("办理"))
                //{
                //    if ((((GridRow)gridBusiness.Rows[e.RowIndex]).Values[6]).Contains("业务转交") &&
                //        !this.ContainsRole(CurrentUser.ObjectId.ToString(), RoleType.YWZJ))
                //    {
                //        Alert.Show("当前步骤是\"业务转交\",请移交至业务总监进行办理!");
                //        return;
                //    }
                //}
                wndNewNormalBusiness.IFrameUrl = "OperatorNormalBusiness.aspx?RecordID=" + strRecordID + "&BusinessID=" + strBusinessID;
                wndNewNormalBusiness.Hidden = false;
            }

            if (e.CommandName == "Transfer")
            {
                wndNormalBusinessTransfer.IFrameUrl = "NormalBusinessTransfer.aspx?RecordID=" + strRecordID + "&BusinessID=" + strBusinessID;
                wndNormalBusinessTransfer.Hidden = false;
            }
        }

        /// <summary>
        /// 数据行绑定事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridBusiness_RowDataBound(object sender, ExtAspNet.GridRowEventArgs e)
        {
            if (e.DataItem != null)
            {
                BusinessManage _manage = new BusinessManage();
                e.Values[3] = _manage.ConvertBusinessTypeToString(true, Convert.ToInt32(e.Values[3].ToString()));

                switch (e.Values[4].ToString())
                {
                    case "0":
                        e.Values[4] = "待办理";
                        e.Values[5] = "";

                        if (!this.ContainsRole(CurrentUser.ObjectId.ToString(), RoleType.YWZY))
                        {
                            e.Values[7] = "<span class=\"gray\">业务转移</span>";
                        }

                        if (CurrentLevel == VisitLevel.View)
                        {
                            e.Values[6] = "<span class=\"gray\">办理</span>";
                            e.Values[7] = "<span class=\"gray\">业务转移</span>";
                        }
                        break;
                    case "1":
                        e.Values[4] = "已办理";
                        e.Values[5] = DateTime.Parse(e.Values[5].ToString()).ToString("yyyy-MM-dd");
                        e.Values[6] = e.Values[6].ToString().Replace("办理", "查看");
                        e.Values[7] = "<span class=\"gray\">业务转移</span>";
                        break;
                    case "2":
                        e.Values[4] = "已转移";
                        e.Values[5] = DateTime.Parse(e.Values[5].ToString()).ToString("yyyy-MM-dd");
                        e.Values[6] = e.Values[6].ToString().Replace("办理", "查看");
                        e.Values[7] = "<span class=\"gray\">业务转移</span>";
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// 办理窗口关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void wndNewNormalBusiness_Close(object sender, ExtAspNet.WindowCloseEventArgs e)
        {
            BindGrid();
        }

        /// <summary>
        /// 转移窗口关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void wndNormalBusinessTransfer_Close(object sender, WindowCloseEventArgs e)
        {
            BindGrid();
        }

        #endregion
    }
}