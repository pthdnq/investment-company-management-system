using System;
using System.Collections.Generic;
using System.Text;
using com.TZMS.Model;
using com.TZMS.DataAccess;

namespace com.TZMS.Business
{
    public class ProxyAccountingManage : ParentManage
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public ProxyAccountingManage()
        { }

        /// <summary>
        /// 添加新单位
        /// </summary>
        /// <param name="info">新单位实体</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>操作结果</returns>
        public int AddNewUnit(ProxyAccountingUnitInfo info, string boName = BoName)
        {
            ProxyAccountingUnitCtrl _ctrl = new ProxyAccountingUnitCtrl();
            return _ctrl.Insert(boName, info);
        }

        /// <summary>
        /// 更新单位
        /// </summary>
        /// <param name="info">单位实例</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>操作结果</returns>
        public int UpdateUnit(ProxyAccountingUnitInfo info, string boName = BoName)
        {
            ProxyAccountingUnitCtrl _ctrl = new ProxyAccountingUnitCtrl();
            return _ctrl.UpDate(boName, info);
        }

        /// <summary>
        /// 根据ID获取单位实例
        /// </summary>
        /// <param name="objectID">ID</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>单位实例</returns>
        public ProxyAccountingUnitInfo GetUnitByObjectID(string objectID, string boName = BoName)
        {
            ProxyAccountingUnitCtrl _ctrl = new ProxyAccountingUnitCtrl();
            List<ProxyAccountingUnitInfo> lstUnits = _ctrl.SelectAsList(boName, "ObjectID='" + objectID + "'");
            if (lstUnits.Count == 0)
            {
                return null;
            }

            return lstUnits[0];
        }

        /// <summary>
        /// 根据查询条件获取单位实例集合
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>单位实例集合</returns>
        public List<ProxyAccountingUnitInfo> GetUnitByCondition(string condition, string boName = BoName)
        {
            ProxyAccountingUnitCtrl _ctrl = new ProxyAccountingUnitCtrl();
            return _ctrl.SelectAsList(boName, condition);
        }

        /// <summary>
        /// 添加新申请
        /// </summary>
        /// <param name="info">申请实例</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>操作结果</returns>
        public int AddNewApply(ProxyAccountingApplyInfo info, string boName = BoName)
        {
            ProxyAccountingApplyCtrl _ctrl = new ProxyAccountingApplyCtrl();
            return _ctrl.Insert(boName, info);
        }

        /// <summary>
        /// 更新申请
        /// </summary>
        /// <param name="info">申请实例</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>操作结果</returns>
        public int UpdateApply(ProxyAccountingApplyInfo info, string boName = BoName)
        {
            ProxyAccountingApplyCtrl _ctrl = new ProxyAccountingApplyCtrl();
            return _ctrl.UpDate(boName, info);
        }

        /// <summary>
        /// 根据ID获取申请实例
        /// </summary>
        /// <param name="objectID">申请实例</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>申请实例</returns>
        public ProxyAccountingApplyInfo GetApplyByObjectID(string objectID, string boName = BoName)
        {
            ProxyAccountingApplyCtrl _ctrl = new ProxyAccountingApplyCtrl();
            List<ProxyAccountingApplyInfo> lstApplys = _ctrl.SelectAsList(boName, "ObjectID='" + objectID + "'");
            if (lstApplys.Count == 0)
            {
                return null;
            }

            return lstApplys[0];
        }

        /// <summary>
        /// 根据查询条件获取申请实例集合
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>申请实例集合</returns>
        public List<ProxyAccountingApplyInfo> GetApplyByCondition(string condition, string boName = BoName)
        {
            ProxyAccountingApplyCtrl _ctrl = new ProxyAccountingApplyCtrl();
            return _ctrl.SelectAsList(boName, condition);
        }

        /// <summary>
        /// 添加新审批
        /// </summary>
        /// <param name="info">审批实例</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>操作结果</returns>
        public int AddNewApprove(ProxyAccountingApproveInfo info, string boName = BoName)
        {
            ProxyAccountingApproveCtrl _ctrl = new ProxyAccountingApproveCtrl();
            return _ctrl.Insert(boName, info);
        }

        /// <summary>
        /// 更新审批
        /// </summary>
        /// <param name="info">审批实例</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>操作结果</returns>
        public int UpdateApprove(ProxyAccountingApproveInfo info, string boName = BoName)
        {
            ProxyAccountingApproveCtrl _ctrl = new ProxyAccountingApproveCtrl();
            return _ctrl.UpDate(boName, info);
        }
        
        /// <summary>
        /// 根据ID获取审批实例
        /// </summary>
        /// <param name="objectID">ID</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>审批实例</returns>
        public ProxyAccountingApproveInfo GetApproveByObjectID(string objectID, string boName = BoName)
        {
            ProxyAccountingApproveCtrl _ctrl = new ProxyAccountingApproveCtrl();
            List<ProxyAccountingApproveInfo> lstApproves = _ctrl.SelectAsList(boName, "ObjectID='" + objectID + "'");
            if (lstApproves.Count == 0)
            {
                return null;
            }

            return lstApproves[0];
        }

        /// <summary>
        /// 根据查询条件获取审批实例集合
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>审批实例集合</returns>
        public List<ProxyAccountingApproveInfo> GetApproveByCondition(string condition, string boName = BoName)
        {
            ProxyAccountingApproveCtrl _ctrl = new ProxyAccountingApproveCtrl();
            return _ctrl.SelectAsList(boName, condition);
        }

    }
}
