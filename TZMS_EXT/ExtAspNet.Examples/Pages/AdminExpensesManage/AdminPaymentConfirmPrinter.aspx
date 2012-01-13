﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminPaymentConfirmPrinter.aspx.cs" Inherits="TZMS.Web.Pages.AdminExpensesManage.AdminPaymentConfirmPrinter" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>AdminPaymentConfirmPrinter</title>
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
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <input id="btnPrinter" type="button" value="打印" onclick="javascript: PrintBill();" />
        <h1>
            备用金支付确认
            <br />
        </h1>
        <h2>
            项目名称：
            <asp:Label runat="server" ID="tbProjectName"></asp:Label>
            <br />
            进展阶段：
            <asp:Label runat="server" ID="lbImplementationPhase"></asp:Label></h2>
        <h3>
            预支金额：<asp:Label runat="server" ID="lbLoanAmount"></asp:Label>
            <br />
            支用时间：
            <asp:Label runat="server" ID="lbLoanDate"></asp:Label>
            <%--  <br />
            备用金余额：
            <asp:Label runat="server" ID="tbImprestAmount"></asp:Label>--%>
            <br />
            申请人：
            <asp:Label runat="server" ID="lbApplier"></asp:Label>
            <br />
            操作人：
            <asp:Label runat="server" ID="lbPaymenter"></asp:Label>
            <br />
            <%--           支付方式：
            <asp:Label runat="server" ID="lbLoanType"></asp:Label>--%>
        </h3>
        <h4>
            <asp:Label runat="server" ID="tbDate"></asp:Label></h4>
    </div>
    </form>
</body>
</html>
