//----------------------------------------------------------------------------------------------------
//程序名:	ChuRu实体类
//功能:   定义了与 dbo.ChuRu 表 对应的数据实体类
//作者:  	xiguazerg
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
    /// ChuRu实体类
    /// </summary>
    [Serializable]
    public class ChuRuInfo : ACommonInfo
    {

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public ChuRuInfo()
        {
            //todo
        }
        #endregion

        #region Field
        private Guid _objectId;
        private Guid _userId;
        private string _userName = DBEmptyString;
        private string _userJobNo = DBEmptyString;
        private string _userDept = DBEmptyString;
        private DateTime _outTime = DBMAXDate;
        private string _outReason = DBEmptyString;
        private DateTime _inTime = DBMAXDate;
        private Guid _inUserId;
        private string _inUserName = DBEmptyString;
        private string _inUserJobNo = DBEmptyString;
        private string _inUserDept = DBEmptyString;
        private short _state;
        #endregion

        #region Property
        /// <summary>
        /// ObjectID 
        /// </summary> 
        public Guid ObjectID
        {
            get { return _objectId; }
            set { _objectId = value; }
        }

        /// <summary>
        /// UserID 
        /// </summary> 
        public Guid UserID
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
        /// UserDept 
        /// </summary> 
        public string UserDept
        {
            get { return _userDept; }
            set { _userDept = value; }
        }

        /// <summary>
        /// OutTime 
        /// </summary> 
        public DateTime OutTime
        {
            get { return _outTime; }
            set { _outTime = value; }
        }

        /// <summary>
        /// OutReason 
        /// </summary> 
        public string OutReason
        {
            get { return _outReason; }
            set { _outReason = value; }
        }

        /// <summary>
        /// InTime 
        /// </summary> 
        public DateTime InTime
        {
            get { return _inTime; }
            set { _inTime = value; }
        }

        /// <summary>
        /// InUserID 
        /// </summary> 
        public Guid InUserID
        {
            get { return _inUserId; }
            set { _inUserId = value; }
        }

        /// <summary>
        /// InUserName 
        /// </summary> 
        public string InUserName
        {
            get { return _inUserName; }
            set { _inUserName = value; }
        }

        /// <summary>
        /// InUserJobNo 
        /// </summary> 
        public string InUserJobNo
        {
            get { return _inUserJobNo; }
            set { _inUserJobNo = value; }
        }

        /// <summary>
        /// InUserDept 
        /// </summary> 
        public string InUserDept
        {
            get { return _inUserDept; }
            set { _inUserDept = value; }
        }

        /// <summary>
        /// State 
        /// </summary> 
        public short State
        {
            get { return _state; }
            set { _state = value; }
        }

        #endregion
    }
}


