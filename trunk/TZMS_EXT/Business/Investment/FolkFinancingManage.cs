﻿using System;
using System.Collections.Generic;
using System.Text;
using com.TZMS.Model;
using com.TZMS.DataAccess;

namespace com.TZMS.Business
{
    public class FolkFinancingManage: ParentManage
    {
           #region 构造函数

        FolkFinancingCtrl ctrl = new FolkFinancingCtrl();

        /// <summary>
        /// 默认构造函数
        /// </summary>
        public FolkFinancingManage()
        {
            //todo
        }
        #endregion

        /// <summary>
        ///  添加到数据库
        /// </summary>
        /// <param name="boName">连接字符串Key</param>
        /// <param name="user">BankLoanInfo 实体</param>
        /// <returns>返回执行结果</returns>
        public int Add(FolkFinancingInfo info, string boName = BoName)
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
        public int Update(FolkFinancingInfo info, string boName = BoName)
        { 
            return ctrl.UpDate(boName, info);
        }

        #region 获取 信息
        /// <summary>
        /// 通过ObjectID获得 
        /// </summary>
        /// <param name="boName">连接字符串Key</param>
        /// <param name="objectID">ObjectID</param>
        /// <returns> 唯一ID（GUID）</returns>
        public FolkFinancingInfo GetUserByObjectID(string objectID, string boName = BoName)
        {
            List<FolkFinancingInfo> users = ctrl.SelectAsList(boName, " status <> 9 and ObjetctID ='" + objectID + "' ");
            if (users.Count == 0)
            {
                return null;
            }
            return users[0];
        }

        /// <summary>
        /// 通过帐号获得员工
        /// </summary>
        /// <param name="boName">连接字符串Key</param>
        /// <param name="accountNo">帐号</param>
        /// <returns>用户实体</returns>
        public FolkFinancingInfo GetUserByAccountNo(string accountNo, string boName = BoName)
        {
            List<FolkFinancingInfo> users = ctrl.SelectAsList(boName, " status <> 9 and  AccountNo ='" + accountNo + "' ");
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
        public List<FolkFinancingInfo> GetAllUsers(string boName = BoName)
        {
            return ctrl.SelectAsList(boName, " status <> 9 ");
        }


        /// <summary>
        /// 根据条件获得信息集合
        /// </summary>
        /// <param name="boName">连接字符串Key</param>
        /// <param name="condtion">条件</param>
        /// <returns>集合</returns>
        public List<FolkFinancingInfo> GetUsersByCondtion(string condtion, string boName = BoName)
        {
            return ctrl.SelectAsList(boName, condtion);
        }
        #endregion

        #region  进程信息  
        FinancingFeePaymentCtrl rctrl = new FinancingFeePaymentCtrl();

        /// <summary>
        ///  添加到数据库
        /// </summary>
        /// <param name="boName">连接字符串Key</param>
        /// <param name="user">BankLoanInfo 实体</param>
        /// <returns>返回执行结果</returns>
        public int AddProcess(FinancingFeePaymentInfo info, string boName = BoName)
        {
            return rctrl.Insert(boName, info);
        }

        /// <summary>
        /// 更新信息
        /// </summary>
        /// <param name="boName">连接字符串Key</param>
        /// <param name="info">用户实体</param>
        /// <returns>执行结果</returns>
        public int UpdateProcess(FinancingFeePaymentInfo info, string boName = BoName)
        {
            return rctrl.UpDate(boName, info);
        }

        /// <summary>
        /// 通过ObjectID获得 
        /// </summary>
        /// <param name="boName">连接字符串Key</param>
        /// <param name="objectID">ObjectID</param>
        /// <returns> 唯一ID（GUID）</returns>
        public FinancingFeePaymentInfo GetProcessByObjectID(string objectID, string boName = BoName)
        {
            List<FinancingFeePaymentInfo> users = rctrl.SelectAsList(boName, " status <> 9 and ObjetctID ='" + objectID + "' ");
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
        public List<FinancingFeePaymentInfo> GetProcessByCondtion(string condtion, string boName = BoName)
        {
            return rctrl.SelectAsList(boName, condtion);
        }
      
        #endregion
    }
}
