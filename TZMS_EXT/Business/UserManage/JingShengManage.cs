using System;
using System.Collections.Generic;
using System.Text;
using com.TZMS.Model;
using com.TZMS.DataAccess;

namespace com.TZMS.Business
{
    public class JingShengManage : ParentManage
    {
        public JingShengManage()
        { }

        /// <summary>
        /// 添加新申请单
        /// </summary>
        /// <param name="info">申请单实体</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>操作结果</returns>
        public int AddNewApply(JingShengApplyInfo info, string boName = BoName)
        {
            JingShengApplyCtrl _ctrl = new JingShengApplyCtrl();
            return _ctrl.Insert(boName, info);
        }

        /// <summary>
        /// 更新申请单
        /// </summary>
        /// <param name="info">申请单实例</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>操作结果</returns>
        public int UpdateApply(JingShengApplyInfo info, string boName = BoName)
        {
            JingShengApplyCtrl _ctrl = new JingShengApplyCtrl();
            return _ctrl.UpDate(boName, info);
        }

        /// <summary>
        /// 根据ID获取申请单实例
        /// </summary>
        /// <param name="objectID">ID</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>申请单实例</returns>
        public JingShengApplyInfo GetApplyByObjectID(string objectID, string boName = BoName)
        {
            JingShengApplyCtrl _ctrl = new JingShengApplyCtrl();
            List<JingShengApplyInfo> lstApplys = _ctrl.SelectAsList(boName, "ObjectID='" + objectID + "'");
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
        public List<JingShengApplyInfo> GetApplyByCondition(string condition, string boName = BoName)
        {
            JingShengApplyCtrl _ctrl = new JingShengApplyCtrl();
            return _ctrl.SelectAsList(boName, condition);
        }

        /// <summary>
        /// 添加新申请单流程
        /// </summary>
        /// <param name="info">申请单流程实体</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>操作结果</returns>
        public int AddNewApprove(JingShengApproveInfo info, string boName = BoName)
        {
            JingShengApproveCtrl _ctrl = new JingShengApproveCtrl();
            return _ctrl.Insert(boName, info);
        }

        /// <summary>
        /// 更新申请单流程
        /// </summary>
        /// <param name="info">申请单流程实例</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>操作结果</returns>
        public int UpdateApprove(JingShengApproveInfo info, string boName = BoName)
        {
            JingShengApproveCtrl _ctrl = new JingShengApproveCtrl();
            return _ctrl.UpDate(boName, info);
        }

        /// <summary>
        /// 根据ID获取申请单流程实例
        /// </summary>
        /// <param name="objectID">ID</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>申请单流程实例</returns>
        public JingShengApproveInfo GetApproveByObjectID(string objectID, string boName = BoName)
        {
            JingShengApproveCtrl _ctrl = new JingShengApproveCtrl();
            List<JingShengApproveInfo> lstApproves = _ctrl.SelectAsList(boName, "ObjectID='" + objectID + "'");
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
        public List<JingShengApproveInfo> GetApproveByCondition(string condition, string boName = BoName)
        {
            JingShengApproveCtrl _ctrl = new JingShengApproveCtrl();
            return _ctrl.SelectAsList(boName, condition);
        }
    }
}
