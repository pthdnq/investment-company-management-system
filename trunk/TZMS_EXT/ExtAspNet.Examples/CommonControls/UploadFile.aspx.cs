using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using Com.iFlytek.Utility;
using System.Xml;
using Com.iFlytek.OA.MUDCommon;
using System.Web.Configuration;

namespace TZMS.Web.CommonControls
{
    /// <summary>
    /// 上传文件
    /// </summary>
    public partial class UploadFile : Page
    {
        /// <summary>
        /// 设置的最大上传文件限制
        /// </summary>
        private static int maxFileSize = Convert.ToInt32(WebConfigurationManager.AppSettings["UploadFileSize"].ToString()) * 1024;
        
        /// <summary>
        /// 页面加载
        /// </summary>
        /// <param name="sender">事件的发送者</param>
        /// <param name="e">向事件处理方法传递某些参数</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            string errorInfo = string.Empty;
            try
            {
                string strUrl = this.Request.Url.ToString();
                //获取操作类型
                int operateType = Int32.Parse(this.Request.Params["OperateType"].ToString());

                //根据操作类型进行相应的操作
                switch (operateType)
                {
                    case 0:
                        //上传新文件
                        this.UploadMUDFile();
                        break;
                    case 1:
                        //下载文件
                        this.DownLoadMUDFile();
                        break;
                    case 2:
                        //删除文件 标记删除
                        this.DeleteMUDFile();
                        break;
                    case 3:
                        //获得文件摘要信息
                        this.GetMUDFileInfo();
                        break;
                    default:
                        //返回没有找到错误类型
                        break;
                }
            }
            catch (Exception ex)
            {
                errorInfo = "文件操作异常,请重试!";
                //TxtLogger.DumpException(ex);
                this.ReturnResultInfo(false, errorInfo);
            }
        }

        /// <summary>
        /// 获得文件的摘要信息
        /// </summary>
        private void GetMUDFileInfo()
        {
            string errorInfo = string.Empty;
            try
            {
                string strSystemName = string.Empty;
                string strRecordID = string.Empty;
                string strAttributeName = string.Empty;
                string selectStr = string.Empty;
                MUDFilesCtrl ctrl = new MUDFilesCtrl();
                ArrayList fileList;
                strSystemName = this.Request.Params["SystemName"].ToString();
                strRecordID = this.Request.Params["RecordID"].ToString();
                strAttributeName = this.Request.Params["AttributeName"].ToString();
                selectStr = "SystemName='" + strSystemName
                    + "' and RecordID='" + strRecordID
                    + "' and AttributeName='" + strAttributeName
                    + "' and TempState<>'2' ";
                fileList = ctrl.SelectAsArrayList(string.Empty, selectStr);
                XmlHelper xmldoc = new XmlHelper();
                xmldoc.LoadXML("<FilesActiveX/>", XmlHelper.LoadType.FromString);
                xmldoc.CreateXmlDeclaration("1.0", "GB2312", string.Empty);
                xmldoc.CreateNodeElement(xmldoc.RootNode, "ResultType", "0");
                xmldoc.CreateNodeElement(xmldoc.RootNode, "ResultInfo", "操作成功");
                foreach (MUDFilesInfo info in fileList)
                {
                    XmlNode file = xmldoc.CreateNodeElement(xmldoc.RootNode, "File", string.Empty);
                    xmldoc.CreateNodeElement(file, "SystemName", info.SystemName);
                    xmldoc.CreateNodeElement(file, "RecordID", info.RecordID);
                    xmldoc.CreateNodeElement(file, "AttributeName", info.AttributeName);
                    xmldoc.CreateNodeElement(file, "FileDisplayName", Server.UrlDecode(info.FileDisplayName));
                    xmldoc.CreateNodeElement(file, "FileServerName", info.FileServerName);
                    xmldoc.CreateNodeElement(file, "FileDescription", info.FileDescription);
                    xmldoc.CreateNodeElement(file, "UploadDate", info.UploadDate.ToString());
                    xmldoc.CreateNodeElement(file, "FileSize", info.FileSize.ToString());
                }
                this.Response.Clear();
                this.Response.Write(xmldoc.ToString());
            }
            catch (Exception ex)
            {
                errorInfo = "下载文件异常!";
                //TxtLogger.DumpException(ex);
                this.ReturnResultInfo(false, errorInfo);
            }
        }

