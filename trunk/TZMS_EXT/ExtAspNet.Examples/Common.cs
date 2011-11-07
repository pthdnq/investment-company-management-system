﻿using System;
using System.Collections.Generic;
using System.Web;
using TZMS.Web.CommonControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using Com.iFlytek.OA.MUDCommon;

namespace TZMS
{
    public class Common
    {

        /// <summary>
        /// 部门
        /// </summary>
        public static class DEPT
        {
            /// <summary>
            /// 行政部
            /// </summary>
            static public string XINGZHENG = "行政部";

            /// <summary>
            /// 财务部
            /// </summary>
            static public string CAIWU = "财务部";

            /// <summary>
            /// 投资部
            /// </summary>
            static public string TOUZI = "投资部";

            /// <summary>
            /// 业务部
            /// </summary>
            static public string YEWU = "业务部";
        }
        #region 附件
        /// <summary>
        /// 保存附件
        /// </summary>
        /// <param name="systemName">systemName</param>
        /// <param name="recordId">recordId</param>
        /// <param name="attributeName">attributeName</param>
        public static void SaveAttachs(string systemName, string recordId, string attributeName)
        {
            MUDFilesCtrl fileCtrl = new MUDFilesCtrl();
            fileCtrl.AcceptFiles(string.Empty, systemName, attributeName, recordId);
        }

        /// <summary>
        /// 保存附件(新ID替换临时ID)
        /// </summary>
        /// <param name="systemName">systemName</param>
        /// <param name="newId">newId</param>
        /// <param name="oldId">oldId</param>
        /// <param name="attributeName">attributeName</param>
        public static void SaveAttachs(string systemName, string newId, string oldId, string attributeName)
        {
            MUDFilesCtrl fileCtrl = new MUDFilesCtrl();
            fileCtrl.AcceptFiles(string.Empty, systemName, oldId, attributeName, newId, string.Empty);
        }

        #region 删除附件
        /// <summary>
        /// 删除附件 by systemName And AttributeName
        /// </summary>
        /// <param name="systemName">systemName</param>
        /// <param name="attributeName">attributeName</param>
        public static void DeleteAttachs(string systemName, string attributeName)
        {
            string commondStr = "DELETE FROM MUDFiles WHERE ";

            if (!string.IsNullOrEmpty(systemName))
            {
                commondStr += " SystemName=" + systemName;
            }

            if (!string.IsNullOrEmpty(attributeName))
            {
                if (!string.IsNullOrEmpty(systemName))
                {
                    commondStr += " AND ";
                }
                commondStr += " AttributeName=" + attributeName;
            }

            SqlCommand sqlCommand = new SqlCommand(commondStr, mutiFilesConnection);
            try
            {
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                //throw new BizException("删除失败!" + e.Message);
            }
        }

        /// <summary>
        /// 删除附件 by recordId
        /// </summary>
        /// <param name="recordId">recordId</param>
        public static void DeleteAttachs(string recordId)
        {
            string commondStr = "DELETE FROM MUDFiles WHERE RecordID='" + recordId + "'";

            SqlCommand sqlCommand = new SqlCommand(commondStr, mutiFilesConnection);
            try
            {
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                //throw new BizException("删除失败!" + e.Message);
            }
        }

        /// <summary>
        /// 打开对附件数据库的连接
        /// </summary>
        public static void OpenMFConnection()
        {
            if (string.IsNullOrEmpty(mutiFilesConnection.ConnectionString))
            {
                mutiFilesConnection.ConnectionString = mutiFilesConnectionStr;
            }
            if (mutiFilesConnection.State != ConnectionState.Open)
            { //如果不是打开的状态，则打开
                mutiFilesConnection.Open();
            }
        }

        /// <summary>
        /// 关闭对附件数据库连接
        /// </summary>
        public static void CloseMFConnection()
        {
            mutiFilesConnection.Close();
        }

        /// <summary>
        /// 定义连接附件数据库的连接字符串
        /// </summary>
        private static string mutiFilesConnectionStr = ConfigurationManager.AppSettings["CONNECTIONSTRINGFORPROVINCE_EXPAND"].ToString();

        /// <summary>
        /// 共享的对多附件数据库的数据库联接
        /// </summary>
        private static SqlConnection mutiFilesConnection = new SqlConnection();

        #endregion

        /// <summary>
        /// 绑定附件列表
        /// </summary>
        /// <param name="control">control</param>
        /// <param name="systemName">systemName</param>
        /// <param name="recordId">recordId</param>
        /// <param name="attributeName">attributeName</param>
        /// <param name="canEdit">canEdit</param>
        public static void BindAttachsRecordInfo(MudFlexCtrl control, string systemName, string recordId, string attributeName, bool canEdit)
        {
            if (canEdit)
            {
                control.ShowAddBtn = "true";
                control.ShowDelBtn = "true";
            }
            else
            {
                control.ShowDelBtn = "false";
                control.ShowAddBtn = "false";
            }
            control.SystemName = systemName;
            control.RecordID = recordId;
            control.AttributeName = attributeName;

            MUDFilesCtrl fileCtrl = new MUDFilesCtrl();
            fileCtrl.ResetFiles(string.Empty, systemName, recordId, attributeName);
        }
        #endregion
    }
}