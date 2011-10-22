var items =
[
{ name: "url", desc: "设置弹出层的链接地址" },
{ name: "title", desc: "设置弹出层的标题", defaultValue: "无标题窗口" },
{ name: "autotitle", desc: "当弹出层是内嵌页面模式时，弹出层标题是否随页面变化而改变标题" },
{ name: "callback", desc: "弹出层回调时调用的原窗口中的方法" },
{ name: "iframe", desc: "设置是否支持内嵌页面(iframe)模式" },
{ name: "target", desc: "设置弹出层的目标位置(枚举值:target/top)" },
{ name: "postgroup", desc: "控件向服务端请求时提交的表单项组，只有在此组内的表单项数据才会发到到服务端" },
{ name: "postfun", desc: "控件向服务端请求的标识，通常为服务端函数名称" },
{ name: "callfun", desc: "控件向服务端请求后的回调函数，其中第一个参数为回传的数据（JSON对象）" },
{ name: "blockable", desc: "控件向服务端请求时是否显示遮罩和等待提示" },
{ name: "click", desc: "鼠标单击事件" },
{ type: "方法", name: "open(mode)", desc: "弹出层控件弹出方法调用格式(1:普通模式 2:最大化模式)" }
];

$(function()
{
    document.title = "弹出层控件api（渲染标签：div）";

    items.each(function()
    {
        if (!this.type) this.type = "属性";
        if (!this.belong) this.belong = "弹出层控件";
    });

    $("#list").grid().bind(items);

    var toolbar = $("#tool").toolbar();
    toolbar.bind(
    [[
        { id: "ask", text: "提问", icon: "help" },
        { id: "suggest", text: "建议", iconurl: "../images/edit.gif" },
        null,
        { id: "search", text: "查询", icon: "search", onclick: function()
        {
            $("#lySearch").layer().open();
        }
        }, { id: "demo", text: "查看演示" }
    ]]
    );

    $("#cbBelong").combobox().bind([{ text: "全部", value: "all", selected: true }, { text: "弹出层控件", value: "弹出层控件"}]);
    $("#cbType").combobox().bind([{ text: "全部", value: "all", selected: true }, { text: "属性", value: "属性" }, { text: "方法", value: "方法" }, { text: "事件", value: "事件"}]);
    $("#btnOK").click(function()
    {
        var belong = $("#cbBelong").combobox().value();
        var type = $("#cbType").combobox().value();
        var arr = new Array();
        items.each(function()
        {
            if (belong != "all" && belong != this.belong) return;
            if (type != "all" && type != this.type) return;
            arr.push(this);
        });

        $("#list").grid().bind(arr);
        $("#lySearch").layer().close();
    });
});