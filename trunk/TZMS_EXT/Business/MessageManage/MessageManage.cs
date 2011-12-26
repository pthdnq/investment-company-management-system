using System;
using System.Collections.Generic;
using System.Text;
using com.TZMS.Model;
using com.TZMS.DataAccess;

namespace com.TZMS.Business
{
    public class MessageManage : ParentManage
    {
        public MessageManage()
        { }

        /// <summary>
        /// 添加新信息
        /// </summary>
        /// <param name="messageInfo">信息实例</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>操作结果</returns>
        public int AddNewMessage(MessageInfo messageInfo, string boName = BoName)
        {
            MessageCtrl _ctrl = new MessageCtrl();
            return _ctrl.Insert(boName, messageInfo);
        }

        /// <summary>
        /// 更新信息
        /// </summary>
        /// <param name="messageInfo">信息实例</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>操作结果</returns>
        public int UpdateMessage(MessageInfo messageInfo, string boName = BoName)
        {
            MessageCtrl _ctrl = new MessageCtrl();
            return _ctrl.UpDate(boName, messageInfo);
        }

        /// <summary>
        /// 根据ObjectID获取指定的消息实例
        /// </summary>
        /// <param name="objectID">ObjectID</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>消息实例</returns>
        public MessageInfo GetMessageByObjectID(string objectID, string boName = BoName)
        {
            MessageCtrl _ctrl = new MessageCtrl();
            List<MessageInfo> lstMessageInfo = _ctrl.SelectAsList(boName, " ObjectID='" + objectID + "'");
            if (lstMessageInfo.Count == 0)
            {
                return null;
            }
            return lstMessageInfo[0];
        }

        /// <summary>
        /// 根据查询条件获取消息实例集合
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>消息实例集合</returns>
        public List<MessageInfo> GetMessageByCondition(string condition, string boName = BoName)
        {
            MessageCtrl _ctrl = new MessageCtrl();
            return _ctrl.SelectAsList(boName, condition);
        }

        /// <summary>
        /// 插入发送消息实例
        /// </summary>
        /// <param name="sentMessageInfo">发送消息实例</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>操作结果</returns>
        public int AddNewSentMessage(SentMessageInfo sentMessageInfo, string boName = BoName)
        {
            SentMessageCtrl _ctrl = new SentMessageCtrl();
            return _ctrl.Insert(boName, sentMessageInfo);
        }

        /// <summary>
        /// 更新发送消息实例
        /// </summary>
        /// <param name="messageInfo">发送消息实例</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>操作结果</returns>
        public int UpdateSentMessage(SentMessageInfo messageInfo, string boName = BoName)
        {
            SentMessageCtrl _ctrl = new SentMessageCtrl();
            return _ctrl.UpDate(boName, messageInfo);
        }

        /// <summary>
        /// 根据ObjectID获取指定的发送消息实例
        /// </summary>
        /// <param name="objectID">ObjectID</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>发送消息实例</returns>
        public SentMessageInfo GetSentMessageByObjectID(string objectID, string boName = BoName)
        {
            SentMessageCtrl _ctrl = new SentMessageCtrl();
            List<SentMessageInfo> lstSentMessage = _ctrl.SelectAsList(boName, "ObjectID='" + objectID + "'");
            if (lstSentMessage.Count == 0)
            {
                return null;
            }

            return lstSentMessage[0];
        }

        /// <summary>
        /// 根据查询条件获取发送消息集合
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>发送消息集合</returns>
        public List<SentMessageInfo> GetSentMessageByCondition(string condition, string boName = BoName)
        {
            SentMessageCtrl _ctrl = new SentMessageCtrl();
            return _ctrl.SelectAsList(boName, condition);
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="messageID">消息ID,附件的RecordID与消息ID一致</param>
        /// <param name="sender">发信人ID</param>
        /// <param name="lstRecevicers">收信人</param>
        /// <param name="strTitle">标题</param>
        /// <param name="strContent">内容</param>
        /// <returns>返回值</returns>
        public int SendMessage(Guid messageID, Guid sender, List<Guid> lstRecevicers, string strTitle, string strContent)
        {
            int result = 3;
            UserManage _userManage = new UserManage();
            MessageManage _manage = new MessageManage();
            SentMessageInfo _sentInfo = new SentMessageInfo();

            UserInfo _sender = _userManage.GetUserByObjectID(sender.ToString());
            if (_sender != null)
            {
                _sentInfo.ObjectId = messageID;
                _sentInfo.SenderId = _sender.ObjectId;
                _sentInfo.SenderName = _sender.Name;
                _sentInfo.DeptName = _sender.Dept;
                _sentInfo.Tile = strTitle;
                _sentInfo.Context = strContent;
                _sentInfo.SendDate = DateTime.Now;
                _sentInfo.IsDelete = false;

                UserInfo _recevicer = null;
                MessageInfo _info = null;
                foreach (Guid recevicer in lstRecevicers)
                {
                    _recevicer = _userManage.GetUserByObjectID(recevicer.ToString());
                    if (_recevicer != null)
                    {
                        _sentInfo.Recevicer += ((string.IsNullOrEmpty(_sentInfo.Recevicer) ? string.Empty : "|") + _recevicer.ObjectId + "," + _recevicer.Name);
                        _info = new MessageInfo();
                        _info.ObjectId = Guid.NewGuid();
                        _info.SenderId = _sentInfo.ObjectId;
                        _info.SenderName = _sentInfo.SenderName;
                        _info.DeptName = _sentInfo.DeptName;
                        _info.Tile = _sentInfo.Tile;
                        _info.Context = _sentInfo.Context;
                        _info.ReceviceId = _recevicer.ObjectId;
                        _info.Recevicer = _recevicer.Name;
                        _info.SendDate = _sentInfo.SendDate;
                        _info.ViewDate = ACommonInfo.DBEmptyDate;
                        _info.IsView = false;
                        _info.IsDelete = false;
                        _info.SentMessageId = _sentInfo.ObjectId;

                        _manage.AddNewMessage(_info);
                    }

                    _recevicer = null;
                    _info = null;
                }

                result = _manage.AddNewSentMessage(_sentInfo);
            }

            return result;
        }
    }
}
