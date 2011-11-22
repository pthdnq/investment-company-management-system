using System;
using System.Collections.Generic;
using System.Text;
using com.TZMS.Model;
using com.TZMS.DataAccess;

namespace com.TZMS.Business
{
    public class WuZhiManage : ParentManage
    {
        public WuZhiManage()
        { }

        /// <summary>
        /// 添加新物资
        /// </summary>
        /// <param name="info">物资实例</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>操作结果</returns>
        public int AddNewWuZhi(WuZhiInfo info, string boName = BoName)
        {
            WuZhiCtrl _ctrl = new WuZhiCtrl();
            return _ctrl.Insert(boName, info);
        }

        /// <summary>
        /// 更新物资
        /// </summary>
        /// <param name="info">物资实例</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>操作结果</returns>
        public int UpdateWuZhi(WuZhiInfo info, string boName = BoName)
        {
            WuZhiCtrl _ctrl = new WuZhiCtrl();
            return _ctrl.UpDate(boName, info);
        }

        /// <summary>
        /// 根据ObjectID获取物资实例
        /// </summary>
        /// <param name="objectID">ObjectID</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>物资实例</returns>
        public WuZhiInfo GetWuZhiByObjectID(string objectID, string boName = BoName)
        {
            WuZhiCtrl _ctrl = new WuZhiCtrl();
            List<WuZhiInfo> lstWuZhi = _ctrl.SelectAsList(boName, " ObjectID = '" + objectID + "'");
            if (lstWuZhi.Count == 0)
            {
                return null;
            }

            return lstWuZhi[0];
        }

        /// <summary>
        /// 通过查询条件获取物资实例集合
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>物资实例集合</returns>
        public List<WuZhiInfo> GetWuZhiByCondition(string condition, string boName = BoName)
        {
            WuZhiCtrl _ctrl = new WuZhiCtrl();
            return _ctrl.SelectAsList(boName, condition);
        }

        /// <summary>
        /// 添加新物资审批
        /// </summary>
        /// <param name="info">物资审批实例</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>操作结果</returns>
        public int AddNewWuZhiCheck(WuzhiCheckInfo info, string boName = BoName)
        {
            WuzhiCheckCtrl _ctrl = new WuzhiCheckCtrl();
            return _ctrl.Insert(boName, info);
        }

        /// <summary>
        /// 更新物资审批
        /// </summary>
        /// <param name="info">物资审批实例</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>操作结果</returns>
        public int UpdateWuZhiCheck(WuzhiCheckInfo info, string boName = BoName)
        {
            WuzhiCheckCtrl _ctrl = new WuzhiCheckCtrl();
            return _ctrl.UpDate(boName, info);
        }

        /// <summary>
        /// 根据ObjectID获取物资审批实例
        /// </summary>
        /// <param name="objectID">ObjectID</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>物资审批实例</returns>
        public WuzhiCheckInfo GetWuZhiCheckByObjectID(string objectID, string boName = BoName)
        {
            WuzhiCheckCtrl _ctrl = new WuzhiCheckCtrl();
            List<WuzhiCheckInfo> lstWuZhi = _ctrl.SelectAsList(boName, " ObjectID = '" + objectID + "'");
            if (lstWuZhi.Count == 0)
            {
                return null;
            }

            return lstWuZhi[0];
        }

        /// <summary>
        /// 通过查询条件获取物资审批实例集合
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>物资审批实例集合</returns>
        public List<WuzhiCheckInfo> GetWuZhiCheckByCondition(string condition, string boName = BoName)
        {
            WuzhiCheckCtrl _ctrl = new WuzhiCheckCtrl();
            return _ctrl.SelectAsList(boName, condition);
        }

        /// <summary>
        /// 添加新物资记录
        /// </summary>
        /// <param name="info">物资记录实例</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>操作结果</returns>
        public int AddNewWuZhiRecord(WuZhiRecordInfo info, string boName = BoName)
        {
            WuZhiRecordCtrl _ctrl = new WuZhiRecordCtrl();
            return _ctrl.Insert(boName, info);
        }

        /// <summary>
        /// 更新物资记录
        /// </summary>
        /// <param name="info">物资记录实例</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>操作结果</returns>
        public int UpdateWuZhiRecord(WuZhiRecordInfo info, string boName = BoName)
        {
            WuZhiRecordCtrl _ctrl = new WuZhiRecordCtrl();
            return _ctrl.UpDate(boName, info);
        }

        /// <summary>
        /// 根据ObjectID获取物资记录实例
        /// </summary>
        /// <param name="objectID">ObjectID</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>物资记录实例</returns>
        public WuZhiRecordInfo GetWuZhiRecordByObjectID(string objectID, string boName = BoName)
        {
            WuZhiRecordCtrl _ctrl = new WuZhiRecordCtrl();
            List<WuZhiRecordInfo> lstWuZhi = _ctrl.SelectAsList(boName, " ObjectID = '" + objectID + "'");
            if (lstWuZhi.Count == 0)
            {
                return null;
            }

            return lstWuZhi[0];
        }

        /// <summary>
        /// 通过查询条件获取物资记录实例集合
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>物资记录实例集合</returns>
        public List<WuZhiRecordInfo> GetWuZhiRecordByCondition(string condition, string boName = BoName)
        {
            WuZhiRecordCtrl _ctrl = new WuZhiRecordCtrl();
            return _ctrl.SelectAsList(boName, condition);
        }
    }
}
