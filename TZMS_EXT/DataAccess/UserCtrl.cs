//----------------------------------------------------------------------------------------------------
//程序名:	UserInfo 控制类
//功能:  	定义了与 dbo.UserInfo 表 对应的数据访问控制类
//作者:  	shunlian
//时间:	2011-10-16 
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

namespace com.TZMS.DataAccess
{
    /// <summary>
    /// UserCtrl
    /// programmer:shunlian
    /// </summary>
    public class UserCtrl
    {
        #region 构造函数

        /// <summary>
        /// UserCtrl默认构造函数
        /// </summary>
        public UserCtrl()
        {
            //ToDo
        }

        #endregion

        #region 增、删、改、查


        /// <summary>
        /// 插入dbo.UserInfo一条记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="UserInfo">UserInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int Insert(string boName, UserInfo UserInfo)
        {
            try
            {
                //存储过程名称
                string strsql = "UserInfo_Add";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjectId",DbType.Guid),
				new SqlParameter("@AccountNo",DbType.String),
				new SqlParameter("@JobNo",DbType.String),
				new SqlParameter("@Name",DbType.String),
				new SqlParameter("@Sex",DbType.Boolean),
				new SqlParameter("@Dept",DbType.String),
				new SqlParameter("@Birthday",DbType.DateTime),
				new SqlParameter("@PhoneNumber",DbType.String),
				new SqlParameter("@Address",DbType.String),
				new SqlParameter("@EntryDate",DbType.DateTime),
				new SqlParameter("@Position",DbType.String),
				new SqlParameter("@State",DbType.Int16),
				new SqlParameter("@BackIpPhoneNumber",DbType.String),
				new SqlParameter("@Email",DbType.String),
				new SqlParameter("@Password",DbType.String),
				new SqlParameter("@Educational",DbType.String),
				new SqlParameter("@WorkYear",DbType.Int16),
				new SqlParameter("@GraduatedSchool",DbType.String),
                new SqlParameter("@IsProbation",DbType.Boolean),
                new SqlParameter("@ProbationTime",DbType.DateTime),
                new SqlParameter("@LeaveTime",DbType.DateTime),
                new SqlParameter("@BaseSalary",DbType.Decimal),
                new SqlParameter("@Menu",DbType.String),
                new SqlParameter("@Record",DbType.String)
				};

                int i = 0;
                sqlparam[i++].Value = UserInfo.ObjectId;
                sqlparam[i++].Value = UserInfo.AccountNo;
                sqlparam[i++].Value = UserInfo.JobNo;
                sqlparam[i++].Value = UserInfo.Name;
                sqlparam[i++].Value = UserInfo.Sex;
                sqlparam[i++].Value = UserInfo.Dept;
                sqlparam[i++].Value = UserInfo.Birthday;
                sqlparam[i++].Value = UserInfo.PhoneNumber;
                sqlparam[i++].Value = UserInfo.Address;
                sqlparam[i++].Value = UserInfo.EntryDate;
                sqlparam[i++].Value = UserInfo.Position;
                sqlparam[i++].Value = UserInfo.State;
                sqlparam[i++].Value = UserInfo.BackIpPhoneNumber;
                sqlparam[i++].Value = UserInfo.Email;
                sqlparam[i++].Value = UserInfo.Password;
                sqlparam[i++].Value = UserInfo.Educational;
                sqlparam[i++].Value = UserInfo.WorkYear;
                sqlparam[i++].Value = UserInfo.GraduatedSchool;
                sqlparam[i++].Value = UserInfo.IsProbation;
                sqlparam[i++].Value = UserInfo.ProbationTime;
                sqlparam[i++].Value = UserInfo.LeaveTime;
                sqlparam[i++].Value = UserInfo.BaseSalary;
                sqlparam[i++].Value = UserInfo.Menu;
                sqlparam[i++].Value = UserInfo.Record;
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
        /// dbo.UserInfo删除记录(通过记录ID ObjectID)
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="condition">条件</param>
        public void Delete(string boName, string condition)
        {
            try
            {
                string strsql = "UserInfo_Delete";

                SqlParameter[] sqlparam =
				{
					new SqlParameter ( "@Condition", SqlDbType.NVarChar )
				};
                int i = 0;
                sqlparam[i++].Value = condition;

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
        /// UserInfo 更新记录
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="UserInfo">UserInfo??</param>
        /// <returns>返回标志,0:失败,1:成功</returns>
        public int UpDate(string boName, UserInfo UserInfo)
        {
            try
            {
                //存储过程名称
                string strsql = "UserInfo_Update";
                SqlParameter[] sqlparam =
                {
				new SqlParameter("@ObjectId",DbType.Guid),
				new SqlParameter("@AccountNo",DbType.String),
				new SqlParameter("@JobNo",DbType.String),
				new SqlParameter("@Name",DbType.String),
				new SqlParameter("@Sex",DbType.Boolean),
				new SqlParameter("@Dept",DbType.String),
				new SqlParameter("@Birthday",DbType.DateTime),
				new SqlParameter("@PhoneNumber",DbType.String),
				new SqlParameter("@Address",DbType.String),
				new SqlParameter("@EntryDate",DbType.DateTime),
				new SqlParameter("@Position",DbType.String),
				new SqlParameter("@State",DbType.Int16),
				new SqlParameter("@BackIpPhoneNumber",DbType.String),
				new SqlParameter("@Email",DbType.String),
				new SqlParameter("@Password",DbType.String),
				new SqlParameter("@Educational",DbType.String),
				new SqlParameter("@WorkYear",DbType.Int16),
				new SqlParameter("@GraduatedSchool",DbType.String),
                new SqlParameter("@IsProbation",DbType.Boolean),
                new SqlParameter("@ProbationTime",DbType.DateTime),
                new SqlParameter("@LeaveTime",DbType.DateTime),
                new SqlParameter("@BaseSalary",DbType.Decimal),
                new SqlParameter("@Menu",DbType.String),
                new SqlParameter("@Record",DbType.String)
                };

                int i = 0;
                sqlparam[i++].Value = UserInfo.ObjectId;
                sqlparam[i++].Value = UserInfo.AccountNo;
                sqlparam[i++].Value = UserInfo.JobNo;
                sqlparam[i++].Value = UserInfo.Name;
                sqlparam[i++].Value = UserInfo.Sex;
                sqlparam[i++].Value = UserInfo.Dept;
                sqlparam[i++].Value = UserInfo.Birthday;
                sqlparam[i++].Value = UserInfo.PhoneNumber;
                sqlparam[i++].Value = UserInfo.Address;
                sqlparam[i++].Value = UserInfo.EntryDate;
                sqlparam[i++].Value = UserInfo.Position;
                sqlparam[i++].Value = UserInfo.State;
                sqlparam[i++].Value = UserInfo.BackIpPhoneNumber;
                sqlparam[i++].Value = UserInfo.Email;
                sqlparam[i++].Value = UserInfo.Password;
                sqlparam[i++].Value = UserInfo.Educational;
                sqlparam[i++].Value = UserInfo.WorkYear;
                sqlparam[i++].Value = UserInfo.GraduatedSchool;
                sqlparam[i++].Value = UserInfo.IsProbation;
                sqlparam[i++].Value = UserInfo.ProbationTime;
                sqlparam[i++].Value = UserInfo.LeaveTime;
                sqlparam[i++].Value = UserInfo.BaseSalary;
                sqlparam[i++].Value = UserInfo.Menu;
                sqlparam[i++].Value = UserInfo.Record;
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
        /// UserInfo 查询,返回Datatable
        /// </summary>
        /// <param name="boName">数据库连接配置key信息</param>
        /// <param name="selectCondition">查询条件</param>
        /// <returns>DataTable</returns>
        public DataTable Select(string boName, string condition)
        {
            try
            {
                //存储过程名称
                string strsql = "UserInfo_Search";
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
        ///UserInfo 查询,返回List
        ///</summary>
        ///<param name="boName">数据库连接配置key信息</param>
        ///<param name="selectCondition">查询条件</param>
        /// <returns>List<UserInfo></returns>
        public List<UserInfo> SelectAsList(string boName, string selectCondition)
        {
            DataTable table = new DataTable();
            List<UserInfo> list = new List<UserInfo>();
            UserInfo accountInfo = new UserInfo();

            try
            {
                table = Select(boName, selectCondition);

                // DataTable To ArrayList
                foreach (DataRow row in table.Rows)
                {
                    accountInfo = UserInfoRowToInfo(row);
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
        /// <param name="UserInfoDataRow">UserInfoDataRow</param>
        /// <returns>UserInfo</returns>
        internal UserInfo UserInfoRowToInfo(DataRow UserInfoInfoDataRow)
        {
            UserInfo UserInfoInfo = new UserInfo();
            if (UserInfoInfoDataRow["ObjectID"] != null)
            {
                UserInfoInfo.ObjectId = new Guid(UserInfoInfoDataRow["ObjectID"].ToString());
            }
            if (UserInfoInfoDataRow["AccountNo"] != null)
            {
                UserInfoInfo.AccountNo = UserInfoInfoDataRow["AccountNo"].ToString();
            }
            if (UserInfoInfoDataRow["JobNo"] != null)
            {
                UserInfoInfo.JobNo = UserInfoInfoDataRow["JobNo"].ToString();
            }
            if (UserInfoInfoDataRow["Name"] != null)
            {
                UserInfoInfo.Name = UserInfoInfoDataRow["Name"].ToString();
            }
            if (UserInfoInfoDataRow["Sex"] != null)
            {
                UserInfoInfo.Sex = bool.Parse(UserInfoInfoDataRow["Sex"].ToString());
            }
            if (UserInfoInfoDataRow["Dept"] != null)
            {
                UserInfoInfo.Dept = UserInfoInfoDataRow["Dept"].ToString();
            }
            if (UserInfoInfoDataRow["Birthday"] != null)
            {
                UserInfoInfo.Birthday = DateTime.Parse(UserInfoInfoDataRow["Birthday"].ToString());
            }
            if (UserInfoInfoDataRow["PhoneNumber"] != null)
            {
                UserInfoInfo.PhoneNumber = UserInfoInfoDataRow["PhoneNumber"].ToString();
            }
            if (UserInfoInfoDataRow["Address"] != null)
            {
                UserInfoInfo.Address = UserInfoInfoDataRow["Address"].ToString();
            }
            if (UserInfoInfoDataRow["EntryDate"] != null)
            {
                UserInfoInfo.EntryDate = DateTime.Parse(UserInfoInfoDataRow["EntryDate"].ToString());
            }
            if (UserInfoInfoDataRow["Position"] != null)
            {
                UserInfoInfo.Position = UserInfoInfoDataRow["Position"].ToString();
            }
            if (UserInfoInfoDataRow["State"] != null)
            {
                UserInfoInfo.State = short.Parse(UserInfoInfoDataRow["State"].ToString());
            }
            if (UserInfoInfoDataRow["BackIpPhoneNumber"] != null)
            {
                UserInfoInfo.BackIpPhoneNumber = UserInfoInfoDataRow["BackIpPhoneNumber"].ToString();
            }
            if (UserInfoInfoDataRow["Email"] != null)
            {
                UserInfoInfo.Email = UserInfoInfoDataRow["Email"].ToString();
            }
            if (UserInfoInfoDataRow["Password"] != null)
            {
                UserInfoInfo.Password = UserInfoInfoDataRow["Password"].ToString();
            }

            if (UserInfoInfoDataRow["Educational"] != null)
            {
                UserInfoInfo.Educational = UserInfoInfoDataRow["Educational"].ToString();
            }
            if (UserInfoInfoDataRow["WorkYear"] != null && UserInfoInfoDataRow["WorkYear"].ToString() != "")
            {
                UserInfoInfo.WorkYear = short.Parse(UserInfoInfoDataRow["WorkYear"].ToString());
            }
            if (UserInfoInfoDataRow["GraduatedSchool"] != null)
            {
                UserInfoInfo.GraduatedSchool = UserInfoInfoDataRow["GraduatedSchool"].ToString();
            }
            if (UserInfoInfoDataRow["IsProbation"] != null)
            {
                if (!string.IsNullOrEmpty(UserInfoInfoDataRow["IsProbation"].ToString()))
                    UserInfoInfo.IsProbation = bool.Parse(UserInfoInfoDataRow["IsProbation"].ToString());
            }
            if (UserInfoInfoDataRow["ProbationTime"] != null)
            {
                if (!string.IsNullOrEmpty(UserInfoInfoDataRow["ProbationTime"].ToString()))
                UserInfoInfo.ProbationTime = DateTime.Parse(UserInfoInfoDataRow["ProbationTime"].ToString());
            }
            if (UserInfoInfoDataRow["LeaveTime"] != null)
            {
                if (!string.IsNullOrEmpty(UserInfoInfoDataRow["LeaveTime"].ToString()))
                    UserInfoInfo.LeaveTime = DateTime.Parse(UserInfoInfoDataRow["LeaveTime"].ToString());
            }
            if (UserInfoInfoDataRow["BaseSalary"] != null)
            {
                if (!string.IsNullOrEmpty(UserInfoInfoDataRow["BaseSalary"].ToString()))
                    UserInfoInfo.BaseSalary = decimal.Parse(UserInfoInfoDataRow["BaseSalary"].ToString());
            }
            if (UserInfoInfoDataRow["Menu"] != null)
            {
                if (!string.IsNullOrEmpty(UserInfoInfoDataRow["Menu"].ToString()))
                    UserInfoInfo.Menu = UserInfoInfoDataRow["Menu"].ToString();
            }
            if (UserInfoInfoDataRow["Record"] != null)
            {
                if (!string.IsNullOrEmpty(UserInfoInfoDataRow["Record"].ToString()))
                    UserInfoInfo.Record = UserInfoInfoDataRow["Record"].ToString();
            }
            return UserInfoInfo;
        }
        #endregion
    }
}
