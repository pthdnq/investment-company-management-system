﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BankLoanAuditResult.aspx.cs"
    Inherits="TZMS.Web.Pages.BankLoanPages.BankLoanAuditResult" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>审核结果列表</title>
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
                                <ext:ListItem Text="待审核" Value="1"/>
                                <ext:ListItem Text="审核中" Value="3" />
                                <ext:ListItem Text="已通过" Value="4"  Selected="true"  />
                                <ext:ListItem Text="未通过" Value="2" />
                                <ext:ListItem Text="已终止" Value="8" />
                                <ext:ListItem Text="已删除" Value="9" />
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
                            <ext:Button ID="btnNew" Text="新增" Icon="Add" runat="server">
                            </ext:Button>
                            <ext:Button ID="btnDelete" Text="删除" Icon="Delete" runat="server" />
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
                            <ext:WindowField ExpandUnusedSpace="true" DataTextField="ProjectName" DataIFrameUrlFields="ObjectId"
                                DataIFrameUrlFormatString="BankLoanAuditResultView.aspx?ID={0}" DataWindowTitleField="ProjectName"
                                DataWindowTitleFormatString="{0}-查看" WindowID="wndNew" HeaderText="项目名称" />
                            <ext:TemplateField Width="66px" HeaderText="状态">
                                <ItemTemplate>
                                    <%# GetStatusName(DataBinder.Eval(Container.DataItem, "Status").ToString())%>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:BoundField Width="150px" DataField="Contact" HeaderText="联系方式" />
                            <ext:BoundField Width="70px" DataField="SignDate" HeaderText="签订日期" DataFormatString="{0:yyyy/MM/dd}" />
                            <ext:BoundField Width="70px" DataField="CustomerName" HeaderText="客户名称" />
                            <ext:BoundField Width="100px" DataField="LoanCompany" HeaderText="贷款公司" />
                            <ext:BoundField Width="80px" DataField="LoanAmountEx" HeaderText="贷款金额" />
                            <%--       <ext:BoundField Width="100px" DataField="LoanFee" HeaderText="贷款手续费" />--%>
                            <%--                            <ext:BoundField Width="100px" DataField="CollateralCompany" HeaderText="抵押物公司" />--%>
                            <%--            <ext:BoundField Width="105px" DataField="DownPayment" HeaderText="预付定金" />--%>
                            <ext:BoundField DataField="NextOperaterName" Width="70px" HeaderText="当前执行人" />
                            <ext:WindowField Width="38px" Text="查看" DataIFrameUrlFields="ObjectId" DataIFrameUrlFormatString="BankLoanAuditResultView.aspx?ID={0}"
                                Title="查看" WindowID="wndView" />
                            <ext:WindowField Width="76px" Text="业务移交" DataIFrameUrlFields="ObjectId" DataIFrameUrlFormatString="BankLoanAuditTransfer.aspx?Type=Owner&ID={0}"
                                Title="业务移交" WindowID="Window1" />
                        </Columns>
                    </ext:Grid>
                </Items>
            </ext:Panel>
        </Items>
    </ext:Panel>
    <ext:Window ID="wndView" Popup="false" EnableIFrame="true" IFrameUrl="about:blank"
        Target="Parent" runat="server" IsModal="true" Height="443px" Width="550px" OnClose="wndNew_Close">
    </ext:Window>
    <ext:Window ID="Window1" Popup="false" EnableIFrame="true" IFrameUrl="about:blank"
        Target="Parent" runat="server" IsModal="true" Height="490px" Width="590px" OnClose="wndNew_Close">
    </ext:Window>
    </form>
</body>
</html>
