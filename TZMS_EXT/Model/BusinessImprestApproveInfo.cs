//----------------------------------------------------------------------------------------------------
//程序名:	BusinessImprestApprove实体类
//功能:   定义了与 dbo.BusinessImprestApprove 表 对应的数据实体类
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
    /// BusinessImprestApprove实体类
    /// </summary>
    [Serializable]
    public class BusinessImprestApproveInfo : ACommonInfo
    {

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public BusinessImprestApproveInfo()
        {
            //todo
        }
        #endregion

        #region Field
        private Guid _objectId;
        private Guid _approverId;
        private string _approverName = DBEmptyString;
        private string _approverDept = DBEmptyString;
        private DateTime _approveTime;
        private short _approveState = -1;
        private short _result = -1;
        private string _approveSugest = DBEmptyString;
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
        /// ApproveTime 
        /// </summary> 
        public DateTime ApproveTime
        {
            get { return _approveTime; }
            set { _approveTime = value; }
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
        /// ApproveSugest 
        /// </summary> 
        public string ApproveSugest
        {
            get { return _approveSugest; }
            set { _approveSugest = value; }
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