        /// <summary>
        /// 删除文件  标记删除
        /// </summary>
        private void DeleteMUDFile()
        {
            string errorInfo = string.Empty;
            try
            {
                string strSystemName = string.Empty;
                string strRecordID = string.Empty;
                string strAttributeName = string.Empty;
                string strFileServerName = string.Empty;
                MUDFilesCtrl ctrl = new MUDFilesCtrl();
                strSystemName = this.Request.Params["SystemName"].ToString();
                strRecordID = this.Request.Params["RecordID"].ToString();
                strAttributeName = this.Request.Params["AttributeName"].ToString();
                strFileServerName = Server.UrlDecode(this.Request.Params["FileServerName"].ToString());
                ctrl.UpdateTempState(string.Empty, Server.UrlDecode(strFileServerName), 2, strRecordID);
                this.ReturnResultInfo(true, errorInfo);
            }
            catch (Exception ex)
            {
                errorInfo = "删除文件异常!";
                //TxtLogger.DumpException(ex);
                this.ReturnResultInfo(false, errorInfo);
            }
        }

        /// <summary>
        /// 把流转化为fileInfo.FileData
        /// </summary>
        /// <param name="fileInfo">文件信息</param>
        /// <param name="stream">流文件</param>
        /// <returns>MUDFilesInfo</returns>
        private MUDFilesInfo TransformFileInfo(MUDFilesInfo fileInfo, Stream stream)
        {
            try
            {
                if (fileInfo != null && stream != null)
                {
                    int intImageSize = fileInfo.FileSize;
                    byte[] mydata = new byte[intImageSize];
                    stream.Read(mydata, 0, intImageSize);
                    fileInfo.FileData = mydata;
                }
                return fileInfo;
            }
            catch (Exception ex)
            {
               // TxtLogger.DumpException(ex);
                return fileInfo;
            }
        }

        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="strSystemName">系统名称</param>
        /// <param name="strRecordID">附件对应的ID</param>
        /// <param name="strAttributeName">页面的属性名称</param>
        /// <param name="strFileServerName">文件服务名</param>
        /// <param name="http">页面请求的Response</param>
        public void DownLoadMUDFile(string strSystemName, string strRecordID, string strAttributeName, string strFileServerName, HttpResponse http)
        {
            try
            {
                string strServerPath = string.Empty;
                MUDFilesCtrl ctrl = new MUDFilesCtrl();
                MUDFilesInfo fileInfo;
                fileInfo = ctrl.GetFileInfo(strSystemName, strRecordID, Server.UrlDecode(strAttributeName), Server.UrlDecode(strFileServerName));
                if (fileInfo == null)
                {
                    http.Write(string.Empty);
                    return;
                }
                strServerPath = fileInfo.ServerPath;
                //如果附件以数据形式存放，则得到数据并进行二进制流回写 edit by linjia
                http.ContentType = "Application/rar";
                http.BinaryWrite((byte[])fileInfo.FileData);
            }
            catch (Exception ex)
            {
                //TxtLogger.DumpException(ex);
                this.Response.Write(string.Empty);
                return;
            }
        }

        /// <summary>
        /// 下载文件
        /// </summary>
        private void DownLoadMUDFile()
        {
            try
            {
                string strSystemName = string.Empty;
                string strRecordID = string.Empty;
                string strAttributeName = string.Empty;
                string strFileServerName = string.Empty;
                if (this.Request.Params["SystemName"] != null)
                {
                    strSystemName = this.Request.Params["SystemName"].ToString();
                }
                if (this.Request.Params["RecordID"] != null)
                {
                    strRecordID = this.Request.Params["RecordID"].ToString();
                }
                if (this.Request.Params["AttributeName"] != null)
                {
                    strAttributeName = this.Request.Params["AttributeName"].ToString();
                }
                if (this.Request.Params["FileServerName"] != null)
                {
                    strFileServerName = Server.UrlDecode(this.Request.Params["FileServerName"].ToString());
                }
                this.DownLoadMUDFile(strSystemName, strRecordID, strAttributeName, strFileServerName, this.Response);
            }
            catch (Exception ex)
            {
                //TxtLogger.DumpException(ex);
                this.Response.Write(string.Empty);
                return;
            }
        }

