<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImportWorkerAttend.aspx.cs"
    Inherits="TZMS.Web.ImportWorkerAttend" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <ext:PageManager ID="PageManager1" runat="server" EnableAjax="false" />
    <ext:Panel ID="pelMain" runat="server" EnableBackgroundColor="true" BodyPadding="3px"
        EnableLargeHeader="true" Title="Panel" AutoScroll="false" ShowBorder="true" ShowHeader="false">
        <Toolbars>
            <ext:Toolbar ID="Toolbar1" runat="server">
                <Items>
                    <ext:Button ID="btnClose" OnClick="btnClose_Click" runat="server" Icon="Cancel" Text="关闭">
                    </ext:Button>
                    <ext:Button ID="btnImport" OnClick="btnImport_Click" runat="server" Icon="Disk" Text="导入">
                    </ext:Button>
                </Items>
            </ext:Toolbar>
        </Toolbars>
        <Items>
            <ext:Panel ID="pelOperator" runat="server" ShowBorder="false" EnableBackgroundColor="true"
                BodyPadding="3px" ShowHeader="false" AnchorValue="100% -36">
                <Items>
                    <ext:ContentPanel ID="ContentPanel1" runat="server" BodyPadding="5px" EnableBackgroundColor="true"
                        ShowBorder="false" ShowHeader="false" Title="ContentPanel">
                        <br />
                        <br />
                        <br />
                        选择考勤Excel:
                        <asp:FileUpload ID="uploadExcel" runat="server"></asp:FileUpload>
                        <br />
                        <ext:HyperLink runat=server NavigateUrl="../../Template/考勤记录.xls" Text="考勤模板"></ext:HyperLink>
                        <br />
                        <br />
                    </ext:ContentPanel>
                </Items>
            </ext:Panel>
        </Items>
    </ext:Panel>
    </form>
</body>
</html>
