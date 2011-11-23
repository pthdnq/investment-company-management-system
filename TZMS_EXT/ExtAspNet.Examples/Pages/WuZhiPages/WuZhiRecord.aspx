<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WuZhiRecord.aspx.cs" Inherits="TZMS.Web.WuZhiRecord" %>

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
                    <ext:Button ID="btnSubmit" Text="领用" Icon="Disk" runat="server" ValidateForms="pelMain"
                        OnClick="btnSubmit_Click">
                    </ext:Button>
                </Items>
            </ext:Toolbar>
        </Toolbars>
        <Items>
            <ext:Panel ID="pelOperator" runat="server" ShowBorder="false" EnableBackgroundColor="true"
                BodyPadding="3px" ShowHeader="false" AnchorValue="100% -36">
                <Items>
                    <ext:TabStrip ID="TabStrip1" runat="server" ActiveTabIndex="0" ShowBorder="false"
                        AutoHeight="true" Height="389px">
                        <Tabs>
                            <ext:Tab ID="Tab1" Title="领用物资" EnableBackgroundColor="true" runat="server" BodyPadding="5px">
                                <Items>
                                    <ext:Form EnableBackgroundColor="true" LabelWidth="65px" ShowHeader="false" ShowBorder="false"
                                        BodyPadding="5px" ID="mainForm" runat="server">
                                        <Rows>
                                            <ext:FormRow ID="FormRow1" runat="server" ColumnWidths="60%">
                                                <Items>
                                                    <ext:Label ID="lblUser" runat="server" Label="申请人">
                                                    </ext:Label>
                                                    <ext:Label ID="lblApplyDate" runat="server" Label="申请时间">
                                                    </ext:Label>
                                                </Items>
                                            </ext:FormRow>
                                            <ext:FormRow ID="FormRow7" runat="server" ColumnWidths="60%">
                                                <Items>
                                                    <ext:TextBox ID="tbxTitle" runat="server" Label="标题" Required="true" ShowRedStar="true"
                                                        MaxLength="50" MaxLengthMessage="最多只能输入50个字！">
                                                    </ext:TextBox>
                                                </Items>
                                            </ext:FormRow>
                                            <ext:FormRow ID="FormRow8" runat="server" ColumnWidths="60%">
                                                <Items>
                                                    <ext:TextArea ID="taaRecord" runat="server" Label="记录" Required="true" ShowRedStar="true"
                                                        MaxLength="1000" MaxLengthMessage="最多只能输入1000个字！" Height="150px">
                                                    </ext:TextArea>
                                                </Items>
                                            </ext:FormRow>
                                        </Rows>
                                    </ext:Form>
                                </Items>
                            </ext:Tab>
                            <ext:Tab ID="tabRecordHistory" Title="领用历史" EnableBackgroundColor="true" runat="server"
                                BodyPadding="5px">
                                <Items>
                                    <ext:Grid ID="gridRecordHistory" Title="Grid1" ShowBorder="true" ShowHeader="false"
                                        runat="server" IsDatabasePaging="true" EnableRowNumber="True" AutoScroll="true"
                                        AutoHeight="true" OnRowDataBound="gridRecordHistory_RowDataBound" 
                                        OnRowCommand="gridRecordHistory_RowCommand">
                                        <Columns>
                                            <ext:BoundField DataField="ObjectId" Hidden="true" />
                                            <ext:BoundField DataField="UserName" HeaderText="领用人" />
                                            <ext:BoundField DataField="Title" HeaderText="标题" />
                                            <ext:BoundField DataField="Record" HeaderText="记录" DataTooltipField="Record" ExpandUnusedSpace="true" />
                                            <ext:BoundField DataField="RecorderName" HeaderText="记录人" />
                                            <ext:BoundField DataField="RecordTime" HeaderText="记录时间" />
                                            <ext:LinkButtonField Width="38px" Text="删除" CommandName="Delete" ConfirmText="确定删除该领用记录?" />
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
    </form>
</body>
</html>
