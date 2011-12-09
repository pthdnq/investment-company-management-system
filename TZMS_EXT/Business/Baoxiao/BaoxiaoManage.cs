using System;
using System.Collections.Generic;
using System.Text;
using com.TZMS.Model;
using com.TZMS.DataAccess;

namespace com.TZMS.Business
{
    /// <summary>
    /// 报销Manage
    /// </summary>
    public class BaoxiaoManage : ParentManage
    {
        /// <summary>
        /// 默认构造方法
        /// </summary>
        public BaoxiaoManage()
        {
            //ToDO
        }

        #region 报销

        /// <summary>
        /// 添加新的报销单到Baoxiao
        /// </summary>
        /// <param name="baoxiao">报销单实例</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>执行结果</returns>
        public int AddNewBaoxiao(BaoxiaoInfo baoxiao, string boName = BoName)
        {
            BaoxiaoCtrl _ctrl = new BaoxiaoCtrl();
            return _ctrl.Insert(boName, baoxiao);
        }

        /// <summary>
        /// 更新报销单
        /// </summary>
        /// <param name="baoxiao">报销单实例</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>执行结果</returns>
        public int UpdateBaoxiao(BaoxiaoInfo baoxiao, string boName = BoName)
        {
            BaoxiaoCtrl _ctrl = new BaoxiaoCtrl();
            return _ctrl.UpDate(boName, baoxiao);
        }

        /// <summary>
        /// 根据指定的ObjectID来获取报销单实例
        /// </summary>
        /// <param name="objectID">报销单实例ObjectID</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>报销单实例</returns>
        public BaoxiaoInfo GetBaoxiaoByObjectID(string objectID, string boName = BoName)
        {
            BaoxiaoCtrl _ctrl = new BaoxiaoCtrl();
            List<BaoxiaoInfo> lstBaoxiao = _ctrl.SelectAsList(boName, "ObjectID='" + objectID + "'");
            if (lstBaoxiao.Count == 0)
            {
                return null;
            }

            return lstBaoxiao[0];
        }

        /// <summary>
        /// 根据指定的查询条件获取报销单实例集合
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>报销单实例集合</returns>
        public List<BaoxiaoInfo> GetBaoxiaoByCondition(string condition, string boName = BoName)
        {
            BaoxiaoCtrl _ctrl = new BaoxiaoCtrl();
            return _ctrl.SelectAsList(boName, condition);
        }

        /// <summary>
        /// 插入新的报销流程记录到报销流程表
        /// </summary>
        /// <param name="baoxiaoCheckInfo">报销流程实体</param>
        /// <param name="boName">数据库连接Key</param>
        /// <returns>执行结果</returns>
        public int AddNewBaoxiaoCheck(BaoxiaoCheckInfo baoxiaoCheckInfo, string boName = BoName)
        {
            BaoxiaoCheckCtrl _ctrl = new BaoxiaoCheckCtrl();
            return _ctrl.Insert(boName, baoxiaoCheckInfo);
        }

        /// <summary>
        /// 更新报销流程记录
        /// </summary>
        /// <param name="baoxiaoCheckInfo">报销流程实例</param>
        /// <param name="boName">数据库连接Key</param>
        /// <returns>执行结果</returns>
        public int UpdateBaoxiaoCheck(BaoxiaoCheckInfo baoxiaoCheckInfo, string boName = BoName)
        {
            BaoxiaoCheckCtrl _ctrl = new BaoxiaoCheckCtrl();
            return _ctrl.UpDate(boName, baoxiaoCheckInfo);
        }

        /// <summary>
        /// 根据ID获取指定的报销流程实例 
        /// </summary>
        /// <param name="objectID">ID</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>报销流程实例</returns>
        public BaoxiaoCheckInfo GetBaoxiaoCheckByObjectID(string objectID, string boName = BoName)
        {
            BaoxiaoCheckCtrl _ctrl = new BaoxiaoCheckCtrl();
            List<BaoxiaoCheckInfo> lstBaoxiaoCheckInfo = _ctrl.SelectAsList(boName, "ObjectID='" + objectID + "'");
            if (lstBaoxiaoCheckInfo.Count == 0)
            {
                return null;
            }

            return lstBaoxiaoCheckInfo[0];
        }

        /// <summary>
        /// 根据指定的查询条件获取报销流程实例集合
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <param name="boName">数据库连接Key</param>
        /// <returns>报销流程实例集合</returns>
        public List<BaoxiaoCheckInfo> GetBaoxiaoCheckByCondition(string condition, string boName = BoName)
        {
            BaoxiaoCheckCtrl _ctrl = new BaoxiaoCheckCtrl();
            return _ctrl.SelectAsList(boName, condition);
        }

