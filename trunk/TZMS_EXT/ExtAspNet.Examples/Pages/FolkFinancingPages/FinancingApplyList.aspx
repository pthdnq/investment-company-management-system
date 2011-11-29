<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FinancingApplyList.aspx.cs"
    Inherits="TZMS.Web.Pages.FolkFinancingPages.FinancingApplyList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>融资申请列表</title>
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
                            <ext:TwinTriggerBox runat="server" EmptyText="请输入项目名称查询" ShowLabel="false" ID="ttbSearch"
                                Trigger1Icon="Search" ShowTrigger2="false" OnTrigger1Click="ttbSearch_Trigger1Click" />
                            <ext:DropDownList ID="ddlstDept" AutoPostBack="true" runat="server" Label="部门名称"
                                OnSelectedIndexChanged="ddlstDept_SelectedIndexChanged" Hidden="true" />
                            <ext:DropDownList ID="ddlstState" AutoPostBack="true" runat="server" Label="状态" OnSelectedIndexChanged="ddlstState_SelectedIndexChanged">
                               <ext:ListItem Text="待审核" Value="1" Selected="true" />
                                <ext:ListItem Text="审核中" Value="0" />
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
                            <ext:BoundField DataField="ObjetctId" HeaderText="ID" Hidden="true" />
                            <ext:BoundField Width="90px" DataField="BorrowerNameA" HeaderText="借款人" />
                            <ext:BoundField Width="90px" DataField="Lenders" HeaderText="出款人" />
                            <ext:BoundField Width="90px" DataField="Guarantee" HeaderText="担保人" />
                            <ext:BoundField Width="105px" DataField="LoanAmount" HeaderText="借款金额" />
                            <ext:BoundField Width="100px" DataField="LoanDate" DataFormatString="{0:yyyy/MM/dd}" HeaderText="借款日期" />
                            <ext:BoundField Width="110px" DataField="DueDateForPay" DataFormatString="每月{0}日" HeaderText="应付款日" />
                            <ext:BoundField Width="110px" DataField="ContactPhone" HeaderText="联系电话" />
                            <ext:TemplateField Width="70px" HeaderText="状态">
                                <ItemTemplate>
                                    <%# (DataBinder.Eval(Container.DataItem,"Status").ToString() == "1") ? "待审核" : "审核中" %>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:WindowField Hidden="true" Width="38px" Text="编辑" DataIFrameUrlFields="ObjetctId" DataIFrameUrlFormatString="FinancingApplyEdit.aspx?Type=Edit&ID={0}"
                                Title="编辑" WindowID="wndNew" />
                            <ext:LinkButtonField Width="38px" Text="删除" ConfirmText="确定删除该记录?" CommandName="Delete" />
                        </Columns>
                    </ext:Grid>
                </Items>
            </ext:Panel>
        </Items>
    </ext:Panel>
  
    <ext:Window ID="wndNew" Popup="false" EnableIFrame="true" IFrameUrl="about:blank"
        Target="Parent" runat="server" IsModal="true" Height="379px" Width="550px" OnClose="wndNew_Close">
    </ext:Window>
    </form>
</body>
</html>
