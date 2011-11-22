//----------------------------------------------------------------------------------------------------
//程序名:	WuZhi实体类
//功能:   定义了与 dbo.WuZhi 表 对应的数据实体类
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
    /// WuZhi实体类
    /// </summary>
    [Serializable]
    public class WuZhiInfo : ACommonInfo
    {

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public WuZhiInfo()
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
        private string _title = DBEmptyString;
        private string _sument = DBEmptyString;
        private string _other = DBEmptyString;
        private DateTime _applyTime = DBEmptyDate;
        private Guid _currentCheckerId;
        private short _state = DBEmptyShort;
        private bool _isdelete ;
        private short _type = DBEmptyShort;
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
        /// Title 
        /// </summary> 
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        /// <summary>
        /// Sument 
        /// </summary> 
        public string Sument
        {
            get { return _sument; }
            set { _sument = value; }
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
        /// ApplyTime 
        /// </summary> 
        public DateTime ApplyTime
        {
            get { return _applyTime; }
            set { _applyTime = value; }
        }

        /// <summary>
        /// CurrentCheckerID 
        /// </summary> 
        public Guid CurrentCheckerId
        {
            get { return _currentCheckerId; }
            set { _currentCheckerId = value; }
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
        /// type 
        /// </summary> 
        public short Type
        {
            get { return _type; }
            set { _type = value; }
        }

        #endregion
    }
}
