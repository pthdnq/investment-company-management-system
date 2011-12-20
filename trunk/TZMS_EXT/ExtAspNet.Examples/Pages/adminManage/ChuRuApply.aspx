<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChuRuApply.aspx.cs" Inherits="TZMS.Web.ChuRuApply" %>

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
                    <ext:Button ID="btnSubmit" Text="登记" Icon="Disk" runat="server" ValidateForms="pelMain"
                        OnClick="btnSubmit_Click" ConfirmText="您确定登记出门吗?">
                    </ext:Button>
                </Items>
            </ext:Toolbar>
        </Toolbars>
        <Items>
            <ext:Panel ID="pelOperator" runat="server" ShowBorder="false" EnableBackgroundColor="true"
                BodyPadding="3px" ShowHeader="false" AnchorValue="100% -36">
                <Items>
                    <ext:Form ID="mainForm2" EnableBackgroundColor="true" ShowHeader="false" BodyPadding="5px"
                        runat="server" LabelWidth="85px">
                        <Rows>
                            <ext:FormRow ColumnWidths="50% 50%">
                                <Items>
                                    <ext:Label ID="lblName" runat="server" Label="出门登记人">
                                    </ext:Label>
                                    <ext:Label ID="lblTime" runat="server" Label="出门登记时间">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow ColumnWidths="60%">
                                <Items>
                                    <ext:TextArea ID="taaReason" Required="true" ShowLabel="true" runat="server" Label="出门事由"
                                        MaxLength="1000" MaxLengthMessage="最多只能输入1000个字!" Height="300px">
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
