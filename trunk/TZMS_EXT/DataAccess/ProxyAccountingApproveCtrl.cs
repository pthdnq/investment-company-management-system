//----------------------------------------------------------------------------------------------------
//程序名:	ProxyAccountingApprove 控制类
//功能:  	定义了与 dbo.ProxyAccountingApprove 表 对应的数据访问控制类
//作者:  	xiguazerg
//时间:	2009-10-16 
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
using com.TZMS.Model;
using Com.iFlytek.Utility;

namespace com.TZMS.DataAccess
{
    /// <summary>
    /// ProxyAccountingApproveCtrl
    /// programmer:xiguazerg
    /// </summary>
    public class ProxyAccountingApproveCtrl
    {
        #region 构造函数

        /// <summary>
        /// ProxyAccountingApproveCtrl默认构造函数
        /// </summary>
        public ProxyAccountingApproveCtrl()
        {
            //ToDo
        }

        #endregion

        #region 增、删、改、查

        /// <summary>
        /// 插入dbo.ProxyAccountingApprove一条记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="ProxyAccountingApproveInfo">ProxyAccountingApproveInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int Insert(string boName, ProxyAccountingApproveInfo ProxyAccountingApproveInfo)
        {
            try
            {
                //存储过程名称
                string strsql = "ProxyAccountingApprove_Add";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjectID",DbType.Guid),
				new SqlParameter("@ApproverID",DbType.Guid),
				new SqlParameter("@ApproverName",DbType.String),
				new SqlParameter("@ApproverDept",DbType.String),
				new SqlParameter("@ApproveDate",DbType.DateTime),
				new SqlParameter("@ApproveState",DbType.Int16),
				new SqlParameter("@Result",DbType.Int16),
				new SqlParameter("@Sugest",DbType.String),
				new SqlParameter("@ApproveOp",DbType.Int16),
				new SqlParameter("@ApplyID",DbType.Guid),
				};

                int i = 0;
                sqlparam[i++].Value = ProxyAccountingApproveInfo.ObjectID;
                sqlparam[i++].Value = ProxyAccountingApproveInfo.ApproverID;
                sqlparam[i++].Value = ProxyAccountingApproveInfo.ApproverName;
                sqlparam[i++].Value = ProxyAccountingApproveInfo.ApproverDept;
                sqlparam[i++].Value = ProxyAccountingApproveInfo.ApproveDate;
                sqlparam[i++].Value = ProxyAccountingApproveInfo.ApproveState;
                sqlparam[i++].Value = ProxyAccountingApproveInfo.Result;
                sqlparam[i++].Value = ProxyAccountingApproveInfo.Sugest;
                sqlparam[i++].Value = ProxyAccountingApproveInfo.ApproveOp;
                sqlparam[i++].Value = ProxyAccountingApproveInfo.ApplyID;
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
        /// dbo.ProxyAccountingApprove删除记录(通过记录ID ObjectID)
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="objectID">ObjectID(唯一ID)</param>
        public void Delete(string boName, string objectID)
        {
            try
            {
                string strsql = "ProxyAccountingApprove_Delete";

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
        /// ProxyAccountingApprove 更新记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="ProxyAccountingApproveInfo">ProxyAccountingApproveInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int UpDate(string boName, ProxyAccountingApproveInfo ProxyAccountingApproveInfo)
        {
            try
            {
                //存储过程名称
                string strsql = "ProxyAccountingApprove_Update";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjectID",DbType.Guid),
				new SqlParameter("@ApproverID",DbType.Guid),
				new SqlParameter("@ApproverName",DbType.String),
				new SqlParameter("@ApproverDept",DbType.String),
				new SqlParameter("@ApproveDate",DbType.DateTime),
				new SqlParameter("@ApproveState",DbType.Int16),
				new SqlParameter("@Result",DbType.Int16),
				new SqlParameter("@Sugest",DbType.String),
				new SqlParameter("@ApproveOp",DbType.Int16),
				new SqlParameter("@ApplyID",DbType.Guid),
                };

                int i = 0;
                sqlparam[i++].Value = ProxyAccountingApproveInfo.ObjectID;
                sqlparam[i++].Value = ProxyAccountingApproveInfo.ApproverID;
                sqlparam[i++].Value = ProxyAccountingApproveInfo.ApproverName;
                sqlparam[i++].Value = ProxyAccountingApproveInfo.ApproverDept;
                sqlparam[i++].Value = ProxyAccountingApproveInfo.ApproveDate;
                sqlparam[i++].Value = ProxyAccountingApproveInfo.ApproveState;
                sqlparam[i++].Value = ProxyAccountingApproveInfo.Result;
                sqlparam[i++].Value = ProxyAccountingApproveInfo.Sugest;
                sqlparam[i++].Value = ProxyAccountingApproveInfo.ApproveOp;
                sqlparam[i++].Value = ProxyAccountingApproveInfo.ApplyID;
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
        /// ProxyAccountingApprove 查询,返回Datatable
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="selectCondition">查询条件</param>
        /// <returns>DataTable</returns>
        public DataTable Select(string boName, string condition)
        {
            try
            {
                //存储过程名称
                string strsql = "ProxyAccountingApprove_Search";
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
        ///ProxyAccountingApprove 查询,返回List
        ///</summary>
        ///<param name="boName">数据库连接配置key信息</param>
        ///<param name="selectCondition">查询条件</param>
        /// <returns>List<ProxyAccountingApproveInfo></returns>
        public List<ProxyAccountingApproveInfo> SelectAsList(string boName, string selectCondition)
        {
            DataTable table = new DataTable();
            List<ProxyAccountingApproveInfo> list = new List<ProxyAccountingApproveInfo>();
            ProxyAccountingApproveInfo accountInfo = new ProxyAccountingApproveInfo();

            try
            {
                table = Select(boName, selectCondition);

                // DataTable To ArrayList
                foreach (DataRow row in table.Rows)
                {
                    accountInfo = ProxyAccountingApproveInfoRowToInfo(row);
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
        /// <param name="ProxyAccountingApproveDataRow">ProxyAccountingApproveDataRow</param>
        /// <returns>ProxyAccountingApproveInfo</returns>
        internal ProxyAccountingApproveInfo ProxyAccountingApproveInfoRowToInfo(DataRow InfoDataRow)
        {
            ProxyAccountingApproveInfo Info = new ProxyAccountingApproveInfo();
            if (InfoDataRow["ObjectID"] != null)
            {
                Info.ObjectID = new Guid(DataUtil.GetStringValueOfRow(InfoDataRow, "ObjectID"));
            }
            if (InfoDataRow["ApproverID"] != null)
            {
                Info.ApproverID = new Guid(DataUtil.GetStringValueOfRow(InfoDataRow, "ApproverID"));
            }
            if (InfoDataRow["ApproverName"] != null)
            {
                Info.ApproverName = DataUtil.GetStringValueOfRow(InfoDataRow, "ApproverName");
            }
            if (InfoDataRow["ApproverDept"] != null)
            {
                Info.ApproverDept = DataUtil.GetStringValueOfRow(InfoDataRow, "ApproverDept");
            }
            if (InfoDataRow["ApproveDate"] != null)
            {
                Info.ApproveDate = DateTime.Parse(DataUtil.GetStringValueOfRow(InfoDataRow, "ApproveDate"));
            }
            if (InfoDataRow["ApproveState"] != null)
            {
                Info.ApproveState = short.Parse(DataUtil.GetStringValueOfRow(InfoDataRow, "ApproveState"));
            }
            if (InfoDataRow["Result"] != null)
            {
                Info.Result = short.Parse(DataUtil.GetStringValueOfRow(InfoDataRow, "Result"));
            }
            if (InfoDataRow["Sugest"] != null)
            {
                Info.Sugest = DataUtil.GetStringValueOfRow(InfoDataRow, "Sugest");
            }
            if (InfoDataRow["ApproveOp"] != null)
            {
                Info.ApproveOp = short.Parse(DataUtil.GetStringValueOfRow(InfoDataRow, "ApproveOp"));
            }
            if (InfoDataRow["ApplyID"] != null)
            {
                Info.ApplyID = new Guid(DataUtil.GetStringValueOfRow(InfoDataRow, "ApplyID"));
            }

            return Info;
        }
        #endregion
    }
}
