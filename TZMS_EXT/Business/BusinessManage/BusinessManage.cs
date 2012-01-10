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

        /// <summary>
        /// 添加新的业务记录
        /// </summary>
        /// <param name="baoxiao">业务记录实例</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>执行结果</returns>
        public int AddNewCostApply(BusinessCostApplyInfo info, string boName = BoName)
        {
            BusinessCostApplyCtrl _ctrl = new BusinessCostApplyCtrl();
            return _ctrl.Insert(boName, info);
        }

        /// <summary>
        /// 更新业务记录
        /// </summary>
        /// <param name="baoxiao">业务记录实例</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>执行结果</returns>
        public int UpdateCostApply(BusinessCostApplyInfo info, string boName = BoName)
        {
            BusinessCostApplyCtrl _ctrl = new BusinessCostApplyCtrl();
            return _ctrl.UpDate(boName, info);
        }

        /// <summary>
        /// 根据指定的ObjectID来获取业务记录实例
        /// </summary>
        /// <param name="objectID">业务记录实例ObjectID</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>业务实例</returns>
        public BusinessCostApplyInfo GetCostApplyByObjectID(string objectID, string boName = BoName)
        {
            BusinessCostApplyCtrl _ctrl = new BusinessCostApplyCtrl();
            List<BusinessCostApplyInfo> lstBaoxiao = _ctrl.SelectAsList(boName, "ObjectID='" + objectID + "'");
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
        public List<BusinessCostApplyInfo> GetCostApplyByCondition(string condition, string boName = BoName)
        {
            BusinessCostApplyCtrl _ctrl = new BusinessCostApplyCtrl();
            return _ctrl.SelectAsList(boName, condition);
        }

        /// <summary>
        /// 添加新的业务记录
        /// </summary>
        /// <param name="baoxiao">业务记录实例</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>执行结果</returns>
        public int AddNewCostApprove(BusinessCostApproveInfo info, string boName = BoName)
        {
            BusinessCostApproveCtrl _ctrl = new BusinessCostApproveCtrl();
            return _ctrl.Insert(boName, info);
        }

        /// <summary>
        /// 更新业务记录
        /// </summary>
        /// <param name="baoxiao">业务记录实例</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>执行结果</returns>
        public int UpdateCostApprove(BusinessCostApproveInfo info, string boName = BoName)
        {
            BusinessCostApproveCtrl _ctrl = new BusinessCostApproveCtrl();
            return _ctrl.UpDate(boName, info);
        }

        /// <summary>
        /// 根据指定的ObjectID来获取业务记录实例
        /// </summary>
        /// <param name="objectID">业务记录实例ObjectID</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>业务实例</returns>
        public BusinessCostApproveInfo GetCostApproveByObjectID(string objectID, string boName = BoName)
        {
            BusinessCostApproveCtrl _ctrl = new BusinessCostApproveCtrl();
            List<BusinessCostApproveInfo> lstBaoxiao = _ctrl.SelectAsList(boName, "ObjectID='" + objectID + "'");
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
        public List<BusinessCostApproveInfo> GetCostApproveByCondition(string condition, string boName = BoName)
        {
            BusinessCostApproveCtrl _ctrl = new BusinessCostApproveCtrl();
            return _ctrl.SelectAsList(boName, condition);
        }

        /// <summary>
        /// 转换业务标示到字符串
        /// </summary>
        /// <param name="isNormalBusiness">是否是普通业务</param>
        /// <param name="nCurrentBusiness">业务编号</param>
        /// <returns>业务名称</returns>
        public string ConvertBusinessTypeToString(bool isNormalBusiness, int nCurrentBusiness)
        {
            string strName = string.Empty;

            if (isNormalBusiness)
            {
                switch (nCurrentBusiness)
                {
                    case -1:
                        strName = "业务转移";
                        break;
                    case 0:
                        strName = "签订合同";
                        break;
                    case 1:
                        strName = "业务转交";
                        break;
                    case 2:
                        strName = "核名";
                        break;
                    case 3:
                        strName = "刻章";
                        break;
                    case 4:
                        strName = "各类许可证";
                        break;
                    case 5:
                        strName = "开户";
                        break;
                    case 6:
                        strName = "验资报告";
                        break;
                    case 7:
                        strName = "营业执照";
                        break;
                    case 8:
                        strName = "办代码证";
                        break;
                    case 9:
                        strName = "办国地税";
                        break;
                    case 10:
                        strName = "转基本户";
                        break;
                    case 11:
                        strName = "税务备案";
                        break;
                    case 12:
                        strName = "增资(开户、验资报告、营业执照)";
                        break;
                    case 13:
                        strName = "完成";
                        break;
                    case 14:
                        strName = "异常终止";
                        break;
                    default:
                        break;
                }
            }
            else
            { }

            return strName;
        }
    }
}
