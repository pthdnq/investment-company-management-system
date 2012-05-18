<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewWorkerSalaryMsg.aspx.cs"
    Inherits="TZMS.Web.NewWorkerSalaryMsg" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <ext:PageManager ID="PageManager1" runat="server" AutoSizePanelID="pelMain" />
    <ext:Panel ID="pelMain" runat="server" EnableBackgroundColor="true" BodyPadding="3px"
        EnableLargeHeader="true" Title="Panel" AutoScroll="false" ShowBorder="true" ShowHeader="false">
        <Toolbars>
            <ext:Toolbar ID="Toolbar1" runat="server">
                <Items>
                    <ext:Button ID="btnClose" Text="关闭" Icon="Cancel" runat="server" OnClick="btnClose_Click">
                    </ext:Button>
                    <ext:Button ID="btnSubmit" Text="保存" Icon="Disk" runat="server" ValidateForms="pelMain"
                        OnClick="btnSubmit_Click" ConfirmText="您确定添加该员工薪资信息吗?">
                    </ext:Button>
                </Items>
            </ext:Toolbar>
        </Toolbars>
        <Items>
            <ext:Panel ID="pelOperator" runat="server" ShowBorder="false" EnableBackgroundColor="true"
                BodyPadding="3px" ShowHeader="false" AnchorValue="100% -36">
                <Items>
                    <ext:Form ID="mainForm2" EnableBackgroundColor="true" ShowHeader="false" BodyPadding="5px"
                        runat="server" LabelWidth="100px">
                        <Rows>
                            <ext:FormRow ID="FormRow1" runat="server" ColumnWidths="50% 50%">
                                <Items>
                                    <ext:Label ID="lblYear" runat="server" Label="年份">
                                    </ext:Label>
                                    <ext:Label ID="lblMonth" runat="server" Label="月份">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow ID="FormRow2" runat="server" ColumnWidths="50% 50%">
                                <Items>
                                    <ext:TextBox ID="tbxName" runat="server" Label="员工名称"  Required="true"
                                        ShowRedStar="true" Enabled="false">
                                    </ext:TextBox>
                                    <ext:Button ID="btnChooseUser" runat="server" Text="选取员工..." OnClick="btnChooseUser_Click">
                                    </ext:Button>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow ID="FormRow3" runat="server" ColumnWidths="50% 50%" Hidden="true">
                                <Items>
                                    <ext:TextBox ID="tbxBaseSalary" Label="基本工资" runat="server" Required="true" ShowRedStar="true"
                                        Regex="^\-?[0-9]*\.?[0-9]{1,2}$"  RegexMessage="金额格式不正确!" Text="0.0" Hidden="true">
                                    </ext:TextBox>
                                    <ext:TextBox ID="tbxExamSalary" Label="提成工资" runat="server" Required="true" ShowRedStar="true"
                                       Regex="^\-?[0-9]*\.?[0-9]{1,2}$"  RegexMessage="金额格式不正确!" Text="0.0" Hidden="true">
                                    </ext:TextBox>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow ID="FormRow4" runat="server" ColumnWidths="50% 50%" Hidden="true">
                                <Items>
                                    <ext:TextBox ID="tbxBackSalary" Label="补贴" runat="server" Required="true" ShowRedStar="true"
                                        Regex="^\-?[0-9]*\.?[0-9]{1,2}$"  RegexMessage="金额格式不正确!" Text="0.0" Hidden="true">
                                    </ext:TextBox>
                                    <ext:TextBox ID="tbxOtherSalary" Label="其它" runat="server" Required="true" ShowRedStar="true"
                                        Regex="^\-?[0-9]*\.?[0-9]{1,2}$"  RegexMessage="金额格式不正确!" Text="0.0" Hidden="true">
                                    </ext:TextBox>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow ID="FormRow5" runat="server" ColumnWidths="50% 50%" Hidden="true">
                                <Items>
                                    <ext:TextBox ID="tbxShouldSalary" Label="应发工资总额" runat="server" Required="true" ShowRedStar="true"
                                        Regex="^\-?[0-9]*\.?[0-9]{1,2}$"  RegexMessage="金额格式不正确!" Text="0.0" Hidden="true">
                                    </ext:TextBox>
                                    <ext:TextBox ID="tbxSalary" Label="实发工资总额" runat="server" Required="true" ShowRedStar="true"
                                      Regex="^\-?[0-9]*\.?[0-9]{1,2}$"  RegexMessage="金额格式不正确!" Text="0.0" Hidden="true">
                                    </ext:TextBox>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow ColumnWidths="50% 50%">
                                <Items>
                                    <ext:TextBox ID="tbxJBGZ" Label="基本工资" runat="server" Required="true" ShowRedStar="true"
                                        MaxLength="50" MaxLengthMessage="最多只能输入50个字!" Text="0.00">
                                    </ext:TextBox>
                                    <ext:TextBox ID="tbxGLGZ" Label="工龄工资" runat="server" Required="true" ShowRedStar="true"
                                        MaxLength="50" MaxLengthMessage="最多只能输入50个字!" Text="0.00">
                                    </ext:TextBox>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow ColumnWidths="50% 50%">
                                <Items>
                                    <ext:TextBox ID="tbxSYQGZ" Label="补发工资" runat="server" Required="true" ShowRedStar="true"
                                        MaxLength="50" MaxLengthMessage="最多只能输入50个字!" Text="0.00">
                                    </ext:TextBox>
                                    <ext:TextBox ID="tbxNZJ" Label="年终奖" runat="server" Required="true" ShowRedStar="true"
                                        MaxLength="50" MaxLengthMessage="最多只能输入50个字!" Text="0.00">
                                    </ext:TextBox>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow ColumnWidths="50% 50%">
                                <Items>
                                    <ext:TextBox ID="tbxJLGZ" Label="奖励工资" runat="server" Required="true" ShowRedStar="true"
                                        MaxLength="50" MaxLengthMessage="最多只能输入50个字!" Text="0.00">
                                    </ext:TextBox>
                                    <ext:TextBox ID="tbxKHGZ" Label="提成工资" runat="server" Required="true" ShowRedStar="true"
                                        MaxLength="50" MaxLengthMessage="最多只能输入50个字!" Text="0.00">
                                    </ext:TextBox>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow ColumnWidths="50% 50%">
                                <Items>
                                    <ext:TextBox ID="tbxCB" Label="餐补" runat="server" Required="true" ShowRedStar="true"
                                        MaxLength="50" MaxLengthMessage="最多只能输入50个字!" Text="0.00">
                                    </ext:TextBox>
                                    <ext:TextBox ID="tbxJTBZ" Label="交通补助" runat="server" Required="true" ShowRedStar="true"
                                        MaxLength="50" MaxLengthMessage="最多只能输入50个字!" Text="0.00">
                                    </ext:TextBox>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow ColumnWidths="50% 50%">
                                <Items>
                                    <ext:TextBox ID="tbxYFGZ" Label="应发工资" runat="server" Required="true" ShowRedStar="true"
                                        MaxLength="50" MaxLengthMessage="最多只能输入50个字!" Text="0.00" Regex="^[0-9]*\.?[0-9]{1,2}$"
                                        RegexMessage="金额格式不正确!">
                                    </ext:TextBox>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow ColumnWidths="50% 50%">
                                <Items>
                                    <ext:TextBox ID="tbxCD" Label="迟到" runat="server" Required="true" ShowRedStar="true"
                                        MaxLength="50" MaxLengthMessage="最多只能输入50个字!" Text="0.00">
                                    </ext:TextBox>
                                    <ext:TextBox ID="tbxZT" Label="早退" runat="server" Required="true" ShowRedStar="true"
                                        MaxLength="50" MaxLengthMessage="最多只能输入50个字!" Text="0.00">
                                    </ext:TextBox>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow ColumnWidths="50% 50%">
                                <Items>
                                    <ext:TextBox ID="tbxKG" Label="旷工" runat="server" Required="true" ShowRedStar="true"
                                        MaxLength="50" MaxLengthMessage="最多只能输入50个字!" Text="0.00">
                                    </ext:TextBox>
                                    <ext:TextBox ID="tbxSJ" Label="事假" runat="server" Required="true" ShowRedStar="true"
                                        MaxLength="50" MaxLengthMessage="最多只能输入50个字!" Text="0.00">
                                    </ext:TextBox>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow ColumnWidths="50% 50%">
                                <Items>
                                    <ext:TextBox ID="tbxBJ" Label="病假" runat="server" Required="true" ShowRedStar="true"
                                        MaxLength="50" MaxLengthMessage="最多只能输入50个字!" Text="0.00">
                                    </ext:TextBox>
                                    <ext:TextBox ID="tbxSB" Label="社保" runat="server" Required="true" ShowRedStar="true"
                                        MaxLength="50" MaxLengthMessage="最多只能输入50个字!" Text="0.00">
                                    </ext:TextBox>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow ColumnWidths="50% 50%">
                                <Items>
                                    <ext:TextBox ID="tbxFK" Label="罚款" runat="server" Required="true" ShowRedStar="true"
                                        MaxLength="50" MaxLengthMessage="最多只能输入50个字!" Text="0.00">
                                    </ext:TextBox>
                                    <ext:TextBox ID="tbxCF" Label="餐费" runat="server" Required="true" ShowRedStar="true"
                                        MaxLength="50" MaxLengthMessage="最多只能输入50个字!" Text="0.00">
                                    </ext:TextBox>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow ColumnWidths="50% 50%">
                                <Items>
                                    <ext:TextBox ID="tbxBJF" Label="保洁费" runat="server" Required="true" ShowRedStar="true"
                                        MaxLength="50" MaxLengthMessage="最多只能输入50个字!" Text="0.00">
                                    </ext:TextBox>
                                    <ext:TextBox ID="tbxLYF" Label="旅游费" runat="server" Required="true" ShowRedStar="true"
                                        MaxLength="50" MaxLengthMessage="最多只能输入50个字!" Text="0.00">
                                    </ext:TextBox>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow ColumnWidths="50% 50%">
                                <Items>
                                    <ext:TextBox ID="tbxSFGZ" Label="实发工资" runat="server" Required="true" ShowRedStar="true"
                                        MaxLength="50" MaxLengthMessage="最多只能输入50个字!" Text="0.00" Regex="^[0-9]*\.?[0-9]{1,2}$"
                                        RegexMessage="金额格式不正确!">
                                    </ext:TextBox>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow ID="FormRow6" runat="server" ColumnWidths="50% 50%">
                                <Items>
                                    <ext:TextArea ID="taaContext" runat="server" Label="备注" EmptyText="请输入备注信息" Height="90px"
                                        MaxLength="100" MaxLengthMessage="最多只能输入100个字符!">
                                    </ext:TextArea>
                                </Items>
                            </ext:FormRow>
                        </Rows>
                    </ext:Form>
                </Items>
            </ext:Panel>
        </Items>
    </ext:Panel>
    <ext:Window ID="wndSelectWorker" Title="选取员工" Popup="false" EnableIFrame="true" IFrameUrl="about:blank"
        Target="Top" runat="server" IsModal="true" Width="560px" EnableConfirmOnClose="true"
        Height="450px" OnClose="wndSelectWorker_Close">
    </ext:Window>
    </form>
</body>
</html>
