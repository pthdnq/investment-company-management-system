using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.TZMS.Business;
using System.Data;
using ExtAspNet;
using System.Text;
using com.TZMS.Model;

namespace TZMS.Web
{
    public partial class MaterialsPurchaseApplyList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CurrentLevel = GetCurrentLevel("wzcgsq");

                dpkStartTime.SelectedDate = DateTime.Now.AddMonths(-1);
                dpkEndTime.SelectedDate = DateTime.Now;

                wndNewPurchaseApply.Title = "物资采购申请";
                btnNewMaterial.OnClientClick = wndNewPurchaseApply.GetShowReference("NewMaterialsPurchase.aspx?Type=Add") + "return false;";
                wndNewPurchaseApply.OnClientCloseButtonClick = wndNewPurchaseApply.GetHidePostBackReference();

                BindType();
                BindGrid();

                if (CurrentLevel == VisitLevel.View)
                {
                    btnNewMaterial.Enabled = false;
                }
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
            strCondition.Append(" IsDelete <> 1");
            strCondition.Append(" and  UserID = '" + CurrentUser.ObjectId.ToString() + "'");

            if (!string.IsNullOrEmpty(tbxSearch.Text.Trim()))
            {
                strCondition.Append(" and MaterialsName LIKE '%" + tbxSearch.Text.Trim() + "%'");
            }
            if (ddlstType.SelectedValue != "all")
            {
                strCondition.Append(" and MaterialsType = " + ddlstType.SelectedValue);
            }
            strCondition.Append(" and State = " + ddlstAproveState.SelectedValue);
            strCondition.Append(" and ApplyTime between '" + startTime.ToString("yyyy-MM-dd 00:00") + "' and '" + endTime.ToString("yyyy-MM-dd 23:59") + "'");

            #endregion

            CommSelect _commSelect = new CommSelect();
            ComHelp _comHelp = new ComHelp();
            _comHelp.TableName = "MaterialsPurchaseApplyView";
            _comHelp.SelectList = "*";
            _comHelp.SearchCondition = strCondition.ToString();
            _comHelp.PageSize = PageCounts;
            _comHelp.PageIndex = gridApply.PageIndex;
            _comHelp.OrderExpression = "ApplyTime desc";

            DataTable dtbLeaveApproves = _commSelect.ComSelect(ref _comHelp);
            gridApply.RecordCount = _comHelp.TotalCount;
            gridApply.PageSize = PageCounts;

            gridApply.DataSource = dtbLeaveApproves.Rows;
            gridApply.DataBind();
        }

        /// <summary>
        /// 绑定类型
        /// </summary>
        private void BindType()
        {
            ddlstType.Items.Add(new ExtAspNet.ListItem("全部", "all"));
            ddlstType.Items.Add(new ExtAspNet.ListItem("办公用品", "0"));
            if (CurrentRoles.Contains(RoleType.WZSQ_GD))
            {
                ddlstType.Items.Add(new ExtAspNet.ListItem("固定资产", "1"));
            }

            ddlstType.SelectedIndex = 0;
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
        protected void gridApply_PageIndexChange(object sender, ExtAspNet.GridPageEventArgs e)
        {
            gridApply.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        /// <summary>
        /// 数据行点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridApply_RowCommand(object sender, ExtAspNet.GridCommandEventArgs e)
        {
            string strApplyID = ((GridRow)gridApply.Rows[e.RowIndex]).Values[0];
            if (e.CommandName == "View")
            {
                wndNewPurchaseApply.IFrameUrl = "NewMaterialsPurchase.aspx?Type=View&ID=" + strApplyID;
                wndNewPurchaseApply.Hidden = false;
            }

            if (e.CommandName == "Edit")
            {
                wndNewPurchaseApply.IFrameUrl = "NewMaterialsPurchase.aspx?Type=Edit&ID=" + strApplyID;
                wndNewPurchaseApply.Hidden = false;
            }

            if (e.CommandName == "Delete")
            {
                MaterialsManage _manage = new MaterialsManage();
                MaterialsPurchaseApplyInfo _info = _manage.GetPurchaseApplyByObjectID(strApplyID);
                if (_info != null)
                {
                    _info.IsDelete = true;
                    _manage.UpdatePurchaseApply(_info);

                    BindGrid();
                }
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
                switch (e.Values[2].ToString())
                {
                    case "0":
                        e.Values[2] = "办公用品";
                        break;
                    case "1":
                        e.Values[2] = "固定资产";
                        break;
                    default:
                        break;
                }

                e.Values[6] = DateTime.Parse(e.Values[6].ToString()).ToString("yyyy-MM-dd");
                e.Values[8] = DateTime.Parse(e.Values[8].ToString()).ToString("yyyy-MM-dd HH:mm");
                if (e.Values[9].ToString() == SystemUser.ObjectId.ToString())
                {
                    e.Values[9] = SystemUser.Name;
                }
                else
                {
                    UserInfo _userInfo = new UserManage().GetUserByObjectID(e.Values[9].ToString());
                    if (_userInfo != null)
                    {
                        e.Values[9] = _userInfo.Name;
                    }
                }

                // 审批状态.
                switch (e.Values[10].ToString())
                {
                    case "0":
                        e.Values[10] = "审批中";
                        e.Values[12] = "<span class=\"gray\">编辑</span>";
                        e.Values[13] = "<span class=\"gray\">删除</span>";
                        break;
                    case "1":
                        e.Values[10] = "未通过";
                        break;
                    case "2":
                        e.Values[10] = "已归档";
                        e.Values[12] = "<span class=\"gray\">编辑</span>";
                        e.Values[13] = "<span class=\"gray\">删除</span>";
                        break;
                    default:
                        break;
                }

                if (CurrentLevel == VisitLevel.View)
                {
                    e.Values[12] = "<span class=\"gray\">编辑</span>";
                    e.Values[13] = "<span class=\"gray\">删除</span>";
                }
            }
        }

        /// <summary>
        /// 关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void wndNewPurchaseApply_Close(object sender, ExtAspNet.WindowCloseEventArgs e)
        {
            BindGrid();
        }

        #endregion
    }
}