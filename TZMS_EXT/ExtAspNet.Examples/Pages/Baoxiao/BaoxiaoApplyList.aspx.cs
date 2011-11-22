using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using com.TZMS.Business;
using System.Data;
using ExtAspNet;
using com.TZMS.Model;

namespace TZMS.Web
{
    public partial class BaoxiaoApplyList : BasePage
    {
        /// <summary>
        /// 报销申请单状态
        /// </summary>
        public int BaoxiaoState
        {
            get
            {
                if (ViewState["BaoxiaoState"] == null)
                {
                    return 0;
                }

                return Convert.ToInt32(ViewState["BaoxiaoState"].ToString());
            }
            set
            {
                ViewState["BaoxiaoState"] = value;
            }
        }

        /// <summary>
        /// 日期范围
        /// </summary>
        public int DateRange
        {
            get
            {
                if (ViewState["DateRange"] == null)
                {
                    return 1;
                }
                return Convert.ToInt32(ViewState["DateRange"].ToString());
            }
            set
            {
                ViewState["DateRange"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // 设定默认时间
                dpkStartTime.SelectedDate = DateTime.Now.AddMonths(-1);
                dpkEndTime.SelectedDate = DateTime.Now;

                //报销申请按钮.
                wndBaoxiao.Title = "新建报销申请单";
                btnNewBaoxiao.OnClientClick = wndBaoxiao.GetShowReference("NewBaoxiaoApply.aspx?Type=Add") + "return false;";
                wndBaoxiao.OnClientCloseButtonClick = wndBaoxiao.GetHidePostBackReference();

                // 获取默认值.
                //BaoxiaoState = Convert.ToInt32(ddlState.SelectedValue);
                //DateRange = Convert.ToInt32(ddldateRange.SelectedValue);

                // 绑定数据到列表.
                BindGrid(Convert.ToInt32(ddlState.SelectedValue), 0);
            }
        }

        /// <summary>
        /// 绑定报销申请单列表
        /// </summary>
        /// <param name="nState">申请单状态</param>
        /// <param name="nDateRange">时间范围</param>
        private void BindGrid(int nState, int nDateRange)
        {
            #region 查询条件

            StringBuilder strCondition = new StringBuilder();
            strCondition.Append(" UserID ='" + CurrentUser.ObjectId.ToString() + "'");
            strCondition.Append(" and Isdelete <> 1");

            // 申请状态.
            switch (nState)
            {
                case 0:
                    strCondition.Append(" and state = 0");
                    break;
                case 1:
                    strCondition.Append(" and state = 1");
                    break;
                case 2:
                    strCondition.Append(" and state = 2");
                    break;
                default:
                    break;
            }

            //// 申请时间.
            //DateTime dateTimeNow = DateTime.Now;
            //switch (nDateRange)
            //{
            //    case 1:
            //        strCondition.Append(" and ApplyTime >= '" + dateTimeNow.AddMonths(-1).ToString("yyyy-MM-dd") + "'");
            //        break;
            //    case 2:
            //        strCondition.Append(" and ApplyTime >= '" + dateTimeNow.AddMonths(-3).ToString("yyyy-MM-dd") + "'");
            //        break;
            //    case 3:
            //        strCondition.Append(" and ApplyTime >= '" + dateTimeNow.AddMonths(-6).ToString("yyyy-MM-dd") + "'");
            //        break;
            //    case 4:
            //        strCondition.Append(" and ApplyTime >= '" + dateTimeNow.AddMonths(-12).ToString("yyyy-MM-dd") + "'");
            //        break;
            //    default:
            //        break;
            //}

            DateTime startTime = Convert.ToDateTime(dpkStartTime.SelectedDate);
            DateTime endTime = Convert.ToDateTime(dpkEndTime.SelectedDate);

            if (DateTime.Compare(startTime, endTime) == 1)
            {
                Alert.Show("结束日期不可小于开始日期!");
                return;
            }

            strCondition.Append(" and ApplyTime between '" + startTime.ToString("yyyy-MM-dd 00:00") + "' and '" + endTime.ToString("yyyy-MM-dd 23:59") + "'");
            strCondition.Append(" order by ApplyTime desc");
            #endregion

            //获得员工
            List<BaoxiaoInfo> lstBaoxiaoInfo = new BaoxiaoManage().GetBaoxiaoByCondition(strCondition.ToString());
            this.gridBaoxiao.RecordCount = lstBaoxiaoInfo.Count;
            this.gridBaoxiao.PageSize = PageCounts;
            int currentIndex = this.gridBaoxiao.PageIndex;
            //计算当前页面显示行数据
            if (lstBaoxiaoInfo.Count > this.gridBaoxiao.PageSize)
            {
                if (lstBaoxiaoInfo.Count > (currentIndex + 1) * this.gridBaoxiao.PageSize)
                {
                    lstBaoxiaoInfo.RemoveRange((currentIndex + 1) * this.gridBaoxiao.PageSize, lstBaoxiaoInfo.Count - (currentIndex + 1) * this.gridBaoxiao.PageSize);
                }
                lstBaoxiaoInfo.RemoveRange(0, currentIndex * this.gridBaoxiao.PageSize);
            }
            this.gridBaoxiao.DataSource = lstBaoxiaoInfo;
            this.gridBaoxiao.DataBind();

            //CommSelect _commSelect = new CommSelect();
            //ComHelp _comHelp = new ComHelp();
            //_comHelp.TableName = "BaoXiaoView";
            //_comHelp.SelectList = "*";
            //_comHelp.SearchCondition = strCondition.ToString();
            //_comHelp.PageSize = PageCounts;
            //_comHelp.PageIndex = gridBaoxiao.PageIndex;
            //_comHelp.OrderExpression = "ApplyTime desc";

            //DataTable dtbBaoxiao = _commSelect.ComSelect(ref _comHelp);
            //gridBaoxiao.RecordCount = _comHelp.TotalCount;
            //gridBaoxiao.PageSize = PageCounts;

            //gridBaoxiao.DataSource = dtbBaoxiao.Rows;
            //gridBaoxiao.DataBind();
        }

        /// <summary>
        /// 报销列表翻页事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridBaoxiao_PageIndexChange(object sender, ExtAspNet.GridPageEventArgs e)
        {
            gridBaoxiao.PageIndex = e.NewPageIndex;
            BindGrid(Convert.ToInt32(ddlState.SelectedValue), 0);
        }

        /// <summary>
        /// 报销列表数据行操作事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridBaoxiao_RowCommand(object sender, ExtAspNet.GridCommandEventArgs e)
        {
            string strBaoxiaoID = ((GridRow)gridBaoxiao.Rows[e.RowIndex]).Values[0];
            if (e.CommandName == "View")
            {
                wndBaoxiao.IFrameUrl = "NewBaoxiaoApply.aspx?Type=View&ID=" + strBaoxiaoID;
                wndBaoxiao.Hidden = false;
            }

            if (e.CommandName == "Edit")
            {
                wndBaoxiao.IFrameUrl = "NewBaoxiaoApply.aspx?Type=Edit&ID=" + strBaoxiaoID;
                wndBaoxiao.Hidden = false;
            }

            if (e.CommandName == "Delete")
            {
                BaoxiaoManage _manage = new BaoxiaoManage();
                BaoxiaoInfo _info = _manage.GetBaoxiaoByObjectID(strBaoxiaoID);
                if (_info != null)
                {
                    _info.Isdelete = true;
                    _manage.UpdateBaoxiao(_info);

                    BindGrid(BaoxiaoState, DateRange);
                }

            }
        }

        /// <summary>
        /// 报销列表数据行绑定事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridBaoxiao_RowDataBound(object sender, ExtAspNet.GridRowEventArgs e)
        {
            if (e.DataItem != null)
            {
                // 申请时间.
                e.Values[2] = DateTime.Parse(e.Values[2].ToString()).ToString("yyyy-MM-dd HH:mm");
                e.Values[3] = DateTime.Parse(e.Values[3].ToString()).ToString("yyyy-MM-dd");
                e.Values[4] = DateTime.Parse(e.Values[4].ToString()).ToString("yyyy-MM-dd");

                // 当前审批人.
                if (e.Values[1].ToString() == SystemUser.ObjectId.ToString())
                {
                    e.Values[8] = SystemUser.Name;
                }
                else
                {
                    UserInfo _userInfo = new UserManage().GetUserByObjectID(e.Values[1].ToString());
                    if (_userInfo != null)
                    {
                        e.Values[8] = _userInfo.Name;
                    }
                }

                // 审批状态.
                switch (e.Values[9].ToString())
                {
                    case "0":
                        e.Values[9] = "审批中";
                        e.Values[11] = "<span class=\"gray\">编辑</span>";
                        e.Values[12] = "<span class=\"gray\">删除</span>";
                        break;
                    case "1":
                        e.Values[9] = "被打回";
                        break;
                    case "2":
                        e.Values[9] = "归档";
                        e.Values[11] = "<span class=\"gray\">编辑</span>";
                        e.Values[12] = "<span class=\"gray\">删除</span>";
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// 报销申请窗口关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void wndBaoxiao_Close(object sender, ExtAspNet.WindowCloseEventArgs e)
        {
            BindGrid(Convert.ToInt32(ddlState.SelectedValue), 0);
        }

        /// <summary>
        /// 查询事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (DateTime.Compare(Convert.ToDateTime(dpkStartTime.SelectedDate), Convert.ToDateTime(dpkEndTime.SelectedDate)) == 1)
            {
                Alert.Show("结束日期不可小于开始日期!");
                return;
            }

            BindGrid(Convert.ToInt32(ddlState.SelectedValue), 0);
        }
    }
}