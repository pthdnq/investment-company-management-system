using System;
using System.Collections.Generic;
using System.Text;
using com.TZMS.Model;
using com.TZMS.DataAccess;

namespace com.TZMS.Business
{
    public class JiangChengManage : ParentManage
    {
        public JiangChengManage()
        { }

        /// <summary>
        /// 添加新奖惩
        /// </summary>
        /// <param name="info">奖惩实体</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>操作结果</returns>
        public int AddNewJiangCheng(JiangChengInfo info, string boName = BoName)
        {
            JiangChengCtrl _ctrl = new JiangChengCtrl();
            return _ctrl.Insert(boName, info);
        }

        /// <summary>
        /// 更新奖惩
        /// </summary>
        /// <param name="info">奖惩实例</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>操作结果</returns>
        public int UpdateJiangCheng(JiangChengInfo info, string boName = BoName)
        {
            JiangChengCtrl _ctrl = new JiangChengCtrl();
            return _ctrl.UpDate(boName, info);
        }

        /// <summary>
        /// 根据ID获取奖惩实例
        /// </summary>
        /// <param name="objectID">ID</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>奖惩实例</returns>
        public JiangChengInfo GetJiangChengByObjectID(string objectID, string boName = BoName)
        {
            JiangChengCtrl _ctrl = new JiangChengCtrl();
            List<JiangChengInfo> lstApplys = _ctrl.SelectAsList(boName, "ObjectID='" + objectID + "'");
            if (lstApplys.Count == 0)
            {
                return null;
            }

            return lstApplys[0];
        }

        /// <summary>
        /// 根据查询条件获取奖惩实例集合
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>奖惩实例集合</returns>
        public List<JiangChengInfo> GetJiangChengByCondition(string condition, string boName = BoName)
        {
            JiangChengCtrl _ctrl = new JiangChengCtrl();
            return _ctrl.SelectAsList(boName, condition);
        }
    }
}
