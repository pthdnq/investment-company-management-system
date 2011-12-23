<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FinancingContract.aspx.cs"
    Inherits="TZMS.Web.Pages.FolkFinancingPages.FinancingContract" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>FinancingContract</title>
</head>
<body>
    <form id="form1" runat="server">
    <ext:PageManager ID="PageManager1" runat="server" AutoSizePanelID="pelMain" />
    <ext:Panel ID="pelMain" runat="server" EnableBackgroundColor="true" BodyPadding="3px"
        EnableLargeHeader="true" Title="Panel" AutoScroll="false" ShowBorder="true" Layout="Fit"
        ShowHeader="false">
        <!--工具栏-->
        <Toolbars>
            <ext:Toolbar ID="Toolbar1" runat="server">
                <Items>
                    <ext:Button ID="btnClose" EnablePostBack="false" Text="关闭" runat="server" Icon="SystemClose" />
                    <ext:ToolbarSeparator ID="ToolbarSeparator2" runat="server" />
                    <%--  <ext:Button ID="btnSave" runat="server" ValidateForms="mainFrame" OnClick="btnSave_Click"
                        IconUrl="~/images/ico_16_xsht.gif" Text="提醒收款" />--%>
                </Items>
            </ext:Toolbar>
        </Toolbars>
        <Items>
            <ext:Form EnableBackgroundColor="true" ShowHeader="false" BodyPadding="5px" ID="mainFrame"
                runat="server" Hidden="true">
                <Rows>
                    <ext:FormRow>
                        <Items>
                            <ext:TwinTriggerBox runat="server" EmptyText="请输入项目名称查询" ShowLabel="false" ID="ttbSearch"
                                Trigger1Icon="Search" ShowTrigger2="false" OnTrigger1Click="ttbSearch_Trigger1Click" />
                            <ext:DropDownList ID="ddlstDept" AutoPostBack="true" runat="server" Label="部门名称"
                                OnSelectedIndexChanged="ddlstDept_SelectedIndexChanged" Hidden="true" />
                            <ext:DropDownList ID="ddlstState" AutoPostBack="true" runat="server" Label="状态" OnSelectedIndexChanged="ddlstState_SelectedIndexChanged">
                                <ext:ListItem Text="待确认" Value="1" Selected="true" />
                                <ext:ListItem Text="已确认" Value="0" />
                            </ext:DropDownList>
                            <ext:Label ID="Label1" runat="server" />
                        </Items>
                    </ext:FormRow>
                </Rows>
            </ext:Form>
            <ext:Panel ID="pelGrid" ShowBorder="True" ShowHeader="false" AnchorValue="100% -36"
                Layout="Fit" runat="server">
                <Toolbars>
                    <ext:Toolbar ID="toolUser" runat="server">
                        <Items>
                            <ext:Button ID="btnNew" Text="新增" Icon="Add" runat="server" />
                            <ext:Button ID="btnDelete" Hidden="true" Text="删除" Icon="Delete" runat="server" />
                        </Items>
                    </ext:Toolbar>
                </Toolbars>
                <Items>
                    <ext:Grid ID="gridData" Title="Grid1" ShowBorder="true" ShowHeader="false" AllowPaging="true"
                        PageSize="1" runat="server" IsDatabasePaging="true" EnableRowNumber="True" AutoHeight="true"
                        OnPageIndexChange="gridData_PageIndexChange" OnRowCommand="gridData_RowCommand"
                        OnRowDataBound="gridData_RowDataBound" Width="100%" RowHeight="100%" Height="324">
                        <Columns>
                            <ext:BoundField DataField="ObjectId" HeaderText="ID" Hidden="true" />
                            <%--     <ext:BoundField Width="70px" DataField="ProjectName" HeaderText="项目名称" /> --%>
                            <ext:BoundField Width="110px" DataTooltipField="PaymentAccount" DataField="PaymentAccount"
                                HeaderText="付款帐号" />
                            <ext:BoundField  ExpandUnusedSpace="true" DataTooltipField="PaymentAccount" DataField="ReceivablesAccount"
                                HeaderText="收款帐号" />
                            <ext:BoundField Width="90px" DataField="AmountOfPayment" HeaderText="支付金额" />
                            <ext:BoundField Width="68px" DataField="DateForPay" DataFormatString="{0:yyyy/MM/dd }"
                                HeaderText="实付账款日" />
                            <ext:BoundField Width="68px" DataField="DueDateForPay" DataFormatString="{0:yyyy/MM/dd }"
                                HeaderText="应付账款日" />
                            <%--   <ext:BoundField Width="110px" DataField="SubmitTime" DataFormatString="{0:yyyy/MM/dd HH:mm}"
                                HeaderText="提交时间" />
                            <ext:BoundField Width="80px" DataField="CreaterName" HeaderText="创建人" />--%>
                            <ext:BoundField DataField="NextOperaterName" Width="72px" HeaderText="当前执行人" />
                            <ext:TemplateField Width="56px" HeaderText="状态">
                                <ItemTemplate>
                                     <%# GetStatusName(DataBinder.Eval(Container.DataItem, "Status").ToString())%>
                                </ItemTemplate>
                            </ext:TemplateField>
                             <ext:WindowField   Width="38px" Text="编辑" DataIFrameUrlFields="ObjectId"
                                DataIFrameUrlFormatString="FinancingContractPayAdd.aspx?Type=Edit&ID={0}" Title="编辑" WindowID="Window1" />
                           
                            <ext:LinkButtonField Width="36px" Text="删除" ConfirmText="确定已确认该记录?" CommandName="Delete" />
                        </Columns>
                    </ext:Grid>
                </Items>
            </ext:Panel>
        </Items>
    </ext:Panel>
    <ext:Window ID="wndNew" Popup="false" EnableIFrame="true" IFrameUrl="about:blank"
        Target="Parent" runat="server" IsModal="true" Height="302px" Width="550px" OnClose="wndNew_Close">
    </ext:Window>
    <ext:Window ID="Window1" Popup="false" EnableIFrame="true" IFrameUrl="about:blank"
        Target="Parent" runat="server" IsModal="true" Height="302px" Width="550px" OnClose="wndNew_Close">
    </ext:Window>
    </form>
</body>
</html>
