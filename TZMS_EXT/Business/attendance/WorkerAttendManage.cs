using System;
using System.Collections.Generic;
using System.Text;
using com.TZMS.Model;
using com.TZMS.DataAccess;
using System.Data;
using System.Data.OleDb;
using System.Collections;

namespace com.TZMS.Business
{
    public class WorkerAttendManage : ParentManage
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public WorkerAttendManage()
        { }

        /// <summary>
        /// 添加新的考勤信息到数据库
        /// </summary>
        /// <param name="attendInfo">考勤信息实体</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>执行结果</returns>
        public int AddNewAttendInfo(AttendInfo attendInfo, string boName = BoName)
        {
            AttendInfoCtrl _ctrl = new AttendInfoCtrl();
            return _ctrl.Insert(boName, attendInfo);
        }

        /// <summary>
        /// 更新考勤信息
        /// </summary>
        /// <param name="attendInfo">考勤信息实体</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>操作结果</returns>
        public int UpdateAttendInfo(AttendInfo attendInfo, string boName = BoName)
        {
            AttendInfoCtrl _ctrl = new AttendInfoCtrl();
            return _ctrl.UpDate(boName, attendInfo);
        }

        /// <summary>
        /// 根据查询条件获取考勤信息集合
        /// </summary>
        /// <param name="codition">查询条件</param>
        /// <param name="boName">连接字符串Key</param>
        /// <returns>考勤信息集合</returns>
        public List<AttendInfo> GetAttendInfoByCondition(string codition, string boName = BoName)
        {
            AttendInfoCtrl _ctrl = new AttendInfoCtrl();
            return _ctrl.SelectAsList(boName, codition);
        }

        /// <summary>
        /// 导入考勤信息
        /// </summary>
        /// <param name="importTable">考勤信息数据表</param>
        /// <param name="boName">连接字符串Key</param>
        public void ImportAttendInfo(DataTable importTable, string boName = BoName)
        {
            if (importTable != null)
            {
                AttendInfo _info = null;
                UserInfo _userInfo = null;
                UserManage _userManage = new UserManage();
                foreach (DataRow row in importTable.Rows)
                {
                    _info = this.AttendInfoHasExist(row[0].ToString(), row[1].ToString(), DateTime.Parse(row[3].ToString()));
                    if (_info == null)
                    {
                        _userInfo = _userManage.GetUserByNameAndJobNo(row[1].ToString(), row[0].ToString());
                        if (_userInfo != null)
                        {
                            _info = new AttendInfo();
                            _info.ObjectId = Guid.NewGuid();
                            _info.JobNo = row[0].ToString();
                            _info.Name = row[1].ToString();
                            _info.AccountNo = _userInfo.AccountNo;
                            _info.Dept = row[2].ToString();
                            _info.PushTime1 = DateTime.Parse(DateTime.Parse(row[3].ToString()).ToString("yyyy-MM-dd ") + row[5].ToString());
                            _info.PushTime2 = DateTime.Parse(DateTime.Parse(row[3].ToString()).ToString("yyyy-MM-dd ") + row[6].ToString());

                            this.AddNewAttendInfo(_info);
                        }
                        else
                        {
                            throw new Exception("找不到用户名为'" + row[1].ToString() + "'的用户!");
                        }
                    }
                    else
                    {
                        _info.PushTime1 = DateTime.Parse(DateTime.Parse(row[3].ToString()).ToString("yyyy-MM-dd ") + row[5].ToString());
                        _info.PushTime2 = DateTime.Parse(DateTime.Parse(row[3].ToString()).ToString("yyyy-MM-dd ") + row[6].ToString());

                        this.UpdateAttendInfo(_info);
                    }
                }
            }
        }

        /// <summary>
        /// 根据工号和日期获取考勤信息
        /// </summary>
        /// <param name="strJobNo">工号</param>
        /// <param name="pushTime">打开时间1</param>
        /// <returns></returns>
        private AttendInfo AttendInfoHasExist(string strJobNo, string strName, DateTime pushTime)
        {
            List<AttendInfo> lstAttendInfo = this.GetAttendInfoByCondition("JobNo = '" + strJobNo
                + "' and Name = '" + strName
                + "' and Year(PushTime1) = '" + pushTime.Year
                + "' and Month(PushTime1) = '" + pushTime.Month
                + "' and Day(PushTime1) = '" + pushTime.Day
                + "'");
            if (lstAttendInfo.Count == 0)
            {
                return null;
            }

            return lstAttendInfo[0];
        }

