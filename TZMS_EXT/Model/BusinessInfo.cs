//----------------------------------------------------------------------------------------------------
//程序名:	Business实体类
//功能:   定义了与 dbo.Business 表 对应的数据实体类
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
    /// Business实体类
    /// </summary>
    [Serializable]
    public class BusinessInfo : ACommonInfo
    {

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public BusinessInfo()
        {
            //todo
        }
        #endregion

        #region Field
        private Guid _objectId;
        private Guid _createrId;
        private string _createrName = DBEmptyString;
        private string _createrAccountNo = DBEmptyString;
        private string _createrDept = DBEmptyString;
        private DateTime _createTime = DBMAXDate;
        private Guid _signerId;
        private string _signerName = DBEmptyString;
        private DateTime _signTime = DBMAXDate;
        private string _companyName = DBEmptyString;
        private Decimal _registeredMoney = DBEmptyDecimal;
        private short _cZType = -1;
        private short _companyType = -1;
        private short _companyNameType = -1;
        private Decimal _sumMoney = DBEmptyDecimal;
        private Decimal _preMoney = DBEmptyDecimal;
        private short _preMoneyType = -1;
        private Decimal _balanceMoney = DBEmptyDecimal;
        private short _balanceMoneyType = -1;
        private string _contact = DBEmptyString;
        private string _contactPhoneNumber = DBEmptyString;
        private Decimal _costMoney = DBEmptyDecimal;
        private Decimal _otherMoney = DBEmptyDecimal;
        private string _otherMoneyExplain = DBEmptyString;
        private string _content = DBEmptyString;
        private string _other = DBEmptyString;
        private short _state = -1;
        private Guid _currentBusinessRecordId;
        private Guid _currentUserId;
        private bool _isDelete = false;
        private short _businessType = -1;
        private string _businessCells = DBEmptyString;
        private string _checkOther = DBEmptyString;
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
        /// CreaterID 
        /// </summary> 
        public Guid CreaterID
        {
            get { return _createrId; }
            set { _createrId = value; }
        }

        /// <summary>
        /// CreaterName 
        /// </summary> 
        public string CreaterName
        {
            get { return _createrName; }
            set { _createrName = value; }
        }

        /// <summary>
        /// CreaterAccountNo 
        /// </summary> 
        public string CreaterAccountNo
        {
            get { return _createrAccountNo; }
            set { _createrAccountNo = value; }
        }

        /// <summary>
        /// CreaterDept 
        /// </summary> 
        public string CreaterDept
        {
            get { return _createrDept; }
            set { _createrDept = value; }
        }

        /// <summary>
        /// CreateTime 
        /// </summary> 
        public DateTime CreateTime
        {
            get { return _createTime; }
            set { _createTime = value; }
        }

        /// <summary>
        /// SignerID 
        /// </summary> 
        public Guid SignerID
        {
            get { return _signerId; }
            set { _signerId = value; }
        }

        /// <summary>
        /// SignerName 
        /// </summary> 
        public string SignerName
        {
            get { return _signerName; }
            set { _signerName = value; }
        }

        /// <summary>
        /// SignTime 
        /// </summary> 
        public DateTime SignTime
        {
            get { return _signTime; }
            set { _signTime = value; }
        }

        /// <summary>
        /// CompanyName 
        /// </summary> 
        public string CompanyName
        {
            get { return _companyName; }
            set { _companyName = value; }
        }

        /// <summary>
        /// RegisteredMoney 
        /// </summary> 
        public Decimal RegisteredMoney
        {
            get { return GetDecimal(_registeredMoney); }
            set { _registeredMoney = value; }
        }

        /// <summary>
        /// CZType 
        /// </summary> 
        public short CZType
        {
            get { return _cZType; }
            set { _cZType = value; }
        }

        /// <summary>
        /// CompanyType 
        /// </summary> 
        public short CompanyType
        {
            get { return _companyType; }
            set { _companyType = value; }
        }

        /// <summary>
        /// CompanyNameType 
        /// </summary> 
        public short CompanyNameType
        {
            get { return _companyNameType; }
            set { _companyNameType = value; }
        }

        /// <summary>
        /// SumMoney 
        /// </summary> 
        public Decimal SumMoney
        {
            get { return GetDecimal(_sumMoney); }
            set { _sumMoney = value; }
        }

        /// <summary>
        /// PreMoney 
        /// </summary> 
        public Decimal PreMoney
        {
            get { return GetDecimal(_preMoney); }
            set { _preMoney = value; }
        }

        /// <summary>
        /// PreMoneyType 
        /// </summary> 
        public short PreMoneyType
        {
            get { return _preMoneyType; }
            set { _preMoneyType = value; }
        }

        /// <summary>
        /// BalanceMoney 
        /// </summary> 
        public Decimal BalanceMoney
        {
            get { return GetDecimal(_balanceMoney); }
            set { _balanceMoney = value; }
        }

        /// <summary>
        /// BalanceMoneyType 
        /// </summary> 
        public short BalanceMoneyType
        {
            get { return _balanceMoneyType; }
            set { _balanceMoneyType = value; }
        }

        /// <summary>
        /// Contact 
        /// </summary> 
        public string Contact
        {
            get { return _contact; }
            set { _contact = value; }
        }

        /// <summary>
        /// ContactPhoneNumber 
        /// </summary> 
        public string ContactPhoneNumber
        {
            get { return _contactPhoneNumber; }
            set { _contactPhoneNumber = value; }
        }

        /// <summary>
        /// CostMoney 
        /// </summary> 
        public Decimal CostMoney
        {
            get { return GetDecimal(_costMoney); }
            set { _costMoney = value; }
        }

        /// <summary>
        /// OtherMoney 
        /// </summary> 
        public Decimal OtherMoney
        {
            get { return GetDecimal(_otherMoney); }
            set { _otherMoney = value; }
        }

        /// <summary>
        /// OtherMoneyExplain 
        /// </summary> 
        public string OtherMoneyExplain
        {
            get { return _otherMoneyExplain; }
            set { _otherMoneyExplain = value; }
        }

        /// <summary>
        /// Content 
        /// </summary> 
        public string Content
        {
            get { return _content; }
            set { _content = value; }
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
        /// State 
        /// </summary> 
        public short State
        {
            get { return _state; }
            set { _state = value; }
        }

        /// <summary>
        /// CurrentBusinessRecordID 
        /// </summary> 
        public Guid CurrentBusinessRecordID
        {
            get { return _currentBusinessRecordId; }
            set { _currentBusinessRecordId = value; }
        }

        /// <summary>
        /// CurrentUserID 
        /// </summary> 
        public Guid CurrentUserID
        {
            get { return _currentUserId; }
            set { _currentUserId = value; }
        }

        /// <summary>
        /// IsDelete 
        /// </summary> 
        public bool IsDelete
        {
            get { return _isDelete; }
            set { _isDelete = value; }
        }

        /// <summary>
        /// BusinessType 
        /// </summary> 
        public short BusinessType
        {
            get { return _businessType; }
            set { _businessType = value; }
        }

        /// <summary>
        /// BusinessCells 
        /// </summary> 
        public string BusinessCells
        {
            get { return _businessCells; }
            set { _businessCells = value; }
        }

        /// <summary>
        /// CheckOther 
        /// </summary> 
        public string CheckOther
        {
            get { return _checkOther; }
            set { _checkOther = value; }
        }

        #endregion
    }
}


