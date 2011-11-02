﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LeaveApp.aspx.cs" Inherits="TZMS.Web.LeaveApp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>请假申请</title>
</head>
<body>
    <form id="form1" runat="server">
    <ext:PageManager ID="PageManager1" AutoSizePanelID="pelMain" HideScrollbar="true"
        runat="server" />
    <ext:Panel ID="pelMain" runat="server" EnableBackgroundColor="true" BodyPadding="3px"
        EnableLargeHeader="true" Title="Panel" ShowBorder="false" ShowHeader="false"
        Layout="Anchor">
        <Items>
            <ext:Form ID="Form2" ShowBorder="False" LabelWidth="55px" BodyPadding="5px" AnchorValue="100%"
                EnableBackgroundColor="true" ShowHeader="False" runat="server">
                <Rows>
                    <ext:FormRow>
                        <Items>
                            <ext:DropDownList ID="ddlappState" AutoPostBack="true" runat="server" Label="申请状态"
                                OnSelectedIndexChanged="ddlappState_SelectedIndexChanged">
                                <ext:ListItem Text="审批中" Value="1" Selected="true" />
                                <ext:ListItem Text="归档" Value="2" />
                                <ext:ListItem Text="被打回" Value="3" />
                            </ext:DropDownList>
                            <ext:DropDownList ID="ddldateRange" AutoPostBack="true" runat="server" Label="日期范围"
                                OnSelectedIndexChanged="ddldateRange_SelectedIndexChanged">
                                <ext:ListItem Text="全部" Value="0" />
                                <ext:ListItem Text="一月内" Value="1" Selected="true" />
                                <ext:ListItem Text="三月内" Value="2" />
                                <ext:ListItem Text="半年内" Value="3" />
                                <ext:ListItem Text="一年内" Value="4" />
                            </ext:DropDownList>
                            <ext:Label runat="server">
                            </ext:Label>
                            <ext:Label runat="server">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                </Rows>
            </ext:Form>
            <ext:Panel ID="pelGrid" ShowBorder="True" ShowHeader="false" AnchorValue="100% -36"
                Layout="Fit" runat="server">
                <Toolbars>
                    <ext:Toolbar ID="toolApp" runat="server">
                        <Items>
                            <ext:Button ID="btnNewApp" Text="请假申请" ToolTip="请假申请" Icon="Add" runat="server">
                            </ext:Button>
                        </Items>
                    </ext:Toolbar>
                </Toolbars>
                <Items>
                    <ext:Grid ID="gridLeave" Title="Grid1" ShowBorder="true" ShowHeader="false" AllowPaging="true"
                        runat="server" IsDatabasePaging="true" EnableRowNumber="True" AutoHeight="true"
                        OnRowCommand="gridLeave_RowCommand" OnRowDataBound="gridLeave_RowDataBound" OnPageIndexChange="gridLeave_PageIndexChange">
                        <Columns>
                            <ext:BoundField DataField="ObjectId" HeaderText="ID" Hidden="true" />
                            <ext:BoundField DataField="WriteTime" HeaderText="申请时间" />
                            <ext:BoundField DataField="StartTime" HeaderText="开始日期" />
                            <ext:BoundField DataField="StopTime" HeaderText="结束日期" />
                            <ext:BoundField DataField="Type" HeaderText="请假类型" />
                            <ext:BoundField DataField="Reason" HeaderText="请假原因" DataTooltipField="Reason" ExpandUnusedSpace="true" />
                            <ext:BoundField HeaderText="当前审批人" />
                            <ext:BoundField DataField="State" HeaderText="申请状态" />
                            <ext:LinkButtonField Width="38px" Text="查看" CommandName="View" />
                            <ext:LinkButtonField Width="38px" Text="编辑" CommandName="Edit" />
                            <ext:LinkButtonField Width="38px" Text="删除" ConfirmTarget="Parent" ConfirmText="确定删除该请假申请单?"
                                CommandName="Delete" />
                        </Columns>
                    </ext:Grid>
                </Items>
            </ext:Panel>
        </Items>
    </ext:Panel>
    <ext:Window ID="wndLeaveApp" Title="请假申请" Popup="false" EnableIFrame="true" IFrameUrl="about:blank"
        Target="Parent" runat="server" OnClose="wndLeaveApp_Close" IsModal="true" Width="550px"
        EnableConfirmOnClose="true" Height="350px">
    </ext:Window>
    </form>
</body>
</html>