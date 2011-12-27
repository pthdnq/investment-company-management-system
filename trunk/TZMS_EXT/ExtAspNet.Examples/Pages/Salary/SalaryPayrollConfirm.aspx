<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SalaryPayrollConfirm.aspx.cs"
    Inherits="TZMS.Web.SalaryPayrollConfirm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <ext:PageManager ID="PageManager1" runat="server" AutoSizePanelID="pelMain" EnableAjax="false" />
    <ext:Panel ID="pelMain" runat="server" EnableBackgroundColor="true" BodyPadding="3px"
        EnableLargeHeader="true" Title="Panel" AutoScroll="false" ShowBorder="true" ShowHeader="false">
        <Toolbars>
            <ext:Toolbar ID="Toolbar1" runat="server">
                <Items>
                    <ext:Button ID="btnClose" Text="关闭" Icon="Cancel" runat="server" OnClick="btnClose_Click">
                    </ext:Button>
                    <ext:Button ID="btnSubmit" Text="确认发放" Icon="Disk" runat="server" ValidateForms="pelMain"
                        OnClick="btnSubmit_Click" ConfirmText="您确定发放工资吗?">
                    </ext:Button>
                    <ext:Button ID="btnExport" Text="导出工资单" IconUrl="~/Images/xls.gif" runat="server"
                        OnClick="btnExport_Click">
                    </ext:Button>
                </Items>
            </ext:Toolbar>
        </Toolbars>
        <Items>
            <ext:Panel ID="pelOperator" runat="server" ShowBorder="false" EnableBackgroundColor="true"
                BodyPadding="3px" ShowHeader="false" AnchorValue="100% -36">
                <Items>
                    <ext:Form ID="mainForm2" EnableBackgroundColor="true" ShowHeader="false" BodyPadding="5px"
                        runat="server">
                        <Rows>
                            <ext:FormRow ColumnWidths="50% 50%">
                                <Items>
                                    <ext:Label ID="lblYear" runat="server" Label="年份">
                                    </ext:Label>
                                    <ext:Label ID="lblMonth" runat="server" Label="月份">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow ColumnWidths="50% 50%">
                                <Items>
                                    <ext:Label ID="lblSumMoney" runat="server" Label="总金额(元)">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                        </Rows>
                    </ext:Form>
                    <ext:TabStrip ID="TabStrip1" runat="server" ActiveTabIndex="0" ShowBorder="false"
                        AutoHeight="true" Height="389px">
                        <Tabs>
                            <ext:Tab ID="Tab1" Title="薪资信息明细" EnableBackgroundColor="true" runat="server" BodyPadding="5px">
                                <Items>
                                    <ext:Grid ID="gridWorkerSalaryMsg" Title="Grid1" ShowBorder="true" ShowHeader="false"
                                        runat="server" IsDatabasePaging="true" EnableRowNumber="True" AutoScroll="true"
                                        AutoHeight="true" OnRowDataBound="gridWorkerSalaryMsg_RowDataBound" Height="340px">
                                        <Columns>
                                            <ext:BoundField DataField="Name" HeaderText="员工姓名" />
                                            <ext:BoundField Width="75px" DataField="Dept" HeaderText="部门" />
                                            <ext:BoundField Width="75px" DataField="BaseSalary" HeaderText="基本工资" Hidden="true" />
                                            <ext:BoundField Width="75px" DataField="ExamSalary" HeaderText="考核工资" Hidden="true" />
                                            <ext:BoundField Width="75px" DataField="BackSalary" HeaderText="补贴" Hidden="true" />
                                            <ext:BoundField Width="75px" DataField="OtherSalary" HeaderText="其它" Hidden="true" />
                                            <ext:BoundField Width="85px" DataField="ShouldSalary" HeaderText="应发工资总额" Hidden="true" />
                                            <ext:BoundField Width="85px" DataField="Salary" HeaderText="实发工资总额" Hidden="true" />
                                            <ext:BoundField DataField="Jbgz" HeaderText="基本工资" Width="150px" />
                                            <ext:BoundField DataField="Glgz" HeaderText="工龄工资" />
                                            <ext:BoundField DataField="Syqgz" HeaderText="试用期补发工资" Width="150px" />
                                            <ext:BoundField DataField="Nzj" HeaderText="年终奖" />
                                            <ext:BoundField DataField="Jlgz" HeaderText="奖励工资" />
                                            <ext:BoundField DataField="Khgz" HeaderText="考核工资" />
                                            <ext:BoundField DataField="Cb" HeaderText="餐补" />
                                            <ext:BoundField DataField="Jtbz" HeaderText="交通补助" />
                                            <ext:BoundField DataField="Yfgz" HeaderText="应发工资" />
                                            <ext:BoundField DataField="Cd" HeaderText="迟到" Width="60px" />
                                            <ext:BoundField DataField="Zt" HeaderText="早退" Width="60px" />
                                            <ext:BoundField DataField="Kg" HeaderText="旷工" Width="60px" />
                                            <ext:BoundField DataField="Sj" HeaderText="事假" Width="60px" />
                                            <ext:BoundField DataField="Bj" HeaderText="病假" Width="60px" />
                                            <ext:BoundField DataField="Sb" HeaderText="社保" Width="60px" />
                                            <ext:BoundField DataField="Fk" HeaderText="罚款" Width="60px" />
                                            <ext:BoundField DataField="Cf" HeaderText="餐费" Width="60px" />
                                            <ext:BoundField DataField="Bjf" HeaderText="保洁费" Width="60px" />
                                            <ext:BoundField DataField="Lyf" HeaderText="旅游费" Width="60px" />
                                            <ext:BoundField DataField="Sfgz" HeaderText="实发工资" />
                                            <ext:BoundField DataField="Context" HeaderText="备注" Width="200px" DataTooltipField="Context" />
                                        </Columns>
                                    </ext:Grid>
                                </Items>
                            </ext:Tab>
                        </Tabs>
                    </ext:TabStrip>
                </Items>
            </ext:Panel>
        </Items>
    </ext:Panel>
    </form>
</body>
</html>
