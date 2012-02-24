using System;
using System.Collections.Generic;
using System.Text;

namespace com.TZMS.Model
{
/// <summary>
    /// ProxyAccountingApply实体类
    /// </summary>
	[Serializable]
    public class ProxyAccountingApplyInfo  : ACommonInfo
	{	 
		
		#region Constructor
		
        /// <summary>
        /// Constructor
        /// </summary>
        public ProxyAccountingApplyInfo()
        {
			//todo
        }
        #endregion 
		
		#region Field
		private Guid _objectId;
		private Guid _payUnitId;
		private string _cNMoney = DBEmptyString;
		private Decimal _eNMoney = DBEmptyDecimal;
		private string _sument = DBEmptyString;
		private DateTime _openingDate = DBEmptyDate;
		private string _collectMethod = DBEmptyString;
		private Guid _collectUnitId;
		private Guid _proxyAccountingId;
		private string _proxyAccountingName = DBEmptyString;
		private Guid _collecterId;
		private string _collecterName = DBEmptyString;
		private short _state = DBEmptyShort;
		private Guid _approverId;
		private bool _isDelete;
        private string _payUnitName = DBEmptyString;
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
        /// PayUnitID 
        /// </summary> 
		public Guid PayUnitID
		{
			get { return _payUnitId; }
			set { _payUnitId = value; }
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
        /// ProxyAccountingID 
        /// </summary> 
		public Guid ProxyAccountingID
		{
			get { return _proxyAccountingId; }
			set { _proxyAccountingId = value; }
		}

		/// <summary>
        /// ProxyAccountingName 
        /// </summary> 
		public string ProxyAccountingName
		{
			get { return _proxyAccountingName; }
			set { _proxyAccountingName = value; }
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

        /// <summary>
        /// PayUnitName 
        /// </summary> 
        public string PayUnitName
        {
            get { return _payUnitName; }
            set { _payUnitName = value; }
        }

		#endregion
	}
}
