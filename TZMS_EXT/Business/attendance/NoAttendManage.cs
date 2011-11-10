using System;
using System.Collections.Generic;
using System.Text;
using com.TZMS.Model;
using com.TZMS.DataAccess;


namespace com.TZMS.Business
{
    public class NoAttendManage : ParentManage
    {
        /// <summary>
        /// 默认构造函数
        /// </summary>
        public NoAttendManage()
        { }

        /// <summary>
        /// 插入新的未打卡记录到数据库
        /// </summary>
        /// <param name="noAttendInfo">未打卡记录实例</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>执行结果</returns>
        public int AddNewNoAttendInfo(NoAttendInfo noAttendInfo, string boName = BoName)
        {
            NoAttendCtrl _ctrl = new NoAttendCtrl();
            return _ctrl.Insert(boName, noAttendInfo);
        }

        /// <summary>
        /// 更新未打卡记录
        /// </summary>
        /// <param name="noAttendInfo">未打卡记录实例</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>操作结果</returns>
        public int UpdateNoAttendInfo(NoAttendInfo noAttendInfo, string boName = BoName)
        {
            NoAttendCtrl _ctrl = new NoAttendCtrl();
            return _ctrl.UpDate(boName, noAttendInfo);
        }

        /// <summary>
        /// 根据ObjectID获取指定的未打卡记录实例
        /// </summary>
        /// <param name="objectID">ObjectID</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>未打卡记录实例</returns>
        public NoAttendInfo GetNoAttendInfoByObjectID(string objectID, string boName = BoName)
        {
            NoAttendCtrl _ctrl = new NoAttendCtrl();
            List<NoAttendInfo> lstNoAttendInfo = _ctrl.SelectAsList(boName, "ObjectID = '" + objectID + "'");
            if (lstNoAttendInfo.Count == 0)
            {
                return null;
            }
            return lstNoAttendInfo[0];
        }

        /// <summary>
        /// 根据查询条件获取未打卡记录实例集合
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>未打卡记录实例集合</returns>
        public List<NoAttendInfo> GetNoAttendInfoByCondition(string condition, string boName = BoName)
        {
            NoAttendCtrl _ctrl = new NoAttendCtrl();
            return _ctrl.SelectAsList(boName, condition);
        }

        /// <summary>
        /// 插入未打卡审批记录到数据库
        /// </summary>
        /// <param name="noAttendCheckInfo">未打卡审批实例</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>执行结果</returns>
        public int AddNewNoAttendCheckInfo(NoAttendCheckInfo noAttendCheckInfo, string boName = BoName)
        {
            NoAttendCheckCtrl _ctrl = new NoAttendCheckCtrl();
            return _ctrl.Insert(boName, noAttendCheckInfo);
        }

        /// <summary>
        /// 更新未打卡审批记录
        /// </summary>
        /// <param name="noAttendCheckInfo">未打卡审批实例</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>执行结果</returns>
        public int UpdateNoAttendCheckInfo(NoAttendCheckInfo noAttendCheckInfo, string boName = BoName)
        {
            NoAttendCheckCtrl _ctrl = new NoAttendCheckCtrl();
            return _ctrl.UpDate(boName, noAttendCheckInfo);
        }

        /// <summary>
        /// 根据ObjectID获取指定的未打卡审批实例
        /// </summary>
        /// <param name="objectID">ObjectID</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>未打卡审批实例</returns>
        public NoAttendCheckInfo GetNoAttendCheckInfoByObjectID(string objectID, string boName = BoName)
        {
            NoAttendCheckCtrl _ctrl = new NoAttendCheckCtrl();
            List<NoAttendCheckInfo> lstCheckInfo = _ctrl.SelectAsList(boName, "ObjectID = '" + objectID + "'");
            if (lstCheckInfo.Count == 0)
            {
                return null;
            }

            return lstCheckInfo[0];
        }

        /// <summary>
        /// 根据指定的查询条件获取未打卡审批集合
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>未打卡审批集合</returns>
        public List<NoAttendCheckInfo> GetNoAttendCheckInfoByCondition(string condition, string boName = BoName)
        {
            NoAttendCheckCtrl _ctrl = new NoAttendCheckCtrl();
            return _ctrl.SelectAsList(boName, condition);
        }
    }
}
