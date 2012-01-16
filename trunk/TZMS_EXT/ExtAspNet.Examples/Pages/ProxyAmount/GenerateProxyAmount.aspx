﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GenerateProxyAmount.aspx.cs"
    Inherits="TZMS.Web.GenerateProxyAmount" %>

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
                            <ext:DropDownList ID="ddlstProxyAmounter" runat="server" Label="代帐会计">
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
                <Toolbars>
                    <ext:Toolbar ID="toolApp" runat="server">
                        <Items>
                            <ext:Button ID="btnGenerateDZ" Text="代帐费生成" ToolTip="代帐费生成" Icon="Add" runat="server" OnClick="btnGenerateDZ_Click">
                            </ext:Button>
                            <ext:Label ID="Label11" runat="server" Text="生成">
                            </ext:Label>
                            <ext:DatePicker ID="dpkGenerateDZDate" ShowLabel="false" runat="server" DateFormatString="yyyy-MM">
                            </ext:DatePicker>
                            <ext:Label ID="Label2" runat="server" Text="代帐费">
                            </ext:Label>
                            <ext:Button ID="btnGenerateNJ" Text="年检费生成" ToolTip="年检费生成" Icon="Add" runat="server" OnClick="btnGenerateNJ_Click">
                            </ext:Button>
                            <ext:Label ID="Label5" runat="server" Text="生成">
                            </ext:Label>
                            <ext:DatePicker ID="dpkGenerateNJDate" ShowLabel="false" runat="server" DateFormatString="yyyy">
                            </ext:DatePicker>
                            <ext:Label ID="Label6" runat="server" Text="年检费">
                            </ext:Label>
                        </Items>
                    </ext:Toolbar>
                </Toolbars>
                <Items>
                    <ext:Grid ID="gridProxyAmount" Title="Grid1" ShowBorder="true" ShowHeader="false"
                        AllowPaging="true" runat="server" IsDatabasePaging="true" EnableRowNumber="True"
                        AutoHeight="true" OnPageIndexChange="gridProxyAmount_PageIndexChange" OnRowCommand="gridProxyAmount_RowCommand"
                        OnRowDataBound="gridProxyAmount_RowDataBound">
                        <Columns>
                            <ext:BoundField DataField="ObjectID" Hidden="true" />
                            <ext:BoundField DataField="ProxyAmountID" Hidden="true" />
                            <ext:BoundField DataField="TemplateType" HeaderText="费用类型" />
                            <ext:BoundField DataField="ProxyAmountUnitName" HeaderText="交款单位" ExpandUnusedSpace="true"
                                DataTooltipField="ProxyAmountUnitName" />
                            <ext:BoundField DataField="ProxyAmounterName" HeaderText="代帐人" />
                            <ext:BoundField DataField="CNMoney" Hidden="true" HeaderText="金额(大写)" />
                            <ext:BoundField DataField="ENMoney" HeaderText="金额(小写)" />
                            <ext:BoundField DataField="Sument" HeaderText="收款事由" DataTooltipField="Sument" />
                            <ext:BoundField DataField="CollectMethod" HeaderText="收款方式" />
                            <ext:BoundField DataField="OpeningDate" HeaderText="开票日期" />
                            <ext:BoundField DataField="CollecterName" HeaderText="收款单位" />
                            <ext:BoundField DataField="State" HeaderText="代帐单状态" />
                            <ext:LinkButtonField Width="38px" Text="查看" CommandName="View" />
                            <ext:LinkButtonField Width="38px" Text="编辑" CommandName="Edit" />
                            <ext:LinkButtonField Width="38px" Text="删除" ConfirmTarget="Parent" ConfirmText="确定删除该代账费申请单?" />
                        </Columns>
                    </ext:Grid>
                </Items>
            </ext:Panel>
        </Items>
    </ext:Panel>
    <ext:Window ID="wndProxyAmount" Title="代账单" Popup="false" EnableIFrame="true" IFrameUrl="about:blank"
        Target="Parent" runat="server" IsModal="true" EnableConfirmOnClose="true" Height="500px"
        Width="700px" onclose="wndProxyAmount_Close">
    </ext:Window>
    </form>
</body>
</html>
