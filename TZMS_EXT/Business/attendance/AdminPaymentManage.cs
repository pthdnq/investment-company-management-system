﻿using System;
using System.Collections.Generic;
using System.Text;
using com.TZMS.Model;
using com.TZMS.DataAccess;

namespace com.TZMS.Business
{
    public class AdminPaymentManage : ParentManage
    {
        #region 构造函数
        public AdminPaymentManage()
        { }
        #endregion

        #region 基本业务
        AdminPaymentCtrl ctrl = new AdminPaymentCtrl();

        /// <summary>
        ///  添加到数据库
        /// </summary>
        /// <param name="boName">连接字符串Key</param>
        /// <param name="user">AdminPaymentInfo 实体</param>
        /// <returns>返回执行结果</returns>
        public int Add(AdminPaymentInfo info, string boName = BoName)
        {
            return ctrl.Insert(boName, info);
        }

        /// <summary>
        /// 根据 唯一ID删除(假删除，改变 state=9)
        /// </summary>
        /// <param name="boName">连接字符串Key</param>
        /// <param name="objectID">唯一ID（GUID）</param>
        public void Delete(string objectID, string boName = BoName)
        {
            ctrl.Delete(boName, " ObjectID ='" + objectID + "' ");
        }

        /// <summary>
        /// 更新信息
        /// </summary>
        /// <param name="boName">连接字符串Key</param>
        /// <param name="info">用户实体</param>
        /// <returns>执行结果</returns>
        public int Update(AdminPaymentInfo info, string boName = BoName)
        {
            return ctrl.UpDate(boName, info);
        }

        /// <summary>
        /// 通过ObjectID获得 
        /// </summary>
        /// <param name="boName">连接字符串Key</param>
        /// <param name="objectID">ObjectID</param>
        /// <returns> 唯一ID（GUID）</returns>
        public AdminPaymentInfo GetUserByObjectID(string objectID, string boName = BoName)
        {
            List<AdminPaymentInfo> users = ctrl.SelectAsList(boName, "  ObjectID ='" + objectID + "' ");
            if (users.Count == 0)
            {
                return null;
            }
            return users[0];
        }

        /// <summary>
        /// 获得所有 
        /// </summary>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>集合</returns>
        public List<AdminPaymentInfo> GetAllUsers(string boName = BoName)
        {
            return ctrl.SelectAsList(boName, " status <> 9 ");
        }

        /// <summary>
        /// 根据条件获得信息集合
        /// </summary>
        /// <param name="boName">连接字符串Key</param>
        /// <param name="condtion">条件</param>
        /// <returns>集合</returns>
        public List<AdminPaymentInfo> GetUsersByCondtion(string condtion, string boName = BoName)
        {
            return ctrl.SelectAsList(boName, condtion);
        }
        #endregion

        #region 历史记录
        AdminPaymentHistoryCtrl hctrl = new AdminPaymentHistoryCtrl();

        public int AddHistory(Guid forID, string operationType, string operationDesc, string operationerAccount, string operationerName, DateTime operationTime, string remark)
        {
            AdminPaymentHistoryInfo info = new AdminPaymentHistoryInfo()
            {
                Id = Guid.NewGuid(),
                ForId = forID,
                OperationType = operationType,
                OperationDesc = operationDesc,
                OperationerAccount = operationerAccount,
                OperationerName = operationerName,
                OperationTime = operationTime,
                Remark = remark
            };
            return AddHistory(info);
        }

        /// <summary>
        /// 添加操作记录
        /// </summary>
        /// <param name="info">info</param>
        /// <param name="boName">boName</param>
        /// <returns>int</returns>
        public int AddHistory(AdminPaymentHistoryInfo info, string boName = BoName)
        {
            return hctrl.Insert(boName, info);
        }

        /// <summary>
        /// 获取操作记录列表
        /// </summary>
        /// <param name="condtion">condtion</param>
        /// <param name="boName">boName</param>
        /// <returns> List 操作记录</returns>
        public List<AdminPaymentHistoryInfo> GetHistoryByCondtion(string condtion, string boName = BoName)
        {
            return hctrl.SelectAsList(boName, condtion);
        }

        #endregion
    }
}
