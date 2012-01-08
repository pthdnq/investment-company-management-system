﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OperatorNormalBusiness.aspx.cs"
    Inherits="TZMS.Web.OperatorNormalBusiness" %>

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
                    <ext:Button ID="btnSubmit" Text="确认办理" Icon="Disk" runat="server" ValidateForms="mainForm2"
                        OnClick="btnSubmit_Click" ConfirmText="您确定办理吗?">
                    </ext:Button>
                </Items>
            </ext:Toolbar>
        </Toolbars>
        <Items>
            <ext:Panel ID="pelOperator" runat="server" ShowBorder="false" EnableBackgroundColor="true"
                BodyPadding="3px" ShowHeader="false" AnchorValue="100% -36">
                <Items>
                    <ext:Form ID="mainForm2" EnableBackgroundColor="true" ShowHeader="false" BodyPadding="5px"
                        runat="server" LabelWidth="65px">
                        <Rows>
                            <ext:FormRow ColumnWidths="50% 50%">
                                <Items>
                                    <ext:DropDownList Required="true" ShowRedStar="true" ID="ddlstNext" runat="server"
                                        Label="下一步">
                                    </ext:DropDownList>
                                    <ext:DropDownList Required="true" ShowRedStar="true" ID="ddlstApproveUser" runat="server"
                                        Label="负责人">
                                    </ext:DropDownList>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow ColumnWidths="35% 35% 15% 15%">
                                <Items>
                                    <ext:TextBox ID="tbxCBJE" runat="server" Label="成本金额" Regex="^[0-9]*\.?[0-9]{1,2}$"
                                        RegexMessage="金额格式不正确!" MaxLength="21" MaxLengthMessage="最大只能输入21个长度的金额!">
                                    </ext:TextBox>
                                    <ext:TextBox ID="tbxQTFY" runat="server" Label="其它费用" Regex="^[0-9]*\.?[0-9]{1,2}$"
                                        RegexMessage="金额格式不正确!" MaxLength="21" MaxLengthMessage="最大只能输入21个长度的金额!">
                                    </ext:TextBox>
                                    <ext:CheckBox ID="cbxSecond" runat="server" Text="是否二次办理" ShowLabel="false" AutoPostBack="true"
                                        OnCheckedChanged="cbxSecond_CheckedChanged">
                                    </ext:CheckBox>
                                    <ext:Label ID="lblDate" runat="server" Label="查看资料">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow ColumnWidths="60%">
                                <Items>
                                    <ext:TextArea ID="taaQTFYSM" runat="server" Label="说明" Height="60px" MaxLength="500"
                                        MaxLengthMessage="最大只能输入500个字!">
                                    </ext:TextArea>
                                </Items>
                            </ext:FormRow>
                        </Rows>
                    </ext:Form>
                    <ext:TabStrip ID="TabStrip1" runat="server" ActiveTabIndex="0" ShowBorder="false"
                        AutoHeight="true" Height="430px">
                        <Tabs>
                            <ext:Tab ID="Tab1" Title="普通业务" EnableBackgroundColor="true" runat="server" BodyPadding="5px">
                                <Items>
                                    <ext:Form EnableBackgroundColor="true" LabelWidth="90px" ShowHeader="false" ShowBorder="false"
                                        BodyPadding="5px" ID="mainForm" runat="server">
                                        <Rows>
                                            <ext:FormRow ColumnWidths="50% 50%">
                                                <Items>
                                                    <ext:DropDownList ID="ddlstSigner" runat="server" Required="true" ShowRedStar="true"
                                                        Label="签单人">
                                                    </ext:DropDownList>
                                                    <ext:DatePicker ID="dpkSignTime" runat="server" Required="true" ShowRedStar="true"
                                                        Label="合同签订时间">
                                                    </ext:DatePicker>
                                                </Items>
                                            </ext:FormRow>
                                            <ext:FormRow ColumnWidths="60%">
                                                <Items>
                                                    <ext:TextBox ID="tbxCompanyName" runat="server" Required="true" ShowRedStar="true"
                                                        Label="公司名称">
                                                    </ext:TextBox>
                                                </Items>
                                            </ext:FormRow>
                                            <ext:FormRow ColumnWidths="50% 50%">
                                                <Items>
                                                    <ext:TextBox ID="tbxRegisteredMoney" runat="server" Label="注册资金" Regex="^[0-9]*\.?[0-9]{1,2}$"
                                                        RegexMessage="金额格式不正确!">
                                                    </ext:TextBox>
                                                    <ext:DropDownList ID="ddlstCZType" runat="server" Label="出资方式">
                                                        <ext:ListItem Text="分期出资" Value="0" />
                                                        <ext:ListItem Text="一次性出资" Value="1" />
                                                    </ext:DropDownList>
                                                </Items>
                                            </ext:FormRow>
                                            <ext:FormRow ColumnWidths="50% 50%">
                                                <Items>
                                                    <ext:DropDownList ID="ddlstCompanyType" runat="server" Label="公司类型">
                                                        <ext:ListItem Text="一般纳税人" Value="0" />
                                                        <ext:ListItem Text="小规模" Value="1" />
                                                    </ext:DropDownList>
                                                    <ext:DropDownList ID="ddlstCompanyNameType" runat="server" Label="公司名类型">
                                                        <ext:ListItem Text="安徽名" Value="0" />
                                                        <ext:ListItem Text="合肥名" Value="1" />
                                                    </ext:DropDownList>
                                                </Items>
                                            </ext:FormRow>
                                            <ext:FormRow ColumnWidths="50% 50%">
                                                <Items>
                                                    <ext:TextBox ID="tbxContact" runat="server" Label="联系人">
                                                    </ext:TextBox>
                                                    <ext:TextBox ID="tbxContactPhoneNumber" runat="server" Label="联系人电话/手机" Regex="(\(?\d{3,4}\)?)?[\s-]?\d{7,8}[\s-]?\d{0,4}"
                                                        RegexMessage="电话号码格式不正确!">
                                                    </ext:TextBox>
                                                </Items>
                                            </ext:FormRow>
                                            <ext:FormRow ColumnWidths="33% 33% 33%">
                                                <Items>
                                                    <ext:TextBox ID="tbxSumMoney" runat="server" Label="合同总金额" Regex="^[0-9]*\.?[0-9]{1,2}$"
                                                        RegexMessage="金额格式不正确!">
                                                    </ext:TextBox>
                                                    <ext:TextBox ID="tbxPreMoney" runat="server" Label="预付金额" Regex="^[0-9]*\.?[0-9]{1,2}$"
                                                        RegexMessage="金额格式不正确!">
                                                    </ext:TextBox>
                                                    <ext:TextBox ID="tbxBalanceMoney" runat="server" Label="业务余款金额" Regex="^[0-9]*\.?[0-9]{1,2}$"
                                                        RegexMessage="金额格式不正确!">
                                                    </ext:TextBox>
                                                </Items>
                                            </ext:FormRow>
                                            <ext:FormRow ColumnWidths="33% 33% 33%">
                                                <Items>
                                                    <ext:CheckBox ID="CheckBox1" Text="业务办理结束付款" runat="server" ShowLabel="false">
                                                    </ext:CheckBox>
                                                    <ext:CheckBox ID="CheckBox2" Text="注册资金客户垫付" runat="server" ShowLabel="false">
                                                    </ext:CheckBox>
                                                    <ext:CheckBox ID="CheckBox3" Text="银行工本费客户垫付" runat="server" ShowLabel="false">
                                                    </ext:CheckBox>
                                                </Items>
                                            </ext:FormRow>
                                            <ext:FormRow ColumnWidths="50% 50%">
                                                <Items>
                                                    <ext:TextBox ID="tbxCostMoney" runat="server" Label="成本金额" Regex="^[0-9]*\.?[0-9]{1,2}$"
                                                        RegexMessage="金额格式不正确!">
                                                    </ext:TextBox>
                                                    <ext:TextBox ID="tbxOtherMoney" runat="server" Label="其它费用" Regex="^[0-9]*\.?[0-9]{1,2}$"
                                                        RegexMessage="金额格式不正确!">
                                                    </ext:TextBox>
                                                </Items>
                                            </ext:FormRow>
                                            <ext:FormRow ColumnWidths="60%">
                                                <Items>
                                                    <ext:TextArea ID="taaOtherMoneyExplain" runat="server" Label="其它费用说明" Height="60px">
                                                    </ext:TextArea>
                                                </Items>
                                            </ext:FormRow>
                                            <ext:FormRow ColumnWidths="60%">
                                                <Items>
                                                    <ext:TextArea ID="taaContent" runat="server" Label="内容" Required="true" ShowRedStar="true"
                                                        Height="60px" EmptyText="请填写业务的大致内容">
                                                    </ext:TextArea>
                                                </Items>
                                            </ext:FormRow>
                                            <ext:FormRow ColumnWidths="60%">
                                                <Items>
                                                    <ext:TextArea ID="taaOther" runat="server" Label="备注" Height="60px">
                                                    </ext:TextArea>
                                                </Items>
                                            </ext:FormRow>
                                        </Rows>
                                    </ext:Form>
                                </Items>
                            </ext:Tab>
                            <ext:Tab ID="tabOperateHistory" Title="操作历史" EnableBackgroundColor="true" runat="server"
                                BodyPadding="5px">
                                <Items>
                                    <ext:Grid ID="gridoperateHistory" Title="Grid1" ShowBorder="true" ShowHeader="false"
                                        runat="server" IsDatabasePaging="true" EnableRowNumber="True" AutoScroll="true"
                                        AutoHeight="true" OnRowDataBound="gridoperateHistory_RowDataBound">
                                        <Columns>
                                            <ext:BoundField DataField="CheckerName" HeaderText="办理人" />
                                            <ext:BoundField DataField="CheckDateTime" HeaderText="办理时间" />
                                            <ext:BoundField DataField="CurrentBusiness" HeaderText="办理类型" />
                                            <ext:BoundField DataField="CostMoney" HeaderText="成本金额" />
                                            <ext:BoundField DataField="OtherMoney" HeaderText="其它费用" />
                                            <ext:BoundField DataField="Explain" HeaderText="说明" ExpandUnusedSpace="true" DataTooltipField="Explain" />
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
    <ext:Window ID="wndSpecialMoney" Title="特殊费用" Popup="false" EnableIFrame="true" IFrameUrl="about:blank"
        Target="Self" runat="server" IsModal="true" EnableConfirmOnClose="true" Height="200px"
        Width="400px" onclose="wndSpecialMoney_Close">
    </ext:Window>
    </form>
</body>
</html>