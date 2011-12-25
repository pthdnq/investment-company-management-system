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
    public partial class SentMessage : BasePage
    {
        /// <summary>
        /// 页面权限模式（可查看，可编辑）
        /// </summary>
        private VisitLevel PageModel
        {
            get
            {
                if (ViewState["VisitLevel"] == null)
                {
                    ViewState["VisitLevel"] = GetCurrentLevel("yfxx");
                }
                return (VisitLevel)ViewState["VisitLevel"];
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // 设置时间控件的默认时间.
                dpkStartTime.SelectedDate = DateTime.Now.AddMonths(-1);
                dpkEndTime.SelectedDate = DateTime.Now;

                // 设置窗口事件.
                wndNewMessage.Title = "发送消息";
                btnNewMessage.OnClientClick = wndNewMessage.GetShowReference("NewMessage.aspx?Type=Add") + "return false;";
                wndNewMessage.OnClientCloseButtonClick = wndNewMessage.GetHidePostBackReference();

                wndViewMessage.OnClientCloseButtonClick = wndViewMessage.GetHideReference();

                // 绑定列表.
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
            strCondition.Append(" IsDelete <> 1 and SenderID = '" + CurrentUser.ObjectId.ToString() + "'");
            strCondition.Append(" and SendDate between '" + startTime.ToString("yyyy-MM-dd 00:00") + "' and '" + endTime.ToString("yyyy-MM-dd 23:59") + "'");
            strCondition.Append(" order by SendDate desc");

            #endregion

            MessageManage _manage = new MessageManage();
            List<SentMessageInfo> lstSentMessage = _manage.GetSentMessageByCondition(strCondition.ToString());
            gridMessage.RecordCount = lstSentMessage.Count;
            gridMessage.PageSize = PageCounts;
            int currentIndex = gridMessage.PageIndex;

            // 计算当前页面显示行数据
            if (lstSentMessage.Count > gridMessage.PageSize)
            {
                if (lstSentMessage.Count > (currentIndex + 1) * gridMessage.PageSize)
                {
                    lstSentMessage.RemoveRange((currentIndex + 1) * gridMessage.PageSize, lstSentMessage.Count - (currentIndex + 1) * gridMessage.PageSize);
                }
                lstSentMessage.RemoveRange(0, currentIndex * gridMessage.PageSize);
            }
            this.gridMessage.DataSource = lstSentMessage;
            this.gridMessage.DataBind();
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
            string strObjectID = ((GridRow)gridMessage.Rows[e.RowIndex]).Values[0];
            MessageManage _manage = new MessageManage();
            if (e.CommandName == "View")
            {
                wndViewMessage.IFrameUrl = "NewMessage.aspx?Type=ViewSentMessage&ID=" + strObjectID;
                wndViewMessage.Hidden = false;
            }

            if (e.CommandName == "Delete")
            {
                // 删除消息.
                SentMessageInfo _info = _manage.GetSentMessageByObjectID(strObjectID);
                if (_info != null)
                {
                    _info.IsDelete = true;
                    _manage.UpdateSentMessage(_info);

                    // 绑定列表.
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
                SentMessageInfo _info = (SentMessageInfo)e.DataItem;

                if (!string.IsNullOrEmpty(_info.Recevicer))
                {
                    string[] arrayRecevicers = _info.Recevicer.Split('|');
                    string strRecevicers = string.Empty;
                    for (int i = 0; i < arrayRecevicers.Length; i++)
                    {
                        if (i != 0)
                        {
                            strRecevicers += ("," + arrayRecevicers[i].Split(',')[1]);
                        }
                        else
                        {
                            strRecevicers += arrayRecevicers[i].Split(',')[1];
                        }
                    }
                    e.Values[1] = "<span  ext:qtip=\"" + strRecevicers + "\">" + strRecevicers + "</span>";
                }

                e.Values[4] = DateTime.Parse(e.Values[4].ToString()).ToString("yyyy-MM-dd HH:mm");
                if (PageModel != VisitLevel.Edit && PageModel != VisitLevel.Both)
                {
                    e.Values[6] = "<span class=\"gray\">删除</span>";
                }
            }
        }

        /// <summary>
        /// 发送消息窗口关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void wndNewMessage_Close(object sender, ExtAspNet.WindowCloseEventArgs e)
        {
            BindGrid();
        }

        #endregion
    }
}