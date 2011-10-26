//----------------------------------------------------------------------------------------------------
//程序名:	ComChecker实体类
//功能:   定义了与 dbo.ComChecker 表 对应的数据实体类
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
    /// ComChecker实体
    /// </summary>
    [Serializable]
    public class ComCheckerInfo :ACommonInfo
    {

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public ComCheckerInfo()
        {
            //todo
        }
        #endregion

        #region Field
        private Guid _userObjectId;
        private string _userName;
        private Guid _checkerObjectId;
        private string _checkerName;
        #endregion

        #region Property
        /// <summary>
        /// UserObjectID 
        /// </summary> 
        public Guid UserObjectId
        {
            get { return _userObjectId; }
            set { _userObjectId = value; }
        }

        /// <summary>
        /// UserName 
        /// </summary> 
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        /// <summary>
        /// CheckerObjectID 
        /// </summary> 
        public Guid CheckerObjectId
        {
            get { return _checkerObjectId; }
            set { _checkerObjectId = value; }
        }

        /// <summary>
        /// CheckerName 
        /// </summary> 
        public string CheckerName
        {
            get { return _checkerName; }
            set { _checkerName = value; }
        }

        #endregion
    }
}
