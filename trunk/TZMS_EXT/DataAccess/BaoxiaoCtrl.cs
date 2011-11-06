//----------------------------------------------------------------------------------------------------
//程序名:	Baoxiao 控制类
//功能:  	定义了与 dbo.Baoxiao 表 对应的数据访问控制类
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
    /// BaoxiaoCtrl
    /// programmer:shunlian
    /// </summary>
    public class BaoxiaoCtrl
    {
        #region 构造函数

        /// <summary>
        /// BaoxiaoCtrl默认构造函数
        /// </summary>
        public BaoxiaoCtrl()
        {
            //ToDo
        }

        #endregion

        #region 增、删、改、查

        /// <summary>
        /// 插入dbo.Baoxiao一条记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="BaoxiaoInfo">BaoxiaoInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int Insert(string boName, BaoxiaoInfo BaoxiaoInfo)
        {
            try
            {
                //存储过程名称
                string strsql = "Baoxiao_Add";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjectId",DbType.Guid),
				new SqlParameter("@UserId",DbType.Guid),
				new SqlParameter("@UserName",DbType.String),
				new SqlParameter("@UserJobNo",DbType.String),
				new SqlParameter("@UserAccountNo",DbType.String),
				new SqlParameter("@Dept",DbType.String),
				new SqlParameter("@Sument",DbType.String),
				new SqlParameter("@Money",DbType.Guid),
				new SqlParameter("@Other",DbType.String),
				new SqlParameter("@ApplyTime",DbType.DateTime),
				new SqlParameter("@State",DbType.Int16),
				new SqlParameter("@Isdelete",DbType.Boolean),
                new SqlParameter("@TellPhone",DbType.String),
                new SqlParameter("@CheckerId",DbType.Guid),
                new SqlParameter("@StartTime",DbType.DateTime),
                new SqlParameter("@EndTime",DbType.DateTime)
				};

                int i = 0;
                sqlparam[i++].Value = BaoxiaoInfo.ObjectId;
                sqlparam[i++].Value = BaoxiaoInfo.UserId;
                sqlparam[i++].Value = BaoxiaoInfo.UserName;
                sqlparam[i++].Value = BaoxiaoInfo.UserJobNo;
                sqlparam[i++].Value = BaoxiaoInfo.UserAccountNo;
                sqlparam[i++].Value = BaoxiaoInfo.Dept;
                sqlparam[i++].Value = BaoxiaoInfo.Sument;
                sqlparam[i++].Value = BaoxiaoInfo.Money;
                sqlparam[i++].Value = BaoxiaoInfo.Other;
                sqlparam[i++].Value = BaoxiaoInfo.ApplyTime;
                sqlparam[i++].Value = BaoxiaoInfo.State;
                sqlparam[i++].Value = BaoxiaoInfo.Isdelete;
                sqlparam[i++].Value = BaoxiaoInfo.TellPhone;
                sqlparam[i++].Value = BaoxiaoInfo.CheckerId;
                sqlparam[i++].Value = BaoxiaoInfo.StartTime;
                sqlparam[i++].Value = BaoxiaoInfo.EndTime;
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
        /// dbo.Baoxiao删除记录(通过记录ID ObjectID)
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="objectID">ObjectID(唯一ID)</param>
        public void Delete(string boName, string objectID)
        {
            try
            {
                string strsql = "Baoxiao_Delete";

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
        /// Baoxiao 更新记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="BaoxiaoInfo">BaoxiaoInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int UpDate(string boName, BaoxiaoInfo BaoxiaoInfo)
        {
            try
            {
                //存储过程名称
                string strsql = "Baoxiao_Update";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjectId",DbType.Guid),
				new SqlParameter("@UserId",DbType.Guid),
				new SqlParameter("@UserName",DbType.String),
				new SqlParameter("@UserJobNo",DbType.String),
				new SqlParameter("@UserAccountNo",DbType.String),
				new SqlParameter("@Dept",DbType.String),
				new SqlParameter("@Sument",DbType.String),
				new SqlParameter("@Money",DbType.Guid),
				new SqlParameter("@Other",DbType.String),
				new SqlParameter("@ApplyTime",DbType.DateTime),
				new SqlParameter("@State",DbType.Int16),
				new SqlParameter("@Isdelete",DbType.Boolean),
                new SqlParameter("@TellPhone",DbType.String),
                new SqlParameter("@CheckerId",DbType.Guid),
                new SqlParameter("@StartTime",DbType.DateTime),
                new SqlParameter("@EndTime",DbType.DateTime)

                };

                int i = 0;
                sqlparam[i++].Value = BaoxiaoInfo.ObjectId;
                sqlparam[i++].Value = BaoxiaoInfo.UserId;
                sqlparam[i++].Value = BaoxiaoInfo.UserName;
                sqlparam[i++].Value = BaoxiaoInfo.UserJobNo;
                sqlparam[i++].Value = BaoxiaoInfo.UserAccountNo;
                sqlparam[i++].Value = BaoxiaoInfo.Dept;
                sqlparam[i++].Value = BaoxiaoInfo.Sument;
                sqlparam[i++].Value = BaoxiaoInfo.Money;
                sqlparam[i++].Value = BaoxiaoInfo.Other;
                sqlparam[i++].Value = BaoxiaoInfo.ApplyTime;
                sqlparam[i++].Value = BaoxiaoInfo.State;
                sqlparam[i++].Value = BaoxiaoInfo.Isdelete;
                sqlparam[i++].Value = BaoxiaoInfo.TellPhone;
                sqlparam[i++].Value = BaoxiaoInfo.CheckerId;
                SqlDBAccess dbaccess = new SqlDBAccess();
                sqlparam[i++].Value = BaoxiaoInfo.StartTime;
                sqlparam[i++].Value = BaoxiaoInfo.EndTime;
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
        /// Baoxiao 查询,返回Datatable
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="selectCondition">查询条件</param>
        /// <returns>DataTable</returns>
        public DataTable Select(string boName, string condition)
        {
            try
            {
                //存储过程名称
                string strsql = "Baoxiao_Search";
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
        ///Baoxiao 查询,返回List
        ///</summary>
        ///<param name="boName">数据库连接配置key信息</param>
        ///<param name="selectCondition">查询条件</param>
        /// <returns>List<BaoxiaoInfo></returns>
        public List<BaoxiaoInfo> SelectAsList(string boName, string selectCondition)
        {
            DataTable table = new DataTable();
            List<BaoxiaoInfo> list = new List<BaoxiaoInfo>();
            BaoxiaoInfo accountInfo = new BaoxiaoInfo();

            try
            {
                table = Select(boName, selectCondition);

                // DataTable To ArrayList
                foreach (DataRow row in table.Rows)
                {
                    accountInfo = BaoxiaoInfoRowToInfo(row);
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
        /// <param name="BaoxiaoDataRow">BaoxiaoDataRow</param>
        /// <returns>BaoxiaoInfo</returns>
        internal BaoxiaoInfo BaoxiaoInfoRowToInfo(DataRow BaoxiaoInfoInfoDataRow)
        {
            BaoxiaoInfo BaoxiaoInfoInfo = new BaoxiaoInfo();
            if (BaoxiaoInfoInfoDataRow["ObjectId"] != null)
            {
                BaoxiaoInfoInfo.ObjectId = new Guid(DataUtil.GetStringValueOfRow(BaoxiaoInfoInfoDataRow, "ObjectId"));
            }
            if (BaoxiaoInfoInfoDataRow["UserId"] != null)
            {
                BaoxiaoInfoInfo.UserId = new Guid(DataUtil.GetStringValueOfRow(BaoxiaoInfoInfoDataRow, "UserId"));
            }
            if (BaoxiaoInfoInfoDataRow["UserName"] != null)
            {
                BaoxiaoInfoInfo.UserName = DataUtil.GetStringValueOfRow(BaoxiaoInfoInfoDataRow, "UserName");
            }
            if (BaoxiaoInfoInfoDataRow["UserJobNo"] != null)
            {
                BaoxiaoInfoInfo.UserJobNo = DataUtil.GetStringValueOfRow(BaoxiaoInfoInfoDataRow, "UserJobNo");
            }
            if (BaoxiaoInfoInfoDataRow["UserAccountNo"] != null)
            {
                BaoxiaoInfoInfo.UserAccountNo = DataUtil.GetStringValueOfRow(BaoxiaoInfoInfoDataRow, "UserAccountNo");
            }
            if (BaoxiaoInfoInfoDataRow["Dept"] != null)
            {
                BaoxiaoInfoInfo.Dept = DataUtil.GetStringValueOfRow(BaoxiaoInfoInfoDataRow, "Dept");
            }
            if (BaoxiaoInfoInfoDataRow["Sument"] != null)
            {
                BaoxiaoInfoInfo.Sument = DataUtil.GetStringValueOfRow(BaoxiaoInfoInfoDataRow, "Sument");
            }
            if (BaoxiaoInfoInfoDataRow["Money"] != null)
            {
                BaoxiaoInfoInfo.Money = Decimal.Parse(DataUtil.GetStringValueOfRow(BaoxiaoInfoInfoDataRow, "Money"));
            }
            if (BaoxiaoInfoInfoDataRow["Other"] != null)
            {
                BaoxiaoInfoInfo.Other = DataUtil.GetStringValueOfRow(BaoxiaoInfoInfoDataRow, "Other");
            }
            if (BaoxiaoInfoInfoDataRow["ApplyTime"] != null)
            {
                BaoxiaoInfoInfo.ApplyTime = DateTime.Parse(DataUtil.GetStringValueOfRow(BaoxiaoInfoInfoDataRow, "ApplyTime"));
            }
            if (BaoxiaoInfoInfoDataRow["State"] != null)
            {
                BaoxiaoInfoInfo.State = short.Parse(DataUtil.GetStringValueOfRow(BaoxiaoInfoInfoDataRow, "State"));
            }
            if (BaoxiaoInfoInfoDataRow["Isdelete"] != null)
            {
                BaoxiaoInfoInfo.Isdelete = bool.Parse(DataUtil.GetStringValueOfRow(BaoxiaoInfoInfoDataRow, "Isdelete"));
            }
            if (BaoxiaoInfoInfoDataRow["TellPhone"] != null)
            {
                BaoxiaoInfoInfo.TellPhone = DataUtil.GetStringValueOfRow(BaoxiaoInfoInfoDataRow, "TellPhone");
            }
            if (BaoxiaoInfoInfoDataRow["CheckerId"] != null)
            {
                BaoxiaoInfoInfo.CheckerId = new Guid(DataUtil.GetStringValueOfRow(BaoxiaoInfoInfoDataRow, "CheckerId"));
            }
            if (BaoxiaoInfoInfoDataRow["StartTime"] != null)
            {
                BaoxiaoInfoInfo.StartTime = DateTime.Parse(DataUtil.GetStringValueOfRow(BaoxiaoInfoInfoDataRow, "StartTime"));
            }
            if (BaoxiaoInfoInfoDataRow["EndTime"] != null)
            {
                BaoxiaoInfoInfo.EndTime = DateTime.Parse(DataUtil.GetStringValueOfRow(BaoxiaoInfoInfoDataRow, "EndTime"));
            }

            return BaoxiaoInfoInfo;
        }
        #endregion
    }
}
