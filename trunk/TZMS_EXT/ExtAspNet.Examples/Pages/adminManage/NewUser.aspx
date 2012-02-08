<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewUser.aspx.cs" Inherits="TZMS.Web.NewUser" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="x-ua-compatible" content="ie=8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <ext:PageManager ID="PageManager1" runat="server" AutoSizePanelID="pelMain" EnableAjax="false" />
    <ext:Panel ID="pelMain" runat="server" EnableBackgroundColor="true" BodyPadding="3px"
        EnableLargeHeader="true" Layout="Fit" Height="317px" Title="Panel" AutoScroll="false"
        ShowBorder="true" ShowHeader="false">
        <!--工具栏-->
        <Toolbars>
            <ext:Toolbar ID="Toolbar1" runat="server">
                <Items>
                    <ext:Button ID="btnSave" runat="server" ValidateForms="mainFrame" OnClick="btnSave_Click"
                        Icon="Disk" Text="保存">
                    </ext:Button>
                    <ext:Button ID="btnInitPsw" runat="server" Hidden="true" ValidateForms="mainFrame"
                        OnClick="btnInitPsw_Click" Icon="Key" Text="初始化密码">
                    </ext:Button>
                    <ext:Label ID="titleMention" runat="server" Hidden="true" Text="提示：初始密码为 1111">
                    </ext:Label>
                </Items>
            </ext:Toolbar>
        </Toolbars>
        <Items>
            <ext:Form EnableBackgroundColor="true" ShowHeader="false" BodyPadding="5px" ID="mainFrame"
                runat="server">
                <Rows>
                    <ext:FormRow ColumnWidths="50% 50%">
                        <Items>
                            <ext:TextBox ID="tbxAccountNo" Label="账号" ShowRedStar="true" Required="true" runat="server"
                                MaxLength="20" MaxLengthMessage="最多只能输入20个字母或数字！" Regex="^[a-zA-Z0-9]*$" RegexMessage="只能输入字母或数字!">
                            </ext:TextBox>
                            <ext:TextBox ID="tbxJobNo" Label="工号" ShowRedStar="true" Required="true" runat="server"
                                MaxLength="20" MaxLengthMessage="最多只能输入20个数字！" Regex="^[0-9]*$" RegexMessage="只能输入字母!">
                            </ext:TextBox>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ColumnWidths="50% 50%">
                        <Items>
                            <ext:TextBox ID="tbxName" Label="姓名" ShowRedStar="true" Required="true" runat="server"
                                MaxLength="20" MaxLengthMessage="最多只能输入20个字符！" Regex="^[a-zA-Z0-9\u4e00-\u9fa5]*$"
                                RegexMessage="不能输入特殊字符!">
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
                            <ext:TextBox ID="tbxPosition" Label="职位" runat="server" Required="true" ShowRedStar="true"
                                MaxLength="20" MaxLengthMessage="最多只能输入20个字符！">
                                <%-- Regex="^[a-zA-Z0-9\u4e00-\u9fa5]*$"--%>
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
                            <ext:TextBox ID="tbxBaseSalary" runat="server" Label="基本工资" Required="true" ShowRedStar="true"
                                Regex="^[0-9]*\.?[0-9]{1,2}$" RegexMessage="金额格式不正确!">
                            </ext:TextBox>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ColumnWidths="50% 50%">
                        <Items>
                            <ext:TextBox ID="tbxGraduatedSchool" Label="毕业院校" runat="server" MaxLength="50" MaxLengthMessage="最多只能输入50个字符！"
                                Regex="^[a-zA-Z0-9\u4e00-\u9fa5]*$" RegexMessage="不能输入特殊字符!">
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
                            <ext:TextBox ID="tbxWorkYear" Label="工作年限" runat="server" MaxLength="2" MaxLengthMessage="最多只能输入2个数字！"
                                Regex="^[0-9]*$" RegexMessage="只能输入数字!">
                            </ext:TextBox>
                            <ext:RadioButtonList ID="rblState" Label="员工状态" runat="server" AutoPostBack="True"
                                OnSelectedIndexChanged="rblState_SelectedIndexChanged">
                                <ext:RadioItem Selected="true" Text="在职" Value="1" />
                                <ext:RadioItem Text="离职" Value="0" />
                            </ext:RadioButtonList>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ColumnWidths="50% 50%">
                        <Items>
                            <ext:DatePicker ID="dpbProbationTime" Label="转正日期" runat="server" Required="true"
                                ShowRedStar="true">
                            </ext:DatePicker>
                            <ext:RadioButtonList ID="rblProbationState" Label="转正状态" runat="server" AutoPostBack="True"
                                OnSelectedIndexChanged="rblProbationState_SelectedIndexChanged">
                                <ext:RadioItem Text="已转正" Value="1" />
                                <ext:RadioItem Text="未转正" Selected="true" Value="0" />
                            </ext:RadioButtonList>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ColumnWidths="50% 50%">
                        <Items>
                            <ext:DatePicker ID="dpkLeaveTime" Label="离职日期" runat="server">
                            </ext:DatePicker>
                            <ext:Label ID="lblLeaveTime" runat="server" Hidden="true">
                            </ext:Label>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ColumnWidths="50% 50%">
                        <Items>
                            <ext:TextBox ID="tbxPhoneNumber" Label="联系电话" runat="server" MaxLength="20" MaxLengthMessage="最多只能输入20个字符！"
                                Regex="(\(?\d{3,4}\)?)?[\s-]?\d{7,8}[\s-]?\d{0,4}" RegexMessage="电话号码格式不正确!">
                            </ext:TextBox>
                            <ext:TextBox ID="tbxBackupPhoneNumber" Label="员工级别" runat="server" MaxLength="20"
                                MaxLengthMessage="最多只能输入20个字符！" Regex="(\(?\d{3,4}\)?)?[\s-]?\d{7,8}[\s-]?\d{0,4}"
                                RegexMessage="电话号码格式不正确!">
                            </ext:TextBox>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ColumnWidths="100%">
                        <Items>
                            <ext:TextBox ID="tbxEmail" Label="电子邮箱" runat="server" MaxLength="20" MaxLengthMessage="最多只能输入20个字符！"
                                Regex="^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$" RegexMessage="邮箱格式不正确!">
                            </ext:TextBox>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ColumnWidths="100%">
                        <Items>
                            <ext:TextBox ID="tbxAddress" Label="住址" runat="server" MaxLength="50" MaxLengthMessage="最多只能输入50个字符！"
                                Regex="^[a-zA-Z0-9\u4e00-\u9fa5]*$" RegexMessage="不能输入特殊字符!">
                            </ext:TextBox>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ColumnWidths="100%">
                        <Items>
                            <ext:TextArea ID="tbxRecord" Label="履历" runat="server" Readonly="true" Height="60px">
                            </ext:TextArea>
                        </Items>
                    </ext:FormRow>
                </Rows>
            </ext:Form>
        </Items>
    </ext:Panel>
    </form>
</body>
</html>
