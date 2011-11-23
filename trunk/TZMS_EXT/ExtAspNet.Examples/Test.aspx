<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="TZMS.Web.Test" %>

<%--<%@ Register Src="../../CommonControls/MudFlexCtrl.ascx" TagName="MudFlexCtrl" TagPrefix="ucl" %>--%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../../App_Flash/AC_OETags.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <a href="http://localhost:19429/Default.aspx?account=1234" target="ds">1456789</a>
   <iframe name="ds" src="http://211.86.153.66:57682/Default.aspx?account=123"  width="100%" height="500px"></iframe>

     <%--   <ucl:MudFlexCtrl runat="server" ID="MUDAttachment"></ucl:MudFlexCtrl>--%>
    </div>
    </form>
</body>
</html>
