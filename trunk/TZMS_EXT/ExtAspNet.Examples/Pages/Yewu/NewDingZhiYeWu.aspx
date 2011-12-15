﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewDingZhiYeWu.aspx.cs"
    Inherits="TZMS.Web.NewDingZhiYeWu" %>

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
                    <ext:Button ID="btnClose" OnClick="btnClose_Click" Text="关闭" Icon="Cancel" runat="server">
                    </ext:Button>
                    <ext:Button ID="btnSubmit" Text="保存" OnClick="btnSubmit_Click" Icon="Disk" runat="server"
                        ValidateForms="mainForm" ConfirmText="您确定保存该表单吗?">
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
                                        RequiredMessage="您的“执行人”为空，请在我的首页设置我的审批人！" Label="负责人">
                                    </ext:DropDownList>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow runat="server" ColumnWidths="25% 25% 25% 25%">
                                <Items>
                                    <ext:CheckBox ID="cbxCMBG" Text="名称变更" runat="server" AutoPostBack="true" ShowLabel="false"
                                        OnCheckedChanged="cbxCMBG_CheckedChanged">
                                    </ext:CheckBox>
                                    <ext:CheckBox ID="cbxGDMCBG" Text="股东名称、发起人姓名变更" runat="server" ShowLabel="false"
                                        AutoPostBack="true" OnCheckedChanged="CommonCheckedChanged">
                                    </ext:CheckBox>
                                    <ext:CheckBox ID="cbxZCZBBG" Text="注册资本变更" runat="server" ShowLabel="false" AutoPostBack="true"
                                        OnCheckedChanged="cbxZCZBBG_CheckedChanged">
                                    </ext:CheckBox>
                                    <ext:CheckBox ID="cbxJYCSBG" Text="经营场所变更" runat="server" ShowLabel="false" AutoPostBack="true"
                                        OnCheckedChanged="CommonCheckedChanged">
                                    </ext:CheckBox>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow runat="server" ColumnWidths="25% 25% 25% 25%">
                                <Items>
                                    <ext:CheckBox ID="cbxFDDBRBG" Text="法定代表人变更" runat="server" ShowLabel="false" AutoPostBack="true"
                                        OnCheckedChanged="CommonCheckedChanged">
                                    </ext:CheckBox>
                                    <ext:CheckBox ID="cbxGDBG" Text="股东变更" runat="server" ShowLabel="false" AutoPostBack="true"
                                        OnCheckedChanged="cbxGDBG_CheckedChanged">
                                    </ext:CheckBox>
                                    <ext:CheckBox ID="cbxSSZBBG" Text="实收资本变更" runat="server" ShowLabel="false" AutoPostBack="true"
                                        OnCheckedChanged="CommonCheckedChanged">
                                    </ext:CheckBox>
                                    <ext:CheckBox ID="cbxGSLXBG" Text="公司类型变更" runat="server" ShowLabel="false" AutoPostBack="true"
                                        OnCheckedChanged="CommonCheckedChanged">
                                    </ext:CheckBox>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow runat="server" ColumnWidths="25% 25% 25% 25%">
                                <Items>
                                    <ext:CheckBox ID="cbxYYQXBG" Text="营业期限变更" runat="server" ShowLabel="false" AutoPostBack="true"
                                        OnCheckedChanged="CommonCheckedChanged">
                                    </ext:CheckBox>
                                    <ext:CheckBox ID="cbxJYFWBG" Text="经营范围变更" runat="server" ShowLabel="false" AutoPostBack="true"
                                        OnCheckedChanged="CommonCheckedChanged">
                                    </ext:CheckBox>
                                    <ext:CheckBox ID="cbxZXDJ" Text="注销登记" runat="server" ShowLabel="false" AutoPostBack="true"
                                        OnCheckedChanged="CommonCheckedChanged">
                                    </ext:CheckBox>
                                    <ext:CheckBox ID="cbxFGSBG" Text="分公司变更" runat="server" ShowLabel="false" AutoPostBack="true"
                                        OnCheckedChanged="CommonCheckedChanged">
                                    </ext:CheckBox>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow runat="server" ColumnWidths="25% 25% 25% 25%">
                                <Items>
                                    <ext:CheckBox ID="cbxFGSZX" Text="分公司注销" runat="server" ShowLabel="false" AutoPostBack="true"
                                        OnCheckedChanged="CommonCheckedChanged">
                                    </ext:CheckBox>
                                </Items>
                            </ext:FormRow>
                        </Rows>
                    </ext:Form>
                    <ext:TabStrip ID="TabStrip1" runat="server" ActiveTabIndex="0" ShowBorder="false"
                        AutoHeight="true" Height="389px">
                        <Tabs>
                            <ext:Tab ID="Tab1" Title="定制业务" EnableBackgroundColor="true" runat="server" BodyPadding="5px">
                                <Items>
                                    <ext:Form EnableBackgroundColor="true" LabelWidth="65px" ShowHeader="false" ShowBorder="false"
                                        BodyPadding="5px" ID="mainForm" runat="server">
                                        <Rows>
                                            <ext:FormRow ID="FormRow1" runat="server" ColumnWidths="60%">
                                                <Items>
                                                    <ext:DropDownList Required="true" ShowRedStar="true" ID="drpSigner" runat="server"
                                                        RequiredMessage="您的“执行人”为空，请在我的首页设置我的审批人！" Label="签单人">
                                                    </ext:DropDownList>
                                                    <ext:DatePicker ID="dpkSign" Required="true" ShowRedStar="true" Label="合同签订时间" runat="server">
                                                    </ext:DatePicker>
                                                </Items>
                                            </ext:FormRow>
                                            <ext:FormRow ID="FormRow7" runat="server" ColumnWidths="60%">
                                                <Items>
                                                    <ext:TextBox ID="tbxTitle" runat="server" Label="业务标题" Required="true" ShowRedStar="true"
                                                        MaxLength="100" MaxLengthMessage="最多只能输入100个字！">
                                                    </ext:TextBox>
                                                </Items>
                                            </ext:FormRow>
                                            <ext:FormRow ID="FormRow8" runat="server" ColumnWidths="60%">
                                                <Items>
                                                    <ext:TextArea ID="taaSument" runat="server" EmptyText="请填写该业务的大致内容" Label="内容" Required="true"
                                                        ShowRedStar="true" MaxLength="1000" MaxLengthMessage="最多只能输入1000个字！" Height="170px">
                                                    </ext:TextArea>
                                                </Items>
                                            </ext:FormRow>
                                            <ext:FormRow ID="FormRow6" runat="server">
                                                <Items>
                                                    <ext:TextArea ID="taaOther" runat="server" Label="备注" MaxLength="200" MaxLengthMessage="最多只能输入200个字！"
                                                        Height="80px">
                                                    </ext:TextArea>
                                                </Items>
                                            </ext:FormRow>
                                        </Rows>
                                    </ext:Form>
                                </Items>
                            </ext:Tab>
                            <ext:Tab ID="tabApproveHistory" Title="操作历史" EnableBackgroundColor="true" runat="server"
                                BodyPadding="5px">
                                <Items>
                                    <ext:Grid ID="gridApproveHistory" Title="Grid1" ShowBorder="true" ShowHeader="false"
                                        runat="server" IsDatabasePaging="true" EnableRowNumber="True" AutoScroll="true"
                                        AutoHeight="true" OnRowDataBound="gridApproveHistory_RowDataBound">
                                        <Columns>
                                            <ext:BoundField DataField="CheckerName" HeaderText="操作人" />
                                            <ext:BoundField DataField="CheckDateTime" HeaderText="操作时间" />
                                            <ext:BoundField DataField="CheckOp" HeaderText="操作类型" ExpandUnusedSpace="true" />
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
