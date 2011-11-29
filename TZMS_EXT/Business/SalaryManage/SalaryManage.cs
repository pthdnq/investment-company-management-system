using System;
using System.Collections.Generic;
using System.Text;
using com.TZMS.Model;
using com.TZMS.DataAccess;

namespace com.TZMS.Business
{
    public class SalaryManage :ParentManage
    {
        public SalaryManage()
        { }

        /// <summary>
        /// 添加新员工薪资信息
        /// </summary>
        /// <param name="info">员工薪资信息实体</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>操作结果</returns>
        public int AddNewWorkerSalaryMsg(WorkerSalaryMsgInfo info, string boName = BoName)
        {
            WorkerSalaryMsgCtrl _ctrl = new WorkerSalaryMsgCtrl();
            return _ctrl.Insert(boName, info);
        }

        /// <summary>
        /// 删除员工薪资信息.
        /// </summary>
        /// <param name="info">对象ID</param>
        /// <param name="boName"></param>
        public void DeleteWorkerSalaryMsg(string objectID, string boName = BoName)
        {
            WorkerSalaryMsgCtrl _ctrl = new WorkerSalaryMsgCtrl();
            _ctrl.Delete(boName, " ObjectID = '" + objectID + "'");
        }

        /// <summary>
        /// 更新员工薪资信息
        /// </summary>
        /// <param name="info">员工薪资信息实例</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>操作结果</returns>
        public int UpdateWorkerSalaryMsg(WorkerSalaryMsgInfo info, string boName = BoName)
        {
            WorkerSalaryMsgCtrl _ctrl = new WorkerSalaryMsgCtrl();
            return _ctrl.UpDate(boName, info);
        }

        /// <summary>
        /// 根据用户ID获取员工薪资信息
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>员工薪资信息实例</returns>
        public WorkerSalaryMsgInfo GetWorkerSalaryMsgByUserID(string userID, string boName = BoName)
        {
            WorkerSalaryMsgCtrl _ctrl = new WorkerSalaryMsgCtrl();
            List<WorkerSalaryMsgInfo> lstApplys = _ctrl.SelectAsList(boName, " UserID = '" + userID + "'");
            if (lstApplys.Count == 0)
            {
                return null;
            }

            return lstApplys[0];
        }

        /// <summary>
        /// 根据ID获取员工薪资信息实例
        /// </summary>
        /// <param name="objectID">ID</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>员工薪资信息实例</returns>
        public WorkerSalaryMsgInfo GetWorkerSalaryMsgByObjectID(string objectID, string boName = BoName)
        {
            WorkerSalaryMsgCtrl _ctrl = new WorkerSalaryMsgCtrl();
            List<WorkerSalaryMsgInfo> lstApplys = _ctrl.SelectAsList(boName, "ObjectID='" + objectID + "'");
            if (lstApplys.Count == 0)
            {
                return null;
            }

            return lstApplys[0];
        }

        /// <summary>
        /// 根据查询条件获取员工薪资信息实例集合
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>员工薪资信息实例集合</returns>
        public List<WorkerSalaryMsgInfo> GetWorkerSalaryMsgByCondition(string condition, string boName = BoName)
        {
            WorkerSalaryMsgCtrl _ctrl = new WorkerSalaryMsgCtrl();
            return _ctrl.SelectAsList(boName, condition);
        }

        /// <summary>
        /// 添加新薪资信息
        /// </summary>
        /// <param name="info">薪资信息实体</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>操作结果</returns>
        public int AddNewSalaryMsg(SalaryMsgInfo info, string boName = BoName)
        {
            SalaryMsgCtrl _ctrl = new SalaryMsgCtrl();
            return _ctrl.Insert(boName, info);
        }

        /// <summary>
        /// 更新薪资信息
        /// </summary>
        /// <param name="info">薪资信息实例</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>操作结果</returns>
        public int UpdateSalaryMsg(SalaryMsgInfo info, string boName = BoName)
        {
            SalaryMsgCtrl _ctrl = new SalaryMsgCtrl();
            return _ctrl.UpDate(boName, info);
        }

