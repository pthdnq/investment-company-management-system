<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BankLoanApplyEditBA.aspx.cs"
    Inherits="TZMS.Web.Pages.BankLoanPages.BankLoanApplyEditBA" %>

<%@ Register Src="~/CommonControls/MudFlexCtrl.ascx" TagName="MudFlexCtrl" TagPrefix="ucl" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script language="javascript" src="../../App_Flash/AC_OETags.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <ext:PageManager ID="PageManager1" runat="server" AutoSizePanelID="pelMain" />
    <ext:Panel ID="pelMain" runat="server" EnableBackgroundColor="true" BodyPadding="3px"
        EnableLargeHeader="true" AutoHeight="true" Title="Panel" AutoScroll="false" ShowBorder="true"
        ShowHeader="false">
        <!--工具栏-->
        <Toolbars>
            <ext:Toolbar ID="Toolbar1" runat="server">
                <Items>
                    <ext:Button ID="btnClose" EnablePostBack="false" Text="关闭" runat="server" Icon="SystemClose" />
                    <ext:ToolbarSeparator ID="ToolbarSeparator2" runat="server" />
                    <ext:Button ID="btnSave" runat="server" ValidateForms="pelMain" OnClick="btnSave_Click"
                        IconUrl="~/Images/ico_nextstep.gif" Text="重新提交" ConfirmText="您确定要重新提交该核算申请吗?" />
                    <ext:Button ID="btnDismissed" Hidden="true" runat="server" ValidateForms="mainFrame"
                        OnClick="btnDismissed_Click" IconUrl="~/Images/ico_firststep.gif" Text="不通过"
                        ConfirmText="您确定不通过该申请吗?" />
                    <ext:Label runat="server" ID="HighMoneyTips">
                    </ext:Label>
                </Items>
            </ext:Toolbar>
        </Toolbars>
        <Items>
            <ext:Form EnableBackgroundColor="true" ShowHeader="false" BodyPadding="5px" ID="mainFrame"
                runat="server">
                <Rows>
                    <ext:FormRow ID="FormRow2" runat="server" ColumnWidths="50% 50%">
                        <Items>
                            <ext:DropDownList Required="true" ShowRedStar="true" ID="ddlstNext" runat="server"
                                Label="下一步" OnSelectedIndexChanged="ddlstNext_SelectedIndexChanged">
                            </ext:DropDownList>
                            <ext:DropDownList Required="true" ShowRedStar="true" ID="ddlstApproveUser" runat="server"
                                RequiredMessage="您的“执行人”为空，请在我的首页设置我的审批人！" Label="执行人">
                            </ext:DropDownList>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ColumnWidths="100%">
                        <Items>
                            <ext:TextArea ID="taRemark" Label="备注(需提交的材料)" runat="server" MaxLength="200" MaxLengthMessage="最多只能输入200个字符！">
                            </ext:TextArea>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ColumnWidths="50% 50%">
                        <Items>
                            <ext:TextArea ID="taAuditOpinion" Enabled="false" Label="审核意见" runat="server" MaxLength="200"
                                Hidden="true" MaxLengthMessage="最多只能输入200个字符！" />
                        </Items>
                    </ext:FormRow>
                </Rows>
            </ext:Form>
            <ext:TabStrip ID="TabStrip1" runat="server" ActiveTabIndex="0" ShowBorder="false"
                AutoHeight="true" Height="302px">
                <Tabs>
                    <ext:Tab ID="TabForm" Title="表单" EnableBackgroundColor="true" runat="server" BodyPadding="5px">
                        <Items>
                            <ext:Form EnableBackgroundColor="true" LabelWidth="50px" ShowHeader="false" ShowBorder="false"
                                BodyPadding="5px" ID="mainForm" runat="server">
                                <Rows>
                                    <ext:FormRow ColumnWidths="50% 50%">
                                        <Items>
                                            <ext:TextBox ID="tbProjectName" Enabled="false" Label="项目名称" runat="server" MaxLength="20"
                                                MaxLengthMessage="最多只能输入20个字符！">
                                            </ext:TextBox>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ID="FormRow6" runat="server" ColumnWidths="10% 90%">
                                        <Items>
                                            <ext:Label ID="Label1" runat="server" ShowLabel="false" Text="附件">
                                            </ext:Label>
                                            <ext:ContentPanel ID="ContentPanel1" runat="server" BodyPadding="5px" EnableBackgroundColor="true"
                                                ShowBorder="false" ShowHeader="false" Height="172px">
                                             <ucl:MudFlexCtrl  ShowAddBtn="false" ShowDelBtn="false" ID="MUDAttachment" runat="server" AttributeName="附件属性" SystemName="会计核算"></ucl:MudFlexCtrl>

                                            </ext:ContentPanel>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ColumnWidths="50% 50%">
                                        <Items>
                                            <ext:TextBox ID="tbCustomerName" Enabled="false" Label="客户名称" runat="server" MaxLength="20"
                                                Hidden="true" MaxLengthMessage="最多只能输入20个字符！" Regex="^[a-zA-Z0-9\u4e00-\u9fa5]*$"
                                                RegexMessage="不能输入特殊字符!">
                                            </ext:TextBox>
                                            <ext:TextBox ID="tbLoanCompany" Enabled="false" Label="贷款公司" runat="server" MaxLength="20"
                                                Hidden="true" MaxLengthMessage="最多只能输入20个字符！" Regex="^[a-zA-Z0-9\u4e00-\u9fa5]*$"
                                                RegexMessage="不能输入特殊字符!">
                                            </ext:TextBox>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ColumnWidths="50% 50%">
                                        <Items>
                                            <ext:TextBox ID="tbLoanAmount" Enabled="false" Label="贷款金额" runat="server" MaxLength="16"
                                                Hidden="true" MaxLengthMessage="最多只能输入16个数字！" Regex="^[0-9]*\.?[0-9]{1,2}$" RegexMessage="只能输入数字!">
                                            </ext:TextBox>
                                            <ext:TextBox ID="tbLoanFee" Enabled="false" Label="贷款手续费" runat="server" MaxLength="16"
                                                Hidden="true" MaxLengthMessage="最多只能输入16个数字！" Regex="^[0-9]*\.?[0-9]{1,2}$" RegexMessage="只能输入数字!">
                                            </ext:TextBox>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ColumnWidths="50% 50%">
                                        <Items>
                                            <ext:TextBox ID="tbCollateralCompany" Enabled="false" Label="抵押物公司" runat="server"
                                                Hidden="true" MaxLength="20" MaxLengthMessage="最多只能输入20个字符！" Regex="^[a-zA-Z0-9\u4e00-\u9fa5]*$"
                                                RegexMessage="不能输入特殊字符!">
                                            </ext:TextBox>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ColumnWidths="50% 50%">
                                        <Items>
                                            <ext:DatePicker Hidden="true" ID="dpSignDate" Enabled="false" Label="签订日期" runat="server">
                                            </ext:DatePicker>
                                            <ext:TextBox Hidden="true" ID="tbDownPayment" Enabled="false" Label="预付订金" runat="server"
                                                MaxLength="16" MaxLengthMessage="最多只能输入16个数字！"  Regex="^[0-9]*\.?[0-9]{1,2}$" RegexMessage="只能输入数字!">
                                            </ext:TextBox>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ColumnWidths="50% 50%">
                                        <Items>
                                            <ext:TextArea ID="taContact" Enabled="false" Label="联系方式" runat="server" MaxLength="100"
                                                Hidden="true" MaxLengthMessage="最多只能输入100个字符！" Regex="^[a-zA-Z0-9\u4e00-\u9fa5]*$"
                                                RegexMessage="不能输入特殊字符!">
                                            </ext:TextArea>
                                        </Items>
                                    </ext:FormRow>
                                </Rows>
                            </ext:Form>
                        </Items>
                    </ext:Tab>
                    <ext:Tab ID="tabHistory" Title="操作历史" EnableBackgroundColor="true" runat="server"
                        BodyPadding="5px">
                        <Items>
                            <ext:Grid ID="gridHistory" Title="Grid1" ShowBorder="true" ShowHeader="false" runat="server"
                                IsDatabasePaging="true" EnableRowNumber="True" AutoScroll="true" AutoHeight="true">
                                <Columns>
                                    <ext:BoundField Width="50px" DataField="OperationerName" HeaderText="操作人" />
                                    <%--        <ext:BoundField Width="55px" DataField="OperationerAccount" HeaderText="帐号" />--%>
                                    <ext:BoundField Width="100px" DataField="OperationTime" DataFormatString="{0:yyyy/MM/dd HH:mm}"
                                        HeaderText="操作时间" />
                                    <ext:BoundField Width="60px" DataField="OperationType" HeaderText="操作类型" />
                                    <ext:BoundField Width="100px" DataField="OperationDesc" DataTooltipField="OperationDesc"
                                        HeaderText="操作描述" />
                                    <ext:BoundField DataField="Remark" HeaderText="操作人意见" DataTooltipField="Remark" ExpandUnusedSpace="true" />
                                </Columns>
                            </ext:Grid>
                        </Items>
                    </ext:Tab>
                </Tabs>
            </ext:TabStrip>
        </Items>
    </ext:Panel>
    </form>
</body>
</html>
