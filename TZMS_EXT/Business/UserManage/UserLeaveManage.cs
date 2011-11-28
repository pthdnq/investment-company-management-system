using System;
using System.Collections.Generic;
using System.Text;
using com.TZMS.Model;
using com.TZMS.DataAccess;

namespace com.TZMS.Business
{
    public class UserLeaveManage : ParentManage
    {
        public UserLeaveManage()
        { }

        /// <summary>
        /// 添加新申请单流程
        /// </summary>
        /// <param name="info">申请单流程实体</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>操作结果</returns>
        public int AddNewApply(UserLeaveApplyInfo info, string boName = BoName)
        {
            UserLeaveApplyCtrl _ctrl = new UserLeaveApplyCtrl();
            return _ctrl.Insert(boName, info);
        }

        /// <summary>
        /// 更新申请单流程
        /// </summary>
        /// <param name="info">申请单流程实例</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>操作结果</returns>
        public int UpdateApply(UserLeaveApplyInfo info, string boName = BoName)
        {
            UserLeaveApplyCtrl _ctrl = new UserLeaveApplyCtrl();
            return _ctrl.UpDate(boName, info);
        }

        /// <summary>
        /// 根据用户ID获取申请单流程实例
        /// </summary>
        /// <param name="objectID">ID</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>申请单流程实例</returns>
        public UserLeaveApplyInfo GetApplyByUserID(string objectID, string boName = BoName)
        {
            UserLeaveApplyCtrl _ctrl = new UserLeaveApplyCtrl();
            List<UserLeaveApplyInfo> lstApproves = _ctrl.SelectAsList(boName, "UserID='" + objectID + "'");
            if (lstApproves.Count == 0)
            {
                return null;
            }

            return lstApproves[0];
        }

        /// <summary>
        /// 根据ID获取申请单流程实例
        /// </summary>
        /// <param name="objectID">ID</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>申请单流程实例</returns>
        public UserLeaveApplyInfo GetApplyByObjectID(string objectID, string boName = BoName)
        {
            UserLeaveApplyCtrl _ctrl = new UserLeaveApplyCtrl();
            List<UserLeaveApplyInfo> lstApproves = _ctrl.SelectAsList(boName, "ObjectID='" + objectID + "'");
            if (lstApproves.Count == 0)
            {
                return null;
            }

            return lstApproves[0];
        }

        /// <summary>
        /// 根据查询条件获取申请单流程实例集合
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>申请单流程实例集合</returns>
        public List<UserLeaveApplyInfo> GetApplyByCondition(string condition, string boName = BoName)
        {
            UserLeaveApplyCtrl _ctrl = new UserLeaveApplyCtrl();
            return _ctrl.SelectAsList(boName, condition);
        }

        /// <summary>
        /// 添加新申请单流程
        /// </summary>
        /// <param name="info">申请单流程实体</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>操作结果</returns>
        public int AddNewApprove(UserLeaveApproveInfo info, string boName = BoName)
        {
            UserLeaveApproveCtrl _ctrl = new UserLeaveApproveCtrl();
            return _ctrl.Insert(boName, info);
        }

        /// <summary>
        /// 更新申请单流程
        /// </summary>
        /// <param name="info">申请单流程实例</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>操作结果</returns>
        public int UpdateApprove(UserLeaveApproveInfo info, string boName = BoName)
        {
            UserLeaveApproveCtrl _ctrl = new UserLeaveApproveCtrl();
            return _ctrl.UpDate(boName, info);
        }

        /// <summary>
        /// 根据ID获取申请单流程实例
        /// </summary>
        /// <param name="objectID">ID</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>申请单流程实例</returns>
        public UserLeaveApproveInfo GetApproveByObjectID(string objectID, string boName = BoName)
        {
            UserLeaveApproveCtrl _ctrl = new UserLeaveApproveCtrl();
            List<UserLeaveApproveInfo> lstApproves = _ctrl.SelectAsList(boName, "ObjectID='" + objectID + "'");
            if (lstApproves.Count == 0)
            {
                return null;
            }

            return lstApproves[0];
        }

        /// <summary>
        /// 根据查询条件获取申请单流程实例集合
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>申请单流程实例集合</returns>
        public List<UserLeaveApproveInfo> GetApproveByCondition(string condition, string boName = BoName)
        {
            UserLeaveApproveCtrl _ctrl = new UserLeaveApproveCtrl();
            return _ctrl.SelectAsList(boName, condition);
        }

        /// <summary>
        /// 添加新交接
        /// </summary>
        /// <param name="info">交接实体</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>操作结果</returns>
        public int AddNewTransfer(UserLeaveTransferInfo info, string boName = BoName)
        {
            UserLeaveTransferCtrl _ctrl = new UserLeaveTransferCtrl();
            return _ctrl.Insert(boName, info);
        }

        /// <summary>
        /// 更新交接
        /// </summary>
        /// <param name="info">交接实例</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>操作结果</returns>
        public int UpdateTransfer(UserLeaveTransferInfo info, string boName = BoName)
        {
            UserLeaveTransferCtrl _ctrl = new UserLeaveTransferCtrl();
            return _ctrl.UpDate(boName, info);
        }

        /// <summary>
        /// 根据ID获取交接实例
        /// </summary>
        /// <param name="objectID">ID</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>交接实例</returns>
        public UserLeaveTransferInfo GetTransferByObjectID(string objectID, string boName = BoName)
        {
            UserLeaveTransferCtrl _ctrl = new UserLeaveTransferCtrl();
            List<UserLeaveTransferInfo> lstApproves = _ctrl.SelectAsList(boName, "ObjectID='" + objectID + "'");
            if (lstApproves.Count == 0)
            {
                return null;
            }

            return lstApproves[0];
        }

        /// <summary>
        /// 根据查询条件获取交接实例集合
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>交接实例集合</returns>
        public List<UserLeaveTransferInfo> GetTransferByCondition(string condition, string boName = BoName)
        {
            UserLeaveTransferCtrl _ctrl = new UserLeaveTransferCtrl();
            return _ctrl.SelectAsList(boName, condition);
        }
    }
}
