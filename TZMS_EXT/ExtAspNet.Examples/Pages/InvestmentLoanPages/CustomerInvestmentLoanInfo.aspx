﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerInvestmentLoanInfo.aspx.cs"
    Inherits="TZMS.Web.Pages.InvestmentLoanPages.CustomerInvestmentLoanInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CustomerInvestmentLoanInfo</title>
</head>
<body>
    <form id="form1" runat="server">
    <ext:PageManager ID="PageManager1" AutoSizePanelID="pelMain" HideScrollbar="true"
        runat="server" />
    <ext:Panel ID="pelMain" runat="server" EnableBackgroundColor="true" BodyPadding="3px"
        EnableLargeHeader="true" Title="Panel" ShowBorder="false" ShowHeader="false"
        Layout="Anchor">
        <Toolbars>
            <ext:Toolbar ID="Toolbar1" runat="server">
                <Items>
                    <ext:Button ID="btnClose" EnablePostBack="false" Text="关闭" runat="server" Icon="SystemClose" />
                    <ext:ToolbarSeparator ID="ToolbarSeparator2" runat="server" />
                </Items>
            </ext:Toolbar>
        </Toolbars>
        <Items>
            <ext:Form ID="Form2" ShowBorder="False" LabelWidth="55px" BodyPadding="5px" AnchorValue="100%"
                EnableBackgroundColor="true" ShowHeader="False" runat="server">
                <Rows>
                    <ext:FormRow>
                        <Items>
                            <ext:TextBox Label="项目名称" ShowLabel="false" runat="server" EmptyText="请输入项目名称查询"
                                ID="ttbSearch" />
                            <ext:DropDownList ID="ddlstState" runat="server" Label="状态">
                                <ext:ListItem Text="待审核" Value="1" />
                                <ext:ListItem Text="审核中" Value="3" />
                                <ext:ListItem Text="已通过" Value="4"/>
                                 <ext:ListItem Text="已确认" Value="5"   Selected="true" />
                                <ext:ListItem Text="未通过" Value="2" />
                                <ext:ListItem Text="终止审核中" Value="7" />
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
                            <ext:Button ID="btnNew" Text="终止" Icon="Add" runat="server">
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
                            <ext:BoundField Width="120px" DataField="ProjectName" HeaderText="项目名称" />
                            <ext:BoundField Width="95px" DataField="BorrowerNameA" HeaderText="借款人（甲方）" />
                            <ext:BoundField Width="95px" DataField="PayerBName" HeaderText="付款人（乙方）" />
                            <ext:BoundField Width="90px" DataField="BorrowerPhone" HeaderText="借款联系电话" />
                            <ext:BoundField Width="66px" DataField="LoanAmountEx" HeaderText="借款金额" />
                            <ext:BoundField Width="105px" DataField="LoanDate" HeaderText="借款日期" DataFormatString="{0:yyyy/MM/dd hh:mm}" />
                            <ext:BoundField Width="105px" DataField="SubmitTime" HeaderText="处理时间" DataFormatString="{0:yyyy/MM/dd hh:mm}" />
                            <ext:TemplateField Width="66px" HeaderText="状态">
                                <ItemTemplate>
                                    <%# GetStatusName(DataBinder.Eval(Container.DataItem, "Status").ToString())%>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:WindowField Text="查看" Width="38px" HeaderText="" DataIFrameUrlFields="ObjectId"
                                DataIFrameUrlFormatString="LoanContract.aspx?Type=View&ID={0}" Title="查看" WindowID="wndNew" />
                            <%--                     <ext:WindowField Width="76px" Text="终止合同" DataIFrameUrlFields="ObjectId" DataIFrameUrlFormatString="LoanContract.aspx?Type=Stop&ID={0}"
                                Title="终止合同" WindowID="wndNew" />--%>
                            <%--     <ext:WindowField Width="76px" Text="还款进展" DataIFrameUrlFields="ObjectId" DataIFrameUrlFormatString="LoanContract.aspx?Type=Edit&ID={0}"
                                Title="还款进展" WindowID="wndNew" />--%>
                        </Columns>
                    </ext:Grid>
                </Items>
            </ext:Panel>
        </Items>
    </ext:Panel>
    <ext:Window ID="wndRolesForUser" runat="server" Popup="false" WindowPosition="Center"
        IsModal="true" Title="权限编辑页面" Target="Parent" EnableIFrame="true" IFrameUrl="about:blank"
        Height="370px" Width="400px">
    </ext:Window>
    <ext:Window ID="wndNew" Popup="false" EnableIFrame="true" IFrameUrl="about:blank"
        Target="Parent" runat="server" IsModal="true" Height="469px" Width="550px" OnClose="wndNew_Close">
    </ext:Window>
    </form>
</body>
</html>
