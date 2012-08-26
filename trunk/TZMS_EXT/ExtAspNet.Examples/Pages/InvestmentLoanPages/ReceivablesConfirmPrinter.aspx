<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReceivablesConfirmPrinter.aspx.cs"
    Inherits="TZMS.Web.Pages.InvestmentLoanPages.ReceivablesConfirmPrinter" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>收款确认</title>
    <style type="text/css">
        body
        {
            background: url(images/bodyback.jpg);
            background-repeat: repeat-x;
            margin: 0;
            padding: 0;
            overflow: hidden;
        }
        .jxtable
        {
            border-collapse: collapse;
            border: solid 1px #000;
            width: 800px;
        }
        .jxtable td
        {
            border: solid 1px #000;
        }
        .tabletitle
        {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width: 800px;">
        <div class="tabletitle">
            <h3>
                安徽吉信投资发展集团收款凭证</h3>
        </div>
        <h5>
            收款时间：
            <asp:Label runat="server" ID="lbLoanDate"></asp:Label></h5>
        <table class="jxtable" border="1" cellpadding="10" cellspacing="0">
            <tr>
                <td colspan="2">
                    项目名称：
                    <asp:Label runat="server" ID="tbProjectName"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    收款帐号或现金：
                    <asp:Label runat="server" ID="lbBorrowerNameA"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    实收金额（大写）：<asp:Label runat="server" ID="lbLoanAmountUper"></asp:Label>
                </td>
                <td>
                    （小写）：<asp:Label runat="server" ID="lbLoanAmount"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    审批历史：<asp:Label runat="server" ID="lbHistory" /> 
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    备注：<asp:Label runat="server" ID="lbOther" /> 
                </td>
            </tr>
        </table>
        <h6>  出纳会计：
            <asp:Label runat="server" ID="lbPaymenter"></asp:Label></h6>
    </div>
    <div>
        <input id="btnPrinter" type="button" value="打印" onclick="javascript: PrintBill();" />
     
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