        /// <summary>
        /// 上传文件
        /// </summary>
        private void UploadMUDFile()
        {
            string errorInfo = string.Empty;
            try
            {
                string strSystemName = string.Empty;
                string strRecordID = string.Empty;
                string strAttributeName = string.Empty;
                string strFileDescription = string.Empty;
                string strFileDisplayName = string.Empty;
                string strFileServerName = string.Empty;
                if (this.Request.Files[0] == null)
                {
                    errorInfo = "上传文件为空!";
                    this.ReturnResultInfo(false, errorInfo);
                    return;
                }
                if (this.Request.Form["SystemName"] != null)
                {
                    strSystemName = this.Request.Form["SystemName"].ToString();
                }
                if (this.Request.Form["RecordID"] != null)
                {
                    strRecordID = this.Request.Form["RecordID"].ToString();
                }
                if (this.Request.Form["AttributeName"] != null)
                {
                    strAttributeName = this.Request.Form["AttributeName"].ToString();
                }
                if (this.Request.Form["FileDescription"] != null)
                {
                    strFileDescription = Server.UrlEncode(this.Request.Form["FileDescription"].ToString());
                }
                if (this.Request.Form["FileDisplayName"] != null)
                {
                    strFileDisplayName = Server.UrlEncode(this.Request.Form["FileDisplayName"].ToString());
                }
                strFileServerName = DUFileUtil.GenUNID();
                MUDFilesInfo fileInfo = new MUDFilesInfo();
                fileInfo.SystemName = strSystemName;
                fileInfo.RecordID = strRecordID;
                fileInfo.AttributeName = strAttributeName;
                fileInfo.FileDescription = strFileDescription;
                fileInfo.FileDisplayName = strFileDisplayName;
                fileInfo.FileSize = this.Request.Files[0].ContentLength;
                fileInfo.UploadDate = DateTime.Now;
                fileInfo.FileServerName = strFileServerName;
                fileInfo.ServerPath = string.Empty;
                fileInfo.TempState = 1;
                fileInfo.FileSize = this.Request.Files[0].ContentLength;

                if (fileInfo.FileSize > maxFileSize)
                {
                    errorInfo = "上传文件太大，无法上传!";
                    this.ReturnResultInfo(false, errorInfo);
                }
                else 
                {
                    this.UploadMUDFile(fileInfo, this.Request.Files[0]);
                    this.ReturnResultInfo(true, errorInfo);
                }                
            }
            catch (Exception ex)
            {
                errorInfo = "文件上传异常，请重试!";
                //TxtLogger.DumpException(ex);
                this.ReturnResultInfo(false, errorInfo);
            }
        }

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="fileInfo">文件信息</param>
        /// <param name="stream">流文件</param>
        public void UploadMUDFile(MUDFilesInfo fileInfo, Stream stream)
        {
            MUDFilesCtrl ctrl = new MUDFilesCtrl();
            string errorInfo = string.Empty;
            try
            {
                int fileSize = (int)stream.Length;

                if (fileSize > maxFileSize)
                {
                    errorInfo = "上传文件太大，无法上传!";
                    this.ReturnResultInfo(false, errorInfo);
                }
                else
                {
                    fileInfo = this.TransformFileInfo(fileInfo, stream);
                    ctrl.Insert(string.Empty, fileInfo);
                    this.ReturnResultInfo(true, errorInfo);
                }
            }
            catch (Exception ex)
            {
                errorInfo = "文件上传异常，请重试!";
                //TxtLogger.DumpException(ex);
                this.ReturnResultInfo(false, errorInfo);
            }
        }

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="fileInfo">文件信息</param>
        /// <param name="http">页面请求的Request</param>
        /// <param name="strServerPath">路径</param>
        public void UploadMUDFile(MUDFilesInfo fileInfo, HttpRequest http, string strServerPath)
        {
            ResultInfo result = new ResultInfo(0);
            try
            {
             
                Stream stream = null;
                stream = http.InputStream;
                this.UploadMUDFile(fileInfo, stream);
            }
            catch (Exception ex)
            {
                //TxtLogger.DumpException(ex);
            }
        }

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="fileInfo">文件信息</param>
        /// <param name="httpfiles">页面请求的Request</param>
        /// <param name="strServerPath">路径</param>
        public void UploadMUDFile(MUDFilesInfo fileInfo, HttpPostedFile httpfiles, string strServerPath)
        {
            MUDFilesCtrl ctrl = new MUDFilesCtrl();
            ResultInfo result = new ResultInfo(0);
            try
            {
                Stream stream = null;
                stream = httpfiles.InputStream;

                this.UploadMUDFile(fileInfo, stream);
            }
            catch (Exception ex)
            {
               // TxtLogger.DumpException(ex);
            }
        }

