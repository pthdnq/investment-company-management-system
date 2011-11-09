//----------------------------------------------------------------------------------------------------
//程序名:	NoAttend实体类
//功能:   定义了与 dbo.NoAttend 表 对应的数据实体类
//作者:  	CodeSmith
//时间:	2010-10-25 
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
    /// NoAttend实体类
    /// </summary>
    [Serializable]
    public class NoAttendInfo : ACommonInfo
    {

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public NoAttendInfo()
        {
            //todo
        }
        #endregion

        #region Field
        private Guid _objectId;
        private Guid _userId;
        private string _userName = DBEmptyString;
        private string _userJobNo = DBEmptyString;
        private string _userAccountNo = DBEmptyString;
        private string _dept = DBEmptyString;
        private string _tellPhone = DBEmptyString;
        private short _year = DBEmptyInt;
        private short _month = DBEmptyInt;
        private DateTime _applyTime = DBEmptyDate;
        private string _comment = DBEmptyString;
        private string _other = DBEmptyString;
        private short _state = DBEmptyInt;
        private bool _isdelete;
        private Guid _currentCheckId;
        #endregion

        #region Property
        /// <summary>
        /// ObjectID 
        /// </summary> 
        public Guid ObjectId
        {
            get { return _objectId; }
            set { _objectId = value; }
        }

        /// <summary>
        /// UserID 
        /// </summary> 
        public Guid UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }

        /// <summary>
        /// UserName 
        /// </summary> 
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        /// <summary>
        /// UserJobNo 
        /// </summary> 
        public string UserJobNo
        {
            get { return _userJobNo; }
            set { _userJobNo = value; }
        }

        /// <summary>
        /// UserAccountNo 
        /// </summary> 
        public string UserAccountNo
        {
            get { return _userAccountNo; }
            set { _userAccountNo = value; }
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
        /// TellPhone 
        /// </summary> 
        public string TellPhone
        {
            get { return _tellPhone; }
            set { _tellPhone = value; }
        }

        /// <summary>
        /// Year 
        /// </summary> 
        public short Year
        {
            get { return _year; }
            set { _year = value; }
        }

        /// <summary>
        /// Month 
        /// </summary> 
        public short Month
        {
            get { return _month; }
            set { _month = value; }
        }

        /// <summary>
        /// ApplyTime 
        /// </summary> 
        public DateTime ApplyTime
        {
            get { return _applyTime; }
            set { _applyTime = value; }
        }

        /// <summary>
        /// Comment 
        /// </summary> 
        public string Comment
        {
            get { return _comment; }
            set { _comment = value; }
        }

        /// <summary>
        /// Other 
        /// </summary> 
        public string Other
        {
            get { return _other; }
            set { _other = value; }
        }

        /// <summary>
        /// state 
        /// </summary> 
        public short State
        {
            get { return _state; }
            set { _state = value; }
        }

        /// <summary>
        /// Isdelete 
        /// </summary> 
        public bool Isdelete
        {
            get { return _isdelete; }
            set { _isdelete = value; }
        }

        /// <summary>
        /// CurrentCheckID 
        /// </summary> 
        public Guid CurrentCheckId
        {
            get { return _currentCheckId; }
            set { _currentCheckId = value; }
        }

        #endregion
    }
}


