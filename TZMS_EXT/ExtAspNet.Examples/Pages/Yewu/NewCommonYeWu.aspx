<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewCommonYeWu.aspx.cs"
    Inherits="TZMS.Web.NewCommonYeWu" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>新建普通业务</title>
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
                                    <%-- <ext:DropDownList Required="true" ShowRedStar="true" ID="ddlstNext" runat="server"
                                        Label="下一步">
                                    </ext:DropDownList>--%>
                                    <ext:DropDownList Required="true" ShowRedStar="true" ID="ddlstApproveUser" runat="server"
                                        RequiredMessage="您的“执行人”为空，请在我的首页设置我的审批人！" Label="当前责任人">
                                    </ext:DropDownList>
                                </Items>
                            </ext:FormRow>
                        </Rows>
                    </ext:Form>
                    <ext:TabStrip ID="TabStrip1" runat="server" ActiveTabIndex="0" ShowBorder="false"
                        AutoHeight="true" Height="389px">
                        <Tabs>
                            <ext:Tab ID="Tab1" Title="普通业务" EnableBackgroundColor="true" runat="server" BodyPadding="5px">
                                <Items>
                                    <ext:Form EnableBackgroundColor="true" LabelWidth="65px" ShowHeader="false" ShowBorder="false"
                                        BodyPadding="5px" ID="mainForm" runat="server">
                                        <Rows>
                                            <ext:FormRow ID="FormRow1" runat="server" ColumnWidths="60%">
                                                <Items>
                                                    <ext:DropDownList Required="true" ShowRedStar="true" ID="drpSigner" runat="server"
                                                        RequiredMessage="您的“执行人”为空，请在我的首页设置我的审批人！" Label="签单人">
                                                    </ext:DropDownList>
                                                    <ext:DatePicker ID="dpkSign" Label="签单时间" runat="server">
                                                    </ext:DatePicker>
                                                    <%-- <ext:Label ID="lblUser" runat="server" Label="创建人">
                                                    </ext:Label>
                                                    <ext:Label ID="lblApplyDate" runat="server" Label="创建时间">
                                                    </ext:Label>--%>
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
                            <ext:Tab ID="tabChecker" Title="责任人设置" EnableBackgroundColor="true" runat="server"
                                BodyPadding="5px">
                                <Items>
                                    <ext:Form EnableBackgroundColor="true" LabelWidth="70px" ShowHeader="false" ShowBorder="false"
                                        BodyPadding="5px" ID="Form2" runat="server">
                                        <Rows>
                                            <ext:FormRow ID="FormRow3" runat="server" ColumnWidths="60%">
                                                <Items>
                                                    <ext:DropDownList Required="true" ID="drpCheck1" runat="server" Label="1.业务转交">
                                                    </ext:DropDownList>
                                                    <ext:DropDownList Required="true" ID="drpCheck2" runat="server" Label="2.核名">
                                                    </ext:DropDownList>
                                                </Items>
                                            </ext:FormRow>
                                            <ext:FormRow ID="FormRow4" runat="server" ColumnWidths="60%">
                                                <Items>
                                                    <ext:DropDownList Required="true" ID="drpCheck3" runat="server" Label="3.刻章">
                                                    </ext:DropDownList>
                                                    <ext:DropDownList Required="true" ID="drpCheck4" runat="server" Label="4.开户">
                                                    </ext:DropDownList>
                                                </Items>
                                            </ext:FormRow>
                                            <ext:FormRow ID="FormRow5" runat="server" ColumnWidths="60%">
                                                <Items>
                                                    <ext:DropDownList Required="true" ID="drpCheck5" runat="server" Label="5.验资报告">
                                                    </ext:DropDownList>
                                                    <ext:DropDownList Required="true" ID="drpCheck6" runat="server" Label="6.营业执照">
                                                    </ext:DropDownList>
                                                </Items>
                                            </ext:FormRow>
                                            <ext:FormRow ID="FormRow9" runat="server" ColumnWidths="60%">
                                                <Items>
                                                    <ext:DropDownList Required="true" ID="drpCheck7" runat="server" Label="7.办代码证">
                                                    </ext:DropDownList>
                                                    <ext:DropDownList Required="true" ID="drpCheck8" runat="server" Label="8.办国地税">
                                                    </ext:DropDownList>
                                                </Items>
                                            </ext:FormRow>
                                            <ext:FormRow ID="FormRow10" runat="server" ColumnWidths="60%">
                                                <Items>
                                                    <ext:DropDownList Required="true" ID="drpCheck9" runat="server" Label="9.转基本户">
                                                    </ext:DropDownList>
                                                    <ext:Label runat="server" Text="每个责任人需要处理相应阶段的工作"></ext:Label>
                                                    <%--      <ext:DropDownList Required="true"  ID="DropDownList10" runat="server"
                                                        Label="2.营业执照">
                                                    </ext:DropDownList>--%>
                                                </Items>
                                            </ext:FormRow>
                                        </Rows>
                                    </ext:Form>
                                </Items>
                            </ext:Tab>
                            <ext:Tab ID="tabApproveHistory" Title="操作历史" EnableBackgroundColor="true" runat="server"
                                BodyPadding="5px">
                                <Items>
                                    <%--                                    <ext:Grid ID="gridApproveHistory" Title="Grid1" ShowBorder="true" ShowHeader="false"
                                        runat="server" IsDatabasePaging="true" EnableRowNumber="True" AutoScroll="true"
                                        AutoHeight="true" OnRowDataBound="gridApproveHistory_RowDataBound">
                                        <Columns>
                                            <ext:BoundField DataField="CheckerName" HeaderText="执行人" />
                                            <ext:BoundField DataField="CheckDateTime" HeaderText="执行时间" />
                                            <ext:BoundField DataField="CheckOp" HeaderText="执行结果" />
                                            <ext:BoundField DataField="CheckSugest" HeaderText="执行人意见" DataTooltipField="CheckSugest"
                                                ExpandUnusedSpace="true" />
                                        </Columns>
                                    </ext:Grid>--%>
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
