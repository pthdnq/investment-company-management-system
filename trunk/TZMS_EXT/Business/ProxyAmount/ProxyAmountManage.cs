using System;
using System.Collections.Generic;
using System.Text;
using com.TZMS.Model;
using com.TZMS.DataAccess;

namespace com.TZMS.Business.ProxyAmount
{
    public class ProxyAmountManage : ParentManage
    {
        public ProxyAmountManage()
        { }

        /// <summary>
        /// 添加新单位
        /// </summary>
        /// <param name="info">新单位实体</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>操作结果</returns>
        public int AddNewUnit(ProxyAmountUnitInfo info, string boName = BoName)
        {
            ProxyAmountUnitCtrl _ctrl = new ProxyAmountUnitCtrl();
            return _ctrl.Insert(boName, info);
        }

        /// <summary>
        /// 更新单位
        /// </summary>
        /// <param name="info">单位实例</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>操作结果</returns>
        public int UpdateUnit(ProxyAmountUnitInfo info, string boName = BoName)
        {
            ProxyAmountUnitCtrl _ctrl = new ProxyAmountUnitCtrl();
            return _ctrl.UpDate(boName, info);
        }

        /// <summary>
        /// 根据ID获取单位实例
        /// </summary>
        /// <param name="objectID">ID</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>单位实例</returns>
        public ProxyAmountUnitInfo GetUnitByObjectID(string objectID, string boName = BoName)
        {
            ProxyAmountUnitCtrl _ctrl = new ProxyAmountUnitCtrl();
            List<ProxyAmountUnitInfo> lstUnits = _ctrl.SelectAsList(boName, "ObjectID='" + objectID + "'");
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
        public List<ProxyAmountUnitInfo> GetUnitByCondition(string condition, string boName = BoName)
        {
            ProxyAmountUnitCtrl _ctrl = new ProxyAmountUnitCtrl();
            return _ctrl.SelectAsList(boName, condition);
        }

        /// <summary>
        /// 添加新单位
        /// </summary>
        /// <param name="info">新单位实体</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>操作结果</returns>
        public int AddNewTemplateApply(ProxyAmountTemplateApplyInfo info, string boName = BoName)
        {
            ProxyAmountTemplateApplyCtrl _ctrl = new ProxyAmountTemplateApplyCtrl();
            return _ctrl.Insert(boName, info);
        }

        /// <summary>
        /// 更新单位
        /// </summary>
        /// <param name="info">单位实例</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>操作结果</returns>
        public int UpdateTemplateApply(ProxyAmountTemplateApplyInfo info, string boName = BoName)
        {
            ProxyAmountTemplateApplyCtrl _ctrl = new ProxyAmountTemplateApplyCtrl();
            return _ctrl.UpDate(boName, info);
        }

        /// <summary>
        /// 根据ID获取单位实例
        /// </summary>
        /// <param name="objectID">ID</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>单位实例</returns>
        public ProxyAmountTemplateApplyInfo GetTemplateApplyByObjectID(string objectID, string boName = BoName)
        {
            ProxyAmountTemplateApplyCtrl _ctrl = new ProxyAmountTemplateApplyCtrl();
            List<ProxyAmountTemplateApplyInfo> lstUnits = _ctrl.SelectAsList(boName, "ObjectID='" + objectID + "'");
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
        public List<ProxyAmountTemplateApplyInfo> GetTemplateApplyByCondition(string condition, string boName = BoName)
        {
            ProxyAmountTemplateApplyCtrl _ctrl = new ProxyAmountTemplateApplyCtrl();
            return _ctrl.SelectAsList(boName, condition);
        }

        /// <summary>
        /// 添加新单位
        /// </summary>
        /// <param name="info">新单位实体</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>操作结果</returns>
        public int AddNewTemplateApprove(ProxyAmountTemplateApproveInfo info, string boName = BoName)
        {
            ProxyAmountTemplateApproveCtrl _ctrl = new ProxyAmountTemplateApproveCtrl();
            return _ctrl.Insert(boName, info);
        }

        /// <summary>
        /// 更新单位
        /// </summary>
        /// <param name="info">单位实例</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>操作结果</returns>
        public int UpdateTemplateApprove(ProxyAmountTemplateApproveInfo info, string boName = BoName)
        {
            ProxyAmountTemplateApproveCtrl _ctrl = new ProxyAmountTemplateApproveCtrl();
            return _ctrl.UpDate(boName, info);
        }

        /// <summary>
        /// 根据ID获取单位实例
        /// </summary>
        /// <param name="objectID">ID</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>单位实例</returns>
        public ProxyAmountTemplateApproveInfo GetTemplateApproveByObjectID(string objectID, string boName = BoName)
        {
            ProxyAmountTemplateApproveCtrl _ctrl = new ProxyAmountTemplateApproveCtrl();
            List<ProxyAmountTemplateApproveInfo> lstUnits = _ctrl.SelectAsList(boName, "ObjectID='" + objectID + "'");
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
        public List<ProxyAmountTemplateApproveInfo> GetTemplateApproveByCondition(string condition, string boName = BoName)
        {
            ProxyAmountTemplateApproveCtrl _ctrl = new ProxyAmountTemplateApproveCtrl();
            return _ctrl.SelectAsList(boName, condition);
        }

        /// <summary>
        /// 添加新单位
        /// </summary>
        /// <param name="info">新单位实体</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>操作结果</returns>
        public int AddNewProxyAmount(ProxyAmountInfo info, string boName = BoName)
        {
            ProxyAmountCtrl _ctrl = new ProxyAmountCtrl();
            return _ctrl.Insert(boName, info);
        }

        /// <summary>
        /// 更新单位
        /// </summary>
        /// <param name="info">单位实例</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>操作结果</returns>
        public int UpdateProxyAmount(ProxyAmountInfo info, string boName = BoName)
        {
            ProxyAmountCtrl _ctrl = new ProxyAmountCtrl();
            return _ctrl.UpDate(boName, info);
        }

        /// <summary>
        /// 根据ID获取单位实例
        /// </summary>
        /// <param name="objectID">ID</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>单位实例</returns>
        public ProxyAmountInfo GetProxyAmountByObjectID(string objectID, string boName = BoName)
        {
            ProxyAmountCtrl _ctrl = new ProxyAmountCtrl();
            List<ProxyAmountInfo> lstUnits = _ctrl.SelectAsList(boName, "ObjectID='" + objectID + "'");
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
        public List<ProxyAmountInfo> GetProxyAmountByCondition(string condition, string boName = BoName)
        {
            ProxyAmountCtrl _ctrl = new ProxyAmountCtrl();
            return _ctrl.SelectAsList(boName, condition);
        }
    }
}
