using System;
using System.Collections.Generic;
using System.Text;
using com.TZMS.Model;
using com.TZMS.DataAccess;

namespace com.TZMS.Business.BusinessManage
{
    public class BusinessManage : ParentManage
    {
        public BusinessManage()
        { }

        /// <summary>
        /// 添加新的业务
        /// </summary>
        /// <param name="baoxiao">业务实例</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>执行结果</returns>
        public int AddNewBusiness(BusinessInfo info, string boName = BoName)
        {
            BusinessCtrl _ctrl = new BusinessCtrl();
            return _ctrl.Insert(boName, info);
        }

        /// <summary>
        /// 更新业务
        /// </summary>
        /// <param name="baoxiao">业务实例</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>执行结果</returns>
        public int UpdateBusiness(BusinessInfo info, string boName = BoName)
        {
            BusinessCtrl _ctrl = new BusinessCtrl();
            return _ctrl.UpDate(boName, info);
        }

        /// <summary>
        /// 根据指定的ObjectID来获取业务实例
        /// </summary>
        /// <param name="objectID">业务实例ObjectID</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>业务实例</returns>
        public BusinessInfo GetBusinessByObjectID(string objectID, string boName = BoName)
        {
            BusinessCtrl _ctrl = new BusinessCtrl();
            List<BusinessInfo> lstBaoxiao = _ctrl.SelectAsList(boName, "ObjectID='" + objectID + "'");
            if (lstBaoxiao.Count == 0)
            {
                return null;
            }

            return lstBaoxiao[0];
        }

        /// <summary>
        /// 根据指定的查询条件获取业务实例集合
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>业务实例集合</returns>
        public List<BusinessInfo> GetBusinessByCondition(string condition, string boName = BoName)
        {
            BusinessCtrl _ctrl = new BusinessCtrl();
            return _ctrl.SelectAsList(boName, condition);
        }

        /// <summary>
        /// 添加新的业务记录
        /// </summary>
        /// <param name="baoxiao">业务记录实例</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>执行结果</returns>
        public int AddNewBusinessRecord(BusinessRecordInfo info, string boName = BoName)
        {
            BusinessRecordCtrl _ctrl = new BusinessRecordCtrl();
            return _ctrl.Insert(boName, info);
        }

        /// <summary>
        /// 更新业务记录
        /// </summary>
        /// <param name="baoxiao">业务记录实例</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>执行结果</returns>
        public int UpdateBusinessRecord(BusinessRecordInfo info, string boName = BoName)
        {
            BusinessRecordCtrl _ctrl = new BusinessRecordCtrl();
            return _ctrl.UpDate(boName, info);
        }

        /// <summary>
        /// 根据指定的ObjectID来获取业务记录实例
        /// </summary>
        /// <param name="objectID">业务记录实例ObjectID</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>业务实例</returns>
        public BusinessRecordInfo GetBusinessRecordByObjectID(string objectID, string boName = BoName)
        {
            BusinessRecordCtrl _ctrl = new BusinessRecordCtrl();
            List<BusinessRecordInfo> lstBaoxiao = _ctrl.SelectAsList(boName, "ObjectID='" + objectID + "'");
            if (lstBaoxiao.Count == 0)
            {
                return null;
            }

            return lstBaoxiao[0];
        }

        /// <summary>
        /// 根据指定的查询条件获取业务记录实例集合
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>业务记录实例集合</returns>
        public List<BusinessRecordInfo> GetBusinessRecordByCondition(string condition, string boName = BoName)
        {
            BusinessRecordCtrl _ctrl = new BusinessRecordCtrl();
            return _ctrl.SelectAsList(boName, condition);
        }
    }
}