        #endregion

        #region 凭证

        /// <summary>
        /// 添加新的报销单到Baoxiao
        /// </summary>
        /// <param name="baoxiao">报销单实例</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>执行结果</returns>
        public int AddNewPinZhengApply(BaoXiaoPinZhengApplyInfo baoxiao, string boName = BoName)
        {
            BaoXiaoPinZhengApplyCtrl _ctrl = new BaoXiaoPinZhengApplyCtrl();
            return _ctrl.Insert(boName, baoxiao);
        }

        /// <summary>
        /// 更新报销单
        /// </summary>
        /// <param name="baoxiao">报销单实例</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>执行结果</returns>
        public int UpdatePinZhengApply(BaoXiaoPinZhengApplyInfo baoxiao, string boName = BoName)
        {
            BaoXiaoPinZhengApplyCtrl _ctrl = new BaoXiaoPinZhengApplyCtrl();
            return _ctrl.UpDate(boName, baoxiao);
        }

        /// <summary>
        /// 根据指定的ObjectID来获取报销单实例
        /// </summary>
        /// <param name="objectID">报销单实例ObjectID</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>报销单实例</returns>
        public BaoXiaoPinZhengApplyInfo GetPinZhengApplyByObjectID(string objectID, string boName = BoName)
        {
            BaoXiaoPinZhengApplyCtrl _ctrl = new BaoXiaoPinZhengApplyCtrl();
            List<BaoXiaoPinZhengApplyInfo> lstBaoxiao = _ctrl.SelectAsList(boName, "ObjectID='" + objectID + "'");
            if (lstBaoxiao.Count == 0)
            {
                return null;
            }

            return lstBaoxiao[0];
        }

        /// <summary>
        /// 根据指定的查询条件获取报销单实例集合
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>报销单实例集合</returns>
        public List<BaoXiaoPinZhengApplyInfo> GetPinZhengApplyByCondition(string condition, string boName = BoName)
        {
            BaoXiaoPinZhengApplyCtrl _ctrl = new BaoXiaoPinZhengApplyCtrl();
            return _ctrl.SelectAsList(boName, condition);
        }

        /// <summary>
        /// 插入新的报销流程记录到报销流程表
        /// </summary>
        /// <param name="baoxiaoCheckInfo">报销流程实体</param>
        /// <param name="boName">数据库连接Key</param>
        /// <returns>执行结果</returns>
        public int AddNewPinZhengApprove(BaoXiaoPinZhengApproveInfo baoxiaoCheckInfo, string boName = BoName)
        {
            BaoXiaoPinZhengApproveCtrl _ctrl = new BaoXiaoPinZhengApproveCtrl();
            return _ctrl.Insert(boName, baoxiaoCheckInfo);
        }

        /// <summary>
        /// 更新报销流程记录
        /// </summary>
        /// <param name="baoxiaoCheckInfo">报销流程实例</param>
        /// <param name="boName">数据库连接Key</param>
        /// <returns>执行结果</returns>
        public int UpdatePinZhengApprove(BaoXiaoPinZhengApproveInfo baoxiaoCheckInfo, string boName = BoName)
        {
            BaoXiaoPinZhengApproveCtrl _ctrl = new BaoXiaoPinZhengApproveCtrl();
            return _ctrl.UpDate(boName, baoxiaoCheckInfo);
        }

        /// <summary>
        /// 根据ID获取指定的报销流程实例 
        /// </summary>
        /// <param name="objectID">ID</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>报销流程实例</returns>
        public BaoXiaoPinZhengApproveInfo GetPinZhengApproveByObjectID(string objectID, string boName = BoName)
        {
            BaoXiaoPinZhengApproveCtrl _ctrl = new BaoXiaoPinZhengApproveCtrl();
            List<BaoXiaoPinZhengApproveInfo> lstBaoxiaoCheckInfo = _ctrl.SelectAsList(boName, "ObjectID='" + objectID + "'");
            if (lstBaoxiaoCheckInfo.Count == 0)
            {
                return null;
            }

            return lstBaoxiaoCheckInfo[0];
        }

        /// <summary>
        /// 根据指定的查询条件获取报销流程实例集合
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <param name="boName">数据库连接Key</param>
        /// <returns>报销流程实例集合</returns>
        public List<BaoXiaoPinZhengApproveInfo> GetPinZhengApproveByCondition(string condition, string boName = BoName)
        {
            BaoXiaoPinZhengApproveCtrl _ctrl = new BaoXiaoPinZhengApproveCtrl();
            return _ctrl.SelectAsList(boName, condition);
        }

        #endregion
    }
}
