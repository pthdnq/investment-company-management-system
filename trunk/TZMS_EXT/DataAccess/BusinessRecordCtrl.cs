//----------------------------------------------------------------------------------------------------
//程序名:	BusinessRecord 控制类
//功能:  	定义了与 dbo.BusinessRecord 表 对应的数据访问控制类
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
    /// BusinessRecordCtrl
    /// programmer:xiguazerg
    /// </summary>
    public class BusinessRecordCtrl
    {
        #region 构造函数

        /// <summary>
        /// BusinessRecordCtrl默认构造函数
        /// </summary>
        public BusinessRecordCtrl()
        {
            //ToDo
        }

        #endregion

        #region 增、删、改、查

        /// <summary>
        /// 插入dbo.BusinessRecord一条记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="BusinessRecordInfo">BusinessRecordInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int Insert(string boName, BusinessRecordInfo BusinessRecordInfo)
        {
            try
            {
                //存储过程名称
                string strsql = "BusinessRecord_Add";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjectID",DbType.Guid),
				new SqlParameter("@CheckerID",DbType.Guid),
				new SqlParameter("@CheckerName",DbType.String),
				new SqlParameter("@CheckrDept",DbType.String),
				new SqlParameter("@CheckDateTime",DbType.DateTime),
				new SqlParameter("@State",DbType.Int16),
				new SqlParameter("@CurrentBusiness",DbType.Int32),
				new SqlParameter("@CostMoney",DbType.Guid),
				new SqlParameter("@OtherMoney",DbType.Guid),
				new SqlParameter("@Explain",DbType.String),
				new SqlParameter("@BusinessID",DbType.Guid),

                new SqlParameter("@CostMoneyFlag",DbType.String),
                new SqlParameter("@OtherMoneyFlag",DbType.String),
				};

                int i = 0;
                sqlparam[i++].Value = BusinessRecordInfo.ObjectID;
                sqlparam[i++].Value = BusinessRecordInfo.CheckerID;
                sqlparam[i++].Value = BusinessRecordInfo.CheckerName;
                sqlparam[i++].Value = BusinessRecordInfo.CheckrDept;
                sqlparam[i++].Value = BusinessRecordInfo.CheckDateTime;
                sqlparam[i++].Value = BusinessRecordInfo.State;
                sqlparam[i++].Value = BusinessRecordInfo.CurrentBusiness;
                sqlparam[i++].Value = BusinessRecordInfo.CostMoney;
                sqlparam[i++].Value = BusinessRecordInfo.OtherMoney;
                sqlparam[i++].Value = BusinessRecordInfo.Explain;
                sqlparam[i++].Value = BusinessRecordInfo.BusinessID;

                sqlparam[i++].Value = BusinessRecordInfo.CostMoneyFlag;
                sqlparam[i++].Value = BusinessRecordInfo.OtherMoneyFlag;
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
        /// dbo.BusinessRecord删除记录(通过记录ID ObjectID)
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="objectID">ObjectID(唯一ID)</param>
        public void Delete(string boName, string objectID)
        {
            try
            {
                string strsql = "BusinessRecord_Delete";

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
        /// BusinessRecord 更新记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="BusinessRecordInfo">BusinessRecordInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int UpDate(string boName, BusinessRecordInfo BusinessRecordInfo)
        {
            try
            {
                //存储过程名称
                string strsql = "BusinessRecord_Update";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjectID",DbType.Guid),
				new SqlParameter("@CheckerID",DbType.Guid),
				new SqlParameter("@CheckerName",DbType.String),
				new SqlParameter("@CheckrDept",DbType.String),
				new SqlParameter("@CheckDateTime",DbType.DateTime),
				new SqlParameter("@State",DbType.Int16),
				new SqlParameter("@CurrentBusiness",DbType.Int32),
				new SqlParameter("@CostMoney",DbType.Guid),
				new SqlParameter("@OtherMoney",DbType.Guid),
				new SqlParameter("@Explain",DbType.String),
				new SqlParameter("@BusinessID",DbType.Guid),
                new SqlParameter("@CostMoneyFlag",DbType.String),
                new SqlParameter("@OtherMoneyFlag",DbType.String),
                };

                int i = 0;
                sqlparam[i++].Value = BusinessRecordInfo.ObjectID;
                sqlparam[i++].Value = BusinessRecordInfo.CheckerID;
                sqlparam[i++].Value = BusinessRecordInfo.CheckerName;
                sqlparam[i++].Value = BusinessRecordInfo.CheckrDept;
                sqlparam[i++].Value = BusinessRecordInfo.CheckDateTime;
                sqlparam[i++].Value = BusinessRecordInfo.State;
                sqlparam[i++].Value = BusinessRecordInfo.CurrentBusiness;
                sqlparam[i++].Value = BusinessRecordInfo.CostMoney;
                sqlparam[i++].Value = BusinessRecordInfo.OtherMoney;
                sqlparam[i++].Value = BusinessRecordInfo.Explain;
                sqlparam[i++].Value = BusinessRecordInfo.BusinessID;
                sqlparam[i++].Value = BusinessRecordInfo.CostMoneyFlag;
                sqlparam[i++].Value = BusinessRecordInfo.OtherMoneyFlag;
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
        /// BusinessRecord 查询,返回Datatable
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="selectCondition">查询条件</param>
        /// <returns>DataTable</returns>
        public DataTable Select(string boName, string condition)
        {
            try
            {
                //存储过程名称
                string strsql = "BusinessRecord_Search";
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
        ///BusinessRecord 查询,返回List
        ///</summary>
        ///<param name="boName">数据库连接配置key信息</param>
        ///<param name="selectCondition">查询条件</param>
        /// <returns>List<BusinessRecordInfo></returns>
        public List<BusinessRecordInfo> SelectAsList(string boName, string selectCondition)
        {
            DataTable table = new DataTable();
            List<BusinessRecordInfo> list = new List<BusinessRecordInfo>();
            BusinessRecordInfo accountInfo = new BusinessRecordInfo();

            try
            {
                table = Select(boName, selectCondition);

                // DataTable To ArrayList
                foreach (DataRow row in table.Rows)
                {
                    accountInfo = BusinessRecordInfoRowToInfo(row);
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
        /// <param name="BusinessRecordDataRow">BusinessRecordDataRow</param>
        /// <returns>BusinessRecordInfo</returns>
        internal BusinessRecordInfo BusinessRecordInfoRowToInfo(DataRow InfoDataRow)
        {
            BusinessRecordInfo Info = new BusinessRecordInfo();
            if (InfoDataRow["ObjectID"] != null)
            {
                Info.ObjectID = new Guid(DataUtil.GetStringValueOfRow(InfoDataRow, "ObjectID"));
            }
            if (InfoDataRow["CheckerID"] != null)
            {
                Info.CheckerID = new Guid(DataUtil.GetStringValueOfRow(InfoDataRow, "CheckerID"));
            }
            if (InfoDataRow["CheckerName"] != null)
            {
                Info.CheckerName = DataUtil.GetStringValueOfRow(InfoDataRow, "CheckerName");
            }
            if (InfoDataRow["CheckrDept"] != null)
            {
                Info.CheckrDept = DataUtil.GetStringValueOfRow(InfoDataRow, "CheckrDept");
            }
            if (InfoDataRow["CheckDateTime"] != null)
            {
                Info.CheckDateTime = DateTime.Parse(DataUtil.GetStringValueOfRow(InfoDataRow, "CheckDateTime"));
            }
            if (InfoDataRow["State"] != null)
            {
                Info.State = short.Parse(DataUtil.GetStringValueOfRow(InfoDataRow, "State"));
            }
            if (InfoDataRow["CurrentBusiness"] != null)
            {
                Info.CurrentBusiness = Convert.ToInt32(DataUtil.GetStringValueOfRow(InfoDataRow, "CurrentBusiness"));
            }
            if (InfoDataRow["CostMoney"] != null)
            {
                Info.CostMoney = Convert.ToDecimal(DataUtil.GetStringValueOfRow(InfoDataRow, "CostMoney"));
            }
            if (InfoDataRow["OtherMoney"] != null)
            {
                Info.OtherMoney = Convert.ToDecimal(DataUtil.GetStringValueOfRow(InfoDataRow, "OtherMoney"));
            }
            if (InfoDataRow["Explain"] != null)
            {
                Info.Explain = DataUtil.GetStringValueOfRow(InfoDataRow, "Explain");
            }
            if (InfoDataRow["BusinessID"] != null)
            {
                Info.BusinessID = new Guid(DataUtil.GetStringValueOfRow(InfoDataRow, "BusinessID"));
            }

            return Info;
        }
        #endregion
    }
}
