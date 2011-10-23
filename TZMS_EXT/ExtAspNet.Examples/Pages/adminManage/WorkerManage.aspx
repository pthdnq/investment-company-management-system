<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WorkerManage.aspx.cs" Inherits="TZMS.Web.WorkerManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>员工管理</title>
</head>
<body>
    <form id="form1" runat="server">
    <ext:PageManager ID="PageManager1" runat="server" />
    <ext:Toolbar ID="toolUser" runat="server">
        <Items>
            <ext:Button ID="btnNewUser" Text="新增员工"  runat="server">
            </ext:Button>
        </Items>
    </ext:Toolbar>
    <ext:Grid ID="gridUser" Title="Grid1" PageSize="15" ShowBorder="true" ShowHeader="false"
        AutoHeight="true" AllowPaging="true" runat="server" IsDatabasePaging="true" EnableRowNumber="True"
        OnPageIndexChange="gridUser_PageIndexChange">
        <Columns>
            <ext:BoundField DataField="JobNo" HeaderText="MyText" ExpandUnusedSpace="True" />
            <ext:BoundField Width="200px" DataField="Name" HeaderText="MyValue" />
            <ext:BoundField Width="60px" DataField="AccountNo" HeaderText="Year" />
        </Columns>
    </ext:Grid>
    </form>
</body>
</html>
