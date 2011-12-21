﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LeaderAuditList.aspx.cs" Inherits="TZMS.Web.Pages.FolkFinancingPages.LeaderAuditList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>领导审核列表</title>
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
                            <ext:TextBox Label="项目名称" ShowLabel="false" runat="server" EmptyText="请输入借款人姓名查询"
                                ID="ttbSearch" />
                            <ext:DropDownList ID="ddlstState" runat="server" Label="状态">
                                <ext:ListItem Text="待审核" Value="1" Selected="true" />
                                <%--            <ext:ListItem Text="审核中" Value="3" />--%>
                                <ext:ListItem Text="已审核" Value="4" />
                                <%--  <ext:ListItem Text="已确认" Value="5" />--%>
                                <ext:ListItem Text="未通过" Value="2" />
                                <%--        <ext:ListItem Text="已删除" Value="9" />--%>
                            </ext:DropDownList>
                            <ext:Button ID="btnSearch" runat="server" Icon="Magnifier" Text="查询" OnClick="ttbSearch_Trigger1Click">
                            </ext:Button>
                            <ext:Label ID="Label4" runat="server" />
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow>
                        <Items>
                            <ext:DatePicker ID="dpkStartTime" runat="server" Label="开始日期">
                            </ext:DatePicker>
                            <ext:DatePicker ID="dpkEndTime" runat="server" Label="结束日期">
                            </ext:DatePicker>
                            <ext:Label ID="Label1" runat="server" />
                            <ext:Label ID="Label2" runat="server" />
                        </Items>
                    </ext:FormRow>
                </Rows>
            </ext:Form>
            <ext:Panel ID="pelGrid" ShowBorder="True" ShowHeader="false" AnchorValue="100% -36"
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
                            <ext:BoundField Width="90px" DataField="BorrowerNameA" HeaderText="借款人" />
                            <ext:BoundField Width="90px" DataField="Lenders" HeaderText="出借人" />
                            <ext:BoundField Width="90px" DataField="Guarantee" HeaderText="担保人" />
                            <ext:BoundField Width="105px" DataField="LoanAmount" HeaderText="借款金额" />
                            <ext:BoundField Width="100px" DataField="LoanDate" DataFormatString="{0:yyyy/MM/dd}" HeaderText="借款日期" />
                            <ext:BoundField Width="110px" DataField="DueDateForPay" DataFormatString="每月{0}日" HeaderText="应付款日" />
                            <ext:BoundField Width="110px" DataField="ContactPhone" HeaderText="联系电话" />
                                   <ext:BoundField DataField="NextOperaterName" Width="75px" HeaderText="当前执行人" />
                            <ext:TemplateField Width="70px" HeaderText="状态">
                                <ItemTemplate>
                                  <%# GetStatusName(DataBinder.Eval(Container.DataItem, "Status").ToString())%>
                                </ItemTemplate>
                            </ext:TemplateField>
                              <ext:BoundField ExpandUnusedSpace="true" DataField="Remark" HeaderText="备注" />
                 
                            <ext:WindowField Width="38px" Text="审核" DataIFrameUrlFields="ObjectId" DataIFrameUrlFormatString="LeaderAudit.aspx?Type=Edit&ID={0}"
                                Title="审核" WindowID="wndNew" />
                            <ext:LinkButtonField Hidden="true" Width="38px" Text="删除" ConfirmText="确定删除该员工?" CommandName="Delete" />
                        </Columns>
                    </ext:Grid>
                </Items>
            </ext:Panel>
        </Items>
    </ext:Panel>
  
    <ext:Window ID="wndNew" Popup="false" EnableIFrame="true" IFrameUrl="about:blank"
        Target="Parent" runat="server" IsModal="true" Height="480px" Width="550px" OnClose="wndNew_Close">
    </ext:Window>
    </form>
</body>
</html>
