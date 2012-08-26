<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SpecialMoney.aspx.cs" Inherits="TZMS.Web.SpecialMoney" %>

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
                    <ext:Button ID="btnSubmit" Text="提交" Icon="Disk" runat="server" ValidateForms="mainForm2"
                        OnClick="btnSubmit_Click" ConfirmText="您确定提交吗?">
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
                            <ext:FormRow ColumnWidths="60%">
                                <Items>
                                    <ext:TextBox ID="tbxSpcialMoney" runat="server" Label="特殊费用" Regex="^\-?[0-9]*\.?[0-9]{1,2}$" 
                                        RegexMessage="金额格式不正确!">
                                    </ext:TextBox>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow ColumnWidths="60%">
                                <Items>
                                    <ext:TextArea ID="taaSpcialMoney" runat="server" Label="特殊费用说明" Height="60px">
                                    </ext:TextArea>
                                </Items>
                            </ext:FormRow>
                        </Rows>
                    </ext:Form>
                </Items>
            </ext:Panel>
        </Items>
    </ext:Panel>
    </form>
</body>
</html>
