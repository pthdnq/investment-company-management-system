<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProbationYear.aspx.cs"
    Inherits="TZMS.Web.ProbationYear" %>

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
                    <ext:FormRow>
                        <Items>
                            <ext:TextBox ID="tbxSearch" runat="server" EmptyText="请输入姓名或账号查询" ShowLabel="false">
                            </ext:TextBox>
                            <ext:DropDownList ID="ddlstDept" runat="server" Label="部门名称">
                            </ext:DropDownList>
                            <ext:Button ID="btnSearch" runat="server" Text="查询" Icon="Magnifier" OnClick="btnSearch_Click"
                                ValidateForms="pelMain">
                            </ext:Button>
                            <ext:Label ID="label1" runat="server">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow>
                        <Items>
                            <ext:TextBox ID="tbxMinYear" runat="server" EmptyText="请输入最小转正年数" Label="最小年数" Regex="^[0-9]*$"
                                RegexMessage="只能输入数字!">
                            </ext:TextBox>
                            <ext:TextBox ID="tbxMaxYear" runat="server" EmptyText="请输入最大转正年数" Label="最大年数" Regex="^[0-9]*$"
                                RegexMessage="只能输入数字!">
                            </ext:TextBox>
                            <ext:Label ID="label2" runat="server">
                            </ext:Label>
                            <ext:Label ID="label3" runat="server">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                </Rows>
            </ext:Form>
            <ext:Panel ID="pelGrid" ShowBorder="True" ShowHeader="false" AnchorValue="100% -60"
                Layout="Fit" runat="server">
                <Items>
                    <ext:Grid ID="gridUser" Title="Grid1" ShowBorder="true" ShowHeader="false" AllowPaging="true"
                        runat="server" IsDatabasePaging="true" EnableRowNumber="True" AutoHeight="true"
                        OnPageIndexChange="gridUser_PageIndexChange" OnRowCommand="gridUser_RowCommand"
                        OnRowDataBound="gridUser_RowDataBound" Width="100%">
                        <Columns>
                            <ext:BoundField DataField="ObjectId" HeaderText="ID" Hidden="true" />
                            <ext:BoundField DataField="JobNo" HeaderText="工号" />
                            <ext:BoundField DataField="Name" HeaderText="姓名" />
                            <ext:BoundField DataField="AccountNo" HeaderText="账号" Hidden="true" />
                            <ext:TemplateField Width="60px" HeaderText="性别">
                                <ItemTemplate>
                                    <%# (Convert.ToBoolean(DataBinder.Eval(Container.DataItem,"Sex")) == true) ? "男" : "女" %>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:BoundField DataField="Dept" HeaderText="部门" />
                            <ext:BoundField DataField="ProbationTime" HeaderText="转正日期" />
                            <ext:BoundField HeaderText="转正年数" />
                            <ext:BoundField Width="145px" DataField="PhoneNumber" HeaderText="联系电话" />
                            <ext:BoundField DataField="BackIpPhoneNumber" Width="145px" HeaderText="员工级别" />
                            <ext:BoundField Width="150px" DataField="Email" HeaderText="邮箱" />
                        </Columns>
                    </ext:Grid>
                </Items>
            </ext:Panel>
        </Items>
    </ext:Panel>
    </form>
</body>
</html>
