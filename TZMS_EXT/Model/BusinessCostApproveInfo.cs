//----------------------------------------------------------------------------------------------------
//???:	BusinessCostApprove???
//??:   ???? dbo.BusinessCostApprove ? ????????
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
    /// BusinessCostApprove???
    /// </summary>
    [Serializable]
    public class BusinessCostApproveInfo : ACommonInfo
    {

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public BusinessCostApproveInfo()
        {
            //todo
        }
        #endregion

        #region Field
        private Guid _objectId;
        private Guid _approverId;
        private string _approverName = DBEmptyString;
        private string _approverDept = DBEmptyString;
        private short _approveState = -1;
        private DateTime _approveTime = DBMAXDate;
        private short _approveOp = -1;
        private string _approverSugest = DBEmptyString;
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
        /// ApproveState 
        /// </summary> 
        public short ApproveState
        {
            get { return _approveState; }
            set { _approveState = value; }
        }

        /// <summary>
        /// ApproveTime 
        /// </summary> 
        public DateTime ApproveTime
        {
            get { return _approveTime; }
            set { _approveTime = value; }
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
        /// ApproverSugest 
        /// </summary> 
        public string ApproverSugest
        {
            get { return _approverSugest; }
            set { _approverSugest = value; }
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


