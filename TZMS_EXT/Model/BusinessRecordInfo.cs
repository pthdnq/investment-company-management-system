//----------------------------------------------------------------------------------------------------
//程序名:	BusinessRecord实体类
//功能:   定义了与 dbo.BusinessRecord 表 对应的数据实体类
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
    /// BusinessRecord实体类
    /// </summary>
    [Serializable]
    public class BusinessRecordInfo : ACommonInfo
    {

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public BusinessRecordInfo()
        {
            //todo
        }
        #endregion

        #region Field
        private Guid _objectId;
        private Guid _checkerId;
        private string _checkerName = DBEmptyString;
        private string _checkrDept = DBEmptyString;
        private DateTime _checkDateTime = DBMAXDate;
        private short _state = -1;
        private int _currentBusiness;
        private Decimal _costMoney = DBEmptyDecimal;
        private Decimal _otherMoney = DBEmptyDecimal;
        private string _explain = DBEmptyString;
        private Guid _businessId;
        private string _costMoneyFlag = DBEmptyString;
        private string _otherMoneyFlag = DBEmptyString;
     
        #endregion

        #region Property

        public string CostMoneyFlag
        {
            get { return _costMoneyFlag; }
            set { _costMoneyFlag = value; }
        }

        public string OtherMoneyFlag
        {
            get { return _otherMoneyFlag; }
            set { _otherMoneyFlag = value; }
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
        /// CheckerID 
        /// </summary> 
        public Guid CheckerID
        {
            get { return _checkerId; }
            set { _checkerId = value; }
        }

        /// <summary>
        /// CheckerName 
        /// </summary> 
        public string CheckerName
        {
            get { return _checkerName; }
            set { _checkerName = value; }
        }

        /// <summary>
        /// CheckrDept 
        /// </summary> 
        public string CheckrDept
        {
            get { return _checkrDept; }
            set { _checkrDept = value; }
        }

        /// <summary>
        /// CheckDateTime 
        /// </summary> 
        public DateTime CheckDateTime
        {
            get { return _checkDateTime; }
            set { _checkDateTime = value; }
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
        /// CurrentBusiness 
        /// </summary> 
        public int CurrentBusiness
        {
            get { return _currentBusiness; }
            set { _currentBusiness = value; }
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
        /// Explain 
        /// </summary> 
        public string Explain
        {
            get { return _explain; }
            set { _explain = value; }
        }

        /// <summary>
        /// BusinessID 
        /// </summary> 
        public Guid BusinessID
        {
            get { return _businessId; }
            set { _businessId = value; }
        }

        #endregion
    }
}


