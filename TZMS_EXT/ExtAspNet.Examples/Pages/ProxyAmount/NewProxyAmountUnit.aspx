<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewProxyAmountUnit.aspx.cs"
    Inherits="TZMS.Web.NewProxyAmountUnit" %>

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
                    <ext:Button ID="btnClose" OnClick="btnClose_Click" runat="server" Icon="Cancel" Text="关闭">
                    </ext:Button>
                    <ext:Button ID="btnSave" OnClick="btnSave_Click" runat="server" Icon="Disk" Text="保存"
                        ValidateForms="mainForm" ConfirmText="您确认保存该单位吗?">
                    </ext:Button>
                </Items>
            </ext:Toolbar>
        </Toolbars>
        <Items>
            <ext:Panel ID="pelOperator" runat="server" ShowBorder="false" EnableBackgroundColor="true"
                BodyPadding="3px" ShowHeader="false" AnchorValue="100% -36">
                <Items>
                    <ext:Form EnableBackgroundColor="true" ShowHeader="false" ShowBorder="false" BodyPadding="5px"
                        ID="mainForm" runat="server" LabelWidth="80px">
                        <Rows>
                            <ext:FormRow ID="FormRow3" runat="server" ColumnWidths="50% 50%">
                                <Items>
                                    <ext:TextBox ID="lblAccountancy" runat="server" Label="代账会计" Required="true" ShowRedStar="true"
                                        Enabled="false">
                                    </ext:TextBox>
                                    <ext:Button ID="btnSetAccountancy" runat="server" Text="设置代账会计..." OnClick="btnSetAccountancy_Click">
                                    </ext:Button>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow ID="FormRow1" runat="server" ColumnWidths="50% 50%">
                                <Items>
                                    <ext:TextBox ID="tbxUnitName" runat="server" Required="true" ShowRedStar="true" Label="单位名称"
                                        MaxLength="50" MaxLengthMessage="最多只能输入50个字!">
                                    </ext:TextBox>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow ID="FormRow2" runat="server" ColumnWidths="60%">
                                <Items>
                                    <ext:TextBox ID="tbxTitle" runat="server" Required="true" ShowRedStar="true" Label="单位地址"
                                        MaxLength="100" MaxLengthMessage="最多只能输入100个字!">
                                    </ext:TextBox>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow ColumnWidths="50% 50%">
                                <Items>
                                    <ext:TextBox ID="tbxSMDJNumber" runat="server" Label="税名登记编码" MaxLength="50" MaxLengthMessage="最多只能输入50个字!">
                                    </ext:TextBox>
                                    <ext:TextBox ID="tbxDSBumber" runat="server" Label="地税编码" MaxLength="50" MaxLengthMessage="最多只能输入50个字!">
                                    </ext:TextBox>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow ColumnWidths="50% 50%">
                                <Items>
                                    <ext:TextBox ID="tbxFRSFZ" runat="server" Label="法人身份证" MaxLength="50" MaxLengthMessage="最多只能输入50个字!">
                                    </ext:TextBox>
                                    <ext:TextBox ID="tbxKHHYZH" runat="server" Label="开户银行账号" MaxLength="50" MaxLengthMessage="最多只能输入50个字!">
                                    </ext:TextBox>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow ColumnWidths="50% 50%">
                                <Items>
                                    <ext:TextBox ID="tbxContactPhoneNumber" runat="server" Label="联系人电话">
                                    </ext:TextBox>
                                    <ext:TextBox ID="tbxGSManager" runat="server" Label="国税管理员" MaxLength="50" MaxLengthMessage="最多只能输入50个字!">
                                    </ext:TextBox>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow ColumnWidths="50% 50%">
                                <Items>
                                    <ext:TextBox ID="tbxDSManager" runat="server" Label="地税管理员" MaxLength="50" MaxLengthMessage="最多只能输入50个字!">
                                    </ext:TextBox>
                                    <ext:Label ID="Label1" runat="server">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow ID="FormRow4" runat="server" ColumnWidths="60%">
                                <Items>
                                    <ext:TextArea ID="taaOther" MaxLength="200" EmptyText="可以填写单位联系电话等基本信息" MaxLengthMessage="最多只能输入200个字！"
                                        Height="200px" runat="server" Label="备注">
                                    </ext:TextArea>
                                </Items>
                            </ext:FormRow>
                        </Rows>
                    </ext:Form>
                </Items>
            </ext:Panel>
        </Items>
    </ext:Panel>
    <ext:Window ID="wndAccountancy" Title="设置代账会计" Popup="false" EnableIFrame="true"
        IFrameUrl="about:blank" Target="Top" runat="server" IsModal="true" Width="560px"
        EnableConfirmOnClose="true" Height="450px" OnClose="wndAccountancy_Close">
    </ext:Window>
    </form>
</body>
</html>
