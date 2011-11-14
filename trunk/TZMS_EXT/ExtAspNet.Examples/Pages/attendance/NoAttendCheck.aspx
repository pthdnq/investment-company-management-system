<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NoAttendCheck.aspx.cs"
    Inherits="TZMS.Web.NoAttendCheck" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>未打卡审批</title>
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
                    <ext:FormRow ID="FormRow1" runat="server">
                        <Items>
                            <ext:TextBox ID="tbxSearch" runat="server" EmptyText="请输入姓名查询" ShowLabel="false">
                            </ext:TextBox>
                            <ext:DropDownList ID="ddlstDept" runat="server" Label="部门名称">
                            </ext:DropDownList>
                            <ext:DropDownList ID="ddlstAproveState" runat="server" Label="审批状态">
                                <ext:ListItem Text="全部" Value="0" />
                                <ext:ListItem Text="待审批" Value="1" Selected="true" />
                                <ext:ListItem Text="已审批" Value="2" />
                            </ext:DropDownList>
                            <ext:Button ID="btnSearch" runat="server" Text="查询" Icon="Magnifier" OnClick="btnSearch_Click">
                            </ext:Button>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow2" runat="server">
                        <Items>
                            <ext:DatePicker ID="dpkStartTime" runat="server" Label="开始日期">
                            </ext:DatePicker>
                            <ext:DatePicker ID="dpkEndTime" runat="server" Label="结束日期">
                            </ext:DatePicker>
                            <ext:Label ID="Label2" runat="server">
                            </ext:Label>
                            <ext:Label ID="Label3" runat="server">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                </Rows>
            </ext:Form>
            <ext:Panel ID="pelGrid" ShowBorder="True" ShowHeader="false" AnchorValue="100% -36"
                Layout="Fit" runat="server">
                <Items>
                    <ext:Grid ID="gridNoAttendCheck" Title="Grid1" ShowBorder="true" ShowHeader="false"
                        AllowPaging="true" runat="server" IsDatabasePaging="true" EnableRowNumber="True"
                        AutoHeight="true" OnPageIndexChange="gridNoAttendCheck_PageIndexChange" OnRowCommand="gridNoAttendCheck_RowCommand"
                        OnRowDataBound="gridNoAttendCheck_RowDataBound">
                        <Columns>
                            <ext:BoundField DataField="NoAttendCheckID" Hidden="true" />
                            <ext:BoundField DataField="ObjectID" Hidden="true" />
                            <ext:BoundField DataField="UserName" Width="70px" HeaderText="姓名" />
                            <ext:BoundField DataField="Dept" Width="70px" HeaderText="部门" />
                            <ext:BoundField DataField="ApplyTime" Width="140px" HeaderText="申请时间" />
                            <ext:BoundField DataField="Year" Width="70px" HeaderText="年月" />
                            <ext:BoundField DataField="Month" Hidden="true" />
                            <ext:BoundField DataField="Comment" HeaderText="事项" DataTooltipField="Comment" ExpandUnusedSpace="true" />
                            <ext:BoundField DataField="Other" Width="150px" HeaderText="备注" />
                            <ext:BoundField DataField="Checkstate" Width="60px" HeaderText="审批状态" />
                            <ext:BoundField DataField="Result" Width="60px" HeaderText="审批结果" />
                            <ext:BoundField DataField="CheckDateTime" Width="140px" HeaderText="审批时间" />
                            <ext:LinkButtonField Width="38px" Text="审批" CommandName="Approve" />
                        </Columns>
                    </ext:Grid>
                </Items>
            </ext:Panel>
        </Items>
    </ext:Panel>
    <ext:Window ID="wndNoAttendCheck" Title="未打卡审批" Popup="false" EnableIFrame="true"
        IFrameUrl="about:blank" Target="Parent" runat="server" IsModal="true" Height="500px"
        Width="700px" OnClose="wndNoAttendCheck_Close">
    </ext:Window>
    </form>
</body>
</html>
