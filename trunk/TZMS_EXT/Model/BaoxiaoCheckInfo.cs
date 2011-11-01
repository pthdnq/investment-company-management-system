//----------------------------------------------------------------------------------------------------
//程序名:	BaoxiaoCheck实体类
//功能:   定义了与 dbo.BaoxiaoCheck 表 对应的数据实体类
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
    /// BaoxiaoCheck实体类
    /// </summary>
    [Serializable]
    public class BaoxiaoCheckInfo : ACommonInfo
    {

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public BaoxiaoCheckInfo()
        {
            //todo
        }
        #endregion

        #region Field
        private Guid _objectId;
        private Guid _checkerId;
        private string _checkerName = DBEmptyString;
        private string _checkrDept = DBEmptyString;
        private DateTime _checkDateTime = DBEmptyDate;
        private short _checkstate = DBEmptyShort;
        private string _result = DBEmptyString;
        private string _checkSugest = DBEmptyString;
        private string _checkOp = DBEmptyString;
        private Guid _applytId;
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
        /// CheckerID 
        /// </summary> 
        public Guid CheckerId
        {
            get { return _checkerId; }
            set { _checkerId = value; }
        }

        /// <summary>
        /// CheckerName 
        /// </summary> 
        public string CheckerName
        {
            get { return _checkerName; }
            set { _checkerName = value; }
        }

        /// <summary>
        /// CheckrDept 
        /// </summary> 
        public string CheckrDept
        {
            get { return _checkrDept; }
            set { _checkrDept = value; }
        }

        /// <summary>
        /// CheckDateTime 
        /// </summary> 
        public DateTime CheckDateTime
        {
            get { return _checkDateTime; }
            set { _checkDateTime = value; }
        }

        /// <summary>
        /// Checkstate 
        /// </summary> 
        public short Checkstate
        {
            get { return _checkstate; }
            set { _checkstate = value; }
        }

        /// <summary>
        /// Result 
        /// </summary> 
        public string Result
        {
            get { return _result; }
            set { _result = value; }
        }

        /// <summary>
        /// CheckSugest 
        /// </summary> 
        public string CheckSugest
        {
            get { return _checkSugest; }
            set { _checkSugest = value; }
        }

        /// <summary>
        /// CheckOp 
        /// </summary> 
        public string CheckOp
        {
            get { return _checkOp; }
            set { _checkOp = value; }
        }

        /// <summary>
        /// ApplytId
        /// </summary>
        public Guid ApplytId
        {
            get { return _applytId; }
            set { _applytId = value; }
        }

        #endregion
    }
}


