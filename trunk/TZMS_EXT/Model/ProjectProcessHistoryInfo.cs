//----------------------------------------------------------------------------------------------------
//程序名:	ProjectProcessHistory实体类
//功能:   定义了与 dbo.ProjectProcessHistory 表 对应的数据实体类
//作者:  	CodeSmith
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
    /// ProjectProcessHistory实体类
    /// </summary>
    [Serializable]
    public class ProjectProcessHistoryInfo : ACommonInfo
    {

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectProcessHistoryInfo()
        {
            //todo
        }
        #endregion

        #region Field
        private Guid _id;
        private Guid _forId;
        private string _operationDesc = DBEmptyString;
        private string _operationType = DBEmptyString;
        private DateTime _operationTime = DBEmptyDate;
        private string _operationerAccount = DBEmptyString;
        private string _operationerName = DBEmptyString;
        private string _remark = DBEmptyString;
        #endregion

        #region Property
        /// <summary>
        /// ID 
        /// </summary> 
        public Guid Id
        {
            get { return _id; }
            set { _id = value; }
        }

        /// <summary>
        /// ForID 
        /// </summary> 
        public Guid ForId
        {
            get { return _forId; }
            set { _forId = value; }
        }

        /// <summary>
        /// OperationDesc 
        /// </summary> 
        public string OperationDesc
        {
            get { return _operationDesc; }
            set { _operationDesc = value; }
        }

        /// <summary>
        /// OperationType 
        /// </summary> 
        public string OperationType
        {
            get { return _operationType; }
            set { _operationType = value; }
        }

        /// <summary>
        /// OperationTime 
        /// </summary> 
        public DateTime OperationTime
        {
            get { return _operationTime; }
            set { _operationTime = value; }
        }

        /// <summary>
        /// OperationerAccount 
        /// </summary> 
        public string OperationerAccount
        {
            get { return _operationerAccount; }
            set { _operationerAccount = value; }
        }

        /// <summary>
        /// OperationerName 
        /// </summary> 
        public string OperationerName
        {
            get { return _operationerName; }
            set { _operationerName = value; }
        }

        /// <summary>
        /// Remark 
        /// </summary> 
        public string Remark
        {
            get { return _remark; }
            set { _remark = value; }
        }

        #endregion
    }
}


