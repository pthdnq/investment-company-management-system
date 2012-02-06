﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CashFlowStatementList.aspx.cs"
    Inherits="TZMS.Web.Pages.CashFlow.CashFlowStatementList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>CashFlowStatementList</title>
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
                            <ext:DatePicker ID="dpkStartTime" runat="server" Label="开始日期">
                            </ext:DatePicker>
                            <ext:DatePicker ID="dpkEndTime" runat="server" Label="结束日期">
                            </ext:DatePicker>
                            <ext:Button ID="btnSearch" runat="server" Icon="Magnifier" Text="查询" OnClick="ttbSearch_Trigger1Click">
                            </ext:Button>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow Hidden="true">
                        <Items>
                            <ext:DropDownList Hidden="true" ID="ddlstState" runat="server" Label="状态">
                                <ext:ListItem Text="待审核" Value="1" Selected="true" />
                                <ext:ListItem Text="审核中" Value="3" />
                                <ext:ListItem Text="未通过" Value="2" />
                                <%--      <ext:ListItem Text="待确认" Value="4" Selected="true" />
                                <ext:ListItem Text="已确认" Value="5" />--%>
                                <%--     <ext:ListItem Text="已删除" Value="9" />--%>
                            </ext:DropDownList>
                            <ext:Label ID="Labeltmp2" runat="server" Hidden="true" />
                            <ext:Label ID="Labeltmp3" runat="server" Hidden="true" />
                        </Items>
                    </ext:FormRow>
                </Rows>
            </ext:Form>
            <ext:Panel ID="pelGrid" ShowBorder="True" ShowHeader="false" AnchorValue="100% -36"
                Layout="Fit" runat="server">
                <Toolbars>
                    <ext:Toolbar ID="toolUser" runat="server">
                        <Items>
                            <ext:Button ID="btnNew" Text="初始化资金" Icon="Add" runat="server">
                            </ext:Button>
                            <ext:Button ID="btnDelete" Hidden="true" Text="删除" Icon="Delete" runat="server" />
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
                            <ext:BoundField ExpandUnusedSpace="true" DataField="ProjectName" HeaderText="项目名称" />
                            <ext:BoundField Width="130px" DataField="DateFor" DataFormatString="{0:yyyy/MM/dd}"
                                HeaderText="日期" />
                            <ext:BoundField Width="90px" DataField="Amount" HeaderText="贷方(元)" />
                            <ext:BoundField Width="90px" DataField="Amount" HeaderText="借方(元)" />
                            <ext:BoundField Width="130px" DataField="RemainingAmount" HeaderText="余额(元)" />
                            <ext:BoundField Width="150px" DataField="Biz" HeaderText="业务类型" />
                            <ext:BoundField Hidden="true" Width="100px" DataField="Summary" HeaderText="项目摘要" />
                            <%--         <ext:WindowField Width="76px" Text="审核" DataIFrameUrlFields="ObjectId" DataIFrameUrlFormatString="FeePayAudit.aspx?ID={0}"
                                Title="审核" WindowID="wndNew" />--%>
                            <%--           <ext:LinkButtonField Hidden="true" Width="38px"  Text="删除" ConfirmText="确定删除该记录?" CommandName="Delete" />--%>
                        </Columns>
                    </ext:Grid>
                </Items>
            </ext:Panel>
        </Items>
    </ext:Panel>
    <ext:Window ID="wndNew" Popup="false" EnableIFrame="true" IFrameUrl="about:blank"
        Target="Parent" runat="server" IsModal="true" Height="154px" Width="550px" OnClose="wndNew_Close">
    </ext:Window>
    </form>
</body>
</html>
