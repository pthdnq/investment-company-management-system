using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TZMS.Web.CommonControls
{
    /// <summary>
    /// Flex附件上传控件,负责向Flex提供参数 
    /// </summary>
    public partial class MudFlexCtrl : UserControl
    {
        /// <summary>
        /// 页面加载
        /// </summary>
        /// <param name="sender">事件的发送者</param>
        /// <param name="e">向事件处理方法传递某些参数</param>
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 组装URL前缀路径
        /// </summary>
        /// <returns>string</returns>
        private static string GetUrl()
        {
            //获取当前URL
            //string strlen = HttpContext.Current.Request.UrlReferrer.ToString();
            //strlen = strlen.Split('/')[0] + "//" + strlen.Split('/')[2] + "/" + strlen.Split('/')[3];
            //return strlen;

            return System.Configuration.ConfigurationManager.AppSettings["WebPagesUrl"];
        }

        /// <summary>
        /// 上传下载的路径
        /// </summary>
        private string _url = GetUrl() + "CommonControls/UploadFile.aspx";
        //private string _url = System.Configuration.ConfigurationManager.AppSettings["WebPagesUrl"] + "/CommonPages/UploadFile.aspx";

        /// <summary>
        /// UploadFile.aspx的url
        /// </summary>
        public string Url
        {
            get
            {
                return this._url;
            }

            set
            {
                this._url = value;
            }
        }

        /// <summary>
        /// 下载的路径
        /// </summary>
        private string _downloadUrl = GetUrl() + "CommonControls/DownloadFile.aspx";
        //private string _downloadUrl = System.Configuration.ConfigurationManager.AppSettings["WebPagesUrl"] + "/CommonPages/DownloadFile.aspx";

        /// <summary>
        /// DownloadFile.aspx的url
        /// </summary>
        public string DownloadUrl
        {
            get
            {
                return this._downloadUrl;
            }

            set
            {
                this._downloadUrl = value;
            }
        }

        /// <summary>
        /// SystemName子系统名称
        /// </summary>
        private string _systemName = string.Empty;

        /// <summary>
        /// SystemName子系统名称
        /// </summary>
        public string SystemName
        {
            get
            {
                return this._systemName;
            }

            set
            {
                this._systemName = value;
            }
        }

        /// <summary>
        /// 附件所关联的记录的id
        /// </summary>
        private string _recordID = string.Empty;

        /// <summary>
        /// 附件所关联的记录的id
        /// </summary>
        public string RecordID
        {
            get
            {
                return this._recordID;
            }

            set
            {
                this._recordID = value;
            }
        }

        /// <summary>
        /// 子系统的子模块名称
        /// </summary>
        private string _attributeName = string.Empty;

        /// <summary>
        /// 子系统的子模块名称
        /// </summary>
        public string AttributeName
        {
            get
            {
                return this._attributeName;
            }

            set
            {
                this._attributeName = value;
            }
        }

        /// <summary>
        /// 上传文件类型限制
        /// 格式:"Word,*.doc|txt,*.txt"则限制为只能上传word和txt文件
        /// </summary>
        private string _fileType = string.Empty;

        /// <summary>
        /// 上传文件类型限制
        /// 格式:"Word,*.doc|txt,*.txt"则限制为只能上传word和txt文件
        /// </summary>
        public string FileType
        {
            get
            {
                return this._fileType;
            }

            set
            {
                this._fileType = value;
            }
        }

        /// <summary>
        /// 文件大小限制
        /// </summary>
        private string _fileSize = "10000000";

        /// <summary>
        /// 文件大小限制
        /// </summary>
        public string FileSize
        {
            get
            {
                return this._fileSize;
            }

            set
            {
                this._fileSize = value;
            }
        }

        /// <summary>
        /// 是否显示添加按钮,"是"赋值"true",否则为"false",默认为true
        /// </summary>
        private string _showAddBtn = "true";

        /// <summary>
        /// 是否显示添加按钮,"是"赋值"true",否则为"false",默认为true
        /// </summary>
        public string ShowAddBtn
        {
            get
            {
                return this._showAddBtn;
            }

            set
            {
                this._showAddBtn = value;
            }
        }

        /// <summary>
        /// 是否显示删除按钮,"是"赋值"true",否则为"false",默认为true
        /// </summary>
        private string _showDelBtn = "true";

        /// <summary>
        /// 是否显示删除按钮,"是"赋值"true",否则为"false",默认为true
        /// </summary>
        public string ShowDelBtn
        {
            get
            {
                return this._showDelBtn;
            }

            set
            {
                this._showDelBtn = value;
            }
        }
    }
}