        /// <summary>
        /// 根据ID获取薪资信息实例
        /// </summary>
        /// <param name="objectID">ID</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>薪资信息实例</returns>
        public SalaryMsgInfo GetSalaryMsgByObjectID(string objectID, string boName = BoName)
        {
            SalaryMsgCtrl _ctrl = new SalaryMsgCtrl();
            List<SalaryMsgInfo> lstApplys = _ctrl.SelectAsList(boName, "ObjectID='" + objectID + "'");
            if (lstApplys.Count == 0)
            {
                return null;
            }

            return lstApplys[0];
        }

        /// <summary>
        /// 根据查询条件获取薪资信息实例集合
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>薪资信息实例集合</returns>
        public List<SalaryMsgInfo> GetSalaryMsgByCondition(string condition, string boName = BoName)
        {
            SalaryMsgCtrl _ctrl = new SalaryMsgCtrl();
            return _ctrl.SelectAsList(boName, condition);
        }

        /// <summary>
        /// 添加新薪资审批信息
        /// </summary>
        /// <param name="info">薪资审批信息实体</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>操作结果</returns>
        public int AddNewSalaryCheck(SalaryCheckInfo info, string boName = BoName)
        {
            SalaryCheckCtrl _ctrl = new SalaryCheckCtrl();
            return _ctrl.Insert(boName, info);
        }

        /// <summary>
        /// 更新薪资审批信息
        /// </summary>
        /// <param name="info">薪资审批信息实例</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>操作结果</returns>
        public int UpdateSalaryCheck(SalaryCheckInfo info, string boName = BoName)
        {
            SalaryCheckCtrl _ctrl = new SalaryCheckCtrl();
            return _ctrl.UpDate(boName, info);
        }

        /// <summary>
        /// 根据ID获取薪资审批信息实例
        /// </summary>
        /// <param name="objectID">ID</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>薪资审批信息实例</returns>
        public SalaryCheckInfo GetSalaryCheckByObjectID(string objectID, string boName = BoName)
        {
            SalaryCheckCtrl _ctrl = new SalaryCheckCtrl();
            List<SalaryCheckInfo> lstApplys = _ctrl.SelectAsList(boName, "ObjectID='" + objectID + "'");
            if (lstApplys.Count == 0)
            {
                return null;
            }

            return lstApplys[0];
        }

        /// <summary>
        /// 根据查询条件获取薪资审批信息实例集合
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>薪资审批信息实例集合</returns>
        public List<SalaryCheckInfo> GetSalaryCheckByCondition(string condition, string boName = BoName)
        {
            SalaryCheckCtrl _ctrl = new SalaryCheckCtrl();
            return _ctrl.SelectAsList(boName, condition);
        }

        /// <summary>
        /// 添加新加薪信息
        /// </summary>
        /// <param name="info">加薪信息实体</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>操作结果</returns>
        public int AddNewAddSalary(AddSalaryInfo info, string boName = BoName)
        {
            AddSalaryCtrl _ctrl = new AddSalaryCtrl();
            return _ctrl.Insert(boName, info);
        }

        /// <summary>
        /// 更新加薪信息
        /// </summary>
        /// <param name="info">加薪信息实例</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>操作结果</returns>
        public int UpdateAddSalary(AddSalaryInfo info, string boName = BoName)
        {
            AddSalaryCtrl _ctrl = new AddSalaryCtrl();
            return _ctrl.UpDate(boName, info);
        }

        /// <summary>
        /// 根据ID获取加薪信息实例
        /// </summary>
        /// <param name="objectID">ID</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>加薪信息实例</returns>
        public AddSalaryInfo GetAddSalaryByObjectID(string objectID, string boName = BoName)
        {
            AddSalaryCtrl _ctrl = new AddSalaryCtrl();
            List<AddSalaryInfo> lstApplys = _ctrl.SelectAsList(boName, "ObjectID='" + objectID + "'");
            if (lstApplys.Count == 0)
            {
                return null;
            }

            return lstApplys[0];
        }

        /// <summary>
        /// 根据查询条件获取加薪信息实例集合
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>加薪信息实例集合</returns>
        public List<AddSalaryInfo> GetAddSalaryByCondition(string condition, string boName = BoName)
        {
            AddSalaryCtrl _ctrl = new AddSalaryCtrl();
            return _ctrl.SelectAsList(boName, condition);
        }
    }
}
