//----------------------------------------------------------------------------------------------------
//程序名:	Baoxiao实体类
//功能:   定义了与 dbo.Baoxiao 表 对应的数据实体类
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
    /// Baoxiao实体类
    /// </summary>
    [Serializable]
    public class BaoxiaoInfo : ACommonInfo
    {

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public BaoxiaoInfo()
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
        private string _sument = DBEmptyString;
        private Decimal _money = DBEmptyDecimal;
        private string _other = DBEmptyString;
        private DateTime _applyTime;
        private short _state = DBEmptyShort;
        private bool _isdelete;
        private string _tellPhone = DBEmptyString;
        private Guid _checkId;
        private DateTime _startTime;
        private DateTime _endTime;
        #endregion

        #region Property

        /// <summary>
        /// TellPhone
        /// </summary>
        public string TellPhone
        {
            get { return _tellPhone; }
            set { _tellPhone = value; }
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
        /// Sument 
        /// </summary> 
        public string Sument
        {
            get { return _sument; }
            set { _sument = value; }
        }

        /// <summary>
        /// Money 
        /// </summary> 
        public Decimal Money
        {
            get { return GetDecimal(_money); }
            set { _money = value; }
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
        /// UserID 
        /// </summary> 
        public Guid CheckerId
        {
            get { return _checkId; }
            set { _checkId = value; }
        }

        /// <summary>
        /// StartTime 
        /// </summary> 
        public DateTime StartTime
        {
            get { return _startTime; }
            set { _startTime = value; }
        }

        /// <summary>
        /// EndTime 
        /// </summary> 
        public DateTime EndTime
        {
            get { return _endTime; }
            set { _endTime = value; }
        }
        #endregion
    }
}


