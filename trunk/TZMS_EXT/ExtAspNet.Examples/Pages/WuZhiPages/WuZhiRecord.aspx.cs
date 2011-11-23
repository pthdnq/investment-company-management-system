using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExtAspNet;
using com.TZMS.Model;
using com.TZMS.Business;
using System.Text;

namespace TZMS.Web
{
    public partial class WuZhiRecord : BasePage
    {
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
                ApplyID = Request.QueryString["ID"];

                BindWuZhiApplyInfo();
                BindRecordHistory();
            }
        }

        #region 私有方法

        /// <summary>
        /// 绑定申请信息
        /// </summary>
        private void BindWuZhiApplyInfo()
        {
            if (ApplyID == null)
                return;

            WuZhiInfo _info = new WuZhiManage().GetWuZhiByObjectID(ApplyID);
            if (_info != null)
            {
                lblUser.Text = _info.UserName;
                lblApplyDate.Text = _info.ApplyTime.ToString("yyyy-MM-dd HH:mm");
            }
        }

        /// <summary>
        /// 绑定领用历史
        /// </summary>
        private void BindRecordHistory()
        {
            if (ApplyID == null)
                return;

            StringBuilder strCondition = new StringBuilder();
            strCondition.Append(" Isdelete = 0 and WuzhiObjectID='" + ApplyID + "'");
            strCondition.Append(" order by RecordTime desc");

            List<WuZhiRecordInfo> lstRecords = new WuZhiManage().GetWuZhiRecordByCondition(strCondition.ToString());
            this.gridRecordHistory.RecordCount = lstRecords.Count;
            this.gridRecordHistory.PageSize = lstRecords.Count;
            this.gridRecordHistory.DataSource = lstRecords;
            this.gridRecordHistory.DataBind();
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
        /// 领用事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (ApplyID == null)
                return;
            WuZhiManage _manage = new WuZhiManage();
            WuZhiInfo _applyInfo = _manage.GetWuZhiByObjectID(ApplyID);
            if (_applyInfo != null)
            {
                WuZhiRecordInfo _recordInfo = new WuZhiRecordInfo();
                _recordInfo.ObjectId = Guid.NewGuid();
                _recordInfo.UserId = _applyInfo.UserId;
                _recordInfo.UserName = _applyInfo.UserName;
                _recordInfo.UserJobNo = _applyInfo.UserJobNo;
                _recordInfo.UserAccountNo = _applyInfo.UserAccountNo;
                _recordInfo.Dept = _applyInfo.Dept;
                _recordInfo.WuzhiObjectId = _applyInfo.ObjectId;
                _recordInfo.Title = tbxTitle.Text.Trim();
                _recordInfo.Record = taaRecord.Text.Trim();
                _recordInfo.RecorderId = CurrentUser.ObjectId;
                _recordInfo.RecorderName = CurrentUser.Name;
                _recordInfo.RecordTime = DateTime.Now;
                _recordInfo.Isdelete = false;

                int result =  _manage.AddNewWuZhiRecord(_recordInfo);
                if (result == -1)
                {
                    Alert.Show("领用物资成功!");
                    btnSubmit.Enabled = false;
                    BindRecordHistory();
                }
                else
                {
                    Alert.Show("领用物资失败!");
                }

            }

        }

        /// <summary>
        /// 数据行绑定事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridRecordHistory_RowDataBound(object sender, ExtAspNet.GridRowEventArgs e)
        {
            if (e.DataItem != null)
            {
                e.Values[5] = DateTime.Parse(e.Values[5].ToString()).ToString("yyyy-MM-dd HH:mm");
            }
        }

        /// <summary>
        /// 数据行点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridRecordHistory_RowCommand(object sender, GridCommandEventArgs e)
        {
            string strRecordID = ((GridRow)gridRecordHistory.Rows[e.RowIndex]).Values[0];
            if (e.CommandName == "Delete")
            {
                WuZhiManage _manage = new WuZhiManage();
                WuZhiRecordInfo _info = _manage.GetWuZhiRecordByObjectID(strRecordID);
                if (_info != null)
                {
                    _info.Isdelete = true;
                    _manage.UpdateWuZhiRecord(_info);

                    BindRecordHistory();
                }
            }
        }

        #endregion
    }
}