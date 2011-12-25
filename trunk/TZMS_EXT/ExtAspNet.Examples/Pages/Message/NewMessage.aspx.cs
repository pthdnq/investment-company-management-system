using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExtAspNet;
using com.TZMS.Business;
using com.TZMS.Model;

namespace TZMS.Web.Pages
{
    public partial class NewMessage : BasePage
    {
        /// <summary>
        /// 操作类型
        /// </summary>
        public string OperatorType
        {
            get
            {
                if (ViewState["OperatorType"] == null)
                {
                    return null;
                }

                return ViewState["OperatorType"].ToString();
            }
            set
            {
                ViewState["OperatorType"] = value;
            }
        }

        /// <summary>
        /// 发送消息ID
        /// </summary>
        public string SentMessageID
        {
            get
            {
                if (ViewState["SentMessageID"] == null)
                {
                    return null;
                }

                return ViewState["SentMessageID"].ToString();
            }
            set
            {
                ViewState["SentMessageID"] = value;
            }
        }

        /// <summary>
        /// 消息ID
        /// </summary>
        public string MessageID
        {
            get
            {
                if (ViewState["MessageID"] == null)
                {
                    return null;
                }

                return ViewState["MessageID"].ToString();
            }
            set
            {
                ViewState["MessageID"] = value;
            }
        }

