//----------------------------------------------------------------------------------------------------
//程序名:	ProxyAccountingApply 控制类
//功能:  	定义了与 dbo.ProxyAccountingApply 表 对应的数据访问控制类
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
    /// ProxyAccountingApplyCtrl
    /// programmer:xiguazerg
    /// </summary>
    public class ProxyAccountingApplyCtrl
    {
        #region 构造函数

        /// <summary>
        /// ProxyAccountingApplyCtrl默认构造函数
        /// </summary>
        public ProxyAccountingApplyCtrl()
        {
            //ToDo
        }

        #endregion

        #region 增、删、改、查

        /// <summary>
        /// 插入dbo.ProxyAccountingApply一条记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="ProxyAccountingApplyInfo">ProxyAccountingApplyInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int Insert(string boName, ProxyAccountingApplyInfo ProxyAccountingApplyInfo)
        {
            try
            {
                //存储过程名称
                string strsql = "ProxyAccountingApply_Add";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjectID",DbType.Guid),
				new SqlParameter("@PayUnitID",DbType.Guid),
				new SqlParameter("@CNMoney",DbType.String),
				new SqlParameter("@ENMoney",DbType.Decimal),
				new SqlParameter("@Sument",DbType.String),
				new SqlParameter("@OpeningDate",DbType.DateTime),
				new SqlParameter("@CollectMethod",DbType.String),
				new SqlParameter("@CollectUnitID",DbType.Guid),
				new SqlParameter("@ProxyAccountingID",DbType.Guid),
				new SqlParameter("@ProxyAccountingName",DbType.String),
				new SqlParameter("@CollecterID",DbType.Guid),
				new SqlParameter("@CollecterName",DbType.String),
				new SqlParameter("@State",DbType.Int16),
				new SqlParameter("@ApproverID",DbType.Guid),
				new SqlParameter("@IsDelete",DbType.Boolean),
                new SqlParameter("@PayUnitName",DbType.String),
                new SqlParameter("@ENMoneyFlag",DbType.String)
				};

                int i = 0;
                sqlparam[i++].Value = ProxyAccountingApplyInfo.ObjectID;
                sqlparam[i++].Value = ProxyAccountingApplyInfo.PayUnitID;
                sqlparam[i++].Value = ProxyAccountingApplyInfo.CNMoney;
                sqlparam[i++].Value = ProxyAccountingApplyInfo.ENMoney;
                sqlparam[i++].Value = ProxyAccountingApplyInfo.Sument;
                sqlparam[i++].Value = ProxyAccountingApplyInfo.OpeningDate;
                sqlparam[i++].Value = ProxyAccountingApplyInfo.CollectMethod;
                sqlparam[i++].Value = ProxyAccountingApplyInfo.CollectUnitID;
                sqlparam[i++].Value = ProxyAccountingApplyInfo.ProxyAccountingID;
                sqlparam[i++].Value = ProxyAccountingApplyInfo.ProxyAccountingName;
                sqlparam[i++].Value = ProxyAccountingApplyInfo.CollecterID;
                sqlparam[i++].Value = ProxyAccountingApplyInfo.CollecterName;
                sqlparam[i++].Value = ProxyAccountingApplyInfo.State;
                sqlparam[i++].Value = ProxyAccountingApplyInfo.ApproverID;
                sqlparam[i++].Value = ProxyAccountingApplyInfo.IsDelete;
                sqlparam[i++].Value = ProxyAccountingApplyInfo.PayUnitName;
                sqlparam[i++].Value = ProxyAccountingApplyInfo.ENMoneyFlag;
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
        /// dbo.ProxyAccountingApply删除记录(通过记录ID ObjectID)
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="objectID">ObjectID(唯一ID)</param>
        public void Delete(string boName, string objectID)
        {
            try
            {
                string strsql = "ProxyAccountingApply_Delete";

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
        /// ProxyAccountingApply 更新记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="ProxyAccountingApplyInfo">ProxyAccountingApplyInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int UpDate(string boName, ProxyAccountingApplyInfo ProxyAccountingApplyInfo)
        {
            try
            {
                //存储过程名称
                string strsql = "ProxyAccountingApply_Update";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjectID",DbType.Guid),
				new SqlParameter("@PayUnitID",DbType.Guid),
				new SqlParameter("@CNMoney",DbType.String),
				new SqlParameter("@ENMoney",DbType.Decimal),
				new SqlParameter("@Sument",DbType.String),
				new SqlParameter("@OpeningDate",DbType.DateTime),
				new SqlParameter("@CollectMethod",DbType.String),
				new SqlParameter("@CollectUnitID",DbType.Guid),
				new SqlParameter("@ProxyAccountingID",DbType.Guid),
				new SqlParameter("@ProxyAccountingName",DbType.String),
				new SqlParameter("@CollecterID",DbType.Guid),
				new SqlParameter("@CollecterName",DbType.String),
				new SqlParameter("@State",DbType.Int16),
				new SqlParameter("@ApproverID",DbType.Guid),
				new SqlParameter("@IsDelete",DbType.Boolean),
                new SqlParameter("@PayUnitName",DbType.String),
                  new SqlParameter("@ENMoneyFlag",DbType.String),
                };

                int i = 0;
                sqlparam[i++].Value = ProxyAccountingApplyInfo.ObjectID;
                sqlparam[i++].Value = ProxyAccountingApplyInfo.PayUnitID;
                sqlparam[i++].Value = ProxyAccountingApplyInfo.CNMoney;
                sqlparam[i++].Value = ProxyAccountingApplyInfo.ENMoney;
                sqlparam[i++].Value = ProxyAccountingApplyInfo.Sument;
                sqlparam[i++].Value = ProxyAccountingApplyInfo.OpeningDate;
                sqlparam[i++].Value = ProxyAccountingApplyInfo.CollectMethod;
                sqlparam[i++].Value = ProxyAccountingApplyInfo.CollectUnitID;
                sqlparam[i++].Value = ProxyAccountingApplyInfo.ProxyAccountingID;
                sqlparam[i++].Value = ProxyAccountingApplyInfo.ProxyAccountingName;
                sqlparam[i++].Value = ProxyAccountingApplyInfo.CollecterID;
                sqlparam[i++].Value = ProxyAccountingApplyInfo.CollecterName;
                sqlparam[i++].Value = ProxyAccountingApplyInfo.State;
                sqlparam[i++].Value = ProxyAccountingApplyInfo.ApproverID;
                sqlparam[i++].Value = ProxyAccountingApplyInfo.IsDelete;
                sqlparam[i++].Value = ProxyAccountingApplyInfo.PayUnitName;
                sqlparam[i++].Value = ProxyAccountingApplyInfo.ENMoneyFlag;
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
        /// ProxyAccountingApply 查询,返回Datatable
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="selectCondition">查询条件</param>
        /// <returns>DataTable</returns>
        public DataTable Select(string boName, string condition)
        {
            try
            {
                //存储过程名称
                string strsql = "ProxyAccountingApply_Search";
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
        ///ProxyAccountingApply 查询,返回List
        ///</summary>
        ///<param name="boName">数据库连接配置key信息</param>
        ///<param name="selectCondition">查询条件</param>
        /// <returns>List<ProxyAccountingApplyInfo></returns>
        public List<ProxyAccountingApplyInfo> SelectAsList(string boName, string selectCondition)
        {
            DataTable table = new DataTable();
            List<ProxyAccountingApplyInfo> list = new List<ProxyAccountingApplyInfo>();
            ProxyAccountingApplyInfo accountInfo = new ProxyAccountingApplyInfo();

            try
            {
                table = Select(boName, selectCondition);

                // DataTable To ArrayList
                foreach (DataRow row in table.Rows)
                {
                    accountInfo = ProxyAccountingApplyInfoRowToInfo(row);
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
        /// <param name="ProxyAccountingApplyDataRow">ProxyAccountingApplyDataRow</param>
        /// <returns>ProxyAccountingApplyInfo</returns>
        internal ProxyAccountingApplyInfo ProxyAccountingApplyInfoRowToInfo(DataRow InfoDataRow)
        {
            ProxyAccountingApplyInfo Info = new ProxyAccountingApplyInfo();
            if (InfoDataRow["ObjectID"] != null)
            {
                Info.ObjectID = new Guid(DataUtil.GetStringValueOfRow(InfoDataRow, "ObjectID"));
            }
            if (InfoDataRow["PayUnitID"] != null)
            {
                Info.PayUnitID = new Guid(DataUtil.GetStringValueOfRow(InfoDataRow, "PayUnitID"));
            }
            if (InfoDataRow["CNMoney"] != null)
            {
                Info.CNMoney = DataUtil.GetStringValueOfRow(InfoDataRow, "CNMoney");
            }
            if (InfoDataRow["ENMoney"] != null)
            {
                Info.ENMoney = Decimal.Parse(DataUtil.GetStringValueOfRow(InfoDataRow, "ENMoney"));
            }
            if (InfoDataRow["Sument"] != null)
            {
                Info.Sument = DataUtil.GetStringValueOfRow(InfoDataRow, "Sument");
            }
            if (InfoDataRow["OpeningDate"] != null)
            {
                Info.OpeningDate = DateTime.Parse(DataUtil.GetStringValueOfRow(InfoDataRow, "OpeningDate"));
            }
            if (InfoDataRow["CollectMethod"] != null)
            {
                Info.CollectMethod = DataUtil.GetStringValueOfRow(InfoDataRow, "CollectMethod");
            }
            if (InfoDataRow["CollectUnitID"] != null)
            {
                Info.CollectUnitID = new Guid(DataUtil.GetStringValueOfRow(InfoDataRow, "CollectUnitID"));
            }
            if (InfoDataRow["ProxyAccountingID"] != null)
            {
                Info.ProxyAccountingID = new Guid(DataUtil.GetStringValueOfRow(InfoDataRow, "ProxyAccountingID"));
            }
            if (InfoDataRow["ProxyAccountingName"] != null)
            {
                Info.ProxyAccountingName = DataUtil.GetStringValueOfRow(InfoDataRow, "ProxyAccountingName");
            }
            if (InfoDataRow["CollecterID"] != null)
            {
                Info.CollecterID = new Guid(DataUtil.GetStringValueOfRow(InfoDataRow, "CollecterID"));
            }
            if (InfoDataRow["CollecterName"] != null)
            {
                Info.CollecterName = DataUtil.GetStringValueOfRow(InfoDataRow, "CollecterName");
            }
            if (InfoDataRow["State"] != null)
            {
                Info.State = short.Parse(DataUtil.GetStringValueOfRow(InfoDataRow, "State"));
            }
            if (InfoDataRow["ApproverID"] != null)
            {
                Info.ApproverID = new Guid(DataUtil.GetStringValueOfRow(InfoDataRow, "ApproverID"));
            }
            if (InfoDataRow["IsDelete"] != null)
            {
                Info.IsDelete = bool.Parse(DataUtil.GetStringValueOfRow(InfoDataRow, "IsDelete"));
            }
            if (InfoDataRow["PayUnitName"] != null)
            {
                Info.PayUnitName = DataUtil.GetStringValueOfRow(InfoDataRow, "PayUnitName");
            }
            if (InfoDataRow["ENMoneyFlag"] != null)
            {
                Info.ENMoneyFlag = DataUtil.GetStringValueOfRow(InfoDataRow, "ENMoneyFlag");
            }
            return Info;
        }
        #endregion
    }
}
