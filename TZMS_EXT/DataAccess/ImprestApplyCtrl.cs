//----------------------------------------------------------------------------------------------------
//程序名:	ImprestApply 控制类
//功能:  	定义了与 dbo.ImprestApply 表 对应的数据访问控制类
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
    /// ImprestApplyCtrl
    /// programmer:xiguazerg
    /// </summary>
    public class ImprestApplyCtrl
    {
        #region 构造函数

        /// <summary>
        /// ImprestApplyCtrl默认构造函数
        /// </summary>
        public ImprestApplyCtrl()
        {
            //ToDo
        }

        #endregion

        #region 增、删、改、查

        /// <summary>
        /// 插入dbo.ImprestApply一条记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="ImprestApplyInfo">ImprestApplyInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int Insert(string boName, ImprestApplyInfo ImprestApplyInfo)
        {
            try
            {
                //存储过程名称
                string strsql = "ImprestApply_Add";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjectID",DbType.Guid),
				new SqlParameter("@UserID",DbType.Guid),
				new SqlParameter("@UserName",DbType.String),
				new SqlParameter("@UserJobNo",DbType.String),
				new SqlParameter("@UserAccountNo",DbType.String),
				new SqlParameter("@UserDept",DbType.String),
				new SqlParameter("@YeWuID",DbType.Guid),
				new SqlParameter("@Sument",DbType.String),
				new SqlParameter("@Money",DbType.Guid),
				new SqlParameter("@ApplyTime",DbType.DateTime),
				new SqlParameter("@CurrentApproverID",DbType.Guid),
				new SqlParameter("@State",DbType.Int16),
				new SqlParameter("@IsDelete",DbType.Boolean),
				};

                int i = 0;
                sqlparam[i++].Value = ImprestApplyInfo.ObjectID;
                sqlparam[i++].Value = ImprestApplyInfo.UserID;
                sqlparam[i++].Value = ImprestApplyInfo.UserName;
                sqlparam[i++].Value = ImprestApplyInfo.UserJobNo;
                sqlparam[i++].Value = ImprestApplyInfo.UserAccountNo;
                sqlparam[i++].Value = ImprestApplyInfo.UserDept;
                sqlparam[i++].Value = ImprestApplyInfo.YeWuID;
                sqlparam[i++].Value = ImprestApplyInfo.Sument;
                sqlparam[i++].Value = ImprestApplyInfo.Money;
                sqlparam[i++].Value = ImprestApplyInfo.ApplyTime;
                sqlparam[i++].Value = ImprestApplyInfo.CurrentApproverID;
                sqlparam[i++].Value = ImprestApplyInfo.State;
                sqlparam[i++].Value = ImprestApplyInfo.IsDelete;
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
        /// dbo.ImprestApply删除记录(通过记录ID ObjectID)
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="objectID">ObjectID(唯一ID)</param>
        public void Delete(string boName, string objectID)
        {
            try
            {
                string strsql = "ImprestApply_Delete";

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
        /// ImprestApply 更新记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="ImprestApplyInfo">ImprestApplyInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int UpDate(string boName, ImprestApplyInfo ImprestApplyInfo)
        {
            try
            {
                //存储过程名称
                string strsql = "ImprestApply_Update";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjectID",DbType.Guid),
				new SqlParameter("@UserID",DbType.Guid),
				new SqlParameter("@UserName",DbType.String),
				new SqlParameter("@UserJobNo",DbType.String),
				new SqlParameter("@UserAccountNo",DbType.String),
				new SqlParameter("@UserDept",DbType.String),
				new SqlParameter("@YeWuID",DbType.Guid),
				new SqlParameter("@Sument",DbType.String),
				new SqlParameter("@Money",DbType.Guid),
				new SqlParameter("@ApplyTime",DbType.DateTime),
				new SqlParameter("@CurrentApproverID",DbType.Guid),
				new SqlParameter("@State",DbType.Int16),
				new SqlParameter("@IsDelete",DbType.Boolean),
                };

                int i = 0;
                sqlparam[i++].Value = ImprestApplyInfo.ObjectID;
                sqlparam[i++].Value = ImprestApplyInfo.UserID;
                sqlparam[i++].Value = ImprestApplyInfo.UserName;
                sqlparam[i++].Value = ImprestApplyInfo.UserJobNo;
                sqlparam[i++].Value = ImprestApplyInfo.UserAccountNo;
                sqlparam[i++].Value = ImprestApplyInfo.UserDept;
                sqlparam[i++].Value = ImprestApplyInfo.YeWuID;
                sqlparam[i++].Value = ImprestApplyInfo.Sument;
                sqlparam[i++].Value = ImprestApplyInfo.Money;
                sqlparam[i++].Value = ImprestApplyInfo.ApplyTime;
                sqlparam[i++].Value = ImprestApplyInfo.CurrentApproverID;
                sqlparam[i++].Value = ImprestApplyInfo.State;
                sqlparam[i++].Value = ImprestApplyInfo.IsDelete;
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
        /// ImprestApply 查询,返回Datatable
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="selectCondition">查询条件</param>
        /// <returns>DataTable</returns>
        public DataTable Select(string boName, string condition)
        {
            try
            {
                //存储过程名称
                string strsql = "ImprestApply_Search";
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
        ///ImprestApply 查询,返回List
        ///</summary>
        ///<param name="boName">数据库连接配置key信息</param>
        ///<param name="selectCondition">查询条件</param>
        /// <returns>List<ImprestApplyInfo></returns>
        public List<ImprestApplyInfo> SelectAsList(string boName, string selectCondition)
        {
            DataTable table = new DataTable();
            List<ImprestApplyInfo> list = new List<ImprestApplyInfo>();
            ImprestApplyInfo accountInfo = new ImprestApplyInfo();

            try
            {
                table = Select(boName, selectCondition);

                // DataTable To ArrayList
                foreach (DataRow row in table.Rows)
                {
                    accountInfo = ImprestApplyInfoRowToInfo(row);
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
        /// <param name="ImprestApplyDataRow">ImprestApplyDataRow</param>
        /// <returns>ImprestApplyInfo</returns>
        internal ImprestApplyInfo ImprestApplyInfoRowToInfo(DataRow InfoDataRow)
        {
            ImprestApplyInfo Info = new ImprestApplyInfo();
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
            if (InfoDataRow["YeWuID"] != null)
            {
                Info.YeWuID = new Guid(DataUtil.GetStringValueOfRow(InfoDataRow, "YeWuID"));
            }
            if (InfoDataRow["Sument"] != null)
            {
                Info.Sument = DataUtil.GetStringValueOfRow(InfoDataRow, "Sument");
            }
            if (InfoDataRow["Money"] != null)
            {
                Info.Money = Convert.ToDecimal(DataUtil.GetStringValueOfRow(InfoDataRow, "Money"));
            }
            if (InfoDataRow["ApplyTime"] != null)
            {
                Info.ApplyTime = DateTime.Parse(DataUtil.GetStringValueOfRow(InfoDataRow, "ApplyTime"));
            }
            if (InfoDataRow["CurrentApproverID"] != null)
            {
                Info.CurrentApproverID = new Guid(DataUtil.GetStringValueOfRow(InfoDataRow, "CurrentApproverID"));
            }
            if (InfoDataRow["State"] != null)
            {
                Info.State = short.Parse(DataUtil.GetStringValueOfRow(InfoDataRow, "State"));
            }
            if (InfoDataRow["IsDelete"] != null)
            {
                Info.IsDelete = bool.Parse(DataUtil.GetStringValueOfRow(InfoDataRow, "IsDelete"));
            }

            return Info;
        }
        #endregion
    }
}
