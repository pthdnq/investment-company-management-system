﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CostApproveList.aspx.cs"
    Inherits="TZMS.Web.CostApproveList" %>

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
                            <ext:TextBox ID="tbxSearch" runat="server" EmptyText="请输入公司名称查询" ShowLabel="false">
                            </ext:TextBox>
                            <ext:DropDownList ID="ddlstCostType" runat="server" Label="费用类型">
                                <ext:ListItem Text="全部" Value="-1" Selected="true" />
                                <ext:ListItem Text="预收定金" Value="0" />
                                <ext:ListItem Text="业务尾款" Value="1" />
                            </ext:DropDownList>
                            <ext:DropDownList ID="ddlstAproveState" runat="server" Label="确认状态">
                                <ext:ListItem Text="全部" Value="0" />
                                <ext:ListItem Text="待确认" Value="1" Selected="true" />
                                <ext:ListItem Text="已确认" Value="2" />
                            </ext:DropDownList>
                            <ext:Button ID="btnSearch" runat="server" Text="查询" Icon="Magnifier" OnClick="btnSearch_Click">
                            </ext:Button>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow2" runat="server">
                        <Items>
                            <ext:DropDownList ID="ddlstDept" runat="server" Label="部门名称">
                            </ext:DropDownList>
                            <ext:DatePicker ID="dpkStartTime" runat="server" Label="开始日期">
                            </ext:DatePicker>
                            <ext:DatePicker ID="dpkEndTime" runat="server" Label="结束日期">
                            </ext:DatePicker>
                            <ext:Label ID="Label1" runat="server">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                </Rows>
            </ext:Form>
            <ext:Panel ID="pelGrid" ShowBorder="True" ShowHeader="false" AnchorValue="100% -60"
                Layout="Fit" runat="server">
                <Items>
                    <ext:Grid ID="gridCostApprove" Title="Grid1" ShowBorder="true" ShowHeader="false"
                        AllowPaging="true" runat="server" IsDatabasePaging="true" EnableRowNumber="True"
                        AutoHeight="true" OnPageIndexChange="gridCostApprove_PageIndexChange" OnRowCommand="gridCostApprove_RowCommand"
                        OnRowDataBound="gridCostApprove_RowDataBound">
                        <Columns>
                            <ext:BoundField DataField="ObjectID" Hidden="true" />
                            <ext:BoundField DataField="ApplyID" Hidden="true" />
                            <ext:BoundField DataField="UserName" HeaderText="申请人" />
                            <ext:BoundField DataField="UserDept" HeaderText="部门" />
                            <ext:BoundField DataField="ApplyTime" HeaderText="申请时间" />
                            <ext:BoundField DataField="CompanyName" HeaderText="公司名称" DataTooltipField="CompanyName"
                                ExpandUnusedSpace="true" />
                            <ext:BoundField DataField="CostType" HeaderText="费用类型" />
                            <ext:BoundField DataField="ApplyMoneyEx" HeaderText="金额" />
                            <ext:BoundField DataField="ActualMoneyEx" HeaderText="实际金额" />
                            <ext:BoundField DataField="ApproveState" Width="60px" HeaderText="确认状态" />
                            <ext:BoundField DataField="ApproveOp" Width="60px" HeaderText="审批结果" Hidden="true" />
                            <ext:BoundField DataField="ApproveTime" Width="100px" HeaderText="确认时间" />
                            <ext:LinkButtonField Width="38px" Text="确认" CommandName="Approve" />
                        </Columns>
                    </ext:Grid>
                </Items>
            </ext:Panel>
        </Items>
    </ext:Panel>
    <ext:Window ID="wndCostApprove" Title="业务费用收取出纳确认" Popup="false" EnableIFrame="true"
        IFrameUrl="about:blank" Target="Parent" runat="server" IsModal="true" EnableConfirmOnClose="true"
        Height="500px" Width="700px" OnClose="wndCostApprove_Close">
    </ext:Window>
    </form>
</body>
</html>
