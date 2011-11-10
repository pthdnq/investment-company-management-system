<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NoAttendToFile.aspx.cs"
    Inherits="TZMS.Web.NoAttendToFile" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>未打卡归档</title>
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
                        </Items>
                    </ext:FormRow>
                </Rows>
            </ext:Form>
            <ext:Panel ID="pelGrid" ShowBorder="True" ShowHeader="false" AnchorValue="100% -36"
                Layout="Fit" runat="server">
                <Items>
                    <ext:Grid ID="gridNoAttendToFile" Title="Grid1" ShowBorder="true" ShowHeader="false"
                        AllowPaging="true" runat="server" IsDatabasePaging="true" EnableRowNumber="True"
                        AutoHeight="true" OnPageIndexChange="gridNoAttendToFile_PageIndexChange" OnRowCommand="gridNoAttendToFile_RowCommand"
                        OnRowDataBound="gridNoAttendToFile_RowDataBound">
                        <Columns>
                            <ext:BoundField Hidden="true" />
                            <ext:BoundField Hidden="true" />
                            <ext:BoundField Width="70px" HeaderText="姓名" />
                            <ext:BoundField Width="70px" HeaderText="部门" Hidden="true" />
                            <ext:BoundField Width="140px" HeaderText="申请时间" />
                            <ext:BoundField Width="70px" HeaderText="年月" />
                            <ext:BoundField HeaderText="事项" ExpandUnusedSpace="true" />
                            <ext:BoundField Width="150px" HeaderText="备注" />
                            <ext:BoundField HeaderText="执行人" />
                            <ext:BoundField HeaderText="审批结果" />
                            <ext:BoundField HeaderText="归档状态" />
                            <ext:BoundField HeaderText="归档时间" />
                            <ext:LinkButtonField Width="38px" Text="归档" CommandName="Archive" ConfirmText="确定归档该未打卡申请单?"
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
