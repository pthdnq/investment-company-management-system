//----------------------------------------------------------------------------------------------------
//程序名:	ProjectProcessHistory 控制类
//功能:  	定义了与 dbo.ProjectProcessHistory 表 对应的数据访问控制类
//作者:  	shunlian
//时间:	2011-10-26 
//----------------------------------------------------------------------------------------------------
//更改历史:
// 日期		            更改人		     更改内容
//---------------------------------------------------------------------------------------------------- 
//----------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Com.iFlytek.DatabaseAccess.DAL;
using Com.iFlytek.BaseService;
using Com.iFlytek.Utility;
using com.TZMS.Model;

namespace com.TZMS.DataAccess
{
    /// <summary>
    /// ProjectProcessHistoryCtrl
    /// programmer:shunlian
    /// </summary>
    public class ProjectProcessHistoryCtrl
    {
        #region 构造函数

        /// <summary>
        /// ProjectProcessHistoryCtrl默认构造函数
        /// </summary>
        public ProjectProcessHistoryCtrl()
        {
            //ToDo
        }

        #endregion

        #region 增、删、改、查

        /// <summary>
        /// 插入dbo.ProjectProcessHistory一条记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="ProjectProcessHistoryInfo">ProjectProcessHistoryInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int Insert(string boName, ProjectProcessHistoryInfo ProjectProcessHistoryInfo)
        {
            try
            {
                //存储过程名称
                string strsql = "ProjectProcessHistory_Add";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@Id",DbType.Guid),
				new SqlParameter("@ForId",DbType.Guid),
				new SqlParameter("@OperationDesc",DbType.String),
				new SqlParameter("@OperationType",DbType.String),
				new SqlParameter("@OperationTime",DbType.DateTime),
				new SqlParameter("@OperationerAccount",DbType.String),
				new SqlParameter("@OperationerName",DbType.String),
				new SqlParameter("@Remark",DbType.String),
				};

                int i = 0;
                sqlparam[i++].Value = ProjectProcessHistoryInfo.Id;
                sqlparam[i++].Value = ProjectProcessHistoryInfo.ForId;
                sqlparam[i++].Value = ProjectProcessHistoryInfo.OperationDesc;
                sqlparam[i++].Value = ProjectProcessHistoryInfo.OperationType;
                sqlparam[i++].Value = ProjectProcessHistoryInfo.OperationTime;
                sqlparam[i++].Value = ProjectProcessHistoryInfo.OperationerAccount;
                sqlparam[i++].Value = ProjectProcessHistoryInfo.OperationerName;
                sqlparam[i++].Value = ProjectProcessHistoryInfo.Remark;
                SqlDBAccess dbaccess = new SqlDBAccess();
                //执行存储过程
                i = dbaccess.ExecuteNonQuery(boName, CommandType.StoredProcedure, strsql, sqlparam);
                return i;
            }
            catch (Exception e)
            {
                Tracing.Error(this, e);
                throw e;
            }
        }

        /// <summary>
        /// dbo.ProjectProcessHistory删除记录(通过记录ID ObjectID)
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="objectID">ObjectID(唯一ID)</param>
        public void Delete(string boName, string objectID)
        {
            try
            {
                string strsql = "ProjectProcessHistory_Delete";

                SqlParameter[] sqlparam =
				{
					new SqlParameter ( "@ObjectID", SqlDbType.NVarChar )
				};
                int i = 0;
                sqlparam[i++].Value = objectID;

                SqlDBAccess dbaccess = new SqlDBAccess();
                dbaccess.ExecuteNonQuery(boName, CommandType.StoredProcedure, strsql, sqlparam);
            }
            catch (Exception e)
            {
                Tracing.Error(this, e);
                throw e;
            }
        }

