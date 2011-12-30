<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserLeaveApproveToFile.aspx.cs"
    Inherits="TZMS.Web.UserLeaveApproveToFile" %>

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
                        </Items>
                    </ext:FormRow>
                </Rows>
            </ext:Form>
            <ext:Panel ID="pelGrid" ShowBorder="True" ShowHeader="false" AnchorValue="100% -36"
                Layout="Fit" runat="server">
                <Items>
                    <ext:Grid ID="gridArchiver" Title="Grid1" ShowBorder="true" ShowHeader="false" AllowPaging="true"
                        runat="server" IsDatabasePaging="true" EnableRowNumber="True" AutoHeight="true"
                        OnPageIndexChange="gridArchiver_PageIndexChange" OnRowCommand="gridArchiver_RowCommand"
                        OnRowDataBound="gridArchiver_RowDataBound">
                        <Columns>
                            <ext:BoundField HeaderText="ApproveID" Hidden="true" />
                            <ext:BoundField HeaderText="ApplyID" Hidden="true" />
                            <ext:BoundField HeaderText="申请人" />
                            <ext:BoundField HeaderText="申请时间" />
                            <ext:BoundField HeaderText="合同开始日期" />
                            <ext:BoundField HeaderText="合同结束日期" />
                            <ext:BoundField HeaderText="拟离职日期" />
                            <ext:BoundField HeaderText="离职原因" ExpandUnusedSpace="true" />
                            <ext:BoundField HeaderText="执行人" />
                            <ext:BoundField HeaderText="执行结果" />
                            <ext:BoundField HeaderText="归档状态" />
                            <ext:LinkButtonField Width="38px" Text="归档" CommandName="Archive" 
                                ConfirmTarget="Parent" />
                        </Columns>
                    </ext:Grid>
                </Items>
            </ext:Panel>
        </Items>
    </ext:Panel>
    <ext:Window ID="wndApprove" Title="离职归档" Popup="false" EnableIFrame="true" IFrameUrl="about:blank"
        Target="Parent" runat="server" IsModal="true" EnableConfirmOnClose="true" Height="550px"
        Width="700px" OnClose="wndApprove_Close">
    </ext:Window>
    </form>
</body>
</html>
