<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CostConfirmList.aspx.cs"
    Inherits="TZMS.Web.CostConfirmList" %>

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
                            <ext:DropDownList ID="ddlstAproveState" runat="server" Label="确认状态">
                                <ext:ListItem Text="全部" Value="3" Selected="true" />
                                <ext:ListItem Text="待确认" Value="1" />
                                <ext:ListItem Text="已确认" Value="2" />
                            </ext:DropDownList>
                            <ext:DatePicker ID="dpkStartTime" runat="server" Label="开始日期">
                            </ext:DatePicker>
                            <ext:DatePicker ID="dpkEndTime" runat="server" Label="结束日期">
                            </ext:DatePicker>
                            <ext:Button ID="btnSearch" runat="server" Text="查询" Icon="Magnifier" OnClick="btnSearch_Click">
                            </ext:Button>
                        </Items>
                    </ext:FormRow>
                </Rows>
            </ext:Form>
            <ext:Panel ID="pelGrid" ShowBorder="True" ShowHeader="false" AnchorValue="100% -36"
                Layout="Fit" runat="server">
                <Items>
                    <ext:Grid ID="gridCostConfirm" Title="Grid1" ShowBorder="true" ShowHeader="false"
                        AllowPaging="true" runat="server" IsDatabasePaging="true" EnableRowNumber="True"
                        AutoHeight="true" OnPageIndexChange="gridCostConfirm_PageIndexChange" OnRowCommand="gridCostConfirm_RowCommand"
                        OnRowDataBound="gridCostConfirm_RowDataBound">
                        <Columns>
                            <ext:BoundField DataField="ObjectID" Hidden="true" />
                            <ext:BoundField DataField="ApplyID" Hidden="true" />
                            <ext:BoundField DataField="UserName" HeaderText="申请人" />
                            <ext:BoundField DataField="UserDept" HeaderText="部门" />
                            <ext:BoundField DataField="ApplyTime" HeaderText="申请时间" />
                            <ext:BoundField DataField="CompanyName" HeaderText="公司名称" DataTooltipField="CompanyName"
                                ExpandUnusedSpace="true" />
                            <ext:BoundField DataField="CostType" HeaderText="费用类型" />
                            <ext:BoundField DataField="ActualMoneyEx" HeaderText="实际金额" />
                            <ext:BoundField HeaderText="执行人" Hidden="true" />
                            <ext:BoundField HeaderText="审批结果" Hidden="true" />
                            <ext:BoundField DataField="ApproveState" HeaderText="确认状态" />
                            <ext:BoundField DataField="ApproveTime" HeaderText="确认时间" />
                            <ext:LinkButtonField Width="38px" Text="确认" CommandName="Confirm" />
                        </Columns>
                    </ext:Grid>
                </Items>
            </ext:Panel>
        </Items>
    </ext:Panel>
    <ext:Window ID="wndCostConfirm" Title="业务费用收取确认归档" Popup="false" EnableIFrame="true"
        IFrameUrl="about:blank" Target="Parent" runat="server" IsModal="true" EnableConfirmOnClose="true"
        Height="500px" Width="700px" OnClose="wndCostConfirm_Close">
    </ext:Window>
    </form>
</body>
</html>