        /// <summary>
        /// 收信人
        /// </summary>
        public string Recevicers
        {
            get
            {
                if (ViewState["Recevicers"] == null)
                {
                    return null;
                }

                return ViewState["Recevicers"].ToString();
            }
            set
            {
                ViewState["Recevicers"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                wndRecevicers.OnClientCloseButtonClick = wndRecevicers.GetHidePostBackReference();

                string strOperatorType = Page.Request.QueryString["Type"];
                string strID = Page.Request.QueryString["ID"];
                switch (strOperatorType)
                {
                    // 发送消息.
                    case "Add":
                        {
                            OperatorType = strOperatorType;
                            SentMessageID = Guid.NewGuid().ToString();
                            BindMessageInfo();
                            SetControlsState();
                        }
                        break;
                    // 查看发送消息.
                    case "ViewSentMessage":
                        {
                            OperatorType = strOperatorType;
                            SentMessageID = strID;

                            BindMessageInfo();
                            SetControlsState();
                        }
                        break;
                    // 查看消息.
                    case "ViewMessage":
                        {
                            OperatorType = strOperatorType;
                            MessageID = strID;

                            BindMessageInfo();
                            SetControlsState();
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        #region 私有方法

        /// <summary>
        /// 绑定页面
        /// </summary>
        private void BindMessageInfo()
        {
            if (string.IsNullOrEmpty(OperatorType))
                return;
            MessageManage _manage = new MessageManage();

            if (OperatorType == "Add")
            {
                lblSentDate.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm");

                MUDAttachment.RecordID = SentMessageID;
            }

            // 绑定发送消息.
            if (OperatorType == "ViewSentMessage")
            {
                SentMessageInfo _info = _manage.GetSentMessageByObjectID(SentMessageID);
                if (_info != null)
                {
                    lblSentDate.Text = _info.SendDate.ToString("yyyy-MM-dd HH:mm");
                    tbxTitle.Text = _info.Tile;
                    taaContent.Text = _info.Context;

                    string[] arrayRecevicers = _info.Recevicer.Split('|');
                    string strRecevicers = string.Empty;
                    for (int i = 0; i < arrayRecevicers.Length; i++)
                    {
                        if (i != 0)
                        {
                            strRecevicers += "," + arrayRecevicers[i].Split(',')[1];
                        }
                        else
                        {
                            strRecevicers += arrayRecevicers[i].Split(',')[1];
                        }
                    }

                    lblRecevices.Text = strRecevicers;

                    MUDAttachment.RecordID = _info.ObjectId.ToString();
                }
            }

            // 绑定消息.
            if (OperatorType == "ViewMessage")
            {
                MessageInfo _info = _manage.GetMessageByObjectID(MessageID);
                if (_info != null)
                {
                    lblSender.Text = _info.SenderName;
                    lblSentDate.Text = _info.SendDate.ToString("yyyy-MM-dd HH:mm");
                    tbxTitle.Text = _info.Tile;
                    taaContent.Text = _info.Context;

                    MUDAttachment.RecordID = _info.SentMessageId.ToString();
                }
            }
        }

        /// <summary>
        /// 设置控件状态
        /// </summary>
        private void SetControlsState()
        {
            if (!string.IsNullOrEmpty(OperatorType))
            {
                switch (OperatorType)
                {
                    case "Add":
                        {
                            lblSender.Hidden = true;
                        }
                        break;
                    case "ViewSentMessage":
                        {

                            MUDAttachment.ShowAddBtn = "false";
                            MUDAttachment.ShowDelBtn = "false";

                            lblSender.Hidden = true;
                            btnSend.Enabled = false;
                            tbxTitle.Required = false;
                            tbxTitle.ShowRedStar = false;
                            tbxTitle.Enabled = false;
                            taaContent.Required = false;
                            taaContent.ShowRedStar = false;
                            taaContent.Enabled = false;
                            lblRecevices.ShowRedStar = false;
                            lblRecevices.Required = false;
                            lblRecevices.Enabled = false;
                            btnRecevicer.Hidden = true;
                        }
                        break;
                    case "ViewMessage":
                        {
                            MUDAttachment.ShowAddBtn = "false";
                            MUDAttachment.ShowDelBtn = "false";

                            btnSend.Enabled = false;
                            btnSend.Hidden = true;
                            btnRecevicer.Enabled = false;
                            btnRecevicer.Hidden = true;
                            lblRecevices.ShowRedStar = false;
                            lblRecevices.Required = false;
                            lblRecevices.Hidden = true;
                            tbxTitle.Required = false;
                            tbxTitle.ShowRedStar = false;
                            tbxTitle.Enabled = false;
                            taaContent.Required = false;
                            taaContent.ShowRedStar = false;
                            taaContent.Enabled = false;
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        private void SendMessage()
        {
            MessageManage _manage = new MessageManage();
            if (string.IsNullOrEmpty(Recevicers))
            {
                Alert.Show("收信人尚未设置!");
                return;
            }

            // 获取收信人.
            string[] arrayRecevicers = Recevicers.Split('|');

            // 创建发送消息实例.
            SentMessageInfo _sentInfo = new SentMessageInfo();
            _sentInfo.ObjectId = new Guid(SentMessageID);
            _sentInfo.SenderId = CurrentUser.ObjectId;
            _sentInfo.SenderName = CurrentUser.Name;
            _sentInfo.DeptName = CurrentUser.Dept;
            _sentInfo.Tile = tbxTitle.Text.Trim();
            _sentInfo.Context = taaContent.Text.Trim();
            _sentInfo.Recevicer = Recevicers;
            _sentInfo.SendDate = DateTime.Now;
            _sentInfo.IsDelete = false;

            // 插入发送消息到数据库.
            int result = _manage.AddNewSentMessage(_sentInfo);

            // 创建消息实例，并插入到数据库.
            MessageInfo _info = null;
            foreach (string strRecevicer in arrayRecevicers)
            {
                _info = new MessageInfo();
                _info.ObjectId = Guid.NewGuid();
                _info.SenderId = _sentInfo.ObjectId;
                _info.SenderName = _sentInfo.SenderName;
                _info.DeptName = _sentInfo.DeptName;
                _info.Tile = _sentInfo.Tile;
                _info.Context = _sentInfo.Context;
                _info.ReceviceId = new Guid(strRecevicer.Split(',')[0]);
                _info.Recevicer = strRecevicer.Split(',')[1];
                _info.SendDate = _sentInfo.SendDate;
                _info.ViewDate = ACommonInfo.DBEmptyDate;
                _info.IsView = false;
                _info.IsDelete = false;
                _info.SentMessageId = _sentInfo.ObjectId;

                _manage.AddNewMessage(_info);
                _info = null;
            }

            if (result == -1)
            {
                Alert.Show("消息发送成功!");
                Session[CurrentUser.ObjectId.ToString()] = null;
                btnSend.Enabled = false;
                btnRecevicer.Enabled = false;
                MUDAttachment.ShowAddBtn = "false";
                MUDAttachment.ShowDelBtn = "false";
            }
            else
            {
                Alert.Show("消息发送失败!");
            }
        }

        #endregion

        #region 页面事件

        /// <summary>
        /// 关闭窗口事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnClose_Click(object sender, EventArgs e)
        {
            PageContext.RegisterStartupScript(ExtAspNet.ActiveWindow.GetHidePostBackReference());
        }

        /// <summary>
        /// 发送消息事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSend_Click(object sender, EventArgs e)
        {
            SendMessage();
        }

        /// <summary>
        /// 收信人按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnRecevicer_Click(object sender, EventArgs e)
        {
            if (OperatorType == "Add")
            {
                wndRecevicers.Title = "设置收信人";
                wndRecevicers.IFrameUrl = "SelectReceivers.aspx?Type=Add";
                wndRecevicers.Hidden = false;
            }

            if (OperatorType == "ViewSentMessage")
            {
                wndRecevicers.Title = "查看收信人";
                wndRecevicers.IFrameUrl = "SelectReceivers.aspx?Type=View&ID=" + SentMessageID;
                wndRecevicers.Hidden = false;
            }
        }

        /// <summary>
        /// 收信人关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void wndRecevicers_Close(object sender, WindowCloseEventArgs e)
        {
            if (e.CloseArgument != "undefined")
            {
                Recevicers = e.CloseArgument;
                string[] arrayRecevicers = e.CloseArgument.Split('|');
                string strRecevicers = string.Empty;
                for (int i = 0; i < arrayRecevicers.Length; i++)
                {
                    if (i != 0)
                    {
                        strRecevicers += "," + arrayRecevicers[i].Split(',')[1];
                    }
                    else
                    {
                        strRecevicers += arrayRecevicers[i].Split(',')[1];
                    }
                }

                lblRecevices.Text = strRecevicers;
            }
        }

        #endregion
    }
}