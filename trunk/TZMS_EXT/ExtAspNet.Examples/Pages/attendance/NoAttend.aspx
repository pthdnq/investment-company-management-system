<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NoAttend.aspx.cs" Inherits="TZMS.Web.NoAttend" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>未打卡说明</title>
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
                            <ext:DropDownList ID="ddlappState" runat="server" Label="申请状态">
                                <ext:ListItem Text="审批中" Value="0" Selected="true" />
                                <ext:ListItem Text="归档-已通过" Value="2" />
                                <ext:ListItem Text="归档-未通过" Value="1" />
                            </ext:DropDownList>
                            <ext:DatePicker ID="dpkStartTime" runat="server" Label="开始日期">
                            </ext:DatePicker>
                            <ext:DatePicker ID="dpkEndTime" runat="server" Label="结束日期">
                            </ext:DatePicker>
                            <ext:Button ID="btnSearch" runat="server" Icon="Magnifier" Text="查询" OnClick="btnSearch_Click">
                            </ext:Button>
                        </Items>
                    </ext:FormRow>
                </Rows>
            </ext:Form>
            <ext:Panel ID="pelGrid" ShowBorder="True" ShowHeader="false" AnchorValue="100% -36"
                Layout="Fit" runat="server">
                <Toolbars>
                    <ext:Toolbar ID="toolApp" runat="server">
                        <Items>
                            <ext:Button ID="btnNewApp" Text="未打卡申请" ToolTip="未打卡申请" Icon="Add" runat="server">
                            </ext:Button>
                        </Items>
                    </ext:Toolbar>
                </Toolbars>
                <Items>
                    <ext:Grid ID="gridNoAttend" Title="Grid1" ShowBorder="true" ShowHeader="false" AllowPaging="true"
                        runat="server" IsDatabasePaging="true" EnableRowNumber="True" AutoHeight="true"
                        OnPageIndexChange="gridNoAttend_PageIndexChange" OnRowCommand="gridNoAttend_RowCommand"
                        OnRowDataBound="gridNoAttend_RowDataBound">
                        <Columns>
                            <ext:BoundField DataField="ObjectId" HeaderText="ID" Hidden="true" />
                            <ext:BoundField HeaderText="年月" />
                            <ext:BoundField DataField="ApplyTime" HeaderText="申请时间" />
                            <ext:BoundField DataField="Comment" HeaderText="事项" DataTooltipField="Comment" ExpandUnusedSpace="true" />
                            <ext:BoundField DataField="Other" HeaderText="备注" DataTooltipField="Other" />
                            <ext:BoundField DataField="CurrentCheckID" HeaderText="当前审批人" />
                            <ext:BoundField DataField="State" HeaderText="申请状态" />
                            <ext:LinkButtonField Width="38px" Text="查看" CommandName="View" />
                        </Columns>
                    </ext:Grid>
                </Items>
            </ext:Panel>
        </Items>
    </ext:Panel>
    <ext:Window ID="wndNewNoAttend" Title="未打卡申请" Popup="false" EnableIFrame="true" IFrameUrl="about:blank"
        Target="Parent" runat="server" IsModal="true" Width="700px" EnableConfirmOnClose="true"
        Height="500px" OnClose="wndNewNoAttend_Close">
    </ext:Window>
    </form>
</body>
</html>
