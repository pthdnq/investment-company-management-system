using System;
using System.Collections.Generic;
using System.Text;
using com.TZMS.Model;
using com.TZMS.DataAccess;

namespace com.TZMS.Business
{
    public class CashFlowManage : ParentManage
    {
        #region 构造函数

        CashFlowStatementCtrl ctrl = new CashFlowStatementCtrl();

        /// <summary>
        /// 默认构造函数
        /// </summary>
        public CashFlowManage()
        {
            //todo
        }
        #endregion

        #region 基本操作
        /// <summary>
        ///  添加到数据库
        /// </summary>
        /// <param name="boName">连接字符串Key</param>
        /// <param name="user">BankLoanInfo 实体</param>
        /// <returns>返回执行结果</returns>
        public int Add(CashFlowStatementInfo info, string boName = BoName)
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
            ctrl.Delete(boName, " ObjetctID ='" + objectID + "' ");
        }

        /// <summary>
        /// 更新信息
        /// </summary>
        /// <param name="boName">连接字符串Key</param>
        /// <param name="info">用户实体</param>
        /// <returns>执行结果</returns>
        public int Update(CashFlowStatementInfo info, string boName = BoName)
        {
            return ctrl.UpDate(boName, info);
        }


        /// <summary>
        /// 通过ObjectID获得 
        /// </summary>
        /// <param name="boName">连接字符串Key</param>
        /// <param name="objectID">ObjectID</param>
        /// <returns> 唯一ID（GUID）</returns>
        public CashFlowStatementInfo GetUserByObjectID(string objectID, string boName = BoName)
        {
            List<CashFlowStatementInfo> users = ctrl.SelectAsList(boName, " status <> 9 and ObjetctID ='" + objectID + "' ");
            if (users.Count == 0)
            {
                return null;
            }
            return users[0];
        }

        /// <summary>
        /// 通过帐号获得 
        /// </summary>
        /// <param name="boName">连接字符串Key</param>
        /// <param name="accountNo">帐号</param>
        /// <returns>用户实体</returns>
        public CashFlowStatementInfo GetUserByAccountNo(string accountNo, string boName = BoName)
        {
            List<CashFlowStatementInfo> users = ctrl.SelectAsList(boName, " status <> 9 and  AccountNo ='" + accountNo + "' ");
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
        public List<CashFlowStatementInfo> GetAllUsers(string boName = BoName)
        {
            return ctrl.SelectAsList(boName, " status <> 9 ");
        }


        /// <summary>
        /// 根据条件获得信息集合
        /// </summary>
        /// <param name="boName">连接字符串Key</param>
        /// <param name="condtion">条件</param>
        /// <returns>集合</returns>
        public List<CashFlowStatementInfo> GetUsersByCondtion(string condtion, string boName = BoName)
        {
            return ctrl.SelectAsList(boName, condtion);
        }
        #endregion

        #region 会计记录
        AccountantAuditHistoryCtrl hctrl = new AccountantAuditHistoryCtrl();

        //public int AddHistory(Guid forID, string operationType, string operationDesc, string operationerAccount, string operationerName, DateTime operationTime, string remark)
        //{
        //    return AddHistory(false, forID, operationType, operationDesc, operationerAccount, operationerName, operationTime, remark);
        //}

        public int AddHistory(Guid forID, string operationType, string operationDesc, string operationerAccount, string operationerName, DateTime operationTime, string remark,string bizType)
        {
            AccountantAuditHistoryInfo info = new AccountantAuditHistoryInfo()
            {
                Id = Guid.NewGuid(),
                ForId = forID,
                OperationType = operationType,
                OperationDesc = operationDesc,
                OperationerAccount = operationerAccount,
                OperationerName = operationerName,
                OperationTime = operationTime,
                Remark = remark,
                BizType = bizType
            };
            return AddHistory(info);

        }

        public int AddHistory(AccountantAuditHistoryInfo info, string boName = BoName)
        {
            return hctrl.Insert(boName, info);
        }

        public List<AccountantAuditHistoryInfo> GetHistoryByCondtion(string condtion, string boName = BoName)
        {
            return hctrl.SelectAsList(boName, condtion);
        }


        #endregion
    }
}
