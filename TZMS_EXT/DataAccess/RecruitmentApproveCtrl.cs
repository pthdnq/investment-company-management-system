//----------------------------------------------------------------------------------------------------
//程序名:	RecruitmentApprove 控制类
//功能:  	定义了与 dbo.RecruitmentApprove 表 对应的数据访问控制类
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
    /// RecruitmentApproveCtrl
    /// programmer:xiguazerg
    /// </summary>
    public class RecruitmentApproveCtrl
    {
        #region 构造函数

        /// <summary>
        /// RecruitmentApproveCtrl默认构造函数
        /// </summary>
        public RecruitmentApproveCtrl()
        {
            //ToDo
        }

        #endregion

        #region 增、删、改、查

        /// <summary>
        /// 插入dbo.RecruitmentApprove一条记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="RecruitmentApproveInfo">RecruitmentApproveInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int Insert(string boName, RecruitmentApproveInfo RecruitmentApproveInfo)
        {
            try
            {
                //存储过程名称
                string strsql = "RecruitmentApprove_Add";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjectID",DbType.Guid),
				new SqlParameter("@ApproverID",DbType.Guid),
				new SqlParameter("@ApproverName",DbType.String),
				new SqlParameter("@ApproverDept",DbType.String),
				new SqlParameter("@ApproveTime",DbType.DateTime),
				new SqlParameter("@ApproveState",DbType.Int16),
				new SqlParameter("@Result",DbType.Int16),
				new SqlParameter("@ApproveOp",DbType.Int16),
				new SqlParameter("@Sugest",DbType.String),
				new SqlParameter("@ApplyID",DbType.Guid),
				};

                int i = 0;
                sqlparam[i++].Value = RecruitmentApproveInfo.ObjectID;
                sqlparam[i++].Value = RecruitmentApproveInfo.ApproverID;
                sqlparam[i++].Value = RecruitmentApproveInfo.ApproverName;
                sqlparam[i++].Value = RecruitmentApproveInfo.ApproverDept;
                sqlparam[i++].Value = RecruitmentApproveInfo.ApproveTime;
                sqlparam[i++].Value = RecruitmentApproveInfo.ApproveState;
                sqlparam[i++].Value = RecruitmentApproveInfo.Result;
                sqlparam[i++].Value = RecruitmentApproveInfo.ApproveOp;
                sqlparam[i++].Value = RecruitmentApproveInfo.Sugest;
                sqlparam[i++].Value = RecruitmentApproveInfo.ApplyID;
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
        /// dbo.RecruitmentApprove删除记录(通过记录ID ObjectID)
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="objectID">ObjectID(唯一ID)</param>
        public void Delete(string boName, string objectID)
        {
            try
            {
                string strsql = "RecruitmentApprove_Delete";

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
        /// RecruitmentApprove 更新记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="RecruitmentApproveInfo">RecruitmentApproveInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int UpDate(string boName, RecruitmentApproveInfo RecruitmentApproveInfo)
        {
            try
            {
                //存储过程名称
                string strsql = "RecruitmentApprove_Update";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjectID",DbType.Guid),
				new SqlParameter("@ApproverID",DbType.Guid),
				new SqlParameter("@ApproverName",DbType.String),
				new SqlParameter("@ApproverDept",DbType.String),
				new SqlParameter("@ApproveTime",DbType.DateTime),
				new SqlParameter("@ApproveState",DbType.Int16),
				new SqlParameter("@Result",DbType.Int16),
				new SqlParameter("@ApproveOp",DbType.Int16),
				new SqlParameter("@Sugest",DbType.String),
				new SqlParameter("@ApplyID",DbType.Guid),
                };

                int i = 0;
                sqlparam[i++].Value = RecruitmentApproveInfo.ObjectID;
                sqlparam[i++].Value = RecruitmentApproveInfo.ApproverID;
                sqlparam[i++].Value = RecruitmentApproveInfo.ApproverName;
                sqlparam[i++].Value = RecruitmentApproveInfo.ApproverDept;
                sqlparam[i++].Value = RecruitmentApproveInfo.ApproveTime;
                sqlparam[i++].Value = RecruitmentApproveInfo.ApproveState;
                sqlparam[i++].Value = RecruitmentApproveInfo.Result;
                sqlparam[i++].Value = RecruitmentApproveInfo.ApproveOp;
                sqlparam[i++].Value = RecruitmentApproveInfo.Sugest;
                sqlparam[i++].Value = RecruitmentApproveInfo.ApplyID;
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
        /// RecruitmentApprove 查询,返回Datatable
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="selectCondition">查询条件</param>
        /// <returns>DataTable</returns>
        public DataTable Select(string boName, string condition)
        {
            try
            {
                //存储过程名称
                string strsql = "RecruitmentApprove_Search";
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
        ///RecruitmentApprove 查询,返回List
        ///</summary>
        ///<param name="boName">数据库连接配置key信息</param>
        ///<param name="selectCondition">查询条件</param>
        /// <returns>List<RecruitmentApproveInfo></returns>
        public List<RecruitmentApproveInfo> SelectAsList(string boName, string selectCondition)
        {
            DataTable table = new DataTable();
            List<RecruitmentApproveInfo> list = new List<RecruitmentApproveInfo>();
            RecruitmentApproveInfo accountInfo = new RecruitmentApproveInfo();

            try
            {
                table = Select(boName, selectCondition);

                // DataTable To ArrayList
                foreach (DataRow row in table.Rows)
                {
                    accountInfo = RecruitmentApproveInfoRowToInfo(row);
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
        /// <param name="RecruitmentApproveDataRow">RecruitmentApproveDataRow</param>
        /// <returns>RecruitmentApproveInfo</returns>
        internal RecruitmentApproveInfo RecruitmentApproveInfoRowToInfo(DataRow InfoDataRow)
        {
            RecruitmentApproveInfo Info = new RecruitmentApproveInfo();
            if (InfoDataRow["ObjectID"] != null)
            {
                Info.ObjectID = new Guid( DataUtil.GetStringValueOfRow(InfoDataRow, "ObjectID"));
            }
            if (InfoDataRow["ApproverID"] != null)
            {
                Info.ApproverID = new Guid( DataUtil.GetStringValueOfRow(InfoDataRow, "ApproverID"));
            }
            if (InfoDataRow["ApproverName"] != null)
            {
                Info.ApproverName = DataUtil.GetStringValueOfRow(InfoDataRow, "ApproverName");
            }
            if (InfoDataRow["ApproverDept"] != null)
            {
                Info.ApproverDept = DataUtil.GetStringValueOfRow(InfoDataRow, "ApproverDept");
            }
            if (InfoDataRow["ApproveTime"] != null)
            {
                Info.ApproveTime = DateTime.Parse( DataUtil.GetStringValueOfRow(InfoDataRow, "ApproveTime"));
            }
            if (InfoDataRow["ApproveState"] != null)
            {
                Info.ApproveState = short.Parse( DataUtil.GetStringValueOfRow(InfoDataRow, "ApproveState"));
            }
            if (InfoDataRow["Result"] != null)
            {
                Info.Result = short.Parse( DataUtil.GetStringValueOfRow(InfoDataRow, "Result"));
            }
            if (InfoDataRow["ApproveOp"] != null)
            {
                Info.ApproveOp = short.Parse( DataUtil.GetStringValueOfRow(InfoDataRow, "ApproveOp"));
            }
            if (InfoDataRow["Sugest"] != null)
            {
                Info.Sugest = DataUtil.GetStringValueOfRow(InfoDataRow, "Sugest");
            }
            if (InfoDataRow["ApplyID"] != null)
            {
                Info.ApplyID = new Guid( DataUtil.GetStringValueOfRow(InfoDataRow, "ApplyID"));
            }

            return Info;
        }
        #endregion
    }
}
