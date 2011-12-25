using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using ExtAspNet;
using com.TZMS.Model;
using com.TZMS.Business;

namespace TZMS.Web
{
    public partial class UserLeaveTransferToFile : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CurrentLevel = GetCurrentLevel("lzjjgd");

                dpkStartTime.SelectedDate = DateTime.Now.AddMonths(-1);
                dpkEndTime.SelectedDate = DateTime.Now;

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
            DateTime startTime = Convert.ToDateTime(dpkStartTime.SelectedDate);
            DateTime endTime = Convert.ToDateTime(dpkEndTime.SelectedDate);

            if (DateTime.Compare(startTime, endTime) == 1)
            {
                Alert.Show("结束日期不可小于开始日期!");
                return;
            }

            #region 查询出条件

            StringBuilder strCondition = new StringBuilder();
            strCondition.Append(" TransferID = '" + CurrentUser.ObjectId.ToString() + "'");

            // 归档状态.
            if (ddlstArchiveState.SelectedIndex == 0)
            {
                strCondition.Append(" and IsTransfer = 0");
            }
            else
            {
                strCondition.Append(" and IsTransfer = 1");
            }

            // 时间范围.
            strCondition.Append(" and (TransferTime between '" + startTime.ToString("yyyy-MM-dd 00:00") + "' and '"
                + endTime.ToString("yyyy-MM-dd 23:59") + "' or TransferTime='" + ACommonInfo.DBMAXDate.ToString() + "')");

            #endregion

            UserLeaveManage _manage = new UserLeaveManage();
            List<UserLeaveTransferInfo> lstApprove = _manage.GetTransferByCondition(strCondition.ToString());
            gridArchiver.RecordCount = lstApprove.Count;
            gridArchiver.PageSize = PageCounts;
            int currentIndex = gridArchiver.PageIndex;

            // 计算当前页面显示行数据
            if (lstApprove.Count > gridArchiver.PageSize)
            {
                if (lstApprove.Count > (currentIndex + 1) * gridArchiver.PageSize)
                {
                    lstApprove.RemoveRange((currentIndex + 1) * gridArchiver.PageSize, lstApprove.Count - (currentIndex + 1) * gridArchiver.PageSize);
                }
                lstApprove.RemoveRange(0, currentIndex * gridArchiver.PageSize);
            }
            this.gridArchiver.DataSource = lstApprove;
            this.gridArchiver.DataBind();

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
        protected void gridArchiver_PageIndexChange(object sender, ExtAspNet.GridPageEventArgs e)
        {
            gridArchiver.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        /// <summary>
        /// 数据行点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridArchiver_RowCommand(object sender, ExtAspNet.GridCommandEventArgs e)
        {
            string strTransferID = ((GridRow)gridArchiver.Rows[e.RowIndex]).Values[0];
            string strApplyID = ((GridRow)gridArchiver.Rows[e.RowIndex]).Values[1];
            if (e.CommandName == "Archive")
            {
                UserLeaveManage _manage = new UserLeaveManage();
                UserManage _userManage = new UserManage();
                UserLeaveTransferInfo _transferInfo = _manage.GetTransferByObjectID(strTransferID);
                UserLeaveApplyInfo _applyInfo = _manage.GetApplyByObjectID(strApplyID);
                if (_transferInfo != null && _applyInfo != null)
                {
                    _transferInfo.TransferTime = DateTime.Now;
                    _transferInfo.IsTransfer = true;
                    _manage.UpdateTransfer(_transferInfo);

                    _applyInfo.TransferState = 1;
                    _manage.UpdateApply(_applyInfo);

                    UserInfo _leaveUser = _userManage.GetUserByObjectID(_applyInfo.UserID.ToString());
                    if (_leaveUser != null)
                    {
                        _leaveUser.State = 0;
                        _leaveUser.LeaveTime = _applyInfo.LeaveDate;

                        _userManage.UpdateUser(_leaveUser);
                    }
                }

                BindGrid();
            }
        }

        /// <summary>
        /// 数据行绑定事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridArchiver_RowDataBound(object sender, ExtAspNet.GridRowEventArgs e)
        {
            if (e.DataItem != null)
            {
                UserLeaveTransferInfo _transferInfo = (UserLeaveTransferInfo)e.DataItem;
                UserLeaveApplyInfo _applyInfo = new UserLeaveManage().GetApplyByObjectID(_transferInfo.ApplyID.ToString());
                if (_applyInfo != null)
                {
                    e.Values[0] = _transferInfo.ObjectID.ToString();
                    e.Values[1] = _applyInfo.ObjectID.ToString();
                    e.Values[2] = _applyInfo.UserName;
                    e.Values[3] = _applyInfo.ApplyTime.ToString("yyyy-MM-dd HH:mm");
                    e.Values[4] = _applyInfo.ContractStartDate.ToString("yyyy-MM-dd");
                    e.Values[5] = _applyInfo.ContractEndDate.ToString("yyyy-MM-dd");
                    e.Values[6] = _applyInfo.LeaveDate.ToString("yyyy-MM-dd");
                    e.Values[7] = "<span  ext:qtip=\"" + _applyInfo.LeaveSeason + "\">" + _applyInfo.LeaveSeason + "</span>";
                    switch (_applyInfo.TransferState)
                    {
                        case 0:
                            e.Values[8] = "待归档";
                            break;
                        case 1:
                            e.Values[8] = "已归档";
                            e.Values[9] = "<span class=\"gray\">归档</span>";
                            break;
                        default:
                            e.Values[8] = "";
                            break;
                    }
                }

                if (CurrentLevel == VisitLevel.View)
                {
                    e.Values[9] = "<span class=\"gray\">归档</span>";
                }
            }
        }

        #endregion
    }
}