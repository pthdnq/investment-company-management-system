<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MaterialsSubComsume.aspx.cs"
    Inherits="TZMS.Web.MaterialsSubComsume" %>

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
                    <ext:Button ID="btnPass" Text="领用" Icon="Accept" runat="server" ValidateForms="mainForm2"
                        OnClick="btnPass_Click" ConfirmText="您确定领用吗?">
                    </ext:Button>
                </Items>
            </ext:Toolbar>
        </Toolbars>
        <Items>
            <ext:Panel ID="pelOperator" runat="server" ShowBorder="false" EnableBackgroundColor="true"
                BodyPadding="3px" ShowHeader="false" AnchorValue="100% -36">
                <Items>
                    <ext:Form ID="mainForm2" EnableBackgroundColor="true" ShowHeader="false" BodyPadding="5px"
                        LabelWidth="85px" runat="server">
                        <Rows>
                            <ext:FormRow ColumnWidths="50% 50%">
                                <Items>
                                    <ext:Label ID="lblName" runat="server" Label="申请人">
                                    </ext:Label>
                                    <ext:Label ID="lblApplyTime" runat="server" Label="申请时间">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow ColumnWidths="50% 50%">
                                <Items>
                                    <ext:Label ID="ddlstType" runat="server" Label="物资类型">
                                    </ext:Label>
                                    <ext:Label ID="ddlstMaterials" runat="server" Label="物资名称">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow ColumnWidths="50%">
                                <Items>
                                    <ext:Label ID="lblTotalCount" runat="server" Label="物资总数量">
                                    </ext:Label>
                                    <ext:Label ID="tbxNumbers" runat="server" Label="申请数量">
                                    </ext:Label>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow ColumnWidths="50%">
                                <Items>
                                    <ext:TextBox ID="tbxActualCount" runat="server" Label="实际领用数量" Required="true" ShowRedStar="true"
                                        Regex="^\d*$" RegexMessage="只能输入数字!">
                                    </ext:TextBox>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow ColumnWidths="60%">
                                <Items>
                                    <ext:TextArea ID="taaOther" runat="server" Label="备注" Enabled="false" Height="200px">
                                    </ext:TextArea>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow ID="FormRow6" runat="server" ColumnWidths="50% 50%">
                                <Items>
                                    <ext:TextArea ID="taaApproveSugest" Height="50px" runat="server" Label="领用意见" MaxLength="100"
                                        MaxLengthMessage="最多只能输入100个字！">
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
