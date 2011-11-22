<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProxyAccountingUnitNew.aspx.cs"
    Inherits="TZMS.Web.ProxyAccountingUnitNew" %>

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
                        ValidateForms="mainForm">
                    </ext:Button>
                </Items>
            </ext:Toolbar>
        </Toolbars>
        <Items>
            <ext:Panel ID="pelOperator" runat="server" ShowBorder="false" EnableBackgroundColor="true"
                BodyPadding="3px" ShowHeader="false" AnchorValue="100% -36">
                <Items>
                    <ext:Form EnableBackgroundColor="true" ShowHeader="false" ShowBorder="false" BodyPadding="5px"
                        ID="mainForm" runat="server" LabelWidth="60px">
                        <Rows>
                            <ext:FormRow ID="FormRow1" runat="server" ColumnWidths="50% 50%">
                                <Items>
                                    <ext:TextBox ID="tbxUnitName" runat="server" Required="true" ShowRedStar="true" Label="单位名称"
                                        MaxLength="50" MaxLengthMessage="最多只能输入50个字!">
                                    </ext:TextBox>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow ID="FormRow3" runat="server" ColumnWidths="50% 50%">
                                <Items>
                                    <ext:Label ID="lblAccountancy" runat="server" Label="代帐会计">
                                    </ext:Label>
                                    <ext:Button ID="btnSetAccountancy" runat="server" Text="设置代帐会计..." OnClick="btnSetAccountancy_Click">
                                    </ext:Button>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow ID="FormRow2" runat="server" ColumnWidths="60%">
                                <Items>
                                    <ext:TextBox ID="tbxTitle" runat="server" Required="true" ShowRedStar="true" Label="单位地址"
                                        MaxLength="100" MaxLengthMessage="最多只能输入100个字!">
                                    </ext:TextBox>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow ID="FormRow4" runat="server" ColumnWidths="60%">
                                <Items>
                                    <ext:TextArea ID="taaOther" MaxLength="200" MaxLengthMessage="最多只能输入200个字！" Height="200px"
                                        runat="server" Label="备注">
                                    </ext:TextArea>
                                </Items>
                            </ext:FormRow>
                        </Rows>
                    </ext:Form>
                </Items>
            </ext:Panel>
        </Items>
    </ext:Panel>
    <ext:Window ID="wndAccountancy" Title="设置代帐会计" Popup="false" EnableIFrame="true"
        IFrameUrl="about:blank" Target="Top" runat="server" IsModal="true" Width="560px"
        EnableConfirmOnClose="true" Height="450px" onclose="wndAccountancy_Close">
    </ext:Window>
    </form>
</body>
</html>
