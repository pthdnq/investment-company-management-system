//----------------------------------------------------------------------------------------------------
//程序名:	ProjectProcess 控制类
//功能:  	定义了与 dbo.ProjectProcess 表 对应的数据访问控制类
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
    /// ProjectProcessCtrl
    /// programmer:shunlian
    /// </summary>
    public class ProjectProcessCtrl
    {
        #region 构造函数

        /// <summary>
        /// ProjectProcessCtrl默认构造函数
        /// </summary>
        public ProjectProcessCtrl()
        {
            //ToDo
        }

        #endregion

        #region 增、删、改、查

        /// <summary>
        /// 插入dbo.ProjectProcess一条记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="ProjectProcessInfo">ProjectProcessInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int Insert(string boName, ProjectProcessInfo ProjectProcessInfo)
        {
            try
            {
                //存储过程名称
                string strsql = "ProjectProcess_Add";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjectId",DbType.Guid),
				new SqlParameter("@ForId",DbType.Guid),
				new SqlParameter("@ProjectName",DbType.String),
				new SqlParameter("@NeedImprest",DbType.Boolean),
				new SqlParameter("@ImplementationPhase",DbType.String),
				new SqlParameter("@AmountExpended",DbType.Guid),
				new SqlParameter("@ExpendedTime",DbType.String),
				new SqlParameter("@ImprestAmount",DbType.Guid),
				new SqlParameter("@Remark",DbType.String),
				new SqlParameter("@PrepaidAmount",DbType.Guid),
				new SqlParameter("@Use",DbType.String),
				new SqlParameter("@ImprestRemark",DbType.String),
				new SqlParameter("@Status",DbType.Byte),
				new SqlParameter("@NextOperaterId",DbType.Guid),
				new SqlParameter("@NextOperaterAccount",DbType.String),
				new SqlParameter("@NextOperaterName",DbType.String),
				new SqlParameter("@CreateTime",DbType.DateTime),
				new SqlParameter("@CreaterId",DbType.Guid),
				new SqlParameter("@CreaterName",DbType.String),
				new SqlParameter("@CreaterAccount",DbType.String),
				new SqlParameter("@SubmitTime",DbType.DateTime),
				new SqlParameter("@AuditOpinion",DbType.String),
				new SqlParameter("@AccountingRemark",DbType.String),
                			new SqlParameter("@Adulters",DbType.String),
                            	new SqlParameter("@IsPassImprest",DbType.Boolean),
				};

                int i = 0;
                sqlparam[i++].Value = ProjectProcessInfo.ObjectId;
                sqlparam[i++].Value = ProjectProcessInfo.ForId;
                sqlparam[i++].Value = ProjectProcessInfo.ProjectName;
                sqlparam[i++].Value = ProjectProcessInfo.NeedImprest;
                sqlparam[i++].Value = ProjectProcessInfo.ImplementationPhase;
                sqlparam[i++].Value = ProjectProcessInfo.AmountExpended;
                sqlparam[i++].Value = ProjectProcessInfo.ExpendedTime;
                sqlparam[i++].Value = ProjectProcessInfo.ImprestAmount;
                sqlparam[i++].Value = ProjectProcessInfo.Remark;
                sqlparam[i++].Value = ProjectProcessInfo.PrepaidAmount;
                sqlparam[i++].Value = ProjectProcessInfo.Use;
                sqlparam[i++].Value = ProjectProcessInfo.ImprestRemark;
                sqlparam[i++].Value = ProjectProcessInfo.Status;
                sqlparam[i++].Value = ProjectProcessInfo.NextOperaterId;
                sqlparam[i++].Value = ProjectProcessInfo.NextOperaterAccount;
                sqlparam[i++].Value = ProjectProcessInfo.NextOperaterName;
                sqlparam[i++].Value = ProjectProcessInfo.CreateTime;
                sqlparam[i++].Value = ProjectProcessInfo.CreaterId;
                sqlparam[i++].Value = ProjectProcessInfo.CreaterName;
                sqlparam[i++].Value = ProjectProcessInfo.CreaterAccount;
                sqlparam[i++].Value = ProjectProcessInfo.SubmitTime;
                sqlparam[i++].Value = ProjectProcessInfo.AuditOpinion;
                sqlparam[i++].Value = ProjectProcessInfo.AccountingRemark;
                sqlparam[i++].Value = ProjectProcessInfo.Adulters;
                sqlparam[i++].Value = ProjectProcessInfo.IsPassImprest;
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
        /// dbo.ProjectProcess删除记录(通过记录ID ObjectID)
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="objectID">ObjectID(唯一ID)</param>
        public void Delete(string boName, string objectID)
        {
            try
            {
                string strsql = "ProjectProcess_Delete";

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
        /// ProjectProcess 更新记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="ProjectProcessInfo">ProjectProcessInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int UpDate(string boName, ProjectProcessInfo ProjectProcessInfo)
        {
            try
            {
                //存储过程名称
                string strsql = "ProjectProcess_Update";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjectId",DbType.Guid),
				new SqlParameter("@ForId",DbType.Guid),
				new SqlParameter("@ProjectName",DbType.String),
				new SqlParameter("@NeedImprest",DbType.Boolean),
				new SqlParameter("@ImplementationPhase",DbType.String),
				new SqlParameter("@AmountExpended",DbType.Guid),
				new SqlParameter("@ExpendedTime",DbType.String),
				new SqlParameter("@ImprestAmount",DbType.Guid),
				new SqlParameter("@Remark",DbType.String),
				new SqlParameter("@PrepaidAmount",DbType.Guid),
				new SqlParameter("@Use",DbType.String),
				new SqlParameter("@ImprestRemark",DbType.String),
				new SqlParameter("@Status",DbType.Byte),
				new SqlParameter("@NextOperaterId",DbType.Guid),
				new SqlParameter("@NextOperaterAccount",DbType.String),
				new SqlParameter("@NextOperaterName",DbType.String),
				new SqlParameter("@CreateTime",DbType.DateTime),
				new SqlParameter("@CreaterId",DbType.Guid),
				new SqlParameter("@CreaterName",DbType.String),
				new SqlParameter("@CreaterAccount",DbType.String),
				new SqlParameter("@SubmitTime",DbType.DateTime),
				new SqlParameter("@AuditOpinion",DbType.String),
				new SqlParameter("@AccountingRemark",DbType.String),
                new SqlParameter("@Adulters",DbType.String),
                     	new SqlParameter("@IsPassImprest",DbType.Boolean),
                };

                int i = 0;
                sqlparam[i++].Value = ProjectProcessInfo.ObjectId;
                sqlparam[i++].Value = ProjectProcessInfo.ForId;
                sqlparam[i++].Value = ProjectProcessInfo.ProjectName;
                sqlparam[i++].Value = ProjectProcessInfo.NeedImprest;
                sqlparam[i++].Value = ProjectProcessInfo.ImplementationPhase;
                sqlparam[i++].Value = ProjectProcessInfo.AmountExpended;
                sqlparam[i++].Value = ProjectProcessInfo.ExpendedTime;
                sqlparam[i++].Value = ProjectProcessInfo.ImprestAmount;
                sqlparam[i++].Value = ProjectProcessInfo.Remark;
                sqlparam[i++].Value = ProjectProcessInfo.PrepaidAmount;
                sqlparam[i++].Value = ProjectProcessInfo.Use;
                sqlparam[i++].Value = ProjectProcessInfo.ImprestRemark;
                sqlparam[i++].Value = ProjectProcessInfo.Status;
                sqlparam[i++].Value = ProjectProcessInfo.NextOperaterId;
                sqlparam[i++].Value = ProjectProcessInfo.NextOperaterAccount;
                sqlparam[i++].Value = ProjectProcessInfo.NextOperaterName;
                sqlparam[i++].Value = ProjectProcessInfo.CreateTime;
                sqlparam[i++].Value = ProjectProcessInfo.CreaterId;
                sqlparam[i++].Value = ProjectProcessInfo.CreaterName;
                sqlparam[i++].Value = ProjectProcessInfo.CreaterAccount;
                sqlparam[i++].Value = ProjectProcessInfo.SubmitTime;
                sqlparam[i++].Value = ProjectProcessInfo.AuditOpinion;
                sqlparam[i++].Value = ProjectProcessInfo.AccountingRemark;
                sqlparam[i++].Value = ProjectProcessInfo.Adulters;
                sqlparam[i++].Value = ProjectProcessInfo.IsPassImprest;
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
        /// ProjectProcess 查询,返回Datatable
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="selectCondition">查询条件</param>
        /// <returns>DataTable</returns>
        public DataTable Select(string boName, string condition)
        {
            try
            {
                //存储过程名称
                string strsql = "ProjectProcess_Search";
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
        ///ProjectProcess 查询,返回List
        ///</summary>
        ///<param name="boName">数据库连接配置key信息</param>
        ///<param name="selectCondition">查询条件</param>
        /// <returns>List<ProjectProcessInfo></returns>
        public List<ProjectProcessInfo> SelectAsList(string boName, string selectCondition)
        {
            DataTable table = new DataTable();
            List<ProjectProcessInfo> list = new List<ProjectProcessInfo>();
            ProjectProcessInfo accountInfo = new ProjectProcessInfo();

            try
            {
                table = Select(boName, selectCondition);

                // DataTable To ArrayList
                foreach (DataRow row in table.Rows)
                {
                    accountInfo = ProjectProcessInfoRowToInfo(row);
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
        /// <param name="ProjectProcessDataRow">ProjectProcessDataRow</param>
        /// <returns>ProjectProcessInfo</returns>
        internal ProjectProcessInfo ProjectProcessInfoRowToInfo(DataRow ProjectProcessInfoInfoDataRow)
        {
            ProjectProcessInfo ProjectProcessInfoInfo = new ProjectProcessInfo();
            if (ProjectProcessInfoInfoDataRow["ObjectId"] != null)
            {
                ProjectProcessInfoInfo.ObjectId = new Guid(DataUtil.GetStringValueOfRow(ProjectProcessInfoInfoDataRow, "ObjectId"));
            }
            if (ProjectProcessInfoInfoDataRow["ForId"] != null)
            {
                ProjectProcessInfoInfo.ForId = new Guid(DataUtil.GetStringValueOfRow(ProjectProcessInfoInfoDataRow, "ForId"));
            }
            if (ProjectProcessInfoInfoDataRow["ProjectName"] != null)
            {
                ProjectProcessInfoInfo.ProjectName = DataUtil.GetStringValueOfRow(ProjectProcessInfoInfoDataRow, "ProjectName");
            }
            if (ProjectProcessInfoInfoDataRow["NeedImprest"] != null)
            {
                ProjectProcessInfoInfo.NeedImprest = bool.Parse(DataUtil.GetStringValueOfRow(ProjectProcessInfoInfoDataRow, "NeedImprest"));
            }
            if (ProjectProcessInfoInfoDataRow["ImplementationPhase"] != null)
            {
                ProjectProcessInfoInfo.ImplementationPhase = DataUtil.GetStringValueOfRow(ProjectProcessInfoInfoDataRow, "ImplementationPhase");
            }
            if (ProjectProcessInfoInfoDataRow["AmountExpended"] != null)
            {
                ProjectProcessInfoInfo.AmountExpended = Decimal.Parse(DataUtil.GetStringValueOfRow(ProjectProcessInfoInfoDataRow, "AmountExpended"));
            }
            if (ProjectProcessInfoInfoDataRow["ExpendedTime"] != null)
            {
                ProjectProcessInfoInfo.ExpendedTime = DataUtil.GetStringValueOfRow(ProjectProcessInfoInfoDataRow, "ExpendedTime");
            }
            if (ProjectProcessInfoInfoDataRow["ImprestAmount"] != null)
            {
                ProjectProcessInfoInfo.ImprestAmount = Decimal.Parse(DataUtil.GetStringValueOfRow(ProjectProcessInfoInfoDataRow, "ImprestAmount"));
            }
            if (ProjectProcessInfoInfoDataRow["Remark"] != null)
            {
                ProjectProcessInfoInfo.Remark = DataUtil.GetStringValueOfRow(ProjectProcessInfoInfoDataRow, "Remark");
            }
            if (ProjectProcessInfoInfoDataRow["PrepaidAmount"] != null)
            {
                ProjectProcessInfoInfo.PrepaidAmount = Decimal.Parse(DataUtil.GetStringValueOfRow(ProjectProcessInfoInfoDataRow, "PrepaidAmount"));
            }
            if (ProjectProcessInfoInfoDataRow["Use"] != null)
            {
                ProjectProcessInfoInfo.Use = DataUtil.GetStringValueOfRow(ProjectProcessInfoInfoDataRow, "Use");
            }
            if (ProjectProcessInfoInfoDataRow["ImprestRemark"] != null)
            {
                ProjectProcessInfoInfo.ImprestRemark = DataUtil.GetStringValueOfRow(ProjectProcessInfoInfoDataRow, "ImprestRemark");
            }
            if (ProjectProcessInfoInfoDataRow["Status"] != null)
            {
                ProjectProcessInfoInfo.Status = int.Parse(DataUtil.GetStringValueOfRow(ProjectProcessInfoInfoDataRow, "Status"));
            }
            if (ProjectProcessInfoInfoDataRow["NextOperaterId"] != null)
            {
                ProjectProcessInfoInfo.NextOperaterId = new Guid(DataUtil.GetStringValueOfRow(ProjectProcessInfoInfoDataRow, "NextOperaterId"));
            }
            if (ProjectProcessInfoInfoDataRow["NextOperaterAccount"] != null)
            {
                ProjectProcessInfoInfo.NextOperaterAccount = DataUtil.GetStringValueOfRow(ProjectProcessInfoInfoDataRow, "NextOperaterAccount");
            }
            if (ProjectProcessInfoInfoDataRow["NextOperaterName"] != null)
            {
                ProjectProcessInfoInfo.NextOperaterName = DataUtil.GetStringValueOfRow(ProjectProcessInfoInfoDataRow, "NextOperaterName");
            }
            if (ProjectProcessInfoInfoDataRow["CreateTime"] != null)
            {
                ProjectProcessInfoInfo.CreateTime = DateTime.Parse(DataUtil.GetStringValueOfRow(ProjectProcessInfoInfoDataRow, "CreateTime"));
            }
            if (ProjectProcessInfoInfoDataRow["CreaterId"] != null)
            {
                ProjectProcessInfoInfo.CreaterId = new Guid(DataUtil.GetStringValueOfRow(ProjectProcessInfoInfoDataRow, "CreaterId"));
            }
            if (ProjectProcessInfoInfoDataRow["CreaterName"] != null)
            {
                ProjectProcessInfoInfo.CreaterName = DataUtil.GetStringValueOfRow(ProjectProcessInfoInfoDataRow, "CreaterName");
            }
            if (ProjectProcessInfoInfoDataRow["CreaterAccount"] != null)
            {
                ProjectProcessInfoInfo.CreaterAccount = DataUtil.GetStringValueOfRow(ProjectProcessInfoInfoDataRow, "CreaterAccount");
            }
            if (ProjectProcessInfoInfoDataRow["SubmitTime"] != null)
            {
                ProjectProcessInfoInfo.SubmitTime = DateTime.Parse(DataUtil.GetStringValueOfRow(ProjectProcessInfoInfoDataRow, "SubmitTime"));
            }
            if (ProjectProcessInfoInfoDataRow["AuditOpinion"] != null)
            {
                ProjectProcessInfoInfo.AuditOpinion = DataUtil.GetStringValueOfRow(ProjectProcessInfoInfoDataRow, "AuditOpinion");
            }
            if (ProjectProcessInfoInfoDataRow["AccountingRemark"] != null)
            {
                ProjectProcessInfoInfo.AccountingRemark = DataUtil.GetStringValueOfRow(ProjectProcessInfoInfoDataRow, "AccountingRemark");
            }
            if (ProjectProcessInfoInfoDataRow["Adulters"] != null)
            {
                ProjectProcessInfoInfo.Adulters = DataUtil.GetStringValueOfRow(ProjectProcessInfoInfoDataRow, "Adulters");
            }
            if (ProjectProcessInfoInfoDataRow["IsPassImprest"] != null)
            {
                ProjectProcessInfoInfo.IsPassImprest = bool.Parse(DataUtil.GetStringValueOfRow(ProjectProcessInfoInfoDataRow, "IsPassImprest"));
            }
            return ProjectProcessInfoInfo;
        }
        #endregion
    }
}
