<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AttendToFile.aspx.cs" Inherits="TZMS.Web.AttendToFile" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
                            <ext:DropDownList ID="ddlstArchiveState" runat="server" Label="归档状态">
                                <ext:ListItem Text="待归档" Value="3" Selected="true" />
                                <ext:ListItem Text="已归档" Value="4" />
                            </ext:DropDownList>
                            <ext:DatePicker ID="dpkStartTime" runat="server" Label="开始日期">
                            </ext:DatePicker>
                            <ext:DatePicker ID="dpkEndTime" runat="server" Label="结束日期">
                            </ext:DatePicker>
                            <ext:Button ID="btnSearch" runat="server" Icon="Magnifier" Text="查询" OnClick="btnSearch_Click">
                            </ext:Button>
                            <ext:Label ID="Label1" runat="server">
                            </ext:Label>
                            <ext:Label ID="Label2" runat="server">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                </Rows>
            </ext:Form>
            <ext:Panel ID="pelGrid" ShowBorder="True" ShowHeader="false" AnchorValue="100% -36"
                Layout="Fit" runat="server">
                <Items>
                    <ext:Grid ID="gridLeave" Title="Grid1" ShowBorder="true" ShowHeader="false" AllowPaging="true"
                        runat="server" IsDatabasePaging="true" EnableRowNumber="True" AutoHeight="true"
                        OnRowCommand="gridLeave_RowCommand" OnRowDataBound="gridLeave_RowDataBound" OnPageIndexChange="gridLeave_PageIndexChange">
                        <Columns>
                            <ext:BoundField HeaderText="ID" Hidden="true" />
                            <ext:BoundField HeaderText="申请时间" />
                            <ext:BoundField HeaderText="开始时间" />
                            <ext:BoundField HeaderText="结束时间" />
                            <ext:BoundField HeaderText="时长(小时)" />
                            <ext:BoundField HeaderText="请假类型" />
                            <ext:BoundField HeaderText="请假原因" ExpandUnusedSpace="true" />
                            <ext:BoundField HeaderText="执行人" />
                            <ext:BoundField HeaderText="审批结果" />
                            <ext:BoundField HeaderText="归档状态" />
                            <ext:LinkButtonField Width="38px" Text="归档" CommandName="Archive" ConfirmText="确定归档该请假申请单?"
                                ConfirmTarget="Parent" />
                        </Columns>
                    </ext:Grid>
                </Items>
            </ext:Panel>
        </Items>
    </ext:Panel>
    </form>
</body>
</html>
