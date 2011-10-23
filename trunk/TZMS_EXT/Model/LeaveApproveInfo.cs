//----------------------------------------------------------------------------------------------------
//程序名:	LeaveApprove实体类
//功能:   定义了与 dbo.LeaveApprove 表 对应的数据实体类
//作者:  	shunlian
//时间:	2011-10-16 
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
    /// LeaveApprove实体类
    /// </summary>
    [Serializable]
    public class LeaveApproveInfo
    {

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public LeaveApproveInfo()
        {
            //todo
            _approveTime = DateTime.Parse("1900-1-1 12:00");
        }
        #endregion

        #region Field
        private Guid _objectId;
        private Guid _leaveId;
        private Guid _approverId;
        private string _approverName;
        private DateTime _approveTime;
        private short _approveResult;
        private string _approveComment = string.Empty;
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
        /// LeaveID 
        /// </summary> 
        public Guid LeaveId
        {
            get { return _leaveId; }
            set { _leaveId = value; }
        }

        /// <summary>
        /// ApproverID 
        /// </summary> 
        public Guid ApproverId
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
        /// ApproveTime 
        /// </summary> 
        public DateTime ApproveTime
        {
            get { return _approveTime; }
            set { _approveTime = value; }
        }

        /// <summary>
        /// ApproveResult 
        /// </summary> 
        public short ApproveResult
        {
            get { return _approveResult; }
            set { _approveResult = value; }
        }

        /// <summary>
        /// ApproveComment 
        /// </summary> 
        public string ApproveComment
        {
            get { return _approveComment; }
            set { _approveComment = value; }
        }

        #endregion
    }
}


