//----------------------------------------------------------------------------------------------------
//???:	ProxyAmountTemplateApprove???
//??:   ???? dbo.ProxyAmountTemplateApprove ? ????????
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
    /// ProxyAmountTemplateApprove???
    /// </summary>
    [Serializable]
    public class ProxyAmountTemplateApproveInfo : ACommonInfo
    {

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public ProxyAmountTemplateApproveInfo()
        {
            //todo
        }
        #endregion

        #region Field
        private Guid _objectId;
        private Guid _approverId;
        private string _approverName = DBEmptyString;
        private string _approverDept = DBEmptyString;
        private DateTime _approveDate = DBMAXDate;
        private short _approveState = -1;
        private short _result = -1;
        private string _sugest = DBEmptyString;
        private short _approveOp = -1;
        private Guid _applyId;
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
        /// ApproverID 
        /// </summary> 
        public Guid ApproverID
        {
            get { return _approverId; }
            set { _approverId = value; }
        }

        /// <summary>
        /// ApproverName 
        /// </summary> 
        public string ApproverName
        {
            get { return _approverName; }
            set { _approverName = value; }
        }

        /// <summary>
        /// ApproverDept 
        /// </summary> 
        public string ApproverDept
        {
            get { return _approverDept; }
            set { _approverDept = value; }
        }

        /// <summary>
        /// ApproveDate 
        /// </summary> 
        public DateTime ApproveDate
        {
            get { return _approveDate; }
            set { _approveDate = value; }
        }

        /// <summary>
        /// ApproveState 
        /// </summary> 
        public short ApproveState
        {
            get { return _approveState; }
            set { _approveState = value; }
        }

        /// <summary>
        /// Result 
        /// </summary> 
        public short Result
        {
            get { return _result; }
            set { _result = value; }
        }

        /// <summary>
        /// Sugest 
        /// </summary> 
        public string Sugest
        {
            get { return _sugest; }
            set { _sugest = value; }
        }

        /// <summary>
        /// ApproveOp 
        /// </summary> 
        public short ApproveOp
        {
            get { return _approveOp; }
            set { _approveOp = value; }
        }

        /// <summary>
        /// ApplyID 
        /// </summary> 
        public Guid ApplyID
        {
            get { return _applyId; }
            set { _applyId = value; }
        }

        #endregion
    }
}


