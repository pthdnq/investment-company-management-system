<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProjectInfoList.aspx.cs" Inherits="TZMS.Web.Pages.BankLoanPages.ProjectInfoList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>项目情况列表</title>
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
                                <ext:ListItem Text="已审核" Value="0" />
                            </ext:DropDownList>
                            <ext:Label ID="Label1" runat="server" />
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
                            <ext:BoundField DataField="ObjetctId" HeaderText="ID" Hidden="true" />
                            <ext:BoundField Width="100px" DataField="CustomerName" HeaderText="客户名称" />
                            <ext:BoundField Width="100px" DataField="LoanCompany" HeaderText="贷款公司" />
                            <ext:BoundField Width="80px" DataField="LoanAmount" HeaderText="贷款金额" />
                            <ext:BoundField Width="105px" DataField="LoanFee" HeaderText="贷款手续费" />
                            <ext:BoundField Width="105px" DataField="CollateralCompany"  HeaderText="抵押物公司" />
                            <ext:BoundField Width="110px" DataField="SignDate" HeaderText="签订日期" />
                            <ext:BoundField Width="110px" DataField="DownPayment" HeaderText="预付订金" />
                            <ext:BoundField Width="110px" DataField="Contact" HeaderText="联系方式" />
                            <ext:TemplateField Width="38px" HeaderText="状态">
                                <ItemTemplate>
                                    <%# (DataBinder.Eval(Container.DataItem, "Status").ToString() == "1") ? "待确认" : "已确认"%>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:WindowField Width="114px" Text="提交项目进展" DataIFrameUrlFields="ObjetctId" DataIFrameUrlFormatString="ProjectInfo.aspx?ID={0}"
                                Title="提交项目进展" WindowID="wndNew" />
                            <ext:LinkButtonField Hidden="true" Width="38px"  Text="删除" ConfirmText="确定删除该记录?" CommandName="Delete" />
                        </Columns>
                    </ext:Grid>
                </Items>
            </ext:Panel>
        </Items>
    </ext:Panel>
    
    <ext:Window ID="wndNew" Popup="false" EnableIFrame="true" IFrameUrl="about:blank"
        Target="Parent" runat="server" IsModal="true" Height="429px" Width="590px" OnClose="wndNew_Close">
    </ext:Window>
    </form>
</body>
</html>
