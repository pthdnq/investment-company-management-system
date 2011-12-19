using System;
using System.Collections.Generic;
using System.Text;
using com.TZMS.Model;
using com.TZMS.DataAccess;

namespace com.TZMS.Business
{
    public class ChuRuManage : ParentManage
    {
        public ChuRuManage()
        { }

        /// <summary>
        /// 添加新出入信息
        /// </summary>
        /// <param name="info">新出入实体</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>操作结果</returns>
        public int AddNewChuRu(ChuRuInfo info, string boName = BoName)
        {
            ChuRuCtrl _ctrl = new ChuRuCtrl();
            return _ctrl.Insert(boName, info);
        }

        /// <summary>
        /// 更新出入信息
        /// </summary>
        /// <param name="info">出入实体</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>操作结果</returns>
        public int UpdateChuRu(ChuRuInfo info, string boName = BoName)
        {
            ChuRuCtrl _ctrl = new ChuRuCtrl();
            return _ctrl.UpDate(boName, info);
        }

        /// <summary>
        /// 根据ID获取出入信息
        /// </summary>
        /// <param name="objectID">ID</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>出入信息</returns>
        public ChuRuInfo GetChuRuByObjectID(string objectID, string boName = BoName)
        {
            ChuRuCtrl _ctrl = new ChuRuCtrl();
            List<ChuRuInfo> lstUnits = _ctrl.SelectAsList(boName, "ObjectID='" + objectID + "'");
            if (lstUnits.Count == 0)
            {
                return null;
            }

            return lstUnits[0];
        }

        /// <summary>
        /// 根据查询条件获取出入信息实例集合
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>出入信息集合</returns>
        public List<ChuRuInfo> GetUnitByCondition(string condition, string boName = BoName)
        {
            ChuRuCtrl _ctrl = new ChuRuCtrl();
            return _ctrl.SelectAsList(boName, condition);
        }
    }
}
