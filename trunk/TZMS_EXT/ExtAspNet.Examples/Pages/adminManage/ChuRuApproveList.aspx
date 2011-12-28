<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChuRuApproveList.aspx.cs"
    Inherits="TZMS.Web.ChuRuApproveList" %>

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
            <ext:Form ID="Form2" ShowBorder="False" LabelWidth="55px" BodyPadding="5px" AnchorValue="100%"
                EnableBackgroundColor="true" ShowHeader="False" runat="server">
                <Rows>
                    <ext:FormRow ID="FormRow1" runat="server">
                        <Items>
                            <ext:TextBox ID="tbxSearch" runat="server" EmptyText="请输入登记人查询" ShowLabel="false">
                            </ext:TextBox>
                            <ext:DropDownList ID="ddlstDept" runat="server" Label="部门名称">
                            </ext:DropDownList>
                            <ext:DropDownList ID="ddlstState" runat="server" Label="登记状态">
                                <ext:ListItem Text="全部" Value="3" Selected="true" />
                                <ext:ListItem Text="未登记" Value="0" />
                                <ext:ListItem Text="已登记" Value="1" />
                            </ext:DropDownList>
                            <ext:Button ID="btnSearch" runat="server" Text="查询" Icon="Magnifier" OnClick="btnSearch_Click">
                            </ext:Button>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow>
                        <Items>
                            <ext:DatePicker ID="dpkStartTime" runat="server" Label="开始日期">
                            </ext:DatePicker>
                            <ext:DatePicker ID="dpkEndTime" runat="server" Label="结束日期">
                            </ext:DatePicker>
                            <ext:Label ID="Label2" runat="server">
                            </ext:Label>
                            <ext:Label ID="Label3" runat="server">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                </Rows>
            </ext:Form>
            <ext:Panel ID="pelGrid" ShowBorder="True" ShowHeader="false" AnchorValue="100% -60"
                Layout="Fit" runat="server">
                <Items>
                    <ext:Grid ID="gridChuRu" Title="Grid1" ShowBorder="true" ShowHeader="false" AllowPaging="true"
                        runat="server" IsDatabasePaging="true" EnableRowNumber="True" AutoHeight="true"
                        OnPageIndexChange="gridChuRu_PageIndexChange" OnRowCommand="gridChuRu_RowCommand"
                        OnRowDataBound="gridChuRu_RowDataBound">
                        <Columns>
                            <ext:BoundField DataField="ObjectID" Hidden="true" />
                            <ext:BoundField DataField="UserName" HeaderText="出门登记人" />
                            <ext:BoundField DataField="UserDept" HeaderText="部门" />
                            <ext:BoundField DataField="OutTime" HeaderText="出门登记时间" />
                            <ext:BoundField DataField="InUserName" HeaderText="入门登记人" />
                            <ext:BoundField DataField="InTime" HeaderText="出门登记时间" />
                            <ext:BoundField DataField="OutReason" HeaderText="出门事由" DataTooltipField="OutReason"
                                ExpandUnusedSpace="true" />
                            <ext:BoundField DataField="State" Hidden="true" />
                            <ext:LinkButtonField Width="70px" Text="入门登记" CommandName="RMDJ" ConfirmText="您确定入门登记吗?" />
                        </Columns>
                    </ext:Grid>
                </Items>
            </ext:Panel>
        </Items>
    </ext:Panel>
    </form>
</body>
</html>
