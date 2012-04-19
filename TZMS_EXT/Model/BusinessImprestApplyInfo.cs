//----------------------------------------------------------------------------------------------------
//程序名:	BusinessImprestApply实体类
//功能:   定义了与 dbo.BusinessImprestApply 表 对应的数据实体类
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
    /// BusinessImprestApply实体类
    /// </summary>
    [Serializable]
    public class BusinessImprestApplyInfo : ACommonInfo
    {

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public BusinessImprestApplyInfo()
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
        private string _userDept = DBEmptyString;
        private Guid _businessId;
        private short _businessType = -1;
        private string _businessName = DBEmptyString;
        private Decimal _sumMoney;
        private string _applySument = DBEmptyString;
        private string _sument = DBEmptyString;
        private DateTime _applyTime = DBMAXDate;
        private Guid _approverId;
        private short _state = -1;
        private bool _isDelete = false;
        private string _sumMoneyFlag = DBEmptyString;
        #endregion

        #region Property

        public string SumMoneyFlag
        {
            get { return _sumMoneyFlag; }
            set { _sumMoneyFlag = value; }
        }

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
        /// UserAccountNo 
        /// </summary> 
        public string UserAccountNo
        {
            get { return _userAccountNo; }
            set { _userAccountNo = value; }
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
        /// BusinessID 
        /// </summary> 
        public Guid BusinessID
        {
            get { return _businessId; }
            set { _businessId = value; }
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
        /// BusinessName 
        /// </summary> 
        public string BusinessName
        {
            get { return _businessName; }
            set { _businessName = value; }
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
        /// ApplySument 
        /// </summary> 
        public string ApplySument
        {
            get { return _applySument; }
            set { _applySument = value; }
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
        /// ApplyTime 
        /// </summary> 
        public DateTime ApplyTime
        {
            get { return _applyTime; }
            set { _applyTime = value; }
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
        /// State 
        /// </summary> 
        public short State
        {
            get { return _state; }
            set { _state = value; }
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


