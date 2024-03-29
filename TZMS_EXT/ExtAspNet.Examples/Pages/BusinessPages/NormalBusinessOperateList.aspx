﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NormalBusinessOperateList.aspx.cs"
    Inherits="TZMS.Web.NormalBusinessOperateList" %>

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
                            <ext:DropDownList ID="ddlstAproveState" runat="server" Label="业务状态">
                                <ext:ListItem Text="待办理" Value="0" Selected="true" />
                                <ext:ListItem Text="已办理" Value="1" />
                                <ext:ListItem Text="已转移" Value="2" />
                            </ext:DropDownList>
                            <ext:Button ID="btnSearch" runat="server" Text="查询" Icon="Magnifier" OnClick="btnSearch_Click">
                            </ext:Button>
                            <ext:Label ID="Label1" runat="server">
                            </ext:Label>
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
                            <ext:Label ID="Label4" runat="server">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                </Rows>
            </ext:Form>
            <ext:Panel ID="pelGrid" ShowBorder="True" ShowHeader="false" AnchorValue="100% -60"
                Layout="Fit" runat="server">
                <Items>
                    <ext:Grid ID="gridBusiness" Title="Grid1" ShowBorder="true" ShowHeader="false" AllowPaging="true"
                        runat="server" IsDatabasePaging="true" EnableRowNumber="True" AutoHeight="true"
                        OnPageIndexChange="gridBusiness_PageIndexChange" OnRowCommand="gridBusiness_RowCommand"
                        OnRowDataBound="gridBusiness_RowDataBound">
                        <Columns>
                            <ext:BoundField DataField="ObjectID" Hidden="true" />
                            <ext:BoundField DataField="BusinessID" Hidden="true" />
                            <ext:BoundField DataField="CompanyName" HeaderText="公司名称" ExpandUnusedSpace="true"
                                DataTooltipField="CompanyName" />
                            <ext:BoundField DataField="CurrentBusiness" HeaderText="当前办理流程" />
                            <ext:BoundField DataField="State" HeaderText="操作状态" />
                            <ext:BoundField DataField="CheckDateTime" HeaderText="操作时间" />
                            <ext:LinkButtonField Width="38px" Text="办理" CommandName="View" />
                            <ext:LinkButtonField Width="75px" Text="业务转移" CommandName="Transfer" />
                        </Columns>
                    </ext:Grid>
                </Items>
            </ext:Panel>
        </Items>
    </ext:Panel>
    <ext:Window ID="wndNewNormalBusiness" Title="办理普通业务" Popup="false" EnableIFrame="true"
        IFrameUrl="about:blank" Target="Parent" runat="server" IsModal="true" EnableConfirmOnClose="true"
        Height="550px" Width="700px" OnClose="wndNewNormalBusiness_Close">
    </ext:Window>
    <ext:Window ID="wndNormalBusinessTransfer" Title="普通业务转移" Popup="false" EnableIFrame="true"
        IFrameUrl="about:blank" Target="Parent" runat="server" IsModal="true" EnableConfirmOnClose="true"
        Height="580px" Width="700px" onclose="wndNormalBusinessTransfer_Close" >
    </ext:Window>
    </form>
</body>
</html>
