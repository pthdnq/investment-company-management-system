<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewMaterials.aspx.cs" Inherits="TZMS.Web.NewMaterials" %>

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
                    <ext:Button ID="btnSubmit" Text="保存" Icon="Disk" runat="server" ValidateForms="pelMain"
                        OnClick="btnSubmit_Click" ConfirmText="您确定保存该物资吗?">
                    </ext:Button>
                </Items>
            </ext:Toolbar>
        </Toolbars>
        <Items>
            <ext:Panel ID="pelOperator" runat="server" ShowBorder="false" EnableBackgroundColor="true"
                BodyPadding="3px" ShowHeader="false" AnchorValue="100% - 36">
                <Items>
                    <ext:Form ID="mainForm2" EnableBackgroundColor="true" ShowHeader="false" BodyPadding="5px"
                        runat="server">
                        <Rows>
                            <ext:FormRow ColumnWidths="50%">
                                <Items>
                                    <ext:DropDownList ID="ddlstType" runat="server" Required="true" ShowRedStar="true"
                                        Label="物资类型">
                                    </ext:DropDownList>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow ColumnWidths="50%">
                                <Items>
                                    <ext:TextBox ID="tbxMaterialName" runat="server" Required="true" ShowRedStar="true"
                                        Label="物资名称" MaxLength="20" MaxLengthMessage="最多只能输入20个字!">
                                    </ext:TextBox>
                                </Items>
                            </ext:FormRow>
                            <ext:FormRow ColumnWidths="50%">
                                <Items>
                                    <ext:TextBox ID="tbxNumbers" runat="server" Required="true" ShowRedStar="true" Label="物资数量"
                                        Regex="^\d*$" RegexMessage="只能输入数字!">
                                    </ext:TextBox>
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
