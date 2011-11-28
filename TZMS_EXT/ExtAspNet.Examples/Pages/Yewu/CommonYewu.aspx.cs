using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TZMS.Web
{
    public partial class CommonYewu : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region Grid
        /// <summary>
        /// 翻页事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridYewu_PageIndexChange(object sender, ExtAspNet.GridPageEventArgs e)
        {
            //gridWuZhi.PageIndex = e.NewPageIndex;
            //BindGrid();
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
            //if (e.DataItem != null)
            //{
            //    e.Values[1] = e.Values[1].ToString() == "0" ? "办公用品" : "固定资产";
            //    e.Values[5] = DateTime.Parse(e.Values[5].ToString()).ToString("yyyy-MM-dd HH:mm");
            //    // 当前审批人.
            //    if (e.Values[6].ToString() == SystemUser.ObjectId.ToString())
            //    {
            //        e.Values[6] = SystemUser.Name;
            //    }
            //    else
            //    {
            //        UserInfo _userInfo = new UserManage().GetUserByObjectID(e.Values[6].ToString());
            //        if (_userInfo != null)
            //        {
            //            e.Values[6] = _userInfo.Name;
            //        }
            //    }
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
            //}
        }

        /// <summary>
        /// 申请窗口关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void wndNewYewu_Close(object sender, ExtAspNet.WindowCloseEventArgs e)
        {
            //BindGrid();
        }
        #endregion
    }
}