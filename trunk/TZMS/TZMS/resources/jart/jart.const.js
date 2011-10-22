/*
* jart常量定义
*/
window.jart_consts = {
    error_parameter_type: "方法{0}的参数{1}类型错误，应为{2}类型！",
    error_parameter_null: "方法{0}的参数{1}不能为空！",
    error_parameter_invalid: "方法{0}的参数{1}不是一个有效的参数，详情请查阅帮助文档！",
    error_object_already_exists: "标识为{0}类型为{1}对象已存在，不能重复创建！",
    error_node_render_invalid: "标识为{0}的元素无法渲染为类型为{1}的控件，因为不符合渲染逻辑！",
    error_control_type_not_realized: "不能创建类型为{0}的控件，因为此控件类型未实现！",
    error_convert_type_failed: "将值{0}转换为类型{1}失败！",
    error_layout_regin_invalid: "布局控件的区域必须为div块！",
    error_layout_region_middle_lost: "布局控件必须包含中间区域！",
    error_layer_title_unget: "无法加载标题！",

    info_loading_text: "正在加载..."
};

//默认皮肤
window.jart_theme = "default";

// 控件默认属性设置
window.jart_defaults = {
    iframe: {
        block: true
    }
};

window.jart_debug = true;

