<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SalaryMsgApprove.aspx.cs"
    Inherits="TZMS.Web.SalaryMsgApprove" %>

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
                    <ext:Button ID="btnPass" Text="同意" Icon="Accept" runat="server" ValidateForms="mainForm2"
                        OnClick="btnPass_Click" ConfirmText="您确定同意吗?">
                    </ext:Button>
                    <ext:Button ID="btnRefuse" Text="不同意" Icon="Stop" runat="server" OnClick="btnRefuse_Click"
                        ConfirmText="您确定不同意吗?">
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
                            <ext:FormRow ID="FormRow2" runat="server" ColumnWidths="50% 50%">
                                <Items>
                                    <ext:DropDownList Required="true" ShowRedStar="true" ID="ddlstNext" runat="server"
                                        AutoPostBack="true" Label="下一步" OnSelectedIndexChanged="ddlstNext_SelectedIndexChanged">
                                    </ext:DropDownList>
                                    <ext:DropDownList Required="true" ShowRedStar="true" ID="ddlstApproveUser" runat="server"
                                        RequiredMessage="您的“执行人”为空，请在我的首页设置我的审批人！" Label="执行人">
                                    </ext:DropDownList>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow ID="FormRow6" runat="server" ColumnWidths="50% 50%">
                                <Items>
                                    <ext:TextArea ID="taaApproveSugest" Height="50px" runat="server" Label="审批意见" EmptyText="请输入审批意见"
                                        MaxLength="100" MaxLengthMessage="最多只能输入100个字！">
                                    </ext:TextArea>
                                </Items>
                            </ext:FormRow>
                        </Rows>
                    </ext:Form>
                    <ext:TabStrip ID="TabStrip1" runat="server" ActiveTabIndex="0" ShowBorder="false"
                        AutoHeight="true" Height="335px">
                        <Tabs>
                            <ext:Tab ID="Tab1" Title="薪资申请单" EnableBackgroundColor="true" runat="server" BodyPadding="5px">
                                <Items>
                                    <ext:Grid ID="gridWorkerSalaryMsg" Title="Grid1" ShowBorder="true" ShowHeader="false"
                                        runat="server" IsDatabasePaging="true" EnableRowNumber="True" AutoScroll="true"
                                        AutoHeight="true" OnRowDataBound="gridWorkerSalaryMsg_RowDataBound" Height="300px">
                                        <Columns>
                                            <ext:BoundField DataField="Name" HeaderText="员工姓名" />
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
                            <ext:Tab ID="tabApproveHistory" Title="审批历史" EnableBackgroundColor="true" runat="server"
                                BodyPadding="5px">
                                <Items>
                                    <ext:Grid ID="gridApproveHistory" Title="Grid1" ShowBorder="true" ShowHeader="false"
                                        runat="server" EnableRowNumber="True" AutoScroll="true" AutoHeight="true" OnRowDataBound="gridApproveHistory_RowDataBound">
                                        <Columns>
                                            <ext:BoundField DataField="CheckerName" HeaderText="执行人" />
                                            <ext:BoundField DataField="CheckDateTime" HeaderText="执行时间" />
                                            <ext:BoundField DataField="CheckOp" HeaderText="执行结果" />
                                            <ext:BoundField DataField="CheckSugest" HeaderText="执行人意见" DataTooltipField="CheckSugest"
                                                ExpandUnusedSpace="true" />
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
