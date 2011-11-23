﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReceivablesInfoList.aspx.cs"
    Inherits="TZMS.Web.Pages.InvestmentLoanPages.ReceivablesInfoList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>合同列表</title>
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
                                <ext:ListItem Text="已确认" Value="2" Selected="true" />
                                <ext:ListItem Text="待确认" Value="1" />
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
                            <ext:Button ID="btnNew" Text="终止" Icon="Add" runat="server">
                            </ext:Button>
                            <ext:Button ID="btnDelete" Text="删除" Icon="Delete" runat="server" Hidden="true" />
                        </Items>
                    </ext:Toolbar>
                </Toolbars>
                <Items>
                    <ext:Grid ID="gridData" Title="Grid1" ShowBorder="true" ShowHeader="false" AllowPaging="true"
                        PageSize="1" runat="server" IsDatabasePaging="true" EnableRowNumber="True" AutoHeight="true"
                        OnPageIndexChange="gridData_PageIndexChange" OnRowCommand="gridData_RowCommand"
                        OnRowDataBound="gridData_RowDataBound" Width="100%">
                        <Columns>
                           <ext:BoundField DataField="ObjetctId" HeaderText="ID" Hidden="true"/>
                          <ext:BoundField Width="120px" DataField="ProjectName" HeaderText="项目名称" /> 
                            <ext:BoundField Width="85px" DataField="DueDateForReceivables"  DataFormatString="{0:yyyy/MM/dd}" HeaderText="实收款日" />
                            <ext:BoundField Width="85px" DataField="DateForReceivables" DataFormatString="{0:yyyy/MM/dd}" HeaderText="应收款日" />
                            <ext:BoundField Width="80px" DataField="AmountofpaidUp" HeaderText="实收金额" />
                            <ext:BoundField Width="120px" DataField="ReceivablesAccount" HeaderText="收款帐号/现金" />
                            <ext:BoundField Width="145px" DataField="Remark" HeaderText="备注" />
                            <ext:TemplateField Width="60px" HeaderText="状态">
                                <ItemTemplate>
                                    <%# (DataBinder.Eval(Container.DataItem, "Status").ToString() == "2") ? "已确认" : "待确认"%>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:WindowField Width="38px" Text="查看" DataIFrameUrlFields="ObjetctId" DataIFrameUrlFormatString="ReceivablesInfo.aspx?ID={0}"
                                Title="查看"  WindowID="wndNew"/>
                        </Columns>
                    </ext:Grid>
                </Items>
            </ext:Panel>
        </Items>
    </ext:Panel>
 
    <ext:Window ID="wndNew" Popup="false" EnableIFrame="true" IFrameUrl="about:blank"
        Target="Parent" runat="server" IsModal="true" Height="349px" Width="550px" OnClose="wndNew_Close">
    </ext:Window>
    </form>
</body>
</html>
