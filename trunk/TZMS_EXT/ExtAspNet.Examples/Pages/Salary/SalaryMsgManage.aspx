<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SalaryMsgManage.aspx.cs"
    Inherits="TZMS.Web.SalaryMsgManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <ext:PageManager ID="PageManager1" AutoSizePanelID="pelMain" HideScrollbar="true"
        runat="server" />
    <ext:Panel ID="pelMain" runat="server" EnableBackgroundColor="true" BodyPadding="3px"
        EnableLargeHeader="true" Title="Panel" ShowBorder="false" ShowHeader="false"
        Layout="Anchor">
        <Items>
            <ext:Form ID="Form2" ShowBorder="False" LabelWidth="55px" BodyPadding="5px" AnchorValue="100%"
                EnableBackgroundColor="true" ShowHeader="False" runat="server">
                <Rows>
                    <ext:FormRow ID="FormRow1" runat="server">
                        <Items>
                            <ext:DropDownList ID="ddlstYear" runat="server" Label="年份">
                            </ext:DropDownList>
                            <ext:DropDownList ID="ddlstMonth" runat="server" Label="月份">
                                <ext:ListItem Text="1" Value="1" />
                                <ext:ListItem Text="2" Value="2" />
                                <ext:ListItem Text="3" Value="3" />
                                <ext:ListItem Text="4" Value="4" />
                                <ext:ListItem Text="5" Value="5" />
                                <ext:ListItem Text="6" Value="6" />
                                <ext:ListItem Text="7" Value="7" />
                                <ext:ListItem Text="8" Value="8" />
                                <ext:ListItem Text="9" Value="9" />
                                <ext:ListItem Text="10" Value="10" />
                                <ext:ListItem Text="11" Value="11" />
                                <ext:ListItem Text="12" Value="12" />
                            </ext:DropDownList>
                            <ext:DropDownList ID="ddlstDept" runat="server" Label="部门名称">
                            </ext:DropDownList>
                            <ext:Button ID="btnSearch" runat="server" Text="查询" Icon="Magnifier" OnClick="btnSearch_Click">
                            </ext:Button>
                        </Items>
                    </ext:FormRow>
                </Rows>
            </ext:Form>
            <ext:Panel ID="pelGrid" ShowBorder="True" ShowHeader="false" AnchorValue="100% -36"
                Layout="Fit" runat="server">
                <Toolbars>
                    <ext:Toolbar ID="Toolbar1" runat="server">
                        <Items>
                            <ext:Button ID="btnNewSalaryMsg" runat="server" Text="新增薪资信息" Icon="Add" OnClick="btnNewSalaryMsg_Click">
                            </ext:Button>
                            <ext:Button ID="btnSave" runat="server" Text="保存所有员工薪资信息" Icon="Disk" OnClick="btnSave_Click">
                            </ext:Button>
                            <ext:Button ID="btnNewWorkerSalary" runat="server" Text="新增员工薪资信息" Hidden="false"
                                Icon="Add" OnClick="btnNewWorkerSalary_Click">
                            </ext:Button>
                        </Items>
                    </ext:Toolbar>
                </Toolbars>
                <Items>
                    <ext:Grid ID="gridWorkerSalaryMsg" Title="Grid1" ShowBorder="true" ShowHeader="false"
                        AllowPaging="true" runat="server" IsDatabasePaging="true" EnableRowNumber="True"
                        AutoHeight="true" OnPageIndexChange="gridWorkerSalaryMsg_PageIndexChange" OnRowCommand="gridWorkerSalaryMsg_RowCommand"
                        OnRowDataBound="gridWorkerSalaryMsg_RowDataBound">
                        <Columns>
                            <ext:BoundField DataField="ObjectID" Hidden="true" />
                            <ext:BoundField DataField="UserID" Hidden="true" />
                            <ext:BoundField DataField="SalaryMsgID" Hidden="true" />
                            <ext:BoundField DataField="Name" HeaderText="员工姓名" />
                            <ext:BoundField DataField="Dept" HeaderText="部门" />
                            <ext:TemplateField HeaderText="基本工资" Hidden="true">
                                <ItemTemplate>
                                    <asp:TextBox ID="tbxBaseSalary" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"BaseSalary") %>'
                                        MaxLength="21" Width="80px" Style="ime-mode: disabled" onkeypress="if ((event.keyCode<48 || event.keyCode>57) && event.keyCode!=46) event.returnValue=false;"></asp:TextBox>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField HeaderText="提成工资" Hidden="true">
                                <ItemTemplate>
                                    <asp:TextBox ID="tbxExamSalary" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ExamSalary") %>'
                                        MaxLength="21" Width="80px" Style="ime-mode: disabled" onkeypress="if ((event.keyCode<48 || event.keyCode>57) && event.keyCode!=46) event.returnValue=false;"></asp:TextBox>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField HeaderText="补贴" Hidden="true">
                                <ItemTemplate>
                                    <asp:TextBox ID="tbxBackSalary" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "BackSalary") %>'
                                        MaxLength="21" Width="80px" Style="ime-mode: disabled" onkeypress="if ((event.keyCode<48 || event.keyCode>57) && event.keyCode!=46) event.returnValue=false;"></asp:TextBox>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField HeaderText="其它" Hidden="true">
                                <ItemTemplate>
                                    <asp:TextBox ID="tbxOtherSalary" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "OtherSalary") %>'
                                        MaxLength="21" Width="80px" Style="ime-mode: disabled" onkeypress="if ((event.keyCode<48 || event.keyCode>57) && event.keyCode!=46) event.returnValue=false;"></asp:TextBox>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField HeaderText="应发工资总额" Hidden="true">
                                <ItemTemplate>
                                    <asp:TextBox ID="tbxShouldSalary" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ShouldSalary") %>'
                                        MaxLength="21" Width="80px" Style="ime-mode: disabled" onkeypress="if ((event.keyCode<48 || event.keyCode>57) && event.keyCode!=46) event.returnValue=false;"></asp:TextBox>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField HeaderText="实发工资总额" Hidden="true">
                                <ItemTemplate>
                                    <asp:TextBox ID="tbxSalary" runat="server" MaxLength="21" Width="80px" Text='<%# DataBinder.Eval(Container.DataItem, "Salary") %>'
                                        Style="ime-mode: disabled" onkeypress="if ((event.keyCode<48 || event.keyCode>57) && event.keyCode!=46) event.returnValue=false;"></asp:TextBox>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField HeaderText="基本工资" Width="150px">
                                <ItemTemplate>
                                    <asp:TextBox ID="tbxJBGZ" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"JBGZ") %>'
                                        MaxLength="50" Width="135px"></asp:TextBox>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField HeaderText="工龄工资">
                                <ItemTemplate>
                                    <asp:TextBox ID="tbxGLGZ" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"GLGZ") %>'
                                        MaxLength="50" Width="85px"></asp:TextBox>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField HeaderText="补发工资" Width="150px">
                                <ItemTemplate>
                                    <asp:TextBox ID="tbxSYQGZ" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"SYQGZ") %>'
                                        MaxLength="50" Width="135px"></asp:TextBox>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField HeaderText="年终奖">
                                <ItemTemplate>
                                    <asp:TextBox ID="tbxNZJ" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"NZJ") %>'
                                        MaxLength="50" Width="85px"></asp:TextBox>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField HeaderText="奖励工资">
                                <ItemTemplate>
                                    <asp:TextBox ID="tbxJLGZ" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"JLGZ") %>'
                                        MaxLength="50" Width="85px"></asp:TextBox>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField HeaderText="提成工资">
                                <ItemTemplate>
                                    <asp:TextBox ID="tbxKHGZ" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"KHGZ") %>'
                                        MaxLength="50" Width="85px"></asp:TextBox>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField HeaderText="餐补">
                                <ItemTemplate>
                                    <asp:TextBox ID="tbxCB" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"CB") %>'
                                        MaxLength="50" Width="85px"></asp:TextBox>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField HeaderText="交通补助">
                                <ItemTemplate>
                                    <asp:TextBox ID="tbxJTBZ" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"JTBZ") %>'
                                        MaxLength="50" Width="85px"></asp:TextBox>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField HeaderText="应发工资">
                                <ItemTemplate>
                                    <asp:TextBox ID="tbxYFGZ" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"YFGZ") %>'
                                        MaxLength="50" Width="85px" Style="ime-mode: disabled" onkeypress="if ((event.keyCode<48 || event.keyCode>57) && event.keyCode!=46) event.returnValue=false;"></asp:TextBox>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField HeaderText="迟到" Width="60px">
                                <ItemTemplate>
                                    <asp:TextBox ID="tbxCD" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"CD") %>'
                                        MaxLength="50" Width="45px"></asp:TextBox>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField HeaderText="早退" Width="60px">
                                <ItemTemplate>
                                    <asp:TextBox ID="tbxZT" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"ZT") %>'
                                        MaxLength="50" Width="45px"></asp:TextBox>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField HeaderText="旷工" Width="60px">
                                <ItemTemplate>
                                    <asp:TextBox ID="tbxKG" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"KG") %>'
                                        MaxLength="50" Width="45px"></asp:TextBox>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField HeaderText="事假" Width="60px">
                                <ItemTemplate>
                                    <asp:TextBox ID="tbxSJ" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"SJ") %>'
                                        MaxLength="50" Width="45px"></asp:TextBox>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField HeaderText="病假" Width="60px">
                                <ItemTemplate>
                                    <asp:TextBox ID="tbxBJ" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"BJ") %>'
                                        MaxLength="50" Width="45px"></asp:TextBox>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField HeaderText="社保" Width="60px">
                                <ItemTemplate>
                                    <asp:TextBox ID="tbxSB" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"SB") %>'
                                        MaxLength="50" Width="45px"></asp:TextBox>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField HeaderText="罚款" Width="60px">
                                <ItemTemplate>
                                    <asp:TextBox ID="tbxFK" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"FK") %>'
                                        MaxLength="50" Width="45px"></asp:TextBox>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField HeaderText="餐费" Width="60px">
                                <ItemTemplate>
                                    <asp:TextBox ID="tbxCF" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"CF") %>'
                                        MaxLength="50" Width="45px"></asp:TextBox>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField HeaderText="保洁费" Width="60px">
                                <ItemTemplate>
                                    <asp:TextBox ID="tbxBJF" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"BJF") %>'
                                        MaxLength="50" Width="45px"></asp:TextBox>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField HeaderText="旅游费" Width="60px">
                                <ItemTemplate>
                                    <asp:TextBox ID="tbxLYF" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"LYF") %>'
                                        MaxLength="50" Width="45px"></asp:TextBox>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField HeaderText="实发工资" Width="60px">
                                <ItemTemplate>
                                    <asp:TextBox ID="tbxSFGZ" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"SFGZ") %>'
                                        MaxLength="50" Width="45px" Style="ime-mode: disabled" onkeypress="if ((event.keyCode<48 || event.keyCode>57) && event.keyCode!=46) event.returnValue=false;"></asp:TextBox>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:TemplateField HeaderText="备注" Width="200px">
                                <ItemTemplate>
                                    <asp:TextBox ID="tbxContext" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Context") %>'
                                        MaxLength="100" Width="185px"></asp:TextBox>
                                </ItemTemplate>
                            </ext:TemplateField>
                            <ext:LinkButtonField Width="38px" Text="保存" CommandName="Save" />
                            <ext:LinkButtonField Width="38px" Text="删除" CommandName="Delete" ConfirmText="您确认删除该条员工薪资信息吗?" />
                        </Columns>
                    </ext:Grid>
                </Items>
            </ext:Panel>
        </Items>
    </ext:Panel>
    <ext:Window ID="wndNewSalaryMsg" Title="添加薪资信息" Popup="false" EnableIFrame="true"
        IFrameUrl="about:blank" Target="Parent" runat="server" IsModal="true" EnableConfirmOnClose="true"
        Height="500px" Width="700px" OnClose="wndNewSalaryMsg_Close">
    </ext:Window>
    <ext:Window ID="wndNewWorkerSalaryMsg" Title="添加员工薪资信息" Popup="false" EnableIFrame="true"
        IFrameUrl="about:blank" Target="Parent" runat="server" IsModal="true" EnableConfirmOnClose="true"
        Height="500px" Width="700px" OnClose="wndNewWorkerSalaryMsg_Close">
    </ext:Window>
    </form>
</body>
</html>
