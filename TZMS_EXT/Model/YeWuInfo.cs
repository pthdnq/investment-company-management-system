//----------------------------------------------------------------------------------------------------
//程序名:	YeWu实体类
//功能:   定义了与 dbo.YeWu 表 对应的数据实体类
//作者:  	omit
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
    /// YeWu实体类
    /// </summary>
    [Serializable]
    public class YeWuInfo : ACommonInfo
    {

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public YeWuInfo()
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
        private Guid _currentCheckerId;
        private short _currentOp;
        private short _state = DBEmptyShort;
        private bool _isdelete;
        private short _type = DBEmptyShort;
        private DateTime _signDate = DBEmptyDate;
        private string _celslOfYeWu = DBEmptyString;
        #endregion

        #region Property

        /// <summary>
        /// CelslOfYeWu(该业务包含那些操作)
        /// </summary>
        public string CelslOfYeWu
        {
            get { return _celslOfYeWu; }
            set { _celslOfYeWu = value; }
        }

        /// <summary>
        /// SignDate
        /// </summary>
        public DateTime SignDate
        {
            get { return _signDate; }
            set { _signDate = value; }
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
        /// CurrentCheckerID 
        /// </summary> 
        public Guid CurrentCheckerId
        {
            get { return _currentCheckerId; }
            set { _currentCheckerId = value; }
        }

        /// <summary>
        /// CurrentOp 
        /// </summary> 
        public short CurrentOp
        {
            get { return _currentOp; }
            set { _currentOp = value; }
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