        /// <summary>
        /// 上传并修改文件
        /// </summary>
        /// <param name="fileInfo">文件信息</param>
        /// <param name="httpfiles">页面请求的Request</param>
        public void UploadMUDFile(MUDFilesInfo fileInfo, HttpPostedFile httpfiles)
        {
            MUDFilesCtrl ctrl = new MUDFilesCtrl();
            ResultInfo result = new ResultInfo(0);

            string strServerPath = ConfigUtil.GetValue("ATTACHMENTDIR", "d:\\attachment\\");

            if (strServerPath.Substring(strServerPath.Length - 1, 1) != "\\")
            {
                strServerPath = strServerPath + "\\";
            }

            this.UploadMUDFile(fileInfo, httpfiles, strServerPath);
        }

        /// <summary>
        /// 上传并修改文件
        /// </summary>
        /// <param name="fileInfo">文件信息</param>
        /// <param name="stream">流文件</param>
        public void UpdateFile(MUDFilesInfo fileInfo, Stream stream)
        {
            MUDFilesCtrl ctrl = new MUDFilesCtrl();
            ResultInfo result = new ResultInfo(0);
            string errorInfo = string.Empty;

            try
            {
                int fileSize = (int)stream.Length;

                if (fileSize > maxFileSize)
                {
                    errorInfo = "上传文件太大，无法上传!";
                    this.ReturnResultInfo(false, errorInfo);
                }
                else
                {
                    fileInfo = this.TransformFileInfo(fileInfo, stream);
                    ctrl.Update(string.Empty, fileInfo);
                    this.ReturnResultInfo(true, errorInfo);
                }
            }
            catch (Exception ex)
            {
                errorInfo = "文件上传异常，请重试!";
                //TxtLogger.DumpException(ex);
                this.ReturnResultInfo(false, errorInfo);
            }
        }

        /// <summary>
        /// 上传并修改文件
        /// </summary>
        /// <param name="fileInfo">文件信息</param>
        /// <param name="http">页面请求的Request</param>
        /// <param name="strServerPath">路径</param>
        public void UpdateFile(MUDFilesInfo fileInfo, HttpRequest http, string strServerPath)
        {
            try
            {
                Stream stream = null;
                stream = http.InputStream;

                this.UpdateFile(fileInfo, stream);
            }
            catch (Exception ex)
            {
                //TxtLogger.DumpException(ex);
            }
        }

        /// <summary>
        /// 上传并修改文件
        /// </summary>
        /// <param name="fileInfo">文件信息</param>
        /// <param name="httpfiles">页面请求的Request</param>
        /// <param name="strServerPath">路径</param>
        public void UpdateFile(MUDFilesInfo fileInfo, HttpPostedFile httpfiles, string strServerPath)
        {
            try
            {
                Stream stream = null;
                stream = httpfiles.InputStream;
                this.UpdateFile(fileInfo, stream);
            }
            catch (Exception ex)
            {
                //TxtLogger.DumpException(ex);
            }
        }

        /// <summary>
        /// 上传并修改文件
        /// </summary>
        /// <param name="fileInfo">文件信息</param>
        /// <param name="httpfiles">页面请求的Request</param>
        public void UpdateFile(MUDFilesInfo fileInfo, HttpPostedFile httpfiles)
        {
            string strServerPath = ConfigUtil.GetValue("ATTACHMENTDIR", "d:\\attachment\\");
            if (strServerPath.Substring(strServerPath.Length - 1, 1) != "\\")
            {
                strServerPath = strServerPath + "\\";
            }
            strServerPath += "MUD\\";
            this.UpdateFile(fileInfo, httpfiles, strServerPath);
        }

        /// <summary>
        /// 返回操作结果
        /// </summary>
        /// <param name="result">是或否</param>
        /// <param name="errorInfo">错误类型</param>
        private void ReturnResultInfo(bool result, string errorInfo)
        {
            XmlHelper xmldoc = new XmlHelper();
            xmldoc.LoadXML("<FilesActiveX/>", XmlHelper.LoadType.FromString);
            xmldoc.CreateXmlDeclaration("1.0", "GB2312", string.Empty);
            if (result)
            {
                xmldoc.CreateNodeElement(xmldoc.RootNode, "ResultType", "0");
                xmldoc.CreateNodeElement(xmldoc.RootNode, "ResultInfo", "操作成功");
            }
            else
            {
                xmldoc.CreateNodeElement(xmldoc.RootNode, "ResultType", "-1");
                xmldoc.CreateNodeElement(xmldoc.RootNode, "ResultInfo", "操作失败:" + errorInfo);
            }
            Response.Clear();
            Response.Write(xmldoc.ToString());
        }
    }
}
