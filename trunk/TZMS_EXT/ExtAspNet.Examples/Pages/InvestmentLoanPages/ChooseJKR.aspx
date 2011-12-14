<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChooseJKR.aspx.cs" Inherits="TZMS.Web.Pages.InvestmentLoanPages.ChooseJKR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ChooseJKR</title>
</head>
<body>
    <form id="form1" runat="server">
    <ext:PageManager ID="PageManager1" runat="server" />
    <ext:Panel ID="pelMain" runat="server" EnableBackgroundColor="true" BodyPadding="3px"
        EnableLargeHeader="true" Title="Panel" ShowBorder="false" ShowHeader="false"
        AutoHeight="true" Layout="Column">
        <Toolbars>
            <ext:Toolbar ID="Toolbar1" runat="server">
                <Items>
                    <ext:Button ID="btnClose" OnClick="btnClose_Click" runat="server" Icon="Cancel" Text="关闭">
                    </ext:Button>
                    <ext:Button ID="btnSave" Text="设置并保存" OnClick="btnSave_Click" runat="server" Icon="Disk"
                        ConfirmText="您确认设置并保存吗?" />
                </Items>
            </ext:Toolbar>
        </Toolbars>
        <Items>
            <ext:Grid ID="gridUnSelectUser" Title="客户列表" ShowBorder="true" ShowHeader="true"
                ColumnWidth="46%" runat="server" AutoHeight="true" Height="385px" EnableMultiSelect="false"
                OnRowDataBound="gridUnSelectUser_RowDataBound">
                <Columns>
                    <ext:BoundField DataField="ObjectId" Hidden="true" />
                    <ext:BoundField DataField="Name" HeaderText="姓名" Width="53px" />
                    <ext:BoundField DataField="MobilePhone" HeaderText="手机" Width="71px" />
                    <ext:BoundField DataField="CreditScore" HeaderText="积分" Width="35px" />
                    <ext:BoundField ExpandUnusedSpace="true" HeaderText="公司" />
                </Columns>
            </ext:Grid>
            <ext:Panel ID="Panel1" ColumnWidth="8%" Layout="Row" EnableBackgroundColor="true"
                BodyPadding="3px" ShowBorder="false" ShowHeader="false" runat="server">
                <Items>
                    <ext:Label ID="Label1" runat="server" Height="150px">
                    </ext:Label>
                    <ext:Button ID="btnSelect" runat="server" ToolTip="选择" Icon="ArrowRight" OnClick="btnSelect_Click">
                    </ext:Button>
                    <ext:Button ID="btnUnselect" runat="server" ToolTip="移除" Icon="ArrowLeft" OnClick="btnUnselect_Click">
                    </ext:Button>
                </Items>
            </ext:Panel>
            <ext:Grid ID="gridSelectdUsers" Title="已选择借款人" ShowBorder="true" ShowHeader="true"
                EnableMultiSelect="false" ColumnWidth="46%" runat="server" AutoHeight="true"
                Height="385px" OnRowDataBound="gridSelectdUsers_RowDataBound">
                <Columns>
                    <ext:BoundField DataField="ObjectId" Hidden="true" />
                    <ext:BoundField DataField="Name" HeaderText="姓名" Width="53px" />
                    <ext:BoundField DataField="MobilePhone" HeaderText="手机" Width="71px" />
                    <ext:BoundField DataField="CreditScore" HeaderText="积分" Width="35px" />
                    <ext:BoundField ExpandUnusedSpace="true" HeaderText="公司" />
                </Columns>
            </ext:Grid>
        </Items>
    </ext:Panel>
    </form>
</body>
</html>
