<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerList.aspx.cs" Inherits="TZMS.Web.Pages.CashFlow.CustomerList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>客户一览表</title>
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
                            <ext:TextBox Label="项目名称" ShowLabel="false" runat="server" EmptyText="请输入客户姓名查询"
                                ID="ttbSearch" />
                            <ext:Button ID="btnSearch" runat="server" Icon="Magnifier" Text="查询" OnClick="ttbSearch_Trigger1Click">
                            </ext:Button>
                            <ext:DatePicker Hidden="true" ID="dpkStartTime" runat="server" Label="开始日期">
                            </ext:DatePicker>
                            <ext:DatePicker Hidden="true" ID="dpkEndTime" runat="server" Label="结束日期">
                            </ext:DatePicker>
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
                            <ext:Label Hidden="true" ID="Labeltmp2" runat="server" />
                            <ext:Label Hidden="true" ID="Labeltmp3" runat="server" />
                        </Items>
                    </ext:FormRow>
                </Rows>
            </ext:Form>
            <ext:Panel ID="pelGrid" ShowBorder="True" ShowHeader="false" AnchorValue="100% -36"
                Layout="Fit" runat="server">
                <Toolbars>
                    <ext:Toolbar ID="toolUser" runat="server" Hidden="true">
                        <Items>
                            <ext:Button ID="btnNew" Text="初始化资金" Icon="Add" runat="server">
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
                            <ext:BoundField DataField="ObjectId" Hidden="true" />
                            <%--        <ext:BoundField DataField="Name" HeaderText="姓名" Width="73px" />--%>
                            <ext:WindowField Width="76px" DataTextField="Name" DataIFrameUrlFields="ObjectId"
                                DataIFrameUrlFormatString="CustomerInvestmentLoanInfo.aspx?ID={0}" Title="借款信息查看"
                                WindowID="wndNew" HeaderText="客户名称" />
                            <ext:BoundField DataField="MobilePhone" HeaderText="手机" Width="101px" />
                            <ext:BoundField DataField="CreditScore" HeaderText="星级" Width="95px" />
                            <ext:BoundField DataField="CreditScore" HeaderText="积分" Width="95px" />
                            <ext:TemplateField Width="60px" HeaderText="借款状态">
                                <ItemTemplate>
                                    <%# (DataBinder.Eval(Container.DataItem,"Status").ToString() == "1") ? "借款中" : "已结清" %>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:BoundField DataField="Remark" ExpandUnusedSpace="true" HeaderText="备注" />
                            <ext:WindowField Width="76px" Text="编辑" DataIFrameUrlFields="ObjectId" DataIFrameUrlFormatString="CustomerEdit.aspx?ID={0}"
                                Title="编辑" WindowID="wndEdit" />
                            <%--           <ext:LinkButtonField Hidden="true" Width="38px"  Text="删除" ConfirmText="确定删除该记录?" CommandName="Delete" />--%>
                        </Columns>
                    </ext:Grid>
                </Items>
            </ext:Panel>
        </Items>
    </ext:Panel>
    <ext:Window ID="wndEdit" Popup="false" EnableIFrame="true" IFrameUrl="about:blank"
        Target="Parent" runat="server" IsModal="true" Height="164px" Width="530px" OnClose="wndNew_Close">
    </ext:Window>
    <ext:Window ID="wndNew" Popup="false" EnableIFrame="true" IFrameUrl="about:blank"
        Target="Parent" runat="server" IsModal="true" Height="554px" Width="830px" OnClose="wndNew_Close">
    </ext:Window>
    </form>
</body>
</html>
