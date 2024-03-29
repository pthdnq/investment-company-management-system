﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ContractViewList.aspx.cs" Inherits="TZMS.Web.Pages.FolkFinancingPages.ContractViewList" %>

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
            <ext:Form ID="Form2" ShowBorder="False" LabelWidth="65px" BodyPadding="5px" AnchorValue="100%"
                EnableBackgroundColor="true" ShowHeader="False" runat="server">
                <Rows>
                    <ext:FormRow>
                        <Items>
                            <ext:TextBox Label="项目名称" ShowLabel="false" runat="server" EmptyText="请输入借款人姓名查询"
                                ID="ttbSearch" />
                            <ext:DropDownList ID="ddlstState" runat="server" Label="状态">
                                <%--      <ext:ListItem Text="待审核" Value="1"/>--%>
                                <ext:ListItem Text="审核中" Value="3" />
                                <ext:ListItem Text="已通过" Value="5" Selected="true" />
                                <ext:ListItem Text="未通过" Value="2" />
                                <ext:ListItem Text="已终止" Value="8" />
                                <ext:ListItem Text="已删除" Value="9" />
                            </ext:DropDownList>
                            <ext:TextBox Label="应付账款日" ShowLabel="true" runat="server" EmptyText="输入1,2... ;0表示查询所有"
                                ID="tbSeachDueDay" MaxLength="2" MaxLengthMessage="最多只能输入2个数字！" Regex="^[0-9]*$"
                                RegexMessage="只能输入数字!" />
                            <%--         <ext:Label ID="Labeltmp1" runat="server" />--%>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow>
                        <Items>
                            <ext:DatePicker ID="dpkStartTime" runat="server" Label="开始日期">
                            </ext:DatePicker>
                            <ext:DatePicker ID="dpkEndTime" runat="server" Label="结束日期">
                            </ext:DatePicker>
                            <ext:Button ID="btnSearch" runat="server" Icon="Magnifier" Text="查询" OnClick="ttbSearch_Trigger1Click">
                            </ext:Button>
                            <%--  <ext:Label ID="Labeltmp2" runat="server" />--%>
                            <%--      <ext:Label ID="Labeltmp3" runat="server" />--%>
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
                            <ext:BoundField Width="80px" DataField="BorrowerNameA" HeaderText="借款人" />
                            <ext:BoundField Width="80px" DataField="Lenders" HeaderText="出款人" />
                            <ext:BoundField Width="80px" DataField="Guarantee" HeaderText="担保人" />
                            <ext:BoundField Width="105px" DataField="LoanAmountEx" HeaderText="借款金额" />
                            <ext:BoundField Width="80px" DataField="LoanDate" DataFormatString="{0:yyyy-MM-dd}"
                                HeaderText="借款日期" />
                            <ext:BoundField Width="80px" DataField="DueDateForPay" DataFormatString="每月{0}日"
                                HeaderText="应付账款日" />
                            <ext:BoundField Width="100px" DataField="ContactPhone" HeaderText="联系电话" />
                            <ext:BoundField DataField="NextOperaterName" Width="75px" HeaderText="当前执行人" />
                            <ext:TemplateField Width="70px" HeaderText="状态">
                                <ItemTemplate>
                                    <%# GetStatusName(DataBinder.Eval(Container.DataItem, "Status").ToString())%>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:WindowField Width="104px" Text="申请支付费用" DataIFrameUrlFields="ObjectId" DataIFrameUrlFormatString="FinancingContract.aspx?Type=Edit&ID={0}"
                                Title="申请支付费用" WindowID="wndNew" />
                            <ext:WindowField Width="66px" Text="业务移交" DataIFrameUrlFields="ObjectId" DataIFrameUrlFormatString="LeaderAuditTransfer.aspx?Type=Owner&ID={0}"
                                Title="业务移交" Hidden="true" WindowID="Window1" />
                            <ext:WindowField Width="38px" Text="查看" DataIFrameUrlFields="ObjectId" DataIFrameUrlFormatString="LeaderAudit.aspx?Type=View&ID={0}"
                                Title="查看" WindowID="wndView" />
                        </Columns>
                    </ext:Grid>
                </Items>
            </ext:Panel>
        </Items>
    </ext:Panel>
    <ext:Window ID="wndNew" Popup="false" EnableIFrame="true" IFrameUrl="about:blank"
        Target="Parent" runat="server" IsModal="true" Height="419px" Width="690px" OnClose="wndNew_Close">
    </ext:Window>
    <ext:Window ID="Window1" Popup="false" EnableIFrame="true" IFrameUrl="about:blank"
        Target="Parent" runat="server" IsModal="true" Height="480px" Width="550px" OnClose="wndNew_Close">
    </ext:Window>
    <ext:Window ID="wndView" Popup="false" EnableIFrame="true" IFrameUrl="about:blank"
        Target="Parent" runat="server" IsModal="true" Height="410px" Width="550px" OnClose="wndNew_Close">
    </ext:Window>
    </form>
</body>
</html>
