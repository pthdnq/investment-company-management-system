//----------------------------------------------------------------------------------------------------
//程序名:	ProbationApply 控制类
//功能:  	定义了与 dbo.ProbationApply 表 对应的数据访问控制类
//作者:  	xiguazerg
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
    /// ProbationApplyCtrl
    /// programmer:xiguazerg
    /// </summary>
    public class ProbationApplyCtrl
    {
        #region 构造函数

        /// <summary>
        /// ProbationApplyCtrl默认构造函数
        /// </summary>
        public ProbationApplyCtrl()
        {
            //ToDo
        }

        #endregion

        #region 增、删、改、查

        /// <summary>
        /// 插入dbo.ProbationApply一条记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="ProbationApplyInfo">ProbationApplyInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int Insert(string boName, ProbationApplyInfo ProbationApplyInfo)
        {
            try
            {
                //存储过程名称
                string strsql = "ProbationApply_Add";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjectID",DbType.Guid),
				new SqlParameter("@UserID",DbType.Guid),
				new SqlParameter("@UserName",DbType.String),
				new SqlParameter("@UserJobNo",DbType.String),
				new SqlParameter("@UserAccountNo",DbType.String),
				new SqlParameter("@UserDept",DbType.String),
				new SqlParameter("@Sument",DbType.String),
				new SqlParameter("@Other",DbType.String),
				new SqlParameter("@ApplyTime",DbType.DateTime),
				new SqlParameter("@CurrentApproverID",DbType.Guid),
				new SqlParameter("@State",DbType.Int16),
				new SqlParameter("@IsDelete",DbType.Boolean),
				};

                int i = 0;
                sqlparam[i++].Value = ProbationApplyInfo.ObjectID;
                sqlparam[i++].Value = ProbationApplyInfo.UserID;
                sqlparam[i++].Value = ProbationApplyInfo.UserName;
                sqlparam[i++].Value = ProbationApplyInfo.UserJobNo;
                sqlparam[i++].Value = ProbationApplyInfo.UserAccountNo;
                sqlparam[i++].Value = ProbationApplyInfo.UserDept;
                sqlparam[i++].Value = ProbationApplyInfo.Sument;
                sqlparam[i++].Value = ProbationApplyInfo.Other;
                sqlparam[i++].Value = ProbationApplyInfo.ApplyTime;
                sqlparam[i++].Value = ProbationApplyInfo.CurrentApproverID;
                sqlparam[i++].Value = ProbationApplyInfo.State;
                sqlparam[i++].Value = ProbationApplyInfo.IsDelete;
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
        /// dbo.ProbationApply删除记录(通过记录ID ObjectID)
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="objectID">ObjectID(唯一ID)</param>
        public void Delete(string boName, string objectID)
        {
            try
            {
                string strsql = "ProbationApply_Delete";

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
        /// ProbationApply 更新记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="ProbationApplyInfo">ProbationApplyInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int UpDate(string boName, ProbationApplyInfo ProbationApplyInfo)
        {
            try
            {
                //存储过程名称
                string strsql = "ProbationApply_Update";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjectID",DbType.Guid),
				new SqlParameter("@UserID",DbType.Guid),
				new SqlParameter("@UserName",DbType.String),
				new SqlParameter("@UserJobNo",DbType.String),
				new SqlParameter("@UserAccountNo",DbType.String),
				new SqlParameter("@UserDept",DbType.String),
				new SqlParameter("@Sument",DbType.String),
				new SqlParameter("@Other",DbType.String),
				new SqlParameter("@ApplyTime",DbType.DateTime),
				new SqlParameter("@CurrentApproverId",DbType.Guid),
				new SqlParameter("@State",DbType.Int16),
				new SqlParameter("@IsDelete",DbType.Boolean),
                };

                int i = 0;
                sqlparam[i++].Value = ProbationApplyInfo.ObjectID;
                sqlparam[i++].Value = ProbationApplyInfo.UserID;
                sqlparam[i++].Value = ProbationApplyInfo.UserName;
                sqlparam[i++].Value = ProbationApplyInfo.UserJobNo;
                sqlparam[i++].Value = ProbationApplyInfo.UserAccountNo;
                sqlparam[i++].Value = ProbationApplyInfo.UserDept;
                sqlparam[i++].Value = ProbationApplyInfo.Sument;
                sqlparam[i++].Value = ProbationApplyInfo.Other;
                sqlparam[i++].Value = ProbationApplyInfo.ApplyTime;
                sqlparam[i++].Value = ProbationApplyInfo.CurrentApproverID;
                sqlparam[i++].Value = ProbationApplyInfo.State;
                sqlparam[i++].Value = ProbationApplyInfo.IsDelete;
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
        /// ProbationApply 查询,返回Datatable
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="selectCondition">查询条件</param>
        /// <returns>DataTable</returns>
        public DataTable Select(string boName, string condition)
        {
            try
            {
                //存储过程名称
                string strsql = "ProbationApply_Search";
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
        ///ProbationApply 查询,返回List
        ///</summary>
        ///<param name="boName">数据库连接配置key信息</param>
        ///<param name="selectCondition">查询条件</param>
        /// <returns>List<ProbationApplyInfo></returns>
        public List<ProbationApplyInfo> SelectAsList(string boName, string selectCondition)
        {
            DataTable table = new DataTable();
            List<ProbationApplyInfo> list = new List<ProbationApplyInfo>();
            ProbationApplyInfo accountInfo = new ProbationApplyInfo();

            try
            {
                table = Select(boName, selectCondition);

                // DataTable To ArrayList
                foreach (DataRow row in table.Rows)
                {
                    accountInfo = ProbationApplyInfoRowToInfo(row);
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
        /// <param name="ProbationApplyDataRow">ProbationApplyDataRow</param>
        /// <returns>ProbationApplyInfo</returns>
        internal ProbationApplyInfo ProbationApplyInfoRowToInfo(DataRow InfoDataRow)
        {
            ProbationApplyInfo Info = new ProbationApplyInfo();
            if (InfoDataRow["ObjectID"] != null)
            {
                Info.ObjectID = new Guid(DataUtil.GetStringValueOfRow(InfoDataRow, "ObjectID"));
            }
            if (InfoDataRow["UserID"] != null)
            {
                Info.UserID = new Guid(DataUtil.GetStringValueOfRow(InfoDataRow, "UserID"));
            }
            if (InfoDataRow["UserName"] != null)
            {
                Info.UserName = DataUtil.GetStringValueOfRow(InfoDataRow, "UserName");
            }
            if (InfoDataRow["UserJobNo"] != null)
            {
                Info.UserJobNo = DataUtil.GetStringValueOfRow(InfoDataRow, "UserJobNo");
            }
            if (InfoDataRow["UserAccountNo"] != null)
            {
                Info.UserAccountNo = DataUtil.GetStringValueOfRow(InfoDataRow, "UserAccountNo");
            }
            if (InfoDataRow["UserDept"] != null)
            {
                Info.UserDept = DataUtil.GetStringValueOfRow(InfoDataRow, "UserDept");
            }
            if (InfoDataRow["Sument"] != null)
            {
                Info.Sument = DataUtil.GetStringValueOfRow(InfoDataRow, "Sument");
            }
            if (InfoDataRow["Other"] != null)
            {
                Info.Other = DataUtil.GetStringValueOfRow(InfoDataRow, "Other");
            }
            if (InfoDataRow["ApplyTime"] != null)
            {
                Info.ApplyTime = DateTime.Parse( DataUtil.GetStringValueOfRow(InfoDataRow, "ApplyTime"));
            }
            if (InfoDataRow["CurrentApproverID"] != null)
            {
                Info.CurrentApproverID = new Guid(DataUtil.GetStringValueOfRow(InfoDataRow, "CurrentApproverID"));
            }
            if (InfoDataRow["State"] != null)
            {
                Info.State = short.Parse( DataUtil.GetStringValueOfRow(InfoDataRow, "State"));
            }
            if (InfoDataRow["IsDelete"] != null)
            {
                Info.IsDelete = bool.Parse( DataUtil.GetStringValueOfRow(InfoDataRow, "IsDelete"));
            }

            return Info;
        }
        #endregion
    }
}
