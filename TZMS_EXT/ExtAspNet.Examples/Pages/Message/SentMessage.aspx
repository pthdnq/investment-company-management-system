<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SentMessage.aspx.cs" Inherits="TZMS.Web.Pages.SentMessage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>已发消息</title>
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
                            <ext:DatePicker ID="dpkStartTime" runat="server" Label="开始日期">
                            </ext:DatePicker>
                            <ext:DatePicker ID="dpkEndTime" runat="server" Label="结束日期">
                            </ext:DatePicker>
                            <ext:Button ID="btnSearch" runat="server" Icon="Magnifier" Text="查询" OnClick="btnSearch_Click">
                            </ext:Button>
                            <ext:Label ID="label1" runat="server">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                </Rows>
            </ext:Form>
            <ext:Panel ID="pelGrid" ShowBorder="True" ShowHeader="false" AnchorValue="100% -36"
                Layout="Fit" runat="server">
                <Toolbars>
                    <ext:Toolbar ID="toolApp" Hidden="true" runat="server">
                        <Items>
                            <ext:Button ID="btnNewMessage" Text="发送消息" ToolTip="发送消息" Icon="Add" runat="server"
                                Hidden="true" Enabled="false">
                            </ext:Button>
                        </Items>
                    </ext:Toolbar>
                </Toolbars>
                <Items>
                    <ext:Grid ID="gridMessage" Title="Grid1" ShowBorder="true" ShowHeader="false" AllowPaging="true"
                        runat="server" IsDatabasePaging="true" EnableRowNumber="True" AutoHeight="true"
                        OnPageIndexChange="gridMessage_PageIndexChange" OnRowCommand="gridMessage_RowCommand"
                        OnRowDataBound="gridMessage_RowDataBound">
                        <Columns>
                            <ext:BoundField DataField="ObjectId" HeaderText="ID" Hidden="true" />
                            <ext:BoundField DataField="Recevicer" HeaderText="收信人" DataTooltipField="Recevicer" />
                            <ext:BoundField DataField="Tile" HeaderText="标题" />
                            <ext:BoundField DataField="Context" HeaderText="内容" DataTooltipField="Context" ExpandUnusedSpace="true" />
                            <ext:BoundField DataField="SendDate" HeaderText="发送日期" />
                            <ext:LinkButtonField Width="38px" Text="查看" CommandName="View" />
                            <ext:LinkButtonField Width="38px" Text="删除" CommandName="Delete" ConfirmText="您确认要删除该消息?" />
                        </Columns>
                    </ext:Grid>
                </Items>
            </ext:Panel>
        </Items>
    </ext:Panel>
    <ext:Window ID="wndViewMessage" Title="查看消息" Popup="false" EnableIFrame="true" IFrameUrl="about:blank"
        Target="Parent" runat="server" IsModal="true" Width="700px" EnableConfirmOnClose="true"
        Height="500px">
    </ext:Window>
    <ext:Window ID="wndNewMessage" Title="发送消息" Popup="false" EnableIFrame="true" IFrameUrl="about:blank"
        Target="Parent" runat="server" IsModal="true" Width="700px" EnableConfirmOnClose="true"
        Height="500px" OnClose="wndNewMessage_Close">
    </ext:Window>
    </form>
</body>
</html>
