<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyWeb.aspx.cs" Inherits="TZMS.Web.MyWeb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>我的首页</title>
</head>
<body>
    <form id="form1" runat="server">
    <ext:PageManager ID="PageManager1" AutoSizePanelID="pelMain" HideScrollbar="true"
        runat="server" />
    <ext:Panel ID="pelMain" runat="server" EnableBackgroundColor="true" BodyPadding="3px"
        EnableLargeHeader="true" Title="Panel" ShowBorder="false" ShowHeader="false"
        Layout="Anchor">
        <Toolbars>
            <ext:Toolbar runat="server">
                <Items>
                    <ext:Button ID="myMessage" runat="server" Text="个人信息">
                    </ext:Button>
                    <ext:Button ID="changePsw" runat="server" Text="修改密码">
                    </ext:Button>
                    <ext:Button ID="setChecker" runat="server" Text="设置审批人">
                    </ext:Button>
                </Items>
            </ext:Toolbar>
        </Toolbars>
        <Items>
        </Items>
    </ext:Panel>
    </form>
</body>
</html>
