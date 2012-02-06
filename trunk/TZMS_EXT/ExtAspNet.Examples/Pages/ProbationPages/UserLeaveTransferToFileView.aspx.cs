using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.TZMS.Business;
using System.Text;
using com.TZMS.Model;
using ExtAspNet;

namespace TZMS.Web
{
    public partial class UserLeaveTransferToFileView : BasePage
    {
        /// <summary>
        /// TransferID
        /// </summary>
        public string TransferID
        {
            get
            {
                if (ViewState["TransferID"] == null)
                {
                    return null;
                }
                return ViewState["TransferID"].ToString();
            }

            set
            {
                ViewState["TransferID"] = value;
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
                TransferID = Page.Request.QueryString["TransferID"];
                ApplyID = Page.Request.QueryString["ApplyID"];

                BindTransferHistory();
                SetPanelState();
            }
        }

        #region 私有方法

        /// <summary>
        /// 绑定交接历史
        /// </summary>
        private void BindTransferHistory()
        {
            if (ApplyID == null)
                return;
            // 获取数据.
            StringBuilder strCondition = new StringBuilder();
            strCondition.Append("ApplyID = '" + ApplyID + "'");
            strCondition.Append(" and TransferState <> -1 and TransferType <> 4");
            List<UserLeaveTransferInfo> lstApprove = new UserLeaveManage().GetTransferByCondition(strCondition.ToString());

            lstApprove.Sort(delegate(UserLeaveTransferInfo x, UserLeaveTransferInfo y)
            {
                return DateTime.Compare(y.TransferTime, x.TransferTime);
            });

            // 绑定列表.
            gridTransfer.RecordCount = lstApprove.Count;
            this.gridTransfer.DataSource = lstApprove;
            this.gridTransfer.DataBind();
        }

        /// <summary>
        /// 设置面板状态
        /// </summary>
        private void SetPanelState()
        {
            if (string.IsNullOrEmpty(TransferID))
                return;

            UserLeaveManage _manage = new UserLeaveManage();
            UserLeaveTransferInfo _transferInfo = _manage.GetTransferByObjectID(TransferID);
            if (_transferInfo != null)
            {
                if (_transferInfo.IsTransfer)
                {
                    btnSubmit.Enabled = false;
                }
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
        /// 确认归档事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TransferID) || string.IsNullOrEmpty(ApplyID))
                return;

            UserLeaveManage _manage = new UserLeaveManage();
            UserManage _userManage = new UserManage();
            UserLeaveTransferInfo _transferInfo = _manage.GetTransferByObjectID(TransferID);
            UserLeaveApplyInfo _applyInfo = _manage.GetApplyByObjectID(ApplyID);
            int result = 3;
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
                    _leaveUser.Record += _leaveUser.LeaveTime.ToString("yyyy-MM-dd") + " 离职\r\n";
                   result =  _userManage.UpdateUser(_leaveUser);
                }
            }

            if (result == -1)
            {
                this.btnClose_Click(null, null);
            }
            else
            {
                Alert.Show("确认归档失败!");
            }
        }

        /// <summary>
        /// 交接历史数据行绑定事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridTransfer_RowDataBound(object sender, ExtAspNet.GridRowEventArgs e)
        {
            if (e.DataItem != null)
            {
                DateTime approveDate = DateTime.Parse(e.Values[1].ToString());
                if (DateTime.Compare(approveDate, ACommonInfo.DBMAXDate) == 0)
                {
                    e.Values[1] = "交接中...";
                }
                else
                {
                    e.Values[1] = approveDate.ToString("yyyy-MM-dd HH:mm");
                }
                switch (e.Values[2].ToString())
                {
                    case "0":
                        e.Values[2] = "所属部门交接";
                        break;
                    case "1":
                        e.Values[2] = "财务部交接";
                        break;
                    case "2":
                        e.Values[2] = "行政部交接";
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