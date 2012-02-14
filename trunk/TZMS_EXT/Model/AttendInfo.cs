//----------------------------------------------------------------------------------------------------
//程序名:	AttendInfo实体类
//功能:   定义了与 dbo.AttendInfo 表 对应的数据实体类
//作者:  	shunlian
//时间:	2011-10-16 
//----------------------------------------------------------------------------------------------------
//更改历史:
//日期		         更改人		     更改内容
//----------------------------------------------------------------------------------------------------
//----------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

namespace com.TZMS.Model
{
    /// <summary>
    /// AttendInfo实体类
    /// </summary>
    [Serializable]
    public class AttendInfo : ACommonInfo
    {

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public AttendInfo()
        {
            //todo
            _pushTime1 = DateTime.Parse("1900-1-1 12:00");
            _pushTime2 = DateTime.Parse("1900-1-1 12:00");
            _startWorkTime = DateTime.Parse("1900-1-1 12:00");
            _stopWorkTime = DateTime.Parse("1900-1-1 12:00");
        }
        #endregion

        #region Field
        private Guid _objectId;
        private string _jobNo = string.Empty;
        private string _accountNo = string.Empty;
        private string _name = string.Empty;
        private string _dept = string.Empty;
        private DateTime _pushTime1 ;
        private DateTime _pushTime2;
        private DateTime _startWorkTime;
        private DateTime _stopWorkTime;
        private string _other = string.Empty;

        #endregion

        #region Property

        /// <summary>
        /// Other
        /// </summary>
        public string Other
        {
            get { return _other; }
            set { _other = value; }
        }

        /// <summary>
        /// ObjectID 
        /// </summary> 
        public Guid ObjectId
        {
            get { return _objectId; }
            set { _objectId = value; }
        }

        /// <summary>
        /// JobNo 
        /// </summary> 
        public string JobNo
        {
            get { return _jobNo; }
            set { _jobNo = value; }
        }

        /// <summary>
        /// AccountNo 
        /// </summary> 
        public string AccountNo
        {
            get { return _accountNo; }
            set { _accountNo = value; }
        }

        /// <summary>
        /// Name 
        /// </summary> 
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// Dept 
        /// </summary> 
        public string Dept
        {
            get { return _dept; }
            set { _dept = value; }
        }

        /// <summary>
        /// PushTime1 
        /// </summary> 
        public DateTime PushTime1
        {
            get { return _pushTime1; }
            set { _pushTime1 = value; }
        }

        /// <summary>
        /// PushTime2 
        /// </summary> 
        public DateTime PushTime2
        {
            get { return _pushTime2; }
            set { _pushTime2 = value; }
        }

        /// <summary>
        /// StartWorkTime 
        /// </summary> 
        public DateTime StartWorkTime
        {
            get { return _startWorkTime; }
            set { _startWorkTime = value; }
        }

        /// <summary>
        /// StopWorkTime 
        /// </summary> 
        public DateTime StopWorkTime
        {
            get { return _stopWorkTime; }
            set { _stopWorkTime = value; }
        }

        #endregion
    }
}


