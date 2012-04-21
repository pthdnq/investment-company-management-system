//----------------------------------------------------------------------------------------------------
//程序名:	BusinessImprestApply 控制类
//功能:  	定义了与 dbo.BusinessImprestApply 表 对应的数据访问控制类
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
    /// BusinessImprestApplyCtrl
    /// programmer:xiguazerg
    /// </summary>
    public class BusinessImprestApplyCtrl
    {
        #region 构造函数

        /// <summary>
        /// BusinessImprestApplyCtrl默认构造函数
        /// </summary>
        public BusinessImprestApplyCtrl()
        {
            //ToDo
        }

        #endregion

        #region 增、删、改、查

        /// <summary>
        /// 插入dbo.BusinessImprestApply一条记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="BusinessImprestApplyInfo">BusinessImprestApplyInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int Insert(string boName, BusinessImprestApplyInfo BusinessImprestApplyInfo)
        {
            try
            {
                //存储过程名称
                string strsql = "BusinessImprestApply_Add";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjectID",DbType.Guid),
				new SqlParameter("@UserID",DbType.Guid),
				new SqlParameter("@UserName",DbType.String),
				new SqlParameter("@UserJobNo",DbType.String),
				new SqlParameter("@UserAccountNo",DbType.String),
				new SqlParameter("@UserDept",DbType.String),
				new SqlParameter("@BusinessID",DbType.Guid),
				new SqlParameter("@BusinessType",DbType.Int16),
				new SqlParameter("@BusinessName",DbType.String),
				new SqlParameter("@SumMoney",DbType.Guid),
				new SqlParameter("@ApplySument",DbType.String),
				new SqlParameter("@Sument",DbType.String),
				new SqlParameter("@ApplyTime",DbType.DateTime),
				new SqlParameter("@ApproverID",DbType.Guid),
				new SqlParameter("@State",DbType.Int16),
				new SqlParameter("@IsDelete",DbType.Boolean),
                new SqlParameter("@SumMoneyFlag",DbType.String),
				};

                int i = 0;
                sqlparam[i++].Value = BusinessImprestApplyInfo.ObjectID;
                sqlparam[i++].Value = BusinessImprestApplyInfo.UserID;
                sqlparam[i++].Value = BusinessImprestApplyInfo.UserName;
                sqlparam[i++].Value = BusinessImprestApplyInfo.UserJobNo;
                sqlparam[i++].Value = BusinessImprestApplyInfo.UserAccountNo;
                sqlparam[i++].Value = BusinessImprestApplyInfo.UserDept;
                sqlparam[i++].Value = BusinessImprestApplyInfo.BusinessID;
                sqlparam[i++].Value = BusinessImprestApplyInfo.BusinessType;
                sqlparam[i++].Value = BusinessImprestApplyInfo.BusinessName;
                sqlparam[i++].Value = BusinessImprestApplyInfo.SumMoney;
                sqlparam[i++].Value = BusinessImprestApplyInfo.ApplySument;
                sqlparam[i++].Value = BusinessImprestApplyInfo.Sument;
                sqlparam[i++].Value = BusinessImprestApplyInfo.ApplyTime;
                sqlparam[i++].Value = BusinessImprestApplyInfo.ApproverID;
                sqlparam[i++].Value = BusinessImprestApplyInfo.State;
                sqlparam[i++].Value = BusinessImprestApplyInfo.IsDelete;
                sqlparam[i++].Value = BusinessImprestApplyInfo.SumMoneyFlag;
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
        /// dbo.BusinessImprestApply删除记录(通过记录ID ObjectID)
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="objectID">ObjectID(唯一ID)</param>
        public void Delete(string boName, string objectID)
        {
            try
            {
                string strsql = "BusinessImprestApply_Delete";

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
        /// BusinessImprestApply 更新记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="BusinessImprestApplyInfo">BusinessImprestApplyInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int UpDate(string boName, BusinessImprestApplyInfo BusinessImprestApplyInfo)
        {
            try
            {
                //存储过程名称
                string strsql = "BusinessImprestApply_Update";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjectID",DbType.Guid),
				new SqlParameter("@UserID",DbType.Guid),
				new SqlParameter("@UserName",DbType.String),
				new SqlParameter("@UserJobNo",DbType.String),
				new SqlParameter("@UserAccountNo",DbType.String),
				new SqlParameter("@UserDept",DbType.String),
				new SqlParameter("@BusinessID",DbType.Guid),
				new SqlParameter("@BusinessType",DbType.Int16),
				new SqlParameter("@BusinessName",DbType.String),
				new SqlParameter("@SumMoney",DbType.Guid),
				new SqlParameter("@ApplySument",DbType.String),
				new SqlParameter("@Sument",DbType.String),
				new SqlParameter("@ApplyTime",DbType.DateTime),
				new SqlParameter("@ApproverID",DbType.Guid),
				new SqlParameter("@State",DbType.Int16),
				new SqlParameter("@IsDelete",DbType.Boolean),
                 new SqlParameter("@SumMoneyFlag",DbType.String),
                };

                int i = 0;
                sqlparam[i++].Value = BusinessImprestApplyInfo.ObjectID;
                sqlparam[i++].Value = BusinessImprestApplyInfo.UserID;
                sqlparam[i++].Value = BusinessImprestApplyInfo.UserName;
                sqlparam[i++].Value = BusinessImprestApplyInfo.UserJobNo;
                sqlparam[i++].Value = BusinessImprestApplyInfo.UserAccountNo;
                sqlparam[i++].Value = BusinessImprestApplyInfo.UserDept;
                sqlparam[i++].Value = BusinessImprestApplyInfo.BusinessID;
                sqlparam[i++].Value = BusinessImprestApplyInfo.BusinessType;
                sqlparam[i++].Value = BusinessImprestApplyInfo.BusinessName;
                sqlparam[i++].Value = BusinessImprestApplyInfo.SumMoney;
                sqlparam[i++].Value = BusinessImprestApplyInfo.ApplySument;
                sqlparam[i++].Value = BusinessImprestApplyInfo.Sument;
                sqlparam[i++].Value = BusinessImprestApplyInfo.ApplyTime;
                sqlparam[i++].Value = BusinessImprestApplyInfo.ApproverID;
                sqlparam[i++].Value = BusinessImprestApplyInfo.State;
                sqlparam[i++].Value = BusinessImprestApplyInfo.IsDelete;
                sqlparam[i++].Value = BusinessImprestApplyInfo.SumMoneyFlag;
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
        /// BusinessImprestApply 查询,返回Datatable
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="selectCondition">查询条件</param>
        /// <returns>DataTable</returns>
        public DataTable Select(string boName, string condition)
        {
            try
            {
                //存储过程名称
                string strsql = "BusinessImprestApply_Search";
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
        ///BusinessImprestApply 查询,返回List
        ///</summary>
        ///<param name="boName">数据库连接配置key信息</param>
        ///<param name="selectCondition">查询条件</param>
        /// <returns>List<BusinessImprestApplyInfo></returns>
        public List<BusinessImprestApplyInfo> SelectAsList(string boName, string selectCondition)
        {
            DataTable table = new DataTable();
            List<BusinessImprestApplyInfo> list = new List<BusinessImprestApplyInfo>();
            BusinessImprestApplyInfo accountInfo = new BusinessImprestApplyInfo();

            try
            {
                table = Select(boName, selectCondition);

                // DataTable To ArrayList
                foreach (DataRow row in table.Rows)
                {
                    accountInfo = BusinessImprestApplyInfoRowToInfo(row);
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
        /// <param name="BusinessImprestApplyDataRow">BusinessImprestApplyDataRow</param>
        /// <returns>BusinessImprestApplyInfo</returns>
        internal BusinessImprestApplyInfo BusinessImprestApplyInfoRowToInfo(DataRow InfoDataRow)
        {
            BusinessImprestApplyInfo Info = new BusinessImprestApplyInfo();
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
            if (InfoDataRow["BusinessID"] != null)
            {
                Info.BusinessID = new Guid(DataUtil.GetStringValueOfRow(InfoDataRow, "BusinessID"));
            }
            if (InfoDataRow["BusinessType"] != null)
            {
                Info.BusinessType = short.Parse(DataUtil.GetStringValueOfRow(InfoDataRow, "BusinessType"));
            }
            if (InfoDataRow["BusinessName"] != null)
            {
                Info.BusinessName = DataUtil.GetStringValueOfRow(InfoDataRow, "BusinessName");
            }
            if (InfoDataRow["SumMoney"] != null)
            {
                Info.SumMoney = Convert.ToDecimal(DataUtil.GetStringValueOfRow(InfoDataRow, "SumMoney"));
            }
            if (InfoDataRow["ApplySument"] != null)
            {
                Info.ApplySument = DataUtil.GetStringValueOfRow(InfoDataRow, "ApplySument");
            }
            if (InfoDataRow["Sument"] != null)
            {
                Info.Sument = DataUtil.GetStringValueOfRow(InfoDataRow, "Sument");
            }
            if (InfoDataRow["ApplyTime"] != null)
            {
                Info.ApplyTime = DateTime.Parse(DataUtil.GetStringValueOfRow(InfoDataRow, "ApplyTime"));
            }
            if (InfoDataRow["ApproverID"] != null)
            {
                Info.ApproverID = new Guid(DataUtil.GetStringValueOfRow(InfoDataRow, "ApproverID"));
            }
            if (InfoDataRow["State"] != null)
            {
                Info.State = short.Parse(DataUtil.GetStringValueOfRow(InfoDataRow, "State"));
            }
            if (InfoDataRow["IsDelete"] != null)
            {
                Info.IsDelete = bool.Parse(DataUtil.GetStringValueOfRow(InfoDataRow, "IsDelete"));
            }
            if (InfoDataRow["SumMoneyFlag"] != null)
            {
                Info.SumMoneyFlag = DataUtil.GetStringValueOfRow(InfoDataRow, "SumMoneyFlag");
            }
            return Info;
        }
        #endregion
    }
}
