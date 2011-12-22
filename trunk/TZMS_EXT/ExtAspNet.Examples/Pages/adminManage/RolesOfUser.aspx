<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RolesOfUser.aspx.cs" Inherits="TZMS.Web.RolesOfUser" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="x-ua-compatible" content="ie=8" /> 
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <ext:PageManager ID="PageManager1" runat="server" />
    <ext:Panel ID="pelMain" runat="server" EnableBackgroundColor="true" BodyPadding="3px"
        EnableLargeHeader="true" Title="Panel" ShowBorder="false" ShowHeader="false"
        AutoHeight="true" Layout="Column">
        <Toolbars>
            <ext:Toolbar>
                <Items>
                    <ext:Button ID="btnSave" Text="保存" runat="server" OnClick="btnSave_Click" Icon="Disk" />
                </Items>
            </ext:Toolbar>
        </Toolbars>
        <Items>
            <ext:Grid ID="gridUnSelectRoles" Title="Grid1" ShowBorder="true" ShowHeader="false"
                ColumnWidth="44%" runat="server" AutoHeight="true" Height="405px" EnableMultiSelect="false">
                <Columns>
                    <ext:BoundField DataField="RoleName" HeaderText="角色名称" Width="140px" />
                </Columns>
            </ext:Grid>
            <ext:Panel ColumnWidth="13%" Layout="Row" EnableBackgroundColor="true" BodyPadding="3px"
                ShowBorder="false" ShowHeader="false" runat="server">
                <Items>
                    <ext:Label runat="server" Height="130px">
                    </ext:Label>
                    <ext:Button ID="btnSelect" runat="server" OnClick="btnSelect_Click" Icon="ArrowRight">
                    </ext:Button>
                    <ext:Button ID="btnUnselect" runat="server" OnClick="btnUnselect_Click" Icon="ArrowLeft">
                    </ext:Button>
                </Items>
            </ext:Panel>
            <ext:Grid ID="gridSelectdRoles" Title="Grid2" ShowBorder="true" ShowHeader="false"
                EnableMultiSelect="false" ColumnWidth="43%" runat="server" AutoHeight="true"
                Height="405px">
                <Columns>
                    <ext:BoundField DataField="RoleName" HeaderText="我拥有的角色" Width="135px" />
                </Columns>
            </ext:Grid>
        </Items>
    </ext:Panel>
    </form>
</body>
</html>
