using System;
using System.Collections.Generic;
using System.Text;
using com.TZMS.Model;
using com.TZMS.DataAccess;

namespace com.TZMS.Business
{
    public class ProbationManage : ParentManage
    {
        public ProbationManage()
        { }

        /// <summary>
        /// 添加新申请单
        /// </summary>
        /// <param name="info">申请单实体</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>操作结果</returns>
        public int AddNewProbationApply(ProbationApplyInfo info, string boName = BoName)
        {
            ProbationApplyCtrl _ctrl = new ProbationApplyCtrl();
            return _ctrl.Insert(boName, info);
        }

        /// <summary>
        /// 更新申请单
        /// </summary>
        /// <param name="info">申请单实例</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>操作结果</returns>
        public int UpdateApply(ProbationApplyInfo info, string boName = BoName)
        {
            ProbationApplyCtrl _ctrl = new ProbationApplyCtrl();
            return _ctrl.UpDate(boName, info);
        }

        /// <summary>
        /// 根据用户ID获取转正申请单
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>转正申请单实例</returns>
        public ProbationApplyInfo GetApplyByUserID(string userID, string boName = BoName)
        {
            ProbationApplyCtrl _ctrl = new ProbationApplyCtrl();
            List<ProbationApplyInfo> lstApplys = _ctrl.SelectAsList(boName, " UserID = '" + userID + "'");
            if (lstApplys.Count == 0)
            {
                return null;
            }

            return lstApplys[0];
        }

        /// <summary>
        /// 根据ID获取申请单实例
        /// </summary>
        /// <param name="objectID">ID</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>申请单实例</returns>
        public ProbationApplyInfo GetApplyByObjectID(string objectID, string boName = BoName)
        {
            ProbationApplyCtrl _ctrl = new ProbationApplyCtrl();
            List<ProbationApplyInfo> lstApplys = _ctrl.SelectAsList(boName, "ObjectID='" + objectID + "'");
            if (lstApplys.Count == 0)
            {
                return null;
            }

            return lstApplys[0];
        }

        /// <summary>
        /// 根据查询条件获取申请单实例集合
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>申请单实例集合</returns>
        public List<ProbationApplyInfo> GetApplyByCondition(string condition, string boName = BoName)
        {
            ProbationApplyCtrl _ctrl = new ProbationApplyCtrl();
            return _ctrl.SelectAsList(boName, condition);
        }

        /// <summary>
        /// 添加新申请单流程
        /// </summary>
        /// <param name="info">申请单流程实体</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>操作结果</returns>
        public int AddNewProbationApprove(ProbationApproveInfo info, string boName = BoName)
        {
            ProbationApproveCtrl _ctrl = new ProbationApproveCtrl();
            return _ctrl.Insert(boName, info);
        }

        /// <summary>
        /// 更新申请单流程
        /// </summary>
        /// <param name="info">申请单流程实例</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>操作结果</returns>
        public int UpdateApprove(ProbationApproveInfo info, string boName = BoName)
        {
            ProbationApproveCtrl _ctrl = new ProbationApproveCtrl();
            return _ctrl.UpDate(boName, info);
        }

        /// <summary>
        /// 根据ID获取申请单流程实例
        /// </summary>
        /// <param name="objectID">ID</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>申请单流程实例</returns>
        public ProbationApproveInfo GetApproveByObjectID(string objectID, string boName = BoName)
        {
            ProbationApproveCtrl _ctrl = new ProbationApproveCtrl();
            List<ProbationApproveInfo> lstApproves = _ctrl.SelectAsList(boName, "ObjectID='" + objectID + "'");
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
        public List<ProbationApproveInfo> GetApproveByCondition(string condition, string boName = BoName)
        {
            ProbationApproveCtrl _ctrl = new ProbationApproveCtrl();
            return _ctrl.SelectAsList(boName, condition);
        }
    }
}
