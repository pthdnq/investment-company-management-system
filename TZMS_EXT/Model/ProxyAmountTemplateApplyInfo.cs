//----------------------------------------------------------------------------------------------------
//???:	ProxyAmountTemplateApply???
//??:   ???? dbo.ProxyAmountTemplateApply ? ????????
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
    /// ProxyAmountTemplateApply???
    /// </summary>
    [Serializable]
    public class ProxyAmountTemplateApplyInfo : ACommonInfo
    {

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public ProxyAmountTemplateApplyInfo()
        {
            //todo
        }
        #endregion

        #region Field
        private Guid _objectId;
        private Guid _proxyAmountUnitId;
        private string _proxyAmountUnitName = DBEmptyString;
        private Guid _proxyAmounterId;
        private string _proxyAmounterName = DBEmptyString;
        private string _cNMoney = DBEmptyString;
        private Decimal _eNMoney;
        private string _sument = DBEmptyString;
        private string _collectMethod = DBEmptyString;
        private string _collectUnitName = DBEmptyString;
        private DateTime _applyTime = DBMAXDate;
        private short _state = -1;
        private Guid _approverId;
        private short _templateType = 0;
        private bool _isDelete = false;
        private string _eNMoneyFlag = DBEmptyString;

        public string ENMoneyFlag
        {
            get { return _eNMoneyFlag; }
            set { _eNMoneyFlag = value; }
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
        /// ProxyAmountUnitID 
        /// </summary> 
        public Guid ProxyAmountUnitID
        {
            get { return _proxyAmountUnitId; }
            set { _proxyAmountUnitId = value; }
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
        /// CollectMethod 
        /// </summary> 
        public string CollectMethod
        {
            get { return _collectMethod; }
            set { _collectMethod = value; }
        }

        /// <summary>
        /// CollectUnitName 
        /// </summary> 
        public string CollectUnitName
        {
            get { return _collectUnitName; }
            set { _collectUnitName = value; }
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
        /// TemplateType 
        /// </summary> 
        public short TemplateType
        {
            get { return _templateType; }
            set { _templateType = value; }
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


