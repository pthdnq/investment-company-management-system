using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.TZMS.Business;
using com.TZMS.Model;
using ExtAspNet;

namespace TZMS.Web
{
    public partial class JiangChengConfirm : BasePage
    {
        /// <summary>
        /// ID
        /// </summary>
        public string JiangChengID
        {
            get
            {
                if (ViewState["JiangChengID"] == null)
                {
                    return null;
                }

                return ViewState["JiangChengID"].ToString();
            }
            set
            {
                ViewState["JiangChengID"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                JiangChengID = Request.QueryString["ID"];
                BindJiangChengInfo();
                SetState();
            }
        }

        #region 私有方法

        /// <summary>
        /// 绑定奖惩单信息
        /// </summary>
        private void BindJiangChengInfo()
        {
            if (string.IsNullOrEmpty(JiangChengID))
                return;

            JiangChengManage _manage = new JiangChengManage();
            JiangChengInfo _info = _manage.GetJiangChengByObjectID(JiangChengID);
            if (_info != null)
            {
                lblName.Text = _info.CreateName;
                lblApplyTime.Text = _info.CreateTime.ToString("yyyy-MM-dd HH:mm");
                lblJC.Text = _info.UserName;
                lblZJ.Text = _info.ZJName;
                lblType.Text = _info.Type == 0 ? "奖励" : "惩罚";
                taaReason.Text = _info.Reason;
            }
        }

        /// <summary>
        /// 设置状态
        /// </summary>
        private void SetState()
        {
            JiangChengManage _manage = new JiangChengManage();
            JiangChengInfo _info = _manage.GetJiangChengByObjectID(JiangChengID);
            if (_info != null)
            {
                if (_info.State > 0)
                    btnSubmit.Enabled = false;
                //if (_info.UserID.ToString() == CurrentUser.ObjectId.ToString())
                //{
                //    if (_info.State > 0)
                //        btnSubmit.Enabled = false;
                //}
                //else if (_info.ZjID.ToString() == CurrentUser.ObjectId.ToString())
                //{
                //    if (_info.State > 1)
                //        btnSubmit.Enabled = false;
                //}
                //else
                //{
                //    btnSubmit.Enabled = false;
                //}
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
        /// 确认事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(JiangChengID))
                return;

            JiangChengManage _manage = new JiangChengManage();
            JiangChengInfo _info = _manage.GetJiangChengByObjectID(JiangChengID);
            int result = 3;
            if (_info != null)
            {
                //_info.State += 1;
                if (DateTime.Now > _info.UserConfirmTime)
                {
                    
                    _info.ConfirmType = 1;
                }
                _info.ConfirmTime = DateTime.Now;
                _info.State = 1;
                result = _manage.UpdateJiangCheng(_info);
            }
            if (result == -1)
            {
                this.btnClose_Click(null, null);
            }
            else
            {
                Alert.Show("确认失败!");
            }
        }

        #endregion
    }
}