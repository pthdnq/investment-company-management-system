//----------------------------------------------------------------------------------------------------
//程序名:	BaoxiaoCheck 控制类
//功能:  	定义了与 dbo.BaoxiaoCheck 表 对应的数据访问控制类
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
    /// BaoxiaoCheckCtrl
    /// programmer:shunlian
    /// </summary>
    public class BaoxiaoCheckCtrl
    {
        #region 构造函数

        /// <summary>
        /// BaoxiaoCheckCtrl默认构造函数
        /// </summary>
        public BaoxiaoCheckCtrl()
        {
            //ToDo
        }

        #endregion

        #region 增、删、改、查

        /// <summary>
        /// 插入dbo.BaoxiaoCheck一条记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="BaoxiaoCheckInfo">BaoxiaoCheckInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int Insert(string boName, BaoxiaoCheckInfo BaoxiaoCheckInfo)
        {
            try
            {
                //存储过程名称
                string strsql = "BaoxiaoCheck_Add";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjectId",DbType.Guid),
				new SqlParameter("@CheckerId",DbType.Guid),
				new SqlParameter("@CheckerName",DbType.String),
				new SqlParameter("@CheckrDept",DbType.String),
				new SqlParameter("@CheckDateTime",DbType.DateTime),
				new SqlParameter("@Checkstate",DbType.Int16),
				new SqlParameter("@Result",DbType.String),
				new SqlParameter("@CheckSugest",DbType.String),
				new SqlParameter("@CheckOp",DbType.String),
                new SqlParameter("@applyID",DbType.Guid)
				};

                int i = 0;
                sqlparam[i++].Value = BaoxiaoCheckInfo.ObjectId;
                sqlparam[i++].Value = BaoxiaoCheckInfo.CheckerId;
                sqlparam[i++].Value = BaoxiaoCheckInfo.CheckerName;
                sqlparam[i++].Value = BaoxiaoCheckInfo.CheckrDept;
                sqlparam[i++].Value = BaoxiaoCheckInfo.CheckDateTime;
                sqlparam[i++].Value = BaoxiaoCheckInfo.Checkstate;
                sqlparam[i++].Value = BaoxiaoCheckInfo.Result;
                sqlparam[i++].Value = BaoxiaoCheckInfo.CheckSugest;
                sqlparam[i++].Value = BaoxiaoCheckInfo.CheckOp;
                sqlparam[i++].Value = BaoxiaoCheckInfo.ApplytId;
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
        /// dbo.BaoxiaoCheck删除记录(通过记录ID ObjectID)
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="objectID">ObjectID(唯一ID)</param>
        public void Delete(string boName, string objectID)
        {
            try
            {
                string strsql = "BaoxiaoCheck_Delete";

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
        /// BaoxiaoCheck 更新记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="BaoxiaoCheckInfo">BaoxiaoCheckInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int UpDate(string boName, BaoxiaoCheckInfo BaoxiaoCheckInfo)
        {
            try
            {
                //存储过程名称
                string strsql = "BaoxiaoCheck_Update";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjectId",DbType.Guid),
				new SqlParameter("@CheckerId",DbType.Guid),
				new SqlParameter("@CheckerName",DbType.String),
				new SqlParameter("@CheckrDept",DbType.String),
				new SqlParameter("@CheckDateTime",DbType.DateTime),
				new SqlParameter("@Checkstate",DbType.Int16),
				new SqlParameter("@Result",DbType.String),
				new SqlParameter("@CheckSugest",DbType.String),
				new SqlParameter("@CheckOp",DbType.String),
                new SqlParameter("@applyID",DbType.Guid)
                };

                int i = 0;
                sqlparam[i++].Value = BaoxiaoCheckInfo.ObjectId;
                sqlparam[i++].Value = BaoxiaoCheckInfo.CheckerId;
                sqlparam[i++].Value = BaoxiaoCheckInfo.CheckerName;
                sqlparam[i++].Value = BaoxiaoCheckInfo.CheckrDept;
                sqlparam[i++].Value = BaoxiaoCheckInfo.CheckDateTime;
                sqlparam[i++].Value = BaoxiaoCheckInfo.Checkstate;
                sqlparam[i++].Value = BaoxiaoCheckInfo.Result;
                sqlparam[i++].Value = BaoxiaoCheckInfo.CheckSugest;
                sqlparam[i++].Value = BaoxiaoCheckInfo.CheckOp;
                sqlparam[i++].Value = BaoxiaoCheckInfo.ApplytId;
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
        /// BaoxiaoCheck 查询,返回Datatable
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="selectCondition">查询条件</param>
        /// <returns>DataTable</returns>
        public DataTable Select(string boName, string condition)
        {
            try
            {
                //存储过程名称
                string strsql = "BaoxiaoCheck_Search";
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
        ///BaoxiaoCheck 查询,返回List
        ///</summary>
        ///<param name="boName">数据库连接配置key信息</param>
        ///<param name="selectCondition">查询条件</param>
        /// <returns>List<BaoxiaoCheckInfo></returns>
        public List<BaoxiaoCheckInfo> SelectAsList(string boName, string selectCondition)
        {
            DataTable table = new DataTable();
            List<BaoxiaoCheckInfo> list = new List<BaoxiaoCheckInfo>();
            BaoxiaoCheckInfo accountInfo = new BaoxiaoCheckInfo();

            try
            {
                table = Select(boName, selectCondition);

                // DataTable To ArrayList
                foreach (DataRow row in table.Rows)
                {
                    accountInfo = BaoxiaoCheckInfoRowToInfo(row);
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
        /// <param name="BaoxiaoCheckDataRow">BaoxiaoCheckDataRow</param>
        /// <returns>BaoxiaoCheckInfo</returns>
        internal BaoxiaoCheckInfo BaoxiaoCheckInfoRowToInfo(DataRow BaoxiaoCheckInfoInfoDataRow)
        {
            BaoxiaoCheckInfo BaoxiaoCheckInfoInfo = new BaoxiaoCheckInfo();
            if (BaoxiaoCheckInfoInfoDataRow["ObjectId"] != null)
            {
                BaoxiaoCheckInfoInfo.ObjectId = new Guid(DataUtil.GetStringValueOfRow(BaoxiaoCheckInfoInfoDataRow, "ObjectId"));
            }
            if (BaoxiaoCheckInfoInfoDataRow["CheckerId"] != null)
            {
                BaoxiaoCheckInfoInfo.CheckerId = new Guid(DataUtil.GetStringValueOfRow(BaoxiaoCheckInfoInfoDataRow, "CheckerId"));
            }
            if (BaoxiaoCheckInfoInfoDataRow["CheckerName"] != null)
            {
                BaoxiaoCheckInfoInfo.CheckerName = DataUtil.GetStringValueOfRow(BaoxiaoCheckInfoInfoDataRow, "CheckerName");
            }
            if (BaoxiaoCheckInfoInfoDataRow["CheckrDept"] != null)
            {
                BaoxiaoCheckInfoInfo.CheckrDept = DataUtil.GetStringValueOfRow(BaoxiaoCheckInfoInfoDataRow, "CheckrDept");
            }
            if (BaoxiaoCheckInfoInfoDataRow["CheckDateTime"] != null)
            {
                BaoxiaoCheckInfoInfo.CheckDateTime = DateTime.Parse(DataUtil.GetStringValueOfRow(BaoxiaoCheckInfoInfoDataRow, "CheckDateTime"));
            }
            if (BaoxiaoCheckInfoInfoDataRow["Checkstate"] != null)
            {
                BaoxiaoCheckInfoInfo.Checkstate = short.Parse(DataUtil.GetStringValueOfRow(BaoxiaoCheckInfoInfoDataRow, "Checkstate"));
            }
            if (BaoxiaoCheckInfoInfoDataRow["Result"] != null)
            {
                BaoxiaoCheckInfoInfo.Result = DataUtil.GetStringValueOfRow(BaoxiaoCheckInfoInfoDataRow, "Result");
            }
            if (BaoxiaoCheckInfoInfoDataRow["CheckSugest"] != null)
            {
                BaoxiaoCheckInfoInfo.CheckSugest = DataUtil.GetStringValueOfRow(BaoxiaoCheckInfoInfoDataRow, "CheckSugest");
            }
            if (BaoxiaoCheckInfoInfoDataRow["CheckOp"] != null)
            {
                BaoxiaoCheckInfoInfo.CheckOp = DataUtil.GetStringValueOfRow(BaoxiaoCheckInfoInfoDataRow, "CheckOp");
            }

            return BaoxiaoCheckInfoInfo;
        }
        #endregion
    }
}
