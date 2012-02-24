//----------------------------------------------------------------------------------------------------
//???:	CashFlowSetter???
//??:   ???? dbo.CashFlowSetter ? ????????
//??:  	Model
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
    /// CashFlowSetter???
    /// </summary>
    [Serializable]
    public class CashFlowSetterInfo : ACommonInfo
    {

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public CashFlowSetterInfo()
        {
            //todo
        }
        #endregion

        #region Field
        private Guid _objectId;
        private Decimal _originalAmount = DBEmptyDecimal;
        private int _status = DBEmptyTinyInt;
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
        /// OriginalAmount 
        /// </summary> 
        public Decimal OriginalAmount
        {
            get { return GetDecimal(_originalAmount); }
            set { _originalAmount = value; }
        }

        /// <summary>
        /// Status 
        /// </summary> 
        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }

        #endregion
    }
}


