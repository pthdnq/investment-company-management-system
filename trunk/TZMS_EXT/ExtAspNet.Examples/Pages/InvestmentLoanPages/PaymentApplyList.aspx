<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaymentApplyList.aspx.cs"
    Inherits="TZMS.Web.Pages.InvestmentLoanPages.PaymentApplyList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>借款申请</title>
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
                                <ext:ListItem Text="待审核" Value="1" Selected="true" />
                                <ext:ListItem Text="审核中" Value="3" />
                                <ext:ListItem Text="已通过" Value="4" />
                                <ext:ListItem Text="未通过" Value="2" />
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
            <ext:Panel ID="pelGrid" ShowBorder="True" ShowHeader="false" AnchorValue="100% -36"
                Layout="Fit" runat="server">
                <Toolbars>
                    <ext:Toolbar ID="toolUser" runat="server">
                        <Items>
                            <ext:Button ID="btnNew" Text="新增" Icon="Add" runat="server">
                            </ext:Button>
                            <ext:Button Hidden="true" ID="btnDelete" Text="删除" Icon="Delete" runat="server" />
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
                            <%--      <ext:WindowField DataTextField="ProjectName"   Width="120px" HeaderText="项目名称" DataIFrameUrlFields="ObjectId"
                                DataIFrameUrlFormatString="LoanContract.aspx?Type=View&ID={0}" Title="查看"
                                WindowID="wndView" />--%>
                            <ext:BoundField Width="120px" DataField="ProjectName" HeaderText="项目名称" />
                            <ext:BoundField Width="110px" DataField="BorrowerNameA" HeaderText="借款人（甲方）" />
                            <ext:BoundField Width="110px" DataField="PayerBName" HeaderText="付款人（乙方）" />
                            <ext:BoundField Width="90px" DataField="BorrowerPhone" HeaderText="借款联系电话" />
                            <ext:BoundField Width="80px" DataField="LoanAmount" HeaderText="借款金额" />
                            <ext:BoundField Width="125px" DataField="LoanDate" DataFormatString="{0:yyyy/MM/dd}"
                                HeaderText="借款日期" />
                                                            <ext:BoundField DataField="DueDateForPay" Width="35px" HeaderText="应付借款日" />
                            <ext:BoundField DataField="CreateTime" Width="125px" DataFormatString="{0:yyyy/MM/dd HH:mm}"
                                HeaderText="创建时间" />
                            <ext:TemplateField Width="70px" HeaderText="状态">
                                <ItemTemplate>
                                    <%# GetStatusName(DataBinder.Eval(Container.DataItem, "Status").ToString())%>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:WindowField Hidden="true" Width="38px" Text="编辑" DataIFrameUrlFields="ObjectId"
                                DataIFrameUrlFormatString="PaymentApplyEdit.aspx?Type=Edit&ID={0}" Title="编辑"
                                WindowID="wndNew" />
                            <ext:WindowField Text="查看"  Width="38px" HeaderText="" DataIFrameUrlFields="ObjectId"
                                DataIFrameUrlFormatString="LoanContract.aspx?Type=View&ID={0}" Title="查看" WindowID="wndView" />
                            <ext:LinkButtonField Width="38px" Text="删除" ConfirmText="确定删除该记录?" CommandName="Delete" />
                        </Columns>
                    </ext:Grid>
                </Items>
            </ext:Panel>
        </Items>
    </ext:Panel>
    <ext:Window ID="wndNew" Popup="false" EnableIFrame="true" IFrameUrl="about:blank"
        Target="Parent" runat="server" IsModal="true" Height="592px" Width="550px" OnClose="wndNew_Close">
    </ext:Window>
    <ext:Window ID="wndView" Popup="false" EnableIFrame="true" IFrameUrl="about:blank"
        Target="Parent" runat="server" IsModal="true" Height="622px" Width="550px" OnClose="wndNew_Close">
    </ext:Window>
    </form>
</body>
</html>
