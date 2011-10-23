//----------------------------------------------------------------------------------------------------
//程序名:	LeaveInfo实体类
//功能:   定义了与 dbo.LeaveInfo 表 对应的数据实体类
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
    /// LeaveInfo实体类
    /// </summary>
    [Serializable]
    public class LeaveInfo
    {

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public LeaveInfo()
        {
            //todo
            _startTime = DateTime.Parse("1900-1-1 12:00");
            _stopTime = DateTime.Parse("1900-1-1 12:00");
        }
        #endregion

        #region Field
        private Guid _objectId;
        private string _jobNo = string.Empty;
        private string _accountNo = string.Empty;
        private string _name = string.Empty;
        private string _dept = string.Empty;
        private string _type = string.Empty;
        private DateTime _startTime;
        private DateTime _stopTime;
        private string _reason = string.Empty;
        private DateTime _writeTime;
        private short _state = 99;
        private Guid _approverId;
        private bool _isDelete = true;
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
        /// JobNo 
        /// </summary> 
        public string JobNo
        {
            get { return _jobNo; }
            set { _jobNo = value; }
        }

        /// <summary>
        /// AccountNo 
        /// </summary> 
        public string AccountNo
        {
            get { return _accountNo; }
            set { _accountNo = value; }
        }

        /// <summary>
        /// Name 
        /// </summary> 
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// Dept 
        /// </summary> 
        public string Dept
        {
            get { return _dept; }
            set { _dept = value; }
        }

        /// <summary>
        /// Type 
        /// </summary> 
        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        /// <summary>
        /// StartTime 
        /// </summary> 
        public DateTime StartTime
        {
            get { return _startTime; }
            set { _startTime = value; }
        }

        /// <summary>
        /// StopTime 
        /// </summary> 
        public DateTime StopTime
        {
            get { return _stopTime; }
            set { _stopTime = value; }
        }

        /// <summary>
        /// Reason 
        /// </summary> 
        public string Reason
        {
            get { return _reason; }
            set { _reason = value; }
        }

        /// <summary>
        /// WriteTime 
        /// </summary> 
        public DateTime WriteTime
        {
            get { return _writeTime; }
            set { _writeTime = value; }
        }

        /// <summary>
        /// state 
        /// </summary> 
        public short State
        {
            get { return _state; }
            set { _state = value; }
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


