﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImprestApply.aspx.cs" Inherits="TZMS.Web.ImprestApply" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="x-ua-compatible" content="ie=8" /> 
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <ext:PageManager ID="PageManager1" runat="server" />
    <ext:Panel ID="pelMain" runat="server" EnableBackgroundColor="true" BodyPadding="3px"
        EnableLargeHeader="true" Title="Panel" AutoScroll="false" ShowBorder="true" ShowHeader="false">
        <Toolbars>
            <ext:Toolbar ID="Toolbar1" runat="server">
                <Items>
                    <ext:Button ID="btnClose" Text="关闭" Icon="Cancel" runat="server" OnClick="btnClose_Click">
                    </ext:Button>
                    <ext:Button ID="btnSubmit" Text="提交" Icon="Disk" runat="server" ValidateForms="pelMain"
                        OnClick="btnSubmit_Click" ConfirmText="您确定提交该表单吗?">
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
                                        Label="下一步">
                                    </ext:DropDownList>
                                    <ext:DropDownList Required="true" ShowRedStar="true" ID="ddlstApproveUser" runat="server"
                                        RequiredMessage="您的“执行人”为空，请在我的首页设置我的审批人！" Label="执行人">
                                    </ext:DropDownList>
                                </Items>
                            </ext:FormRow>
                        </Rows>
                    </ext:Form>
                    <ext:TabStrip ID="TabStrip1" runat="server" ActiveTabIndex="0" ShowBorder="false"
                        AutoHeight="true" Height="389px">
                        <Tabs>
                            <ext:Tab ID="Tab1" Title="备用金申请单" EnableBackgroundColor="true" runat="server" BodyPadding="5px">
                                <Items>
                                    <ext:Form EnableBackgroundColor="true" LabelWidth="65px" ShowHeader="false" ShowBorder="true"
                                        BodyPadding="5px" ID="mainForm" runat="server">
                                        <Rows>
                                            <ext:FormRow ID="FormRow1" runat="server" ColumnWidths="50% 50%">
                                                <Items>
                                                    <ext:Label ID="lblName" runat="server" Label="申请人">
                                                    </ext:Label>
                                                    <ext:Label ID="lblApplyTime" runat="server" Label="申请时间">
                                                    </ext:Label>
                                                </Items>
                                            </ext:FormRow>
                                            <ext:FormRow ID="FormRow7" runat="server" ColumnWidths="50% 50%">
                                                <Items>
                                                    <ext:DropDownList ID="ddlstYeWu" runat="server" Label="项目名称" Required="true" ShowRedStar="true">
                                                    </ext:DropDownList>
                                                    <ext:TextBox ID="tbxMoney" runat="server" Label="金额(元)" Required="true" ShowRedStar="true"
                                                       Regex="^\-?[0-9]*\.?[0-9]{1,2}$" MaxLength="16"  RegexMessage="金额格式不正确!">
                                                    </ext:TextBox>
                                                </Items>
                                            </ext:FormRow>
                                            <ext:FormRow ID="FormRow8" runat="server" ColumnWidths="60%">
                                                <Items>
                                                    <ext:TextArea ID="tbxSument" runat="server" Required="true" ShowRedStar="true" Label="申请事由"
                                                        MaxLength="100" Height="250px" MaxLengthMessage="最多只能输入100个字！">
                                                    </ext:TextArea>
                                                </Items>
                                            </ext:FormRow>
                                        </Rows>
                                    </ext:Form>
                                </Items>
                            </ext:Tab>
                            <ext:Tab ID="tabApproveHistory" Title="审批历史" EnableBackgroundColor="true" runat="server"
                                BodyPadding="5px">
                                <Items>
                                    <ext:Grid ID="gridApproveHistory" Title="Grid1" ShowBorder="true" ShowHeader="false"
                                        runat="server" IsDatabasePaging="true" EnableRowNumber="True" AutoScroll="true"
                                        AutoHeight="true" OnRowDataBound="gridApproveHistory_RowDataBound">
                                        <Columns>
                                            <ext:BoundField DataField="ApproverName" HeaderText="执行人" />
                                            <ext:BoundField DataField="ApproveTime" HeaderText="执行时间" />
                                            <ext:BoundField DataField="ApproveOp" HeaderText="执行结果" />
                                            <ext:BoundField DataField="ApproveSugest" HeaderText="执行人意见" DataTooltipField="ApproveSugest" ExpandUnusedSpace="true" />
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
