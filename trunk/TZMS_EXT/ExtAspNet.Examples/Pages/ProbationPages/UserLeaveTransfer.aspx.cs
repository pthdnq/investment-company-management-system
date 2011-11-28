﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExtAspNet;
using com.TZMS.Model;
using com.TZMS.Business;

namespace TZMS.Web
{
    public partial class UserLeaveTransfer : BasePage
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

                BindArchiver();
                BindTransferInfo();
            }
        }

        #region 私有方法

        /// <summary>
        /// 绑定归档人
        /// </summary>
        private void BindArchiver()
        {
            UserInfo _archiverUser = new UserManage().GetUserByObjectID(strArchiver);
            if (_archiverUser != null)
            {
                ddlstArchiver.Items.Add(new ExtAspNet.ListItem(_archiverUser.Name, _archiverUser.ObjectId.ToString()));
            }
        }

        /// <summary>
        /// 绑定交接信息
        /// </summary>
        private void BindTransferInfo()
        {
            if (ApplyID == null)
                return;
            UserLeaveApplyInfo _applyInfo = new UserLeaveManage().GetApplyByObjectID(ApplyID);
            if (_applyInfo != null)
            {
                lblName.Text = _applyInfo.UserName;
                lblPostion.Text = _applyInfo.UserPosition;
                lblLeaveDate.Text = _applyInfo.LeaveDate.ToString("yyyy-MM-dd HH:mm");
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
        /// 交接事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnPass_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TransferID) || string.IsNullOrEmpty(ApplyID))
                return;
            UserLeaveManage _manage = new UserLeaveManage();
            UserLeaveTransferInfo _transferInfo = _manage.GetTransferByObjectID(TransferID);
            if (_transferInfo != null)
            {
                // 更新交接单信息.
                _transferInfo.IsTransfer = true;
                _transferInfo.TransferTime = DateTime.Now;
                _transferInfo.Other = taaOther.Text.Trim();

                int result = _manage.UpdateTransfer(_transferInfo);

                // 检查是否已交接完成.
                List<UserLeaveTransferInfo> lstTransfer = _manage.GetTransferByCondition(" ApplyID = '" + ApplyID + "'");
                bool isReadyToArchiver = true;
                foreach (UserLeaveTransferInfo item in lstTransfer)
                {
                    if (item.IsTransfer == false)
                    {
                        isReadyToArchiver = false;
                    }
                }

                if (isReadyToArchiver)
                {
                    // 设置申请单的交接状态.
                    UserLeaveApplyInfo _applyInfo = _manage.GetApplyByObjectID(ApplyID);
                    UserInfo _archiverUser = new UserManage().GetUserByObjectID(strArchiver);
                    if (_applyInfo != null && _archiverUser != null)
                    {
                        _applyInfo.TransferID = new Guid(strArchiver);
                        _applyInfo.TransferState = 0;

                        _manage.UpdateApply(_applyInfo);

                        // 插入新的交接单.
                        UserLeaveTransferInfo _newTransferInfo = new UserLeaveTransferInfo();
                        _newTransferInfo.ObjectID = Guid.NewGuid();
                        _newTransferInfo.TransferID = _archiverUser.ObjectId;
                        _newTransferInfo.TransferName = _archiverUser.Name;
                        _newTransferInfo.TransferDept = _archiverUser.Dept;
                        _newTransferInfo.IsTransfer = false;
                        _newTransferInfo.TransferState = 0;
                        _newTransferInfo.TransferType = 4;
                        _newTransferInfo.ApplyID = _applyInfo.ObjectID;

                        _manage.AddNewTransfer(_newTransferInfo);
                    }
                }

                if (result == -1)
                {
                    this.btnClose_Click(null, null);
                }
                else
                {
                    Alert.Show("离职交接失败!");
                }
            }
        }

        #endregion
    }
}