﻿using System;
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
        /// <param name="leaveInfo"></param>
        /// <param name="boName"></param>
        /// <returns></returns>
        public int AddNewLeaveApp(LeaveInfo leaveInfo, string boName = BoName)
        {
            LeaveInfoCtrl leaveCtrl = new LeaveInfoCtrl();
            return leaveCtrl.Insert(boName, leaveInfo);
        }

    }
}
