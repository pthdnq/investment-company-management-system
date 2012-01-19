<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProjectProcessAdd.aspx.cs"
    Inherits="TZMS.Web.Pages.BankLoanPages.ProjectProcessAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ProjectProcessAdd</title>
</head>
<body>
    <form id="form1" runat="server">
    <ext:PageManager ID="PageManager1" runat="server" AutoSizePanelID="pelMain" />
    <ext:Panel ID="pelMain" runat="server" EnableBackgroundColor="true" BodyPadding="3px"
        EnableLargeHeader="true" Height="389px" Title="Panel" AutoScroll="false" ShowBorder="true"
        ShowHeader="false">
        <!--工具栏-->
        <Toolbars>
            <ext:Toolbar ID="Toolbar1" runat="server">
                <Items>
                    <ext:Button ID="btnClose" EnablePostBack="false" Text="关闭" runat="server" Icon="SystemClose" />
                    <ext:ToolbarSeparator ID="ToolbarSeparator2" runat="server" />
                    <ext:Button ID="btnSave" runat="server" ValidateForms="pelMain" OnClick="btnSave_Click"
                        Icon="Disk" Text="提交" ConfirmText="您确定提交该表单吗?" />
                    <ext:Label runat="server" ID="HighMoneyTips" />
                </Items>
            </ext:Toolbar>
        </Toolbars>
        <Items>
           <ext:TabStrip ID="TabStrip1" runat="server" ActiveTabIndex="0" ShowBorder="false"
                AutoHeight="true" Height="474px">
                <Tabs>
                    <ext:Tab ID="TabForm" Title="表单" EnableBackgroundColor="true" runat="server" BodyPadding="5px">
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
                    <%--    <ext:FormRow ColumnWidths="50% 50%">
                        <Items>
                            <ext:TextBox Enabled="false" ID="tbxName" Label="项目名称" ShowRedStar="true" Required="true"
                                runat="server" MaxLength="20" MaxLengthMessage="最多只能输入20个字符！" Regex="^[a-zA-Z0-9\u4e00-\u9fa5]*$"
                                RegexMessage="不能输入特殊字符!" />
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ColumnWidths="50% 50%">
                        <Items>
                            <ext:TextBox Enabled="false" ID="TextBox2" Label="贷款银行" ShowRedStar="true" Required="true"
                                runat="server" MaxLength="20" MaxLengthMessage="最多只能输入20个字符！" Regex="^[a-zA-Z0-9\u4e00-\u9fa5]*$"
                                RegexMessage="不能输入特殊字符!" />
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ColumnWidths="50% 50%">
                        <Items>
                            <ext:TextBox Enabled="false" ID="TextBox3" Label="担保公司" ShowRedStar="true" Required="true"
                                runat="server" MaxLength="20" MaxLengthMessage="最多只能输入20个字符！" Regex="^[a-zA-Z0-9\u4e00-\u9fa5]*$"
                                RegexMessage="不能输入特殊字符!" />
                        </Items>
                    </ext:FormRow>--%>
                    <ext:FormRow ColumnWidths="50% 50%">
                        <Items>
                            <ext:TextArea ID="taImplementationPhase" Label="项目实施阶段" ShowRedStar="true" Required="true"
                                runat="server" MaxLength="100" MaxLengthMessage="最多只能输入100个字符！" />
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ColumnWidths="50% 50%">
                        <Items>
                            <ext:TextArea ID="taRemark" Label="备注" runat="server" MaxLength="200" MaxLengthMessage="最多只能输入200个字符！" />
                        </Items>
                    </ext:FormRow>
                    <ext:FormRow ColumnWidths="60% 40%">
                        <Items>
                            <ext:CheckBox ID="cbIsAmountExpended" runat="server" Text="申请备用金" Checked="false"
                                AutoPostBack="true" OnCheckedChanged="cbIsAmountExpended_OnCheckedChanged" />
                        </Items>
                    </ext:FormRow>
                </Rows>
            </ext:Form>
            <ext:GroupPanel AutoHeight="true" runat="server" ID="gpAmount" Title="备用金申请" EnableBackgroundColor="true">
                <Items>
                    <ext:Form EnableBackgroundColor="true" ShowHeader="false" BodyPadding="5px" ID="mainFrame2"
                        runat="server">
                        <Rows>
                            <ext:FormRow ColumnWidths="60% 40%">
                                <Items>
                                    <ext:TextBox Hidden="true" ID="tbImprestAmount" Label="备用金余额" ShowRedStar="true"
                                        Required="true" runat="server" MaxLength="10" MaxLengthMessage="最多只能输入10个数字！"
                                        Regex="^[0-9]*$" RegexMessage="只能输入数字!">
                                    </ext:TextBox>
                                    <ext:Label ID="Labeltmpx3" runat="server" />
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow ColumnWidths="60% 40%">
                                <Items>
                                    <ext:TextBox Hidden="true" ID="tbAmountExpended" Label="预支金额" ShowRedStar="true"
                                        Required="true" runat="server" MaxLength="10" MaxLengthMessage="最多只能输入10个数字！"
                                        Regex="^[0-9]*$" RegexMessage="只能输入数字!">
                                    </ext:TextBox>
                                    <ext:Label ID="Label1" runat="server" />
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow ColumnWidths="60% 40%">
                                <Items>
                                    <ext:TextBox Hidden="true" ID="tbExpendedTime" Label="支用时间" ShowRedStar="true" Required="true"
                                        runat="server" MaxLength="50" MaxLengthMessage="最多只能输入50个字符！">
                                    </ext:TextBox>
                                    <ext:Label ID="Label2" runat="server" />
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:TextArea Hidden="true" ID="tbUse" Label="用途" ShowRedStar="true" Required="true"
                                        runat="server" Height="50px" MaxLength="200" MaxLengthMessage="最多只能输入200个字符！">
                                    </ext:TextArea>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow>
                                <Items>
                                    <ext:TextArea Hidden="true" ID="tbImprestRemark" Label="备注"  
                                        runat="server" Height="50px" MaxLength="200" MaxLengthMessage="最多只能输入200个字符！">
                                    </ext:TextArea>
                                </Items>
                            </ext:FormRow>
                        </Rows>
                    </ext:Form>
                </Items>
            </ext:GroupPanel>
                    </Items>
                    </ext:Tab>
                    <ext:Tab ID="tabHistory" Title="操作记录" EnableBackgroundColor="true" runat="server"
                     Layout="Fit"    BodyPadding="5px">
                        <Items>
                            <ext:Grid ID="gridHistory" Title="Grid1" ShowBorder="true" ShowHeader="false" runat="server"
                                IsDatabasePaging="true" EnableRowNumber="True" AutoScroll="true" AutoHeight="true">
                                <Columns>
                                    <ext:BoundField Width="52px" DataField="OperationerName" HeaderText="操作人" />
                                    <%--          <ext:BoundField Width="50px" DataField="OperationerAccount" HeaderText="帐号" />--%>
                                    <ext:BoundField Width="100px" DataField="OperationTime" DataFormatString="{0:yyyy/MM/dd HH:mm}"
                                        HeaderText="操作时间" />
                                    <ext:BoundField Width="56px" DataField="OperationType" HeaderText="操作类型" />
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
