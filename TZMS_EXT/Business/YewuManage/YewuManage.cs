using System;
using System.Collections.Generic;
using System.Text;
using com.TZMS.Model;
using com.TZMS.DataAccess;

namespace com.TZMS.Business
{
    public class YewuManage : ParentManage
    {
        /// <summary>
        /// 默认构造函数
        /// </summary>
        public YewuManage()
        {

        }

        #region 业务

        /// <summary>
        /// 添加一条新业务记录（业务单和流程）
        /// </summary>
        /// <param name="yewu"></param>
        /// <param name="yewuDoing"></param>
        /// <param name="boName"></param>
        public void AddYeWu(YeWuInfo yewu, YeWuGudingDoingInfo yewuDoing, string boName = BoName)
        {
            YeWuCtrl yewuCtrl = new YeWuCtrl();
            YeWuGudingDoingCtrl yeWudongCtrl = new YeWuGudingDoingCtrl();
            yewuCtrl.Insert(boName, yewu);
            yeWudongCtrl.Insert(boName, yewuDoing);
        }

        /// <summary>
        /// 添加记录表
        /// </summary>
        /// <param name="list"></param>
        /// <param name="boName"></param>
        public void AddRecord(List<YeWuGudingDoingInfo> list, string boName = BoName)
        {
            YeWuGudingDoingCtrl yeWudongCtrl = new YeWuGudingDoingCtrl();
            foreach (YeWuGudingDoingInfo info in list)
            {
                yeWudongCtrl.Insert(boName, info);
            }
        }

        /// <summary>
        /// 返回List
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="boName"></param>
        /// <returns>List</returns>
        public List<YeWuInfo> GetYeWuForList(string condition, string boName = BoName)
        {
            List<YeWuInfo> list = new List<YeWuInfo>();

            YeWuCtrl yewuCtrl = new YeWuCtrl();
            list = yewuCtrl.SelectAsList(boName, condition);
            return list;
        }

        /// <summary>
        /// 返回单个对象
        /// </summary>
        /// <param name="objectID"></param>
        /// <param name="boName"></param>
        /// <returns>List</returns>
        public YeWuInfo GetYeWuForObject(string objectID, string boName = BoName)
        {
            List<YeWuInfo> list = new List<YeWuInfo>();

            YeWuCtrl yewuCtrl = new YeWuCtrl();
            list = yewuCtrl.SelectAsList(boName, " ObjectID ='" + objectID + "' and isdelete=0");
            return list[0];
        }

        /// <summary>
        /// 返回单个对象
        /// </summary>
        /// <param name="objectID"></param>
        /// <param name="boName"></param>
        /// <returns>List</returns>
        public YeWuGudingDoingInfo GetYeWuDoingForObject(string condition, string boName = BoName)
        {
            List<YeWuGudingDoingInfo> list = new List<YeWuGudingDoingInfo>();

            YeWuGudingDoingCtrl yewuCtrl = new YeWuGudingDoingCtrl();
            list = yewuCtrl.SelectAsList(boName, condition);
            return list[0];
        }

        /// <summary>
        /// 返回List
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="boName"></param>
        /// <returns>List</returns>
        public List<YeWuGudingDoingInfo> GetYeWuDoingForList(string condition, string boName = BoName)
        {
            List<YeWuGudingDoingInfo> list = new List<YeWuGudingDoingInfo>();

            YeWuGudingDoingCtrl yewuCtrl = new YeWuGudingDoingCtrl();
            list = yewuCtrl.SelectAsList(boName, condition);
            return list;
        }

        /// <summary>
        /// 更新YeWuInfo
        /// </summary>
        /// <param name="info"></param>
        /// <param name="boName"></param>
        public void SaveYeWu(YeWuInfo info, string boName = BoName)
        {
            YeWuCtrl yewuCtrl = new YeWuCtrl();
            yewuCtrl.UpDate(boName, info);
        }

        /// <summary>
        /// 更新YeWuInfo
        /// </summary>
        /// <param name="info"></param>
        /// <param name="boName"></param>
        public void SaveYeWuDoing(YeWuGudingDoingInfo info, string boName = BoName)
        {
            YeWuGudingDoingCtrl yewuCtrl = new YeWuGudingDoingCtrl();
            yewuCtrl.UpDate(boName, info);
        }

        #endregion

        #region 备用金

        /// <summary>
        /// 添加新申请单
        /// </summary>
        /// <param name="info">申请单实体</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>操作结果</returns>
        public int AddNewImprestApply(ImprestApplyInfo info, string boName = BoName)
        {
            ImprestApplyCtrl _ctrl = new ImprestApplyCtrl();
            return _ctrl.Insert(boName, info);
        }

        /// <summary>
        /// 更新申请单
        /// </summary>
        /// <param name="info">申请单实例</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>操作结果</returns>
        public int UpdateImprestApply(ImprestApplyInfo info, string boName = BoName)
        {
            ImprestApplyCtrl _ctrl = new ImprestApplyCtrl();
            return _ctrl.UpDate(boName, info);
        }

        /// <summary>
        /// 根据ID获取申请单实例
        /// </summary>
        /// <param name="objectID">ID</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>申请单实例</returns>
        public ImprestApplyInfo GetImprestApplyByObjectID(string objectID, string boName = BoName)
        {
            ImprestApplyCtrl _ctrl = new ImprestApplyCtrl();
            List<ImprestApplyInfo> lstApplys = _ctrl.SelectAsList(boName, "ObjectID='" + objectID + "'");
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
        public List<ImprestApplyInfo> GetImprestApplyByCondition(string condition, string boName = BoName)
        {
            ImprestApplyCtrl _ctrl = new ImprestApplyCtrl();
            return _ctrl.SelectAsList(boName, condition);
        }

        /// <summary>
        /// 添加新申请单流程
        /// </summary>
        /// <param name="info">申请单流程实体</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>操作结果</returns>
        public int AddNewImprestApprove(ImprestApproveInfo info, string boName = BoName)
        {
            ImprestApproveCtrl _ctrl = new ImprestApproveCtrl();
            return _ctrl.Insert(boName, info);
        }

        /// <summary>
        /// 更新申请单流程
        /// </summary>
        /// <param name="info">申请单流程实例</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>操作结果</returns>
        public int UpdateImprestApprove(ImprestApproveInfo info, string boName = BoName)
        {
            ImprestApproveCtrl _ctrl = new ImprestApproveCtrl();
            return _ctrl.UpDate(boName, info);
        }

        /// <summary>
        /// 根据ID获取申请单流程实例
        /// </summary>
        /// <param name="objectID">ID</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>申请单流程实例</returns>
        public ImprestApproveInfo GetImprestApproveByObjectID(string objectID, string boName = BoName)
        {
            ImprestApproveCtrl _ctrl = new ImprestApproveCtrl();
            List<ImprestApproveInfo> lstApproves = _ctrl.SelectAsList(boName, "ObjectID='" + objectID + "'");
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
        public List<ImprestApproveInfo> GetImprestApproveByCondition(string condition, string boName = BoName)
        {
            ImprestApproveCtrl _ctrl = new ImprestApproveCtrl();
            return _ctrl.SelectAsList(boName, condition);
        }

        #endregion
    }
}
