using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExtAspNet;
using System.Text;
using com.TZMS.Model;
using com.TZMS.Business;

namespace TZMS.Web
{
    public partial class ProbationToFileView : BasePage
    {
        /// <summary>
        /// ApproveID
        /// </summary>
        public string ApproveID
        {
            get
            {
                if (ViewState["ApproveID"] == null)
                {
                    return null;
                }
                return ViewState["ApproveID"].ToString();
            }

            set
            {
                ViewState["ApproveID"] = value;
            }
        }

        /// <summary>
        /// ApplyID
        /// </summary>
        public string ApplyID
        {
            get
            {
                if (ViewState["ApplyID"] == null)
                {
                    return null;
                }
                return ViewState["ApplyID"].ToString();
            }

            set
            {
                ViewState["ApplyID"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ApproveID = Request.QueryString["ApproveID"];
                ApplyID = Request.QueryString["ApplyID"];

                BindApplyInfo();
                BindApproveHistory();
                SetPanelState();
            }
        }

        #region 私有方法

        /// <summary>
        /// 绑定报销申请单信息
        /// </summary>
        private void BindApplyInfo()
        {
            if (!string.IsNullOrEmpty(ApplyID))
            {
                ProbationApplyInfo _info = new ProbationManage().GetApplyByObjectID(ApplyID);
                if (_info != null)
                {
                    lblName.Text = _info.UserName;
                    lblAppDate.Text = _info.ApplyTime.ToString("yyyy-MM-dd HH:mm");
                    lblEntryDate.Text = _info.UserEntryDate.ToString("yyyy-MM-dd");
                    taaSument.Text = _info.Sument;
                    taaOther.Text = _info.Other;
                }
            }
        }

        /// <summary>
        /// 绑定审批历史
        /// </summary>
        private void BindApproveHistory()
        {
            if (ApplyID == null)
                return;
            // 获取数据.
            StringBuilder strCondition = new StringBuilder();
            strCondition.Append(" ApplyID = '" + ApplyID + "'");
            strCondition.Append(" and  (ApproveState <> 0 or (ApproveState = 0 and ApproveOp = 0) or (ApproveState = 0 and ApproveOp = 4))");
            List<ProbationApproveInfo> lstApprove = new ProbationManage().GetApproveByCondition(strCondition.ToString());
            lstApprove.Sort(delegate(ProbationApproveInfo x, ProbationApproveInfo y) { return DateTime.Compare(y.ApproveTime, x.ApproveTime); });

            // 绑定列表.
            gridApproveHistory.RecordCount = lstApprove.Count;
            this.gridApproveHistory.DataSource = lstApprove;
            this.gridApproveHistory.DataBind();
        }

        /// <summary>
        /// 设置面板状态
        /// </summary>
        private void SetPanelState()
        {
            if (string.IsNullOrEmpty(ApproveID))
                return;
            ProbationManage _manage = new ProbationManage();
            ProbationApproveInfo _approveInfo = _manage.GetApproveByObjectID(ApproveID);
            if (_approveInfo != null)
            {
                if (_approveInfo.ApproveOp == 4)
                    btnArchive.Enabled = false;
            }
        }

        #endregion

        #region 页面事件

        /// <summary>
        /// 关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnClose_Click(object sender, EventArgs e)
        {
            PageContext.RegisterStartupScript(ExtAspNet.ActiveWindow.GetHidePostBackReference());
        }

        /// <summary>
        /// 归档事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnArchive_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ApproveID) || string.IsNullOrEmpty(ApplyID))
                return;

            ProbationManage _manage = new ProbationManage();
            ProbationApproveInfo _approveInfo = _manage.GetApproveByObjectID(ApproveID);
            ProbationApplyInfo _applyInfo = _manage.GetApplyByObjectID(_approveInfo.ApplyID.ToString());
            int result = 3;

            // 设置归档信息.
            _approveInfo.ApproveOp = 4;
            _approveInfo.ApproveTime = DateTime.Now;
            _manage.UpdateApprove(_approveInfo);

            List<ProbationApproveInfo> lstApprove = _manage.GetApproveByCondition(" ApplyID='" + _applyInfo.ObjectID.ToString()
                        + "' and (ApproveOp = 1 or ApproveOp = 2) and ApproveTime < '" + _approveInfo.ApproveTime
                        + "' order by ApproveTime desc");
            if (lstApprove.Count > 0)
            {
                // 设置申请单信息.
                if (lstApprove[0].Result == 0)
                {
                    _applyInfo.State = 2;

                    // 设置转正属性.
                    UserManage _userManage = new UserManage();
                    UserInfo _applyUser = _userManage.GetUserByObjectID(_applyInfo.UserID.ToString());
                    if (_applyUser != null)
                    {
                        _applyUser.IsProbation = true;
                        _applyUser.ProbationTime = DateTime.Now;
                        _applyUser.Record += _applyUser.ProbationTime.ToString("yyyyMM-dd") + " 转正\r\n";
                        _userManage.UpdateUser(_applyUser);
                    }
                }
                else
                {
                    _applyInfo.State = 1;
                }

                result = _manage.UpdateApply(_applyInfo);
            }

            if (result == -1)
            {
                this.btnClose_Click(null, null);
            }
            else
            {
                Alert.Show("转正归档失败!");
            }
        }

        /// <summary>
        /// 数据行绑定事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridApproveHistory_RowDataBound(object sender, ExtAspNet.GridRowEventArgs e)
        {
            if (e.DataItem != null)
            {
                e.Values[1] = DateTime.Parse(e.Values[1].ToString()).ToString("yyyy-MM-dd HH:mm");
                switch (e.Values[2].ToString())
                {
                    case "0":
                        e.Values[2] = "起草";
                        break;
                    case "1":
                        e.Values[2] = "审批-通过";
                        break;
                    case "2":
                        e.Values[2] = "审批-不通过";
                        break;
                    case "4":
                        e.Values[2] = "归档";
                        break;
                    default:
                        break;
                }
            }
        }

        #endregion
    }
}