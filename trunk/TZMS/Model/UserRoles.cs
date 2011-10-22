//----------------------------------------------------------------------------------------------------
//程序名:	UserRoles实体类
//功能:   定义了与 dbo.UserRoles 表 对应的数据实体类
//作者:  	xiguazerg
//时间:	2011-10-21 
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
    /// UserRoles实体类
    /// </summary>
    [Serializable]
    public class UserRoles
    {

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public UserRoles()
        {
            //todo
        }
        #endregion

        #region Field
        private Guid _userObjectId;
        private string _accountNo = string.Empty;
        private string _jobNo = string.Empty;
        private string _name = string.Empty;
        private string _roles = string.Empty;
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
        /// AccountNo 
        /// </summary> 
        public string AccountNo
        {
            get { return _accountNo; }
            set { _accountNo = value; }
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
        /// Name 
        /// </summary> 
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// Roles 
        /// </summary> 
        public string Roles
        {
            get { return _roles; }
            set { _roles = value; }
        }

        #endregion
    }
}


