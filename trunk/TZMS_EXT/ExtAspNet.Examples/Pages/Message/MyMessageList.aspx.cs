using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExtAspNet;
using System.Text;
using com.TZMS.Business;
using com.TZMS.Model;

namespace TZMS.Web.Pages
{
    public partial class MyMessageList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CurrentLevel = GetCurrentLevel("wdxx");

                dpkStartTime.SelectedDate = DateTime.Now.AddMonths(-1);
                dpkEndTime.SelectedDate = DateTime.Now;

                wndViewMessage.OnClientCloseButtonClick = wndViewMessage.GetHidePostBackReference();

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
            strCondition.Append(" IsDelete <> 1 and ReceviceID = '" + CurrentUser.ObjectId.ToString() + "'");
            strCondition.Append(" and SendDate between '" + startTime.ToString("yyyy-MM-dd 00:00") + "' and '" + endTime.ToString("yyyy-MM-dd 23:59") + "'");

            if (ddlMessageState.SelectedIndex != 0)
            {
                strCondition.Append(" and IsView = " + ddlMessageState.SelectedValue);
            }

            strCondition.Append(" order by SendDate desc");

            #endregion

            MessageManage _manage = new MessageManage();
            List<MessageInfo> lstMessage = _manage.GetMessageByCondition(strCondition.ToString());
            gridMessage.RecordCount = lstMessage.Count;
            gridMessage.PageSize = PageCounts;
            int currentIndex = gridMessage.PageIndex;

            // 计算当前页面显示行数据
            if (lstMessage.Count > gridMessage.PageSize)
            {
                if (lstMessage.Count > (currentIndex + 1) * gridMessage.PageSize)
                {
                    lstMessage.RemoveRange((currentIndex + 1) * gridMessage.PageSize, lstMessage.Count - (currentIndex + 1) * gridMessage.PageSize);
                }
                lstMessage.RemoveRange(0, currentIndex * gridMessage.PageSize);
            }
            this.gridMessage.DataSource = lstMessage;
            this.gridMessage.DataBind();
        }

        #endregion

        #region 页面事件

        /// <summary>
        /// 翻页事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridMessage_PageIndexChange(object sender, ExtAspNet.GridPageEventArgs e)
        {
            gridMessage.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        /// <summary>
        /// 数据行点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridMessage_RowCommand(object sender, ExtAspNet.GridCommandEventArgs e)
        {
            string strMessageID = ((GridRow)gridMessage.Rows[e.RowIndex]).Values[0];

            // 查看消息.
            if (e.CommandName == "View")
            {
                MessageManage _manage = new MessageManage();
                MessageInfo _info = _manage.GetMessageByObjectID(strMessageID);
                if (_info != null)
                {
                    _info.IsView = true;
                    _info.ViewDate = DateTime.Now;

                    _manage.UpdateMessage(_info);

                    wndViewMessage.Title = "查看消息";
                    wndViewMessage.IFrameUrl = "NewMessage.aspx?Type=ViewMessage&ID=" + strMessageID;
                    wndViewMessage.Hidden = false;
                }
            }

            // 删除消息
            if (e.CommandName == "Delete")
            {
                MessageManage _manage = new MessageManage();
                MessageInfo _info = _manage.GetMessageByObjectID(strMessageID);
                if (_info != null)
                {
                    _info.IsDelete = true;
                    _manage.UpdateMessage(_info);

                    BindGrid();
                }
            }
        }

        /// <summary>
        /// 数据行绑定事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridMessage_RowDataBound(object sender, ExtAspNet.GridRowEventArgs e)
        {
            if (e.DataItem != null)
            {
                e.Values[5] = DateTime.Parse(e.Values[5].ToString()).ToString("yyyy-MM-dd HH:mm");
                DateTime viewDate = DateTime.Parse(e.Values[7].ToString());
                if (DateTime.Compare(viewDate, ACommonInfo.DBEmptyDate) == 0)
                {
                    e.Values[7] = "";
                }
                else
                {
                    e.Values[7] = DateTime.Parse(e.Values[7].ToString()).ToString("yyyy-MM-dd HH:mm");
                }

                if (e.Values[6].ToString() == "False")
                {
                    e.Values[6] = "未查看";
                }
                else
                {
                    e.Values[6] = "已查看";
                }
            }
        }

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
        /// 查看窗口关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void wndViewMessage_Close(object sender, WindowCloseEventArgs e)
        {
            BindGrid();
        }

        #endregion
    }
}