﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SetMyChecker.aspx.cs" Inherits="TZMS.Web.SetMyChecker" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="x-ua-compatible" content="ie=8" />
    <title>设置我的审批人</title>
</head>
<body>
    <form id="form1" runat="server">
    <ext:PageManager ID="PageManager1" runat="server" />
    <ext:Panel ID="pelMain" runat="server" EnableBackgroundColor="true" BodyPadding="3px"
        EnableLargeHeader="true" Title="Panel" ShowBorder="false" ShowHeader="false"
        AutoHeight="true" Layout="Column">
        <Toolbars>
            <ext:Toolbar runat="server">
                <Items>
                    <ext:Button ID="btnSave" Text="保存" OnClick="btnSave_Click" runat="server" Icon="Disk" />
                </Items>
            </ext:Toolbar>
        </Toolbars>
        <Items>
            <ext:Grid ID="gridUnSelectUser" Title="员工列表" ShowBorder="true" ShowHeader="true"
                ColumnWidth="44%" runat="server" AutoHeight="true" Height="385px" EnableMultiSelect="false">
                <Columns>
                    <ext:BoundField DataField="Name" HeaderText="姓名" Width="65px" />
                    <ext:BoundField DataField="AccountNo" HeaderText="帐号" Width="65px" Hidden="true" />
                    <ext:BoundField DataField="Position" HeaderText="职位" ExpandUnusedSpace="true" />
                </Columns>
            </ext:Grid>
            <ext:Panel ID="Panel1" ColumnWidth="13%" Layout="Row" EnableBackgroundColor="true"
                BodyPadding="3px" ShowBorder="false" ShowHeader="false" runat="server">
                <Items>
                    <ext:Label runat="server" Height="150px">
                    </ext:Label>
                    <ext:Button ID="btnSelect" runat="server" ToolTip="选择" Icon="ArrowRight" OnClick="btnSelect_Click">
                    </ext:Button>
                    <ext:Button ID="btnUnselect" runat="server" ToolTip="移除" Icon="ArrowLeft" OnClick="btnUnselect_Click">
                    </ext:Button>
                </Items>
            </ext:Panel>
            <ext:Grid ID="gridSelectdUsers" Title="常用审批人" ShowBorder="true" ShowHeader="true"
                EnableMultiSelect="false" ColumnWidth="43%" runat="server" AutoHeight="true"
                Height="385px">
                <Columns>
                    <ext:BoundField DataField="Name" HeaderText="姓名" Width="65px" />
                    <ext:BoundField DataField="AccountNo" HeaderText="帐号" Width="65px" Hidden="true" />
                    <ext:BoundField DataField="Position" HeaderText="职位" ExpandUnusedSpace="true" />
                </Columns>
            </ext:Grid>
        </Items>
    </ext:Panel>
    </form>
</body>
</html>
