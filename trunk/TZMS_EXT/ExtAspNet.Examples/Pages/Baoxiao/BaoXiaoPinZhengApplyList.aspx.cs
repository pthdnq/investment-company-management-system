using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExtAspNet;
using System.Text;
using com.TZMS.Model;
using com.TZMS.Business;

namespace TZMS.Web
{
    public partial class BaoXiaoPinZhengApplyList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dpkStartTime.SelectedDate = DateTime.Now.AddMonths(-1);
                dpkEndTime.SelectedDate = DateTime.Now;

                wndPinZheng.OnClientCloseButtonClick = wndPinZheng.GetHidePostBackReference();

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

            strCondition.Append(" IsDelete <> 1");

            if (ddlState.SelectedIndex == 0)
            {
                strCondition.Append(" and State = -1 ");
            }
            else
            {
                strCondition.Append(" and UserID ='" + CurrentUser.ObjectId.ToString() + "'");
                strCondition.Append(" and State = " + Convert.ToInt32(ddlState.SelectedValue));
            }

            strCondition.Append(" and (ApplyTime between '" + startTime.ToString("yyyy-MM-dd 00:00")
                + "' and '" + endTime.ToString("yyyy-MM-dd 23:59")
                + "' or ApplyTime = '" + ACommonInfo.DBMAXDate.ToString() + "')");

            #endregion

            List<BaoXiaoPinZhengApplyInfo> lstApply = new BaoxiaoManage().GetPinZhengApplyByCondition(strCondition.ToString());
            this.gridBaoxiao.RecordCount = lstApply.Count;
            this.gridBaoxiao.PageSize = PageCounts;
            int currentIndex = this.gridBaoxiao.PageIndex;
            //计算当前页面显示行数据
            if (lstApply.Count > this.gridBaoxiao.PageSize)
            {
                if (lstApply.Count > (currentIndex + 1) * this.gridBaoxiao.PageSize)
                {
                    lstApply.RemoveRange((currentIndex + 1) * this.gridBaoxiao.PageSize, lstApply.Count - (currentIndex + 1) * this.gridBaoxiao.PageSize);
                }
                lstApply.RemoveRange(0, currentIndex * this.gridBaoxiao.PageSize);
            }
            this.gridBaoxiao.DataSource = lstApply;
            this.gridBaoxiao.DataBind();
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
        protected void gridBaoxiao_PageIndexChange(object sender, ExtAspNet.GridPageEventArgs e)
        {
            gridBaoxiao.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        /// <summary>
        /// 数据行点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridBaoxiao_RowCommand(object sender, ExtAspNet.GridCommandEventArgs e)
        {
            string strApplyID = ((GridRow)gridBaoxiao.Rows[e.RowIndex]).Values[0];
            if (e.CommandName == "PinZheng")
            {
                wndPinZheng.Title = "创建报销凭证";
                wndPinZheng.IFrameUrl = "BaoXiaoPinZhengApply.aspx?Type=Add&ID=" + strApplyID;
                wndPinZheng.Hidden = false;
            }

            if (e.CommandName == "View")
            {
                wndPinZheng.Title = "查看报销凭证";
                wndPinZheng.IFrameUrl = "BaoXiaoPinZhengApply.aspx?Type=View&ID=" + strApplyID;
                wndPinZheng.Hidden = false;
            }

            if (e.CommandName == "Edit")
            {
                wndPinZheng.Title = "编辑报销凭证";
                wndPinZheng.IFrameUrl = "BaoXiaoPinZhengApply.aspx?Type=Edit&ID=" + strApplyID;
                wndPinZheng.Hidden = false;
            }

            if (e.CommandName == "Delete")
            {
                BaoxiaoManage _manage = new BaoxiaoManage();
                BaoXiaoPinZhengApplyInfo _applyInfo = _manage.GetPinZhengApplyByObjectID(strApplyID);
                if (_applyInfo != null)
                {
                    _applyInfo.IsDelete = true;
                    _manage.UpdatePinZhengApply(_applyInfo);
                }

                BindGrid();
            }
        }

        /// <summary>
        /// 数据行绑定事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridBaoxiao_RowDataBound(object sender, ExtAspNet.GridRowEventArgs e)
        {
            if (e.DataItem != null)
            {
                e.Values[4] = DateTime.Parse(e.Values[4].ToString()).ToString("yyyy-MM-dd HH:mm");

                UserManage _userManage = new UserManage();
                UserInfo _approveUser = _userManage.GetUserByObjectID(e.Values[5].ToString());
                if (_approveUser != null)
                {
                    e.Values[5] = _approveUser.Name;
                }

                switch (e.Values[6].ToString())
                {
                    case "-1":
                        e.Values[3] = "";
                        e.Values[4] = "";
                        e.Values[5] = "";
                        e.Values[6] = "待创建";
                        e.Values[8] = "<span class=\"gray\">查看</span>";
                        e.Values[9] = "<span class=\"gray\">编辑</span>";
                        e.Values[10] = "<span class=\"gray\">删除</span>";
                        break;
                    case "0":
                        e.Values[6] = "审批中";
                        e.Values[7] = "<span class=\"gray\">创建凭证</span>";
                        e.Values[9] = "<span class=\"gray\">编辑</span>";
                        e.Values[10] = "<span class=\"gray\">删除</span>";
                        break;
                    case "1":
                        e.Values[6] = "未通过";
                        e.Values[7] = "<span class=\"gray\">创建凭证</span>";
                        break;
                    case "2":
                        e.Values[6] = "归档";
                        e.Values[7] = "<span class=\"gray\">创建凭证</span>";
                        e.Values[9] = "<span class=\"gray\">编辑</span>";
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// 凭证窗口关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void wndPinZheng_Close(object sender, ExtAspNet.WindowCloseEventArgs e)
        {
            BindGrid();
        }

        #endregion
    }
}