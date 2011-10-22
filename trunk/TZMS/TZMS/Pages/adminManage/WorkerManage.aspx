<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WorkerManage.aspx.cs" Inherits="TZMS.Pages.adminManage.WorkerManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>员工管理</title>
    <script id="jart_js" type="text/javascript" src="../../resources/jart/jart.js"></script>
    <script type="text/javascript">
        function formatter(data, index) {

            return "<a href='#' onclick=\"leaveEvent('" + data.ID + "');\">离职</a>&nbsp;&nbsp;<a href='#'>编辑</a>&nbsp;&nbsp;<a href='#'>权限</a>&nbsp;&nbsp;<a href='#'>删除</a>";
        }

        $(document).ready(function () {

            initGridView();
            // 加载部门下拉框.
            bindDepts();
            // 加载GridView.
            //search();
            InitTool();
        });

        //        var dept = '全部';
        //        var state = '在职';
        //        var strSearch = '';

        function initGridView() {

            var dept = $('#cbxDept').val();
            var state = $('#cbxState').val();
            var strSearch = $('#tbxSearch').val();

            $("#grvUsers").grid({ url: window.location.href + "?" + 'op=getUser&dept=' + escape(dept) + '&state=' + escape(state) + '&txt=' + escape(strSearch)
            , gridline: 'all', pageMode: "local", pageSize: 15, pageList: [10, 15, 20], rownumbers: true, columns:
                    [
                        [
                            { title: "工号", field: "JobNo", align: "center" },
                            { title: "姓名", field: "Name", align: "center" },
                            { title: "账号", field: "AccountNo", align: "center" },
                            { title: "性别", field: "Sex", width: "80px", align: "center" },
                            { title: "部门", field: "Dept", width: "80px", align: "center" },
                            { title: "联系电话", field: "PhoneNumber", width: "150px", align: "center" },
                            { title: "员工状态", field: "State", width: "100px", align: "center" },
                            { title: "操作", width: "150px", formatter: formatter, align: "center" }
                        ]
                    ]
            });

        }

        //绑定部门
        function bindDepts() {
            $.ajax({
                url: "../../PageServer/Common.ashx", //公共服务
                data: 'op=getDept',
                success: function (result) {
                    var data = eval('(' + result + ')');
                    $('#cbxDept').combobox().bind(data);
                }
            });
        }

        // 离职事件.
        function leaveEvent(userID) {
            $.ajax({
                url: window.location.href,
                data: 'op=userLeave&ID=' + userID,
                success: function (result) {

                    // 离职成功.
                    if (parseInt(result) == -1) {

//                        var dept = $('#cbxDept').val();
//                        var state = $('#cbxState').val();
//                        var strSearch = $('#tbxSearch').val();

//                        $("#grvUsers").grid({
//                            url: window.location.href + "?" + 'op=getUser&dept=' + escape(dept) + '&state=' + escape(state) + '&txt=' + escape(strSearch)
//                        }).loadData();

                        $('#grvUsers').grid().loadData();
                    }
                }
            });
        }

        // 查询事件.
        function search() {

            var dept = $('#cbxDept').val();
            var state = $('#cbxState').val();
            var strSearch = $('#tbxSearch').val();

            $("#grvUsers").grid({
                url: window.location.href + '?op=getUser&dept=' + escape(dept) + '&state=' + escape(state) + '&txt=' + escape(strSearch)
            }).loadData();

            // 重新加载数据.
            //$('#grvUsers').grid().removeData('dataSource');
            //            $('#grvUsers').grid().rows.clear();
            //            $("#grvUsers").grid({
            //                url: window.location.href + "?" + 'op=getUser&dept=' + escape(dept) + '&state=' + escape(state) + '&txt=' + escape(strSearch),
            //                gridline: 'all',
            //                pageMode: "local",
            //                pageSize: 15,
            //                pageList: [10, 15, 20]
            //            }).loadData();


            //            $('#grvUsers').grid().reload(true);

            //            $.ajax({
            //                url: window.location.href,
            //                data: 'op=getUser&dept=' + escape(dept) + '&state=' + escape(state) + '&txt=' + escape(strSearch),
            //                success: function (result) {
            //                    var data = eval('(' + result + ')');
            //                    $('#grvUsers').grid().dataSource(data);
            //                    $('#grvUsers').grid().update();

            //                }
            //            });

            //            $("#grvUsers").empty();
            //            $("#grvUsers").grid({ url: window.location.href + "?" + 'op=getUser&dept=' + escape(dept) + '&state=' + escape(state) + '&txt=' + escape(strSearch)
            //            , gridline: 'all', pageMode: "local", pageSize: 15, pageList: [10, 15, 20], rownumbers: true, columns:
            //                    [
            //                        [
            //                            { title: "工号", field: "JobNo", align: "center" },
            //                            { title: "姓名", field: "Name", align: "center" },
            //                            { title: "账号", field: "AccountNo", align: "center" },
            //                            { title: "性别", field: "Sex", width: "80px", align: "center" },
            //                            { title: "部门", field: "Dept", width: "80px", align: "center" },
            //                            { title: "联系电话", field: "PhoneNumber", width: "150px", align: "center" },
            //                            { title: "员工状态", field: "State", width: "100px", align: "center" },
            //                            { title: "操作", width: "150px", formatter: formatter, align: "center" }
            //                        ]
            //                    ]
            //            });
        }

        //初始化图标
        function InitTool() {
            var data = [[
            //新增员工，弹出窗口显示
					{id: 'item2', text: '新增员工', iconurl: '../../images/information.gif', onclick: '' },
  		    	]];
            $('#tool').toolbar().bind(data);

        }


    </script>
</head>
<body style="background-color: #ecf3fd">
    <form id="form1" runat="server">
    <table>
        <tr>
            <td>
                部门<input type="text" id="cbxDept" art="combobox" />
            </td>
            <td>
                员工状态<input type="text" id="cbxState" art="combobox" datasource="[{value:1,text:'在职',selected:'True'},{value:0,text:'离职'}]" />
            </td>
            <td>
                <input id="tbxSearch" type="text" art="textbox" emptytext="请输入姓名或账号查询" />
                <span art="button" onclick="search();">查询</span>
            </td>
        </tr>
    </table>
    <div id="tool" style="margin-top: 5px;">
    </div>
    <div id="grvUsers">
    </div>
    </form>
</body>
</html>
