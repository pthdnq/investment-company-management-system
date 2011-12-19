﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChuRuApplyList.aspx.cs" Inherits="TZMS.Web.ChuRuApplyList" %>

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
                            <ext:DatePicker ID="dpkStartTime" runat="server" Label="开始日期">
                            </ext:DatePicker>
                            <ext:DatePicker ID="dpkEndTime" runat="server" Label="结束日期">
                            </ext:DatePicker>
                            <ext:Button ID="btnSearch" runat="server" Text="查询" Icon="Magnifier" OnClick="btnSearch_Click">
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
                    <ext:Toolbar ID="toolApp" runat="server">
                        <Items>
                            <ext:Button ID="btnNewProxy" Text="出门登记" ToolTip="出门登记" Icon="Add" runat="server">
                            </ext:Button>
                        </Items>
                    </ext:Toolbar>
                </Toolbars>
                <Items>
                    <ext:Grid ID="gridChuRu" Title="Grid1" ShowBorder="true" ShowHeader="false" AllowPaging="true"
                        runat="server" IsDatabasePaging="true" EnableRowNumber="True" AutoHeight="true"
                        >
                        <Columns>
                            <ext:BoundField DataField="ObjectID" Hidden="true" />
                            <ext:BoundField DataField="PayUnitID" Hidden="true" />
                            <ext:BoundField DataField="PayUnitName" Width="220px" HeaderText="交款单位" />
                            <ext:BoundField DataField="ProxyAccountingName" HeaderText="代帐人" />
                            <ext:BoundField DataField="CNMoney" Hidden="true" HeaderText="金额(大写)" />
                            <ext:BoundField DataField="ENMoney" HeaderText="金额(小写)" />
                            <ext:BoundField DataField="Sument" HeaderText="收款事由" DataTooltipField="Sument" ExpandUnusedSpace="true" />
                            <ext:BoundField DataField="CollectMethod" Hidden="true" HeaderText="收款方式" />
                            <ext:BoundField DataField="OpeningDate" HeaderText="开票日期" />
                            <ext:BoundField HeaderText="收款单位" Hidden="true" />
                            <ext:BoundField DataField="ApproverID" HeaderText="当前执行人" />
                            <ext:BoundField DataField="State" HeaderText="申请状态" />
                            <ext:LinkButtonField Width="38px" Text="查看" CommandName="View" />
                            <ext:LinkButtonField Width="38px" Text="编辑" CommandName="Edit" />
                            <ext:LinkButtonField Width="38px" Text="删除" ConfirmTarget="Parent" ConfirmText="确定删除该代账费申请单?" />
                        </Columns>
                    </ext:Grid>
                </Items>
            </ext:Panel>
        </Items>
    </ext:Panel>
    <ext:Window ID="wndNewProxy" Title="报销审批" Popup="false" EnableIFrame="true" IFrameUrl="about:blank"
        Target="Parent" runat="server" IsModal="true" EnableConfirmOnClose="true" Height="500px"
        Width="700px" OnClose="wndNewProxy_Close">
    </ext:Window>
    </form>
</body>
</html>
