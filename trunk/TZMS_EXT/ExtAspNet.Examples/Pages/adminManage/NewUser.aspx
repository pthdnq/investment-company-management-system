<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewUser.aspx.cs" Inherits="TZMS.Web.NewUser" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <ext:PageManager ID="PageManager1" runat="server" />
    <ext:Panel ID="pelMain" runat="server" EnableBackgroundColor="true" BodyPadding="3px"
        EnableLargeHeader="true" Height="317px" Title="Panel" AutoScroll="false" ShowBorder="true"
        ShowHeader="false">
        <!--工具栏-->
        <Toolbars>
            <ext:Toolbar ID="Toolbar1" runat="server">
                <Items>
                    <ext:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Icon="Disk" Text="保存">
                    </ext:Button>
                </Items>
            </ext:Toolbar>
        </Toolbars>
        <Items>
            <ext:Form EnableBackgroundColor="true" ShowHeader="false" BodyPadding="5px" ID="Form2"
                runat="server">
                <Rows>
                    <ext:FormRow ColumnWidths="50% 50%">
                        <Items>
                            <ext:TextBox ID="tbxAccountNo" Label="账号" ShowRedStar="true" Required="true" runat="server">
                            </ext:TextBox>
                            <ext:TextBox ID="tbxJobNo" Label="工号" ShowRedStar="true" Required="true" runat="server">
                            </ext:TextBox>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ColumnWidths="50% 50%">
                        <Items>
                            <ext:TextBox ID="tbxName" Label="姓名" ShowRedStar="true" Required="true" runat="server">
                            </ext:TextBox>
                            <ext:RadioButtonList ID="rblSex" Label="性别" runat="server">
                                <ext:RadioItem Selected="true" Text="男" Value="1" />
                                <ext:RadioItem Text="女" Value="0" />
                            </ext:RadioButtonList>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ColumnWidths="50% 50%">
                        <Items>
                            <ext:DropDownList ID="ddlstDept" Label="所在部门" ShowRedStar="true" Required="true"
                                runat="server">
                            </ext:DropDownList>
                            <ext:TextBox ID="tbxPosition" Label="职位" runat="server">
                            </ext:TextBox>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ColumnWidths="50% 50%">
                        <Items>
                            <ext:DatePicker ID="dpkEntryDate" Label="入职时间" ShowRedStar="true" Required="true"
                                runat="server">
                            </ext:DatePicker>
                            <ext:DatePicker ID="dpkBirthday" Label="出生年月" runat="server">
                            </ext:DatePicker>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ColumnWidths="50% 50%">
                        <Items>
                            <ext:TextBox ID="tbxGraduatedSchool" Label="毕业院校" runat="server">
                            </ext:TextBox>
                            <ext:DropDownList ID="ddlstEducational" Label="学历" runat="server">
                                <ext:ListItem Text="博士及以上" Value="博士及以上" />
                                <ext:ListItem Text="硕士" Value="硕士" />
                                <ext:ListItem Text="本科" Value="本科" Selected="true" />
                                <ext:ListItem Text="大专" Value="大专" />
                                <ext:ListItem Text="大专以下" Value="大专以下" />
                            </ext:DropDownList>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ColumnWidths="50% 50%">
                        <Items>
                            <ext:TextBox ID="tbxWorkYear" Label="工作年限" runat="server">
                            </ext:TextBox>
                            <ext:RadioButtonList ID="rblState" Label="员工状态" runat="server">
                                <ext:RadioItem Selected="true" Text="在职" Value="1" />
                                <ext:RadioItem Text="离职" Value="0" />
                            </ext:RadioButtonList>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ColumnWidths="50% 50%">
                        <Items>
                            <ext:TextBox ID="tbxPhoneNumber" Label="联系电话" runat="server">
                            </ext:TextBox>
                            <ext:TextBox ID="tbxBackupPhoneNumber" Label="备用联系电话" runat="server">
                            </ext:TextBox>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ColumnWidths="100%">
                        <Items>
                            <ext:TextBox ID="tbxEmail" Label="电子邮箱" runat="server">
                            </ext:TextBox>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ColumnWidths="100%">
                        <Items>
                            <ext:TextBox ID="tbxAddress" Label="住址" runat="server">
                            </ext:TextBox>
                        </Items>
                    </ext:FormRow>
                </Rows>
            </ext:Form>
        </Items>
    </ext:Panel>
    </form>
</body>
</html>
