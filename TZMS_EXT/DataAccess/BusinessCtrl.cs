//----------------------------------------------------------------------------------------------------
//程序名:	Business 控制类
//功能:  	定义了与 dbo.Business 表 对应的数据访问控制类
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
    /// BusinessCtrl
    /// programmer:xiguazerg
    /// </summary>
    public class BusinessCtrl
    {
        #region 构造函数

        /// <summary>
        /// BusinessCtrl默认构造函数
        /// </summary>
        public BusinessCtrl()
        {
            //ToDo

        }

        #endregion

        #region 增、删、改、查

        /// <summary>
        /// 插入dbo.Business一条记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="BusinessInfo">BusinessInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int Insert(string boName, BusinessInfo BusinessInfo)
        {
            try
            {
                //存储过程名称
                string strsql = "Business_Add";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjectID",DbType.Guid),
				new SqlParameter("@CreaterID",DbType.Guid),
				new SqlParameter("@CreaterName",DbType.String),
				new SqlParameter("@CreaterAccountNo",DbType.String),
				new SqlParameter("@CreaterDept",DbType.String),
				new SqlParameter("@CreateTime",DbType.DateTime),
				new SqlParameter("@SignerID",DbType.Guid),
				new SqlParameter("@SignerName",DbType.String),
				new SqlParameter("@SignTime",DbType.DateTime),
				new SqlParameter("@CompanyName",DbType.String),
				new SqlParameter("@RegisteredMoney",DbType.Guid),
				new SqlParameter("@CZType",DbType.Int16),
				new SqlParameter("@CompanyType",DbType.Int16),
				new SqlParameter("@CompanyNameType",DbType.Int16),
				new SqlParameter("@SumMoney",DbType.Guid),
				new SqlParameter("@PreMoney",DbType.Guid),
				new SqlParameter("@PreMoneyType",DbType.Int16),
				new SqlParameter("@BalanceMoney",DbType.Guid),
				new SqlParameter("@BalanceMoneyType",DbType.Int16),
				new SqlParameter("@Contact",DbType.String),
				new SqlParameter("@ContactPhoneNumber",DbType.String),
				new SqlParameter("@CostMoney",DbType.Guid),
				new SqlParameter("@OtherMoney",DbType.Guid),
				new SqlParameter("@OtherMoneyExplain",DbType.String),
				new SqlParameter("@Content",DbType.String),
				new SqlParameter("@Other",DbType.String),
				new SqlParameter("@State",DbType.Int16),
				new SqlParameter("@CurrentBusinessRecordID",DbType.Guid),
				new SqlParameter("@CurrentUserID",DbType.Guid),
				new SqlParameter("@IsDelete",DbType.Boolean),
				new SqlParameter("@BusinessType",DbType.Int16),
				new SqlParameter("@BusinessCells",DbType.String),
				new SqlParameter("@CheckOther",DbType.String),

                new SqlParameter("@RegisteredMoneyFlag",DbType.String),
                new SqlParameter("@SumMoneyFlag",DbType.String),
                new SqlParameter("@PreMoneyFlag",DbType.String),
                new SqlParameter("@BalanceMoneyFlag",DbType.String),
                new SqlParameter("@CostMoneyFlag",DbType.String),
                new SqlParameter("@OtherMoneyFlag",DbType.String),
				};

                int i = 0;
                sqlparam[i++].Value = BusinessInfo.ObjectID;
                sqlparam[i++].Value = BusinessInfo.CreaterID;
                sqlparam[i++].Value = BusinessInfo.CreaterName;
                sqlparam[i++].Value = BusinessInfo.CreaterAccountNo;
                sqlparam[i++].Value = BusinessInfo.CreaterDept;
                sqlparam[i++].Value = BusinessInfo.CreateTime;
                sqlparam[i++].Value = BusinessInfo.SignerID;
                sqlparam[i++].Value = BusinessInfo.SignerName;
                sqlparam[i++].Value = BusinessInfo.SignTime;
                sqlparam[i++].Value = BusinessInfo.CompanyName;
                sqlparam[i++].Value = BusinessInfo.RegisteredMoney;
                sqlparam[i++].Value = BusinessInfo.CZType;
                sqlparam[i++].Value = BusinessInfo.CompanyType;
                sqlparam[i++].Value = BusinessInfo.CompanyNameType;
                sqlparam[i++].Value = BusinessInfo.SumMoney;
                sqlparam[i++].Value = BusinessInfo.PreMoney;
                sqlparam[i++].Value = BusinessInfo.PreMoneyType;
                sqlparam[i++].Value = BusinessInfo.BalanceMoney;
                sqlparam[i++].Value = BusinessInfo.BalanceMoneyType;
                sqlparam[i++].Value = BusinessInfo.Contact;
                sqlparam[i++].Value = BusinessInfo.ContactPhoneNumber;
                sqlparam[i++].Value = BusinessInfo.CostMoney;
                sqlparam[i++].Value = BusinessInfo.OtherMoney;
                sqlparam[i++].Value = BusinessInfo.OtherMoneyExplain;
                sqlparam[i++].Value = BusinessInfo.Content;
                sqlparam[i++].Value = BusinessInfo.Other;
                sqlparam[i++].Value = BusinessInfo.State;
                sqlparam[i++].Value = BusinessInfo.CurrentBusinessRecordID;
                sqlparam[i++].Value = BusinessInfo.CurrentUserID;
                sqlparam[i++].Value = BusinessInfo.IsDelete;
                sqlparam[i++].Value = BusinessInfo.BusinessType;
                sqlparam[i++].Value = BusinessInfo.BusinessCells;
                sqlparam[i++].Value = BusinessInfo.CheckOther;

                sqlparam[i++].Value = BusinessInfo.RegisteredMoneyFlag;
                sqlparam[i++].Value = BusinessInfo.SumMoneyFlag;
                sqlparam[i++].Value = BusinessInfo.PreMoneyFlag;
                sqlparam[i++].Value = BusinessInfo.BalanceMoneyFlag;
                sqlparam[i++].Value = BusinessInfo.CostMoneyFlag;
                sqlparam[i++].Value = BusinessInfo.OtherMoneyFlag;
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
        /// dbo.Business删除记录(通过记录ID ObjectID)
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="objectID">ObjectID(唯一ID)</param>
        public void Delete(string boName, string objectID)
        {
            try
            {
                string strsql = "Business_Delete";

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
        /// Business 更新记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="BusinessInfo">BusinessInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int UpDate(string boName, BusinessInfo BusinessInfo)
        {
            try
            {
                //存储过程名称
                string strsql = "Business_Update";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjectID",DbType.Guid),
				new SqlParameter("@CreaterID",DbType.Guid),
				new SqlParameter("@CreaterName",DbType.String),
				new SqlParameter("@CreaterAccountNo",DbType.String),
				new SqlParameter("@CreaterDept",DbType.String),
				new SqlParameter("@CreateTime",DbType.DateTime),
				new SqlParameter("@SignerID",DbType.Guid),
				new SqlParameter("@SignerName",DbType.String),
				new SqlParameter("@SignTime",DbType.DateTime),
				new SqlParameter("@CompanyName",DbType.String),
				new SqlParameter("@RegisteredMoney",DbType.Guid),
				new SqlParameter("@CZType",DbType.Int16),
				new SqlParameter("@CompanyType",DbType.Int16),
				new SqlParameter("@CompanyNameType",DbType.Int16),
				new SqlParameter("@SumMoney",DbType.Guid),
				new SqlParameter("@PreMoney",DbType.Guid),
				new SqlParameter("@PreMoneyType",DbType.Int16),
				new SqlParameter("@BalanceMoney",DbType.Guid),
				new SqlParameter("@BalanceMoneyType",DbType.Int16),
				new SqlParameter("@Contact",DbType.String),
				new SqlParameter("@ContactPhoneNumber",DbType.String),
				new SqlParameter("@CostMoney",DbType.Guid),
				new SqlParameter("@OtherMoney",DbType.Guid),
				new SqlParameter("@OtherMoneyExplain",DbType.String),
				new SqlParameter("@Content",DbType.String),
				new SqlParameter("@Other",DbType.String),
				new SqlParameter("@State",DbType.Int16),
				new SqlParameter("@CurrentBusinessRecordID",DbType.Guid),
				new SqlParameter("@CurrentUserID",DbType.Guid),
				new SqlParameter("@IsDelete",DbType.Boolean),
				new SqlParameter("@BusinessType",DbType.Int16),
				new SqlParameter("@BusinessCells",DbType.String),
				new SqlParameter("@CheckOther",DbType.String),
                new SqlParameter("@RegisteredMoneyFlag",DbType.String),
                new SqlParameter("@SumMoneyFlag",DbType.String),
                new SqlParameter("@PreMoneyFlag",DbType.String),
                new SqlParameter("@BalanceMoneyFlag",DbType.String),
                new SqlParameter("@CostMoneyFlag",DbType.String),
                new SqlParameter("@OtherMoneyFlag",DbType.String),
                };

                int i = 0;
                sqlparam[i++].Value = BusinessInfo.ObjectID;
                sqlparam[i++].Value = BusinessInfo.CreaterID;
                sqlparam[i++].Value = BusinessInfo.CreaterName;
                sqlparam[i++].Value = BusinessInfo.CreaterAccountNo;
                sqlparam[i++].Value = BusinessInfo.CreaterDept;
                sqlparam[i++].Value = BusinessInfo.CreateTime;
                sqlparam[i++].Value = BusinessInfo.SignerID;
                sqlparam[i++].Value = BusinessInfo.SignerName;
                sqlparam[i++].Value = BusinessInfo.SignTime;
                sqlparam[i++].Value = BusinessInfo.CompanyName;
                sqlparam[i++].Value = BusinessInfo.RegisteredMoney;
                sqlparam[i++].Value = BusinessInfo.CZType;
                sqlparam[i++].Value = BusinessInfo.CompanyType;
                sqlparam[i++].Value = BusinessInfo.CompanyNameType;
                sqlparam[i++].Value = BusinessInfo.SumMoney;
                sqlparam[i++].Value = BusinessInfo.PreMoney;
                sqlparam[i++].Value = BusinessInfo.PreMoneyType;
                sqlparam[i++].Value = BusinessInfo.BalanceMoney;
                sqlparam[i++].Value = BusinessInfo.BalanceMoneyType;
                sqlparam[i++].Value = BusinessInfo.Contact;
                sqlparam[i++].Value = BusinessInfo.ContactPhoneNumber;
                sqlparam[i++].Value = BusinessInfo.CostMoney;
                sqlparam[i++].Value = BusinessInfo.OtherMoney;
                sqlparam[i++].Value = BusinessInfo.OtherMoneyExplain;
                sqlparam[i++].Value = BusinessInfo.Content;
                sqlparam[i++].Value = BusinessInfo.Other;
                sqlparam[i++].Value = BusinessInfo.State;
                sqlparam[i++].Value = BusinessInfo.CurrentBusinessRecordID;
                sqlparam[i++].Value = BusinessInfo.CurrentUserID;
                sqlparam[i++].Value = BusinessInfo.IsDelete;
                sqlparam[i++].Value = BusinessInfo.BusinessType;
                sqlparam[i++].Value = BusinessInfo.BusinessCells;
                sqlparam[i++].Value = BusinessInfo.CheckOther;
                sqlparam[i++].Value = BusinessInfo.RegisteredMoneyFlag;
                sqlparam[i++].Value = BusinessInfo.SumMoneyFlag;
                sqlparam[i++].Value = BusinessInfo.PreMoneyFlag;
                sqlparam[i++].Value = BusinessInfo.BalanceMoneyFlag;
                sqlparam[i++].Value = BusinessInfo.CostMoneyFlag;
                sqlparam[i++].Value = BusinessInfo.OtherMoneyFlag;
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
        /// Business 查询,返回Datatable
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="selectCondition">查询条件</param>
        /// <returns>DataTable</returns>
        public DataTable Select(string boName, string condition)
        {
            try
            {
                //存储过程名称
                string strsql = "Business_Search";
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
        ///Business 查询,返回List
        ///</summary>
        ///<param name="boName">数据库连接配置key信息</param>
        ///<param name="selectCondition">查询条件</param>
        /// <returns>List<BusinessInfo></returns>
        public List<BusinessInfo> SelectAsList(string boName, string selectCondition)
        {
            DataTable table = new DataTable();
            List<BusinessInfo> list = new List<BusinessInfo>();
            BusinessInfo accountInfo = new BusinessInfo();

            try
            {
                table = Select(boName, selectCondition);

                // DataTable To ArrayList
                foreach (DataRow row in table.Rows)
                {
                    accountInfo = BusinessInfoRowToInfo(row);
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
        /// <param name="BusinessDataRow">BusinessDataRow</param>
        /// <returns>BusinessInfo</returns>
        internal BusinessInfo BusinessInfoRowToInfo(DataRow InfoDataRow)
        {
            BusinessInfo Info = new BusinessInfo();
            if (InfoDataRow["ObjectID"] != null)
            {
                Info.ObjectID = new Guid(DataUtil.GetStringValueOfRow(InfoDataRow, "ObjectID"));
            }
            if (InfoDataRow["CreaterID"] != null)
            {
                Info.CreaterID = new Guid(DataUtil.GetStringValueOfRow(InfoDataRow, "CreaterID"));
            }
            if (InfoDataRow["CreaterName"] != null)
            {
                Info.CreaterName = DataUtil.GetStringValueOfRow(InfoDataRow, "CreaterName");
            }
            if (InfoDataRow["CreaterAccountNo"] != null)
            {
                Info.CreaterAccountNo = DataUtil.GetStringValueOfRow(InfoDataRow, "CreaterAccountNo");
            }
            if (InfoDataRow["CreaterDept"] != null)
            {
                Info.CreaterDept = DataUtil.GetStringValueOfRow(InfoDataRow, "CreaterDept");
            }
            if (InfoDataRow["CreateTime"] != null)
            {
                Info.CreateTime = DateTime.Parse(DataUtil.GetStringValueOfRow(InfoDataRow, "CreateTime"));
            }
            if (InfoDataRow["SignerID"] != null)
            {
                Info.SignerID = new Guid(DataUtil.GetStringValueOfRow(InfoDataRow, "SignerID"));
            }
            if (InfoDataRow["SignerName"] != null)
            {
                Info.SignerName = DataUtil.GetStringValueOfRow(InfoDataRow, "SignerName");
            }
            if (InfoDataRow["SignTime"] != null)
            {
                Info.SignTime = DateTime.Parse(DataUtil.GetStringValueOfRow(InfoDataRow, "SignTime"));
            }
            if (InfoDataRow["CompanyName"] != null)
            {
                Info.CompanyName = DataUtil.GetStringValueOfRow(InfoDataRow, "CompanyName");
            }
            if (InfoDataRow["RegisteredMoney"] != null)
            {
                Info.RegisteredMoney = Convert.ToDecimal(DataUtil.GetStringValueOfRow(InfoDataRow, "RegisteredMoney"));
            }
            if (InfoDataRow["CZType"] != null)
            {
                Info.CZType = short.Parse(DataUtil.GetStringValueOfRow(InfoDataRow, "CZType"));
            }
            if (InfoDataRow["CompanyType"] != null)
            {
                Info.CompanyType = short.Parse(DataUtil.GetStringValueOfRow(InfoDataRow, "CompanyType"));
            }
            if (InfoDataRow["CompanyNameType"] != null)
            {
                Info.CompanyNameType = short.Parse(DataUtil.GetStringValueOfRow(InfoDataRow, "CompanyNameType"));
            }
            if (InfoDataRow["SumMoney"] != null)
            {
                Info.SumMoney = Convert.ToDecimal(DataUtil.GetStringValueOfRow(InfoDataRow, "SumMoney"));
            }
            if (InfoDataRow["PreMoney"] != null)
            {
                Info.PreMoney = Convert.ToDecimal(DataUtil.GetStringValueOfRow(InfoDataRow, "PreMoney"));
            }
            if (InfoDataRow["PreMoneyType"] != null)
            {
                Info.PreMoneyType = short.Parse(DataUtil.GetStringValueOfRow(InfoDataRow, "PreMoneyType"));
            }
            if (InfoDataRow["BalanceMoney"] != null)
            {
                Info.BalanceMoney = Convert.ToDecimal(DataUtil.GetStringValueOfRow(InfoDataRow, "BalanceMoney"));
            }
            if (InfoDataRow["BalanceMoneyType"] != null)
            {
                Info.BalanceMoneyType = short.Parse(DataUtil.GetStringValueOfRow(InfoDataRow, "BalanceMoneyType"));
            }
            if (InfoDataRow["Contact"] != null)
            {
                Info.Contact = DataUtil.GetStringValueOfRow(InfoDataRow, "Contact");
            }
            if (InfoDataRow["ContactPhoneNumber"] != null)
            {
                Info.ContactPhoneNumber = DataUtil.GetStringValueOfRow(InfoDataRow, "ContactPhoneNumber");
            }
            if (InfoDataRow["CostMoney"] != null)
            {
                Info.CostMoney = Convert.ToDecimal(DataUtil.GetStringValueOfRow(InfoDataRow, "CostMoney"));
            }
            if (InfoDataRow["OtherMoney"] != null)
            {
                Info.OtherMoney = Convert.ToDecimal(DataUtil.GetStringValueOfRow(InfoDataRow, "OtherMoney"));
            }
            if (InfoDataRow["OtherMoneyExplain"] != null)
            {
                Info.OtherMoneyExplain = DataUtil.GetStringValueOfRow(InfoDataRow, "OtherMoneyExplain");
            }
            if (InfoDataRow["Content"] != null)
            {
                Info.Content = DataUtil.GetStringValueOfRow(InfoDataRow, "Content");
            }
            if (InfoDataRow["Other"] != null)
            {
                Info.Other = DataUtil.GetStringValueOfRow(InfoDataRow, "Other");
            }
            if (InfoDataRow["State"] != null)
            {
                Info.State = short.Parse(DataUtil.GetStringValueOfRow(InfoDataRow, "State"));
            }
            if (InfoDataRow["CurrentBusinessRecordID"] != null)
            {
                Info.CurrentBusinessRecordID = new Guid(DataUtil.GetStringValueOfRow(InfoDataRow, "CurrentBusinessRecordID"));
            }
            if (InfoDataRow["CurrentUserID"] != null)
            {
                Info.CurrentUserID = new Guid(DataUtil.GetStringValueOfRow(InfoDataRow, "CurrentUserID"));
            }
            if (InfoDataRow["IsDelete"] != null)
            {
                Info.IsDelete = bool.Parse(DataUtil.GetStringValueOfRow(InfoDataRow, "IsDelete"));
            }
            if (InfoDataRow["BusinessType"] != null)
            {
                Info.BusinessType = short.Parse(DataUtil.GetStringValueOfRow(InfoDataRow, "BusinessType"));
            }
            if (InfoDataRow["BusinessCells"] != null)
            {
                Info.BusinessCells = DataUtil.GetStringValueOfRow(InfoDataRow, "BusinessCells");
            }
            if (InfoDataRow["CheckOther"] != null)
            {
                Info.CheckOther = DataUtil.GetStringValueOfRow(InfoDataRow, "CheckOther");
            }

            if (InfoDataRow["RegisteredMoneyFlag"] != null)
            {
                Info.RegisteredMoneyFlag = DataUtil.GetStringValueOfRow(InfoDataRow, "RegisteredMoneyFlag");
            }
            if (InfoDataRow["SumMoneyFlag"] != null)
            {
                Info.SumMoneyFlag = DataUtil.GetStringValueOfRow(InfoDataRow, "SumMoneyFlag");
            }
            if (InfoDataRow["PreMoneyFlag"] != null)
            {
                Info.PreMoneyFlag = DataUtil.GetStringValueOfRow(InfoDataRow, "PreMoneyFlag");
            }
            if (InfoDataRow["BalanceMoneyFlag"] != null)
            {
                Info.BalanceMoneyFlag = DataUtil.GetStringValueOfRow(InfoDataRow, "BalanceMoneyFlag");
            }
            if (InfoDataRow["CostMoneyFlag"] != null)
            {
                Info.CostMoneyFlag = DataUtil.GetStringValueOfRow(InfoDataRow, "CostMoneyFlag");
            }
            if (InfoDataRow["OtherMoneyFlag"] != null)
            {
                Info.OtherMoneyFlag = DataUtil.GetStringValueOfRow(InfoDataRow, "OtherMoneyFlag");
            }

            return Info;
        }
        #endregion
    }
}
