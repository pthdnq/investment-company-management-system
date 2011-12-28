<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserLeaveApproveList.aspx.cs"
    Inherits="TZMS.Web.UserLeaveApproveList" %>

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
                    <ext:FormRow ID="FormRow1" runat="server">
                        <Items>
                            <ext:TextBox ID="tbxSearch" runat="server" EmptyText="请输入姓名查询" ShowLabel="false">
                            </ext:TextBox>
                            <ext:DropDownList ID="ddlstDept" runat="server" Label="部门名称">
                            </ext:DropDownList>
                            <ext:DropDownList ID="ddlstAproveState" runat="server" Label="审批状态">
                                <ext:ListItem Text="全部" Value="3" />
                                <ext:ListItem Text="待审批" Value="0" Selected="true" />
                                <ext:ListItem Text="已审批" Value="1" />
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
                            <ext:Label ID="Label3" runat="server">
                            </ext:Label>
                            <ext:Label ID="Label1" runat="server">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                </Rows>
            </ext:Form>
            <ext:Panel ID="pelGrid" ShowBorder="True" ShowHeader="false" AnchorValue="100% -60"
                Layout="Fit" runat="server">
                <Items>
                    <ext:Grid ID="gridApprove" Title="Grid1" ShowBorder="true" ShowHeader="false" AllowPaging="true"
                        runat="server" IsDatabasePaging="true" EnableRowNumber="True" AutoHeight="true"
                        OnPageIndexChange="gridApprove_PageIndexChange" OnRowCommand="gridApprove_RowCommand"
                        OnRowDataBound="gridApprove_RowDataBound">
                        <Columns>
                            <ext:BoundField DataField="ObjectID" Hidden="true" />
                            <ext:BoundField DataField="ApplyID" Hidden="true" />
                            <ext:BoundField DataField="UserName" HeaderText="申请人" />
                            <ext:BoundField DataField="UserDept" HeaderText="部门" />
                            <ext:BoundField DataField="UserPositon" HeaderText="职务" />
                            <ext:BoundField DataField="ContractStartDate" HeaderText="合同开始日期" />
                            <ext:BoundField DataField="ContractEndDate" HeaderText="合同结束日期" />
                            <ext:BoundField DataField="LeaveDate" HeaderText="拟离职日期" />
                            <ext:BoundField DataField="LeaveSeason" HeaderText="离职原因" DataTooltipField="LeaveSeason" ExpandUnusedSpace="true" />
                            <ext:BoundField DataField="ApplyTime" HeaderText="申请时间" />
                            <ext:BoundField DataField="IsApprove" HeaderText="审批状态" />
                            <ext:BoundField DataField="ApproveResult" HeaderText="审批结果" />
                            <ext:BoundField DataField="ApproveTime" HeaderText="审批时间" />
                            <ext:LinkButtonField Width="38px" Text="审批" CommandName="Approve" />
                        </Columns>
                    </ext:Grid>
                </Items>
            </ext:Panel>
        </Items>
    </ext:Panel>
    <ext:Window ID="wndApprove" Title="离职审批" Popup="false" EnableIFrame="true" IFrameUrl="about:blank"
        Target="Parent" runat="server" IsModal="true" EnableConfirmOnClose="true" Height="550px"
        Width="700px" OnClose="wndApprove_Close">
    </ext:Window>
    </form>
</body>
</html>
