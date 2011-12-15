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

namespace TZMS.Web
{
    public partial class ImprestApplyList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dpkStartTime.SelectedDate = DateTime.Now.AddMonths(-1);
                dpkEndTime.SelectedDate = DateTime.Now;

                wndNewImprest.Title = "备用金申请";
                btnNewImprest.OnClientClick = wndNewImprest.GetShowReference("ImprestApply.aspx?Type=Add") + "return false;";
                wndNewImprest.OnClientCloseButtonClick = wndNewImprest.GetHidePostBackReference();

                BindGrid();
            }
        }

        #region 私有方法

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
            strCondition.Append(" and UserID ='" + CurrentUser.ObjectId.ToString() + "'");
            if (!string.IsNullOrEmpty(tbxSearch.Text.Trim()))
            {
                strCondition.Append(" and Title Like '%" + tbxSearch.Text.Trim() + "%'");
            }

            strCondition.Append(" and State = " + Convert.ToInt32(ddlstAproveState.SelectedValue));
            strCondition.Append(" and ApplyTime between '" + startTime.ToString("yyyy-MM-dd 00:00") + "' and '" + endTime.ToString("yyyy-MM-dd 23:59") + "'");

            #endregion

            CommSelect _commSelect = new CommSelect();
            ComHelp _comHelp = new ComHelp();
            _comHelp.TableName = "ImprestApplyView";
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
                wndNewImprest.IFrameUrl = "ImprestApply.aspx?Type=View&ID=" + strApplyID;
                wndNewImprest.Hidden = false;
            }

            if (e.CommandName == "Edit")
            {
                wndNewImprest.IFrameUrl = "ImprestApply.aspx?Type=Edit&ID=" + strApplyID;
                wndNewImprest.Hidden = false;
            }

            if (e.CommandName == "Delete")
            {
                YewuManage _manage = new YewuManage();
                ImprestApplyInfo _info = _manage.GetImprestApplyByObjectID(strApplyID);
                if (_info != null)
                {
                    _info.IsDelete = true;
                    _manage.UpdateImprestApply(_info);

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
                e.Values[2] = DateTime.Parse(e.Values[2].ToString()).ToString("yyyy-MM-dd HH:mm");
                // 当前审批人.
                if (e.Values[6].ToString() == SystemUser.ObjectId.ToString())
                {
                    e.Values[6] = SystemUser.Name;
                }
                else
                {
                    UserInfo _userInfo = new UserManage().GetUserByObjectID(e.Values[6].ToString());
                    if (_userInfo != null)
                    {
                        e.Values[6] = _userInfo.Name;
                    }
                }

                // 审批状态.
                switch (e.Values[7].ToString())
                {
                    case "0":
                        e.Values[7] = "审批中";
                        e.Values[9] = "<span class=\"gray\">编辑</span>";
                        e.Values[10] = "<span class=\"gray\">删除</span>";
                        break;
                    case "1":
                        e.Values[7] = "未通过";
                        break;
                    case "2":
                        e.Values[7] = "归档";
                        e.Values[9] = "<span class=\"gray\">编辑</span>";
                        e.Values[10] = "<span class=\"gray\">删除</span>";
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// 申请窗口关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void wndNewImprest_Close(object sender, ExtAspNet.WindowCloseEventArgs e)
        {
            BindGrid();
        }

        #endregion
    }
}