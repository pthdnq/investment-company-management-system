//----------------------------------------------------------------------------------------------------
//程序名:	WuZhiRecord实体类
//功能:   定义了与 dbo.WuZhiRecord 表 对应的数据实体类
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
    /// WuZhiRecord实体类
    /// </summary>
    [Serializable]
    public class WuZhiRecordInfo : ACommonInfo
    {

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public WuZhiRecordInfo()
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
        private Guid _wuzhiObjectId;
        private string _title = DBEmptyString;
        private string _record = DBEmptyString;
        private Guid _recorderId;
        private string _recorderName = DBEmptyString;
        private bool _isdelete;
        private DateTime _recordTime = DBEmptyDate;
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
        /// WuzhiObjectID 
        /// </summary> 
        public Guid WuzhiObjectId
        {
            get { return _wuzhiObjectId; }
            set { _wuzhiObjectId = value; }
        }

        /// <summary>
        /// Title 
        /// </summary> 
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        /// <summary>
        /// Record 
        /// </summary> 
        public string Record
        {
            get { return _record; }
            set { _record = value; }
        }

        /// <summary>
        /// RecorderID 
        /// </summary> 
        public Guid RecorderId
        {
            get { return _recorderId; }
            set { _recorderId = value; }
        }

        /// <summary>
        /// RecorderName 
        /// </summary> 
        public string RecorderName
        {
            get { return _recorderName; }
            set { _recorderName = value; }
        }

        /// <summary>
        /// Isdelete 
        /// </summary> 
        public bool Isdelete
        {
            get { return _isdelete; }
            set { _isdelete = value; }
        }

        public DateTime RecordTime
        {
            get { return _recordTime; }
            set { _recordTime = value; }
        }

        #endregion
    }
}