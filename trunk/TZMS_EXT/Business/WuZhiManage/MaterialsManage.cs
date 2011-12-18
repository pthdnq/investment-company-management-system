using System;
using System.Collections.Generic;
using System.Text;
using com.TZMS.Model;
using com.TZMS.DataAccess;

namespace com.TZMS.Business
{
    public class MaterialsManage : ParentManage
    {
        public MaterialsManage()
        { }

        /// <summary>
        /// 添加新申请
        /// </summary>
        /// <param name="info">申请实例</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>操作结果</returns>
        public int AddNewMaterial(MaterialsManageInfo info, string boName = BoName)
        {
            MaterialsManageCtrl _ctrl = new MaterialsManageCtrl();
            return _ctrl.Insert(boName, info);
        }

        /// <summary>
        /// 更新申请
        /// </summary>
        /// <param name="info">申请实例</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>操作结果</returns>
        public int UpdateMaterial(MaterialsManageInfo info, string boName = BoName)
        {
            MaterialsManageCtrl _ctrl = new MaterialsManageCtrl();
            return _ctrl.UpDate(boName, info);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="objectID"></param>
        /// <param name="boName"></param>
        public void DeleteMaterial(string objectID, string boName = BoName)
        {
            MaterialsManageCtrl _ctrl = new MaterialsManageCtrl();
            _ctrl.Delete(boName, objectID);
        }

        /// <summary>
        /// 根据ID获取申请实例
        /// </summary>
        /// <param name="objectID">申请实例</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>申请实例</returns>
        public MaterialsManageInfo GetMaterialByObjectID(string objectID, string boName = BoName)
        {
            MaterialsManageCtrl _ctrl = new MaterialsManageCtrl();
            List<MaterialsManageInfo> lstApplys = _ctrl.SelectAsList(boName, "ObjectID='" + objectID + "'");
            if (lstApplys.Count == 0)
            {
                return null;
            }

            return lstApplys[0];
        }

        /// <summary>
        /// 根据查询条件获取申请实例集合
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>申请实例集合</returns>
        public List<MaterialsManageInfo> GetMaterialsByCondition(string condition, string boName = BoName)
        {
            MaterialsManageCtrl _ctrl = new MaterialsManageCtrl();
            return _ctrl.SelectAsList(boName, condition);
        }

        /// <summary>
        /// 添加新申请
        /// </summary>
        /// <param name="info">申请实例</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>操作结果</returns>
        public int AddNewApply(MaterialsApplyInfo info, string boName = BoName)
        {
            MaterialsApplyCtrl _ctrl = new MaterialsApplyCtrl();
            return _ctrl.Insert(boName, info);
        }

        /// <summary>
        /// 更新申请
        /// </summary>
        /// <param name="info">申请实例</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>操作结果</returns>
        public int UpdateApply(MaterialsApplyInfo info, string boName = BoName)
        {
            MaterialsApplyCtrl _ctrl = new MaterialsApplyCtrl();
            return _ctrl.UpDate(boName, info);
        }

        /// <summary>
        /// 根据ID获取申请实例
        /// </summary>
        /// <param name="objectID">申请实例</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>申请实例</returns>
        public MaterialsApplyInfo GetApplyByObjectID(string objectID, string boName = BoName)
        {
            MaterialsApplyCtrl _ctrl = new MaterialsApplyCtrl();
            List<MaterialsApplyInfo> lstApplys = _ctrl.SelectAsList(boName, "ObjectID='" + objectID + "'");
            if (lstApplys.Count == 0)
            {
                return null;
            }

            return lstApplys[0];
        }

        /// <summary>
        /// 根据查询条件获取申请实例集合
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>申请实例集合</returns>
        public List<MaterialsApplyInfo> GetApplyByCondition(string condition, string boName = BoName)
        {
            MaterialsApplyCtrl _ctrl = new MaterialsApplyCtrl();
            return _ctrl.SelectAsList(boName, condition);
        }

        /// <summary>
        /// 添加新审批
        /// </summary>
        /// <param name="info">审批实例</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>操作结果</returns>
        public int AddNewApprove(MaterialsApproveInfo info, string boName = BoName)
        {
            MaterialsApproveCtrl _ctrl = new MaterialsApproveCtrl();
            return _ctrl.Insert(boName, info);
        }

        /// <summary>
        /// 更新审批
        /// </summary>
        /// <param name="info">审批实例</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>操作结果</returns>
        public int UpdateApprove(MaterialsApproveInfo info, string boName = BoName)
        {
            MaterialsApproveCtrl _ctrl = new MaterialsApproveCtrl();
            return _ctrl.UpDate(boName, info);
        }

        /// <summary>
        /// 根据ID获取审批实例
        /// </summary>
        /// <param name="objectID">ID</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>审批实例</returns>
        public MaterialsApproveInfo GetApproveByObjectID(string objectID, string boName = BoName)
        {
            MaterialsApproveCtrl _ctrl = new MaterialsApproveCtrl();
            List<MaterialsApproveInfo> lstApproves = _ctrl.SelectAsList(boName, "ObjectID='" + objectID + "'");
            if (lstApproves.Count == 0)
            {
                return null;
            }

            return lstApproves[0];
        }

        /// <summary>
        /// 根据查询条件获取审批实例集合
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>审批实例集合</returns>
        public List<MaterialsApproveInfo> GetApproveByCondition(string condition, string boName = BoName)
        {
            MaterialsApproveCtrl _ctrl = new MaterialsApproveCtrl();
            return _ctrl.SelectAsList(boName, condition);
        }
    }
}
