<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaymentApplyAdd.aspx.cs"
    Inherits="TZMS.Web.Pages.InvestmentLoanPages.PaymentApplyAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>PaymentApplyAdd</title>
</head>
<body>
    <form id="form1" runat="server">
    <ext:PageManager ID="PageManager1" runat="server" AutoSizePanelID="pelMain" />
    <ext:Panel ID="pelMain" runat="server" EnableBackgroundColor="true" BodyPadding="3px"
        EnableLargeHeader="true" Title="Panel" AutoScroll="false" ShowBorder="true" ShowHeader="false">
        <!--工具栏-->
        <Toolbars>
            <ext:Toolbar ID="Toolbar1" runat="server">
                <Items>
                    <ext:Button ID="btnClose" EnablePostBack="false" Text="关闭" runat="server" Icon="SystemClose" />
                    <ext:ToolbarSeparator ID="ToolbarSeparator2" runat="server" />
                    <ext:Button ID="btnSave" runat="server" ValidateForms="pelMain" OnClick="btnSave_Click"
                        Icon="Disk" Text="提交" ConfirmText="您确定提交该表单吗?" />
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
                                Label="下一步">
                            </ext:DropDownList>
                            <ext:DropDownList Required="true" ShowRedStar="true" ID="ddlstApproveUser" runat="server"
                                RequiredMessage="您的“执行人”为空，请在我的首页设置我的审批人！" Label="执行人">
                            </ext:DropDownList>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ColumnWidths="50% 50%">
                        <Items>
                            <ext:TextBox ID="tbProjectName" Label="项目名称" ShowRedStar="true" Required="true" runat="server"
                                MaxLength="50" MaxLengthMessage="最多只能输入50个字符！">
                            </ext:TextBox>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ColumnWidths="50% 50%">
                        <Items>
                            <ext:TextArea ID="tbProjectOverview" Label="项目概述" ShowRedStar="true" Required="true"
                                runat="server" MaxLength="300" MaxLengthMessage="最多只能输入300个字符！" />
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ColumnWidths="50% 50%">
                        <Items>
                            <%--          <ext:TextBox ID="tbBorrowerNameA" Label="借款人（甲方）" ShowRedStar="true" Required="true"
                                runat="server" MaxLength="20" MaxLengthMessage="最多只能输入20个字符！" Regex="^[a-zA-Z0-9\u4e00-\u9fa5]*$"
                                RegexMessage="不能输入特殊字符!">
                            </ext:TextBox>--%>
                            <ext:TriggerBox EnableEdit="false" ID="tbBorrowerNameA" Label="借款人(甲方)" TriggerIconUrl="~/Images/ico_16_grxx.gif"
                                OnTriggerClick="tbBorrowerNameA_TriggerClick" EmptyText="" runat="server">
                            </ext:TriggerBox>
                            <ext:TextBox ID="tbBorrowerPhone" Label="借款联系电话" runat="server" MaxLength="20" MaxLengthMessage="最多只能输入20个字符！"
                                Regex="(\(?\d{3,4}\)?)?[\s-]?\d{7,8}[\s-]?\d{0,4}" RegexMessage="电话号码格式不正确!">
                            </ext:TextBox>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ColumnWidths="50% 50%">
                        <Items>
                            <ext:Label ID="Label1" runat="server" Text="借款人信用星级：***" Hidden="true" />
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ColumnWidths="50% 50%">
                        <Items>
                            <ext:TextBox ID="tbPayerBName" Label="付款人(乙方)" ShowRedStar="true" Required="true"
                                runat="server" MaxLength="20" MaxLengthMessage="最多只能输入20个字符！" Regex="^[a-zA-Z0-9\u4e00-\u9fa5]*$"
                                RegexMessage="不能输入特殊字符!">
                            </ext:TextBox>
                            <ext:DropDownList  runat="server" Label="付款方式" ID="ddlLoanType" ShowRedStar="true" Required="true">
                            <ext:ListItem Text="现金" Value="Cash" />
                            <ext:ListItem Text="转账" Value="TransferAccount"  Selected="true"/>
                            </ext:DropDownList>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ColumnWidths="50% 50%">
                        <Items>
                            <ext:TextBox ID="tbLoanAmount" Label="借款金额(元)" ShowRedStar="true" Required="true"
                                runat="server" MaxLength="20" MaxLengthMessage="最多只能输入20个数字！" Regex="^[0-9]*$"
                                RegexMessage="只能输入数字!">
                            </ext:TextBox>
                            <ext:TextBox ID="tbLoanTimeLimit" Label="借款期限" runat="server" ShowRedStar="true"
                                Required="true">
                            </ext:TextBox>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ColumnWidths="50% 50%">
                        <Items>
                            <ext:DatePicker ID="dpLoanDate" Label="借款日期" ShowRedStar="true" Required="true" runat="server">
                            </ext:DatePicker>
                            <ext:DatePicker ID="dpDueDateForPay" Label="应付借款日" runat="server" ShowRedStar="true"
                                Required="true">
                            </ext:DatePicker>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ColumnWidths="50% 50%">
                        <Items>
                            <ext:TextBox ID="tbCollateral" Label="抵押物" runat="server" ShowRedStar="true" Required="true"
                                MaxLength="40" MaxLengthMessage="最多只能输入40个字符！">
                            </ext:TextBox>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ColumnWidths="50% 50%">
                        <Items>
                            <ext:TextBox ID="tbGuarantor" Label="担保人" runat="server" ShowRedStar="true" Required="true"
                                MaxLength="20" MaxLengthMessage="最多只能输入20个字符！" Regex="^[a-zA-Z0-9\u4e00-\u9fa5]*$"
                                RegexMessage="不能输入特殊字符!">
                            </ext:TextBox>
                            <ext:TextBox ID="tbGuarantorPhone" Label="担保人联系电话" runat="server" MaxLength="20"
                                MaxLengthMessage="最多只能输入20个字符！" Regex="(\(?\d{3,4}\)?)?[\s-]?\d{7,8}[\s-]?\d{0,4}"
                                RegexMessage="电话号码格式不正确!">
                            </ext:TextBox>
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ColumnWidths="50% 50%">
                        <Items>
                            <ext:TextBox ID="tbRateOfReturn" Label="投资回报率(%)" runat="server" ShowRedStar="true"
                                Required="true" MaxLength="2" MaxLengthMessage="最多只能输入2个数字！" Regex="^[0-9]*$"
                                RegexMessage="只能输入数字!" />
                        </Items>
                    </ext:FormRow>
                </Rows>
            </ext:Form>
            <ext:Form Title="会计核算" runat="server" EnableCollapse="true" EnableBackgroundColor="true"
                BodyPadding="5px">
                <Rows>
                    <ext:FormRow runat="server" ColumnWidths="60% 40%">
                        <Items>
                            <ext:DropDownList Required="true" ShowRedStar="true" ID="ddlstApproveUserBA" runat="server"
                                RequiredMessage="您的“执行人”为空，请在我的首页设置我的审批人！" Label="核算会计">
                            </ext:DropDownList>
                            <ext:Label runat="server" />
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow>
                        <Items>
                            <ext:TextArea ID="tbRemark" Label="备注(需提供材料)" runat="server" MaxLength="200" MaxLengthMessage="最多只能输入200字符！" />
                        </Items>
                    </ext:FormRow>
                </Rows>
            </ext:Form>
        </Items>
    </ext:Panel>
    <ext:Window ID="wndChooseZJ" Title="选取借款人" Popup="false" EnableIFrame="true" IFrameUrl="about:blank"
        Target="Parent" runat="server" IsModal="true" EnableConfirmOnClose="true" Height="460px"
        Width="590px" OnClose="wndChooseZJ_Close">
    </ext:Window>
    </form>
</body>
</html>
