<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaymentApplyEdit.aspx.cs"
    Inherits="TZMS.Web.Pages.InvestmentLoanPages.PaymentApplyEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>PaymentApplyEdit</title>
</head>
<body>
    <form id="form1" runat="server">
    <ext:PageManager ID="PageManager1" runat="server" AutoSizePanelID="pelMain" />
    <ext:Panel ID="pelMain" runat="server" EnableBackgroundColor="true" BodyPadding="3px"
        EnableLargeHeader="true" Title="Panel" AutoHeight="true" AutoScroll="true" ShowBorder="true"
        ShowHeader="false">
        <!--工具栏-->
        <Toolbars>
            <ext:Toolbar ID="Toolbar1" runat="server">
                <Items>
                    <ext:Button ID="btnClose" EnablePostBack="false" Text="关闭" runat="server" Icon="SystemClose" />
                    <ext:ToolbarSeparator ID="ToolbarSeparator2" runat="server" />
                    <ext:Button ID="btnSave" runat="server" ValidateForms="pelMain" OnClick="btnSave_Click"
                        IconUrl="~/Images/ico_nextstep.gif" Text="提交" ConfirmText="您确定要提交该申请吗?" />
                    <ext:Button ID="btnDismissed" Hidden="true" runat="server" ValidateForms="pelMain"
                        OnClick="btnDismissed_Click" IconUrl="~/Images/ico_firststep.gif" Text="不通过"
                        ConfirmText="您确定要不通过该申请吗?" />
                    <ext:Label runat="server" ID="HighMoneyTips" />
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
                            <ext:TextArea ID="taAuditOpinion" Label="审核意见" Enabled="false" Height="54px" runat="server"
                                Hidden="true" MaxLength="200" MaxLengthMessage="最多只能输入200个字符！" />
                        </Items>
                    </ext:FormRow>
                </Rows>
            </ext:Form>
            <ext:TabStrip ID="TabStrip1" runat="server" ActiveTabIndex="0" ShowBorder="false"
                AutoHeight="true" Height="362px">
                <Tabs>
                    <ext:Tab ID="TabForm" Title="表单" EnableBackgroundColor="true" runat="server" BodyPadding="5px">
                        <Items>
                            <ext:Form EnableBackgroundColor="true" LabelWidth="97px" ShowHeader="false" ShowBorder="false"
                                BodyPadding="5px" ID="mainForm" runat="server">
                                <Rows>
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
                                                Height="50px" runat="server" MaxLength="300" MaxLengthMessage="最多只能输入300个字符！" />
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ColumnWidths="50% 50%">
                                        <Items>
                                            <%--          <ext:TextBox ID="tbBorrowerNameA" Label="借款人（甲方）" ShowRedStar="true" Required="true"
                                runat="server" MaxLength="20" MaxLengthMessage="最多只能输入20个字符！" Regex="^[a-zA-Z0-9\u4e00-\u9fa5]*$"
                                RegexMessage="不能输入特殊字符!">
                            </ext:TextBox>--%>
                                            <ext:TriggerBox EnableEdit="true" ID="tbBorrowerNameA" Label="借款人(甲方)" TriggerIconUrl="~/Images/ico_16_grxx.gif"
                                                OnTriggerClick="tbBorrowerNameA_TriggerClick" EmptyText="" runat="server" ShowRedStar="true"
                                                Required="true">
                                            </ext:TriggerBox>
                                            <ext:TextBox ID="tbBorrowerPhone" Label="借款联系电话" runat="server" MaxLength="20" MaxLengthMessage="最多只能输入20个字符！"
                                                Regex="^1[0-9]{10}$" RegexMessage="手机号码格式不正确!" ShowRedStar="true" Required="true">
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
                                            <ext:TextBox ID="tbLoanTimeLimit" Label="借款期限" runat="server" ShowRedStar="true"
                                                Required="true">
                                            </ext:TextBox>
                                            <ext:DropDownList runat="server" Label="付款方式" ID="ddlLoanType" Hidden="true" HideMode="Display">
                                                <ext:ListItem Text="现金" Value="Cash" />
                                                <ext:ListItem Text="转账" Value="TransferAccount" Selected="true" />
                                            </ext:DropDownList>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ColumnWidths="50% 50%">
                                        <Items>
                                            <ext:TextBox ID="tbLoanAmount" Label="借款金额(元)" ShowRedStar="true" Required="true"
                                                AutoPostBack="true" OnTextChanged="tbCash_OnTextChanged" runat="server" MaxLength="16"
                                                MaxLengthMessage="最多只能输入16个数字！"  Regex="^[0-9]*\.?[0-9]{1,2}$" RegexMessage="只能输入数字!" CompareControl="tbCash"
                                                CompareType="Int" CompareOperator="GreaterThanEqual" CompareMessage="现金不能大于借款总金额">
                                            </ext:TextBox>
                                            <ext:TextBox ID="tbCash" Label="现金(元)" ShowRedStar="true" Required="true" runat="server"
                                                AutoPostBack="true" OnTextChanged="tbCash_OnTextChanged" MaxLength="16" MaxLengthMessage="最多只能输入16个数字！"
                                                Regex="^[0-9]*\.?[0-9]{1,2}$" RegexMessage="只能输入数字!" CompareControl="tbLoanAmount" CompareType="Int"
                                                CompareOperator="LessThanEqual" CompareMessage="现金不能大于借款总金额">
                                            </ext:TextBox>
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ColumnWidths="50% 50%">
                                        <Items>
                                            <ext:Label runat="server" ID="lbTransferAccount" Text="转账：0 元">
                                            </ext:Label>
                                            <ext:TextBox ID="tbRateOfReturn" Label="投资回报率(%)" runat="server" ShowRedStar="true"
                                                Required="true" MaxLength="10" MaxLengthMessage="最多只能输入10个数字！"  Regex="^[0-9]*\.?[0-9]{1,2}$"
                                                RegexMessage="只能输入数字!" />
                                        </Items>
                                    </ext:FormRow>
                                    <ext:FormRow ColumnWidths="50% 50%">
                                        <Items>
                                            <ext:DatePicker ID="dpLoanDate" Label="借款日期" ShowRedStar="true" Required="true" runat="server">
                                            </ext:DatePicker>
                                            <ext:TextBox ID="dpDueDateForPay" Label="应付借款日" ShowRedStar="true" Required="true"
                                                runat="server" MaxLength="2" MaxLengthMessage="最多只能输入2个数字！" Regex="^[0-9]*$"
                                                RegexMessage="只能输入数字!">
                                            </ext:TextBox>
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
                                            <ext:TextArea ID="tbRemark" Enabled="false" Label="备注" runat="server" MaxLength="200"
                                                Height="50px" MaxLengthMessage="最多只能输入200个字符！" />
                                        </Items>
                                    </ext:FormRow>
                                </Rows>
                            </ext:Form>
                        </Items>
                    </ext:Tab>
                    <ext:Tab ID="tabHistory" Title="操作历史" EnableBackgroundColor="true" runat="server"
                        Layout="Fit" BodyPadding="5px">
                        <Items>
                            <ext:Grid ID="gridHistory" Title="Grid1" ShowBorder="true" ShowHeader="false" runat="server"
                                IsDatabasePaging="true" EnableRowNumber="True" AutoScroll="true" AutoHeight="true">
                                <Columns>
                                    <ext:BoundField Width="52px" DataField="OperationerName" HeaderText="操作人" />
                                    <%--           <ext:BoundField Width="50px" DataField="OperationerAccount" HeaderText="帐号" />--%>
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
    <ext:Window ID="wndChooseZJ" Title="选取借款人" Popup="false" EnableIFrame="true" IFrameUrl="about:blank"
        Target="Parent" runat="server" IsModal="true" EnableConfirmOnClose="true" Height="460px"
        Width="590px" OnClose="wndChooseZJ_Close">
    </ext:Window>
    </form>
</body>
</html>
