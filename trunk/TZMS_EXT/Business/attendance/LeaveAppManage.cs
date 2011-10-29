using System;
using System.Collections.Generic;
using System.Text;
using com.TZMS.Model;
using com.TZMS.DataAccess;

namespace com.TZMS.Business
{
    public class LeaveAppManage : ParentManage
    {
        /// <summary>
        /// 默认构造函数
        /// </summary>
        public LeaveAppManage()
        {
            //todo

        }

        /// <summary>
        /// 增加一条新的请假申请单
        /// </summary>
        /// <param name="leaveInfo">请假申请单实体</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>操作结果</returns>
        public int AddNewLeaveInfo(LeaveInfo leaveInfo, string boName = BoName)
        {
            LeaveInfoCtrl leaveCtrl = new LeaveInfoCtrl();
            return leaveCtrl.Insert(boName, leaveInfo);
        }

        /// <summary>
        /// 更新请假申请单信息
        /// </summary>
        /// <param name="leaveInfo">请假申请实体</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>操作结果</returns>
        public int UpdateLeaveInfo(LeaveInfo leaveInfo, string boName = BoName)
        {
            LeaveInfoCtrl leaveCtrl = new LeaveInfoCtrl();
            return leaveCtrl.UpDate(boName, leaveInfo);
        }

        /// <summary>
        /// 根据ObjectID来获取指定的实例
        /// </summary>
        /// <param name="objectID">ObjectID</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>请假申请单实例</returns>
        public LeaveInfo GetLeaveInfoByObjectID(string objectID, string boName = BoName)
        {
            LeaveInfoCtrl leaveCtrl = new LeaveInfoCtrl();
            List<LeaveInfo> lstLeaveApps = leaveCtrl.SelectAsList(boName, "IsDelete <> 1 and ObjectID = '" + objectID + "'");
            if (lstLeaveApps.Count == 0)
            {
                return null;
            }

            return lstLeaveApps[0];
        }

        /// <summary>
        /// 根据查询条件获取请假申请单集合
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>请假申请单集合</returns>
        public List<LeaveInfo> GetLeaveInfosByCondition(string condition, string boName = BoName)
        {
            LeaveInfoCtrl leaveCtrl = new LeaveInfoCtrl();
            return leaveCtrl.SelectAsList(boName, condition);

        }

        /// <summary>
        /// 添加一条新的请假流程信息
        /// </summary>
        /// <param name="leaveApproveInfo">请假流程实体</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>操作结果</returns>
        public int AddNewLeaveApprove(LeaveApproveInfo leaveApproveInfo, string boName = BoName)
        {
            LeaveApproveCtrl leaveApproveCtrl = new LeaveApproveCtrl();
            return leaveApproveCtrl.Insert(boName, leaveApproveInfo);
        }

        /// <summary>
        /// 更新请假流程信息
        /// </summary>
        /// <param name="leaveApproveInfo">请假流程信息实体</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>操作结果</returns>
        public int UpdateLeaveApprove(LeaveApproveInfo leaveApproveInfo, string boName = BoName)
        {
            LeaveApproveCtrl leaveApproveCtrl = new LeaveApproveCtrl();
            return leaveApproveCtrl.UpDate(boName, leaveApproveInfo);
        }

        /// <summary>
        /// 通过ObjectID获取指定的请假流程信息.
        /// </summary>
        /// <param name="objectID">请假流程信息ID</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>请假流程实体</returns>
        public LeaveApproveInfo GetLeaveApproveInfoByObjectID(string objectID, string boName = BoName)
        {
            LeaveApproveCtrl leaveApproveCtrl = new LeaveApproveCtrl();
            List<LeaveApproveInfo> lstLeaveApprove = leaveApproveCtrl.SelectAsList(boName, "ObjectID = '" + objectID + "'");
            if (lstLeaveApprove.Count == 0)
            {
                return null;
            }
            return lstLeaveApprove[0];
        }

        /// <summary>
        /// 通过查询条件获取请假流程信息集合
        /// </summary>
        /// <param name="condition">查询信息</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>请假流程信息集合</returns>
        public List<LeaveApproveInfo> GetLeaveApprovesByCondition(string condition, string boName = BoName)
        {
            LeaveApproveCtrl leaveApproveCtrl = new LeaveApproveCtrl();
            List<LeaveApproveInfo> lstLeaveApproves = leaveApproveCtrl.SelectAsList(boName, condition);

            return lstLeaveApproves;
        }

        ///// <summary>
        ///// 根据
        ///// </summary>
        ///// <param name="appState">状态：0-</param>
        ///// <param name="startDate"></param>
        ///// <param name="endTime"></param>
        ///// <param name="boName"></param>
        ///// <returns></returns>
        //public List<LeaveInfo> GetLeaveInfo(string appState, string startDate, string endTime, string boName = BoName)
        //{ 

        //}

    }
}
