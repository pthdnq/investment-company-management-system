using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.TZMS.Business;
using System.Text;
using com.TZMS.Model;
using ExtAspNet;

namespace TZMS.Web
{
    public partial class DingzhiYewu :  BasePage
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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnNewYewu.OnClientClick = wndNewYewu.GetShowReference("NewDingZhiYeWu.aspx?Type=Add") + "return false;";
                wndNewYewu.OnClientCloseButtonClick = wndNewYewu.GetHidePostBackReference();
                DataBindData();
            }
        }

        #region 私有方法

        /// <summary>
        /// 绑定列表
        /// </summary>
        private void DataBindData()
        {
            //CommSelect commSelect = new CommSelect();
            #region 查询条件

            StringBuilder strCondition = new StringBuilder();

            strCondition.Append(" Isdelete <> 1 and type = 1 ");
            strCondition.Append(" and UserID='" + this.CurrentUser.ObjectId.ToString() + "' ");
            strCondition.Append(" and state = " + ddlstAproveState.SelectedValue);

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

        #endregion

        #region 页面事件

        /// <summary>
        /// 查询事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            DataBindData();
        }

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
            string strWuZhiID = ((GridRow)gridYewu.Rows[e.RowIndex]).Values[0];
            if (e.CommandName == "View")
            {
                wndNewYewu.IFrameUrl = "NewDingZhiYeWu.aspx?Type=View&ID=" + strWuZhiID;
                wndNewYewu.Hidden = false;
            }

            if (e.CommandName == "Delete")
            {
                WuZhiManage _manage = new WuZhiManage();
                WuZhiInfo _info = _manage.GetWuZhiByObjectID(strWuZhiID);
                if (_info != null)
                {
                    _info.Isdelete = true;
                    _manage.UpdateWuZhi(_info);

                    DataBindData();
                }
            }
        }

        /// <summary>
        /// 数据行绑定事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridYewu_RowDataBound(object sender, ExtAspNet.GridRowEventArgs e)
        {
            if (e.DataItem != null)
            {
                YeWuInfo _info = (YeWuInfo)e.DataItem;

                    UserInfo _userInfo = new UserManage().GetUserByObjectID(e.Values[4].ToString());
                    if (_userInfo != null)
                    {
                        e.Values[4] = _userInfo.Name;
                    }

                // 当前操作
                switch (e.Values[5].ToString())
                {
                    case "1":
                        e.Values[5] = "名称变更";
                        break;
                    case "2":
                        e.Values[5] = "股东名称、发起人姓名变更";
                        break;
                    case "3":
                        e.Values[5] = "注册资本变更";
                        break;
                    case "4":
                        e.Values[5] = "经营场所变更";
                        break;
                    case "5":
                        e.Values[5] = "法定代表人变更";
                        break;
                    case "6":
                        e.Values[5] = "股东变更";
                        break;
                    case "7":
                        e.Values[5] = "实收资本变更";
                        break;
                    case "8":
                        e.Values[5] = "公司类型变更";
                        break;
                    case "9":
                        e.Values[5] = "营业期限变更";
                        break;
                    case "10":
                        e.Values[5] = "经营范围变更";
                        break;
                    case "11":
                        e.Values[5] = "注销登记";
                        break;
                    case "12":
                        e.Values[5] = "分公司变更";
                        break;
                    case "13":
                        e.Values[5] = "分公司注销";
                        break;
                    default:
                        break;
                }

                // 审批状态.
                switch (e.Values[6].ToString())
                {
                    case "0":
                        e.Values[6] = "未完成";

                        // 检查删除的状态.
                        {
                            YewuManage _mange = new YewuManage();
                            List<YeWuGudingDoingInfo> lstGudingDoing = _mange.GetYeWuDoingForList(" ApplyID='" + _info.ObjectId.ToString() + "' and Checkstate = 1");
                            if (lstGudingDoing.Count >= 2)
                            {
                                e.Values[8] = "<span class=\"gray\">删除</span>";
                            }
                        }
                        break;
                    case "1":
                        e.Values[9] = "已完成";
                        e.Values[8] = "<span class=\"gray\">删除</span>";
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// 创建窗口
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