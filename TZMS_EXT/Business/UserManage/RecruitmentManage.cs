using System;
using System.Collections.Generic;
using System.Text;
using com.TZMS.Model;
using com.TZMS.DataAccess;

namespace com.TZMS.Business
{
    public class RecruitmentManage : ParentManage
    {
        public RecruitmentManage()
        { }

        /// <summary>
        /// 添加新申请单
        /// </summary>
        /// <param name="info">申请单实体</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>操作结果</returns>
        public int AddNewApply(RecruitmentApplyInfo info, string boName = BoName)
        {
            RecruitmentApplyCtrl _ctrl = new RecruitmentApplyCtrl();
            return _ctrl.Insert(boName, info);
        }

        /// <summary>
        /// 更新申请单
        /// </summary>
        /// <param name="info">申请单实例</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>操作结果</returns>
        public int UpdateApply(RecruitmentApplyInfo info, string boName = BoName)
        {
            RecruitmentApplyCtrl _ctrl = new RecruitmentApplyCtrl();
            return _ctrl.UpDate(boName, info);
        }

        /// <summary>
        /// 根据ID获取申请单实例
        /// </summary>
        /// <param name="objectID">ID</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>申请单实例</returns>
        public RecruitmentApplyInfo GetApplyByObjectID(string objectID, string boName = BoName)
        {
            RecruitmentApplyCtrl _ctrl = new RecruitmentApplyCtrl();
            List<RecruitmentApplyInfo> lstApplys = _ctrl.SelectAsList(boName, "ObjectID='" + objectID + "'");
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
        public List<RecruitmentApplyInfo> GetApplyByCondition(string condition, string boName = BoName)
        {
            RecruitmentApplyCtrl _ctrl = new RecruitmentApplyCtrl();
            return _ctrl.SelectAsList(boName, condition);
        }

        /// <summary>
        /// 添加新申请单流程
        /// </summary>
        /// <param name="info">申请单流程实体</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>操作结果</returns>
        public int AddNewApprove(RecruitmentApproveInfo info, string boName = BoName)
        {
            RecruitmentApproveCtrl _ctrl = new RecruitmentApproveCtrl();
            return _ctrl.Insert(boName, info);
        }

        /// <summary>
        /// 更新申请单流程
        /// </summary>
        /// <param name="info">申请单流程实例</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>操作结果</returns>
        public int UpdateApprove(RecruitmentApproveInfo info, string boName = BoName)
        {
            RecruitmentApproveCtrl _ctrl = new RecruitmentApproveCtrl();
            return _ctrl.UpDate(boName, info);
        }

        /// <summary>
        /// 根据ID获取申请单流程实例
        /// </summary>
        /// <param name="objectID">ID</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>申请单流程实例</returns>
        public RecruitmentApproveInfo GetApproveByObjectID(string objectID, string boName = BoName)
        {
            RecruitmentApproveCtrl _ctrl = new RecruitmentApproveCtrl();
            List<RecruitmentApproveInfo> lstApproves = _ctrl.SelectAsList(boName, "ObjectID='" + objectID + "'");
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
        public List<RecruitmentApproveInfo> GetApproveByCondition(string condition, string boName = BoName)
        {
            RecruitmentApproveCtrl _ctrl = new RecruitmentApproveCtrl();
            return _ctrl.SelectAsList(boName, condition);
        }
    }
}
