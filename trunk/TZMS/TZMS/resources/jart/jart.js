/**
 * 加载所有jart相关js脚本文件
 */
(function() {
	// 获取jart文件的路径
	var jsPath = (function() {
		// 找jart_js或者找关键字jart的js文件
		var script = document.getElementById("jart_js");
		var scripts = document.getElementsByTagName("script");
		for ( var i = 0; i < scripts.length; i++) {
			if (!scripts[i].src)
				continue;
			var name = scripts[i].src
					.substr(scripts[i].src.lastIndexOf("/") + 1);
			if (name.toLowerCase().indexOf("jart") >= 0) {
				script = scripts[i];
				break;
			}
		}
		// 返回路径
		if (script)
			return script.src.substr(0, script.src.lastIndexOf("/") + 1);
		return null;
	})();

	// 加载js脚本文件
	function loadJS(file) {
		file = jsPath + file;
		document.write("<script type='text/javascript' src='" + file
				+ ".js'></script>");
	}

	if (!window.jQuery) {
		loadJS("jquery-1.6.2.min");
	}
	loadJS("jart.const");
	loadJS("jart.all");
})();