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
    /// �ϴ��ļ�
    /// </summary>
    public partial class UploadFile : Page
    {
        /// <summary>
        /// ���õ�����ϴ��ļ�����
        /// </summary>
        private static int maxFileSize = Convert.ToInt32(WebConfigurationManager.AppSettings["UploadFileSize"].ToString()) * 1024;
        
        /// <summary>
        /// ҳ�����
        /// </summary>
        /// <param name="sender">�¼��ķ�����</param>
        /// <param name="e">���¼�����������ĳЩ����</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            string errorInfo = string.Empty;
            try
            {
                string strUrl = this.Request.Url.ToString();
                //��ȡ��������
                int operateType = Int32.Parse(this.Request.Params["OperateType"].ToString());

                //���ݲ������ͽ�����Ӧ�Ĳ���
                switch (operateType)
                {
                    case 0:
                        //�ϴ����ļ�
                        this.UploadMUDFile();
                        break;
                    case 1:
                        //�����ļ�
                        this.DownLoadMUDFile();
                        break;
                    case 2:
                        //ɾ���ļ� ���ɾ��
                        this.DeleteMUDFile();
                        break;
                    case 3:
                        //����ļ�ժҪ��Ϣ
                        this.GetMUDFileInfo();
                        break;
                    default:
                        //����û���ҵ���������
                        break;
                }
            }
            catch (Exception ex)
            {
                errorInfo = "�ļ������쳣,������!";
                //TxtLogger.DumpException(ex);
                this.ReturnResultInfo(false, errorInfo);
            }
        }

        /// <summary>
        /// ����ļ���ժҪ��Ϣ
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
                xmldoc.CreateNodeElement(xmldoc.RootNode, "ResultInfo", "�����ɹ�");
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
                errorInfo = "�����ļ��쳣!";
                //TxtLogger.DumpException(ex);
                this.ReturnResultInfo(false, errorInfo);
            }
        }

        /// <summary>
        /// ɾ���ļ�  ���ɾ��
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
                errorInfo = "ɾ���ļ��쳣!";
                //TxtLogger.DumpException(ex);
                this.ReturnResultInfo(false, errorInfo);
            }
        }

        /// <summary>
        /// ����ת��ΪfileInfo.FileData
        /// </summary>
        /// <param name="fileInfo">�ļ���Ϣ</param>
        /// <param name="stream">���ļ�</param>
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
        /// �����ļ�
        /// </summary>
        /// <param name="strSystemName">ϵͳ����</param>
        /// <param name="strRecordID">������Ӧ��ID</param>
        /// <param name="strAttributeName">ҳ�����������</param>
        /// <param name="strFileServerName">�ļ�������</param>
        /// <param name="http">ҳ�������Response</param>
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
                //���������������ʽ��ţ���õ����ݲ����ж���������д edit by linjia
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
        /// �����ļ�
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
        /// �ϴ��ļ�
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
                    errorInfo = "�ϴ��ļ�Ϊ��!";
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
                    errorInfo = "�ϴ��ļ�̫���޷��ϴ�!";
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
                errorInfo = "�ļ��ϴ��쳣��������!";
                //TxtLogger.DumpException(ex);
                this.ReturnResultInfo(false, errorInfo);
            }
        }

        /// <summary>
        /// �ϴ��ļ�
        /// </summary>
        /// <param name="fileInfo">�ļ���Ϣ</param>
        /// <param name="stream">���ļ�</param>
        public void UploadMUDFile(MUDFilesInfo fileInfo, Stream stream)
        {
            MUDFilesCtrl ctrl = new MUDFilesCtrl();
            string errorInfo = string.Empty;
            try
            {
                int fileSize = (int)stream.Length;

                if (fileSize > maxFileSize)
                {
                    errorInfo = "�ϴ��ļ�̫���޷��ϴ�!";
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
                errorInfo = "�ļ��ϴ��쳣��������!";
                //TxtLogger.DumpException(ex);
                this.ReturnResultInfo(false, errorInfo);
            }
        }

        /// <summary>
        /// �ϴ��ļ�
        /// </summary>
        /// <param name="fileInfo">�ļ���Ϣ</param>
        /// <param name="http">ҳ�������Request</param>
        /// <param name="strServerPath">·��</param>
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
        /// �ϴ��ļ�
        /// </summary>
        /// <param name="fileInfo">�ļ���Ϣ</param>
        /// <param name="httpfiles">ҳ�������Request</param>
        /// <param name="strServerPath">·��</param>
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
        /// �ϴ����޸��ļ�
        /// </summary>
        /// <param name="fileInfo">�ļ���Ϣ</param>
        /// <param name="httpfiles">ҳ�������Request</param>
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
        /// �ϴ����޸��ļ�
        /// </summary>
        /// <param name="fileInfo">�ļ���Ϣ</param>
        /// <param name="stream">���ļ�</param>
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
                    errorInfo = "�ϴ��ļ�̫���޷��ϴ�!";
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
                errorInfo = "�ļ��ϴ��쳣��������!";
                //TxtLogger.DumpException(ex);
                this.ReturnResultInfo(false, errorInfo);
            }
        }

        /// <summary>
        /// �ϴ����޸��ļ�
        /// </summary>
        /// <param name="fileInfo">�ļ���Ϣ</param>
        /// <param name="http">ҳ�������Request</param>
        /// <param name="strServerPath">·��</param>
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
        /// �ϴ����޸��ļ�
        /// </summary>
        /// <param name="fileInfo">�ļ���Ϣ</param>
        /// <param name="httpfiles">ҳ�������Request</param>
        /// <param name="strServerPath">·��</param>
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
        /// �ϴ����޸��ļ�
        /// </summary>
        /// <param name="fileInfo">�ļ���Ϣ</param>
        /// <param name="httpfiles">ҳ�������Request</param>
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
        /// ���ز������
        /// </summary>
        /// <param name="result">�ǻ��</param>
        /// <param name="errorInfo">��������</param>
        private void ReturnResultInfo(bool result, string errorInfo)
        {
            XmlHelper xmldoc = new XmlHelper();
            xmldoc.LoadXML("<FilesActiveX/>", XmlHelper.LoadType.FromString);
            xmldoc.CreateXmlDeclaration("1.0", "GB2312", string.Empty);
            if (result)
            {
                xmldoc.CreateNodeElement(xmldoc.RootNode, "ResultType", "0");
                xmldoc.CreateNodeElement(xmldoc.RootNode, "ResultInfo", "�����ɹ�");
            }
            else
            {
                xmldoc.CreateNodeElement(xmldoc.RootNode, "ResultType", "-1");
                xmldoc.CreateNodeElement(xmldoc.RootNode, "ResultInfo", "����ʧ��:" + errorInfo);
            }
            Response.Clear();
            Response.Write(xmldoc.ToString());
        }
    }
}