        /// <summary>
        /// 导入单条考勤信息.
        /// </summary>
        /// <param name="attendInfo">考勤信息实体</param>
        /// <param name="boName">连接字符串Key</param>
        public void ImportSingleAttendInfo(AttendInfo attendInfo, string boName = BoName)
        {
            if (attendInfo != null)
            {

            }
        }

        /// <summary>
        /// 获取指定路径、指定工作簿名称的Excel数据:取第一个sheet的数据
        /// </summary>
        /// <param name="FilePath">文件存储路径</param>
        /// <param name="WorkSheetName">工作簿名称</param>
        /// <returns>如果争取找到了数据会返回一个完整的Table，否则返回异常</returns>
        public DataTable GetExcelData(string astrFileName)
        {
            string strSheetName = GetExcelWorkSheets(astrFileName)[0].ToString();
            return GetExcelData(astrFileName, strSheetName);
        }

        /// <summary>
        /// 获取指定路径、指定工作簿名称的Excel数据
        /// </summary>
        /// <param name="FilePath">文件存储路径</param>
        /// <param name="WorkSheetName">工作簿名称</param>
        /// <returns>如果争取找到了数据会返回一个完整的Table，否则返回异常</returns>
        public DataTable GetExcelData(string FilePath, string WorkSheetName)
        {
            DataTable dtExcel = new DataTable();
            OleDbConnection con = new OleDbConnection(GetExcelConnection(FilePath));
            OleDbDataAdapter adapter = new OleDbDataAdapter("Select * from [" + WorkSheetName + "$]", con);

            //读取
            con.Open();
            adapter.FillSchema(dtExcel, SchemaType.Mapped);
            adapter.Fill(dtExcel);
            con.Close();
            dtExcel.TableName = WorkSheetName;

            //返回
            return dtExcel;
        }

        /// <summary>
        /// 获取链接字符串
        /// </summary>
        /// <param name="strFilePath"></param>
        /// <returns></returns>
        public string GetExcelConnection(string strFilePath)
        {
            return "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strFilePath + ";Extended properties=\"Excel 8.0;Imex=1;HDR=Yes;\"";
        }

        /// <summary>
        /// 返回指定文件所包含的工作簿列表;如果有WorkSheet，就返回以工作簿名字命名的ArrayList，否则返回空
        /// </summary>
        /// <param name="strFilePath">要获取的Excel</param>
        /// <returns>如果有WorkSheet，就返回以工作簿名字命名的ArrayList，否则返回空</returns>
        public ArrayList GetExcelWorkSheets(string strFilePath)
        {
            ArrayList alTables = new ArrayList();

            OleDbConnection odn = new OleDbConnection(GetExcelConnection(strFilePath));
            odn.Open();

            DataTable dt = new DataTable();

            dt = odn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

            if (dt == null)
            {
                throw new Exception("无法获取指定Excel的架构!");
            }

            foreach (DataRow dr in dt.Rows)
            {
                string tempName = dr["Table_Name"].ToString();

                int iDolarIndex = tempName.IndexOf('$');

                if (iDolarIndex > 0)
                {
                    tempName = tempName.Substring(0, iDolarIndex);
                }

                //修正了Excel2003中某些工作薄名称为汉字的表无法正确识别的BUG。
                if (tempName[0] == '\'')
                {
                    if (tempName[tempName.Length - 1] == '\'')
                    {
                        tempName = tempName.Substring(1, tempName.Length - 2);
                    }
                    else
                    {
                        tempName = tempName.Substring(1, tempName.Length - 1);
                    }

                }
                if (!alTables.Contains(tempName))
                {
                    alTables.Add(tempName);
                }
            }

            odn.Close();

            if (alTables.Count == 0)
            {
                return null;
            }

            return alTables;
        }
    }
}
