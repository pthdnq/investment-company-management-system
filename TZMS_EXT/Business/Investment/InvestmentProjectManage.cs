using System;
using System.Collections.Generic;
using System.Text;
using com.TZMS.Model;
using com.TZMS.DataAccess;


namespace com.TZMS.Business
{
    public class InvestmentProjectManage : ParentManage
    {
        #region 构造函数

        InvestmentProjectCtrl ctrl = new InvestmentProjectCtrl();

        /// <summary>
        /// 默认构造函数
        /// </summary>
        public InvestmentProjectManage()
        {
            //todo
        }
        #endregion

        #region CRUD
        /// <summary>
        ///  添加到数据库
        /// </summary>
        /// <param name="boName">连接字符串Key</param>
        /// <param name="user">InvestmentProjectInfo 实体</param>
        /// <returns>返回执行结果</returns>
        public int Add(InvestmentProjectInfo info, string boName = BoName)
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
        public int Update(InvestmentProjectInfo info, string boName = BoName)
        {
            return ctrl.UpDate(boName, info);
        }
        #endregion

        #region 获取借款信息
        /// <summary>
        /// 通过ObjectID获得 
        /// </summary>
        /// <param name="boName">连接字符串Key</param>
        /// <param name="objectID">ObjectID</param>
        /// <returns> 唯一ID（GUID）</returns>
        public InvestmentProjectInfo GetUserByObjectID(string objectID, string boName = BoName)
        {
            List<InvestmentProjectInfo> users = ctrl.SelectAsList(boName, " status <> 9 and ObjetctID ='" + objectID + "' ");
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
        /// <returns> 实体</returns>
        public InvestmentProjectInfo GetUserByAccountNo(string accountNo, string boName = BoName)
        {
            List<InvestmentProjectInfo> users = ctrl.SelectAsList(boName, " status <> 9 and  AccountNo ='" + accountNo + "' ");
            if (users.Count == 0)
            {
                return null;
            }
            return users[0];
        }

        /// <summary>
        /// 获得所有员工
        /// </summary>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>集合</returns>
        public List<InvestmentProjectInfo> GetAllUsers(string boName = BoName)
        {
            return ctrl.SelectAsList(boName, " status <> 9 ");
        }


        /// <summary>
        /// 根据条件获得信息集合
        /// </summary>
        /// <param name="boName">连接字符串Key</param>
        /// <param name="condtion">条件</param>
        /// <returns>集合</returns>
        public List<InvestmentProjectInfo> GetUsersByCondtion(string condtion, string boName = BoName)
        {
            return ctrl.SelectAsList(boName, condtion);
        }
        #endregion

        #region  还款信息
        ProjectProcessCtrl rctrl = new ProjectProcessCtrl();

        /// <summary>
        ///  添加到数据库
        /// </summary>
        /// <param name="boName">连接字符串Key</param>
        /// <param name="user">InvestmentProjectInfo 实体</param>
        /// <returns>返回执行结果</returns>
        public int AddProcess(ProjectProcessInfo info, string boName = BoName)
        {
            return rctrl.Insert(boName, info);
        }

        /// <summary>
        /// 更新信息
        /// </summary>
        /// <param name="boName">连接字符串Key</param>
        /// <param name="info">用户实体</param>
        /// <returns>执行结果</returns>
        public int UpdateProcess(ProjectProcessInfo info, string boName = BoName)
        {
            return rctrl.UpDate(boName, info);
        }

        /// <summary>
        /// 通过ObjectID获得 
        /// </summary>
        /// <param name="boName">连接字符串Key</param>
        /// <param name="objectID">ObjectID</param>
        /// <returns> 唯一ID（GUID）</returns>
        public ProjectProcessInfo GetProcessByObjectID(string objectID, string boName = BoName)
        {
            List<ProjectProcessInfo> users = rctrl.SelectAsList(boName, " status <> 9 and ObjetctID ='" + objectID + "' ");
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
        public List<ProjectProcessInfo> GetProcessByCondtion(string condtion, string boName = BoName)
        {
            return rctrl.SelectAsList(boName, condtion);
        }

        #endregion

        #region 历史记录
        InvestmentProjectHistoryCtrl hctrl = new InvestmentProjectHistoryCtrl();
        ProjectProcessHistoryCtrl rhctrl = new ProjectProcessHistoryCtrl();

        public int AddHistory(Guid forID, string operationType, string operationDesc, string operationerAccount, string operationerName, DateTime operationTime, string remark)
        {
            return AddHistory(false, forID, operationType, operationDesc, operationerAccount, operationerName, operationTime, remark);
        }

        public int AddHistory(bool isProcess, Guid forID, string operationType, string operationDesc, string operationerAccount, string operationerName, DateTime operationTime, string remark)
        {
            int iResult = 0;
            if (!isProcess)
            {
                InvestmentProjectHistoryInfo info = new InvestmentProjectHistoryInfo()
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
                iResult = AddHistory(info);
            }
            else
            {
                ProjectProcessHistoryInfo info = new ProjectProcessHistoryInfo()
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
                iResult = AddHistory(info);
            }
            return iResult;
        }

        public int AddHistory(InvestmentProjectHistoryInfo info, string boName = BoName)
        {
            return hctrl.Insert(boName, info);
        }

        public List<InvestmentProjectHistoryInfo> GetHistoryByCondtion(string condtion, string boName = BoName)
        {
            return hctrl.SelectAsList(boName, condtion);
        }

        public int AddHistory(ProjectProcessHistoryInfo info, string boName = BoName)
        {
            return rhctrl.Insert(boName, info);
        }

        public List<ProjectProcessHistoryInfo> GetProcessHistoryByCondtion(string condtion, string boName = BoName)
        {
            return rhctrl.SelectAsList(boName, condtion);
        }

        #endregion
    }
}
