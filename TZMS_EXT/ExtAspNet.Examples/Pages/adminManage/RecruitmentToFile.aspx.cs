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
    public partial class RecruitmentToFile : BasePage
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
                    ViewState["VisitLevel"] = GetCurrentLevel("zpsqgd");
                }
                return (VisitLevel)ViewState["VisitLevel"];
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
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
            strCondition.Append(" ApproverID = '" + CurrentUser.ObjectId.ToString() + "'");

            // 归档状态.
            if (ddlstArchiveState.SelectedIndex == 0)
            {
                strCondition.Append(" and ApproveOp = 3");
            }
            else
            {
                strCondition.Append(" and ApproveOp = 4");
            }

            // 时间范围.
            strCondition.Append(" and (ApproveTime between '" + startTime.ToString("yyyy-MM-dd 00:00") + "' and '"
                + endTime.ToString("yyyy-MM-dd 23:59") + "' or ApproveTime='" + ACommonInfo.DBMAXDate.ToString() + "')");

            #endregion

            RecruitmentManage _manage = new RecruitmentManage();
            List<RecruitmentApproveInfo> lstApprove = _manage.GetApproveByCondition(strCondition.ToString());
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
            string strApproveID = ((GridRow)gridArchiver.Rows[e.RowIndex]).Values[0];
            string strApproveResult = ((GridRow)gridArchiver.Rows[e.RowIndex]).Values[8];
            if (!string.IsNullOrEmpty(strApproveID))
            {
                RecruitmentManage _manage = new RecruitmentManage();
                RecruitmentApproveInfo _approveInfo = _manage.GetApproveByObjectID(strApproveID);
                RecruitmentApplyInfo _applyInfo = _manage.GetApplyByObjectID(_approveInfo.ApplyID.ToString());

                // 设置归档信息.
                _approveInfo.ApproveState = 1;
                _approveInfo.ApproveOp = 4;
                _approveInfo.ApproveTime = DateTime.Now;
                _manage.UpdateApprove(_approveInfo);

                // 设置申请单信息.
                if (strApproveResult == "同意")
                {
                    _applyInfo.State = 2;
                }
                else
                {
                    _applyInfo.State = 1;
                }

                _manage.UpdateApply(_applyInfo);

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
                RecruitmentManage _manage = new RecruitmentManage();
                RecruitmentApproveInfo _approveInfo = (RecruitmentApproveInfo)e.DataItem;
                RecruitmentApplyInfo _applyInfo = _manage.GetApplyByObjectID(_approveInfo.ApplyID.ToString());
                if (_applyInfo != null)
                {
                    List<RecruitmentApproveInfo> lstApprove = _manage.GetApproveByCondition(" ApplyID='" + _applyInfo.ObjectID.ToString()
                        + "' and (ApproveOp = 1 or ApproveOp = 2) and ApproveTime < '" + _approveInfo.ApproveTime
                        + "' order by ApproveTime desc");

                    e.Values[0] = _approveInfo.ObjectID.ToString();
                    e.Values[1] = _applyInfo.ObjectID.ToString();
                    e.Values[2] = _applyInfo.Name;
                    e.Values[3] = _applyInfo.ApplyTime.ToString("yyyy-MM-dd HH:mm");
                    e.Values[4] = _applyInfo.Dept;
                    e.Values[5] = _applyInfo.Title;
                    e.Values[6] = "<span  ext:qtip=\"" + _applyInfo.Content + "\">" + _applyInfo.Content + "</span>";
                    if (lstApprove.Count > 0)
                    {
                        e.Values[7] = lstApprove[0].ApproverName;
                        e.Values[8] = lstApprove[0].Result == 0 ? "同意" : "不同意";
                    }
                    e.Values[9] = _approveInfo.ApproveOp == 3 ? "待归档" : "已归档";
                    if (_approveInfo.ApproveOp == 4)
                    {
                        e.Values[10] = "<span class=\"gray\">归档</span>";
                    }
                }
                //判断页面是否可编辑（可查看不用考虑）
                if (PageModel != VisitLevel.Edit || PageModel != VisitLevel.Both)
                {
                    e.Values[10] = "<span class=\"gray\">归档</span>";
                }
            }
        }

        #endregion
    }
}