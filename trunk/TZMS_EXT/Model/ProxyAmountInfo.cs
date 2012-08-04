//----------------------------------------------------------------------------------------------------
//???:	ProxyAmount???
//??:   ???? dbo.ProxyAmount ? ????????
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
    /// ProxyAmount???
    /// </summary>
    [Serializable]
    public class ProxyAmountInfo : ACommonInfo
    {

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public ProxyAmountInfo()
        {
            //todo
        }
        #endregion

        #region Field
        private Guid _objectId;
        private Guid _createrId;
        private string _createName = DBEmptyString;
        private DateTime _createTime = DBMAXDate;
        private Guid _proxyAmountId;
        private string _proxyAmountUnitName = DBEmptyString;
        private Guid _proxyAmounterId;
        private string _proxyAmounterName = DBEmptyString;
        private string _cNMoney = DBEmptyString;
        private Decimal _eNMoney;
        private string _sument = DBEmptyString;
        private DateTime _openingDate = DBMAXDate;
        private string _collectMethod;
        private Guid _collectUnitId;
        private Guid _collecterId;
        private string _collecterName = DBEmptyString;
        private short _state = -1;
        private bool _isDelete = false;
        private short _proxyAmountType;
        private string _eNMoneyFlag = DBEmptyString;

        public string ENMoneyFlag
        {
            get { return _eNMoneyFlag; }
            set { _eNMoneyFlag = value; }
        }
        #endregion
        #region 扩展字段（只读）
        public string ENMoneyEx
        {
            get { return ENMoneyFlag + ENMoney.ToString(); }
        }

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
        /// CreateName 
        /// </summary> 
        public string CreateName
        {
            get { return _createName; }
            set { _createName = value; }
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
        /// ProxyAmountID 
        /// </summary> 
        public Guid ProxyAmountID
        {
            get { return _proxyAmountId; }
            set { _proxyAmountId = value; }
        }

        /// <summary>
        /// ProxyAmountUnitName 
        /// </summary> 
        public string ProxyAmountUnitName
        {
            get { return _proxyAmountUnitName; }
            set { _proxyAmountUnitName = value; }
        }

        /// <summary>
        /// ProxyAmounterID 
        /// </summary> 
        public Guid ProxyAmounterID
        {
            get { return _proxyAmounterId; }
            set { _proxyAmounterId = value; }
        }

        /// <summary>
        /// ProxyAmounterName 
        /// </summary> 
        public string ProxyAmounterName
        {
            get { return _proxyAmounterName; }
            set { _proxyAmounterName = value; }
        }

        /// <summary>
        /// CNMoney 
        /// </summary> 
        public string CNMoney
        {
            get { return _cNMoney; }
            set { _cNMoney = value; }
        }

        /// <summary>
        /// ENMoney 
        /// </summary> 
        public Decimal ENMoney
        {
            get { return GetDecimal(_eNMoney); }
            set { _eNMoney = value; }
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
        /// OpeningDate 
        /// </summary> 
        public DateTime OpeningDate
        {
            get { return _openingDate; }
            set { _openingDate = value; }
        }

        /// <summary>
        /// CollectMethod 
        /// </summary> 
        public string CollectMethod
        {
            get { return _collectMethod; }
            set { _collectMethod = value; }
        }

        /// <summary>
        /// CollectUnitID 
        /// </summary> 
        public Guid CollectUnitID
        {
            get { return _collectUnitId; }
            set { _collectUnitId = value; }
        }

        /// <summary>
        /// CollecterID 
        /// </summary> 
        public Guid CollecterID
        {
            get { return _collecterId; }
            set { _collecterId = value; }
        }

        /// <summary>
        /// CollecterName 
        /// </summary> 
        public string CollecterName
        {
            get { return _collecterName; }
            set { _collecterName = value; }
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

        public short ProxyAmountType
        {
            get { return _proxyAmountType; }
            set { _proxyAmountType = value; }
        }

        #endregion
    }
}