        /// <summary>
        /// ProjectProcessHistory 更新记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="ProjectProcessHistoryInfo">ProjectProcessHistoryInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int UpDate(string boName, ProjectProcessHistoryInfo ProjectProcessHistoryInfo)
        {
            try
            {
                //存储过程名称
                string strsql = "ProjectProcessHistory_Update";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@Id",DbType.Guid),
				new SqlParameter("@ForId",DbType.Guid),
				new SqlParameter("@OperationDesc",DbType.String),
				new SqlParameter("@OperationType",DbType.String),
				new SqlParameter("@OperationTime",DbType.DateTime),
				new SqlParameter("@OperationerAccount",DbType.String),
				new SqlParameter("@OperationerName",DbType.String),
				new SqlParameter("@Remark",DbType.String),
                };

                int i = 0;
                sqlparam[i++].Value = ProjectProcessHistoryInfo.Id;
                sqlparam[i++].Value = ProjectProcessHistoryInfo.ForId;
                sqlparam[i++].Value = ProjectProcessHistoryInfo.OperationDesc;
                sqlparam[i++].Value = ProjectProcessHistoryInfo.OperationType;
                sqlparam[i++].Value = ProjectProcessHistoryInfo.OperationTime;
                sqlparam[i++].Value = ProjectProcessHistoryInfo.OperationerAccount;
                sqlparam[i++].Value = ProjectProcessHistoryInfo.OperationerName;
                sqlparam[i++].Value = ProjectProcessHistoryInfo.Remark;
                SqlDBAccess dbaccess = new SqlDBAccess();
                //执行存储过程
                i = dbaccess.ExecuteNonQuery(boName, CommandType.StoredProcedure, strsql, sqlparam);
                return i;
            }
            catch (Exception e)
            {
                Tracing.Error(this, e);
                throw e;
            }
        }

        /// <summary>
        /// ProjectProcessHistory 查询,返回Datatable
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="selectCondition">查询条件</param>
        /// <returns>DataTable</returns>
        public DataTable Select(string boName, string condition)
        {
            try
            {
                //存储过程名称
                string strsql = "ProjectProcessHistory_Search";
                SqlParameter[] sqlparam =
                {
					new SqlParameter("@Condition",SqlDbType.NVarChar), 
                };

                int i = 0;
                sqlparam[i++].Value = condition;
                SqlDBAccess dbaccess = new SqlDBAccess();
                //执行存储过程
                DataSet ds = (DataSet)dbaccess.ExecuteDataset(boName, CommandType.StoredProcedure, strsql, sqlparam);

                return ds.Tables[0];
            }
            catch (Exception e)
            {
                Tracing.Error(this, e);
                throw e;
            }
        }

        ///<summary>
        ///ProjectProcessHistory 查询,返回List
        ///</summary>
        ///<param name="boName">数据库连接配置key信息</param>
        ///<param name="selectCondition">查询条件</param>
        /// <returns>List<ProjectProcessHistoryInfo></returns>
        public List<ProjectProcessHistoryInfo> SelectAsList(string boName, string selectCondition)
        {
            DataTable table = new DataTable();
            List<ProjectProcessHistoryInfo> list = new List<ProjectProcessHistoryInfo>();
            ProjectProcessHistoryInfo accountInfo = new ProjectProcessHistoryInfo();

            try
            {
                table = Select(boName, selectCondition);

                // DataTable To ArrayList
                foreach (DataRow row in table.Rows)
                {
                    accountInfo = ProjectProcessHistoryInfoRowToInfo(row);
                    list.Add(accountInfo);
                }

                return list;
            }
            catch (Exception e)
            {
                Tracing.Error(this, e);
                throw e;
            }
        }

        /// <summary>
        /// DataRow To Object
        /// </summary>
        /// <param name="ProjectProcessHistoryDataRow">ProjectProcessHistoryDataRow</param>
        /// <returns>ProjectProcessHistoryInfo</returns>
        internal ProjectProcessHistoryInfo ProjectProcessHistoryInfoRowToInfo(DataRow ProjectProcessHistoryInfoInfoDataRow)
        {
            ProjectProcessHistoryInfo ProjectProcessHistoryInfoInfo = new ProjectProcessHistoryInfo();
            //if (ProjectProcessHistoryInfoInfoDataRow["Id"] != null)
            //{
            //    ProjectProcessHistoryInfoInfo.Id = DataUtil.GetStringValueOfRow(ProjectProcessHistoryInfoInfoDataRow, "Id");
            //}
            //if (ProjectProcessHistoryInfoInfoDataRow["ForId"] != null)
            //{
            //    ProjectProcessHistoryInfoInfo.ForId = DataUtil.GetStringValueOfRow(ProjectProcessHistoryInfoInfoDataRow, "ForId");
            //}
            //if (ProjectProcessHistoryInfoInfoDataRow["OperationDesc"] != null)
            //{
            //    ProjectProcessHistoryInfoInfo.OperationDesc = DataUtil.GetStringValueOfRow(ProjectProcessHistoryInfoInfoDataRow, "OperationDesc");
            //}
            //if (ProjectProcessHistoryInfoInfoDataRow["OperationType"] != null)
            //{
            //    ProjectProcessHistoryInfoInfo.OperationType = DataUtil.GetStringValueOfRow(ProjectProcessHistoryInfoInfoDataRow, "OperationType");
            //}
            //if (ProjectProcessHistoryInfoInfoDataRow["OperationTime"] != null)
            //{
            //    ProjectProcessHistoryInfoInfo.OperationTime = DataUtil.GetStringValueOfRow(ProjectProcessHistoryInfoInfoDataRow, "OperationTime");
            //}
            //if (ProjectProcessHistoryInfoInfoDataRow["OperationerAccount"] != null)
            //{
            //    ProjectProcessHistoryInfoInfo.OperationerAccount = DataUtil.GetStringValueOfRow(ProjectProcessHistoryInfoInfoDataRow, "OperationerAccount");
            //}
            //if (ProjectProcessHistoryInfoInfoDataRow["OperationerName"] != null)
            //{
            //    ProjectProcessHistoryInfoInfo.OperationerName = DataUtil.GetStringValueOfRow(ProjectProcessHistoryInfoInfoDataRow, "OperationerName");
            //}
            //if (ProjectProcessHistoryInfoInfoDataRow["Remark"] != null)
            //{
            //    ProjectProcessHistoryInfoInfo.Remark = DataUtil.GetStringValueOfRow(ProjectProcessHistoryInfoInfoDataRow, "Remark");
            //}

            return ProjectProcessHistoryInfoInfo;
        }
        #endregion
    }
}
