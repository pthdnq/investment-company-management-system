using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExtAspNet;
using System.Text;
using com.TZMS.Business;
using com.TZMS.Model;

namespace TZMS.Web
{
    public partial class CommonYewu : BasePage
    {
        /// <summary>
        /// 查询Help
        /// </summary>
        public ComHelp SearchHelp
        {
            get
            {
                if (ViewState["SearchHelp%"] != null)
                {
                    return (ComHelp)ViewState["SearchHelp%"];
                }
                return new ComHelp();
            }
            set
            {
                ViewState["SearchHelp%"] = value;
            }
        }

        /// <summary>
        /// 页面加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnNewYewu.OnClientClick = wndNewYewu.GetShowReference("NewCommonYeWu.aspx") + "return false;";
                DataBindData();
            }
        }

        /// <summary>
        /// 绑定列表
        /// </summary>
        private void DataBindData()
        {
            //CommSelect commSelect = new CommSelect();
            #region 查询条件

            StringBuilder strCondition = new StringBuilder();

            strCondition.Append(" Isdelete <> 1 and state=0 ");
            strCondition.Append(" and UserID='"+this.CurrentUser.ObjectId.ToString()+"' ");
            if (!string.IsNullOrEmpty(tbxSearch.Text.Trim()))
            {
                strCondition.Append(" and Title Like '%" + tbxSearch.Text.Trim() + "%'");
            }
           
            #endregion

            List<YeWuInfo> lstYewu = new YewuManage().GetYeWuForList(strCondition.ToString());
            this.gridYewu.RecordCount = lstYewu.Count;
            this.gridYewu.PageSize = PageCounts;
            int currentIndex = this.gridYewu.PageIndex;
            //计算当前页面显示行数据
            if (lstYewu.Count > this.gridYewu.PageSize)
            {
                if (lstYewu.Count > (currentIndex + 1) * this.gridYewu.PageSize)
                {
                    lstYewu.RemoveRange((currentIndex + 1) * this.gridYewu.PageSize, lstYewu.Count - (currentIndex + 1) * this.gridYewu.PageSize);
                }
                lstYewu.RemoveRange(0, currentIndex * this.gridYewu.PageSize);
            }
            this.gridYewu.DataSource = lstYewu;
            this.gridYewu.DataBind();
        }

        #region Grid
        /// <summary>
        /// 翻页事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridYewu_PageIndexChange(object sender, ExtAspNet.GridPageEventArgs e)
        {
            gridYewu.PageIndex = e.NewPageIndex;
            DataBindData();
        }

        /// <summary>
        /// 数据行点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridYewu_RowCommand(object sender, ExtAspNet.GridCommandEventArgs e)
        {
            //string strWuZhiID = ((GridRow)gridWuZhi.Rows[e.RowIndex]).Values[0];
            //if (e.CommandName == "View")
            //{
            //    wndNewWuZhi.IFrameUrl = "WuZhiApplyNew.aspx?Type=View&ID=" + strWuZhiID;
            //    wndNewWuZhi.Hidden = false;
            //}

            //if (e.CommandName == "Edit")
            //{
            //    wndNewWuZhi.IFrameUrl = "WuZhiApplyNew.aspx?Type=Edit&ID=" + strWuZhiID;
            //    wndNewWuZhi.Hidden = false;
            //}

            //if (e.CommandName == "Delete")
            //{
            //    WuZhiManage _manage = new WuZhiManage();
            //    WuZhiInfo _info = _manage.GetWuZhiByObjectID(strWuZhiID);
            //    if (_info != null)
            //    {
            //        _info.Isdelete = true;
            //        _manage.UpdateWuZhi(_info);

            //        BindGrid();
            //    }
            //}
        }

        /// <summary>
        /// 数据行绑定事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridYewu_RowDataBound(object sender, ExtAspNet.GridRowEventArgs e)
        {
            return;
            if (e.DataItem != null)
            {
            //    e.Values[1] = e.Values[1].ToString() == "0" ? "办公用品" : "固定资产";
            //    e.Values[5] = DateTime.Parse(e.Values[5].ToString()).ToString("yyyy-MM-dd HH:mm");
            //    // 当前审批人.
              if (e.Values[3].ToString() == SystemUser.ObjectId.ToString())
              {
                  e.Values[3] = SystemUser.Name;
              }
              else
              {
                  UserInfo _userInfo = new UserManage().GetUserByObjectID(e.Values[3].ToString());
                  if (_userInfo != null)
                  {
                      e.Values[3] = _userInfo.Name;
                  }
              }
            //    // 审批状态.
            //    switch (e.Values[7].ToString())
            //    {
            //        case "0":
            //            e.Values[7] = "审批中";
            //            e.Values[9] = "<span class=\"gray\">编辑</span>";
            //            e.Values[10] = "<span class=\"gray\">删除</span>";
            //            break;
            //        case "1":
            //            e.Values[7] = "未通过";
            //            break;
            //        case "2":
            //            e.Values[7] = "归档";
            //            e.Values[9] = "<span class=\"gray\">编辑</span>";
            //            e.Values[10] = "<span class=\"gray\">删除</span>";
            //            break;
            //        default:
            //            break;
            //    }
            }
        }

        /// <summary>
        /// 申请窗口关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void wndNewYewu_Close(object sender, ExtAspNet.WindowCloseEventArgs e)
        {
            DataBindData();
        }
        #endregion
    }
}