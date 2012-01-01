using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.TZMS.Model;
using com.TZMS.Business;
using System.Text;
using ExtAspNet;

namespace TZMS.Web
{
    public partial class NoAttendToFileView : BasePage
    {
        /// <summary>
        /// NoAttendID
        /// </summary>
        public string NoAttendID
        {
            get
            {
                if (ViewState["NoAttendID"] == null)
                {
                    return null;
                }
                return ViewState["NoAttendID"].ToString();
            }

            set
            {
                ViewState["NoAttendID"] = value;
            }
        }

        /// <summary>
        /// NoAttendCheckID
        /// </summary>
        public string NoAttendCheckID
        {
            get
            {
                if (ViewState["NoAttendCheckID"] == null)
                {
                    return null;
                }
                return ViewState["NoAttendCheckID"].ToString();
            }

            set
            {
                ViewState["NoAttendCheckID"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                NoAttendID = Page.Request.QueryString["NoAttendID"];
                NoAttendCheckID = Page.Request.QueryString["NoAttendCheckID"];

                BindNoAttendInfo();
                BindApproveHistory();
                SetPanelState();
            }
        }

        #region 私有方法

        /// <summary>
        /// 绑定申请单信息
        /// </summary>
        private void BindNoAttendInfo()
        {
            NoAttendInfo _info = new NoAttendManage().GetNoAttendInfoByObjectID(NoAttendID);
            if (_info != null)
            {
                lblName.Text = _info.UserName;
                lblAppDate.Text = _info.ApplyTime.ToString("yyyy-MM-dd HH:mm");
                lblYear.Text = _info.Year.ToString();
                lblMonth.Text = _info.Month.ToString();
                taaSument.Text = _info.Comment;
                taaOther.Text = _info.Other;
            }
        }

        /// <summary>
        /// 绑定审批历史
        /// </summary>
        private void BindApproveHistory()
        {
            // 获取数据.
            StringBuilder strCondition = new StringBuilder();
            strCondition.Append("ApplyID = '" + NoAttendID + "'");
            strCondition.Append(" and Checkstate <> 0");
            List<NoAttendCheckInfo> lstNoAttendCheck = new NoAttendManage().GetNoAttendCheckInfoByCondition(strCondition.ToString());

            lstNoAttendCheck.Sort(delegate(NoAttendCheckInfo x, NoAttendCheckInfo y) { return DateTime.Compare(y.CheckDateTime, x.CheckDateTime); });

            // 绑定列表.
            gridApproveHistory.RecordCount = lstNoAttendCheck.Count;
            this.gridApproveHistory.DataSource = lstNoAttendCheck;
            this.gridApproveHistory.DataBind();
        }

        /// <summary>
        /// 设置面板状态
        /// </summary>
        private void SetPanelState()
        {
            if (string.IsNullOrEmpty(NoAttendCheckID))
                return;
            NoAttendManage _manage = new NoAttendManage();
            NoAttendCheckInfo _checkInfo = _manage.GetNoAttendCheckInfoByObjectID(NoAttendCheckID);
            if (_checkInfo != null)
            {
                if (_checkInfo.Checkstate == 1)
                {
                    btnPass.Enabled = false;
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
        protected void btnPass_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(NoAttendID) || string.IsNullOrEmpty(NoAttendCheckID))
                return;

            NoAttendManage _manage = new NoAttendManage();
            NoAttendInfo _info = _manage.GetNoAttendInfoByObjectID(NoAttendID);
            NoAttendCheckInfo _checkInfo = _manage.GetNoAttendCheckInfoByObjectID(NoAttendCheckID);
            int result = 3;
            if (_info != null && _checkInfo != null)
            {
                //_info.State = strLastApproveResult == "同意" ? short.Parse("2") : short.Parse("1");
                //_manage.UpdateNoAttendInfo(_info);

                _checkInfo.CheckOp = "4";
                _checkInfo.Checkstate = 1;
                _checkInfo.CheckDateTime = DateTime.Now;
                _manage.UpdateNoAttendCheckInfo(_checkInfo);

                List<NoAttendCheckInfo> lstCheckInfo = _manage.GetNoAttendCheckInfoByCondition("ApplyID='" + _info.ObjectId.ToString() + "'" +
                        " and (CheckOp = '1' or CheckOp = '2') order by CheckDateTime desc");
                if (lstCheckInfo.Count > 0)
                {
                    _info.State = short.Parse(lstCheckInfo[0].CheckOp);
                    result = _manage.UpdateNoAttendInfo(_info);
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
        /// 审批历史数据行绑定事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridApproveHistory_RowDataBound(object sender, ExtAspNet.GridRowEventArgs e)
        {
            if (e.DataItem != null)
            {
                NoAttendCheckInfo _checkInfo = (NoAttendCheckInfo)e.DataItem;
                e.Values[0] = _checkInfo.CheckerName;
                e.Values[1] = _checkInfo.CheckDateTime.ToString("yyyy-MM-dd HH:mm");
                switch (_checkInfo.CheckOp)
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