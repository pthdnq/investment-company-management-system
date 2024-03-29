﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProxyAmountMoneyManage.aspx.cs"
    Inherits="TZMS.Web.ProxyAmountMoneyManage" %>

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
                            <ext:TextBox ID="tbxSearch" runat="server" EmptyText="请输入交款单位查询" ShowLabel="false">
                            </ext:TextBox>
                            <ext:DropDownList ID="ddlstProxyAmounter" runat="server" Label="代账会计">
                            </ext:DropDownList>
                            <ext:Button ID="btnSearch" runat="server" Text="查询" Icon="Magnifier" OnClick="btnSearch_Click">
                            </ext:Button>
                            <ext:Label ID="label1" runat="server">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ID="FormRow2" runat="server">
                        <Items>
                            <ext:DatePicker ID="dpkStartTime" runat="server" Label="年份" DateFormatString="yyyy">
                            </ext:DatePicker>
                            <ext:DatePicker ID="dpkEndTime" runat="server" Label="月份" DateFormatString="MM">
                            </ext:DatePicker>
                            <ext:Label ID="Label3" runat="server">
                            </ext:Label>
                            <ext:Label ID="Label4" runat="server">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                </Rows>
            </ext:Form>
            <ext:Panel ID="pelGrid" ShowBorder="True" ShowHeader="false" AnchorValue="100% -60"
                Layout="Fit" runat="server">
                <Items>
                    <ext:Grid ID="gridProxyAmount" Title="Grid1" ShowBorder="true" ShowHeader="false"
                        AllowPaging="true" runat="server" IsDatabasePaging="true" EnableRowNumber="True"
                        AutoHeight="true" OnPageIndexChange="gridProxyAmount_PageIndexChange" OnRowCommand="gridProxyAmount_RowCommand"
                        OnRowDataBound="gridProxyAmount_RowDataBound">
                        <Columns>
                            <ext:BoundField DataField="ObjectID" Hidden="true" />
                            <ext:BoundField DataField="ProxyAmountID" Hidden="true" />
                            <ext:BoundField DataField="ProxyAmountUnitName" HeaderText="交款单位" ExpandUnusedSpace="true"
                                DataTooltipField="ProxyAmountUnitName" />
                            <ext:BoundField DataField="ProxyAmounterName" HeaderText="代账人" />
                            <ext:BoundField DataField="CNMoney" Hidden="true" HeaderText="金额(大写)" />
                            <ext:BoundField DataField="ENMoneyEx" HeaderText="金额(小写)" />
                            <ext:BoundField DataField="Sument" HeaderText="收款事由" DataTooltipField="Sument" />
                            <ext:BoundField DataField="CollectMethod" HeaderText="收款方式" />
                            <ext:BoundField DataField="OpeningDate" HeaderText="开票日期" />
                            <ext:BoundField DataField="CollecterName" HeaderText="收款单位" />
                            <ext:BoundField DataField="State" HeaderText="收款状态" />
                            <ext:LinkButtonField Width="75px" Text="确认收款" CommandName="View" ConfirmText="您确认收款嘛?" />
                        </Columns>
                    </ext:Grid>
                </Items>
            </ext:Panel>
        </Items>
    </ext:Panel>
    </form>
</body>
</html>
