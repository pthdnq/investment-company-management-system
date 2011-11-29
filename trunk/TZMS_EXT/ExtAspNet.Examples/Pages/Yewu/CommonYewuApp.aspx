<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CommonYewuApp.aspx.cs"
    Inherits="TZMS.Web.CommonYewuApp" %>

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
                    <ext:Button ID="btnSubmit" Text="提交" OnClick="btnSubmit_Click" Icon="Disk" runat="server"
                        ValidateForms="mainForm" ConfirmText="您确定提交该表单吗?">
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
                            <ext:FormRow ID="FormRow3" runat="server" ColumnWidths="50% 50%">
                                <Items>
                                    <ext:TextArea ID="taaApproveSugest" Required="true" EmptyText="请说明本本业务注意细节及说明" Height="50px" runat="server" Label="提交说明" MaxLength="100"
                                        MaxLengthMessage="最多只能输入100个字！">
                                    </ext:TextArea>
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
                                                    <ext:DropDownList Required="true" Enabled="false" ShowRedStar="true" ID="drpSigner"
                                                        runat="server" RequiredMessage="您的“执行人”为空，请在我的首页设置我的审批人！" Label="签单人">
                                                    </ext:DropDownList>
                                                    <ext:DatePicker ID="dpkSign" Enabled="false" Label="签单时间" runat="server">
                                                    </ext:DatePicker>
                                                </Items>
                                            </ext:FormRow>
                                            <ext:FormRow ID="FormRow7" runat="server" ColumnWidths="60%">
                                                <Items>
                                                    <ext:TextBox ID="tbxTitle" runat="server" Enabled="false" Label="业务标题" Required="true"
                                                        ShowRedStar="true" MaxLength="100" MaxLengthMessage="最多只能输入100个字！">
                                                    </ext:TextBox>
                                                </Items>
                                            </ext:FormRow>
                                            <ext:FormRow ID="FormRow8" runat="server" ColumnWidths="60%">
                                                <Items>
                                                    <ext:TextArea ID="taaSument" Enabled="false" runat="server" Label="内容" Required="true"
                                                        ShowRedStar="true" MaxLength="1000" MaxLengthMessage="最多只能输入1000个字！" Height="170px">
                                                    </ext:TextArea>
                                                </Items>
                                            </ext:FormRow>
                                            <ext:FormRow ID="FormRow6" runat="server">
                                                <Items>
                                                    <ext:TextArea ID="taaOther" Enabled="false" runat="server" Label="备注" MaxLength="200"
                                                        MaxLengthMessage="最多只能输入200个字！" Height="80px">
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
