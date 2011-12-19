<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccountingAuditPrinter.aspx.cs"
    Inherits="TZMS.Web.Pages.FolkFinancingPages.AccountingAuditPrinter" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <input id="btnPrinter" type="button" value="打印" onclick="javascript: PrintBill();" />
        <h1>
            项目：
            <asp:Label runat="server" ID="tbProjectName"></asp:Label></h1>
        <h2>
            出款人：<asp:Label runat="server" ID="lbLenders"></asp:Label>
            <br />
            借款人：
            <asp:Label runat="server" ID="lbBorrowerNameA"></asp:Label></h2>
        <h3>
            出款金额：<asp:Label runat="server" ID="lbLoanAmount"></asp:Label>
            <br />
            借款时间：
            <asp:Label runat="server" ID="lbLoanDate"></asp:Label>
        </h3>
        <h4>
            <asp:Label runat="server" ID="tbDate"></asp:Label></h4>
    </div>
    </form>
</body>
<script language="javascript" type="text/javascript">
    var hkey_root, hkey_path, hkey_key
    hkey_root = "HKEY_CURRENT_USER"
    hkey_path = "\\Software\\Microsoft\\Internet Explorer\\PageSetup\\"
    //设置网页打印的页眉页脚为空
    function pagesetup_null() {
        try {
            var RegWsh = new ActiveXObject("WScript.Shell")
            hkey_key = "header"
            RegWsh.RegWrite(hkey_root + hkey_path + hkey_key, "")
            hkey_key = "footer"
            RegWsh.RegWrite(hkey_root + hkey_path + hkey_key, "")
        } catch (e) { }
    }

    function PrintBill() {
        pagesetup_null();
        var tab = document.getElementById("btnPrinter");
        tab.style.display = 'none';
        window.print(); //这句是打印，其他的是设置是否打印 
        tab.style.display = 'block';
    }

</script>
</html>
