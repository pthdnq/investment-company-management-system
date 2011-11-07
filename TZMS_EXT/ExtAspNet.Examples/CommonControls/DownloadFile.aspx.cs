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
using Com.iFlytek.Utility;
using System.IO;
using Com.iFlytek.OA.MUDCommon;


namespace TZMS.Web.CommonControls
{
    /// <summary>
    /// �ϴ����ؿؼ�ҳ��
    /// </summary>
    public partial class UserControl_DownloadFile : Page
    {
        /// <summary>
        /// ҳ�����
        /// </summary>
        /// <param name="sender">�¼��ķ�����</param>
        /// <param name="e">���¼�����������ĳЩ����</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            this.DownLoadMUDFile();
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
                string strFileDisplayName = string.Empty;

                if (this.Request.Params["SystemName"] != null)
                {
                    strSystemName = Server.UrlDecode(this.Request.Params["SystemName"]);
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
                    strFileServerName = this.Request.Params["FileServerName"].ToString();
                }
                if (this.Request.Params["FileDisplayName"] != null)
                {
                    strFileDisplayName = this.Request.Params["FileDisplayName"].ToString();
                }
                this.DownLoadMUDFile(strSystemName, strRecordID, strAttributeName, strFileServerName, strFileDisplayName, this.Response);
            }
            catch (Exception ex)
            {
                //TxtLogger.DumpException(ex);

                this.Response.Write(string.Empty);
                return;
            }
        }

        /// <summary>
        /// �����ļ��ķ���
        /// </summary>
        /// <param name="strSystemName">ϵͳ����</param>
        /// <param name="strRecordID">Ψһ��ID</param>
        /// <param name="strAttributeName">�ļ�����������</param>
        /// <param name="strFileServerName">�ļ�FileServerName</param>
        /// <param name="strFileDisplayName">���ص��ļ�����</param>
        /// <param name="http">��ǰҳ���HttpResponse</param>
        public void DownLoadMUDFile(string strSystemName, string strRecordID, string strAttributeName, string strFileServerName, string strFileDisplayName, HttpResponse http)
        {
            try
            {
                string strServerPath = string.Empty;
                MUDFilesCtrl ctrl = new MUDFilesCtrl();
                MUDFilesInfo fileInfo;
                fileInfo = ctrl.GetFileInfo(strSystemName, strRecordID, strAttributeName, strFileServerName);
                if (fileInfo == null)
                {
                    http.Write(string.Empty);
                    return;
                }
                strServerPath = fileInfo.ServerPath;
                http.Clear();
                http.Buffer = true;
                string fileName = HttpUtility.UrlDecode(fileInfo.FileDisplayName);
                string postFix = fileName.Substring(fileName.LastIndexOf('.') + 1);
                int start = fileName.Length - 16;
                fileName = fileName.Substring(start < 0 ? 0 : start);
                http.AppendHeader("Content-Disposition", "attachment; filename=" + HttpUtility.UrlEncode(fileName, System.Text.Encoding.UTF8));
                if (postFix.ToLower().Equals("doc") || postFix.ToLower().Equals("docx"))
                {
                    http.ContentType = "application/msword";
                }
                else if (postFix.ToLower().Equals("txt"))
                {
                    http.ContentType = "text/plain";
                }
                else
                {
                    http.ContentType = "application/x-download";
                }
                http.OutputStream.Write(fileInfo.FileData, 0, fileInfo.FileSize);
                http.OutputStream.Flush();
                http.OutputStream.Close();
            }
            catch (Exception ex)
            {
                //TxtLogger.DumpException(ex);

                this.Response.Write(string.Empty);

                return;
            }
        }
    }
}
