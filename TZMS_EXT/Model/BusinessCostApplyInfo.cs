//----------------------------------------------------------------------------------------------------
//???:	BusinessCostApply???
//??:   ???? dbo.BusinessCostApply ? ????????
//??:  	xiguazerg
//??:	2010-10-25 
//----------------------------------------------------------------------------------------------------
//????:
//??		         ???		     ????
//----------------------------------------------------------------------------------------------------
//----------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

namespace com.TZMS.Model
{
    /// <summary>
    /// BusinessCostApply???
    /// </summary>
    [Serializable]
    public class BusinessCostApplyInfo : ACommonInfo
    {

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public BusinessCostApplyInfo()
        {
            //todo
        }
        #endregion

        #region Field
        private Guid _objectId;
        private Guid _userId;
        private string _userName = DBEmptyString;
        private string _userDept = DBEmptyString;
        private string _userAccountNo = DBEmptyString;
        private DateTime _applyTime = DBMAXDate;
        private Guid _businessId;
        private string _companyName = DBEmptyString;
        private short _costType = -1;
        private Decimal _applyMoney;
        private Decimal _actualMoney;
        private short _payType;
        private DateTime _payDate = DBMAXDate;
        private string _other = DBEmptyString;
        private short _state = -1;
        private Guid _approverId;
        private bool _isDelete = false;
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
        /// BusinessID 
        /// </summary> 
        public Guid UserID
        {
            get { return _userId; }
            set { _userId = value; }
        }

        /// <summary>
        /// BusinessID 
        /// </summary> 
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        /// <summary>
        /// BusinessID 
        /// </summary> 
        public string UserDept
        {
            get { return _userDept; }
            set { _userDept = value; }
        }

        /// <summary>
        /// BusinessID 
        /// </summary> 
        public string UserAccountNo
        {
            get { return _userAccountNo; }
            set { _userAccountNo = value; }
        }

        /// <summary>
        /// BusinessID 
        /// </summary> 
        public DateTime ApplyTime
        {
            get { return _applyTime; }
            set { _applyTime = value; }
        }

        /// <summary>
        /// BusinessID 
        /// </summary> 
        public Guid BusinessID
        {
            get { return _businessId; }
            set { _businessId = value; }
        }

        /// <summary>
        /// BusinessID 
        /// </summary> 
        public string CompanyName
        {
            get { return _companyName; }
            set { _companyName = value; }
        }

        /// <summary>
        /// CostType 
        /// </summary> 
        public short CostType
        {
            get { return _costType; }
            set { _costType = value; }
        }

        /// <summary>
        /// ApplyMoney 
        /// </summary> 
        public Decimal ApplyMoney
        {
            get { return GetDecimal(_applyMoney); }
            set { _applyMoney = value; }
        }

        /// <summary>
        /// ActualMoney 
        /// </summary> 
        public Decimal ActualMoney
        {
            get { return GetDecimal(_actualMoney); }
            set { _actualMoney = value; }
        }

        /// <summary>
        /// PayType 
        /// </summary> 
        public short PayType
        {
            get { return _payType; }
            set { _payType = value; }
        }

        /// <summary>
        /// PayDate 
        /// </summary> 
        public DateTime PayDate
        {
            get { return _payDate; }
            set { _payDate = value; }
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
        /// ApproverID 
        /// </summary> 
        public Guid ApproverID
        {
            get { return _approverId; }
            set { _approverId = value; }
        }

        /// <summary>
        /// IsDelete 
        /// </summary> 
        public bool IsDelete
        {
            get { return _isDelete; }
            set { _isDelete = value; }
        }

        #endregion
    }
}


