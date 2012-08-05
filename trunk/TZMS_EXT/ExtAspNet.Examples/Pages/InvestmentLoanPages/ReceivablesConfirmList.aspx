﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReceivablesConfirmList.aspx.cs"
    Inherits="TZMS.Web.Pages.InvestmentLoanPages.ReceivablesConfirmList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>收款确认</title>
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
                            <ext:TextBox Label="项目名称" ShowLabel="false" runat="server" EmptyText="请输入项目名称查询"
                                ID="ttbSearch" />
                            <ext:DropDownList ID="ddlstState" runat="server" Label="状态">
                                <%--      <ext:ListItem Text="待审核" Value="1"/>
                                <ext:ListItem Text="审核中" Value="3" />--%>
                                <ext:ListItem Text="待确认" Value="4" Selected="true" />
                                <ext:ListItem Text="已确认" Value="5" />
                                <%--     <ext:ListItem Text="已删除" Value="9" />--%>
                            </ext:DropDownList>
                            <ext:Button ID="btnSearch" runat="server" Icon="Magnifier" Text="查询" OnClick="ttbSearch_Trigger1Click">
                            </ext:Button>
                            <ext:Label ID="Labeltmp1" runat="server" />
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow>
                        <Items>
                            <ext:DatePicker ID="dpkStartTime" runat="server" Label="开始日期">
                            </ext:DatePicker>
                            <ext:DatePicker ID="dpkEndTime" runat="server" Label="结束日期">
                            </ext:DatePicker>
                            <ext:Label ID="Labeltmp2" runat="server" />
                            <ext:Label ID="Labeltmp3" runat="server" />
                        </Items>
                    </ext:FormRow>
                </Rows>
            </ext:Form>
            <ext:Panel ID="pelGrid" ShowBorder="True" ShowHeader="false" AnchorValue="100% -54"
                Layout="Fit" runat="server">
                <Toolbars>
                    <ext:Toolbar ID="toolUser" runat="server" Hidden="true">
                        <Items>
                            <ext:Button ID="btnNew" Text="终止" Icon="Add" runat="server">
                            </ext:Button>
                            <ext:Button ID="btnDelete" Text="删除" Icon="Delete" runat="server" Hidden="true" />
                        </Items>
                    </ext:Toolbar>
                </Toolbars>
                <Items>
                    <ext:Grid ID="gridData" Title="Grid1" ShowBorder="true" ShowHeader="false" AllowPaging="true"
                        PageSize="1" runat="server" IsDatabasePaging="true" EnableRowNumber="True" AutoHeight="true"
                        OnPageIndexChange="gridData_PageIndexChange" OnRowCommand="gridData_RowCommand"
                        OnRowDataBound="gridData_RowDataBound" Width="100%">
                        <Columns>
                            <ext:BoundField DataField="ObjectId" HeaderText="ID" Hidden="true" />
                            <ext:BoundField Width="130px" DataField="ProjectName" HeaderText="项目名称" />
                            <ext:BoundField Width="85px" DataField="DateForReceivables" DataFormatString="{0:yyyy/MM/dd}"
                                HeaderText="实收借款日" />
                            <ext:BoundField Width="85px" DataField="DueDateForReceivables" DataFormatString="{0:yyyy/MM/dd}"
                                HeaderText="应收借款日" />
                            <ext:BoundField Width="80px" DataField="AmountofpaidUpEx" HeaderText="实收金额" />
                            <ext:BoundField DataField="AccountingName" Width="75px" HeaderText="当前执行人" />
                            <ext:BoundField Width="120px" DataField="ReceivablesAccount" HeaderText="收款帐号或现金" />
                            <ext:BoundField ExpandUnusedSpace="true" DataField="Remark" HeaderText="备注" />
                            <ext:TemplateField Width="60px" HeaderText="状态">
                                <ItemTemplate>
                                    <%# GetStatusName(DataBinder.Eval(Container.DataItem, "Status").ToString())%>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:WindowField Width="38px" Text="确认" DataIFrameUrlFields="ObjectId" DataIFrameUrlFormatString="ReceivablesConfirm.aspx?ID={0}"
                                Title="确认" WindowID="wndNew" />
                            <ext:WindowField Width="38px" Text="查看" DataIFrameUrlFields="ObjectId" DataIFrameUrlFormatString="ReceivablesConfirm.aspx?Type=View&ID={0}"
                                Title="查看" WindowID="wndNew" />
                            <%--     <ext:LinkButtonField Width="38px"  Text="确认" ConfirmText="确定已确认该收款信息?" CommandName="Delete" />--%>
                        </Columns>
                    </ext:Grid>
                </Items>
            </ext:Panel>
        </Items>
    </ext:Panel>
    <ext:Window ID="wndNew" Popup="false" EnableIFrame="true" IFrameUrl="about:blank"
        Target="Parent" runat="server" IsModal="true" Height="364px" Width="550px" OnClose="wndNew_Close">
    </ext:Window>
    </form>
</body>
</html>
