<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserLeaveTransfer.aspx.cs"
    Inherits="TZMS.Web.UserLeaveTransfer" %>

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
                    <ext:Button ID="btnPass" Text="确定交接" Icon="Accept" runat="server" ValidateForms="mainForm2"
                        OnClick="btnPass_Click" ConfirmText="您确定交接吗?">
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
                            <ext:FormRow ID="FormRow4" runat="server" ColumnWidths="50% 50%">
                                <Items>
                                    <ext:DropDownList ID="ddlstArchiver" runat="server" Required="true" ShowRedStar="true"
                                        Label="执行人">
                                    </ext:DropDownList>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow ID="FormRow1" runat="server" ColumnWidths="50% 50%">
                                <Items>
                                    <ext:Label ID="lblName" runat="server" Label="离职员工">
                                    </ext:Label>
                                    <ext:Label ID="lblPostion" runat="server" Label="职务">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow ID="FormRow2" runat="server" ColumnWidths="60%">
                                <Items>
                                    <ext:Label ID="lblLeaveDate" runat="server" Label="拟离职时间">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow ID="FormRow3" runat="server" ColumnWidths="60%">
                                <Items>
                                    <ext:TextArea ID="taaOther" runat="server" Height="100px" Label="交接内容" Required="true"
                                        ShowRedStar="true" MaxLength="200" MaxLengthMessage="最多只能输入200个字!">
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
