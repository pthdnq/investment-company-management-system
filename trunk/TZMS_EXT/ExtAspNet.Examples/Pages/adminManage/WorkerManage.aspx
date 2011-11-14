<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WorkerManage.aspx.cs" Inherits="TZMS.Web.WorkerManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>员工管理</title>
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
                            <ext:DropDownList ID="ddlstDept" AutoPostBack="true" runat="server" Label="部门名称"
                                OnSelectedIndexChanged="ddlstDept_SelectedIndexChanged">
                            </ext:DropDownList>
                            <ext:DropDownList ID="ddlstState" AutoPostBack="true" runat="server" Label="员工状态"
                                OnSelectedIndexChanged="ddlstState_SelectedIndexChanged">
                                <ext:ListItem Text="在职" Value="1" Selected="true" />
                                <ext:ListItem Text="离职" Value="0" />
                            </ext:DropDownList>
                            <ext:Button ID="btnSearch" runat="server" Text="查询" Icon="Magnifier" OnClick="btnSearch_Click">
                            </ext:Button>
                        </Items>
                    </ext:FormRow>
                </Rows>
            </ext:Form>
            <ext:Panel ID="pelGrid" ShowBorder="True" ShowHeader="false" AnchorValue="100% -36"
                Layout="Fit" runat="server">
                <Toolbars>
                    <ext:Toolbar ID="toolUser" runat="server">
                        <Items>
                            <ext:Button ID="btnNewUser" Text="新增员工" Icon="UserAdd" runat="server">
                            </ext:Button>
                        </Items>
                    </ext:Toolbar>
                </Toolbars>
                <Items>
                    <ext:Grid ID="gridUser" Title="Grid1" ShowBorder="true" ShowHeader="false" AllowPaging="true"
                        PageSize="1" runat="server" IsDatabasePaging="true" EnableRowNumber="True" AutoHeight="true"
                        OnPageIndexChange="gridUser_PageIndexChange" OnRowCommand="gridUser_RowCommand"
                        OnRowDataBound="gridUser_RowDataBound" Width="100%">
                        <Columns>
                            <ext:BoundField DataField="ObjectId"  HeaderText="ID" Hidden="true" />
                            <ext:BoundField Width="70px" DataField="JobNo" HeaderText="工号" />
                            <ext:BoundField Width="80px" DataField="Name" HeaderText="姓名" />
                            <ext:BoundField Width="80px" DataField="AccountNo" HeaderText="账号" />
                            <ext:TemplateField Width="60px" HeaderText="性别">
                                <ItemTemplate>
                                    <%# (Convert.ToBoolean(DataBinder.Eval(Container.DataItem,"Sex")) == true) ? "男" : "女" %>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:BoundField Width="80px" DataField="Dept" HeaderText="部门" />
                            <ext:BoundField Width="145px" DataField="PhoneNumber" HeaderText="联系电话" />
                            <ext:BoundField DataField="BackIpPhoneNumber" Width="145px" HeaderText="备用联系电话"  />
                            <ext:BoundField Width="150px" DataField="Email" HeaderText="邮箱" />
                            <ext:TemplateField Width="70px" HeaderText="员工状态">
                                <ItemTemplate>
                                    <%# (DataBinder.Eval(Container.DataItem,"State").ToString() == "1") ? "在职" : "离职" %>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:LinkButtonField Width="38px" Text="编辑" CommandName="Edit" />
                            <ext:LinkButtonField Width="38px" Text="权限" CommandName="Role" />
                            <ext:LinkButtonField Width="38px" Text="离职" ConfirmText="确定该员工离职?" CommandName="Leave" />
                            <ext:LinkButtonField Width="38px" Text="删除" ConfirmText="确定删除该员工?" CommandName="Delete" />
                        </Columns>
                    </ext:Grid>
                </Items>
            </ext:Panel>
        </Items>
    </ext:Panel>
    <ext:Window ID="wndRolesForUser" runat="server" Popup="false" WindowPosition="Center"
        IsModal="true" Title="权限编辑页面" Target="Parent" EnableIFrame="true" IFrameUrl="about:blank"
        Height="370px" Width="400px">
    </ext:Window>
    <ext:Window ID="wndNewUser" Popup="false" EnableIFrame="true" IFrameUrl="about:blank"
        Target="Parent" runat="server" IsModal="true" Height="349px" Width="550px" OnClose="wndNewUser_Close">
    </ext:Window>
    </form>
</body>
</html>
