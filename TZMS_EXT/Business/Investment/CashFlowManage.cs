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
        /// 添加资金流
        /// </summary>
        /// <param name="amount">金额</param>
        /// <param name="dateFor">日期</param>
        /// <param name="flowDirection">Payment出款；Receive收款</param>
        /// <param name="biz">业务</param>
        /// <param name="projectName">项目</param> 
        ///  <param name="remark">备注</param> 
        /// <returns>int</returns>
        public int Add(decimal amount, DateTime dateFor, string flowDirection, string biz, string projectName, string remark)
        {
            CashFlowStatementInfo vsfi = new CashFlowStatementInfo()
                       {
                           ObjectId = Guid.NewGuid(),
                           Amount = amount,
                           DateFor = dateFor,
                           FlowDirection = flowDirection,
                           FlowType = "",
                           Biz = biz,
                           ProjectName = projectName,
                           IsAccountingAudit = 1,
                           Remark = remark
                       };
            return Add(vsfi);
        }

        /// <summary>
        ///  添加到数据库
        /// </summary>
        /// <param name="boName">连接字符串Key</param>
        /// <param name="user">BankLoanInfo 实体</param>
        /// <returns>返回执行结果</returns>
        public int Add(CashFlowStatementInfo info, string boName = BoName)
        {
            //Receive ++
            // --
            CashFlowSetterInfo cash = new CashFlowSetterInfo();
            List<CashFlowSetterInfo> list = new CashFlowSetterCtrl().SelectAsList(boName, " [Status]=1 ");
            if (list.Count > 0)
                cash = list[0];
            if (info.FlowDirection.ToLower() == "receive")
            {
                cash.OriginalAmount += info.Amount;
            }
            else
            {
                cash.OriginalAmount -= info.Amount;
            }
            if (list.Count > 0)
            {
                new CashFlowSetterCtrl().UpDate(boName, cash);
                info.RemainingAmount = cash.OriginalAmount;
            }
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
            List<CashFlowStatementInfo> users = ctrl.SelectAsList(boName, " status <> 9 and ObjectID ='" + objectID + "' ");
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

        public int AddHistory(Guid forID, string operationType, string operationDesc, string operationerAccount, string operationerName, DateTime operationTime, string remark, string bizType)
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

        #region 资金初始化
        CashFlowSetterCtrl cfsCtrl = new CashFlowSetterCtrl();
        /// <summary>
        ///  添加到数据库
        /// </summary>
        /// <param name="boName">连接字符串Key</param>
        /// <param name="user">BankLoanInfo 实体</param>
        /// <returns>返回执行结果</returns>
        public int AddCashFlowSetter(CashFlowSetterInfo info, string boName = BoName)
        {
            return cfsCtrl.Insert(boName, info);
        }

        /// <summary>
        /// 根据 唯一ID删除(假删除，改变 state=9)
        /// </summary>
        /// <param name="boName">连接字符串Key</param>
        /// <param name="objectID">唯一ID（GUID）</param>
        public void DeleteCashFlowSetter(string objectID, string boName = BoName)
        {
            cfsCtrl.Delete(boName, " ObjectID ='" + objectID + "' ");
        }

        /// <summary>
        /// 更新信息
        /// </summary>
        /// <param name="boName">连接字符串Key</param>
        /// <param name="info">用户实体</param>
        /// <returns>执行结果</returns>
        public int UpdateCashFlowSetter(CashFlowSetterInfo info, string boName = BoName)
        {
            return cfsCtrl.UpDate(boName, info);
        }


        /// <summary>
        /// 通过ObjectID获得 
        /// </summary>
        /// <param name="boName">连接字符串Key</param>
        /// <param name="objectID">ObjectID</param>
        /// <returns> 唯一ID（GUID）</returns>
        public CashFlowSetterInfo GetCashFlowSetterByObjectID(string objectID, string boName = BoName)
        {
            List<CashFlowSetterInfo> users = cfsCtrl.SelectAsList(boName, "  ObjectID ='" + objectID + "' ");
            if (users.Count == 0)
            {
                return null;
            }
            return users[0];
        }

        /// <summary>
        /// 根据条件获得信息集合
        /// </summary>
        /// <param name="boName">连接字符串Key</param>
        /// <param name="condtion">条件</param>
        /// <returns>集合</returns>
        public List<CashFlowSetterInfo> GetCashFlowSettersByCondtion(string condtion, string boName = BoName)
        {
            return cfsCtrl.SelectAsList(boName, condtion);
        }
        #endregion
    }
}
