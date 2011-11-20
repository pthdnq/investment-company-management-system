//----------------------------------------------------------------------------------------------------
//程序名:	ProxyAccountingUnit 控制类
//功能:  	定义了与 dbo.ProxyAccountingUnit 表 对应的数据访问控制类
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
    /// ProxyAccountingUnitCtrl
    /// programmer:xiguazerg
    /// </summary>
    public class ProxyAccountingUnitCtrl
    {
        #region 构造函数

        /// <summary>
        /// ProxyAccountingUnitCtrl默认构造函数
        /// </summary>
        public ProxyAccountingUnitCtrl()
        {
            //ToDo
        }

        #endregion

        #region 增、删、改、查

        /// <summary>
        /// 插入dbo.ProxyAccountingUnit一条记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="ProxyAccountingUnitInfo">ProxyAccountingUnitInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int Insert(string boName, ProxyAccountingUnitInfo ProxyAccountingUnitInfo)
        {
            try
            {
				//存储过程名称
                string strsql = "ProxyAccountingUnit_Add"; 
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjectID", DbType.Guid),
				new SqlParameter("@UnitName",DbType.String),
				new SqlParameter("@UnitAddress",DbType.String),
				new SqlParameter("@AccountancyID", DbType.Guid),
				new SqlParameter("@AccountancyName",DbType.String),
				new SqlParameter("@Other",DbType.String),
				new SqlParameter("@IsDelete",DbType.Boolean),
				};
				
				int i=0;
				sqlparam[i++].Value = ProxyAccountingUnitInfo.ObjectID; 
				sqlparam[i++].Value = ProxyAccountingUnitInfo.UnitName; 
				sqlparam[i++].Value = ProxyAccountingUnitInfo.UnitAddress; 
				sqlparam[i++].Value = ProxyAccountingUnitInfo.AccountancyID; 
				sqlparam[i++].Value = ProxyAccountingUnitInfo.AccountancyName; 
				sqlparam[i++].Value = ProxyAccountingUnitInfo.Other; 
				sqlparam[i++].Value = ProxyAccountingUnitInfo.IsDelete; 
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
        /// dbo.ProxyAccountingUnit删除记录(通过记录ID ObjectID)
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="objectID">ObjectID(唯一ID)</param>
        public void Delete(string boName, string objectID)
        {
            try
            {
                string strsql = "ProxyAccountingUnit_Delete";

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
        /// ProxyAccountingUnit 更新记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="ProxyAccountingUnitInfo">ProxyAccountingUnitInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int UpDate(string boName, ProxyAccountingUnitInfo ProxyAccountingUnitInfo)
        {
            try
            {
                //存储过程名称
                string strsql = "ProxyAccountingUnit_Update";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjectID",DbType.Guid),
				new SqlParameter("@UnitName",DbType.String),
				new SqlParameter("@UnitAddress",DbType.String),
				new SqlParameter("@AccountancyID",DbType.Guid),
				new SqlParameter("@AccountancyName",DbType.String),
				new SqlParameter("@Other",DbType.String),
				new SqlParameter("@IsDelete",DbType.Boolean),
                };

                int i = 0;
				sqlparam[i++].Value = ProxyAccountingUnitInfo.ObjectID; 
				sqlparam[i++].Value = ProxyAccountingUnitInfo.UnitName; 
				sqlparam[i++].Value = ProxyAccountingUnitInfo.UnitAddress; 
				sqlparam[i++].Value = ProxyAccountingUnitInfo.AccountancyID; 
				sqlparam[i++].Value = ProxyAccountingUnitInfo.AccountancyName; 
				sqlparam[i++].Value = ProxyAccountingUnitInfo.Other; 
				sqlparam[i++].Value = ProxyAccountingUnitInfo.IsDelete; 
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
        /// ProxyAccountingUnit 查询,返回Datatable
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="selectCondition">查询条件</param>
        /// <returns>DataTable</returns>
        public DataTable Select(string boName, string condition)
        {
            try
            {
                //存储过程名称
                string strsql = "ProxyAccountingUnit_Search";
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
        ///ProxyAccountingUnit 查询,返回List
        ///</summary>
        ///<param name="boName">数据库连接配置key信息</param>
        ///<param name="selectCondition">查询条件</param>
        /// <returns>List<ProxyAccountingUnitInfo></returns>
        public List<ProxyAccountingUnitInfo> SelectAsList(string boName, string selectCondition)
        {
            DataTable table = new DataTable();
            List<ProxyAccountingUnitInfo> list = new List<ProxyAccountingUnitInfo>();
            ProxyAccountingUnitInfo accountInfo = new ProxyAccountingUnitInfo();

            try
            {
                table = Select(boName, selectCondition);

                // DataTable To ArrayList
                foreach (DataRow row in table.Rows)
                {
                    accountInfo = ProxyAccountingUnitInfoRowToInfo(row);
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
        /// <param name="ProxyAccountingUnitDataRow">ProxyAccountingUnitDataRow</param>
        /// <returns>ProxyAccountingUnitInfo</returns>
        internal ProxyAccountingUnitInfo ProxyAccountingUnitInfoRowToInfo(DataRow InfoDataRow)
        {
            ProxyAccountingUnitInfo Info = new ProxyAccountingUnitInfo();
            if (InfoDataRow["ObjectID"] != null)
            {
                Info.ObjectID = new Guid(DataUtil.GetStringValueOfRow(InfoDataRow, "ObjectID"));
            }
            if (InfoDataRow["UnitName"] != null)
            {
                Info.UnitName = DataUtil.GetStringValueOfRow(InfoDataRow, "UnitName");
            }
            if (InfoDataRow["UnitAddress"] != null)
            {
                Info.UnitAddress = DataUtil.GetStringValueOfRow(InfoDataRow, "UnitAddress");
            }
            if (InfoDataRow["AccountancyID"] != null)
            {
                Info.AccountancyID = new Guid(DataUtil.GetStringValueOfRow(InfoDataRow, "AccountancyID"));
            }
            if (InfoDataRow["AccountancyName"] != null)
            {
                Info.AccountancyName = DataUtil.GetStringValueOfRow(InfoDataRow, "AccountancyName");
            }
            if (InfoDataRow["Other"] != null)
            {
                Info.Other = DataUtil.GetStringValueOfRow(InfoDataRow, "Other");
            }
            if (InfoDataRow["IsDelete"] != null)
            {
                Info.IsDelete = Convert.ToBoolean(DataUtil.GetStringValueOfRow(InfoDataRow, "IsDelete"));
            }

            return Info;
        }
        #endregion
    }
}
