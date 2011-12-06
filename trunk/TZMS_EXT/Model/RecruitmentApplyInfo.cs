//----------------------------------------------------------------------------------------------------
//程序名:	RecruitmentApply实体类
//功能:   定义了与 dbo.RecruitmentApply 表 对应的数据实体类
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
    /// RecruitmentApply实体类
    /// </summary>
    [Serializable]
    public class RecruitmentApplyInfo : ACommonInfo
    {

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public RecruitmentApplyInfo()
        {
            //todo
        }
        #endregion

        #region Field
        private Guid _objectId;
        private Guid _userId;
        private string _name = DBEmptyString;
        private string _dept = DBEmptyString;
        private string _title = DBEmptyString;
        private string _content = DBEmptyString;
        private short _state = DBEmptyShort;
        private Guid _approveId;
        private DateTime _applyTime = DBMAXDate;
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
        /// UserID 
        /// </summary> 
        public Guid UserID
        {
            get { return _userId; }
            set { _userId = value; }
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
        /// Title 
        /// </summary> 
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        /// <summary>
        /// Content 
        /// </summary> 
        public string Content
        {
            get { return _content; }
            set { _content = value; }
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
        /// ApproveID 
        /// </summary> 
        public Guid ApproveID
        {
            get { return _approveId; }
            set { _approveId = value; }
        }

        /// <summary>
        /// ApplyTime 
        /// </summary> 
        public DateTime ApplyTime
        {
            get { return _applyTime; }
            set { _applyTime = value; }
        }

        #endregion
    }
}


