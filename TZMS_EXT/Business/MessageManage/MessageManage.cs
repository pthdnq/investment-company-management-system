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
    }
}
