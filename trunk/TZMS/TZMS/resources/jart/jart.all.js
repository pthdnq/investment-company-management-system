//+-------------------------------------------------------------------+
//+ CreateTime:     2011-06-01
//+ModifyTime:      2011-10-13 17:16:35
//+ FileName: 	    jArt-all.js
//+ Author:         陈家军
//+ Company:        科大讯飞
//+ CopyRight:      版权所有，请勿非法使用和传播
//+ Email:          fengxia520@gmail.com
//+ Description:    jArt框架库完全版，基于jquery
//+-------------------------------------------------------------------+

/* 
* 基础对象的扩展以及一些全局函数定义
*/
(function (undefined) {
    /**
    * <summary group="property" name="window.jart_path" type="string">
    * jart文件的路径
    * </summary>
    */
    window.jart_path = (function () {
        // 找jart_js或者找关键字jart的js文件
        var script = document.getElementById("jart_js");
        var scripts = document.getElementsByTagName("script");
        for (var i = 0; i < scripts.length; i++) {
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

    /**
    * <summary group="method" name="document.getCookie">    
    * 获取cookie的值
    * </summary>
    * <param name="key">
    * cookie的键
    * </param>
    * <returns>
    * cookie的值
    * </returns>
    */
    document.getCookie = function (key) {
        if (key === undefined) return document.cookie;
        var cookies = document.cookie.split("; ");
        for (var i = 0; i < cookies.length; i++) {
            var nv = cookies[i].split("=");
            if (nv[0] == escape(key)) return unescape(nv[1]);
        }
        return null;
    };

    /**
    * <summary group="method" name="document.setCookie">    
    * 设置cookie的值
    * </summary>
    * <param name="key">
    * cookie的键
    * </param>
    * <param name="value">
    * cookie的值
    * </param>
    * <param name="expires">
    * cookie过期时间
    * </param>
    */
    document.setCookie = function (key, value, expires) {
        if (key === undefined) throw new Error(jart_consts.error_parameter_null.format("document.setCookie", "key"));
        if (value === undefined) throw new Error(jart_consts.error_parameter_null.format("document.setCookie", "value"));
        var str = escape(key) + "=" + escape(value);
        if (expires instanceof Date) str += ";expires=" + expires.toGMTString();
        document.cookie = str;
    };

    /**
    * <summary group="method" name="document.deleteCookie">    
    * 删除cookie的值
    * </summary>
    * <param name="key">
    * cookie的键
    * </param>
    */
    document.deleteCookie = function (key) {
        this.setCookie(key, "delete", (new Date()).addSeconds(-1));
    };

    /**
    * <summary group="method" name="window.jart_changeTheme">    
    * 切换jart控件的皮肤
    * </summary>
    * <param name="theme">
    * 皮肤名称
    * </param>
    */
    window.jart_changeTheme = function (theme) {
        if (!theme) theme = "default";
        window.jart_currentTheme = theme;
        var css = jart_path + "themes/" + theme + "/";
        document.getElementById("jart_theme_icon").setAttribute("href", css + "icons.css");
        document.getElementById("jart_theme_main").setAttribute("href", css + "main.css");
        document.setCookie("jart_theme", theme, (new Date()).addMonths(1));

        var iframes = document.getElementsByTagName("iframe");
        for (var i = 0; i < iframes.length; i++) {
            try {
                iframes[i].contentWindow.jart_changeTheme(theme);
            } catch (e) { }
        }
    };

    //加载样式
    (function () {
        //cookie中的皮肤优先级最高，其次到配置文件，最后是default
        var theme = document.getCookie("jart_theme") || jart_theme || "default";
        window.jart_currentTheme = theme;
        var css = jart_path + "themes/" + theme + "/";
        document.write("<link id='jart_theme_icon' href='" + css + "icons.css' rel='stylesheet' />");
        document.write("<link id='jart_theme_main' href='" + css + "main.css' rel='stylesheet' />");
    })();

    /**
    * <summary group="property" name="{Array}.isArray" type="Boolean">
    * 判断对象是否为数组
    * </summary>
    */
    Array.prototype.isArray = true;

    /**
    * <summary group="method" name="{Array}.insert">    
    * 在数组中指定位置插入对象
    * </summary>
    * <param name="item">
    * 待插入的对象
    * </param>
    * <param name="index">
    * 待插入的位置，如果为空则插到最后的位置
    * </param>
    * <returns>
    * 返回新添加项的位置
    * </returns>
    */
    Array.prototype.insert = function (item, index) {
        if (index === null || isNaN(index) || index >= this.length) {
            index = this.length;
            this.push(item);
        } else {
            if (index < 0)
                index = 0;
            this.push(null);
            for (var i = this.length; i--; i > index) {
                this[i] = this[i - 1];
            }
            this[index] = item;
        }
        return { item: item, index: index };
    };

    /**
    * <summary group="method" name="{Array}.removeAt">    
    * 移除数组中指定位置的对象
    * </summary>
    * <param name="index">
    * 指定位置
    * </param>
    * <returns>
    * 被移除的对象
    * </returns>
    */
    Array.prototype.removeAt = function (index) {
        if (isNaN(index))
            throw new Error(jart_consts.error_parameter_type.format(
					"Array.removeAt", "index", "int"));
        if (index >= 0 || index < this.length) {
            var item = this.splice(index, 1)[0];
            return { item: item, index: index };
        }
    };

    /**
    * <summary group="method" name="{Array}.remove">    
    * 移除数组中指定的对象
    * </summary>
    * <param name="item">
    * 指定对象
    * </param>
    * <returns>
    * 被移除的对象
    * </returns>
    */
    Array.prototype.remove = function (item) {
        for (var i = 0; i < this.length; i++) {
            if (this[i] == item) {
                this.removeAt(i);
                return { item: item, index: i };
            }
        }
    };

    /**
    * <summary group="method" name="{Array}.clear">    
    * 清空数组
    * </summary>
    */
    Array.prototype.clear = function () {
        this.length = 0;
    };

    /**
    * <summary group="method" name="{Array}.contains">    
    * 判断数组中是否包含指定对象
    * </summary>
    * <param name="item">
    * 指定对象
    * </param>
    * <returns>
    * {Boolean}
    * </returns>
    */
    Array.prototype.contains = function (item) {
        for (var i = 0; i < this.length; i++) {
            if (this[i] == item) {
                return true;
            }
        }
        return false;
    };

    /**
    * <summary group="method" name="{Array}.find">
    * 从数组中查找满足条件的项
    * </summary>
    * <param name="fn">
    * 对项执行的方法，如果返回true，则此项满足条件，否则不满足条件
    * </param>
    * <returns type="">
    * 返回所有满足条件的项
    * </returns>
    */
    Array.prototype.find = function (fn) {
        var arr = new Array();
        this.each(function () {
            if (fn.call(this)) arr.push(this);
        });
        return arr;
    };

    /**
    * <summary group="method" name="{Array}.each">    
    * 对数组中每个元素执行指定函数
    * </summary>
    * <param name="fn">
    * 指定函数
    * </param>
    */
    Array.prototype.each = function (fn) {
        var length = this.length;
        for (var i = 0; i < length; i++) {
            fn.call(this[i], i);
        }
    };

    /**
    * <summary group="method" name="Boolean.parse">    
    * 转换对象为boolean型
    * </summary>
    * <param name="obj">
    * @returns {Boolean}
    * </param>
    */
    Boolean.parse = function (obj) {
        if (obj == "false")
            return false;
        if (obj == "0")
            return false;
        if (obj)
            return true;
        return false;
    };

    /**
    * <summary group="method" name="{Number}.toSize">    
    * 获取整数的字符形式，当整数位数小于size时，向前补0
    * </summary>
    * <param name="size">
    * 字符串最小长度
    * </param>
    * <returns>
    * 
    * </returns>
    */
    Number.prototype.toSize = function (size) {
        var str = this.toString();
        for (var i = size; i > str.length; i--) {
            str = "0" + str;
        }
        return str;
    };

    /**
    * <summary group="method" name="Function.parse">    
    * 转换指定对象为函数
    * </summary>
    * <param name="obj">
    * 指定对象
    * </param>
    * <param name="params">
    * 参数集合，可以为一个数组或多个字符串参数
    * </param>
    * <returns>
    * 
    * </returns>
    */
    Function.parse = function (obj, params) {
        if (obj) {
            if (typeof (obj) == "function")
                return obj;
            if (typeof (obj) == "string") {
                if (window[obj])
                    return window[obj];
                var str = "return new Function(";
                if (arguments.length > 1) {
                    if (params instanceof Array)
                        for (var i = 0; i < params.length; i++)
                            str += "'" + params[i] + "',";
                    else
                        for (var i = 1; i < arguments.length; i++)
                            str += "'" + arguments[i] + "',";
                }
                str += "\"" + obj + "\");";
                var fn = new Function(str);
                return fn();
            }
        }
        return null;
    };

    /**
    * <summary group="method" name="Function.extend">    
    * 函数类继承
    * </summary>
    * <param name="c">
    * 子类名称
    * </param>
    * <param name="p">
    * 父类
    * </param>
    */
    Function.extend = function (c, p, attrs) {
        if (!c || (typeof (c) == "string" && typeof (c) == "function")) throw new Error(jart_consts.error_parameter_type.format("Function.extend", "c", "string,function"));
        if (!p || typeof (p) != "function") throw new Error(jart_consts.error_parameter_type.format("Function.extend", "p", "function"));
        if (attrs && (!attrs instanceof Array)) throw new Error(jart_consts.error_parameter_type.format("Function.extend", "attrs", "array"));
        var oc = null;
        if (typeof (c) == "string") {
            var cs = c.split(".");
            c = "window";
            for (var i = 0; i < cs.length; i++) c += "['" + cs[i] + "']";
            oc = eval(c);

            // 构造函数继承
            eval(c + "=function(){arguments.callee.parent.apply(this, arguments);arguments.callee.me.apply(this, arguments);};");
            c = eval(c);
        }
        else {
            oc = c;
            c = function () { arguments.callee.parent.apply(this, arguments); arguments.callee.me.apply(this, arguments); };
        }
        c.me = oc;
        c.parent = p;

        // 原型继承
        for (var key in c.parent.prototype) {
            if (attrs && attrs.contains(key) && jQuery) {
                c.prototype[key] = jQuery.extend({}, c.prototype[key], c.parent.prototype[key]);
            }
            else c.prototype[key] = c.parent.prototype[key];
        }
        for (var key in c.me.prototype) {
            if (attrs && attrs.contains(key) && jQuery) {
                c.prototype[key] = jQuery.extend({}, c.prototype[key], c.me.prototype[key]);
            }
            else c.prototype[key] = c.me.prototype[key];
        }
        c.prototype.constructor = c;
        return c;
    };

    /**
    * <summary group="method" name="{Function}.attachRenderValueAttribute">    
    * 添加渲染属性方法和属性
    * </summary>
    */
    Function.prototype.attachRenderAttrAttribute = function (types) {
        /*
        * <summary group="property" name="this.prototype.attrTypes" type="Object">
        * 对象的所有属性类型集合
        * </summary>
        */
        this.prototype.attrTypes = types || {};

        /*
        * <summary group="property" name="this.prototype.attrNames" type="Object">
        * 缓存的属性名称对应规则集合
        * </summary>
        */
        this.prototype.attrNames = {};

        /**
        * <summary group="event" name="{this}.onAttr">
        * 当属性被赋值后触发
        * </summary>
        * <param name="name">
        * 属性名称
        * </param>
        * <param name="val">
        * 属性值
        * </param>
        */
        this.prototype.onAttr = function (name, val) { };
        /**
        * <summary group="event" name="{this}.onBeforeAttr">
        * 当属性被赋值前触发
        * </summary>
        * <param name="name">
        * 属性名称
        * </param>
        * <param name="val">
        * 属性名称
        * </param>
        * <returns type="Boolean">
        * 如果返回false则停止赋值操作
        * </returns>
        */
        this.prototype.onBeforeAttr = function (name, val) { };

        // 设置或获取方法
        // 1.将一个属性集渲染到对象上，如有必要则用fields映射替换，并且排除数组ex中的属性名渲染
        // 2.设置一个属性的值
        // 3.获取一个属性的值
        this.prototype.attr = function (attrs, fields, ex) {
            if (typeof (attrs) == "string") {
                var key = attrs.lower();
                if (["attr", "attrnames", "attrtypes", "onattr",
						"onbeforeattr"].contains(key))
                    return;

                // 找到属性对应的属性名或方法名
                var owned = false;
                if (this[key] !== undefined)
                    owned = true;
                else {
                    if (this.attrNames[key]) {
                        key = this.attrNames[key];
                        owned = true;
                    } else {
                        if (this[attrs] !== undefined) {
                            this.attrNames[key] = name;
                            key = attrs;
                            owned = true;
                        } else {
                            for (var name in this) {
                                if (name.lower() == key) {
                                    this.attrNames[key] = name;
                                    key = name;
                                    owned = true;
                                    break;
                                }
                            }
                        }
                    }
                }

                // 获取或设置属性
                if (owned) {
                    if (fields === undefined) {
                        var val = null;
                        if (typeof (this[key]) == "function") {
                            if (!this.attrTypes[key])
                                val = this[key]();
                            else {
                                var type = this.attrTypes[key][0];
                                // 是否是函数式属性，函数式属性将通过调用函数获取属性
                                var isfn = this.attrTypes[key][1];
                                if (type == "o" || type == "f") {
                                    if (isfn == "1" && typeof (this[key]) == "function")
                                        val = this[key]();
                                    else
                                        val = this[key];
                                } else
                                    val = this[key]();
                            }
                        } else
                            val = this[key];
                        if (this["get_" + key]) val = this["get_" + key](val);
                        return val;
                    } else {
                        if (this["set_" + key]) fields = this["set_" + key](fields, ex);
                        var type = "", isfn = "", ext = "";
                        if (this.attrTypes[key]) {
                            type = this.attrTypes[key][0];
                            // 是否是函数式属性，函数式属性将通过调用函数设置属性
                            isfn = this.attrTypes[key][1];
                            // 一些类型转换需要额外的参数
                            ext = this.attrTypes[key][2];
                        }
                        var val = Math.convertTo(fields, type, ext);
                        if (typeof (this.onBeforeAttr) == "function" && this.onBeforeAttr(key, val, ex) === false)
                            return;
                        if (typeof (this[key]) == "function") {
                            if (!this.attrTypes[key])
                                this[key](val, ex);
                            else {
                                if (type == "o" || type == "f") {
                                    if (isfn == "1" && typeof (this[key]) == "function")
                                        this[key](val, ex);
                                    else
                                        this[key] = val;
                                } else
                                    this[key](val, ex);
                            }
                        } else
                            this[key] = val;
                        if (typeof (this.onAttr) == "function")
                            this.onAttr(key, val, ex);
                    }
                }
            } else if (typeof (attrs) == "object") {
                // 反映射
                var xfields = {};
                if (fields) {
                    for (var key in fields) {
                        xfields[fields[key]] = key;
                    }
                }

                // 最小化例外属性串
                var lex = [];
                if (ex) {
                    for (var i = 0; i < ex.length; i++) {
                        lex.push(ex[i].lower());
                    }
                }

                for (var key in attrs) {
                    var mkey = key;
                    if (xfields[mkey])
                        mkey = xfields[mkey];
                    if (lex.contains(mkey.lower()))
                        continue;
                    this.attr(mkey, attrs[key], fields);
                }
            }
        };
    };

    /**
    * <summary group="method" name="{String}.lower">    
    * 转换为小写
    * </summary>
    * <returns>
    * 
    * </returns>
    */
    String.prototype.lower = function () {
        return this.toLowerCase();
    };

    /**
    * <summary group="method" name="{String}.upper">    
    * 转换为大写
    * </summary>
    * <returns>
    * 
    * </returns>
    */
    String.prototype.upper = function () {
        return this.toUpperCase();
    };

    /**
    * <summary group="method" name="{String}.starts">    
    * 判断字符串是否以指定的字符串开始
    * </summary>
    * <param name="s">
    * 指定的字符串
    * </param>
    * <returns>
    * {Boolean}
    * </returns>
    */
    String.prototype.starts = function (s) {
        if (this.length < s.length)
            return false;
        return this.indexOf(s) == 0;
    };

    /**
    * <summary group="method" name="{String}.ends">    
    * 判断字符串是否以指定的字符串结束
    * </summary>
    * <param name="s">
    * 指定的字符串
    * </param>
    * <returns>
    * {Boolean}
    * </returns>
    */
    String.prototype.ends = function (s) {
        if (this.length < s.length)
            return false;
        return this.lastIndexOf(s) == this.length - s.length;
    };

    /**
    * <summary group="method" name="{String}.ltrim">    
    * 修整字符串头部,不指定参数则修整空格
    * </summary>
    * <param name="s">
    * 修整子串
    * </param>
    * <returns>
    * 
    * </returns>
    */
    String.prototype.ltrim = function (s) {
        if (!s)
            s = " ";
        if (this.starts(s)) {
            return this.substr(s.length).ltrim(s).toString();
        }
        return this.toString();
    };

    /**
    * <summary group="method" name="{String}.rtrim">    
    * 修整字符串尾部，不指定参数则修整空格
    * </summary>
    * <param name="s">
    * 修整子串
    * </param>
    * <returns>
    * 
    * </returns>
    */
    String.prototype.rtrim = function (s) {
        if (!s)
            s = " ";
        if (this.ends(s)) {
            return this.substr(0, this.length - s.length).rtrim(s).toString();
        }
        return this.toString();
    };

    /**
    * <summary group="method" name="{String}.trim">    
    * 修整字符串两端，不指定参数则修整空格
    * </summary>
    * <param name="s">
    * 修整子串
    * </param>
    * <returns>
    * 
    * </returns>
    */
    String.prototype.trim = function (s) {
        return this.ltrim(s).rtrim(s).toString();
    };

    /**
    * <summary group="method" name="{String}.size">    
    * 获取字符串的字节长度
    * </summary>
    * <returns>
    * 字节长度
    * </returns>
    */
    String.prototype.size = function () {
        var reg = /[\u4E00-\u9FA5]/g;
        return this.replace(reg, "aa").length;
    };

    /**
    * <summary group="method" name="{String}.format">    
    * 格式化字符串
    * </summary>
    * <param name="arr">
    * 格式对象集合，可为数组或多个参数
    * </param>
    * <returns>
    * {String}
    * </returns>
    */
    String.prototype.format = function (arr) {
        var result = this;
        var arrx = arr;
        if (!(arr instanceof Array))
            arrx = arguments;
        for (var i = 0; i < arrx.length; i++) {
            result = result.replace(new RegExp("\\{" + i + "\\}", "ig"),
					arrx[i]);
        }
        return result;
    };

    /**
    * <summary group="method" name="{Date}.addDays">    
    * 向日期添加指定的天数
    * </summary>
    * <param name="d">
    * 天数
    * </param>
    * <returns>
    * {Date}
    * </returns>
    */
    Date.prototype.addDays = function (d) {
        var nd = new Date(this);
        nd.setDate(nd.getDate() + d);
        return nd;
    };

    /**
    * <summary group="method" name="{Date}.addMonths">    
    * 向日期添加指定的月数
    * </summary>
    * <param name="m">
    * 月数
    * </param>
    * <returns>
    * {Date}
    * </returns>
    */
    Date.prototype.addMonths = function (m) {
        var nd = new Date(this);
        nd.setMonth(nd.getMonth() + m);
        return nd;
    };

    /**
    * <summary group="method" name="{Date}.addYears">    
    * 向日期添加指定的年数
    * </summary>
    * <param name="y">
    * 年数
    * </param>
    * <returns>
    * {Date}
    * </returns>
    */
    Date.prototype.addYears = function (y) {
        var nd = new Date(this);
        nd.setFullYear(nd.getFullYear() + y);
        return nd;
    };

    /**
    * <summary group="method" name="{Date}.addHours">    
    * 向日期添加指定的小时数
    * </summary>
    * <param name="h">
    * 小时数
    * </param>
    * <returns>
    * {Date}
    * </returns>
    */
    Date.prototype.addHours = function (h) {
        var nd = new Date(this);
        nd.setHours(nd.getHours() + h);
        return nd;
    };

    /**
    * <summary group="method" name="{Date}.addMinutes">    
    * 向日期添加指定的分钟数
    * </summary>
    * <param name="m">
    * 分钟数
    * </param>
    * <returns>
    * {Date}
    * </returns>
    */
    Date.prototype.addMinutes = function (m) {
        var nd = new Date(this);
        nd.setMinutes(nd.getMinutes() + m);
        return nd;
    };

    /**
    * <summary group="method" name="{Date}.addSeconds">    
    * 向日期添加指定的秒数
    * </summary>
    * <param name="s">
    * 秒数
    * </param>
    * <returns type="Date">
    * 日期
    * </returns>
    */
    Date.prototype.addSeconds = function (s) {
        var nd = new Date(this);
        nd.setSeconds(nd.getSeconds(), s);
        return nd;
    };

    /**
    * <summary group="method" name="{Date}.equals">    
    * 比较日期之间的大小,m表示是比较是否包含时间比较
    * </summary>
    * <param name="d">
    * 被比较的时间
    * </param>
    * <param name="m">
    * 是否包含时间比较
    * </param>
    * <returns>
    * {Number}
    * </returns>
    */
    Date.prototype.equals = function (d, m) {
        if (m)
            return this.getTime() - d.getTime();
        var d1 = new Date(d.toDateString());
        var d2 = new Date(this.toDateString());
        return d2 - d1;
    };

    /**
    * <summary group="method" name="{Date}.format">    
    * 格式化时间字符串
    * </summary>
    * <param name="f">
    * 格式化串
    * </param>
    * <returns>
    * 
    * </returns>
    */
    Date.prototype.format = function (f) {
        f = f.replace("%y", this.getFullYear());

        var month = this.getMonth() + 1;
        if (month < 10)
            month = "0" + month;
        f = f.replace("%MM", month);
        f = f.replace("%M", month.toString().ltrim("0"));

        var day = this.getDate();
        if (day < 10)
            day = "0" + day;
        f = f.replace("%dd", day);
        f = f.replace("%d", day.toString().ltrim("0"));

        var hour = this.getHours();
        if (hour < 10)
            hour = "0" + hour;
        f = f.replace("%hh", hour);
        f = f.replace("%h", hour.toString().ltrim("0"));

        var minute = this.getMinutes();
        if (minute < 10)
            minute = "0" + minute;
        f = f.replace("%mm", minute);
        f = f.replace("%m", minute.toString().ltrim("0"));

        var second = this.getSeconds();
        if (second < 10)
            second = "0" + second;
        f = f.replace("%ss", second);
        f = f.replace("%s", second.toString().ltrim("0"));
        return f;
    };

    /**
    * <summary group="method" name="Date.error">    
    * 判断时间对象是否不是有效时间
    * </summary>
    * <param name="date">
    * 对象
    * </param>
    * <returns type="Boolean">
    * 是否有效
    * </returns>
    */
    Date.error = function (date) {
        if (!date || isNaN(date)
				|| date.toString().toLowerCase() == "invalid date")
            return true;
    };

    /**
    * <summary group="method" name="Date.parse">    
    * 将字符串等其它类型转化成时间
    * </summary>
    * <param name="o">
    * 对象
    * </param>
    * <returns type="Date">
    * 转换后的时间
    * </returns>
    */
    Date.parse = function (o) {
        if (!o)
            return null;
        if (typeof (o) == "string")
            o = o.replace(/-/g, "/");
        var date = new Date(o);
        if (Date.error(date))
            return null;
        return date;
    };

    /**
    * <summary group="method" name="Math.convertTo">
    * 将对象转换为指定类型
    * </summary>
    * <param name="obj">
    * 待转换的对象
    * </param>
    * <param name="type">
    * 类型字符串
    * </param>
    * <param name="ext">
    * 扩展串
    * </param>
    * <returns>
    * 转换后的对象
    * </returns>
    */
    Math.convertTo = function (obj, type, ext) {
        if (!obj)
            return obj;
        switch (type) {
            case "i": // 整数
                return parseInt(obj);
            case "n": // 浮点型
                return parseFloat(obj);
            case "b": // 布尔型
                return Boolean.parse(obj);
            case "o": // 对象型
                if (typeof (obj) == "string") {
                    try {
                        return eval("(" + obj + ")");
                    } catch (e) {
                        throw new Error(jart_consts.error_convert_type_failed.format(obj, "Object"));
                    }
                }
                break;
            case "a": // 对象型
                if (typeof (obj) == "string") {
                    try {
                        var arr = eval("(" + obj + ")");
                        if (arr instanceof Array) return arr;
                        throw new Error(jart_consts.error_convert_type_failed.format(obj, "Array"));
                    } catch (e) {
                        throw new Error(jart_consts.error_convert_type_failed.format(obj, "Object"));
                    }
                }
                else {
                    if (obj.isArray) return obj;
                    throw new Error(jart_consts.error_convert_type_failed.format(obj, "Array"));
                }
                break;
            case "f": // 函数型
                if (ext) {
                    return Function.parse(obj, ext);
                }
                return Function.parse(obj);
            case "d": // 日期型
                return Date.parse(obj);
            case "e":   //枚举字符串
                if (ext && ext.length > 0) {
                    var val = parseInt(obj);
                    if (isNaN(val)) {
                        if (ext.contains(obj)) return obj;
                        else return null;
                    }
                    else {
                        return ext[val];
                    }
                }
            default:
                break;
        }
        return obj;
    };

    /**
    * <summary group="property" name="window.Debug" type="Object">
    * 调试对象
    * </summary>
    */
    window.Debug = {};

    /**
    * <summary group="property" name="Date._starts" type="Array">
    * 计时开始时间堆栈
    * </summary>
    */
    Debug._starts = new Array();

    /**
    * <summary group="method" name="Date.start">    
    * 开时计时
    * </summary>
    */
    Debug.start = function (title) {
        if (!jart_debug) return;
        if (!title) title = "cost";
        Debug._starts.push({ title: title, time: new Date() });
    };

    /**
    * <summary group="method" name="Date.end">    
    * 计时结束并返回计时对象{value:毫秒数,text:计时文本}
    * </summary>
    * <returns>
    * 
    * </returns>
    */
    Debug.end = function () {
        if (!jart_debug) return;
        if (Debug._starts.length < 1) return;
        var start = Debug._starts.pop();
        var now = new Date();
        var dv = now - start.time;
        var ms = dv % 1000;
        var s = Math.floor(dv / 1000);
        var m = Math.floor(s / 60);
        s = s % 60;
        var h = Math.floor(m / 60);
        m = m % 60;

        var result = {
            value: dv,
            text: "{0}:{1}:{2}.{3}".format(h, m, s, ms)
        };
        Debug.info(start.title + "：" + result.text);
        return result;
    };

    /**
    * <summary group="method" name="Math.info">
    * 打印一条消息
    * </summary>
    * <param name="info">
    * 消息内容
    * </param>
    */
    Debug.info = function (info) {
        if (!jart_debug) return;
        if (window.self != window.top && window.top.Debug) {
            window.top.Debug.info(info);
            return;
        }
        var id = "jart_info_shower";
        var node = jQuery("#" + id);
        if (node.length < 1) node = $("<div id='" + id + "' align='right' style='position:fixed;_position:absolute;right:5px;bottom:5px;width:300px;'><div style='width:5px;height:5px;background-color:red;cursor:pointer;overflow:hidden;' onclick='Debug.toggle();'></div><div align='left' style='background-color:gray;padding:5px;overflow-x:hidden;overflow-y:auto;height:100px;'></div></div>").alpha(0.5).appendTo(document.body);
        node = node.children("div:last");
        $("<div></div>").text("＝〉" + info).prependTo(node);
    };

    Debug.toggle = function (toggle) {
        var id = "jart_info_shower";
        var node = jQuery("#" + id);
        if (node.length > 0) {
            node = node.children("div:last");
            if (toggle === undefined) toggle = !node.is(":visible");
            if (toggle) {
                node.show();
            }
            else {
                node.hide();
            }
        }
    };

    window.jart_Delay = function (host, callback) {
        var delayer = {
            host: host, params: [],
            clock: null, active: function (param) {
                if (param && !this.params.contains(param)) this.params.push(param);
                var me = this;
                this.clock = setTimeout(function () {
                    me.callback.call(me.host, me.params);
                    clearTimeout(me.clock);
                    me.clock = null;
                    me.params.clear();
                }, 0);
            },
            cancel: function () {
                if (this.clock) {
                    clearTimeout(this.clock);
                    this.clock = null;
                }
            },
            callback: callback
        };
        return delayer;
    };
})();

/*
* jQuery扩展，提供更高级的dom操作，并给控件提供基础支撑
*/
(function ($) {
    /**
    * <summary group="property" name="jQuery.browser" type="Object">
    * 浏览器属性对象，包含以下属性和方法：
    * name：浏览器名称；
    * os：操作系统平台；
    * ie：是否是IE浏览器；
    * ie6：是否是IE6浏览器；
    * ie7：是否是IE7浏览器；
    * ie7s：是否是标准IE7浏览器；
    * ie7c：是否是兼容模式IE7浏览器；
    * ie8：是否是IE8浏览器；
    * ie9：是否是IE9浏览器；
    * firefox：是否是火狐（firefox）浏览器；
    * chrome：是否是谷歌（chrome）浏览器；
    * safari：是否是苹果（safari）浏览器；
    * width：浏览器网页视图区的可见宽度；
    * height：浏览器网页视图区的可见高度；
    * sbwx：竖向滚动条的宽度；
    * sbwy：横向滚动条的宽度；
    * resize(fn,data)：绑定一个窗口变化事件，fn是绑定的方法，data为绑定数据，将会作为fn方法的第一个参数传入fn。
    * </summary>
    */
    $.browser = {};
    (function (bs) {
        var version = window.navigator.userAgent;
        var re = new RegExp("MSIE ([0-9.a-z]+)", "ig");
        if (re.test(version)) {
            bs.name = "MSIE";
        }
        else {
            re = new RegExp("Firefox/([0-9.a-z]+)", "ig");
            if (re.test(version)) {
                bs.name = "Firefox";
            }
            else {
                re = new RegExp("Chrome/([0-9.a-z]+)", "ig");
                if (re.test(version)) {
                    bs.name = "Chrome";
                }
                else {
                    re = new RegExp("Safari/([0-9.a-z]+)", "ig");
                    if (re.test(version)) {
                        bs.name = "Safari";
                    }
                    else {
                        re = new RegExp("Camino/([0-9.a-z]+)", "ig");
                        if (re.test(version)) {
                            bs.name = "Camino";
                        }
                        else {
                            re = new RegExp("Gecko/([0-9.a-z]+)", "ig");
                            if (re.test(version)) {
                                bs.name = "Gecko";
                            }
                            else {
                                re = new RegExp("Opera/([0-9.a-z]+)", "ig");
                                if (re.test(version)) {
                                    bs.name = "Opera";
                                }
                                else bs.name = "Unkown";
                            }
                        }
                    }
                }
            }
        }
        bs.version = RegExp.$1;
        bs.os = window.navigator.platform;
        bs.ie = (bs.name == "MSIE");
        bs.ie6 = (bs.name == "MSIE" && parseInt(bs.version) == 6);
        bs.ie7 = (bs.name == "MSIE" && parseInt(bs.version) == 7);
        bs.ie7s = (bs.name == "MSIE" && parseInt(bs.version) == 7 && window.onmessage === undefined);
        bs.ie7c = (bs.name == "MSIE" && parseInt(bs.version) == 7 && window.onmessage !== undefined);
        bs.ie8 = (bs.name == "MSIE" && parseInt(bs.version) == 8);
        bs.ie9 = (bs.name == "MSIE" && parseInt(bs.version) == 9);
        bs.firefox = (bs.name == "Firefox");
        bs.chrome = (bs.name == "Chrome");
        bs.opera = (bs.name == "Opera");
        bs.safari = (bs.name == "Safari");
        bs.width = $(window).width();
        bs.height = $(window).height();
        //ie6下关掉特效
        //        if (bs.ie6) $.fx.off = true;
        bs.fnResize = new Array();
        bs.resize = function (fn, data) {
            fn.data = data;
            this.fnResize.push(fn);
        };
    })($.browser);

    //实时获取窗口大小并触发$.browser.resize事件
    $(window).bind("resize", function () {
        $.browser.resizable = true;
        if ($.browser.width == $(window).width() && $.browser.height == $(window).height()) {
            $.browser.resizable = false;
            return;
        }
        $.browser.width = document.documentElement.clientWidth;
        $.browser.height = document.documentElement.clientHeight;
        $.browser.fnResize.each(function () {
            this(this.data);
        });
    });

    //获取滚动条宽度
    $(function () {
        $.browser.sbwx = 0;
        $.browser.sbwy = 0;
        var dv = $("<div style='width:500px;height:500px;overflow:scroll;visibility:hidden;position:absolute;left:0px;top:0px;'><div style='width:500px;height:500px;'></div></div>").appendTo($(document.body));
        dv[0].scrollTop = 50;
        dv[0].scrollLeft = 50;
        $.browser.sbwx = dv[0].scrollLeft;
        $.browser.sbwy = dv[0].scrollTop;
        dv.remove();
    });

    /**
    * <summary group="method" name="方法名">    
    * 设置元素透明度，介于0与1之间
    * </summary>
    * <param name="degree">
    * 透明度，介于0与1之间
    * </param>
    * <returns>
    * 返回值
    * </returns>
    */
    $.fn.extend({ alpha: function (degree) {
        if (isNaN(degree) || degree > 1 || degree < 0) throw new Error(jart_consts.error_parameter_invalid.format("$.fn.alpha", "degree"));
        if (document.all) {
            var filter = this.get(0).style.filter;
            if (!filter) {
                this.css("filter", "alpha(opacity=" + degree * 100 + ")");
            }
            else {
                var re = new RegExp("alpha[(](.+)[)]", "ig");
                if (re.test(filter)) {
                    this.css("filter", filter.replace(re, "alpha(opacity=" + degree * 100 + ")"));
                }
                else this.css("filter", filter + " alpha(opacity=" + degree * 100 + ")");
            }
        }
        else this.css("opacity", degree);
        return this;
    }
    });

    /**
    * <summary group="method" name="方法名">    
    * 获取或设置包含标签本身在内的html
    * </summary>
    * <param name="html">
    * 待设置的html串
    * </param>
    * <returns>
    * 如果html参数为空则返回html串，否则返回jQuery对象
    * </returns>
    */
    $.fn.extend({ outerHtml: function (html) {
        if (html === undefined) html = true;
        if (typeof (html) == "boolean") {
            var obj = this[0];
            var parent = document.createElement("div");
            if (obj.tagName.lower() == "xml") {
                var tmp = document.createElement("span");
                var p = obj.parentNode;
                if ($.browser.ie) obj.replaceNode(tmp);
                else p.replaceChild(tmp, obj);
                parent.appendChild(obj);
                var result = parent.innerHTML;
                if ($.browser.ie) tmp.replaceNode(obj);
                else p.replaceChild(obj, tmp);
                return result;
            }
            else {
                var me = obj.cloneNode(html);
                parent.appendChild(me);
                return parent.innerHTML;
            }
        }
        else {
            return this.replaceWith(html);
        }
    }
    });

    //获取不重复的整型值
    var _uid = 1;
    $.extend({ uid: function () {
        return _uid++;
    }
    });

    //获取当前最大的zindex值，从10000开始，以100为间隔
    var _zindex = 10000;
    $.extend({ zindex: function () {
        return _zindex += 100;
    }
    });

    /**
    * <summary group="method" name="方法名">    
    * 使元素无法选中
    * </summary>
    */
    $.fn.extend({ unselectable: function () {
        this.attr("unselectable", "on");
        this.css("-moz-user-select", "none").css("-khtml-user-select", "none");
        return this;
    }
    });

    /**
    * <summary group="method" name="方法名">    
    * 使元素滚动到能在窗口中看到的位置
    * </summary>
    * <param name="arg">
    * 表示滚动位置，0或空值：中部，1：顶部，2：底部
    * </param>
    */
    $.fn.extend({ scrollIntoView: function (arg) {
        if (arg != 0 && arg != 1 && arg != 2) arg = 0;
        this.each(function () {
            if (arg == 1) this.scrollIntoView();
            else this.scrollIntoView(false);
            if (arg == 0) {
                var p = this.parentNode;
                while (p.scrollHeight <= p.clientHeight && p != document.body) p = p.parentNode;
                if (p.scrollTop <= 0) return this;
                var maxtop = p.scrollHeight - p.clientHeight;
                var h = p.clientHeight - this.offsetHeight;
                h /= 2;
                var top = p.scrollTop + h;
                if (top > maxtop) top = maxtop;
                p.scrollTop = top;
            }
        });
        return this;
    }
    });

    //使元素刷新，此方法用来解决布局控件在显隐左边框时出现的异常问题
    $.fn.extend({ refresh: function () {
        if (this.length == 0) return;
        var s = this[0];
        var p = s.parentNode;
        var t = document.createElement("span");
        p.replaceChild(t, s);
        p.replaceChild(s, t);
        return this;
    }
    });

    /**
    * <summary group="method" name="方法名">    
    * 使元素相对父元素居中
    * </summary>
    */
    $.fn.extend({ middle: function () {
        this.each(function () {
            var margin = (($(this).parent().height() - $(this).outerHeight()) / 2) + "px";
            $(this).css({ "margin-top": margin, "margin-bottom": margin });
        });
        return this;
    }
    });

    //扩展方法attribute获取元素原生attribute
    $.fn.extend({ attribute: function (name, value) {
        if (typeof (name) == "string") {
            //当name为字符串时，对单个属性赋值
            if (value === undefined) return this.get(0).attributes[name] ? this.get(0).attributes[name].nodeValue : null;
            if (value == null) {
                this[0][name] = null;
                if (this[0].attributes[name]) this[0].attributes.removeNamedItem(name);
            }
            else {
                if (this.get(0).attributes[name]) this.get(0).attributes[name].nodeValue = value;
                else {
                    var attr = document.createAttribute(name);
                    attr.value = value;
                    this.get(0).attributes.setNamedItem(attr);
                }
            }
        }
        else {
            //当name为对象时，对多个属性赋值
            for (var key in name) {
                this.attribute(key.toString(), name[key]);
            }
        }
        return this;
    }
    });

    //扩展removeStyle方法，功能：从style属性中删除一样式内容
    //name为样式名称
    $.fn.extend({ removeStyle: function (name) {
        if (!name) throw new Error(iGeli_Consts.ParameterIsNull.format("name"));
        if (this.length > 1) this.each(function () { $(this).removeStyle(name); });
        else if (this.length == 1) {
            this.css(name, "");
            if (this.attr("style")) {
                var styles = this.attr("style").split(";");
                for (var i = 0; i < styles.length; i++) {
                    var style = styles[i];
                    if ($.trim(style.split(":")[0]).toLowerCase() == name.toLowerCase()) {
                        styles.removeAt(i);
                        break;
                    }
                }
                var style = styles.join(";");
                if (!style) style = " ";
                this.attr("style", style);
            }
        }
        return this;
    }
    });

    //扩展addStyle方法，功能：从style属性中添加一样式内容，如果样式已存在则修改
    //name为样式名称，value为样式值
    $.fn.extend({ addStyle: function (name, value) {
        if (!name) throw new Error(jart_consts.error_parameter_null.format("{jQuery}.addStyle", "name"));
        if (!value) throw new Error(jart_consts.error_parameter_null.format("{jQuery}.addStyle", "value"));
        if (this.length > 1) this.each(function () { $(this).addStyle(name, value); });
        else if (this.length == 1) {
            var styles = new Array();
            if (this.attr("style")) styles = this.attr("style").split(";");
            for (var i = 0; i < styles.length; i++) {
                var style = styles[i];
                if ($.trim(style.split(":")[0]).toLowerCase() == name.toLowerCase()) {
                    styles.removeAt(i);
                    break;
                }
            }
            styles.push(name + ":" + value);
            this.attr("style", styles.join(";"));
        }
        return this;
    }
    });

    $.fn.extend({ toggleStyle: function (name, value, add) {
        if (add === undefined) {
            var removed = false;
            var styles = new Array();
            if (this.attr("style")) styles = this.attr("style").split(";");
            for (var i = 0, len = styles.length; i < len; i++) {
                var style = styles[i];
                if ($.trim(style.split(":")[0]).toLowerCase() == name.toLowerCase()) {
                    styles.removeAt(i);
                    removed = true;
                    break;
                }
            }
            if (!removed) styles.push(name + ":" + value);
            this.attr("style", styles.join(";"));
        }
        else {
            if (add) this.addStyle(name, value);
            else this.removeStyle(name);
        }
        return this;
    }
    });

    //扩展movein，moveout方法，功能：使元素从可视区域外还原或使元素移出可视区域外
    $.fn.extend({ moveIn: function () {
        this.each(function () {
            var jq = $(this);
            if (jq.attribute("_is_out")) {
                this.style.position = jq.attribute("_o_position");
                this.style.left = jq.attribute("_o_left");
                this.style.top = jq.attribute("_o_top");
                jq.attribute({ "_is_out": null, "_o_position": null, "_o_left": null, "_o_top": null })
            }
        });
        return this;
    }, moveOut: function () {
        this.each(function () {
            var jq = $(this);
            if (!jq.attribute("_is_out")) {
                jq.attribute({ "_is_out": true, "_o_position": this.style.position, "_o_left": this.style.left, "_o_top": this.style.top }).css({ "position": "absolute", "left": "-100000px", "top": "-100000px" });
            }
        });
        return this;
    }, isOut: function () {
        return this[0]._is_out;
    }
    });

    //扩展showx方法，功能：控制元素显示和隐藏，隐藏时能保存display以便恢复
    $.fn.extend({ showx: function (sh) {
        if (sh === undefined) return this.css("display") != "none";
        this.each(function () {
            if (sh) {
                if ($(this).css("display") == "none") {
                    this.style.display = $(this).attribute("_display") || "";
                    $(this).attribute("_display", null);
                }
            }
            else {
                if (this.style.display != "none") $(this).attribute("_display", this.style.display);
                this.style.display = "none";
            }
        });
        return this;
    }
    });
    //ie6下替换slidetoggle为showx
    if ($.browser.ie6) {
        $.fn.extend({ _slideToggle: $.fn.slideToggle, _slideDown: $.fn.slideDown, _slideUp: $.fn.slideUp });
        $.fn.extend({ slideToggle: function (arg1, arg2) {
            if (typeof (arg1) == "function") arg2 = arg1;
            this.each(function () {
                $(this).showx(!$(this).showx());
                if (arg2) arg2.call(this);
            });
        }, slideDown: function (arg1, arg2) {
            if (typeof (arg1) == "function") arg2 = arg1;
            this.each(function () {
                $(this).showx(true);
                if (arg2) arg2.call(this);
            });
        }, slideUp: function (arg1, arg2) {
            if (typeof (arg1) == "function") arg2 = arg1;
            this.each(function () {
                $(this).showx(false);
                if (arg2) arg2.call(this);
            });
        }
        });
    }

    /**
    * <summary group="method" name="方法名">    
    * 跳转到指定的页面
    * </summary>
    * <param name="url">
    * 页面地址
    * </param>
    * <param name="target">
    * 目标窗口
    * </param>
    * <returns>
    * 返回值
    * </returns>
    */
    $.extend({ redirect: function (url, target) {
        var fm = null;
        if (target) {
            var fm = $("iframe[name=" + target + "]");
        }
        if (fm && fm.length > 0) {
            if (fm.is("[art=iframe]")) fm.iframe({ url: url });
            else fm.attr("src", url);
        }
        else {
            if (target) window.open(url, target);
            else location.href = url;
        }
        return this;
    }
    });

    /**
    * <summary group="method" name="方法名">    
    * 判断当前元素是否包含另外一个元素
    * </summary>
    * <param name="child">
    * 子元素
    * </param>
    * <returns>
    * {Boolean}
    * </returns>
    */
    $.fn.extend({ contains: function (child) {
        if (!child) return false;
        if (child.get(0) == this.get(0)) return true;
        if ($.browser.ie) return this.get(0).contains(child.get(0));
        else {
            while (child && child.length > 0) {
                if (child.get(0) == this.get(0)) return true;
                child = child.parent();
            }
            return false;
        }
    }
    });

    /**
    * <summary group="method" name="方法名">    
    * 使当前元素定位到目标元素的下方
    * </summary>
    * <param name="target">
    * 目标元素
    * </param>
    * <param name="pos">
    * 自定义的位置对象（包含left,top两个属性）
    * </param>
    * <param name="adjust">
    * 是否根据网页大小自动调节使元元素可见
    * </param>
    */
    $.fn.extend({ relateTo: function (target, pos, adjust) {
        var offset = target.offset();
        offset.top += target.outerHeight();
        if (pos) {
            if (!isNaN(pos.left)) offset.left = pos.left;
            if (!isNaN(pos.top)) offset.top = pos.top;
        }
        this.css({ "position": "absolute", "left": offset.left + "px", "top": offset.top + "px" });
        if (adjust) {
            //TODO:待实现
        }
        return this;
    }
    });

    //扩展heights方法，功能：获取元素集合总高度
    $.fn.extend({ heights: function () {
        var height = 0;
        this.each(function () {
            height += $(this).outerHeight(true);
        });
        return height;
    }
    });

    /**
    * <summary group="method" name="方法名">    
    * 使元素带上阴影
    * </summary>
    * <param name="deep">
    * 阴影深度
    * </param>
    * <param name="alpha">
    * 阴影透明度
    * </param>
    */
    $.fn.extend({ shadow: function (deep, alpha) {
        if (this.children("div[_showdow_area=true]").length <= 0) {
            if (isNaN(deep)) deep = 4;
            if (isNaN(alpha)) alpha = 0.4;
            if (deep != 0) {
                if (this.css("position") == "static") this.css("position", "relative");
                var shadow = $("<div style='position:absolute;background:#000;top:" + deep + "px;left:" + deep + "px;right:-" + deep + "px;bottom:-" + deep + "px;z-index:-1;'></div>").alpha(alpha).attribute("_showdow_area", true);
                if ($.browser.ie6) shadow.width(this.outerWidth()).height(this.outerHeight());
                this.prepend(shadow);
            }
        }
        else {
            if (deep == 0) this.children("div[_showdow_area=true]").remove();
        }
        return this;
    }
    });

    //工具条提示扩展,提供工具条提示的支持
    $.extend({ templateOfTooltip: function () {
        return "<div style='background-color: #ffffe1;color: #000;border: solid 1px black;padding: 2px 2px;font-size: 12px;'>{0}</div>";
    }, showTooltip: function (offset, tip) {
        var tooltip = $("#_jart_tooltip_sdfasf23234");
        if (tooltip.length < 1) {
            tooltip = $("<div id='_jart_tooltip_sdfasf23234' style='position:absolute;max-width:300px;' ></div>").prependTo($(document.body)).append($.templateOfTooltip().format("<span id='_jart_tooltip_text_sdfasf23234'>" + tip + "</span>")).shadow();
        }
        else {
            tooltip.find("span#_jart_tooltip_text_sdfasf23234").html(tip);
        }
        var maxw = Math.min(document.documentElement.clientWidth - offset.left - 20, 300);
        if (maxw < 200) {
            offset.left = offset.left - 200 + maxw;
            maxw = 200;
        }
        tooltip.css("z-index", $.zindex()).css("max-width", maxw + "px").show().offset(offset);
        return tooltip;
    }, hideTooltip: function () {
        var tooltip = $("#_jart_tooltip_sdfasf23234");
        tooltip.hide();
    }
    });
    $("[tooltip]").live("mouseenter", function (event) {
        var jq = $(this);
        var offset = new Object();
        offset.left = event.clientX + 12;
        offset.top = event.clientY + 12;
        var tooltip = jq.attr("tooltip");
        if (tooltip == "{text}") tooltip = jq.text();
        if (tooltip) {
            $.showTooltip(offset, tooltip);
        }
    }).live("mouseleave", function () {
        $.hideTooltip();
    });

    //鼠标事件样式扩展
    var timeFlag = {};
    $("[hover]").live("mouseenter", function () {
        var obj = $(this);
        var selector = obj.attr("hoverSelector");
        if (selector) obj = $(selector);
        obj.addClass(obj.attr("hover"));
    }).live("mouseleave", function (e) {
        var obj = $(this);
        var selector = obj.attr("hoverSelector");
        if (selector) {
            obj = $(selector);
            var x = e.clientX;
            var y = e.clientY;
            var flag = false;
            obj.not(this).each(function () {
                var offset = $(this).offset();
                if (offset.left < x && x < offset.left + $(this).outerWidth() && offset.top < y && y < offset.top + $(this).outerHeight()) flag = true;
            });
            if (flag) return;
        }
        obj.removeClass(obj.attr("hover"));
    });

    $("[down]").live("mousedown", function (e) {
        var obj = $(this);
        obj.addClass(obj.attr("down"));
    }).live("mouseup mouseleave", function () {
        var obj = $(this);
        obj.removeClass(obj.attr("down"));
    });

    //block扩展，异步遮罩层
    (function () {
        var _alpha = 0.3;
        var _ids = new Array();
        function getBlockIframe(id, uncreate) {
            if (id === undefined) return $("iframe[blockuse=true]");
            var fm = $("#jjchen_iframeforblock_" + id);
            if (uncreate) return fm;
            //网页里有可见的select元素时才会插入iframe
            if (fm.length < 1 && $("select:visible").length > 0) {
                fm = $("<iframe id='jjchen_iframeforblock_" + id + "' blockuse='true' frameborder='0' style='background-color:#000;position:absolute;z-index:100;top:0px;right:0px;'></iframe>").alpha(0);
                if ($.browser.firefox || $.browser.chrome) fm.appendTo($(document.documentElement));
                else fm.appendTo($(document.body));
                //解决空白页加载问题
                fm[0].contentWindow.document.write("aaa");
            }
            return fm;
        }

        function getBlockDiv(id, uncreate) {
            if (id === undefined) return $("div[blockuse=true]");
            var blk = $("#jjchen_blockdiv_" + id);
            if (uncreate) return blk;
            if (blk.length < 1) {
                blk = $("<div id='jjchen_blockdiv_" + id + "' blockuse='true' align='center' style='background-color:#000;position:absolute;z-index:100;top:0px;left:0px;display:none;'></div>").alpha(_alpha);
                if ($.browser.firefox || $.browser.chrome) blk.appendTo($(document.documentElement));
                else blk.appendTo($(document.body));
            }
            return blk;
        }

        function getMsgDiv(id, uncreate) {
            if (id === undefined) return $("table[blockuse=true]");
            var msg = $("#jjchen_msgdiv_" + id);
            if (uncreate) return msg;
            if (msg.length < 1) {
                msg = $("<table id='jjchen_msgdiv_" + id + "' blockuse='true' cellspacing='0' cellpadding='0' style='position:absolute;z-index:100;display:none;left:0px;top:0px;background:transparent'><tr><td align='center' valign='middle'><span style='display:inline-block'>正在加载，请稍候......</span></td></tr></table>");
                if ($.browser.firefox || $.browser.chrome) msg.appendTo($(document.documentElement));
                else msg.appendTo($(document.body));
            }
            return msg;
        }

        //        $.browser.resize(function () {
        //            _ids.each(function () {
        //                var fm = getBlockIframe(this, true);
        //                var blk = getBlockDiv(this, true);
        //                var msg = getMsgDiv(this, true);
        //                if (blk.is("div:visible")) {
        //                    var width = $.browser.width;
        //                    var height = $.browser.height;
        //                    var _target = blk.get(0)._target;
        //                    if (_target) {
        //                        width = _target.outerWidth();
        //                        height = _target.outerHeight();
        //                        fm.width(width).height(height);
        //                        blk.width(width).height(height);
        //                    }
        //                    else {
        //                        fm.width(width).height(height);
        //                        blk.width(width).height(height);
        //                    }
        //                    msg.find("td").width(width - 10).height(height);
        //                }
        //            });
        //        });

        $.extend({ block: function (id, opts) {
            if (!id) id = $.uid();
            if (typeof (id) == "object") {
                opts = id;
                id = $.uid();
            }
            var zindex = $.zindex();
            var fm = getBlockIframe(id).css("z-index", zindex);
            var blk = getBlockDiv(id).css("z-index", zindex);
            var msg = getMsgDiv(id).css("z-index", zindex);
            if (opts) {
                if (opts.message != undefined) msg.find("td").children("span").empty().append(opts.message);
                if (opts.css != undefined) blk.css(opts.css);
                if (opts.alpha != undefined) blk.alpha(opts.alpha);
                if (opts.zindex != undefined) {
                    fm.css("z-index", opts.zindex);
                    blk.css("z-index", opts.zindex);
                    msg.css("z-index", opts.zindex);
                }
            }
            $(document.documentElement).css("overflow", "hidden");
            var width = $.browser.width;
            var height = $.browser.height;
            fm.show().width(width).height(height).css({ top: "0px", left: "0px" });
            blk.show().width(width).height(height).css({ top: "0px", left: "0px" });
            msg.show().css({ top: "0px", left: "0px" }).find("td").width(width - 10).height(height);
            _ids.push(id);
        }, blockj: function (id, msg) {
            if (!msg) msg = jart_consts.info_loading_text;
            this.block(id, { message: "<span style='display:inline-block' class='x-loading'><span style='display:inline-block' class='x-loading-in'>" + msg + "</span></span>" });
        }
        , unblock: function (id) {
            var fm = getBlockIframe(id, true);
            var blk = getBlockDiv(id, true);
            var msg = getMsgDiv(id, true);
            msg.remove();
            blk.remove();
            fm.remove();
            $(document.documentElement).css("overflow", "auto");
            _ids.remove(id);
        }
        });

        $.fn.extend({ block: function (id, opts) {
            if (!id) id = "autoblockid_" + $.uid();
            if (typeof (id) == "object") {
                opts = id;
                id = $.uid();
            }
            var zindex = $.zindex();
            var fm = getBlockIframe(id).css("z-index", zindex);
            var blk = getBlockDiv(id).css("z-index", zindex);
            blk[0]._target = this;
            var msg = getMsgDiv(id).css("z-index", zindex);
            if (opts) {
                if (opts.message != undefined) msg.find("td").children("span").empty().append(opts.message);
                if (opts.css != undefined) blk.css(opts.css);
                if (opts.alpha != undefined) blk.alpha(opts.alpha);
                if (opts.zindex != undefined) {
                    fm.css("z-index", opts.zindex);
                    blk.css("z-index", opts.zindex);
                    msg.css("z-index", opts.zindex);
                }
            }
            var width = this.outerWidth();
            var height = this.outerHeight();
            var offset = this.offset();
            fm.show().width(width).height(height).css({ top: offset.top + "px", left: offset.left + "px" });
            blk.show().width(width).height(height).css({ top: offset.top + "px", left: offset.left + "px" });
            msg.show().css({ top: offset.top + "px", left: offset.left + "px" }).find("td").width(width - 10).height(height);
            _ids.push(id);
            return this;
        }, blockj: function (id, msg, opts) {
            if (!msg) msg = jart_consts.info_loading_text;
            if (!opts) opts = {};
            opts.message = "<span style='display:inline-block' class='x-loading'><span style='display:inline-block' class='x-loading-in'>" + msg + "</span></span>";
            this.block(id, opts);
        }
        });

        //循环判断遮罩位置
        setInterval(function () {
            for (var i = 0; i < _ids.length; i++) {
                var id = _ids[i];
                var fm = getBlockIframe(id, true);
                var blk = getBlockDiv(id, true);
                var msg = getMsgDiv(id, true);
                var target, width, height, offset;
                if (blk.length > 0 && blk[0]._target) {
                    target = blk[0]._target;
                    width = target.outerWidth();
                    height = target.outerHeight();
                    offset = target.offset();
                    if (target.parent().length < 1) {
                        $.unblock(id);
                        return;
                    }
                }
                else {
                    width = $.browser.width;
                    height = $.browser.height;
                    offset = { left: 0, top: 0 };
                }
                fm.width(width).height(height).css({ top: offset.top + "px", left: offset.left + "px" });
                blk.width(width).height(height).css({ top: offset.top + "px", left: offset.left + "px" });
                msg.css({ top: offset.top + "px", left: offset.left + "px" }).find("td").width(width - 10).height(height);
            }
        }, 200);
    })();

    //鼠标拖动扩展
    /**
    * <summary group="method" name="方法名">    
    * 激活鼠标拖动（pull）动作，通常此方法在mousedown中被调用，然后随着鼠标移动而元素也随之触发pull事件，直到松开鼠标时结束。
    * </summary>
    * <param name="e">
    * 事件参数
    * </param>
    * <param name="move">
    * 元素支持的拖动动模式，1为自身不移动，2为自身移动--此项为扩展属性
    * </param>
    * <param name="cursor">
    * 自定义的鼠标样式，如果没有，则沿用当前元素的样式
    * </param>
    */
    $.fn.extend({ dopull: function (e, move, cursor) {
        //延迟执行
        //设置当前元素为拖动元素
        document.pull_source = this[0];
        //初始化拖动数据
        document.pull_x = e.pageX;
        document.pull_y = e.pageY;
        document.pull_move = move;
        if (cursor) $(document.body).css("cursor", cursor);
        else $(document.body).css("cursor", this.css("cursor"));
        $.block("pull_block_gdasdfasdf", { message: "", alpha: 0 });
        return this;
    }, pull: function (fn, data) {
        if (typeof (fn) == "function") {
            for (var i = 0; i < this.length; i++) {
                if (!this[i].pullfuns) this[i].pullfuns = new Array();
                fn.pull_data = data;
                this[i].pullfuns.push(fn);
            }
        }
        else {
            if (this[0].pullfuns) {
                for (var i = 0; i < this[0].pullfuns.length; i++) {
                    fn.data = this[0].pullfuns[i].pull_data;
                    this[0].pullfuns[i].call(this[0], fn);
                }
            }
        }
        return this;
    }, pullend: function (fn, data) {
        if (typeof (fn) == "function") {
            for (var i = 0; i < this.length; i++) {
                if (!this[i].pullendfuns) this[i].pullendfuns = new Array();
                fn.pullend_data = data;
                this[i].pullendfuns.push(fn);
            }
        }
        else {
            if (this[0].pullendfuns) {
                for (var i = 0; i < this[0].pullendfuns.length; i++) {
                    fn.data = this[0].pullendfuns[i].pullend_data;
                    this[0].pullendfuns[i].call(this[0], fn);
                }
            }
        }
        return this;
    }
    });
    $(document).bind("mousedown", function (e) {
        var node = $(e.target);
        if (!$(document.body).contains(node)) return;
        while (node[0] != document.body) {
            var pullmode = node.attr("pullmode");
            if (pullmode) {
                pullmode = parseInt(pullmode);
                if (pullmode == 1 || pullmode == 2) node.dopull(e, pullmode);
                break;
            }
            node = node.parent();
        }
    }).bind("mouseup", function (e) {
        //设置拖动元素为空
        if (document.pull_source) $(document.pull_source).pullend(e);
        document.pull_source = null;
        $.unblock("pull_block_gdasdfasdf");
        $(document.body).css("cursor", "");
    }).bind("mousemove", function (e) {
        if (!document.pull_source) {
            $.unblock("pull_block_gdasdfasdf");
            $(document.body).css("cursor", "");
            return;
        }
        //鼠标左键未按下则返回
        if (e.button != ($.browser.ie ? ($.browser.ie9 ? 0 : 1) : 0)) {
            if (document.pull_source) $(document.pull_source).pullend(e);
            document.pull_source = null;
            $.unblock("pull_block_gdasdfasdf");
            $(document.body).css("cursor", "");
            return;
        }
        e.target = document.pull_source;
        //dx是离上一次mousemove事件的鼠标x轴移动距离，dy是离上一次mousemove事件的鼠标y轴移动距离
        e.dx = e.clientX - document.pull_x;
        e.dy = e.clientY - document.pull_y;
        document.pull_x = e.clientX;
        document.pull_y = e.clientY;
        var node = $(e.target);
        if (document.pull_move == 2) {
            var left = node.attr("offsetLeft") || parseFloat(node.css("left")) || node.offset().left || 0;
            var top = node.attr("offsetTop") || parseFloat(node.css("top")) || node.offset().top || 0;
            node.css("left", (left + e.dx) + "px");
            node.css("top", (top + e.dy) + "px");
        }
        node.pull(e);
    });

    /**
    * <summary group="method" name="方法名">    
    * 扩展的绑定事件操作，如果当前元素的任何子元素或本身满足context选择器，则会被绑定事件，此功能只支持能向上冒泡的事件
    * </summary>
    * <param name="context">
    * jQuery选择器字符串
    * </param>
    * <param name="type">
    * 绑定的事件类型
    * </param>
    * <param name="data">
    * 绑定的事件数据
    * </param>
    * <param name="fn">
    * 绑定到事件上的方法，此方法将会传一个参数e,e包含属性data（事件数据）和targets（触发事件的元素集）
    * </param>
    * <returns>
    * 返回值
    * </returns>
    */
    $.fn.extend({ binds: function (context, type, data, fn) {
        var myfn = function (e) {
            var context = arguments.callee.context;
            var fn = arguments.callee.fn;
            var target = $(e.target);
            e.targets = $();
            while (target[0] != this) {
                if (target.is(context)) e.targets = e.targets.add(target);
                target = target.parent();
            }
            if (e.targets.length > 0) fn.call(this, e);
        };
        myfn.fn = fn;
        myfn.context = context;
        this.bind(type, data, myfn);
    }
    });

    //引入免激活flash操作
    function AC_Generateobj(doc, objAttrs, params, embedAttrs) {
        if (!doc) doc = document;
        var str = '<object ';
        for (var i in objAttrs)
            str += i + '="' + objAttrs[i] + '" ';
        str += '>';
        for (var i in params)
            str += '<param name="' + i + '" value="' + params[i] + '" /> ';
        str += '<param name="menu" value="false"> <embed ';
        for (var i in embedAttrs)
            str += i + '="' + embedAttrs[i] + '" ';
        str += ' menu="false"></embed></object>';

        doc.write(str);
    }

    function AC_FL_RunContent() {
        var ret =
     AC_GetArgs
     (arguments, "movie", "clsid:d27cdb6e-ae6d-11cf-96b8-444553540000"
     , "application/x-shockwave-flash"
     );
        return ret;
    }

    function AC_GetArgs(args, srcParamName, classid, mimeType) {
        var ret = new Object();
        ret.embedAttrs = new Object();
        ret.params = new Object();
        ret.objAttrs = new Object();
        for (var i = 0; i < args.length; i = i + 2) {
            var currArg = args[i].toLowerCase();

            switch (currArg) {
                case "classid":
                    break;
                case "pluginspage":
                case "name":
                    ret.embedAttrs[args[i]] = args[i + 1];
                    break;
                case "src":
                case "movie":
                    ret.embedAttrs["src"] = args[i + 1];
                    ret.params[srcParamName] = args[i + 1];
                    break;
                case "style":
                case "onafterupdate":
                case "onbeforeupdate":
                case "onblur":
                case "oncellchange":
                case "onclick":
                case "ondblClick":
                case "ondrag":
                case "ondragend":
                case "ondragenter":
                case "ondragleave":
                case "ondragover":
                case "ondrop":
                case "onfinish":
                case "onfocus":
                case "onhelp":
                case "onmousedown":
                case "onmouseup":
                case "onmouseover":
                case "onmousemove":
                case "onmouseout":
                case "onkeypress":
                case "onkeydown":
                case "onkeyup":
                case "onload":
                case "onlosecapture":
                case "onpropertychange":
                case "onreadystatechange":
                case "onrowsdelete":
                case "onrowenter":
                case "onrowexit":
                case "onrowsinserted":
                case "onstart":
                case "onscroll":
                case "onbeforeeditfocus":
                case "onactivate":
                case "onbeforedeactivate":
                case "ondeactivate":
                case "type":
                case "codebase":
                case "id":
                    ret.objAttrs[args[i]] = args[i + 1];
                    break;
                case "width":
                case "height":
                case "align":
                case "vspace":
                case "hspace":
                case "class":
                case "title":
                case "accesskey":
                case "tabindex":
                    ret.embedAttrs[args[i]] = ret.objAttrs[args[i]] = args[i + 1];
                    break;
                default:
                    ret.embedAttrs[args[i]] = ret.params[args[i]] = args[i + 1];
            }
        }
        ret.objAttrs["classid"] = classid;
        if (mimeType) ret.embedAttrs["type"] = mimeType;
        return ret;
    }

    /**
    * <summary group="method" name="方法名">    
    * 加载一个flash文档
    * </summary>
    * <param name="id">
    * 元素标识
    * </param>
    * <param name="src">
    * flash文档地址
    * </param>
    * <param name="flashvars">
    * flash参数
    * </param>
    * <param name="width">
    * 元素宽度
    * </param>
    * <param name="height">
    * 元素高度
    * </param>
    * <param name="doc">
    * 加载的目标文档
    * </param>
    */
    $.extend({ flash: function (id, src, flashvars, width, height, doc) {
        var ret = AC_FL_RunContent(
        'codebase', 'http://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=8,0,0,0'
        , 'width', width         //FLASH文件的宽
        , 'height', height           //FLASH文件的高
        , 'src', src       //FLASH文件的位置
        , 'quality', 'high'       //FLASH文件的默认质量
        , 'pluginspage'
        , 'http://www.macromedia.com/go/getflashplayer'
        , 'movie', src   //FLASH文件的位置，和上面的要一样
        , 'allowscriptaccess', 'sameDomain'     //可与页面进行js交互
        , 'wmode', 'transparent'
        , 'scale', 'Exactfit'
        , 'flashvars', flashvars
        , 'id', id
        , 'name', id
        );
        AC_Generateobj(doc, ret.objAttrs, ret.params, ret.embedAttrs);
    }
    });

    /**
    * <summary group="method" name="方法名">    
    * 使元素宽度自动填充，只有标记了fillx属性才有此功能，fillx属性为一个json串，包含如下属性：
    * percent：自适应的百分比；
    * padding：自适应的外补白；
    * target：自适应的参照元素，如果未设定则默认为最近的一个拥有allowfillx属性的元素或body元素，allowfillx为一个整形值，标识自适应的内补白，可为空（等价于0）
    * hidden：是否隐藏横向滚动条
    * </summary>
    */
    $.fn.extend({ fillx: function () {
        if (this.length < 1) return this;
        else if (this.length > 1) this.each(function () { $(this).fillx(); });
        else if (this.is("[fillx]")) {
            var fillable = Function.parse(this.attr("fillable"), "x");
            if (fillable && !fillable.call(this, true)) return this;
            var target = this.parents("[allowfillx]:first");
            if (target.length < 1) target = $(document.body);
            var percent = 1, padding = 0, hidden = false;

            //从属性中取fillx参数
            var fillx = null;
            try { fillx = eval("(" + this.attr("fillx") + ")"); } catch (e) { }
            if (fillx) {
                if (fillx.target !== undefined) target = $(fillx.target);
                if (fillx.percent !== undefined) percent = parseFloat(fillx.percent);
                if (fillx.padding !== undefined) padding = parseFloat(fillx.padding);
                if (fillx.hidden !== undefined) hidden = Boolean.parse(fillx.hidden);
            }

            //chrome浏览器下对block状态的div判断margin-right错误处理
            var chromeFlag = false;
            if ($.browser.chrome && this.is("div") && this.css("display") == "block") {
                this.css("display", "inline-block");
                chromeFlag = true;
            }

            //自适应容器允许自定义差距
            if (target.attr("allowfillx")) padding += isNaN(parseInt(target.attr("allowfillx"))) ? 0 : parseInt(target.attr("allowfillx"));
            var width = 0;
            var owidth = this.width();
            if (target.get(0) == document || target.get(0) == document.body || target.get(0) == document.documentElement || target.get(0) == window) {
                //解决ie6/7/firefox下会有竖向滚动条问题
                if ($.browser.ie6 || $.browser.ie7 || $.browser.firefox) $(document.documentElement).css("overflow", "hidden");
                if (target.get(0) == document.body) width = ($(window).width() + ($(document.body).width() - $(document.body).outerWidth(true)) - padding) * percent;
                else width = ($(window).width() - padding) * percent;
                width += this.width() - this.outerWidth(true);
            }
            else {
                width = (target.width() - padding) * percent + this.width() - this.outerWidth(true);
            }

            //还原chrome处理
            if (chromeFlag) this.css("display", "");
            if (hidden) target.css("overflow-x", "hidden");

            if (width != owidth) this.width(width);
        }
        return this;
    }
    });

    /**
    * <summary group="method" name="方法名">    
    * 使元素包含的可宽度自适应的所有元素进行宽度自适应
    * </summary>
    */
    $.fn.extend({ fillxs: function () {
        this.find("[fillx]:visible").fillx();
    }
    });

    /**
    * <summary group="method" name="方法名">    
    * 使元素宽度自动填充，只有标记了filly属性才有此功能，filly属性为一个json串，包含如下属性：
    * percent：自适应的百分比；
    * padding：自适应的外补白；
    * target：自适应的参照元素，如果未设定则默认为最近的一个拥有allowfilly属性的元素或body元素，allowfilly为一个整形值，标识自适应的内补白，可为空（等价于0）
    * hidden：是否隐藏竖向滚动条
    * </summary>
    */
    $.fn.extend({ filly: function () {
        if (this.length < 1) return this;
        else if (this.length > 1) this.each(function () { $(this).filly() });
        else if (this.is("[filly]")) {
            //判断fillable函数
            var fillable = Function.parse(this.attr("fillable"), "x");
            if (fillable && !fillable.call(this, false)) return this;

            var target = this.parents("[allowfilly]:first");
            if (target.length < 1) target = $(document.body);
            var percent = 1, padding = 0, hidden = true;

            //从属性中取filly参数
            var filly = null;
            try { filly = eval("(" + this.attr("filly") + ")"); } catch (e) { }
            if (filly) {
                if (filly.target) target = $(filly.target);
                if (filly.percent !== undefined) percent = filly.percent;
                if (filly.padding !== undefined) padding = filly.padding;
                if (filly.hidden !== undefined) hidden = filly.hidden;
            }

            //自适应容器允许自定义差距
            if (target.attr("allowfilly")) padding += isNaN(parseInt(target.attr("allowfilly"))) ? 0 : parseInt(target.attr("allowfilly"));
            var height = 0;
            var oheight = this.height();
            if (target.get(0) == document || target.get(0) == document.body || target.get(0) == document.documentElement || target.get(0) == window) {
                if (target.get(0) == document.body) height = ($(window).height() + ($(document.body).height() - $(document.body).outerHeight(true)) - padding) * percent;
                else height = ($(window).height() - padding) * percent;
                height += this.height() - this.outerHeight(true);

                if (height != oheight) this.height(height);
            }
            else {
                var onfilly = Function.parse(this.attr("onfilly"), "filled");
                if ($.browser.ie) {
                    if (!target[0].currentStyle.height || target[0].currentStyle.height == "auto") {
                        if (onfilly) onfilly.call(this, false);
                        return this;
                    }
                }
                else {
                    if (!target[0].style.height || target[0].style.height == "auto") {
                        if (onfilly) onfilly.call(this, false);
                        return this;
                    }
                }
                //ie下div被撑开问题处理
                var oy = target[0].style.overflowY;
                if ($.browser.ie6) target.css("overflow-y", "hidden");

                height = (target.height() - padding) * percent + this.height() - this.outerHeight(true);

                //还原ie下div撑开问题处理
                if ($.browser.ie6) target[0].style.overflowY = oy;
                if (hidden) target.css("overflow-y", "hidden");

                if (height != oheight) {
                    this.height(height);
                    if (onfilly) onfilly.call(this, true);
                }
                //                else if (onfilly) onfilly.call(this, false);
            }
        }
        return this;
    }
    });

    /**
    * <summary group="method" name="方法名">    
    * 使元素包含的可高度自适应的所有元素进行高度自适应
    * </summary>
    */
    $.fn.extend({ fillys: function () {
        this.find("[filly]:visible").filly();
    }
    });

    /**
    * <summary group="method" name="方法名">    
    * 使元素支持图标设置，将会给元素添加上icon(icon)和iconurl(url)两个方法，用来获取或设置元素的图标
    * </summary>
    * <param name="clsAdd">
    * 设置图标后需要添加的样式
    * </param>
    * <param name="clsRemove">
    * 设置图标后需要移除的样式
    * </param>
    */
    $.fn.extend({ iconed: function (clsAdd, clsRemove) {
        if (this.is("span")) this.css({ "display": "inline-block" });
        this.css({ "background-repeat": "no-repeat" });
        this.each(function () {
            this._iconcls = clsAdd;
            this._iconclsRemove = clsRemove;
            this.icon = function (icon) {
                if (icon === undefined) return this._icon;
                if (icon) {
                    $(this).removeClass("x-icon-" + this._icon);
                    $(this).addClass("x-icon-" + icon);
                    if (this._iconcls) $(this).addClass(this._iconcls);
                    else if (this._iconclsRemove) $(this).removeClass(this._iconclsRemove);
                    else this.style.display = "inline-block";
                }
                else {
                    $(this).removeClass("x-icon-" + this._icon);
                    if (!this._iconurl) {
                        if (this._iconcls) $(this).removeClass(this._iconcls);
                        else if (this._iconclsRemove) $(this).addClass(this._iconclsRemove);
                        else this.style.display = "none";
                    }
                }
                this._icon = icon;
            };
            this.iconurl = function (url) {
                if (url === undefined) return this._iconurl;
                if (url) {
                    $(this).addStyle("background-image", "url(" + url + ")");
                    if (this._iconcls) $(this).addClass(this._iconcls);
                    else if (this._iconclsRemove) $(this).removeClass(this._iconclsRemove);
                    else this.style.display = "inline-block";
                }
                else {
                    $(this).removeStyle("background-image");
                    if (!this._icon) {
                        if (this._iconcls) $(this).removeClass(this._iconcls);
                        else if (this._iconclsRemove) $(this).addClass(this._iconclsRemove);
                        else this.style.display = "none";
                    }
                }
                this._iconurl = url;
            };
        });
        return this;
    }
    });

    //扩展非ie下的onresize方法
    /**
    * <summary group="method" name="{jQuery}.unresizable">
    * 获取或设置元素是否允许改变大小事件
    * </summary>
    * <param name="able">
    * 元素是否允许改变大小事件
    * </param>
    * <returns type="Boolean">
    * 元素是否允许改变大小事件
    * </returns>
    */
    $.fn.extend({ unresizable: function (able) {
        if (able === undefined) return Boolean.parse(this.attr("unresizable"));
        this.attr("unresizable", able);
        if (able) {
            this.each(function () {
                this._width_asd234 = undefined;
                this._height_234fwf = undefined;
            });
        } else {
            this.each(function () {
                this._width_asd234 = this.clientWidth || this.offsetWidth;
                this._height_234fwf = this.clientHeight || this.offsetHeight;
            });
        }
        return this;
    }
    });

    //启动操作
    /*#region*/
    $(function () {
        if (!$.browser.ie) {
            window.setInterval(function () {
                $("[resizable=true]").each(function () {
                    var width = this.clientWidth || this.offsetWidth;
                    var height = this.clientHeight || this.offsetHeight;
                    var owidth = this._width_asd234;
                    var oheight = this._height_234fwf;
                    this._width_asd234 = width;
                    this._height_234fwf = height;
                    //                    if (owidth === undefined && oheight === undefined) return;
                    if (owidth != width || oheight != height) {
                        var onresize = this.onresize || $(this).attribute("onresize");
                        var fn = Function.parse(onresize);
                        fn.call(this);
                    }
                });
            }, 200);
        }
    });
})(jQuery);

/*
*jart命名空间定义及jart控件基类定义
*/
(function ($, undefined) {
    /*
    * <summary group="property" name="window.jart_controls" type="Object">
    * 存储控件的盒子
    * </summary>
    */
    window.jart_controls = new Object();

    //存储控件的标签
    var jart_labels = new Object();

    /**
    * <summary group="method" name="jart">
    * 定义jart(简写art)域及方法，只传入控件id，返回jart控件对象，传入控件id、控件类型type则创建或修改控件并返回控件
    * </summary>
    * <param name="id">
    * 控件标识或网页元素
    * </param>
    * <param name="attrs">
    * 控件属性集合
    * </param>
    * <param name="type">
    * 控件类型
    * </param>
    * <returns type="">
    * jart控件对象
    * </returns>
    */
    window.jart = function (id, attrs, type) {
        if (attrs && typeof (attrs) == "string") attrs = eval("(" + attrs + ")");
        if (typeof (id) == "string") {
            //从盒子中取出指定id的控件
            if (!id) return null;
            var ctl = jart_controls[id];
            if (ctl && attrs) ctl.mRenderAttrs(attrs);
            return ctl;
        }
        else {
            var node = $(id);
            if (node.length < 1) return null;
            if (node.length > 1) node = $(node[0]);
            id = node.attr("id");
            var ctl = jart_controls[node.attr("id")];
            if (ctl) {
                ctl.mRenderAttrs(attrs);
                return ctl;
            }
            if (!type) type = node.attribute("art") || "any";
            if (!jart[type]) throw new Error(jart_consts.error_control_type_not_realized.format(type));
            return new jart[type](node, attrs);
        }
    };

    //请不要删除此作者信息，谢谢
    /**
    * <summary group="property" name="jart.plugin" type="Object">
    * jart控件内置插件扩展
    * </summary>
    */
    jart.plugin = {
        copyright: {
            author: '陈家军',
            company: "科大讯飞",
            email: "fengxia520@gmail.com"
        }
    };

    /**
    * <summary group="method" name="jQuery.plugin">
    * 让jart控件支持通过$.fn.type(...)方法来获取或设置属性，并返回jart控件对象
    * </summary>
    * <param name="type">
    * 控件类型
    * </param>
    * <param name="label">
    * 控件标签（jquery选择器）
    * </param>
    * <returns type="">
    * jart控件对象
    * </returns>
    */
    $.extend({ plugin: function (type, label) {
        var obj = {};
        obj[type] = function (name, value) {
            if (typeof (name) == "string") {
                if (value === undefined) {
                    var ctl = jart(this, {}, arguments.callee.art);
                    return ctl.attr(name);
                }
                else {
                    var attrs = {};
                    attrs[name] = value;
                    return jart(this, attrs, arguments.callee.art);
                }
            }
            else {
                var attrs = name;
                return jart(this, attrs, arguments.callee.art);
            }
        };
        obj[type].art = type;
        $.fn.extend(obj);
        if (!label) label = "span";
        jart_labels[type] = label;
        jart[type].prototype.type = type;
    }
    });

    /**
    * <summary group="method" name="{jQuery}.jart">
    * 获取元素所属的控件
    * </summary>
    * <returns type="">
    * jart控件对象
    * </returns>
    */
    $.fn.extend({ jart: function () {
        var obj = this;
        if (!obj.is("[art_wrap]")) obj = this.parents("[art_wrap]:first");
        if (obj.length == 0) return null;
        return jart(obj.attr("art_wrap"));
    }
    });

    /**
    * <summary group="method" name="{jQuery}.myattrs">
    * 获取元素的自定义属性集合
    * </summary>
    * <param name="remove">
    * 是否移除属性标签
    * </param>
    */
    $.fn.extend({ myattrs: function (remove) {
        var re = new RegExp("\\s[a-z_0-9]+=([^\\s\">]+|\"[^\"]*\")>", "gi");
        var htm = this.outerHtml(false);
        var matches = htm.match(re);
        if (!matches || matches.length < 1) return {};
        var str = htm.match(re)[0];
        htm = htm.substr(0, htm.indexOf(str) + str.length);
        re = new RegExp("\\s[a-z_0-9]+=([^\\s\">]+|\"[^\"]*\")", "gi");
        var arr = htm.match(re);
        var tag = this[0].tagName;
        attrs = new Object();
        var filter = ",id,name,art,art_render,init,iframe.src,", i;
        for (i = 0; i < arr.length; i++) {
            var name = arr[i].split("=")[0].trim();
            if (filter.indexOf("," + name + ",") >= 0) continue;
            if (filter.indexOf("," + tag + "." + name + ",") >= 0) continue;
            if (this[0].tagName.lower() == "xml") attrs[name] = this[0].getAttribute(name);
            else attrs[name] = this.attribute(name);
        }
        var xmls = this[0].getElementsByTagName("xml"), xml;
        var len = xmls.length;
        for (i = 0; i < len; i++) {
            xml = xmls[i];
            if (xml.getAttribute("property")) {
                attrs[xml.getAttribute("property")] = xml.innerHTML;
            }
            else {
                $.extend(attrs, $(xml).myattrs());
            }
        }
        if (remove) {
            while (xmls.length > 0) this[0].removeChild(xmls[0]);
        }
        return attrs;
    }
    });

    /**
    * <summary group="method" name="jart.base">
    * 所有控件的基类
    * </summary>
    * <param name="node">
    * 创建控件的元素
    * </param>
    * <param name="attrs">
    * 参数注释
    * </param>
    * <returns type="">
    * 返回值
    * </returns>
    */
    jart.base = function (node, attrs) {
        //判断参数
        if (!node) throw new Error(jart_consts.error_parameter_null.format("jart.base", "node"));
        node = $(node);
        if (node.length < 1) throw new Error(jart_consts.error_parameter_invalid.format("jart.base", "node"));
        if (node.length > 1) node = $(node[0]);

        //检查逻辑
        this.mCheckLogical(node);

        //设置控件id
        var id = node.attr("id");
        if (!id) {
            id = "art_element_" + $.uid();
            node.attr("id", id);
        }
        if (jart_controls[id]) throw new Error(jart_consts.error_object_already_exists.format(id, "jart.base"));
        attrs = $.extend({}, jart_defaults[this.type], node.myattrs(true), attrs);

        /**
        * <summary group="property" name="{jart.base}.id" type="string">
        * 控件的唯一标识
        * </summary>
        */
        this.id = id;

        /**
        * <summary group="property" name="{jart.base}.node" type="jQuery">
        * 控件对应的dom元素
        * </summary>
        */
        this.node = node;

        /**
        * <summary group="property" name="{jart.base}.first" type="Boolean">
        * 是否是初始化属性
        * </summary>
        */
        this.first = true;

        this.node.attr("art_render", "done");
        this.node.attr("art", this.type);
        jart_controls[this.id] = this;
        try {

            /**
            * <summary group="property" name="{jart.base}.wrap" type="jQuery">
            * 控件的最外层元素
            * </summary>
            */
            this.wrap = this.mRenderStart(node, attrs);
            this.wrap.attr("art_wrap", this.id);
            this.mRenderAttrs(attrs, node);
        } catch (e) {
            jart_controls[this.id] = undefined;
            throw e;
        }
        this.first = false;
    };
    jart.base.attachRenderAttrAttribute();

    //渲染属性前处理
    jart.base.prototype.onBeforeAttr = function (name, val) {
        if (["title"].contains(name)) this.node.removeAttr(name);
    };

    /**
    * <summary group="property" name="{jart.base}.type" type="string">
    * 控件的类型
    * </summary>
    */
    jart.base.prototype.type = "";

    /**
    * <summary group="method" name="{jart.base}.mRenderStart">
    * 控件渲染开始函数，请在此函数里初始化控件dom结构
    * </summary>
    */
    jart.base.prototype.mRenderStart = function () {
        throw new Error("mRenderStart");
    };

    /*
    * <summary group="method" name="{jart.base}.mCheckLogical">
    * 检查标签是否合理，不合理则抛出异常，终止操作
    * </summary>
    * <param name="node">
    * 待检查的网页元素
    * </param>
    */
    jart.base.prototype.mCheckLogical = function (node) {
        var selector = "";
        var labels = jart_labels[this.type].split(",");
        for (var i = 0; i < labels.length; i++) {
            selector += "," + labels[i];
        }
        selector = selector.substr(1);
        if (!node.is(selector)) throw new Error(jart_consts.error_node_render_invalid.format(node.attr("id"), this.type));
    };

    /*
    * <summary group="method" name="{jart.base}.mRenderAttrs">
    * 渲染控件的属性
    * </summary>
    * <param name="attrs">
    * 属性集合
    * </param>
    * <param name="first">
    * 是否是第一次渲染时的元素
    * </param>
    */
    jart.base.prototype.mRenderAttrs = function (attrs, node) {
        if (!attrs) return;
        if (this.mRenderBegin) this.mRenderBegin(attrs, node);
        this.attr(attrs, null, ["id", "node", "type"]);
        if (this.mRenderEnd) this.mRenderEnd(attrs, node);
    };

    /**
    * <summary group="method" name="{jart.base}.remove">
    * 移除控件
    * </summary>
    */
    jart.base.prototype.remove = function () {
        if (this.onRemove) this.onRemove();
        this.node.remove();
        this.node = null;
        jart_controls[this.id] = null;
    };

    /*
    * <summary group="property" name="{jart.grid}.delay" type="Object">
    * 获取延迟执行器
    * </summary>
    */
    jart.base.prototype.delay = function () {
        var delay = this.node.data("delay");
        if (!delay) {
            delay = jart_Delay(this, this.onDelay);
            this.node.data("delay", delay);
        }
        return delay;
    };

    //边框设置
    /**
    * <summary group="property" name="jart.base.prototype.borders" type="string">
    * 获取或设置边框
    * </summary>
    */
    jart.base.prototype.borders = function (border) {
        if (border === undefined) return this.node[0].__border;
        this.node[0].__border = border;
        this.node.removeStyle("border-top");
        this.node.removeStyle("border-bottom");
        this.node.removeStyle("border-left");
        this.node.removeStyle("border-right");
        if (border) {
            var strs = border.split(",");
            if (strs.length == 1) {
                if (!Boolean.parse(strs[0])) {
                    this.node.addStyle("border-top", "none 0px");
                    this.node.addStyle("border-bottom", "none 0px");
                    this.node.addStyle("border-left", "none 0px");
                    this.node.addStyle("border-right", "none 0px");
                }
            }
            else if (strs.length == 2) {
                if (!Boolean.parse(strs[0])) {
                    this.node.addStyle("border-top", "none 0px");
                    this.node.addStyle("border-bottom", "none 0px");
                }
                if (!Boolean.parse(strs[1])) {
                    this.node.addStyle("border-left", "none 0px");
                    this.node.addStyle("border-right", "none 0px");
                }
            }
            else if (strs.length > 2) {
                if (!Boolean.parse(strs[0])) this.node.addStyle("border-top", "none 0px");
                if (!Boolean.parse(strs[1])) this.node.addStyle("border-right", "none 0px");
                if (!Boolean.parse(strs[2])) this.node.addStyle("border-bottom", "none 0px");
                if (!Boolean.parse(strs[3])) this.node.addStyle("border-left", "none 0px");
            }
        }
    };

    /**
    * <summary group="property" name="{jart.base}.name" type="String">
    * 控件元素对应的名称
    * </summary>
    */
    jart.base.prototype.name = function () {
        var name = this.node.attr("name");
        if (!name) {
            name = "ctrl_name_" + $.uid();
            this.node.attr("name", name);
        }
        return name;
    };

    /**
    * <summary group="property" name="{jart.base}.width" type="Number">
    * 控件宽度
    * </summary>
    */
    jart.base.prototype.width = function (arg) {
        if (arg === undefined) return this.node.data("width");
        this.node.data("width", arg);
        if (arg) {
            if (isNaN(arg)) this.node.addStyle("width", arg);
            else this.node.addStyle("width", arg + "px");
        }
        else this.node.removeStyle("width");
        return this;
    };

    /**
    * <summary group="property" name="{jart.base}.height" type="Number">
    * 控件高度
    * </summary>
    */
    jart.base.prototype.height = function (arg) {
        if (arg === undefined) return this.node.data("height");
        this.node.data("height", arg);
        if (arg) {
            if (isNaN(arg)) this.node.addStyle("height", arg);
            else this.node.addStyle("height", arg + "px");
        }
        else this.node.removeStyle("height");
        return this;
    };

    /**
    * <summary group="method" name="jart.any">
    * 任意元素控件化
    * </summary>
    * <param name="node">
    * 元素
    * </param>
    * <param name="attrs">
    * 属性集
    * </param>
    */
    jart.any = function (node, attrs) { };
    Function.extend("jart.any", jart.base);
    $.plugin("any", "*");
    jart.any.prototype.mRenderStart = function (node) { };
    //启动操作
    //渲染网页元素形式的jart控件
    window.jart_renderCtrl = function (p) {
        var selector = "[art][art_render!=done]";
        //渲染控件
        var controls = null;
        if (p) controls = p.find(selector);
        else controls = $(selector);
        controls.each(function () {
            jart($(this));
        });
    };
    $(function () {
        document.body.style.visibility = "hidden";
        $("form").css("margin", "0px");
        jart_renderCtrl();
        //每30秒检测无效控件并进行清理
        setInterval(function () {
            var ctl = null;
            for (var key in jart_controls) {
                ctl = jart_controls[key];
                if (ctl && ctl.wrap.parent().length < 1) ctl.remove();
            }
        }, 30000);
    });
    $(window).load(function () {

        //解决ie6/7/firefox下会有竖向滚动条问题
        if ($.browser.ie6 || $.browser.ie7 || $.browser.firefox) $(document.documentElement).css("overflow", "hidden");

        //ie6/7下看不见元素BUG
        if ($.browser.ie7) $(document.body).hide();
        if ($.browser.ie6 || $.browser.ie7) {
            setTimeout(function () {
                $(document.body).hide().show();
                $("[fillx]:visible").fillx();
                $("[filly]:visible").filly();
                document.body.style.visibility = "";
            }, 0);
        }
        else {
            $("[fillx]:visible").fillx();
            $("[filly]:visible").filly();
            document.body.style.visibility = "";
        }
        $.browser.resize(function () {
            if ($.browser.resizable) {
                $("[fillx]:visible").fillx();
                $("[filly]:visible").filly();
            }
        });
    });
    if (escape(jart.plugin.copyright.author) != "%u9648%u5BB6%u519B" || escape(jart.plugin.copyright.company) != "%u79D1%u5927%u8BAF%u98DE") setTimeout(function () { jart = null; }, 0);
})(jQuery);

/*
* 向远程获取数据插件
*/
(function ($, jart) {
    //同步

    //列表插件
    jart.plugin.list = function () {
        //保存集合
        var _items = new Array();

        function sync() {
            for (var i = 0; i < _items.length; i++) {
                this[i] = _items[i];
            }
            for (; i < this.length; i++) this[i] = undefined;
            this.length = _items.length;
        }

        /**
        * <summary group="property" name="{jart.plugin.list}.length" type="Number">
        * 列表长度
        * </summary>
        */
        this.length = 0;

        //向列表尾部插入内容
        this.push = function (item) {
            if (!this.check(item)) return this;
            if (this.unique && _items.contains(item)) return this;
            _items.push(item);
            sync.call(this);
            return this;
        };

        //从列表尾部删除内容
        this.pop = function () {
            var item = _items.pop();
            sync.call(this);
            return item;
        };

        this.sort = function (fn) {
            _items = _items.sort(fn);
            sync.call(this);
            return this;
        };

        this.reverse = function () {
            _items = _items.reverse();
            sync.call(this);
            return this;
        };

        //插入一项
        this.insert = function (item, i) {
            if (!this.check(item)) return this;
            if (this.unique && _items.contains(item)) return this;
            var ret = _items.insert(item, i);
            sync.call(this);
            if (typeof (this.onInsert) == "function") this.onInsert(ret.item, ret.index);
            return this;
        };

        //移除一项
        this.remove = function (item) {
            if (!_items.contains(item)) return this;
            var ret = _items.remove(item);
            sync.call(this);
            if (typeof (this.onRemove) == "function") this.onRemove(ret.item, ret.index);
            return this;
        };

        //移除指定位置的项
        this.removeAt = function (i) {
            var ret = _items.removeAt(i);
            sync.call(this);
            if (typeof (this.onRemove) == "function") this.onRemove(ret.item, ret.index);
            return this;
        };

        //清除
        /**
        * <summary group="method" name="{jart.plugin.list}.clear">
        * 清空列表
        * </summary>
        * <param name="ncb">
        * 是否触发清空事件
        * </param>
        */
        this.clear = function (cb) {
            _items.clear();
            sync.call(this);
            if (cb && typeof (this.onClear) == "function") this.onClear();
            return this;
        };
    };

    //判断项的合法性
    jart.plugin.list.prototype.check = function () {
        return true;
    };

    /**
    * <summary group="property" name="{jart.plugin.list}.unique" type="Boolean">
    * 不允许存在重复的项
    * </summary>
    */
    jart.plugin.list.prototype.unique = false;

    /**
    * <summary group="property" name="{jart.plugin.list}.uniqueProperty" type="String">
    * 项的属性名，列表中不允许存在两个项的此属性值相等
    * </summary>
    */
    jart.plugin.list.prototype.uniqueProperty = "";

    /*
    * <summary group="property" name="{jart.plugin.list}.isArray" type="Boolean">
    * 是数组格式
    * </summary>
    */
    jart.plugin.list.prototype.isArray = true;
})(jQuery, jart);

/*
* 验证插件扩展
*/
(function ($, jart) {
    var validTypes = {
        //邮箱地址验证类型
        email: { validate: function (val) {
            if (!val) return true;
            var re = /^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$/gi;
            return re.test(val);
        }, errorMsg: "不是一个合法的邮箱地址！"
        },
        //网址验证类型
        url: { validate: function (val) {
            if (!val) return true;
            var re = new RegExp("^[a-zA-z]+://[^\\s]*$", "gi");
            return re.test(val);
        }, errorMsg: "不是一个合法的网址！"
        },
        //日期验证类型
        date: { validate: function (val) {
            if (!val) return true;
            var vals = val.split("-");
            if (vals.length != 3) vals = val.split("/");
            if (vals.length != 3) return false;
            if (vals[1].length > 2) return false;
            if (vals[2].length > 2) return false;
            val = vals[0].ltrim("0") + "-" + vals[1].ltrim("0") + "-" + vals[2].ltrim("0");
            var d = Date.parse(val);
            if (d && d.format("%y-%M-%d") == val) return true;
            return false;
        }, errorMsg: "不是一个合法的日期！"
        },
        //长度验证
        length: { validate: function (val, min, max) {
            return val.length >= min && val.length <= max;
        }, errorMsg: "长度超过限制（{0},{1}）！"
        },
        //大小验证
        size: { validate: function (val, min, max) {
            return val.size() >= min && val.size() <= max;
        }, errorMsg: "大小超过限制（{0},{1}）！"
        },
        //比较验证
        than: { validate: function (val, operate, tid, type) {
            var valt = jart(tid).attr(this.validProperty);
            if (type == "int") {
                if (!val || !valt) return true;
                val = parseInt(val);
                valt = parseInt(valt);
            }
            else if (type == "float") {
                if (!val || !valt) return true;
                val = parseFloat(val);
                valt = parseFloat(valt);
            }
            switch (operate) {
                case "==":
                    if (val != valt) return false;
                    break;
                case ">=":
                    if (val < valt) return false;
                    break;
                case "<=":
                    if (val > valt) return false;
                    break;
                case ">":
                    if (val <= valt) return false;
                    break;
                case "<":
                    if (val >= valt) return false;
                    break;
                case "!=":
                    if (val == valt) return false;
                    break;
            }
            return true;
        }, errorMsg: "与控件{1}进行{0}比较不通过！"
        },
        regular: { validate: function (val, regularString) {
            var re = new RegExp("^" + regularString + "$", "gi");
            return re.test(val);
        }, errorMsg: "输入不合法"
        }
    };

    /**
    * <summary group="method" name="jart.plugin.validator">
    * 表单验证插件
    * </summary>
    */
    jart.plugin.validator = function () {
        /**
        * <summary group="property" name="{jart.plugin.validator}.validGroup" type="String">
        * 验证组
        * </summary>
        */
        this.validGroup = null;

        /**
        * <summary group="property" name="{jart.plugin.validator}.required" type="Boolean">
        * 值是否不能为空
        * </summary>
        */
        this.required = false;

        /**
        * <summary group="property" name="{jart.plugin.validator}.regular" type="String">
        * 值必须满足的正则表达式
        * </summary>
        */
        this.regular = null;

        /**
        * <summary group="property" name="{jart.plugin.validator}.validType" type="String">
        * 值必须满足的验证类型（email,url,date,length[1,10]，size[1,10],than[<,id]等）
        * </summary>
        */
        this.validType = null;

        /**
        * <summary group="property" name="{jart.plugin.validator}.customValidator" type="Object">
        * 自定义的验证类型，{validate:function(val){return true;},errorMsg:"消息"}
        * </summary>
        */
        this.customValidator = null;

        /**
        * <summary group="property" name="{jart.plugin.validator}.display" type="String">
        * 提示信息位置（right：右边，below：下方,tip：提示的形式）
        * </summary>
        */
        this.display = "right";

        /**
        * <summary group="property" name="{jart.plugin.validator}.hasErrorStyle" type="Boolean">
        * 当验证不通过时显示错误样式
        * </summary>
        */
        this.hasErrorStyle = true;

        /**
        * <summary group="property" name="{jart.plugin.validator}.customDisplay" type="Function">
        * 自定义提示操作，输入验证结果和值，function(isvalid,msg){}
        * </summary>
        */
        this.customDisplay = null;

        /**
        * <summary group="property" name="{jart.plugin.validator}.requiredMsg" type="String">
        * 为空的提示消息
        * </summary>
        */
        this.requiredMsg = "不能为空！";

        /**
        * <summary group="property" name="{jart.plugin.validator}.errorMsg" type="String">
        * 提示消息，与validType匹配，替换其默认消息
        * </summary>
        */
        this.errorMsg = "";
    };

    /*
    * <summary group="property" name="{jart.plugin.validator}.attrTypes" type="Object">
    * 验证插件属性的类型
    * </summary>
    */
    jart.plugin.validator.prototype.attrTypes = { required: ["b"], display: ["e", "", ["right", "below", "tip"]], hasErrorStyle: ["b"], customDisplay: ["f", "0", ["isvalid", "msg"]] };

    /*
    * <summary group="property" name="{jart.plugin.validator}.validProperty" type="String">
    * 被验证的属性
    * </summary>
    */
    jart.plugin.validator.prototype.validProperty = "text";

    //验证方法
    /**
    * <summary group="method" name="{jart.plugin.validator}.validate">
    * 执行控件的验证
    * </summary>
    * <returns type="Boolean">
    * 验证是否通过
    * </returns>
    */
    jart.plugin.validator.prototype.validate = function () {
        var valid = true;
        var msg = "";
        var val = this.attr(this.validProperty);
        try {
            //非空验证
            if (this.required) {
                if (!val.trim()) {
                    valid = false;
                    msg = this.requiredMsg;
                }
            }

            //进行其它验证
            if (this.validType) {
                //遍历验证类型
                var types = this.validType.split("|");
                for (var i = 0; i < types.length; i++) {
                    var type = types[i];
                    var typeName = type.split("[")[0];
                    var arr = [val];
                    type = type.ltrim(typeName).ltrim("[").rtrim("]");
                    if (type) arr = arr.concat(type.split(","));
                    var vt = validTypes[typeName] || eval(typeName);
                    if (vt) {
                        if (vt.validate.apply(this, arr) == false) {
                            valid = false;
                            var errmsg = null;
                            if (this.errorMsg) errmsg = this.errorMsg.split("|")[i];
                            if (!errmsg) errmsg = vt.errorMsg;
                            msg += errmsg.format(arr[1], arr[2], arr[3], arr[4], arr[5]);
                        }
                    }
                }

                //进行自定义验证
                if (this.customValidator) {
                    if (this.customValidator.validate.call(this, val) == false) {
                        valid = false;
                        msg += this.customValidator.errorMsg;
                    }
                }
            }
        } catch (e) { valid = false; msg = e; }

        var id = this.id + "_errormsgbox";
        $("#" + id).remove();
        if (this.node.attribute("_o_invalid") == "true") this.node.attribute("tooltip", this.node.attribute("_o_tooltip")).attribute("_o_invalid", "false");
        if (this.hasErrorStyle) {
            if (valid) this.node.removeClass("x-textbox-invalid");
            else this.node.addClass("x-textbox-invalid");
        }
        this.customDisplay = Function.parse(this.customDisplay, "isvalid", "msg");
        if (this.customDisplay) this.customDisplay(valid, msg);
        else if (!valid) {
            if (this.display == "right") {
                var nd = this.wrap;
                var msgbox = $("<span id='" + id + "' class='x-invalid-text'>" + msg + "</span>");
                nd.after(msgbox);
            }
            else if (this.display == "below") {
                var nd = this.wrap;
                var msgbox = $("<div id='" + id + "' class='x-invalid-text'>" + msg + "</div>");
                nd.after(msgbox);
            }
            else {
                this.node.attribute("_o_tooltip", this.node.attribute("tooltip")).attribute("_o_invalid", "true");
                this.node.attribute("tooltip", "<span id='" + id + "' class='x-invalid-text'>" + msg + "</span>");
            }
        }

        return valid;
    };

    /**
    * <summary group="method" name="jQuery.isValid">
    * 对表单进行分组验证
    * </summary>
    * <param name="group">
    * 验证组，为空则验证所有
    * </param>
    * <returns type="Boolean">
    * 验证是否通过
    * </returns>
    */
    $.extend({ isValid: function (group) {
        var valid = true;
        for (var key in jart_controls) {
            var ctl = jart_controls[key];
            if (ctl.validGroup !== undefined && ctl.validate !== undefined) {
                if (!ctl.validGroup || ctl.validGroup == group) {
                    if (!ctl.validate()) valid = false;
                }
            }
        }
        return valid;
    }
    });
})(jQuery, jart);

/*
* 弹出层插件
*/
(function ($, jart) {
    var layerTemplate = "<div class='x-layer' allowfilly='0' style='position:absolute;top:0px;left:0px;overflow:hidden;'>" +
"<table cellpadding='0' cellspacing='0' border='0' width='100%'><tr><td>" +
    "<table width='100%' cellpadding='0' cellspacing='0' border='0' class='x-table-fixed'><tr><td class='x-layer-topleft'></td>" +
        "<td class='x-layer-topcenter' style='cursor:move;'>" +
            "<table cellpadding='0' cellspacing='0' border='0' width='100%'><tr><td>" +
            "<div style='width:100%;height:100%;overflow:hidden;white-space:nowrap;text-overflow:ellipsis;-o-text-overflow: ellipsis;padding-left:3px' class='x-layer-title'>{0}</div>" +
            "</td><td align='right'>" +
                "<span style='display:{1};vertical-align:middle' class='x-layer-collapsebutton' hover='x-layer-collapsebutton-hover'></span>" +
                "<span style='display:{2};vertical-align:middle' class='x-layer-maxbutton' hover='x-layer-maxbutton-hover'></span>" +
                "<span style='display:inline-block;vertical-align:middle' class='x-layer-closebutton' hover='x-layer-closebutton-hover'></span>" +
            "</td></tr></table>" +
        "</td>" +
        "<td class='x-layer-topright'></td></tr></table>" +
"</td></tr><tr><td>" +
    "<div class='x-layer-middle'><table width='100%' cellpadding='0' cellspacing='0' border='0' class='x-table-fixed'><tr>" +
        "<td class='x-layer-middleleft' style='line-height:1px;'>&nbsp;</td>" +
        "<td class='x-layer-middlecenter'>" +
            "<div layer_wrap='true' filly=\"{padding:$(this).parents('div.x-layer:first').children('table:first').outerHeight(true)-$(this).height()}\" allowfilly='0' style='overflow:auto;'></div>" +
        "</td>" +
        "<td class='x-layer-middleright' style='line-height:1px;'>&nbsp;</td>" +
    "</tr></table></div>" +
"</td></tr><tr><td>" +
    "<table cellpadding='0' cellspacing='0' border='0' class='x-table-fixed'><tr>" +
        "<td class='x-layer-bottomleft' style='line-height:1px;'>&nbsp;</td>" +
        "<td class='x-layer-bottomcenter' style='line-height:1px;'>&nbsp;</td>" +
        "<td class='x-layer-bottomright' style='line-height:1px;'>&nbsp;</td>" +
    "</tr></table>" +
"</td></tr></table></div>";

    function getBody(node) {
        return node.find("div[layer_wrap=true]:first");
    }

    //居中
    function center(node) {
        var left = ($.browser.width - node.width()) / 2;
        var top = ($.browser.height - node.height()) / 2;
        node.css({ "left": left, "top": top });
    };

    ///最大化窗口
    function maximize(node) {
        node.attr("_width", node[0].style.width);
        node.attr("_height", node[0].style.height);
        node.attr("_top", node[0].style.top);
        node.attr("_left", node[0].style.left);
        node.css({ "top": "0px", "left": "0px" }).attr("fillx", "{target:document.documentElement}").attr("filly", "{target:document.documentElement}").addClass("x-layer-maxed");
        node.fillx().filly();
        node.fillys();
    };

    ///还原
    function restore(node) {
        node.removeClass("x-layer-maxed").removeAttr("fillx").removeAttr("filly").css({ "width": node.attr("_width") || "", "height": node.attr("_height") || "", "top": node.attr("_top") || "", "left": node.attr("_left") || "" });
        node.find("[fillx]").css("width", "");
        node.find("[filly]").css("height", "");
        node.fillys();
    };

    function close(node) {
        var fn = node.data("__close");
        fn.call(node);
    }

    window.__openLayer = function (content, max) {
        this.layerNode = $(layerTemplate.format(this.title || "&nbsp;", this.collapsible ? "inline-block" : "none", this.maxable ? "inline-block" : "none"));
        var zindex = $.zindex();
        if (this.maskable) $.block(this.id + "_block", { message: " ", zindex: zindex });
        this.layerNode.css({ "left": this.left + "px", "top": this.top + "px", "z-index": zindex + 1 });
        if (this.width) this.layerNode.css("width", this.width + "px");
        if (this.height) this.layerNode.css("height", this.height + "px");
        else getBody(this.layerNode).css("overflow-y", "hidden");
        this.layerNode.data("__movable", this.movable);
        this.layerNode.data("__onclose", this.onColse);
        this.layerNode.data("__layerid", this.id);
        this.layerNode[0].__layer = this;
        this.layerNode.data("__close", function () {
            var ctl = this[0].__layer;
            var blkid = this.data("__layerid") + "_block";
            var fn = this.data("__onclose");
            if (fn) fn.call(this);
            this[0].__layer = null;
            this.removeData("__onclose");
            this.remove();
            this.find("[art_render=done]").each(function () {
                $(this).jart().remove();
            });
            $.unblock(blkid);
            ctl.layerNode = null;
        });
        this.layerNode.prependTo($(document.body));
        getBody(this.layerNode).append(content);
        center(this.layerNode);
        if (max) maximize(this.layerNode);
        jart_renderCtrl(getBody(this.layerNode));
        this.layerNode.fillys();

        this.layerNode.binds("td.x-layer-topcenter", "mousedown", null, function (e) {
            var target = $(e.target);
            if (target.is(".x-layer-collapsebutton,.x-layer-maxbutton,.x-layer-closebutton")) return;
            var jq = $(this);
            if (jq.is(".x-layer-maxed")) return;
            if (jq.data("__movable")) jq.dopull(e, 2, "move");
        });
        this.layerNode.binds("span.x-layer-collapsebutton", "click", null, function (e) {
            var jq = $(this);
            if (jq.is(".x-layer-collapsed")) {
                jq.removeClass("x-layer-collapsed");
                jq.find("div.x-layer-middle").parents("tr:first").showx(true);
                jq.find("div.x-layer-middle").slideDown(function () {
                    $(this).parents("div.x-layer:first").fillys();
                });
            }
            else {
                jq.addClass("x-layer-collapsed");
                jq.find("div.x-layer-middle:first").slideUp(function () {
                    $(this).parents("tr:first").showx(false);
                });
            }
        });

        this.layerNode.binds("span.x-layer-maxbutton", "click", null, function (e) {
            var jq = $(this);
            if (jq.is(".x-layer-maxed")) restore(jq);
            else maximize(jq);
        });

        this.layerNode.binds("span.x-layer-closebutton", "click", null, function (e) {
            close($(this));
        });
    };
    jart.plugin.layer = function () {
        ///目标窗口
        this.target = "self";

        ///标题
        this.title = "";

        ///上边位置
        this.top = 0;

        ///左边位置
        this.left = 0;

        ///宽度
        this.width = null;

        ///高度
        this.height = null;

        ///弹出层是否可以移动
        this.movable = false;

        //是否遮罩
        this.maskable = true;

        ///弹出层是否可以最大化操作
        this.maxable = false;

        ///弹出层是否可以折叠操作
        this.collapsible = false;

        ///弹出层是否可以拖动改变大小操作
        this.resizable = false;

        //关闭事件
        this.onClose = function () { };
    };
    jart.plugin.layer.prototype.attrTypes = { target: ["e", "", ["self", "parent", "top"]], top: ["n"], left: ["n"], width: ["n"], height: ["n"], movable: ["b"], maskable: ["b"], maxable: ["b"], collapsible: ["b"], resizable: ["b"], onClose: ["f"] };

    ///打开弹出层，max为打开后是否最大化
    jart.plugin.layer.prototype.open = function (max) {
        if (!this.closed()) return this;
        var win = window[this.target];
        if (!win || !win.__openLayer) win = window;
        win.__openLayer.call(this, this.getContent(), max);
        return this;
    };

    jart.plugin.layer.prototype.getContent = function () { return ""; };

    ///关闭层
    jart.plugin.layer.prototype.close = function () {
        if (this.closed()) return this;
        var fn = this.layerNode.data("__close");
        fn.call(this.layerNode);
        return this;
    };

    ///指示层是否关闭
    jart.plugin.layer.prototype.closed = function () {
        return !this.layerNode;
    };

    var alertTemplater = "<div class='x-alert' style='vertical-align:top;'><div>" +
    "<table><tr><td valign='top'><span style='display:inline-block;' class='x-alert-icon {0}'></span></td>" +
    "<td valign='top'><span style='display:inline-block;' class='x-alert-text'>{1}</span></td></tr></table>" +
    "</div><div align='center' class='x-alert-btn'><span sn='ok'>{2}</span></div></div>";
    var confirmTemplater = "<div class='x-alert' style='vertical-align:top;'><div>" +
    "<table><tr><td valign='top'><span style='display:inline-block;' class='x-alert-icon {0}'></span></td>" +
    "<td valign='top'><span style='display:inline-block;' class='x-alert-text'>{1}</span></td></tr></table>" +
    "</div><div align='center' class='x-alert-btn'><span sn='yes'>{2}</span>&nbsp;&nbsp;&nbsp;&nbsp;<span sn='no'>{3}</span></div></div>";
    var promptTemplater = "<div class='x-alert' style='vertical-align:top;'><div>" +
    "<table><tr><td valign='top'><span style='display:inline-block;' class='x-alert-icon {0}'></span></td>" +
    "<td valign='top'><span style='display:inline-block;' class='x-alert-text'>{1}</span><br><input type='text' style='width:200px;margin-bottom:5px;' /></td></tr></table>" +
    "</div><div align='center' class='x-alert-btn'><span sn='yes'>{2}</span>&nbsp;&nbsp;&nbsp;&nbsp;<span sn='no'>{3}</span></div></div>";
    $.extend({ alert: function (msg, title, type, fn) {
        var win = window.top;
        if (win != window.self && win.jQuery && win.jQuery.alert) {
            win.jQuery.alert(msg, title, type, fn);
        }
        else {
            var str = alertTemplater.format(type ? "x-alert-icon-" + type : "", msg, "确定");
            var layer = new jart.plugin.layer();
            layer.title = title || "No Title";
            layer.width = 300;
            layer.onClose = function () { if (fn) fn(); };
            layer.getContent = function () { return str; };
            layer.open();
            getBody(layer.layerNode).find("span[sn=ok]").click(function () { close($(this).parents("div.x-layer:first")); }).button();
        }
    }, confirm: function (msg, title, type, yesfn, nofn) {
        var win = window.top;
        if (win != window.self && win.jQuery && win.jQuery.confirm) {
            win.jQuery.confirm(msg, title, type, yesfn, nofn);
        }
        else {
            var str = confirmTemplater.format(type ? "x-alert-icon-" + type : "", msg, "确定", "取消");
            var layer = new jart.plugin.layer();
            layer.title = title || "No Title";
            layer.width = 300;
            layer.onclose = function () { if (!this[0].__yesfn && nofn) nofn(); };
            layer.getContent = function () { return str; };
            layer.open();
            getBody(layer.layerNode).find("span[sn=yes]").click(function () {
                var ly = $(this).parents("div.x-layer:first");
                ly[0].__yesfn = true;
                if (yesfn) yesfn();
                close(ly);
            }).button();
            getBody(layer.layerNode).find("span[sn=no]").click(function () { close($(this).parents("div.x-layer:first")); }).button();
        }
    }, prompt: function (msg, title, type, yesfn, nofn) {
        var win = window.top;
        if (win != window.self && win.jQuery && win.jQuery.prompt) {
            win.jQuery.prompt(msg, title, type, yesfn, nofn);
        }
        else {
            var str = promptTemplater.format(type ? "x-alert-icon-" + type : "", msg, "确定", "取消");
            var layer = new jart.plugin.layer();
            layer.title = title || "No Title";
            layer.width = 300;
            layer.onclose = function () { if (!this[0].__yesfn && nofn) nofn(); };
            layer.getContent = function () { return str; };
            layer.open();
            getBody(layer.layerNode).find("span[sn=yes]").click(function () {
                var ly = $(this).parents("div.x-layer:first");
                ly[0].__yesfn = true;
                var tb = $(this).parent().parent().find("input:text:first");
                if (yesfn) yesfn(tb.val());
                close(ly);
            }).button();
            getBody(layer.layerNode).find("span[sn=no]").click(function () { close($(this).parents("div.x-layer:first")); }).button();
        }
    }
    });
})(jQuery, jart);

/*
* 向远程获取数据插件
*/
(function ($, jart) {
    /**
    * <summary group="method" name="jart.plugin.dataLoader">
    * 向远程获取数据插件
    * </summary>
    */
    jart.plugin.dataLoader = function () {
        /**
        * <summary group="property" name="{jart.plugin.dataLoader}.url" type="String">
        * 数据请求的地址
        * </summary>
        */
        this.url = "";

        /**
        * <summary group="property" name="{jart.plugin.dataLoader}.loadMsg" type="String">
        * 请求数据时的加载提示信息
        * </summary>
        */
        this.loadMsg = "";

        /**
        * <summary group="property" name="{jart.plugin.dataLoader}.method" type="String">
        * 请求的类型，post或get等
        * </summary>
        */
        this.method = "get";

        /**
        * <summary group="property" name="{jart.plugin.dataLoader}.queryParams" type="Object">
        * 请求数据集合
        * </summary>
        */
        this.queryParams = {};

        /**
        * <summary group="property" name="{jart.plugin.dataLoader}.blockable" type="Boolean">
        * 请求时是否遮罩提示
        * </summary>
        */
        this.blockable = true;
    };

    /*
    * <summary group="property" name="{jart.plugin.dataLoader}.attrTypes" type="Object">
    * 数据加载插件属性的类型
    * </summary>
    */
    jart.plugin.dataLoader.prototype.attrTypes = { method: ["e", "", ["get", "post"]], queryParams: ["o"], blockable: ["b"] };

    /**
    * <summary group="method" name="{jart.plugin.dataLoader}.blocker">
    * 获取被遮罩的对象
    * </summary>
    * <returns type="jQuery">
    * 被遮罩的对象
    * </returns>
    */
    jart.plugin.dataLoader.prototype.blocker = function () { return null };

    /**
    * <summary group="method" name="{jart.plugin.dataLoader}.loadData">
    * 处理请求并加载数据到控件
    * </summary>
    */
    jart.plugin.dataLoader.prototype.loadData = function () {
        if (typeof (this.onBeforeLoadData) == "function" && this.onBeforeLoadData() === false) return;
        if (!this.url) return;
        var bid = "fagsdfo_" + $.uid();
        if (Boolean.parse(this.blockable)) {
            var blk = this.blocker();
            if (blk) blk.blockj(bid, this.loadMsg);
            //            else $.blockj(bid, this.loadMsg);
        }
        var params = $.extend({}, this.queryParams);
        params.__newtime = (new Date()).toString();
        var obj = this;
        $.ajax({
            type: this.method,
            url: this.url,
            data: params,
            success: function (data) {
                if (typeof (data) == "string") data = eval("(" + data + ")");
                obj.onLoadData(data);
                $.unblock(bid);
            },
            error: function (a, b, c) {
                if (a) {
                    if (a.status == 200 && b == "parsererror") {
                        var data = a.responseText;
                        try {
                            data = eval("(" + data + ")");
                            obj.onLoadData(data);
                        } catch (e) { throw new Error(jart_consts.error_load_data_error); }
                    }
                }
                $.unblock(bid);
            }
        });
    };

    /**
    * <summary group="event" name="{jart.plugin.dataLoader}.onLoadData">
    * 数据加载事件
    * </summary>
    * <param name="data">
    * 加载的数据
    * </param>
    */
    jart.plugin.dataLoader.prototype.onLoadData = function (data) {
        throw new Error("jart.plugin.getdata.onloaddata");
    };
    //捕获错误处理
    window.onerror = function (msg, url, line) {
        Debug.info(msg);
    };
})(jQuery, jart);

/*
* 按钮控件
*/
(function ($, jart) {
    /**
    * <summary group="method" name="jart.button">
    * 按钮控件构造方法
    * </summary>
    * <param name="node">
    * 渲染控件的dom元素
    * </param>
    * <param name="attrs">
    * 绑定的属性集合
    * </param>
    */
    jart.button = function (node, attrs) { };
    Function.extend("jart.button", jart.base, ["attrTypes"]);
    $.plugin("button", "span");

    //控件初始化
    jart.button.prototype.mRenderStart = function (node) {
        var text = $.trim(node.text());
        node.html(
            "<span style='display:inline-block;vertical-align:middle;' class='x-button-left'>" +
                "<span style='display:inline-block;' class='x-button-right'>" +
                    "<span style='display:inline-block;' class='x-button-center' style='white-space:nowrap;'>" +
                        "<span sn='button' class='x-button-text'>" + text + "</span>" +
                    "</span>" +
                "</span>" +
            "</span>");
        node.unselectable().attr("hover", "x-button-over").attr("down", "x-button-click");
        node.find("span[sn=button]").iconed("x-button-icon");
        return node;
    };

    /**
    * <summary group="property" name="jart.button.prototype.text" type="string">
    * 按钮的文本
    * </summary>
    */
    jart.button.prototype.text = function (txt) {
        if (txt === undefined) return this.node.find("span[sn=button]").text();
        this.node.find("span[sn=button]").text(txt);
        return this;
    };

    /**
    * <summary group="property" name="jart.button.prototype.iconurl" type="string">
    * 按钮的图标地址
    * </summary>
    */
    jart.button.prototype.iconurl = function (url) {
        if (url === undefined) return this.node.find("span[sn=button]")[0].iconurl();
        this.node.find("span[sn=button]")[0].iconurl(url);
        return this;
    };

    /**
    * <summary group="property" name="jart.button.prototype.icon" type="string">
    * 按钮的图标类型
    * </summary>
    */
    jart.button.prototype.icon = function (icon) {
        if (icon === undefined) return this.node.find("span[sn=button]")[0].icon();
        this.node.find("span[sn=button]")[0].icon(icon);
        return this;
    };
})(jQuery, jart);

/*
* 文本框控件
*/
(function ($, jart) {
    /*
    * <summary group="method" name="checkStyle">
    * 检查文本框值的风格
    * </summary>
    * <param name="e">
    * 事件参数
    * </param>
    */
    function checkStyle(e) {
        var tn = this.node;
        if (this.maxLength()) {
            if (e) {
                //如果长度超过限制则禁止输入
                if (tn.is("textarea") && tn.val().length >= this.maxLength()) {
                    if (e.keyCode != 8 && !e.ctrlKey) e.preventDefault();
                }
            }
            else {
                //如果长度超过限制则截取
                if (tn.is("textarea") && tn.val().length >= this.maxLength()) {
                    tn.val(tn.val().rtrim("\r\n").substr(0, this.maxLength()));
                }
            }
        }
        if (this.textMode() == "int") {
            if (e) {
                if (e.keyCode == 35 || e.keyCode == 36 || e.keyCode == 37 || e.keyCode == 39) return;
                if ((!((e.keyCode >= 48 && e.keyCode <= 57) || (e.keyCode >= 96 && e.keyCode <= 105)) && e.keyCode != 13 && e.keyCode != 8 && e.keyCode != 46) || e.shiftKey) {
                    e.preventDefault();
                }
                if (!((this.minNum() && parseInt(tn.val()) < this.minNum()) || (this.maxNum() && parseInt(tn.val()) > this.maxNum()))) {
                    tn.attr("pre_val", tn.val());
                }
            }
            else {
                if ((new RegExp("[^0-9]")).test(tn.val())) tn.val(tn.val().replace(new RegExp("[^0-9]"), ""));
                if ((this.minNum() && parseInt(tn.val()) < this.minNum()) || (this.maxNum() && parseInt(tn.val()) > this.maxNum())) {
                    tn.val(tn.attr("pre_val"));
                }
            }
        }
        else if (this.textMode() == "float") {
            if (e) {
                if (e.keyCode == 35 || e.keyCode == 36 || e.keyCode == 37 || e.keyCode == 39) return;
                if ((e.keyCode == 190 || e.keyCode == 110) && tn.val().indexOf(".") < 0) return;
                if ((!((e.keyCode >= 48 && e.keyCode <= 57) || (e.keyCode >= 96 && e.keyCode <= 105)) && e.keyCode != 13 && e.keyCode != 8 && e.keyCode != 46) || e.shiftKey) {
                    e.preventDefault();
                }
                if (!((this.minNum() && parseFloat(tn.val()) < this.minNum()) || (this.maxNum() && parseFloat(tn.val()) > this.maxNum()))) {
                    tn.attr("pre_val", tn.val());
                }
            }
            else {
                var text = tn.val();
                var texts = text.split(".");
                if (texts.length > 1) text = texts[0] + "." + texts[1];
                if (text != tn.val() || (new RegExp("[^0-9.]")).test(text)) tn.val(text.replace(new RegExp("[^0-9.]"), ""));
                if ((this.minNum() && parseFloat(tn.val()) < this.minNum()) || (this.maxNum() && parseFloat(tn.val()) > this.maxNum())) {
                    tn.val(tn.attr("pre_val"));
                }
            }
        }
    }

    /*
    * <summary group="method" name="changeLengthSize">
    * 切换长度提示
    * </summary>
    */
    function changeLengthSize() {
        var max = this.maxLength();
        if (max && max > 0 && max < 99999 && this.showMaxLength()) {
            var tn = this.node;
            var right = 0;
            if (tn.is("textarea")) {
                if ($.browser.opera) right = 18;
                else right = tn.outerWidth() - tn.attr("scrollWidth");
            }
            this.wrap.find("span[sn=max]").css("right", right + "px").showx(true).text(tn.val().length + "/" + max);
        }
    }

    /**
    * <summary group="method" name="jart.textbox">
    * 文本框控件构造方法
    * </summary>
    * <param name="node">
    * 渲染控件的dom元素
    * </param>
    * <param name="attrs">
    * 绑定的属性集合
    * </param>
    */
    jart.textbox = function (node, attrs) { };
    jart.textbox.prototype.attrTypes = { textMode: ["e", "", ["all", "int", "float"]], maxNum: ["n"], minNum: ["n"], showMaxLength: ["b"], maxLength: ["i"] };
    Function.extend("jart.textbox", jart.base, ["attrTypes"]);
    Function.extend("jart.textbox", jart.plugin.validator, ["attrTypes"]);
    $.plugin("textbox", "input:text,input:password,textarea");

    //控件初始化
    jart.textbox.prototype.mRenderStart = function (node) {
        //保存初始文本框值
        var val = node.val();

        //加上textbox样式，并设置textarea的高度为自动
        if (node.is("textarea")) node.addClass("x-textarea");
        else node.addClass("x-textbox");

        //包裹加创建空提示和最大长度提示
        node.wrap("<span style='position:relative;display:inline-block;vertical-align:middle;'><span></span></span>");
        var pnode = node.parent().parent();
        pnode.append("<span sn='empty' style='position:absolute;top:0px;left:0px;display:inline-block;" + (val ? "visibility:hidden" : "") + "' class='x-textbox-empty'></span>");
        pnode.append("<span sn='max' style='position:absolute;bottom:0px;right:0px;display:none;' class='x-textbox-maxtip'>1/100</span>");

        pnode.click(function () {
            $(this).find("input,textarea").focus();
        });

        node.focus(function () {
            var ctl = $(this).jart();
            changeLengthSize.call(ctl);
            ctl.wrap.find("span[sn=empty]").css("visibility", "hidden");

        }).blur(function () {
            var ctl = $(this).jart();
            ctl.wrap.find("span[sn=max]").showx(false);
            ctl.wrap.find("span[sn=empty]").css("visibility", this.value ? "hidden" : "");
        }).change(function () {
            var ctl = $(this).jart();
            ctl.wrap.find("span[sn=empty]").css("visibility", this.value ? "hidden" : "");
        }).keydown(function (e) {
            var ctl = $(this).jart();
            checkStyle.call(ctl, e);
        }).keyup(function () {
            var ctl = $(this).jart();
            checkStyle.call(ctl);
            changeLengthSize.call(ctl);
        });
        node.blur(function () {
            var ctl = $(this).jart();
            ctl.validate();
        });
        return pnode;
    };

    ///水印提示
    jart.textbox.prototype.emptyText = function (txt) {
        if (txt === undefined) return this.wrap.find("span[sn=empty]").text();
        this.wrap.find("span[sn=empty]").text(txt);
        return this;
    };

    ///文本框值
    jart.textbox.prototype.text = function (txt) {
        if (txt === undefined) return this.node.val();
        var oval = this.node.val();
        this.node.val(txt);
        var act = null;
        try { act = document.activeElement; } catch (e) { };
        if (act != this.node[0] && txt != oval) this.node.change();
        return this;
    };

    ///输入模式，all或0：无限制，int或1：只能输入数字，float或2：只能输入小数
    jart.textbox.prototype.textMode = function (mode) {
        if (mode === undefined) return this.node.data("textMode");
        this.node.data("textMode", mode);
        return this;
    };

    ///最大值，当输入模式为数字时此属性生效
    jart.textbox.prototype.maxNum = function (num) {
        if (num === undefined) return this.node.data("maxNum");
        this.node.data("maxNum", num);
        return this;
    };

    ///最小值，当输入模式为数字时此属性生效
    jart.textbox.prototype.minNum = function (num) {
        if (num === undefined) return this.node.data("minNum");
        this.node.data("minNum", num);
        return this;
    };

    ///是否显示最大长度提示
    jart.textbox.prototype.showMaxLength = function (sh) {
        if (sh === undefined) return this.node.data("showMaxLength");
        this.node.data("showMaxLength", sh);
        return this;
    };

    ///限制输入的最大长度
    jart.textbox.prototype.maxLength = function (len) {
        if (len === undefined) return this.node.data("maxLength");
        if (isNaN(len)) len = null;
        this.node.data("maxLength", len);
        if (this.node.is("input")) this.node[0].setAttribute("maxlength", len);
        return this;
    };
})(jQuery, jart);

/*
* 组合框控件
*/
(function ($, jart) {
    /*
    * <summary group="method" name="droplist">
    * 下拉列表组合体，这个作为默认的组合体，组合体为点击combobox时弹出的窗口
    * </summary>
    * <param name="cid">
    * 组合框控件的id
    * </param>
    * <param name="attrs">
    * 组合体属性集合
    * </param>
    */
    function droplist(cid, attrs) {
        ///记录对应控件的ID
        this.cid = cid;

        ///组合体元素
        this.node = null;

        ///宽度是否自适应文本框大小
        this.fixWidth = true;

        ///最大高度，如果为空，则默认自动
        this.maxHeight = null;

        ///是否是多选
        this.multiple = false;

        function render() {
            var ctl = jart(this.cid);
            var data = ctl.dataSource();
            if (typeof (data) == "string") data = eval("(" + data + ")");
            var values = ctl.value().split(",");
            var list = this.node.children("div.x-drop-list");
            list.empty().css("height", "auto");
            if (data) {
                for (var i = 0; i < data.length; i++) {
                    if (values.contains(data[i].value)) data[i].selected = true;
                    list.append("<div dropitem='true' index='" + i + "' style='white-space:nowrap;' class='x-drop-item" + (data[i].selected ? " x-drop-item-selected" : "") + "' hover='x-drop-item-hover' value='" + data[i].value + "' tooltip='" + data[i].text + "'><label style='vertical-align:middle;padding-left:" + (16 * (data[i].level || 0)) + "px'>" + data[i].text + "</label></div>");
                    data[i].selected = false;
                }
                list.children("div[dropitem=true]:first").addClass("x-drop-item-first");
                if (this.maxHeight && this.maxHeight < list.height()) {
                    list.height(this.maxHeight);
                    var selected = list.children("div.x-drop-item-selected:first");
                    if (selected.length > 0) selected.scrollIntoView();
                }
            }
        }

        //打开组合体
        this.open = function () {
            if (this.node.showx()) return this;
            var ctl = jart(this.cid);
            this.node.showx(true).css("z-index", $.zindex()).relateTo(ctl.node);
            if (this.fixWidth) {
                var list = this.node.children("div.x-drop-list");
                var adjust = list.outerWidth() - list.width();
                list.width(ctl.node.outerWidth() - adjust);
            }
            render.call(this);
            return this;
        };

        ///组合框内容变化操作
        this.change = function (txt) {
            if (txt) {
                var list = this.node.children("div.x-drop-list");
                var item = list.children("div[dropitem=true]:contains('" + txt + "'):first");
                if (item.length > 0) item.scrollIntoView(1);
            }
            return this;
        };

        //关闭组合体
        this.close = function () {
            this.node.css("height", "auto").showx(false);
            return this;
        };

        ///移除
        this.remove = function () {
            this.node.remove();
            return this;
        };

        this.attr(attrs);

        ///初始化组合体
        this.node = $("<div style='position:absolute;left:0px;top:0px;display:none;'><div style='overflow-x:hidden;overflow-y:auto;' class='x-drop-list' cid='" + this.cid + "' multiple='" + this.multiple + "'></div></div>").prependTo($(document.body));
        this.node.children("div.x-drop-list").mousedown(function (e) {
            if (this == e.target) return;
            var item = $(e.target);
            if (item.attr("dropitem") != "true") item = item.parent();
            var ctl = jart($(this).attr("cid"));
            var multiple = Boolean.parse($(this).attribute("multiple"));
            if (multiple) {
                item.toggleClass("x-drop-item-selected");

                var text = "", value = "";
                $(this).children(".x-drop-item-selected").each(function () {
                    value += $(this).attr("value") + ",";
                    text += $(this).children("label").text() + ",";
                });

                ctl.value(value.rtrim(",")).text(text.rtrim(","));
            }
            else {
                $(this).children(".x-drop-item-selected").removeClass("x-drop-item-selected");
                ctl.value(item.attr("value")).node.val(item.children("label").text());
                item.addClass("x-drop-item-selected");
                $(this).parent().showx(false);
                ctl.node.change();
            }
        });
    }
    droplist.attachRenderAttrAttribute({ fixWidth: ["b"], maxHeight: ["n"], multiple: ["b"] });

    ///组合下拉框控件
    /**
    * <summary group="method" name="jart.combobox">
    * 组合框控件的构造方法
    * </summary>
    * <param name="node">
    * 渲染控件的dom元素
    * </param>
    * <param name="attrs">
    * 绑定的属性集合
    * </param>
    */
    jart.combobox = function (node, attrs) {
        this.loadData();
    };
    jart.combobox.prototype.attrTypes = { dataSource: ["a"], comboAttrs: ["o", "1"] };
    Function.extend("jart.combobox", jart.textbox, ["attrTypes"]);
    Function.extend("jart.combobox", jart.plugin.dataLoader, ["attrTypes"]);
    $.plugin("combobox", "input:text");

    //控件初始化
    jart.combobox.prototype.mRenderStart = function (node) {
        //切换名称
        var name = node.attr("name");
        var txtname = node.attr("txtname") || (name + "_txt");
        node.attr("name", txtname).attr("readonly", true);

        var pnode = jart.textbox.prototype.mRenderStart.call(this, node);
        pnode.addClass("x-combobox");
        $("<span sn='picker' style='position:absolute;display:inline-block;top:0px;bottom:0px;right:0px;overflow:hidden;_height:100%;' class='x-combobox-picker'></span>").unselectable().appendTo(pnode);
        $("<input type='hidden' name='" + (name || "") + "' sn='value' />").appendTo(pnode);
        if ($.browser.ie6) pnode.children("span[sn=picker]").height(pnode.height());

        node.focus(function () {
            //聚焦时打开组合体
            var ctl = $(this).jart();
            ctl.combo().open();
        }).keydown(function () {
            var ctl = $(this).jart();
            setTimeout(function () { ctl.combo().change(ctl.text()); }, 0);
        });
        //鼠标点击别处时关闭组合体
        $(document).bind("mousedown", this.id, function (e) {
            var ctl = jart(e.data);
            if (!ctl.combo().node.showx()) return;
            var node = ctl.node;
            var offset = node.offset();
            if (e.clientX < offset.left || e.clientX > offset.left + node.outerWidth() || e.clientY < offset.top || e.clientY > offset.top + node.outerHeight()) {
                node = ctl.combo().node;
                offset = node.offset();
                if (e.clientX < offset.left || e.clientX > offset.left + node.outerWidth() || e.clientY < offset.top || e.clientY > offset.top + node.outerHeight()) {
                    ctl.combo().close();
                }
            }
        });

        return pnode;
    };
    jart.combobox.prototype.onRemove = function () {
        if (this.node.data("combo")) this.node.data("combo").remove();
    };
    jart.combobox.prototype.onLoadData = function (data) {
        this.bind(data);
    };

    ///数据源
    jart.combobox.prototype.dataSource = function (data) {
        if (data === undefined) return this.node.data("dataSource");
        this.node.data("dataSource", data);

        //获取并设置选中的值
        var values = "", texts = "";
        if (data && data.length > 0) {
            for (var i = 0; i < data.length; i++) {
                if (data[i].selected) {
                    values += data[i].value + ",";
                    texts += data[i].text + ",";
                }
            }
        }
        if (values || texts) {
            this.value(values.rtrim(","));
            this.text(texts.rtrim(","));
        }
        else this.value("").text("");

        return this;
    };

    ///组合体属性集合
    jart.combobox.prototype.comboAttrs = function (arg) {
        if (arg === undefined) return this.node.data("comboAttrs");
        this.node.data("comboAttrs", arg);
        this.combo().attr(arg);
        return this;
    };

    ///组合框的当前值
    jart.combobox.prototype.value = function (val) {
        if (val === undefined) return this.wrap.children("input[sn=value]").val();
        this.wrap.children("input[sn=value]").val(val);
        return this;
    };

    ///组合体类型
    jart.combobox.prototype.comboType = function (type) {
        if (type === undefined) return this.node.data("comboType") || droplist;
        if (typeof (type) == "string") type = eval(type);
        if (this.node.data("comboType") != type) {
            if (this.node.data("combo")) {
                this.node.data("combo").remove();
                this.node.removeData("combo");
            }
            this.node.data("comboType", type);
        }
        return this;
    };

    //获取组合体
    jart.combobox.prototype.combo = function () {
        if (!this.node.data("combo")) {
            var type = this.comboType();
            this.node.data("combo", new type(this.id, this.comboAttrs()));
        }
        return this.node.data("combo");
    };

    ///绑定数据
    jart.combobox.prototype.bind = function (data) {
        this.dataSource(data);
    };
})(jQuery, jart);

/*
* 时间选择控件
*/
(function ($, jart) {
    function selectModeIndex(ctl) {
        var index = 0;
        switch (ctl.selectMode()) {
            case "datetime":
                index = 1;
                break;
            case "time":
                index = 2;
                break;
            default: break;
        };
        return index;
    }
    //时间选择区块方法
    function adjustText(val) {
        if (!val) {
            this.text("");
            return;
        }
        //对val进行转换
        if (this.displayMode) {
            var mode = this.displayMode.split("|")[selectModeIndex(this)] || this.displayMode;
            mode = mode.replace("d", "(\\d{1,2})").replace("y", "(\\d{1,4})").replace("M", "(\\d{1,2})").replace("h", "(\\d{1,2})").replace("m", "(\\d{1,2})").replace("s", "(\\d{1,2})");
            var reg = new RegExp("^" + mode + "$", "gi");
            var matchs = reg.exec(val);
            if (!matchs || matchs.length < 1) this.text(this.__oldVal || "");
            else {
                matchs.removeAt(0);
                if (this.selectMode() == "date") val = "{0}/{1}/{2}".format(matchs);
                else if (this.selectMode() == "datetime") val = "{0}/{1}/{2} {3}:{4}:{5}".format(matchs);
                else val = "{3}:{4}:{5}".format(matchs);
            }
        }
        //模式为2特殊处理
        if (this.selectMode() == "time") {
            var re = new RegExp("((0?[1-9])|([1-5][0-9])):((0?[1-9])|([1-5][0-9])):((0?[1-9])|([1-5][0-9]))", "gi");
            if (re.test(val)) {
                var h = val.split(":")[0];
                var m = val.split(":")[1];
                var s = val.split(":")[2];
                if (h.length < 2) h = "0" + h;
                if (m.length < 2) m = "0" + m;
                if (s.length < 2) s = "0" + s;
                this.text(h + ":" + m + ":" + s);
            }
            else {
                this.text(this.__oldVal || "");
            }
        }
        else {
            var date = Date.parse(val);
            if (date && (!this.minTime() || date.equals(new Date(this.minTime()), selectModeIndex(this)) >= 0) && (!this.maxTime() || date.equals(new Date(this.maxTime()), selectModeIndex(this)) <= 0)) {
                if (this.selectMode() == "datetime") this.text(date.format("%y/%MM/%dd %hh:%mm:%ss"));
                else this.text(date.format("%y/%MM/%dd"));
            }
            else this.text(this.__oldVal || "");
        }
    }
    //获取控件
    function getCtrl(obj) {
        var id = $(obj).parents("div.x-ds:first").attr("datetimerid");
        return jart(id);
    }

    //获取时间选择块
    function getSelector(obj) {
        return getCtrl(obj).selector();
    }

    //渲染年份菜单
    function renderYearMenu(year) {
        var tmp = 0;
        this.node.find("table[sn=menu_y] td:lt(10)").each(function () {
            if (tmp % 2 == 0) $(this).text(year - 5 + parseInt(tmp / 2));
            else $(this).text(year + parseInt(tmp / 2));
            tmp++;
        });
    }

    ///渲染选择器
    function render() {
        //1.检查范围和模式
        this.node.find("span[sn=timer]").toggle(this.mode != 0).children().toggle(this.mode != 0);
        this.node.find("div.x-ds-top").toggle(this.mode != 2);
        this.node.find("div.x-ds-week").toggle(this.mode != 2);
        this.node.find("div.x-ds-days").toggle(this.mode != 2);
        this.node.find("input[sn=now]").val(this.mode == 0 ? "今天" : "现在");
        this.node.find("input[sn=ok]").val(this.mode == 0 ? "清空" : "确定");

        //2.写文本框
        this.node.find("input[sn_ds=month]").textbox().text(this.showMonth.getMonth() + 1);
        this.node.find("input[sn_ds=year]").textbox().text(this.showMonth.getFullYear());
        this.node.find("input[sn_ds=hour]").textbox().text(this.showMonth.getHours());
        this.node.find("input[sn_ds=minute]").textbox().text(this.showMonth.getMinutes());
        this.node.find("input[sn_ds=second]").textbox().text(this.showMonth.getSeconds());

        //3.渲染时间表
        var date = new Date(this.showMonth);
        date.setDate(1);
        date = date.addDays(0 - date.getDay());
        var dayTable = this.node.find("table[sn=day]");
        this.node.find("table[sn=day]").find("tr").each(function () {
            var selector = getSelector(this);
            $(this).find("td").each(function () {
                $(this).text(date.getDate()).attr("value", date.format("%y/%MM/%dd"));
                if ((selector.minTime && selector.minTime.equals(date, selector.mode) > 0) || (selector.maxTime && selector.maxTime.equals(date, selector.mode) < 0)) {
                    $(this).attr("class", "x-ds-disabled").attr("disabled", true).removeAttr("hover");
                }
                else {
                    if (date.getFullYear() == selector.showMonth.getFullYear() && date.getMonth() == selector.showMonth.getMonth()) {
                        $(this).removeAttr("disabled").attr("class", "x-ds-day").attr("hover", "x-ds-day-on");
                        if (date.equals(selector.selectedDate) == 0) {
                            $(this).addClass("x-ds-day-current");
                        }
                    }
                    else {
                        $(this).removeAttr("disabled").attr("class", "x-ds-other").attr("hover", "x-ds-day-on");
                    }
                }

                date = date.addDays(1);
            });
        });
    }

    //时间选择区块
    function dateSelector(cid) {
        ///记录对应控件的ID
        this.cid = cid;

        //根节点
        this.node = null;

        //模式
        this.mode = 0;

        //最小时间
        this.minTime = null;

        //最大时间
        this.maxTime = null;

        //选中的时间
        this.selectedDate = null;

        //当前显示的月份
        this.showMonth = null;

        //打开
        this.open = function (cTime, minTime, maxTime, mode) {
            if (this.node.showx()) return this;
            if (!cTime) cTime = new Date();
            this.selectedDate = cTime;
            this.showMonth = cTime;
            this.minTime = minTime;
            this.maxTime = maxTime;
            this.mode = mode;

            var ctl = jart(this.cid);
            this.node.showx(true).css("z-index", $.zindex()).relateTo(ctl.node);

            render.call(this);

            return this;
        };

        //关闭
        this.close = function () {
            this.node.showx(false);
        };

        //初始化
        this.node = $("<div style='position:absolute;display:none' class='x-ds' datetimerid='" + this.cid + "'>" +
            "<div class='x-ds-top'><table width='100%'><tr>" +
                "<td align='left'>" +
                    "<span style='display:inline-block;vertical-align:middle' class='x-ds-year-prev' tooltip='向前一年'></span>" +
                    "<span style='display:inline-block;vertical-align:middle' class='x-ds-month-prev' tooltip='向前一月'></span>" +
                "</td>" +
                "<td align='left'><input type='text' jart='textbox' class='x-ds-text' style='width:40px;' sn_ds='month' textmode='int' maxnum='12' maxlength='2' />" +
                    "<div style='position:relative;'><table style='position:absolute;left:0px;top:0px;display:none;' class='x-ds-menu' sn='menu_m'>" +
                        "<tr><td hover='x-ds-menu-on' val='1' nowrap>一月</td><td hover='x-ds-menu-on' val='7' nowrap>七月</td></tr>" +
                        "<tr><td hover='x-ds-menu-on' val='2' nowrap>二月</td><td hover='x-ds-menu-on' val='8' nowrap>八月</td></tr>" +
                        "<tr><td hover='x-ds-menu-on' val='3' nowrap>三月</td><td hover='x-ds-menu-on' val='9' nowrap>九月</td></tr>" +
                        "<tr><td hover='x-ds-menu-on' val='4' nowrap>四月</td><td hover='x-ds-menu-on' val='10' nowrap>十月</td></tr>" +
                        "<tr><td hover='x-ds-menu-on' val='5' nowrap>五月</td><td hover='x-ds-menu-on' val='11' nowrap>十一</td></tr>" +
                        "<tr><td hover='x-ds-menu-on' val='6' nowrap>六月</td><td hover='x-ds-menu-on' val='12' nowrap>十二</td></tr>" +
                    "</table></div>" +
                "</td>" +
                "<td align='left'><input type='text' jart='textbox' class='x-ds-text' style='width:40px;' sn_ds='year' textmode='int' maxlength='4' />" +
                    "<div style='position:relative;'><table style='position:absolute;left:0px;top:0px;display:none;' class='x-ds-menu' sn='menu_y'>" +
                        "<tr><td hover='x-ds-menu-on' nowrap>2006</td><td hover='x-ds-menu-on' nowrap>2006</td></tr>" +
                        "<tr><td hover='x-ds-menu-on' nowrap>2006</td><td hover='x-ds-menu-on' nowrap>2006</td></tr>" +
                        "<tr><td hover='x-ds-menu-on' nowrap>2006</td><td hover='x-ds-menu-on' nowrap>2006</td></tr>" +
                        "<tr><td hover='x-ds-menu-on' nowrap>2006</td><td hover='x-ds-menu-on' nowrap>2006</td></tr>" +
                        "<tr><td hover='x-ds-menu-on' nowrap>2006</td><td hover='x-ds-menu-on' nowrap>2006</td></tr>" +
                        "<tr><td align='center' colspan='2' nowrap><label style='margin:0px 1px;width:16px;display:inline-block' hover='x-ds-menu-on'>←</label><label style='margin:0px 1px;width:16px;display:inline-block' hover='x-ds-menu-on'>×</label><label style='margin:0px 1px;width:16px;display:inline-block' hover='x-ds-menu-on'>→</label></td></tr>" +
                    "</table></div>" +
                "</td>" +
                "<td align='right'>" +
                    "<span style='display:inline-block;vertical-align:middle' class='x-ds-month-next' tooltip='向后一月'></span>" +
                    "<span style='display:inline-block;vertical-align:middle' class='x-ds-year-next' tooltip='向后一年'></span>" +
                "</td>" +
             "</tr></table></div>" +
            "<div class='x-ds-week'><table class='x-table-fixed'><tr>" +
                "<td class='x-ds-weekday'>日</td>" +
                "<td class='x-ds-weekday'>一</td>" +
                "<td class='x-ds-weekday'>二</td>" +
                "<td class='x-ds-weekday'>三</td>" +
                "<td class='x-ds-weekday'>四</td>" +
                "<td class='x-ds-weekday'>五</td>" +
                "<td class='x-ds-weekday'>六</td>" +
            "</tr></table></div>" +
            "<div class='x-ds-days'><table class='x-table-fixed' cellspaing='0' cellpadding='0' sn='day'>" +
                "<tr><td>1</td><td></td><td></td><td></td><td></td><td></td><td></td></tr>" +
                "<tr><td>1</td><td></td><td></td><td></td><td></td><td></td><td></td></tr>" +
                "<tr><td>1</td><td></td><td></td><td></td><td></td><td></td><td></td></tr>" +
                "<tr><td>1</td><td></td><td></td><td></td><td></td><td></td><td></td></tr>" +
                "<tr><td>1</td><td></td><td></td><td></td><td></td><td></td><td></td></tr>" +
                "<tr><td>1</td><td></td><td></td><td></td><td></td><td></td><td></td></tr>" +
            "</table></div>" +
            "<div align='center' style='white-space:nowrap;' class='x-ds-bottom'>" +
                "<input type='button' value='现在' class='x-ds-button' sn='now' />" +
                "<span sn='timer' style='display:none;'><input type='text' jart='textbox' class='x-ds-text x-ds-text-focus' style='width:18px;' sn_ds='hour' maxlength='2' textmode='int' maxnum='23' />：" +
                "<input type='text' jart='textbox' class='x-ds-text x-ds-text-focus' style='width:20px;' sn_ds='minute' maxlength='2' textmode='int' maxnum='59' />：" +
                "<input type='text' jart='textbox' class='x-ds-text x-ds-text-focus' style='width:20px;' sn_ds='second' maxlength='2' textmode='int' maxnum='59' /></span>" +
                "<input type='button' value='确定' class='x-ds-button' sn='ok' />" +
            "</div>" +
            "</div>").prependTo($(document.body));
        jart_renderCtrl(this.node);
        this.node.find("td").css("border", "none");

        this.node.find("input[sn_ds=month]").focus(function () {
            $(this).select().addClass("x-ds-text-focus");
            getSelector(this).node.find("table[sn=menu_m]").show();
        }).blur(function () {
            var jq = $(this);
            var selector = getSelector(this);
            jq.removeClass("x-ds-text-focus");
            getSelector(this).node.find("table[sn=menu_m]").hide();
            if (selector.minTime && selector.minTime.getFullYear() == selector.showMonth.getFullYear() && selector.minTime.getMonth() >= jq.val()) jq.val(selector.minTime.getMonth() + 1);
            if (selector.maxTime && selector.maxTime.getFullYear() == selector.showMonth.getFullYear() && selector.maxTime.getMonth() <= jq.val()) jq.val(selector.maxTime.getMonth() + 1);
            selector.showMonth.setMonth(jq.val() - 1);
            render.call(selector);
        }).keypress(function (e) {
            if (e.keyCode == 13) $(this).blur();
        });

        this.node.find("input[sn_ds=year]").click(function () {
            var selector = getSelector(this);
            $(this).select().addClass("x-ds-text-focus");
            selector.node.find("table[sn=menu_y]").show();
            var year = parseInt($(this).val());
            renderYearMenu.call(selector, year);
        }).blur(function (e) {
            var jq = $(this);
            var selector = getSelector(this);
            jq.removeClass("x-ds-text-focus");
            selector.node.find("table[sn=menu_y]").hide();
            if (selector.minTime) {
                if (selector.minTime.getFullYear() > jq.val()) jq.val(selector.minTime.getFullYear());
                if (selector.minTime.getFullYear() == jq.val() && selector.minTime.getMonth() > selector.showMonth.getMonth()) jq.val(selector.minTime.getFullYear() + 1);
            }
            if (selector.maxTime) {
                if (selector.maxTime.getFullYear() < jq.val()) jq.val(selector.maxTime.getFullYear());
                if (selector.maxTime.getFullYear() == jq.val() && selector.maxTime.getMonth() < selector.showMonth.getMonth()) jq.val(selector.maxTime.getFullYear() - 1);
            }
            selector.showMonth.setFullYear(jq.val());
            render.call(selector);
        }).keypress(function (e) {
            if (e.keyCode == 13) $(this).blur();
        });

        this.node.find("table[sn=menu_m] td").mousedown(function () {
            getSelector(this).node.find("input[sn_ds=month]").val($(this).attr("val"));
        });

        this.node.find("table[sn=menu_y] td:lt(10)").mousedown(function () {
            getSelector(this).node.find("input[sn_ds=year]").val($(this).text());
        });

        this.node.find("table[sn=menu_y] td:last").unselectable().mousedown(function (e) {
            e.preventDefault();
            e.cancelBubble = true;
        });

        var tmp = 0;
        this.node.find("table[sn=menu_y] td:last label").each(function () {
            if (tmp == 0) {
                $(this).unselectable().mousedown(function () {
                    var selector = getSelector(this);
                    var year = parseInt(selector.node.find("table[sn=menu_y] td:first").text()) - 5;
                    renderYearMenu.call(selector, year);
                });
            }
            else if (tmp == 1) {
                $(this).mousedown(function (e) {
                    e.stopPropagation();
                });
            }
            else {
                $(this).unselectable().mousedown(function () {
                    var selector = getSelector(this);
                    var year = parseInt(selector.node.find("table[sn=menu_y] td:first").text()) + 15;
                    renderYearMenu.call(selector, year);
                });
            }
            tmp++;
        });

        this.node.find("span.x-ds-year-prev").click(function () {
            var selector = getSelector(this);
            var date = selector.showMonth.addYears(-1);
            if (selector.minTime && date.getFullYear() * 100 + date.getMonth() < selector.minTime.getFullYear() * 100 + selector.minTime.getMonth()) return;
            selector.showMonth = date;
            render.call(selector);
        });

        this.node.find("span.x-ds-month-prev").click(function () {
            var selector = getSelector(this);
            var date = selector.showMonth.addMonths(-1);
            if (selector.minTime && date.getFullYear() * 100 + date.getMonth() < selector.minTime.getFullYear() * 100 + selector.minTime.getMonth()) return;
            selector.showMonth = date;
            render.call(selector);
        });

        this.node.find("span.x-ds-year-next").click(function () {
            var selector = getSelector(this);
            var date = selector.showMonth.addYears(1);
            if (selector.maxTime && date.getFullYear() * 100 + date.getMonth() > selector.maxTime.getFullYear() * 100 + selector.maxTime.getMonth()) return;
            selector.showMonth = date;
            render.call(selector);
        });

        this.node.find("span.x-ds-month-next").click(function () {
            var selector = getSelector(this);
            var date = selector.showMonth.addMonths(1);
            if (selector.maxTime && date.getFullYear() * 100 + date.getMonth() > selector.maxTime.getFullYear() * 100 + selector.maxTime.getMonth()) return;
            selector.showMonth = date;
            render.call(selector);
        });

        this.node.find("table[sn=day]").click(function (eve) {
            var selector = getSelector(this);
            var td = jQuery(eve.target);
            if (td.is("td") && !td.attr("disabled")) {
                var date = new Date(td.attr("value") + " " + selector.node.find("input[sn_ds=hour]").val() + ":" + selector.node.find("input[sn_ds=minute]").val() + ":" + selector.node.find("input[sn_ds=second]").val());
                selector.selectedDate = date;
                $(this).find("td").removeClass("x-ds-day-current");
                td.addClass("x-ds-day-current");
                if (selector.mode == 0) {
                    getCtrl(this).text(selector.selectedDate.format("%y/%MM/%dd"));
                    selector.node.hide();
                }
            }
        });

        this.node.find("input[sn=now]").click(function () {
            var selector = getSelector(this);
            var date = new Date();
            if ((selector.minTime && selector.minTime.equals(date, selector.mode) > 0) || (selector.maxTime && selector.maxTime.equals(date, selector.mode) < 0)) return;
            selector.selectedDate = date;
            selector.showMonth = selector.selectedDate;
            render.call(selector);
            if (selector.mode == 0) {
                getCtrl(this).text(selector.selectedDate.format("%y/%MM/%dd"));
                selector.node.hide();
            }
        });

        this.node.find("input[sn=ok]").click(function () {
            var selector = getSelector(this);
            var date = new Date(selector.selectedDate.getFullYear(), selector.selectedDate.getMonth(), selector.selectedDate.getDate(), selector.node.find("input[sn_ds=hour]").val(), selector.node.find("input[sn_ds=minute]").val(), selector.node.find("input[sn_ds=second]").val());
            if (selector.mode == 1) getCtrl(this).text(date.format("%y/%MM/%dd %hh:%mm:%ss"));
            else if (selector.mode == 2) getCtrl(this).text(date.format("%hh:%mm:%ss"));
            else getCtrl(this).text(""); //date.format("%y/%MM/%dd"));
            selector.node.hide();
        });
        this.node.find("input[sn_ds=hour],input[sn_ds=minute],input[sn_ds=second]").focus(function () {
            $(this).select();
        });
    }

    ///日期时间选择控件
    jart.datetimer = function (node, attrs) { };
    jart.datetimer.prototype.attrTypes = { selectMode: ["e", "", ["date", "datetime", "time"]] };
    Function.extend("jart.datetimer", jart.textbox, ["attrTypes"]);
    $.plugin("datetimer", "input:text");

    //控件初始化
    jart.datetimer.prototype.mRenderStart = function (node) {
        var pnode = jart.textbox.prototype.mRenderStart.call(this, node);
        pnode.attr("class", "x-datetimer");
        $("<span sn='picker' style='position:absolute;display:inline-block;top:0px;bottom:0px;right:0px;overflow:hidden;_height:100%;' class='x-datetimer-picker'></span>").unselectable().appendTo(pnode);
        if ($.browser.ie6) pnode.children("span[sn=picker]").height(pnode.height());
        node.focus(function () {
            //聚焦时打开时间选择区域
            var ctl = $(this).jart();
            var date = new Date();
            if (ctl.text()) {
                if (ctl.selectMode() == "time") date = Date.parse(date.format("%y/%MM/%dd ") + ctl.text());
                else date = Date.parse(ctl.text());
            }
            ctl.selector().open(date, ctl.minTime(), ctl.maxTime(), selectModeIndex(ctl));
        }).change(function () {
            adjustText.call($(this).jart(), $(this).val());
        });
        //鼠标点击别处时关闭时间选择区域
        $(document).bind("mousedown", this.id, function (e) {
            var ctl = jart(e.data);
            if (!ctl.selector().node.showx()) return;
            var node = ctl.node;
            var offset = node.offset();
            if (e.clientX < offset.left || e.clientX > offset.left + node.outerWidth() || e.clientY < offset.top || e.clientY > offset.top + node.outerHeight()) {
                node = ctl.selector().node;
                offset = node.offset();
                if (e.clientX < offset.left || e.clientX > offset.left + node.outerWidth() || e.clientY < offset.top || e.clientY > offset.top + node.outerHeight()) {
                    ctl.selector().close();
                }
            }
        });

        return pnode;
    };

    ///框内文本
    jart.datetimer.prototype.text = function (txt) {
        if (txt === undefined) return this.node.data("text") || "";
        this.__oldVal = txt;
        this.node.data("text", txt);
        if (this.displayMode) {
            var d = Date.parse(txt);
            if (d) {
                var index = 0;
                switch (this.selectMode()) {
                    case "datetime":
                        index = 1;
                        break;
                    case "time":
                        index = 2;
                        break;
                    default: break;
                };
                var mode = this.displayMode.split("|")[index] || this.displayMode;
                mode = mode.replace("y", d.getFullYear());
                mode = mode.replace("M", (d.getMonth() + 1).toSize(2));
                mode = mode.replace("d", d.getDate().toSize(2));
                mode = mode.replace("h", d.getHours().toSize(2));
                mode = mode.replace("m", d.getMinutes().toSize(2));
                mode = mode.replace("s", d.getSeconds().toSize(2));
                txt = mode;
            }
        }
        jart.textbox.prototype.text.call(this, txt);
        return this;
    };

    ///选择模式，选择模式，date或0：为日期模式，datetime或1：为日期时间模式，time或2：为时间模式
    jart.datetimer.prototype.selectMode = function (mode) {
        if (mode === undefined) return this.node.data("selectMode");
        this.node.data("selectMode", mode);
        return this;

    };

    ///时间的文本模式，默认"y-M-d|y-M-d h:m:s|h:m:s"
    jart.datetimer.prototype.displayMode = "y-M-d|y-M-d h:m:s|h:m:s";

    ///选择的最大时间上限
    jart.datetimer.prototype.maxTime = function (tm) {
        if (tm === undefined) {
            if (typeof (this.__maxtime) == "string") {
                if (this.__maxtime.starts("{") && this.__maxtime.ends("}")) {
                    var ctl = jart(this.__maxtime.ltrim("{").rtrim("}"));
                    if (ctl && typeof (ctl.text) == "function") return Date.parse(ctl.text());
                    return null;
                }
                if (this.__maxtime == "now") return new Date();
                this.__maxtime = Date.parse(this.__maxtime);
            }
            return this.__maxtime;
        }
        this.__maxtime = tm;
        return this;
    };

    ///选择的最小时间上限
    jart.datetimer.prototype.minTime = function (tm) {
        if (tm === undefined) {
            if (typeof (this.__mintime) == "string") {
                if (this.__mintime.starts("{") && this.__mintime.ends("}")) {
                    var ctl = jart(this.__mintime.ltrim("{").rtrim("}"));
                    if (ctl && typeof (ctl.text) == "function") return Date.parse(ctl.text());
                    return null;
                }
                if (this.__mintime == "now") return new Date();
                this.__mintime = Date.parse(this.__mintime);
            }
            return this.__mintime;
        }
        this.__mintime = tm;
        return this;
    };

    //获取组合体
    jart.datetimer.prototype.selector = function () {
        if (!this.__selector) this.__selector = new dateSelector(this.id);
        return this.__selector;
    };
})(jQuery, jart);

/*
* 表单标签
*/
(function ($, jart) {
    ///表单标签
    jart.label = function (node, attrs) { };
    jart.label.prototype.attrTypes = { required: ["b"] };
    Function.extend("jart.label", jart.base, ["attrTypes"]);
    $.plugin("label", "label");

    //控件初始化
    jart.label.prototype.mRenderStart = function (node) {
        node.wrap("<span></span>");
        node = node.parent();
        node.prepend("<span sn='required' style='color:red;visibility:hidden;font-weight:bold;vertical-align:middle;'> * </span>");
        return node;
    };

    ///是否包含必填提示符
    jart.label.prototype.required = function (required) {
        if (required === undefined) return this.wrap.children("span[sn=required]").css("visibility") == "visible";
        this.wrap.children("span[sn=required]").css("visibility", required ? "visible" : "hidden");
        return this;
    };

    ///是否包含必填提示符
    jart.label.prototype.text = function (txt) {
        if (txt === undefined) return this.node.text();
        this.node.text(txt);
        return this;
    };
})(jQuery, jart);

/*
* 表单布局，支持自适应
*/
(function ($, jart) {
    ///表单布局，支持自适应
    jart.form = function (node, attrs) { };
    Function.extend("jart.form", jart.base, ["attrTypes"]);
    $.plugin("form", "table");

    //控件初始化
    jart.form.prototype.mRenderStart = function (node) {
        node.addClass("x-table-fixed").addStyle("border-collapse", "collapse");
        var rows = node[0].rows;
        for (var i = 0; i < rows.length; i++) {
            var cells = rows[i].cells;
            for (var j = 0; j < cells.length; j++) {
                $(cells[j]).attr("allowfillx", "0");
            }
        }
        return node;
    };

    ///设置表单布局的列，columns是以逗号分隔的宽度信息，*号表示宽度不设置
    jart.form.prototype.columns = function (columns) {
        var ws = columns.split(",");
        var html = "<tr style='visibility:hidden;height:0px;border:none;'>";
        for (var i = 0; i < ws.length; i++) {
            if (ws[i] == "*") html += "<td style='height:0px;border:none;'></td>";
            else html += "<td width='" + ws[i] + "' style='height:0px;border:none;'></td>";
        }
        this.node.prepend(html);
    };
})(jQuery, jart);

/*
* 内嵌页面控件
*/
(function ($, jart) {
    ///内嵌页面控件
    jart.iframe = function (node, attrs) { };
    jart.iframe.prototype.attrTypes = { block: ["b"], data: ["o", "1"], onLoaded: ["f"] };
    Function.extend("jart.iframe", jart.base, ["attrTypes"]);
    $.plugin("iframe", "iframe");

    //控件初始化
    jart.iframe.prototype.mRenderStart = function (node) {
        node[0].__timer = setInterval((function (jq) {
            return function () {
                try {
                    var doc = jq[0].contentWindow.document;
                    var body = $(doc.body);
                    if (jq.is("[autox=true]")) {
                        jq.width(body[0].scrollWidth + body.outerWidth(true) - body.width());
                        $(doc.documentElement).css("overflow-x", "hidden");
                    }
                    if (jq.is("[autoy=true]")) {
                        jq.height(body[0].scrollHeight + body.outerHeight(true) - body.height());
                        $(doc.documentElement).css("overflow-y", "hidden");
                    }
                } catch (e) { }
            };
        })(node), 200);
        node.attribute("blockid", "iframe_" + $.uid()).load(function () {
            var jq = $(this);
            $.unblock(jq.attr("blockid"));
            var panelid = $(this).data("panelid");
            if (panelid) {
                var pnl = jart(panelid);
                if (pnl) {
                    try {
                        pnl.title(this.contentWindow.document.title);
                    } catch (e) {
                        pnl.title(this.__title || "无法加载标题");
                    }
                }
            }
            var ctl = jq.iframe();
            if (ctl.onLoaded) ctl.onLoaded();
        });
        return node;
    };

    jart.iframe.prototype.onRemove = function () {
        clearInterval(this.node[0].__timer);
    };

    ///当窗口地址改变时是否加遮罩效果
    jart.iframe.prototype.block = function (block) {
        if (block === undefined) return this.node.data("block");
        this.node.data("block", block);
        return this;
    };

    ///设置窗口地址
    jart.iframe.prototype.url = function (url) {
        if (url === undefined) return this.node.attr("src");
        if (this.block()) {
            var alpha = this.node.attribute("alpha");
            if (alpha) alpha = parseFloat(alpha);
            else alpha = undefined;
            var opts = { alpha: alpha };
            this.node.blockj(this.node.attribute("blockid"), null, opts);
        }
        this.node.attr("src", url);
        return this;
    };

    //默认标题
    jart.iframe.prototype.title = function (arg) {
        if (arg === undefined) return this.node.data("title");
        this.node.data("title", arg);
        return this;
    };

    ///设置iframe关联的面板id
    jart.iframe.prototype.panelid = function (id) {
        if (id === undefined) return this.node.data("panelid");
        this.node.data("panelid", id);
        return this;
    };

    ///传给内面控件的属性
    jart.iframe.prototype.data = function (data) {
        if (data === undefined) return this.node.data("data");
        this.node.data("data", data);
        return this;
    };

    //加载后事件处理
    jart.iframe.prototype.onLoaded = function () { };

    //给子窗口传递数据
    window.__getIframeData = function (fm) { return $(fm).data("data"); };
    if (window.frameElement) window.iframeData = window.parent.__getIframeData(window.frameElement);
})(jQuery, jart);

/*
* 布局控件
*/
(function ($, jart) {
    ///布局控件
    jart.layout = function (id, attrs) { };
    Function.extend("jart.layout", jart.base, ["attrTypes"]);
    $.plugin("layout", "div");

    ///获取或设置区域的折叠状态
    jart.layout.prototype.collapse = function (rgn, collapsed) {
        var split = (rgn == "north" || rgn == "south") ? this.node.children("div.x-layout-" + rgn + "-split") : $(this.node.children("table")[0].rows[0].cells).filter("td.x-layout-" + rgn + "-split");
        if (collapsed === undefined) return split.is(".x-layout-collapsed");
        if (collapsed) split.addClass("x-layout-collapsed");
        else split.removeClass("x-layout-collapsed");
        split.parent().children("[region=" + rgn + "]").showx(!collapsed);
        if (rgn == "north" || rgn == "south") this.node.fillys();
        else {
            if ($.browser.ie8) split.parents("table:first").refresh();
            split.parent().children("[region=middle]").fillxs();
        }
    };

    ///获取或设置区域的大小
    jart.layout.prototype.size = function (rgn, size) {
        var obj = (rgn == "north" || rgn == "south") ? this.node.children("div[region=" + rgn + "]") : $(this.node.children("table")[0].rows[0].cells).filter("td[region=" + rgn + "]");
        if (rgn == "north" || rgn == "south") {
            if (size === undefined) return obj.height();
            obj.height(size);
            this.node.fillys();
        }
        else {
            if (size === undefined) return obj.width();
            obj.width(size);
            obj.fillxs();
            obj.parent().children("td[region=middle]").fillxs();
        }
    };

    jart.layout.prototype.collapsible = function (rgn, collapsible) {
        var split = (rgn == "north" || rgn == "south") ? this.node.children("div.x-layout-" + rgn + "-split") : $(this.node.children("table")[0].rows[0].cells).filter("td.x-layout-" + rgn + "-split");
        if (collapsible === undefined) {
            return split.children("span").showx();
        }
        split.children("span").showx(collapsible);
        if (!this.resizable(rgn)) {
            split.showx(collapsible);
            if (rgn == "north" || rgn == "south") this.node.fillys();
            else this.node.find("td[region=middle]").fillxs();
        }

        return this;
    };

    ///获取或设置区域是否可调整大小
    jart.layout.prototype.resizable = function (rgn, resizable) {
        var split = (rgn == "north" || rgn == "south") ? this.node.children("div.x-layout-" + rgn + "-split") : $(this.node.children("table")[0].rows[0].cells).filter("td.x-layout-" + rgn + "-split");
        if (resizable === undefined) {
            return split.is(".x-layout-" + rgn + "-resizable");
        }
        split.toggleClass("x-layout-" + rgn + "-resizable", resizable);
        if (!this.collapsible(rgn)) {
            split.showx(resizable);
            if (rgn == "north" || rgn == "south") this.node.fillys();
            else this.node.find("td[region=middle]").fillxs();
        }

        return this;
    };

    ///加载north
    jart.layout.prototype.north = function (rgn) {
        if (rgn.length < 1) {
            this.node.children("div[region=north]").empty().showx(false);
            this.collapsible("north", false);
            this.resizable("north", false);
            return this;
        }

        if (!rgn.is("div") || rgn.length > 1) throw new Error(jart_consts.error_layout_regin_invalid);
        rgn.removeAttr("region").css({ "overflow": "auto", "position": "relative" }).attr("allowfillx", "0").attr("allowfilly", "0").attr("filly", "true");

        this.node.children("div[region=north]").empty().append(rgn).showx(true);
        if (rgn.attr("size")) this.size("north", rgn.attr("size"));
        this.collapsible("north", Boolean.parse(rgn.attr("collapsible")));
        this.resizable("north", Boolean.parse(rgn.attr("resizable")));

        return this;
    };

    ///加载west
    jart.layout.prototype.west = function (rgn) {
        if (rgn.length < 1) {
            this.node.find("td[region=west]").empty().showx(false);
            this.collapsible("west", false);
            this.resizable("west", false);
            return this;
        }

        if (!rgn.is("div") || rgn.length > 1) throw new Error(jart_consts.error_layout_regin_invalid);
        rgn.removeAttr("region").css({ "overflow": "auto", "position": "relative" }).attr("allowfillx", "0").attr("allowfilly", "0").attr("filly", "{padding:$(this).jart().node.children('div:visible').heights()}");

        this.node.find("td[region=west]").empty().showx(true).append(rgn);
        if (rgn.attr("size")) this.size("west", rgn.attr("size"));
        this.collapsible("west", Boolean.parse(rgn.attr("collapsible")));
        this.resizable("west", Boolean.parse(rgn.attr("resizable")));


        return this;
    };

    ///加载middle
    jart.layout.prototype.middle = function (rgn) {
        if (!rgn.is("div") || rgn.length != 1) throw new Error(jart_consts.error_layout_regin_invalid);
        rgn.removeAttr("region").css({ "overflow": "auto", "position": "relative" }).attr("allowfillx", "0").attr("allowfilly", "0").attr("filly", "{padding:$(this).jart().node.children('div:visible').heights()}").attr("onfilly", "if(filled&&$.browser.ie6){$(this).jart().node.children('div[region=south]').showx(false).showx(true);}");

        if (rgn.length < 1) throw new Error(jart_consts.error_layout_region_middle_lost);
        this.node.find("td[region=middle]").append(rgn);

        return this;
    };

    ///加载east
    jart.layout.prototype.east = function (rgn) {
        if (rgn.length < 1) {
            this.node.find("td[region=east]").empty().showx(false);
            this.collapsible("east", false);
            this.resizable("east", false);
            return this;
        }

        if (!rgn.is("div") || rgn.length > 1) throw new Error(jart_consts.error_layout_regin_invalid);
        rgn.removeAttr("region").css({ "overflow": "auto", "position": "relative" }).attr("allowfillx", "0").attr("allowfilly", "0").attr("filly", "{padding:$(this).jart().node.children('div:visible').heights()}");

        this.node.find("td[region=east]").empty().showx(true).append(rgn);
        if (rgn.attr("size")) this.size("east", rgn.attr("size"));
        this.collapsible("east", Boolean.parse(rgn.attr("collapsible")));
        this.resizable("east", Boolean.parse(rgn.attr("resizable")));

        return this;
    };

    ///加载south
    jart.layout.prototype.south = function (rgn) {
        if (rgn.length < 1) {
            this.node.children("div[region=south]").empty().showx(false);
            this.collapsible("south", false);
            this.resizable("south", false);
            return this;
        }

        if (!rgn.is("div") || rgn.length > 1) throw new Error(jart_consts.error_layout_regin_invalid);
        rgn.removeAttr("region").css({ "overflow": "auto", "position": "relative" }).attr("allowfillx", "0").attr("allowfilly", "0").attr("filly", "true");

        this.node.children("div[region=south]").append(rgn).showx(true);
        if (rgn.attr("size")) this.size("south", rgn.attr("size"));
        this.collapsible("south", Boolean.parse(rgn.attr("collapsible")));
        this.resizable("south", Boolean.parse(rgn.attr("resizable")));

        return this;
    };

    //控件初始化
    jart.layout.prototype.mRenderStart = function (node) {
        node.attr("allowfilly", "0").css("overflow", "hidden");

        //获取区域
        var north = node.children("div[region=north]");
        var west = node.children("div[region=west]");
        var middle = node.children("div[region=middle]");
        var east = node.children("div[region=east]");
        var south = node.children("div[region=south]");

        //设置控件结构
        node.empty().html(
        //north
    "<div region='north' allowfilly='0'></div>" +
    "<div align='center' class='x-layout-north-split'><span style='display:inline-block' class='x-layout-top-spliticon'></span></div>" +
        //middle
    "<table cellspacing='0' cellpadding='0' border='0' class='x-table-fixed'><tr>" +
        "<td width='160' region='west' style='padding:0px;'></td>" +
        "<td class='x-layout-west-split' style='padding:0px;'><span style='display:inline-block' class='x-layout-left-spliticon'></span></td>" +
        "<td region='middle' style='padding:0px;'></td>" +
            "<td class='x-layout-east-split' style='padding:0px;'><span style='display:inline-block' class='x-layout-right-spliticon'></span></td>" +
        "<td width='160' region='east' style='padding:0px;'></td>" +
    "</tr></table>" +
        //south
    "<div align='center' class='x-layout-south-split'><span style='display:inline-block' class='x-layout-bottom-spliticon'></span></div>" +
    "<div region='south' allowfilly='0' style='_overflow:hidden;'></div>");

        //加载north
        this.north(north);

        //加载west
        this.west(west);

        //加载middle
        this.middle(middle);

        //加载east
        this.east(east);

        //加载south
        this.south(south);

        //绑定north事件
        this.node.children("div.x-layout-north-split").mousedown(function (e) {
            if ($(e.target).is(".x-layout-top-spliticon")) return;
            var jq = $(this);
            if (jq.is(".x-layout-north-resizable")) jq.dopull(e, 1);
        }).pull(function (e) {
            var ctl = $(this).jart();
            ctl.size("north", ctl.size("north") + e.dy);
        }).children("span").click(function () {
            var ctl = $(this).jart();
            ctl.collapse("north", !ctl.collapse("north"));
        });

        //绑定west事件
        this.node.find("td.x-layout-west-split").mousedown(function (e) {
            if ($(e.target).is(".x-layout-left-spliticon")) return;
            var jq = $(this);
            if (jq.is(".x-layout-west-resizable")) jq.dopull(e, 1);
        }).pull(function (e) {
            var ctl = $(this).jart();
            ctl.size("west", ctl.size("west") + e.dx);
        }).children("span").click(function () {
            var ctl = $(this).jart();
            ctl.collapse("west", !ctl.collapse("west"));
        });

        //绑定east事件
        this.node.find("td.x-layout-east-split").mousedown(function (e) {
            if ($(e.target).is(".x-layout-right-spliticon")) return;
            var jq = $(this);
            if (jq.is(".x-layout-east-resizable")) jq.dopull(e, 1);
        }).pull(function (e) {
            var ctl = $(this).jart();
            ctl.size("east", ctl.size("east") - e.dx);
        }).children("span").click(function () {
            var ctl = $(this).jart();
            ctl.collapse("east", !ctl.collapse("east"));
        });

        //绑定south事件
        this.node.children("div.x-layout-south-split").mousedown(function (e) {
            if ($(e.target).is(".x-layout-bottom-spliticon")) return;
            var jq = $(this);
            if (jq.is(".x-layout-south-resizable")) jq.dopull(e, 1);
        }).pull(function (e) {
            var ctl = $(this).jart();
            ctl.size("south", ctl.size("south") - e.dy);
        }).children("span").click(function () {
            var ctl = $(this).jart();
            ctl.collapse("south", !ctl.collapse("south"));
        });

        if ($.browser.ie8) node.children("table:first").refresh();
        return node;
    };
})(jQuery, jart);

/*
* 面板控件
*/
(function ($, jart) {
    function getTitle(ctl) {
        return ctl.node.children("div.x-panel-head").children("div.x-panel-title");
    }

    function getCollapse(ctl) {
        return ctl.node.children("div.x-panel-head").find("span.x-panel-collapsebutton");
    }

    function getClose(ctl) {
        return ctl.node.children("div.x-panel-head").find("span.x-panel-close");
    }

    ///面板控件
    jart.panel = function (id, attrs) { };
    jart.panel.prototype.attrTypes = { showhead: ["b"], collapsable: ["b"], closable: ["b"], collapsed: ["b"] };
    Function.extend("jart.panel", jart.base, ["attrTypes"]);
    $.plugin("panel", "div");

    ///是否显示面板标题
    jart.panel.prototype.showhead = function (show) {
        if (show === undefined) return this.node.children("div.x-panel-head").showx();
        this.node.children("div.x-panel-head").showx(Boolean.parse(show));
        return this;
    };

    ///内容
    jart.panel.prototype.title = function (txt) {
        var tb = getTitle(this);
        if (txt === undefined) return tb.html() == "&nbsp;" ? "" : tb.html();
        tb.html(txt || "&nbsp;");
        return this;
    };

    ///获取或设置元素的图标地址
    jart.panel.prototype.iconurl = function (url) {
        if (url === undefined) return getTitle(this)[0].iconurl();
        getTitle(this)[0].iconurl(url);
        return this;
    };

    ///获取或设置元素的图标类型
    jart.panel.prototype.icon = function (icon) {
        if (icon === undefined) return getTitle(this)[0].icon();
        getTitle(this)[0].icon(icon);
        return this;
    };

    ///面板是否可以手动折叠
    jart.panel.prototype.collapsible = function (able) {
        if (able === undefined) return getCollapse(this).showx();
        able = Boolean.parse(able);
        getCollapse(this).showx(able).middle();
        return this;
    };

    ///面板是否可以手动折叠
    jart.panel.prototype.closable = function (able) {
        if (able === undefined) return getClose(this).showx();
        able = Boolean.parse(able);
        getClose(this).showx(able).middle();
        return this;
    };

    ///面板是否折叠
    jart.panel.prototype.collapsed = function (collapsed) {
        if (collapsed === undefined) return this.node.is(".x-panel-collapsed");
        collapsed = Boolean.parse(collapsed);
        if (collapsed) {
            //折叠的时候要去除一些属性
            this.node[0]._filly = this.node.attr("filly");
            this.node[0]._height = this.node[0].style.height;
            this.node.removeAttr("filly").css("height", "");

            this.node.addClass("x-panel-collapsed");
            this.node.children("div.x-panel-body").slideUp(function () {
                var node = $(this).parent();
                node.children("div.x-panel-head").css("border-bottom", "none 0px");
            });
        }
        else {
            this.node.children("div.x-panel-head").removeStyle("border-bottom");
            this.node.removeClass("x-panel-collapsed");
            this.node.children("div.x-panel-body").show();
            //恢复去掉的属性
            if (this.node[0]._filly !== undefined) this.node.attr("filly", this.node[0]._filly);
            this.node.css("height", this.node[0]._height);
        }
        return this;
    };

    ///内补白
    jart.panel.prototype.padding = function (padding) {
        if (padding === undefined) return this.node.children("div.x-panel-body").css("padding");
        this.node.children("div.x-panel-body").css("padding", padding);
        return this;
    };

    ///获取右方工具条栏，以便扩展
    jart.panel.prototype.tool = function () {
        return this.node.children("div.x-panel-head").children("div.x-panel-toolbar");
    };

    ///控件初始化
    jart.panel.prototype.mRenderStart = function (node) {
        node.addClass("x-panel").attr("allowfilly", "0").css({ "_overflow": "hidden" });
        node.wrapInner("<div style='overflow:auto;position:relative;' allowfillx='0' allowfilly='0' filly='{padding:$(this).prev(\"div:visible\").outerHeight(true)}' class='x-panel-body'></div>");
        node.prepend(
    "<div class='x-panel-head' style='position:relative;'>" +
        "<div class='x-panel-title'>&nbsp;</div>" +
        "<div style='position:absolute;top:0px;right:0px;bottom:0px;_height:100%;' class='x-panel-toolbar'>" +
            "<span _display='inline-block' style='display:none;' class='x-panel-collapsebutton' hover='x-panel-collapsebutton-hover'></span>" +
            "<span _display='inline-block' style='display:none;' class='x-panel-close' hover='x-panel-close-hover'></span>" +
        "</div>" +
    "</div>");
        node.children("div.x-panel-head").children("div.x-panel-title").iconed("x-panel-icon");
        node.children("div.x-panel-head").find("span.x-panel-collapsebutton").click(function () {
            var ctl = $(this).jart();
            ctl.collapsed(!ctl.collapsed());
        });
        node.children("div.x-panel-head").find("span.x-panel-close").click(function () {
            var ctl = $(this).jart();
            ctl.node.showx(!ctl.node.showx());
        });
        return node;
    };
})(jQuery, jart);

/*
* 弹出层控件
*/
(function ($, jart) {
    ///弹出层控件
    jart.layer = function (node, attrs) { };
    jart.layer.prototype.attrTypes = { iframe: ["b"], autoTitle: ["b"], onCallback: ["f", "0", ["arg"]] };
    Function.extend("jart.layer", jart.base, ["attrTypes"]);
    Function.extend("jart.layer", jart.plugin.layer, ["attrTypes"]);
    $.plugin("layer", "div");

    //弹出层的网址
    jart.layer.prototype.url = "";

    //弹出层的标题是否自动更新
    jart.layer.prototype.autoTitle = true;

    /**
    * <summary group="property" name="{jart.layer}.iframe" type="Boolean">
    * 是否是内嵌页面模式
    * </summary>
    */
    jart.layer.prototype.iframe = false;

    //回调事件
    jart.layer.prototype.onCallback = function (arg) { };

    /*#region*/
    //打开窗口
    jart.layer.prototype.open = function (mode, url) {
        if (typeof (mode) == "string" && mode != 0 && mode != 1) {
            url = mode;
            mode = 0;
        }
        if (url) this.url = url;
        jart.plugin.layer.prototype.open.call(this, mode);
    };

    jart.layer.prototype.getContent = function () {
        if (this.iframe) {
            var content = "<iframe frameborder='0' art='iframe' alpha='0' url='" + this.url + "' style='width:100%;' filly='true' class='x-layer-frame'";
            if (this.autoTitle) content += " onload=\"var title='" + jart_consts.error_layer_title_unget + "';try{title=this.contentWindow.document.title;}catch(e){}$(this).parents('div.x-layer:first').find('div.x-layer-title:first').text(title);\"";
            content += "></iframe>";
            return content;
        }
        else {
            return this.node.data("contents");
        }
    };
    ///控件初始化
    jart.layer.prototype.mRenderStart = function (node) {
        node.showx(false);
        node.data("contents", node.html());
        node.empty();
        return node;
    };

    ///关闭弹出层，参数cb指示是否回调
    $.extend({ close: function (cb, arg) {
        if (cb) $.callback(arg);
        if (window.frameElement && $(window.frameElement).parents("div.x-layer:first").length > 0)
            $(window.frameElement).parents("div.x-layer:first")[0].__layer.close();
    }, callback: function (arg) {
        if (window.frameElement && $(window.frameElement).parents("div.x-layer:first").length > 0) {
            var ly = $(window.frameElement).parents("div.x-layer:first")[0].__layer;
            if (ly.onCallback) ly.onCallback(arg);
        }
    }
    });
})(jQuery, jart);

/*
* 导航控件
*/
(function ($, jart) {
    //导航组类，text：文本，iconUrl：图标地址，original：是否是原始内容，content：组下面的内容，只有当original为true时，此属性有效
    function navbarGroup() {
        var iid = "navbar_group_iid_" + $.uid();
        this.iid = function () { return iid; };
        this.id = "navbar_group_" + $.uid();
        this.text = "";
        this.iconUrl = "";
        this.original = false;
        this.content = "";
        this.items = new navbarItemList(iid);
        this.html = function (arg) {
            var htm = "<div id='{0}' nid='{1}' class='x-navbar-group' style='margin-bottom:-1px;{2}'>".format(iid, this.id, arg.index == 0 ? "margin-top:-1px;" : "");
            htm += "<div>";
            if (this.iconUrl) htm += "<img src='{0}' style='vertical-align:middle;margin-right:1px;' />".format(this.iconUrl);
            htm += this.text + "</div>";
            htm += "</div>";
            htm += "<div id='{0}_container' style='overflow:auto;margin-top:1px;_width:100%;{1}' filly=\"{padding:this.parent().children('div:visible').not(this).heights()}\" fillable='return this.jart().exclude();'>".format(iid, arg.exclude && arg.index > 0 ? "display:none" : "");
            if (this.original) htm += this.content;
            else {
                for (var i = 0, len = this.items.length; i < len; i++) {
                    htm += this.items[i].html();
                }
            }
            htm += "</div>";
            return htm;
        };

        this.set_items = function (items) {
            if (items instanceof navbarItemList) return items;
            var myitems = new navbarItemList(iid);
            for (var i = 0; i < items.length; i++) {
                var item = new navbarItem();
                item.attr(items[i]);
                myitems.push(item);
            }
            return myitems;
        };

        this.onAttr = function (name, val) {
        };
    }
    navbarGroup.attachRenderAttrAttribute({ original: ["b"], items: ["a"] });
    navbarGroup.prototype.insertItem = function (data, index) {
        var item = new navbarItem();
        item.attr(data);
        this.items.insert(item, index);
    };

    //导航项类
    function navbarItem() {
        var iid = "navbar_item_iid_" + $.uid();
        this.iid = function () { return iid; };
        this.id = "navbar_item_" + $.uid();
        this.text = "";
        this.iconUrl = "";
        this.url = "";
        this.target = "";
        this.onclick = function (node) { };
        this.html = function (arg) {
            var htm = "<div id='{0}' class='x-navbar-item' hover='x-navbar-item-hover' nid='{1}' url='{2}' target='{3}'>".format(iid, this.id, this.url, this.target);
            if (this.iconUrl) htm += "<img src='{0}' style='vertical-align:middle;margin-right:1px;' />".format(this.iconUrl);
            htm += this.text + "</div>";
            return htm;
        };
    }
    navbarItem.attachRenderAttrAttribute({ onclick: ["f", "", ["node"]] });

    //导航组集合，id为导航控件的ID
    function navbarGroupList(nb) {
        this.nb = nb;
    }
    navbarGroupList = Function.extend(navbarGroupList, jart.plugin.list);
    navbarGroupList.prototype.check = function (item) {
        return item instanceof navbarGroup;
    };
    navbarGroupList.prototype.onInsert = function (item, index) {
        var exclude = this.nb.jart().exclude();
        var gps = this.nb.children("div.x-navbar-group");
        if (index == 0 && gps.length > 0) {
            $(gps[0]).removeStyle("margin-top").next().hide();
        }
        if (index >= gps.length) {
            this.nb.append(item.html({ index: index, exclude: exclude }));
        }
        else {
            $(gps[index]).before(item.html({ index: index, exclude: exclude }));
        }
        this.nb.fillys();
    };
    navbarGroupList.prototype.onRemove = function (item, index) {
        $("#" + item.iid()).remove();
    };

    //导航项集合，id为导航组容器的ID
    function navbarItemList(gid) {
        this.gid = gid;
        this.check = function (item) {
            return item instanceof navbarItem;
        };
        this.onInsert = function (item, index) {
            var gp = $("#" + this.gid + "_container");
            var items = gp.children("div.x-navbar-item");
            if (index == this.length - 1) {
                gp.append(item.html());
            }
            else {
                $(items[index]).before(item.html());
            }
        };
        this.onRemove = function (item, index) {
            $("#" + item.iid()).remove();
        };
    }
    navbarItemList = Function.extend(navbarItemList, jart.plugin.list);

    /*
    * <summary group="method" name="findItemByIId">
    * 获取导航指定IID的项
    * </summary>
    * <param name="id">
    * 项的IID
    * </param>
    * <returns type="navbarItem">
    * 导航项
    * </returns>
    */
    function findItemByIId(id) {
        var j, len2;
        for (var i = 0, len1 = this.groups.length; i < len1; i++) {
            for (j = 0, len2 = this.groups[i].items.length; j < len2; j++) {
                if (this.groups[i].items[j].iid() == id) return this.groups[i].items[j];
            }
        }
        return null;
    }

    ///导航控件
    jart.navbar = function (node, attrs) {
    };
    jart.navbar.prototype.attrType = { exclude: ["b"], dataSource: ["a"] };
    Function.extend("jart.navbar", jart.base, ["attrTypes"]);
    $.plugin("navbar", "div");

    //控件初始化
    jart.navbar.prototype.mRenderStart = function (node, attrs) {
        //定义导航组集合
        this.groups = new navbarGroupList(node);

        //从标签加载数据源
        var children = this.node.children("div");
        this.node.empty();
        var groups = [], group, gpnode;
        for (var i = 0; i < children.length; i++) {
            var gpnode = $(children[i]);
            group = gpnode.myattrs();
            group.content = gpnode.html();
            group.items = [];
            gpnode.children("div").each(function () {
                var item = $(this).myattrs();
                if ($(this).text()) item.text = $(this).text();
                group.items.insert(item);
            });
            groups.push(group);
        }
        attrs.dataSource = groups;

        //设置属性和事件
        node.css("overflow", "hidden").addClass("x-navbar").attr("allowfilly", "0").attr("allowfillx", "0");
        node.binds("div.x-navbar-group", "click", null, function (e) {
            var jq = e.targets;
            if ($(this).jart().exclude()) {
                if (!jq.next().is(":visible")) {
                    jq.parent().children("div:odd:visible").slideToggle();
                }
            }
            jq.next().slideToggle(function () { $(this).parent().fillys(); });
        });
        node.binds("div.x-navbar-item", "click", null, function (e) {
            var ctl = $(this).jart();
            var jq = e.targets;
            var item = findItemByIId.call(ctl, jq.attribute("id"));
            if (item.onclick && item.onclick(jq) == false) return;
            ctl.node.find("div.x-navbar-item-selected").removeClass("x-navbar-item-selected");
            jq.addClass("x-navbar-item-selected");
            if (jq.attribute("url")) {
                $.redirect(jq.attribute("url"), jq.attribute("target"));
            }
        });

        return node;
    };

    /**
    * <summary group="property" name="{jart.navbar}.dataSource" type="Array">
    * 导航的数据源
    * </summary>
    */
    jart.navbar.prototype.dataSource = function (data) {
        if (data === undefined) return this.node.data("dataSource");
        this.node.data("dataSource", data);
        this.groups.clear();
        if (data) {
            for (var i = 0, len = data.length; i < len; i++) {
                this.groups.push(this.newGroup(data[i]));
            }
        }
        this.update();
        return this;
    };

    /**
    * <summary group="method" name="{jart.navbar}.update">
    * 当数据发生变化时，调用此方法更新控件的显示
    * </summary>
    */
    jart.navbar.prototype.update = function () {
        this.node.empty();
        var content = "";
        for (var i = 0; i < this.groups.length; i++) {
            content += this.groups[i].html({ index: i, exclude: this.exclude() });
        }
        this.node.append(content);
        jart_renderCtrl(this.node);
        this.node.fillys();
    };

    jart.navbar.prototype.newGroup = function (data) {
        var group = new navbarGroup();
        group.attr(data);
        return group;
    };

    jart.navbar.prototype.newItem = function (data) {
        var item = new navbarItem();
        item.attr(data);
        return item;
    };

    ///插入一个组
    jart.navbar.prototype.insertGroup = function (data, index) {
        var group = this.newGroup(data);
        this.groups.insert(group, index);
        return group;
    };

    ///设置导航组是否互斥显示
    jart.navbar.prototype.exclude = function (exclude) {
        if (exclude === undefined) return this.node.data("exclude");
        this.node.data("exclude", exclude);
        return this;
    };

    ///返回导航选中的项
    jart.navbar.prototype.selectedItem = function () {
        var node = this.node.find("div.x-navbar-item-selected");
        if (node.length < 1) return null;
        var id = node.attr("nid");
        return this.findItemById(id);
    };

    /**
    * <summary group="method" name="{jart.navbar}.findItemById">
    * 获取导航指定ID的项
    * </summary>
    * <param name="id">
    * 项的ID
    * </param>
    * <returns type="navbarItem">
    * 导航项
    * </returns>
    */
    jart.navbar.prototype.findItemById = function (id) {
        var j, len2;
        for (var i = 0, len1 = this.groups.length; i < len1; i++) {
            for (j = 0, len2 = this.groups[i].items.length; j < len2; j++) {
                if (this.groups[i].items[j].id == id) return this.groups[i].items[j];
            }
        }
        return null;
    };
})(jQuery, jart);

/*
* 工具条控件
*/
(function ($, jart) {
    function toolbarItem() {
        var iid = "toolbar_item_iid_" + $.uid();
        this.iid = function () { return iid; };
        this.id = "toolbar_item_" + $.uid();
        this.icon = "";
        this.iconUrl = "";
        this.text = "";
        this.tooltip = "";
        this.onclick = function (node) { };
        this.disabled = false;
        this.html = function (arg) {
            var iconClass = "", iconStyle = "";
            if (this.iconUrl) {
                iconClass = " x-toolbar-item-icon";
                iconStyle = "background-image:url(" + this.iconUrl + ")";
            }
            else if (this.icon) iconClass = " x-toolbar-item-icon x-icon-" + this.icon;
            var htm = "<span id='{4}' nid='{0}' tooltip='{6}' class='x-toolbar-item' hover='x-toolbar-item-hover' down='x-toolbar-item-down' style='display:inline-block;' {5}><a class='x-toolbar-item-text{2}' style='display:inline-block;{3}'>{1}</a></span>".format(this.id, this.text, iconClass, iconStyle, iid, this.disabled ? "todisabled='true'" : "", this.tooltip);
            return htm;
        };
        this.onAttr = function (name, val) {
            var node = $("#" + iid);
            if (node.length < 1) return;
            name = name.lower();
            if (name == "disabled") {
                node[0].setAttribute("disabled", val);
                if (val) {
                    node.addStyle("color", "gray").alpha(0.5).removeClass("x-toolbar-item-hover").removeAttr("hover").removeAttr("down");
                }
                else {
                    node.removeStyle("color").alpha(1).attr("hover", "x-toolbar-item-hover").attr("down", "x-toolbar-item-down");
                }
            }
            else if (name == "text") {
                node.children("a").text(val);
            }
        };
    }
    toolbarItem.attachRenderAttrAttribute({ onclick: ["f", "", ["node"]], disabled: ["b"] });
    toolbarItem.prototype.category = "item";

    function toolbarSplit() {
        var iid = "toolbar_split_iid_" + $.uid();
        this.iid = function () { return iid; };
        this.html = function (arg) {
            var htm = "<span id='" + iid + "' class='x-toolbar-split' style='display:inline-block;'></span>";
            return htm;
        };
    }
    toolbarSplit.attachRenderAttrAttribute();
    toolbarSplit.prototype.category = "split";

    //工具条项集合
    function toolbarItems(tb, pos) {
        this.tb = tb;
        this.pos = pos;
    }
    toolbarItems = Function.extend(toolbarItems, jart.plugin.list);
    toolbarItems.prototype.check = function (item) {
        return (item instanceof toolbarItem) || (item instanceof toolbarSplit);
    };
    toolbarItems.prototype.onInsert = function (item, index) {
        var group = this.tb.children("div[position=" + this.pos + "]");
        var content = $(item.html({ index: index }));
        if (content.is("span.x-toolbar-item[todisabled]")) {
            content[0].setAttribute("disabled", true);
            content.addStyle("color", "gray").alpha(0.5).removeClass("x-toolbar-item-hover").removeAttr("hover").removeAttr("down").removeAttr("todisabled");
        }
        if (index == this.length - 1) {
            group.append(content);
        }
        else {
            group.children("span:eq(" + index + ")").before(content);
        }
    };
    toolbarItems.prototype.onRemove = function (item, index) {
        $("#" + item.iid()).remove();
    };

    ///工具条控件
    jart.toolbar = function (node, attrs) {
    };
    jart.toolbar.prototype.attrTypes = { dataSource: ["a"], onItemClick: ["f", "", ["item", "node"]] };
    Function.extend("jart.toolbar", jart.base, ["attrTypes"]);
    $.plugin("toolbar", "div");

    ///控件初始化
    jart.toolbar.prototype.mRenderStart = function (node, attrs) {
        ///工具项集合
        this.litems = new toolbarItems(node, "left");
        this.ritems = new toolbarItems(node, "right");

        var left = node.children("div[position=left]").css("float", "left");
        var right = node.children("div[position=right]").css("float", "right");
        node.addClass("x-toolbar").children("div[position!=left][position!=right]").remove();
        if (left.length == 0) left = $("<div position='left' style='float:left;'></div>").appendTo(node);
        else {
            //从标签加载数据源
            var children = left.children("button");
            left.empty();
            var btns = [], btn, bnode;
            for (var i = 0; i < children.length; i++) {
                var bnode = $(children[i]);
                btn = bnode.myattrs();
                btns.push(btn);
            }
            if (!attrs.dataSource) attrs.dataSource = [];
            attrs.dataSource.push(btns);
        }
        if (right.length == 0) right = $("<div position='right' style='float:right;'></div>").appendTo(node);
        else {
            //从标签加载数据源
            var children = right.children("button");
            right.empty();
            var btns = [], btn, bnode;
            for (var i = 0; i < children.length; i++) {
                var bnode = $(children[i]);
                btn = bnode.myattrs();
                btns.push(btn);
            }
            if (!attrs.dataSource) attrs.dataSource = [[]];
            attrs.dataSource.push(btns);
        }

        node.binds("span.x-toolbar-item", "click", null, function (e) {
            var ctl = $(this).jart();
            var jq = e.targets;
            if (jq.is("[disabled=true]")) return;
            var id = jq.attr("nid");
            var item = ctl.findItemById(id);
            if (item.onclick) item.onclick(jq);
            if (ctl.onItemClick) ctl.onItemClick(item, jq);
        });

        return node;
    };

    /**
    * <summary group="property" name="{jart.toolbar}.dataSource" type="Array">
    * 导航的数据源
    * </summary>
    */
    jart.toolbar.prototype.dataSource = function (data) {
        if (data === undefined) return this.node.data("dataSource");
        this.node.data("dataSource", data);
        this.litems.clear();
        this.ritems.clear();
        var litems = data[0], ritems = data[1];
        var i, len;
        if (litems) {
            for (i = 0, len = litems.length; i < len; i++) {
                if (litems[i]) {
                    if (litems[i].category == "split") this.litems.push(this.newSplit());
                    else this.litems.push(this.newItem(litems[i]));
                }
                else this.litems.push(this.newSplit());

            }
        }
        if (ritems) {
            for (i = 0, len = ritems.length; i < len; i++) {
                if (ritems[i]) {
                    if (ritems[i].category == "split") this.ritems.push(this.newSplit());
                    else this.ritems.push(this.newItem(ritems[i]));
                }
                else this.ritems.push(this.newSplit());
            }
        }
        this.update();
        return this;
    };

    /**
    * <summary group="method" name="{jart.toolbar}.update">
    * 当数据发生变化时，调用此方法更新控件的显示
    * </summary>
    */
    jart.toolbar.prototype.update = function () {
        var left = this.node.children("div[position=left]").empty();
        var content = "", i = 0;
        for (i = 0; i < this.litems.length; i++) {
            content += this.litems[i].html({ index: i });
        }
        left.append(content);
        var right = this.node.children("div[position=right]").empty();
        content = "";
        for (i = 0; i < this.ritems.length; i++) {
            content += this.ritems[i].html({ index: i });
        }
        right.append(content);
        this.node.find("span.x-toolbar-item[todisabled]").each(function () {
            this.setAttribute("disabled", true);
            $(this).addStyle("color", "gray").alpha(0.5).removeClass("x-toolbar-item-hover").removeAttr("hover").removeAttr("down").removeAttr("todisabled");
        });
    };

    jart.toolbar.prototype.newItem = function (data) {
        var item = new toolbarItem();
        item.attr(data);
        return item;
    };

    jart.toolbar.prototype.newSplit = function (data) {
        var split = new toolbarSplit();
        split.attr(data);
        return split;
    };

    //创建一个工具项
    jart.toolbar.prototype.insertItem = function (data, index, pos) {
        if (typeof (index) == "string") {
            pos = index;
            index = null;
        }
        var item = this.newItem(data);
        if (pos == "right") this.ritems.insert(item, index);
        else this.litems.insert(item, index);
        return item;
    };

    //创建一个工具项分割
    jart.toolbar.prototype.insertSplit = function (index, pos) {
        if (typeof (index) == "string") {
            pos = index;
            index = null;
        }
        var split = this.newSplit();
        if (pos == "right") this.ritems.insert(split, index);
        else this.litems.insert(split, index);
        return split;
    };

    //绑定工具条项
    jart.toolbar.prototype.bind = function (data) {
        this.dataSource(data);
        return this;
    };

    jart.toolbar.prototype.findItemById = function (id) {
        var i, len;
        for (i = 0, len = this.litems.length; i < len; i++) {
            if (this.litems[i].id == id) return this.litems[i];
        }
        for (i = 0, len = this.ritems.length; i < len; i++) {
            if (this.ritems[i].id == id) return this.ritems[i];
        }
        return null;
    };

    ///工具项点击事件
    jart.toolbar.prototype.onItemClick = function (item, node) { };
})(jQuery, jart);

/*
* 翻页控件
*/
(function ($, jart) {
    //文字版模板
    /*#region*/
    //创建一个数据跳转链接
    function createNumLinker(num) {
        var lnk = $("<a>" + num + "</a>");
        if (num == this.pageIndex()) lnk.attr("class", "x-pager-unlink");
        else {
            lnk.attr("class", "x-pager-link");
            lnk.click(function () {
                var ctl = $(this).jart();
                ctl.pageIndex($(this).text());
            });
        }
        return lnk;
    }

    //创建一个数据跳转省略符
    function createEllipsis() {
        return $("<a class='x-pager-unlink'>…</a>");
    }

    //创建页号内容
    function createNums(nb) {
        var pc = this.pageCount();
        var pi = this.pageIndex();

        //当页数小于12时显示所有页号
        if (pc < 12) {
            for (var i = 1; i <= pc; i++) {
                nb.append(createNumLinker.call(this, i));
            }
        }
        else {
            nb.append(createNumLinker.call(this, 1));
            nb.append(createNumLinker.call(this, 2));

            var pmin = pi - 2;
            var pmax = pi + 2;
            if (pmin < 4) {
                pmin = 4;
                pmax = 8;
            }
            else if (pmax > pc - 3) {
                pmax = pc - 3;
                pmin = pmax - 4;
            }

            if (pmin == 4) {
                nb.append(createNumLinker.call(this, 3));
            }
            else {
                nb.append(createEllipsis());
            }
            for (var i = pmin; i <= pmax; i++) {
                nb.append(createNumLinker.call(this, i));
            }
            if (pmax == pc - 3) {
                nb.append(createNumLinker.call(this, pc - 2));
            }
            else {
                nb.append(createEllipsis.call(this));
            }

            nb.append(createNumLinker.call(this, pc - 1));
            nb.append(createNumLinker.call(this, pc));
        }
    }

    function textMode() {
        var str = "<div sn='state' style='float:left'>显示 {0} - {1}，共 {2} 条</div>" +
            "<div style='float:right'>" +
                "<a sn='first'" + (this.pageIndex() == 1 ? " disabled='disabled' class='x-pager-unlink'" : " class='x-pager-link'") + ">首页</a>" +
                "<a sn='prev'" + (this.pageIndex() == 1 ? " disabled='disabled' class='x-pager-unlink'" : " class='x-pager-link'") + ">上页</a>" +
                "<span sn='number'></span>" +
                "<a sn='next'" + (this.pageIndex() >= this.pageCount() ? " disabled='disabled' class='x-pager-unlink'" : " class='x-pager-link'") + ">下页</a>" +
                "<a sn='last'" + (this.pageIndex() >= this.pageCount() ? " disabled='disabled' class='x-pager-unlink'" : " class='x-pager-link'") + ">尾页</a>" +
            "</div>";
        str = str.format(this.pageLowBound(), this.pageHighBound(), this.totalCount());
        var template = $(str);
        template.find("a[sn=first]").click(function () {
            var ctl = $(this).jart();
            ctl.pageFirst();
        });
        template.find("a[sn=prev]").click(function () {
            var ctl = $(this).jart();
            ctl.pageUp();
        });
        template.find("a[sn=next]").click(function () {
            var ctl = $(this).jart();
            ctl.pageDown();
        });
        template.find("a[sn=last]").click(function () {
            var ctl = $(this).jart();
            ctl.pageLast();
        });

        var nb = template.find("span[sn=number]");
        createNums.call(this, nb);

        return template;
    }
    /*#endregion*/

    //图片版模板
    /*#region*/
    /**
    * 创建每页记录数列表
    * @param template 模板
    */
    function createPageSizeList(template) {
        var pageSizes = this.pageList();
        if (!pageSizes) pageSizes = new Array(this.pageSize().toString());
        var str = '<select>';
        for (var i = 0; i < pageSizes.length; i++) {
            str += ('<option value="{0}" {1}>{0}</option>'.format(pageSizes[i], pageSizes[i] == this.pageSize() ? "selected" : ""));
        }
        str += '</select>';

        var pageSizeList = $(str);
        var placeholder = template.find("span[sn=pageSizeList]");
        placeholder.replaceWith(pageSizeList);
        pageSizeList.change(function () {
            var pageSize = $(this).val();
            var ctl = $(this).jart();
            ctl.pageSize(pageSize);
        });
    }

    /**
    * 创建翻页按钮
    * @param template 模板
    */
    function createPagerButtons(template) {
        var btnFirst = template.find("span[sn=btnFirst]");
        if (this.pageIndex() == 1) {
            btnFirst.addClass('x-pager-btn-disabled x-pager-btn-first');
        } else {
            btnFirst.addClass('x-pager-btn x-pager-btn-first');
            btnFirst.click(function () {
                var ctl = $(this).jart();
                ctl.pageFirst();
            });
        }

        var btnPrev = template.find("span[sn=btnPrev]");
        if (this.pageIndex() == 1) {
            btnPrev.addClass('x-pager-btn-disabled x-pager-btn-prev');
        } else {
            btnPrev.addClass('x-pager-btn x-pager-btn-prev');
            btnPrev.click(function () {
                var ctl = $(this).jart();
                ctl.pageUp();
            });
        }

        var btnNext = template.find("span[sn=btnNext]");
        if (this.pageIndex() >= this.pageCount()) {
            btnNext.addClass('x-pager-btn-disabled x-pager-btn-next');
        } else {
            btnNext.addClass('x-pager-btn x-pager-btn-next');
            btnNext.click(function () {
                var ctl = $(this).jart();
                ctl.pageDown();
            });
        }

        var btnLast = template.find("span[sn=btnLast]");
        if (this.pageIndex() >= this.pageCount()) {
            btnLast.addClass('x-pager-btn-disabled x-pager-btn-last');
        } else {
            btnLast.addClass('x-pager-btn x-pager-btn-last');
            btnLast.click(function () {
                var ctl = $(this).jart();
                ctl.pageLast();
            });
        }

        var btnLoad = template.find("span[sn=btnLoad]");
        btnLoad.addClass('x-pager-btn x-pager-btn-load');
        btnLoad.click(function () {
            var ctl = $(this).jart();
            ctl.onRefresh();
        });
    }

    /**
    * 创建页码输入框
    * @param template 模板
    */
    function createNumInput(template) {
        var str = '<input type="text" class="x-pager-num-input" value="{0}"/>';
        str = str.format(this.pageIndex(), this.pageCount());

        var numInput = $(str);
        var placeholder = template.find("span[sn=numInput]");
        placeholder.replaceWith(numInput);

        numInput.keyup(function () {
            if (event.keyCode == 13) {
                var ctl = $(this).jart();
                ctl.pageIndex($(this).val());
            }
        });
    }

    /**
    * 创建总页数信息
    * @param template 模板
    */
    function createPageCount(template) {
        var info = '共{0}页';
        info = info.format(this.pageCount());
        var pageCount = template.find('span[sn=pageCount]');
        pageCount.text(info);
    }

    /**
    * 创建状态信息
    * @param template 模板
    */
    function createPagerState(template) {
        var info = '显示{0}-{1}，共{2}条记录';
        info = info.format(this.pageLowBound(), this.pageHighBound(), this.totalCount());
        var pagerState = template.find("span[sn=pagerState]");
        pagerState.text(info);
    }

    /**
    * 图片按钮模板
    * @returns  图片按钮模板
    */
    function imgMode() {
        var str = '' +
		'<table style="float:left;" cellpadding="0" cellspacing="0">' +
		'	<tr>' +
		'		<td><span sn="pageSizeList"></span></td>' +
		'		<td><div class="x-pager-btn-separator"></div></td>' +
		'		<td><span sn="btnFirst"></span></td>' +
		'		<td><span sn="btnPrev"></span></td>' +
		'		<td><div class="x-pager-btn-separator"></div></td>' +
		'		<td><span>第</span></td>' +
		'		<td><span sn="numInput"></span></td>' +
		'		<td><span sn="pageCount"></span></td>' +
		'		<td><div class="x-pager-btn-separator"></div></td>' +
		'		<td><span sn="btnNext"></span></td>' +
		'		<td><span sn="btnLast"></span></td>' +
		'		<td><div class="x-pager-btn-separator"></div></td>' +
		'		<td><span sn="btnLoad"></span></td>' +
		'	</tr>' +
		'</table>' +
		'<div style="float:right;"><span sn="pagerState">显示1-0，共0条记录</span></div>';

        var template = $(str);

        createPageSizeList.call(this, template);
        createPagerButtons.call(this, template);
        createNumInput.call(this, template);
        createPageCount.call(this, template);
        createPagerState.call(this, template);

        return template;
    }
    /*#endregion*/

    ///翻页控件
    jart.pager = function (node, attrs) { };
    jart.pager.prototype.attrTypes = { pageSize: ["i"], pageIndex: ["i"], totalCount: ["i"], pageList: ["a"], onPageIndexChanged: ["f"], onPageSizeChanged: ["f"], onRefresh: ["f"] };
    Function.extend("jart.pager", jart.base, ["attrTypes"]);
    $.plugin("pager", "div");

    ///控件初始化
    jart.pager.prototype.mRenderStart = function (node) {
        node.attr("class", "x-pager").css("clear", "both");
        return node;
    };

    jart.pager.prototype.onDelay = function (params) {
        if (params.contains("refresh")) {
            this.refresh();
        }
    };

    ///页记录大小
    jart.pager.prototype.pageSize = function (size) {
        if (size === undefined) return this.node.data("pageSize") || 12;
        if (size < 1) throw new Error(jart_consts.error_parameter_invalid("{jart.pager}.pageSize", "size"));
        if (size != this.node.data("pageSize")) {
            this.node.data("pageSize", size);
            if (this.pageIndex() > this.pageCount()) this.pageIndex(this.pageCount() || 1);
            if (!this.first) this.onPageSizeChanged();
        }
        this.delay().active("refresh");
        return this;
    };

    /**
    * <summary group="property" name="{jart.pager}.pageList" type="Array">
    * 可供切换的页码集合
    * </summary>
    */
    jart.pager.prototype.pageList = function (arg) {
        if (arg === undefined) return this.node.data("pageList");
        this.node.data("pageList", arg);
        this.delay().active("refresh");
        return this;
    };

    ///当前页码，从1开始
    jart.pager.prototype.pageIndex = function (index) {
        if (index === undefined) return this.node.data("pageIndex") || 1;
        if (index < 1) throw new Error(jart_consts.error_parameter_invalid("{jart.pager}.pageIndex", "index"));
        if (index != this.pageIndex()) {
            this.node.data("pageIndex", index);
            if (!this.first) this.onPageIndexChanged();
        }
        this.delay().active("refresh");
        return this;
    };

    ///记录总数
    jart.pager.prototype.totalCount = function (count) {
        if (count === undefined) return this.node.data("totalCount") || 0;
        this.node.data("totalCount", count);
        if (this.pageIndex() > this.pageCount()) this.pageIndex(this.pageCount() || 1);
        this.delay().active("refresh");
        return this;
    };

    jart.pager.prototype.templater = function (templater) {
        if (templater === undefined) return this.node.data("templater") || imgMode;
        if (typeof (templater) == "string") templater = eval(templater);
        this.node.data("templater", templater);
        this.delay().active("refresh");
        return this;
    };

    ///当前记录页数
    jart.pager.prototype.pageCount = function () {
        return Math.ceil(this.totalCount() / this.pageSize());
    };

    ///当前页的最小序号，从1开始
    jart.pager.prototype.pageLowBound = function () {
        if (this.totalCount() == 0) return 0;
        return (this.pageIndex() - 1) * this.pageSize() + 1;
    };

    ///当前页的最大序号，从1开始
    jart.pager.prototype.pageHighBound = function () {
        if (this.totalCount() == 0) return 0;
        return Math.min(this.pageIndex() * this.pageSize(), this.totalCount());
    };

    ///向前一页
    jart.pager.prototype.pageUp = function () {
        if (this.pageIndex() == 1) return;
        this.pageIndex(this.pageIndex() - 1);
    };

    ///向后一页
    jart.pager.prototype.pageDown = function () {
        if (this.pageIndex() == this.pageCount()) return;
        this.pageIndex(this.pageIndex() + 1);
    };

    ///第一页
    jart.pager.prototype.pageFirst = function () {
        this.pageIndex(1);
    };

    ///最后一页
    jart.pager.prototype.pageLast = function () {
        this.pageIndex(this.pageCount());
    };

    ///刷新分页区
    jart.pager.prototype.refresh = function () {
        var fn = this.templater();
        if (typeof (fn) == "function") {
            this.node.empty().append(fn.call(this));
        }
    };

    ///当前页变化事件
    jart.pager.prototype.onPageIndexChanged = function () { };

    ///页大小变化事件
    jart.pager.prototype.onPageSizeChanged = function () { };

    ///刷新事件
    jart.pager.prototype.onRefresh = function () { };
    /*#endregion*/
})(jQuery, jart);

/*
* 树控件
*/
(function ($, jart) {
    function treeNode() {
        var iid = "tree_node_iid_" + $.uid();
        this.id = "tree_node_" + $.uid();
        this.text = "";
        this.unselectable = false;
        this.selected = false;
        this.checked = false;
        this.expanded = false;
        this.icon = "";
        this.iconUrl = "";
        this.url = "";
        this.target = "";
        this.onclick = function (node) { };
        this.tag = null;
        this.ajaxLoad = false;
        this.nodes = new treeNodes(iid);
        this.leaf = function () {
            return this.nodes.length < 1;
        };

        this.iid = function () {
            return iid;
        };
        this.findNodeByIId = function (id) {
            if (iid == id) return this;
            var node = null;
            for (var i = 0, len = this.nodes.length; i < len; i++) {
                node = this.nodes[i].findNodeByIId(id);
                if (node) break;
            }
            return node;
        };

        //获取html片断
        this.html = function (arg) {
            var level = arg.level;
            var check = arg.check;
            this.level = level;
            if (this.ajaxLoad) {
                this.expanded = false;
                this.nodes.clear().push(new treeNode());
            }

            var htm = "<div class='x-tree-node-wrap'>";
            {
                //添加当前节点内容
                var selectedClass = this.selected ? "x-tree-selected" : "";
                htm += "<div id='" + iid + "' nid='" + this.id + "' style='cursor:pointer;white-space:nowrap;vertical-align:middle;' class='x-tree-node' hover='x-tree-over'>";
                {
                    //添加左补白
                    htm += "<span sn='pad'>";
                    {
                        for (var i = 0; i < level; i++) {
                            htm += "<span class='x-tree-pad' style='display:inline-block;vertical-align:middle !important;vertical-align:baseline;'></span>";
                        }
                    }
                    htm += "</span>";

                    //添加展开关闭功能图标
                    var ctrlClass = this.leaf() ? "" : this.expanded ? " x-tree-expanded" : " x-tree-collapsed";
                    var ctrlHover = this.leaf() ? "" : this.expanded ? "x-tree-expanded-hover" : "x-tree-collapsed-hover";
                    htm += "<span sn='ctrl' style='display:inline-block;vertical-align:middle !important;vertical-align:baseline;' class='x-tree-pad" + ctrlClass + "' hover='" + ctrlHover + "'></span>";
                    //添加复选框图标
                    var checkDisplay = check ? "inline-block" : "none";
                    var checkStyle = this.checked ? " x-checkbox-checked" : "";
                    htm += "<span sn='check' style='display:" + checkDisplay + ";vertical-align:middle !important;vertical-align:baseline;' class='x-checkbox" + checkStyle + "'></span>";
                    //添加类型图标
                    var typeClass = this.leaf() ? " x-tree-leaf" : this.expanded ? " x-tree-folder-expanded" : " x-tree-folder", iconStyle = "";
                    if (this.iconUrl) {
                        iconStyle = "background-image:url(" + this.iconUrl + ")";
                    }
                    else if (this.icon) typeClass = " x-icon-" + this.icon;
                    htm += "<span sn='icon' style='display:inline-block;vertical-align:middle !important;vertical-align:baseline;" + iconStyle + "' class='x-tree-pad" + typeClass + "'></span>";
                    //添加文本
                    htm += "<span sn='text'>" + this.text + "</span>";
                }
                htm += "</div>";

                //添加子节点
                htm += "<div id='" + iid + "_container' level='" + (level + 1) + "' treenode_container='true'" + (this.expanded ? "" : " style='display:none;'") + ">";
                {
                    for (var i = 0, len = this.nodes.length; i < len; i++) {
                        htm += this.nodes[i].html({ level: level + 1, check: check });
                    }
                }
                htm += "</div>";
            }
            htm += "</div>";
            return htm;
        };

        this.set_nodes = function (nodes, fields) {
            if (nodes instanceof treeNodes) return nodes;
            var mynodes = new treeNodes(iid);
            for (var i = 0; i < nodes.length; i++) {
                var node = new treeNode();
                node.attr(nodes[i], fields);
                mynodes.push(node);
            }
            return mynodes;
        };

        this.onBeforeAttr = function (name, val) {
            if (name.lower() == "expanded") {
                if (val && this.ajaxLoad) {
                    var node = $("#" + iid);
                    node.jart().ajaxLoad(this);
                    return false;
                }
            }
        };

        //重载属性事件
        this.onAttr = function (name, val) {
            var node = $("#" + iid);
            if (node.length > 0) {
                var name = name.lower();
                if (name == "expanded") {
                    var ctrlClass = this.leaf() ? "" : val ? " x-tree-expanded" : " x-tree-collapsed";
                    var ctrlHover = this.leaf() ? "" : this.expanded ? "x-tree-expanded-hover" : "x-tree-collapsed-hover";
                    node.find("span[sn=ctrl]").attr("class", "x-tree-pad" + ctrlClass).attr("hover", ctrlHover);
                    if (!this.leaf()) {
                        var root = node.jart().node;
                        var container = root.children("div");
                        if (val) $("#" + iid + "_container").slideDown(function () {
                            //设置树节点宽为真实宽度
                            container[0].style.width = "";
                            if (root[0].scrollWidth > root.width()) root.children("div").width(root[0].scrollWidth);
                        });
                        else $("#" + iid + "_container").slideUp(function () {
                            //设置树节点宽为真实宽度
                            container[0].style.width = "";
                            if (root[0].scrollWidth > root.width()) root.children("div").width(root[0].scrollWidth);
                        });
                    }
                }
                else if (name == "selected") {
                    node.toggleClass("x-tree-selected", val);
                }
                else if (name == "text") {
                    node.find("span[sn=text]:first").html(val);
                }
                else if (name == "checked") {
                    node.find("span[sn=check]").removeClass("x-checkbox-half").toggleClass("x-checkbox-checked", val);
                }
                else if (name == "icon" || name == "iconurl") {
                    var typeClass = this.leaf() ? " x-tree-leaf" : this.expanded ? " x-tree-folder-expanded" : " x-tree-folder";
                    if (this.icon) typeClass = " x-icon-" + this.icon;
                    node.find("span[sn=icon]").attr("class", "x-tree-pad" + typeClass).toggleStyle("background-image", this.iconUrl, this.iconUrl);
                }
            }
        };
    }
    treeNode.attachRenderAttrAttribute({ unselectable: ["b"], selected: ["b"], checked: ["b"], expaned: ["b"], onclick: ["f", "", ["node"]], tag: ["o"], nodes: ["a"] });
    treeNode.prototype.findNodeById = function (id) {
        if (this.id == id) return this;
        var node = null;
        for (var i = 0, len = this.nodes.length; i < len; i++) {
            node = this.nodes[i].findNodeById(id);
            if (node) break;
        }
        return node;
    };
    treeNode.prototype.remove = function () {
        var node = $("#" + this.iid());
        if (node.length > 0) {
            var container = node.parent().parent();
            var ctl = container.jart();
            if (container.is("[treenode_container=true]")) {
                var iid = container.attr("id").rtrim("_container");
                var tn = findNodeByIId.call(ctl, iid);
                tn.nodes.remove(this);
            }
            else {
                ctl.nodes.remove(this);
            }

        }
    };

    /*
    * <summary group="method" name="treeNodes">
    * 树节点集合类
    * </summary>
    * <param name="pid">
    * 父节点，如果是树根，则为树的根元素，否则为父节点的元素id
    * </param>
    * <param name="root">
    * 是否是树根
    * </param>
    */
    function treeNodes(parent, root) {
        this.parent = parent;
        this.root = root;
    }
    treeNodes = Function.extend(treeNodes, jart.plugin.list);
    treeNodes.prototype.check = function (item) {
        return item instanceof treeNode;
    };
    treeNodes.prototype.onInsert = function (item, index) {
        var pnode = null, level = 0, checkable = false;
        if (this.root) {
            pnode = this.parent.children("div");
            checkable = this.parent.jart().checkable();
        }
        else {
            pnode = $("#" + this.parent + "_container");
            checkable = pnode.jart().checkable();
            level = parseInt(pnode.attribute("level"));
        }
        var items = pnode.children("div.x-tree-node-wrap");
        if (index == this.length - 1) {
            pnode.append(item.html({ level: level, check: checkable }));
        }
        else {
            $(items[index]).before(item.html({ level: level, check: checkable }));
        }
        if (!this.root && this.length == 1) {
            var node = $("#" + this.parent);
            node.find("span[sn=ctrl]").attr("class", "x-tree-pad x-tree-collapsed");
            node.find("span[sn=icon]").attr("class", "x-tree-pad x-tree-folder");
        }
    };
    treeNodes.prototype.onRemove = function (item, index) {
        $("#" + item.iid()).parent().remove();
        if (!this.root && this.length == 0) {
            var node = $("#" + this.parent);
            node.find("span[sn=ctrl]").attr("class", "x-tree-pad");
            node.find("span[sn=icon]").attr("class", "x-tree-pad x-tree-leaf");
        }
    };
    treeNodes.prototype.onClear = function () {
        if (this.root) {
            this.parent.children("div").empty();
        }
        else {
            var node = $("#" + this.parent);
            var container = $("#" + this.parent + "_container");
            container.empty();
            var tn = findNodeByIId.call(node.jart(), this.parent);
            node.find("span[sn=ctrl]").attr("class", "x-tree-pad");
            node.find("span[sn=icon]").attr("class", "x-tree-pad x-tree-leaf");
            tn.expanded = false;
        }
    };

    function findNodeByIId(id) {
        var node = null;
        for (var i = 0, len = this.nodes.length; i < len; i++) {
            node = this.nodes[i].findNodeByIId(id);
            if (node) break;
        }
        return node;
    }

    function selectNode(tn, node) {
        if (tn.unselectable) return;
        if (this.folderUnSelectable() && !tn.leaf()) return;
        var multiple = this.multiple();
        if (multiple) {
            if (tn.attr("selected")) {
                tn.attr("selected", false);
                this.onSelect(tn, null, false);
            }
            else {
                if (this.node.find("div.x-tree-selected").length < multiple) {
                    tn.attr("selected", true);
                    this.onSelect(tn, node, true);
                }
            }
        }
        else {
            var selectedid = this.node.find("div.x-tree-selected").attr("id");
            if (selectedid != tn.iid()) {
                if (selectedid) findNodeByIId.call(this, selectedid).attr("selected", false);
                tn.attr("selected", true);
                this.onSelect(tn, node, true);
            }
        }
    }

    function checkSubNode(tn, checked) {
        for (var i = 0, len = tn.nodes.length; i < len; i++) {
            tn.nodes[i].attr("checked", checked);
            checkSubNode(tn.nodes[i], checked);
        }
    }

    function checkNode(tn, checked) {
        if (checked === undefined) checked = !tn.attr("checked");
        tn.attr("checked", checked);
        if (this.checkMode() == "three") {
            var container = $("#" + tn.iid() + "_container"), jq;
            checkSubNode(tn, checked);
            var ctl = this;
            container.parent().parents("div.x-tree-node-wrap").each(function () {
                jq = $(this);
                var checks = jq.children("div[treenode_container=true]").find("span[sn=check]");
                jq = jq.children("div.x-tree-node");
                var checkObj = jq.find("span[sn=check]");
                var checked = checkObj.is(".x-checkbox-checked");
                if (checks.filter(".x-checkbox-checked").length == 0) {
                    if (checked) {
                        var tn = findNodeByIId.call(ctl, jq.attr("id"));
                        tn.attr("checked", false);
                    }
                    else checkObj.removeClass("x-checkbox-half");
                }
                else if (checks.filter(".x-checkbox-checked").length == checks.length) {
                    if (checked) checkObj.removeClass("x-checkbox-half");
                    else {
                        var tn = findNodeByIId.call(ctl, jq.attr("id"));
                        tn.attr("checked", true);
                    }
                }
                else {
                    if (checked) {
                        var tn = findNodeByIId.call(ctl, jq.attr("id"));
                        tn.attr("checked", false);
                    }
                    checkObj.addClass("x-checkbox-half");
                }
            });
        }
    }

    function getNodesFromLabel(pnode) {
        var tns = [], tn, children = pnode.children("div");
        for (var i = 0; i < children.length; i++) {
            var node = $(children[i]);
            tn = node.myattrs();
            tn.nodes = getNodesFromLabel(node);
            tns.push(tn);
        }
        return tns;
    }

    ///树控件
    jart.tree = function (node, attrs) {
        this.loadData();
    };
    jart.tree.prototype.attrTypes = { mode: ["e", "", ["none", "arrow"]], checkable: ["b"], checkMode: ["e", "", ["two", "three"]], fastExpand: ["b"], folderUnSelectable: ["b"], dataFields: ["o"], dataSource: ["a"], ajaxLoad: ["f", "", ["node"]], onAjaxLoad: ["f", "", ["node", "data"]], onNodeClick: ["f", "", ["tn", "node"]], onSelect: ["f", "", ["tn", "node", "selected"]] };
    Function.extend("jart.tree", jart.base, ["attrTypes"]);
    Function.extend("jart.tree", jart.plugin.dataLoader, ["attrTypes"]);
    $.plugin("tree", "div");

    ///控件初始化
    jart.tree.prototype.mRenderStart = function (node, attrs) {
        //树节点集合
        this.nodes = new treeNodes(node, true);

        //从标签加载数据源
        attrs.dataSource = getNodesFromLabel(this.node);

        node.addClass("x-tree").css("overflow", "auto").append("<div></div>");
        node.binds("span[sn=ctrl]", "click", null, function (e) {
            var ctl = $(this).jart();
            var jq = e.targets;
            var tn = findNodeByIId.call(ctl, jq.parent().attr("id"));
            tn.attr("expanded", !tn.attr("expanded"));
        });
        node.binds("div.x-tree-node", "click", null, function (e) {
            if ($(e.target).is("[sn=ctrl],[sn=check]")) return;
            var ctl = $(this).jart();
            var jq = e.targets;
            var tn = findNodeByIId.call(ctl, jq.attr("id"));
            if (ctl.fastExpand()) tn.attr("expanded", !tn.attr("expanded"));
            if (tn.onclick && tn.onclick(jq) == false) return;
            if (ctl.onNodeClick && ctl.onNodeClick(tn, jq) == false) return;
            selectNode.call(ctl, tn, jq);
            if (tn.url) $.redirect(tn.url, tn.target);
        });
        node.binds("span[sn=check]", "click", null, function (e) {
            var ctl = $(this).jart();
            var tn = findNodeByIId.call(ctl, e.targets.parent().attr("id"));
            checkNode.call(ctl, tn);
        });
        return node;
    };
    jart.tree.prototype.onLoadData = function (data) {
        this.bind(data);
    };
    jart.tree.prototype.blocker = function () {
        return this.node;
    };
    jart.tree.prototype.blockable = false;

    ///树的模式，有普通、箭头型
    jart.tree.prototype.mode = function (mode) {
        if (mode === undefined) return this.node.data("mode") || "none";
        var omode = this.node.data("mode");
        this.node.data("mode", mode);
        if (mode == "none") this.node.removeClass("x-tree-" + omode);
        else this.node.addClass("x-tree-" + mode);
        return this;
    };

    ///是否可以复选
    jart.tree.prototype.checkable = function (arg) {
        if (arg === undefined) return this.node.data("checkable");
        this.node.data("checkable", arg);
        return this;
    };

    jart.tree.prototype.checkMode = function (arg) {
        if (arg === undefined) return this.node.data("checkMode") || "two";
        this.node.data("checkMode", arg);
        return this;
    };

    ///树支持多选的个数，如果为0，则此树为单选树，否则为多选树，多选个数限制为此属性的值
    jart.tree.prototype.multiple = function (multi) {
        if (multi === undefined) return this.node.data("multiple") || 0;
        if (multi && multi < 0) throw new Error(jart_consts.error_parameter_invalid("{jart.tree}.multiple", "multi"));
        this.node.data("multiple", multi);
        return this;
    };

    ///是否单击鼠标展开或收缩节点
    jart.tree.prototype.fastExpand = function (arg) {
        if (arg === undefined) return this.node.data("fastExpand") || false;
        this.node.data("fastExpand", arg);
        return this;
    };

    ///目录是否不可选中
    jart.tree.prototype.folderUnSelectable = function (arg) {
        if (arg === undefined) return this.node.data("folderUnSelectable") || false;
        this.node.data("folderUnSelectable", arg);
        return this;
    };

    //数据绑定域映射，treeNode的每个属性将映射到数据项的一个属性上，如果对应的映射名为空则属性名与treeNode属性名相同
    jart.tree.prototype.dataFields = null;

    jart.tree.prototype.dataSource = function (data) {
        if (data === undefined) return this.node.data("dataSource");
        this.node.data("dataSource", data);
        this.nodes.clear();
        if (data) {
            for (var i = 0, len = data.length; i < len; i++) {
                this.nodes.push(this.newNode(data[i]));
            }
        }
        this.update();
        return this;
    };

    jart.tree.prototype.update = function (node) {
        var content = "", i, len;
        if (node) {
            var level = node.level + 1;
            var container = $("#" + node.iid() + "_container");
            container.empty();
            for (i = 0, len = node.nodes.length; i < len; i++) {
                content += node.nodes[i].html({ level: level, check: this.checkable() });
            }
            container[0].innerHTML = content;
            if (this.checkMode() == "three") {
                checkNode.call(this, node, node.checked);
            }
        }
        else {
            var container = this.node.children("div").empty();
            for (i = 0, len = this.nodes.length; i < len; i++) {
                content += this.nodes[i].html({ level: 0, check: this.checkable() });
            }
            container[0].innerHTML = content;
        }
        return this;
    };

    ///创建一个新的树节点
    jart.tree.prototype.newNode = function (data) {
        var node = new treeNode();
        node.attr(data, this.dataFields);
        return node;
    };

    ///绑定数据到树上
    jart.tree.prototype.bind = function (data, node) {
        if (node) {
            node.nodes.clear(true);
            if (data && data.length > 0) {
                for (var i = 0, len = data.length; i < len; i++) {
                    node.nodes.push(this.newNode(data[i]));
                }
            }
            this.update(node);
        }
        else this.dataSource(data);
        return this;
    };

    jart.tree.prototype.findNodeById = function (id) {
        var node = null;
        for (var i = 0, len = this.nodes.length; i < len; i++) {
            node = this.nodes[i].findNodeById(id);
            if (node) break;
        }
        return node;
    };

    ///获取所有选中的节点
    function selectedSubNodes(pnode) {
        var nodes = new Array();
        for (var i = 0; i < pnode.nodes.length; i++) {
            if (pnode.nodes[i].selected) nodes.push(pnode.nodes[i]);
            nodes = nodes.concat(selectedSubNodes(pnode.nodes[i]));
        }
        return nodes;
    }

    jart.tree.prototype.selectedNodes = function () {
        return selectedSubNodes(this);
    };

    jart.tree.prototype.getCheckedNodeIds = function (half, leaf) {
        var ids = "", jq;
        this.node.find("div.x-tree-node").each(function () {
            jq = $(this);
            if (jq.find("span[sn=check]").is(".x-checkbox-checked")) {
                if (!leaf || jq.next().children("div").length == 0) ids += "," + jq.attr("nid");
            }
            else if (half && jq.find("span[sn=check]").is(".x-checkbox-half")) {
                if (!leaf || jq.next().children("div").length == 0) ids += "," + jq.attr("nid");
            }
        });
        return ids.substr(1);
    };
    jart.tree.prototype.ajaxLoadUrl = "";
    jart.tree.prototype.ajaxLoad = function (tn) {
        if (!this.ajaxLoadUrl) {
            tn.nodes.clear(true);
            return;
        }
        tn.attr("icon", "loading");
        var ctl = this;
        $.ajax({
            type: this.method,
            url: this.ajaxLoadUrl,
            data: { id: tn.id },
            success: function (data) {
                if (typeof (data) == "string") data = eval("(" + data + ")");
                tn.nodes.clear();
                ctl.onAjaxLoad(tn, data);
                tn.ajaxLoad = false;
                tn.attr({ expanded: true, icon: "" });
            },
            error: function (a, b, c) {
                if (a) {
                    if (a.status == 200 && b == "parsererror") {
                        var data = a.responseText;
                        data = eval("(" + data + ")");
                        tn.nodes.clear();
                        ctl.onAjaxLoad(tn, data);
                        tn.ajaxLoad = false;
                        tn.attr("expanded", true);
                    }
                    tn.attr("icon", "");
                }
            }
        });
    };
    jart.tree.prototype.onAjaxLoad = function (node, data) {
        this.bind(data, node);
    };

    jart.tree.prototype.onNodeClick = function (tn, node) { };
    jart.tree.prototype.onSelect = function (tn, node, selected) { };
})(jQuery, jart);

/*
* 表格控件
*/
(function ($, jart) {
    //工具方法定义
    {
        ///获取单行列的字段整体属性
        function getSingleColumns(columns) {
            //如果列集合为空，则返回空
            if (!columns) return null;
            var fields = new Array();

            //构造完全列集合
            var arr = new Array();
            //拆开列
            for (var i = 0; i < columns.length; i++) {
                arr.push(new Array());
                for (var j = 0; j < columns[i].length; j++) {
                    arr[i].push(columns[i][j]);
                    for (var k = 1; k < (columns[i][j].colspan || 1); k++) arr[i].push(null);
                }
            }
            //拆开行
            for (var i = 0; i < arr[0].length; i++) {
                for (var j = 0; j < arr.length; j++) {
                    if (arr[j][i]) {
                        for (var k = 1; k < (arr[j][i].rowspan || 1); k++) {
                            for (var h = 0; h < (arr[j][i].colspan || 1); h++) arr[j + k].insert(null, i);
                        }
                    }
                }
            }

            //从完整列集合中整合出单行
            for (var i = 0; i < arr.length; i++) {
                for (var j = 0; j < arr[i].length; j++) {
                    var cell = arr[i][j];
                    if (cell && (!cell.colspan || cell.colspan == 1)) {
                        fields[j] = {};
                        if (cell.type != undefined) fields[j].type = cell.type;
                        if (cell.field != undefined) fields[j].field = cell.field;
                        if (cell.formatter != undefined) fields[j].formatter = cell.formatter;
                        if (cell.width != undefined) fields[j].width = cell.width;
                        if (cell.nowrap != undefined) fields[j].nowrap = cell.nowrap;
                        if (cell.align != undefined) fields[j].align = cell.align;
                        if (cell.styler != undefined) fields[j].styler = cell.styler;
                    }
                }
            }
            return fields;
        }

        ///列表头模板，{0：行跨度}｜{1：列跨度}｜{2：样式}｜{3：标题}｜{4：列头的对齐}｜{5：是否显示排序图标}｜{6：是否支持拖动改变列大小}
        var templateTableHead = "<th nowrap='true' class='x-grid-head-th' align='left' rowspan='{0}' colspan='{1}'columnindex='{7}'><div style='position:relative;'>" +
        "<div align='{4}' style='vertical-align:middle;{2}' class='x-grid-head-th-div' sortable='{5}'>{3}<span gsnsp='sorticon' style='display:none;overflow:hidden;vertical-align:middle;_height:100%;' class='x-grid-sort-asc' _display='inline-block'></span></div>" +
        "<span gsn='resizesp' style='position:absolute;right:0px;top:0px;bottom:0px;width:5px;_height:100%;cursor:col-resize;display:{6};' _display='inline-block'></span>" +
    "</div></th>";

        ///渲染冻结列头
        function renderFixedColumns() {
            var columns = this.frozenColumns();
            var fields = getSingleColumns(columns);
            var str = "";
            var str2 = "";
            if (!columns || columns.length <= 0) {
                //当冻结列为空时只加载序号列和选择列
                if ((this.rowNumbers() || this.showCheckBox() || this.showRadio()) && this.columns()) {
                    str += "<tr style='" + ($.browser.ie6 || $.browser.ie7 ? "position: absolute;" : "") + "visibility:hidden;height:0px;border:none;'>";
                    str2 = str;
                    if (this.rowNumbers()) {
                        str += "<th gsn='rownumbers' style='width:25px;height:0px;border:none 0px;'></th>";
                        str2 += "<th gsn='rownumbers' style='width:25px;height:0px;border:none 0px;'></th>";
                    }
                    if (this.showCheckBox()) {
                        str += "<th style='width:25px;height:0px;border:none;'></th>";
                        str2 += "<th  style='width:25px;height:0px;border:none;'></th>";
                    }
                    if (this.showRadio()) {
                        str += "<th style='width:25px;height:0px;border:none;'></th>";
                        str2 += "<th  style='width:25px;height:0px;border:none;'></th>";
                    }
                    str += "<th style='width:0px;height:0px;border:none 0px;padding:0px;'></th></tr>";
                    str2 += "<th style='width:0px;height:0px;border:none 0px;padding:0px;'></th></tr>";

                    var rowspan = this.columns().length;
                    for (var i = 0; i < rowspan; i++) {
                        str += "<tr class='x-grid-head'>";
                        if (i == 0) {
                            if (this.rowNumbers()) str += "<th rowspan='" + rowspan + "' class='x-grid-head-th'><div>&nbsp;</div></th>";
                            if (this.showCheckBox()) str += "<th rowspan='" + rowspan + "' class='x-grid-head-th'><div><input type='checkbox' gsn='checkall' /></div></th>";
                            if (this.showRadio()) str += "<th rowspan='" + rowspan + "' class='x-grid-head-th'>&nbsp;</div></th>";
                        }
                        str += "<th class='x-grid-head-th' style='border-top:none 0px;border-bottom:none 0px;padding:0px;'></th>";
                        str += "</tr>";
                    }
                }
            }
            else {
                //加载序号列和冻结列
                var rowspan = columns.length;
                str += "<tr style='" + ($.browser.ie6 || $.browser.ie7 ? "position: absolute;" : "") + "visibility:hidden;height:0px;border:none;'>";
                str2 += "<tr style='" + ($.browser.ie6 || $.browser.ie7 ? "position: absolute;" : "") + "visibility:hidden;height:0px;border:none;'>";
                if (this.rowNumbers()) {
                    str += "<th gsn='rownumbers' style='width:25px;height:0px;border:none 0px;'></th>";
                    str2 += "<th gsn='rownumbers' style='width:25px;height:0px;border:none 0px;'></th>";
                }
                if (this.showCheckBox()) {
                    str += "<th style='width:25px;height:0px;border:none;'></th>";
                    str2 += "<th  style='width:25px;height:0px;border:none;'></th>";
                }
                if (this.showRadio()) {
                    str += "<th style='width:25px;height:0px;border:none;'></th>";
                    str2 += "<th  style='width:25px;height:0px;border:none;'></th>";
                }
                for (var i = 0; i < fields.length; i++) {
                    var uid = "th_dfasd3_" + $.uid();
                    var width = fields[i].width || "100px";
                    str2 += "<th style='width:" + width + ";height:0px;border:none 0px;' gsn='" + uid + "'></th>";
                    str += "<th style='width:" + width + ";height:0px;border:none 0px;' gsn='" + uid + "'></th>";
                }
                str2 += "<th style='width:0px;height:0px;border:none 0px;padding:0px;'></th></tr>";
                str += "<th style='width:0px;height:0px;border:none 0px;padding:0px;'></th></tr>";

                //加载列头内容
                for (var i = 0; i < columns.length; i++) {
                    str += "<tr>";
                    //第一行添加行号列和选择列
                    if (i == 0) {
                        var rowspan = columns.length;
                        if (this.rowNumbers()) str += "<th rowspan='" + rowspan + "' class='x-grid-head-th'><div>&nbsp;<div></th>";
                        if (this.showCheckBox()) str += "<th rowspan='" + rowspan + "' class='x-grid-head-th'><div><input type='checkbox' gsn='checkall' /></div></th>";
                        if (this.showRadio()) str += "<th rowspan='" + rowspan + "' class='x-grid-head-th'>&nbsp;</div></th>";

                    }

                    //渲染列头
                    for (var j = 0; j < columns[i].length; j++) {
                        var cell = columns[i][j];
                        str += templateTableHead.format(cell.rowspan || 1, cell.colspan || 1, this.sortMode() != "disabled" && (cell.sortfield || cell.sorter) ? "cursor:pointer" : "", cell.title || "&nbsp;", cell.headAlign || "center", this.sortMode() != "disabled" && (cell.sortfield || cell.sorter) ? "true" : "false", cell.resizable ? "inline-block" : "none", "frozenColumns," + i + "," + j);
                    }
                    str += "<th class='x-grid-head-th' style='border-top:none 0px;border-bottom:none 0px;padding:0px;'></th>";
                    str += "</tr>";
                }
            }
            //加入表头
            var head = this.node.find("table[gsn=lhead]:first").empty().append(str);
            this.node.find("table[gsn=llist]:first").children("tbody:first").empty().append(str2);
            setTimeout(function () { head.parent().width(head.outerWidth(true)); }, 0);
        };

        ///渲染列
        function renderColumns() {
            var columns = this.columns();
            var fields = getSingleColumns(columns);
            var str = "";
            var str2 = "";
            var hasauto = false;
            if (columns) {
                //分配列宽
                str += "<tr style='" + ($.browser.ie6 || $.browser.ie7 ? "position: absolute;" : "") + "visibility:hidden;height:0px;border:none;'>";
                str2 += "<tr style='" + ($.browser.ie6 || $.browser.ie7 ? "position: absolute;" : "") + "visibility:hidden;height:0px;border:none;'>";
                for (var i = 0; i < fields.length; i++) {
                    var uid = "th_dfasd3_" + $.uid();
                    if (fields[i].width) {
                        str2 += "<th style='width:" + fields[i].width + ";height:0px;border-top:none;border-bottom:none;' gsn='" + uid + "'></th>";
                        str += "<th style='width:" + fields[i].width + ";height:0px;border-top:none;border-bottom:none;' gsn='" + uid + "'></th>";
                    }
                    else {
                        hasauto = true;
                        str2 += "<th style='height:0px;border-top:none;border-bottom:none;' gsn='" + uid + "'></th>";
                        str += "<th style='height:0px;border-top:none;border-bottom:none;' gsn='" + uid + "'></th>";
                    }
                }
                str2 += "<th style='width:0px;height:0px;border:none 0px;padding:0px;'></th></tr>";
                str += "<th gsn='hadjust' style='width:0px;height:0px;border:none 0px;padding:0px;'></th></tr>";

                //加载列头内容
                for (var i = 0; i < columns.length; i++) {
                    str += "<tr>";
                    for (var j = 0; j < columns[i].length; j++) {
                        var cell = columns[i][j];
                        str += templateTableHead.format(cell.rowspan || 1, cell.colspan || 1, this.sortMode() != "disabled" && (cell.sortfield || cell.sorter) ? "cursor:pointer" : "", cell.title || "&nbsp;", cell.headAlign || "center", this.sortMode() != "disabled" && (cell.sortfield || cell.sorter) ? "true" : "false", cell.resizable ? "inline-block" : "none", "columns," + i + "," + j);
                    }
                    if (i == 0) str += "<th class='x-grid-head-th' rowspan='" + columns.length + "'></th>";
                    str += "</tr>";
                }
            }
            this.node.find("table[gsn=head]").empty().append(str);
            this.node.find("table[gsn=list]").children("tbody:first").empty().append(str2);
            if (!hasauto) this.node.find("table[gsn=head],table[gsn=list]").css("width", "1px");
        };

        //调整行高方法
        function onGridTableResized(node, gsn) {
            if (gsn === undefined) {
                var llist = node.find("table[gsn=llist]"), list = node.find("table[gsn=list]");
                if (llist.unresizable() && list.unresizable()) return;
                llist.unresizable(true);
                list.unresizable(true);
                node.find("td[gsnt=adjust_td]").css("height", "auto");
                list.find("td[gsnt=adjust_td]").each(function () {
                    onGridTableResized(node, $(this).attribute("gsn"));
                });

                var p = list.parent();
                if (list.width() < p[0].clientWidth) {
                    p.parents("tr:first").prev().find('th[gsn=hadjust]').width(p.width() - list.width());
                }
                else if (p.width() > p[0].clientWidth) {
                    p.parents("tr:first").prev().find('th[gsn=hadjust]').width($.browser.sbwx);
                }
                else {
                    p.parents("tr:first").prev().find('th[gsn=hadjust]').css("width", "0px");
                }
                //                if (p.width() > p[0].clientWidth) {
                //                    node.find("div[gsn=lwrap]").children("div:last").showx(true);
                //                }

                setTimeout(function () {
                    llist.unresizable(false);
                    list.unresizable(false);
                }, 0);

                //让冻结列和非冻列并齐
                var lwrap = node.find("div[gsn=lwrap]");
                var wrap = node.find("div[gsn=wrap]");
                if (lwrap[0].scrollTop < wrap[0].scrollTop) wrap[0].scrollTop = lwrap[0].scrollTop;
                else if (lwrap[0].scrollTop > wrap[0].scrollTop) lwrap[0].scrollTop = wrap[0].scrollTop;
                return;
            }
            var height = null;
            var change = false;
            var tds = node.find("td[gsn=" + gsn + "]");
            tds.each(function () {
                var h = this.offsetHeight;
                if (height === null) {
                    height = h;
                }
                else {
                    if (height != h) {
                        change = true;
                        if (height < h) {
                            height = h;
                        }
                    }
                }
            });
            if (change) tds.css("height", height + "px");
        };
    }

    //表格相关类
    {
        /*
        * <summary group="method" name="gridCell">
        * 表格单元格类
        * </summary>
        */
        function gridCell() {
            //内部对行的唯一标识
            var iid = "grid_row_iid_" + $.uid();
            //获取行的唯一标识
            this.iid = function () { return iid; };
            /**
            * <summary group="property" name="{gridCell}.text" type="String">
            * 单元格内容
            * </summary>
            */
            this.content = "";
            //跨列数
            this.colspan = 1;
            //跨行数
            this.rowspan = 1;
            //对齐，left：左对齐｜center：居中对齐｜right：右对齐
            this.align = "left";
            //不允许换行，且文本长度超过显示范围时自动截断
            this.nowrap = false;
            //单元格样式
            this.style = "";

            this.html = function (arg) {
                var nowrapStyle = "";
                if (this.nowrap) nowrapStyle = " style='white-space:nowrap;text-overflow:ellipsis;-o-text-overflow:ellipsis;overflow: hidden;' tooltip='" + this.content + "'";
                var htm = "<td rowspan='{0}' colspan='{1}' align='{2}' class='x-grid-list-td' style='{5}'><div{3}>{4}</div></td>".format(this.rowspan, this.colspan, this.align, nowrapStyle, this.content, this.style || "");
                return htm;
            };
        }
        gridCell.attachRenderAttrAttribute({ colspan: ["i"], rowspan: ["i"], align: ["e", "", ["left", "center", "right"]], nowrap: ["b"] });

        /*
        * <summary group="method" name="gridRow">
        * 表格行类
        * </summary>
        */
        function gridRow() {
            //内部对行的唯一标识
            var iid = "grid_row_iid_" + $.uid();
            //获取行的唯一标识
            this.iid = function () { return iid; };
            //外部标识，由用户定义，用来标识此行,用户可根据此关键字获取此行
            this.id = "grid_row_" + $.uid();
            //行关联的数据
            this.data = null;
            //行的序号
            this.index = 0;
            //此行的冻结列内容
            this.frozenColumns = new Array();
            //此行的普通列内容
            this.columns = new Array();

            this.frozenHtml = function (arg) {
                var cls = arg.striped && arg.index % 2 == 1 ? " x-grid-list-row-even" : "";
                var htm = "<tbody gsn='gridrow' id='" + iid + "_fl' gsnid='" + iid + "' nid='" + this.id + "' class='x-grid-list-row" + cls + "' hover='x-grid-list-row-hover' hoverselector=\"tbody[gsnid=" + iid + "]\">";
                var i, j, len1, len2;
                for (i = 0, len1 = this.frozenColumns.length; i < len1; i++) {
                    htm += "<tr>";
                    for (j = 0, len2 = this.frozenColumns[i].length; j < len2; j++) {
                        htm += this.frozenColumns[i][j].html({ gridline: arg.gridline, rowline: arg.rowline ? 0 : (i == len1 - 1 ? 1 : 2) });
                    }
                    htm += "<td gsnt='adjust_td' gsn='" + iid + "_" + i + "' style='border:none 0px;padding:0px;'>&nbsp;</td></tr>";
                }
                htm += "</tbody>";
                return htm;
            };

            this.html = function (arg) {
                var cls = arg.striped && arg.index % 2 == 1 ? " x-grid-list-row-even" : "";
                var htm = "<tbody gsn='gridrow' id='" + iid + "' gsnid='" + iid + "' nid='" + this.id + "' class='x-grid-list-row" + cls + "' hover='x-grid-list-row-hover' hoverselector=\"tbody[gsnid=" + iid + "]\">";
                var i, j, len1, len2;
                for (i = 0, len1 = this.columns.length; i < len1; i++) {
                    htm += "<tr>";
                    for (j = 0, len2 = this.columns[i].length; j < len2; j++) {
                        htm += this.columns[i][j].html({ gridline: arg.gridline, rowline: arg.rowline ? 0 : (i == len1 - 1 ? 1 : 2) });
                    }
                    htm += "<td gsnt='adjust_td' gsn='" + iid + "_" + i + "' style='border:none 0px;padding:0px;'></td></tr>";
                }
                htm += "</tbody>";
                return htm;
            };

            this.select = function () {
                var node = $("#" + iid);
                if (!node) node = $("#" + iid + "_fl");
                if (node) {
                    var ctl = node.jart();
                    if (ctl.selectMode() == "single") {
                        var row = ctl.node.find("tbody[gsn=gridrow]").removeClass("x-grid-list-row-selected").filter("[gsnid=" + iid + "]").addClass("x-grid-list-row-selected");
                        if (typeof (ctl.onSelect) == "function") ctl.onSelect(this);
                    }
                    else if (ctl.selectMode() == "multiple") {
                        var row = ctl.node.find("tbody[gsnid=" + iid + "]").toggleClass("x-grid-list-row-selected");
                        if (typeof (ctl.onSelect) == "function") ctl.onSelect(this, row.is(".x-grid-list-row-selected"));
                    }
                }
            };
        }

        function gridRows(grid) {
            this.grid = grid;
        }
        gridRows = Function.extend(gridRows, jart.plugin.list);
        gridRows.prototype.check = function (item) {
            return item instanceof gridRow;
        };
        gridRows.prototype.onInsert = function (item, index) {
        };
        gridRows.prototype.onRemove = function (item, index) {
        };
    }

    //列表控件
    jart.grid = function (node, attrs) {
        this.loadData();
    };
    jart.grid.prototype.attrTypes = { frozenColumns: ["a"], columns: ["a"], dataSource: ["a"], multiple: ["b"], rowNumbers: ["b"], striped: ["b"], gridline: ["e", "", ["all", "horizontal", "vertical", "none"]], rowline: ["b"], showCheckBox: ["b"], showRadio: ["b"], selectMode: ["e", "", ["disabled", "single", "multiple"]], rememberChecked: ["b"], pageMode: ["e", "", ["disabled", "local", "remote"]], pageSize: ["i"], pageList: ["a"], pageIndex: ["i"], totalCount: ["i"], sortMode: ["e", "", ["disabled", "local", "remote"]], sortOrder: ["e", "", ["asc", "desc"]], onSelect: ["f", "", ["row", "selected"]] };
    Function.extend("jart.grid", jart.base, ["attrTypes"]);
    Function.extend("jart.grid", jart.plugin.dataLoader, ["attrTypes"]);
    $.plugin("grid", "div");

    /**
    * <summary group="event" name="{jart.grid}.onDelay">
    * 延迟执行事件
    * </summary>
    * <param name="params">
    * 执行参数数组
    * </param>
    */
    jart.grid.prototype.onDelay = function (params) {
        if (params.contains("title")) {
            renderFixedColumns.call(this);
            renderColumns.call(this);
        }
        if (params.contains("list")) {
            this.update();
        }
        if (params.contains("list") || params.contains("gridline")) {
            var nodes = this.node.find("td.x-grid-list-td");
            if (this.gridline() == "none") {
                nodes.addStyle("border-right", "none 0px").addStyle("border-bottom", "none 0px");
            }
            else if (this.gridline() == "vertical") {
                nodes.addStyle("border-bottom", "none 0px").removeStyle("border-right");
                if (!this.rowline()) nodes.addStyle("border-right", "none 0px");
            }
            else if (this.gridline() == "horizontal") {
                nodes.addStyle("border-right", "none 0px").removeStyle("border-bottom");
                if (!this.rowline()) nodes.filter(function () {
                    var tr = $(this).parent();
                    var tbdoy = tr.parent();
                    var trs = tbdoy.children("tr");
                    var length = trs.length;
                    var index = trs.index(tr) + ($(this).attr("rowspan") || 1);
                    return index < length;
                }).addStyle("border-bottom", "none 0px");
            }
            else {
                nodes.removeStyle("border-right").removeStyle("border-bottom");
                if (!this.rowline()) {
                    nodes.addStyle("border-right", "none 0px");
                    nodes.filter(function () {
                        var tr = $(this).parent();
                        var tbdoy = tr.parent();
                        var trs = tbdoy.children("tr");
                        var length = trs.length;
                        var index = trs.index(tr) + (parseInt($(this).attr("rowspan")) || 1);
                        return index < length;
                    }).addStyle("border-bottom", "none 0px");
                }
            }
        }
    };
    //数据绑定相关属性和方法
    {
        //标识域
        jart.grid.prototype.idFields = "";

        ///冻结列集合，冻结列如果宽度不设置，则默认为100px，列属性与普通列属性相同
        jart.grid.prototype.frozenColumns = function (cols) {
            if (cols === undefined) return this.node.data("frozenColumns");
            this.node.data("frozenColumns", cols);
            this.delay().active("title");
            return this;
        };

        ///列集合，列属性有如下：title：列标题｜type：列类型（radio,check或空）｜field：列表数据绑定域｜nowrap：文本长度超过自动截断｜width：列宽｜resizable：可拖动改变宽度，当列宽未设置时此属性无效｜colspan：列跨度｜rowspan：行跨度｜align：对齐方式｜headAlign：列头对齐方式，默认居中｜formatter(rowData,index)：列内容格式化方法｜styler(rowData,index)：列样式格式化方法｜sortfield：排序域｜sorter(rowData1,rowData2)：排序规则方法，此优先级高于sortfield，但列表为服务端排序时，此方法无效
        jart.grid.prototype.columns = function (cols) {
            if (cols === undefined) return this.node.data("columns");
            this.node.data("columns", cols);
            this.delay().active("title");
            return this;
        };

        /**
        * <summary group="property" name="{jart.grid}.dataSource" type="Array">
        * 导航的数据源
        * </summary>
        */
        jart.grid.prototype.dataSource = function (data) {
            if (data === undefined) return this.node.data("dataSource");
            this.node.data("dataSource", data);
            if (!this.rememberChecked) this.checkedRowIds = "";
            this.delay().active("list");
            return this;
        };

        /**
        * <summary group="method" name="{jart.grid}.update">
        * 当数据发生变化时，调用此方法更新控件的显示
        * </summary>
        */
        jart.grid.prototype.update = function () {
            //对数据进行分页处理
            this.rows.clear();
            var data = this.dataSource(), i = 0;
            if (data) {
                var low = 0, high = data.length, start = 1;
                if (this.pageMode() == "local") {
                    this.totalCount(data.length);
                    low = this.pager().pageLowBound() - 1;
                    high = this.pager().pageHighBound();
                } else if (this.pageMode() == "remote") {
                    start = this.pager().pageLowBound();
                }
                if (data) {
                    for (i = low; i < high; i++) {
                        this.rows.push(this.newRow(data[i], i + start));
                    }
                }
            }

            var llist = this.node.find("table[gsn=llist]");
            llist.children("tbody:gt(0)").remove();
            var list = this.node.find("table[gsn=list]");
            list.children("tbody:gt(0)").remove();
            var lcontent = "", content = "";
            for (i = 0; i < this.rows.length; i++) {
                lcontent += this.rows[i].frozenHtml({ index: i, striped: this.striped(), gridline: this.gridline(), rowline: this.rowline() });
                content += this.rows[i].html({ index: i, striped: this.striped(), gridline: this.gridline(), rowline: this.rowline() });
            }
            llist.append(lcontent);
            list.append(content);
            this.node.find("div[gsn=emptytext]").showx(false);
            this.node.find("tr[gsn=listtr]").showx(true);
            this.node.fillys();
            var node = this.node;
            if ($.browser.ie6) setTimeout(function () { onGridTableResized(node); }, 200);
            else setTimeout(function () { onGridTableResized(node); }, 0);
            return this;
        };

        ///创建表格匹配的一个新行
        jart.grid.prototype.newRow = function (data, index) {
            if (!data) throw new Error(jart_consts.error_parameter_null.format("{jart.grid}.newRow", "data"));
            var row = new gridRow();
            row.data = data;
            row.index = index;
            if (this.idFields) row.id = data[this.idFields];
            if (this.multiple()) {
                //取得多行表格一个逻辑行的最大物理行数 
                var length = 0, fcells = this.frozenColumns(), cells = this.columns(), i, j, len, field;
                if (fcells) length = fcells.length;
                if (cells && cells.length > length) length = cells.length;

                for (i = 0; i < length; i++) {
                    var arr = new Array();
                    if (i == 0) {
                        if (this.rowNumbers()) {
                            var cell = new gridCell();
                            cell.attr({ content: index, rowspan: length });
                            arr.push(cell);
                        }
                        if (this.showCheckBox()) {
                            var ids = this.checkedRowIds.split(",");
                            ids.remove("");
                            var checked = ids.contains(row.id);
                            var cell = new gridCell();
                            cell.attr({ content: "<input type='checkbox' gsn='check' name='" + this.name() + "_check' value='" + row.id + "'" + (checked ? " checked" : "") + " />", rowspan: length });
                            arr.push(cell);
                        }
                        if (this.showRadio()) {
                            var cell = new gridCell();
                            cell.attr({ content: "<input type='radio' gsn='radio' name='" + this.name() + "_radio' value='" + row.id + "' />", rowspan: length });
                            arr.push(cell);
                        }
                    }
                    if (fcells && fcells[i]) {
                        var cols = fcells[i];
                        for (j = 0, len = cols.length; j < len; j++) {
                            field = cols[j];
                            obj = { align: field.align, nowrap: field.nowrap, colspan: field.colspan, rowspan: field.rowspan };
                            obj.content = data[field.field];
                            if (field.formatter) obj.content = field.formatter(data, index);
                            obj.style = field.styler ? field.styler(data, index) : "";
                            var cell = new gridCell();
                            cell.attr(obj);
                            arr.push(cell);
                        }
                    }
                    row.frozenColumns.push(arr);
                }

                for (i = 0; i < length; i++) {
                    var arr = new Array();
                    if (cells && cells[i]) {
                        var cols = cells[i];
                        for (var j = 0, len = cols.length; j < len; j++) {
                            field = cols[j];
                            obj = { align: field.align, nowrap: field.nowrap, colspan: field.colspan, rowspan: field.rowspan };
                            obj.content = data[field.field];
                            if (field.formatter) obj.content = field.formatter(data, index);
                            obj.style = field.styler ? field.styler(data, index) : "";
                            var cell = new gridCell();
                            cell.attr(obj);
                            arr.push(cell);
                        }
                    }
                    row.columns.push(arr);
                }
            }
            else {
                //根据域集合取冻结列集合
                var arr = new Array(), field, obj, i, len;
                var fields = getSingleColumns(this.frozenColumns());
                if (this.rowNumbers()) {
                    var cell = new gridCell();
                    cell.attr({ content: index });
                    arr.push(cell);
                }
                if (this.showCheckBox()) {
                    var ids = this.checkedRowIds.split(",");
                    ids.remove("");
                    var checked = ids.contains(row.id);
                    var cell = new gridCell();
                    cell.attr({ content: "<input type='checkbox' gsn='check' name='" + this.name() + "_check' value='" + row.id + "'" + (checked ? " checked" : "") + " />" });
                    arr.push(cell);
                }
                if (this.showRadio()) {
                    var cell = new gridCell();
                    cell.attr({ content: "<input type='radio' gsn='radio' name='" + this.name() + "_radio' value='" + row.id + "' />" });
                    arr.push(cell);
                }
                if (fields) {
                    for (i = 0, len = fields.length; i < len; i++) {
                        field = fields[i];
                        obj = { align: field.align, nowrap: field.nowrap, colspan: 1, rowspan: 1 };
                        obj.content = data[field.field];
                        if (field.formatter) obj.content = field.formatter(data, index);
                        obj.style = field.styler ? field.styler(data, index) : "";
                        var cell = new gridCell();
                        cell.attr(obj);
                        arr.push(cell);
                    }
                }
                row.frozenColumns.push(arr);

                //根据域集合取普通列集合
                arr = new Array();
                fields = getSingleColumns(this.columns());
                if (fields) {
                    for (i = 0, len = fields.length; i < len; i++) {
                        field = fields[i];
                        obj = { align: field.align, nowrap: field.nowrap, colspan: 1, rowspan: 1 };
                        obj.content = data[field.field];
                        if (field.formatter) obj.content = field.formatter(data, index);
                        obj.style = field.styler ? field.styler(data, index) : "";
                        var cell = new gridCell();
                        cell.attr(obj);
                        arr.push(cell);
                    }
                }
                row.columns.push(arr);
            }
            return row;
        };

        ///绑定数据到列表上，此数据必须为二维数组
        jart.grid.prototype.bind = function (data) {
            this.dataSource(data);
            return this;
        };

        /**
        * <summary group="method" name="{jart.grid}.reload">
        * 重新加载数据源并更新控件
        * </summary>
        * <param name="req">
        * 是否向服务端请求数据
        * </param>
        */
        jart.grid.prototype.reload = function (req) {
            if (req) this.loadData();
            else this.update();
            return this;
        };
    }

    //基本属性
    {
        ///是否是多行表格,多行表格列表一行将根据表头规则显示数据
        jart.grid.prototype.multiple = function (multi) {
            if (multi === undefined) return this.node.data("multiple");
            this.node.data("multiple", multi);
            this.delay().active("list");
            return this;
        };

        //是否显示序号列
        jart.grid.prototype.rowNumbers = function (show) {
            if (show === undefined) return this.node.data("rowNumbers");
            this.node.data("rowNumbers", show);
            this.delay().active("list");
            return this;
        };

        ///间隔行是否区分样式
        jart.grid.prototype.striped = function (striped) {
            if (striped === undefined) return this.node.data("striped");
            this.node.data("striped", striped);
            this.node.find("table[gsn=llist]").children("tbody:even:gt(0)").toggleClass("x-grid-list-row-even", striped);
            this.node.find("table[gsn=list]").children("tbody:even:gt(0)").toggleClass("x-grid-list-row-even", striped);
            return this;
        };

        ///列表网格形式，horizontal或1：只显示水平网格线｜vertical或2：只显示垂直网格线｜all或0：显示所有网格线｜none或3：不显示网格线
        jart.grid.prototype.gridline = function (line) {
            if (line === undefined) return this.node.data("gridline") || "all";
            this.node.data("gridline", line);
            this.delay().active("gridline");
            return this;
        };

        ///列表行内多行间是否显示分隔线
        jart.grid.prototype.rowline = function (line) {
            if (line === undefined) return this.node.data("rowline");
            this.node.data("rowline", line);
            this.delay().active("gridline");
            return this;
        };
    }

    //选择相关属性和方法
    {
        /**
        * <summary group="property" name="{jart.grid}.showCheckBox" type="Boolean">
        * 是否显示复选框列
        * </summary>
        */
        jart.grid.prototype.showCheckBox = function (arg) {
            if (arg === undefined) return this.node.data("showCheckBox");
            this.node.data("showCheckBox", arg);
            return this;
        };

        /**
        * <summary group="property" name="{jart.grid}.showRadio" type="Boolean">
        * 是否显示单选框列
        * </summary>
        */
        jart.grid.prototype.showRadio = function (arg) {
            if (arg === undefined) return this.node.data("showRadio");
            this.node.data("showRadio", arg);
            return this;
        };

        ///单击行选中模式，disabled或0：不可选，single或1：单选，multiple或2：多选
        jart.grid.prototype.selectMode = function (mode) {
            if (mode === undefined) return this.node.data("selectMode") || "disabled";
            var omode = this.selectMode();
            this.node.data("selectMode", mode);
            if (mode != omode) {
                this.node.find("tbody.x-grid-list-row-selected").removeClass("x-grid-list-row-selected");
            }
            return this;
        };

        ///是否记住翻页后选的选择
        jart.grid.prototype.rememberChecked = false;

        ///获取或设置筛选中的ID
        jart.grid.prototype.checkedRowIds = "";

        var findRowByIId = function (iid) {
            var i, len;
            for (i = 0, len = this.rows.length; i < len; i++) {
                if (this.rows[i].iid() == iid) return this.rows[i];
            }
            return null;
        };

        jart.grid.prototype.findRowById = function (id) {
            var i, len;
            for (i = 0, len = this.rows.length; i < len; i++) {
                if (this.rows[i].id == id) return this.rows[i];
            }
            return null;
        };

        ///获取被复选框选中的行集
        jart.grid.prototype.checkedRows = function () {
            var rows = new Array();
            for (var i = 0, len = this.rows.length; i < len; i++) {
                var node = $("#" + this.rows[i].iid() + "_fl");
                if (node.has("input:checkbox[gsn=check]:checked").length > 0) rows.push(this.rows[i]);
            }
            return rows;
        };

        ///获取被单选框选中的行集
        jart.grid.prototype.radioedRow = function () {
            var row = new Array();
            for (var i = 0, len = this.rows.length; i < len; i++) {
                var node = $("#" + this.rows[i].iid() + "_fl");
                if (node.has("input:radio[gsn=radio]:checked").length > 0) return this.rows[i];
            }
            return null;
        };

        ///获取单击行选中的行集
        jart.grid.prototype.selectedRows = function () {
            var rows = new Array();
            for (var i = 0, len = this.rows.length; i < len; i++) {
                var node = $("#" + this.rows[i].iid());
                if (node.length < 1) node = $("#" + this.rows[i].iid() + "_fl");
                if (node.is(".x-grid-list-row-selected")) rows.push(this.rows[i]);
            }
            return rows;
        };
    }

    //分页相关属性和方法
    {
        ///获取列表对应的分页控件
        jart.grid.prototype.pager = function () {
            return this.node.children("div[gsn=pager]").pager();
        };

        ///分页模式，disabled或0不分页，local：内存分页，remote：虚拟分页
        jart.grid.prototype.pageMode = function (mode) {
            if (mode === undefined) return this.node.data("pageMode") || "disabled";
            this.node.data("pageMode", mode);
            if (mode != "disabled") this.pager().node.showx(true);
            return this;
        };

        //每页显示记录数
        jart.grid.prototype.pageSize = function (size) {
            if (size === undefined) return this.pager().pageSize();
            this.pager().pageSize(size);
            return this;
        };

        //可供选择的页大小
        jart.grid.prototype.pageList = function (arg) {
            if (arg === undefined) return this.pager().pageList();
            this.pager().pageList(arg);
            return this;
        };

        //获取或设置当前页码
        jart.grid.prototype.pageIndex = function (arg) {
            if (arg === undefined) return this.pager().pageIndex();
            this.pager().pageIndex(arg);
            return this;
        };

        //获取或设置总记录数
        jart.grid.prototype.totalCount = function (arg) {
            if (arg === undefined) return this.pager().totalCount();
            this.pager().totalCount(arg);
            return this;
        };
    }

    //排序相关属性和方法
    {
        ///排序模式，disabled不排序，local本地客户端排序，remote服务端排序
        jart.grid.prototype.sortMode = function (mode) {
            if (mode === undefined) return this.node.data("sortMode") || "disabled";
            this.node.data("sortMode", mode);
            return this;
        };

        ///列表当前排序字段
        jart.grid.prototype.sortField = function (field) {
            if (field === undefined) return this.node.data("sortField");
            this.node.data("sortField", field);
            return this;
        };

        ///列表当前排序方向，asc或desc
        jart.grid.prototype.sortOrder = function (order) {
            if (order === undefined) return this.node.data("sortOrder") || "asc";
            this.node.data("sortOrder", order);
            return this;
        };

        ///根据某列进行客户端排序，sorter：排序的逻辑，direction：排序的方向
        jart.grid.prototype.sort = function (sorter, direction) {
            if (typeof (sorter) == "function") {
                var ds = this.dataSource().sort(sorter);
                if (direction == "desc") ds = ds.reverse();
                this.dataSource(ds);
            }
            else {
                var fn = function (obj1, obj2) { if (obj1[sorter] == obj2[sorter]) return 0; if (obj1[sorter] > obj2[sorter]) return 1; return -1; };
                var ds = this.dataSource().sort(fn);
                if (direction == "desc") ds = ds.reverse();
                this.dataSource(ds);
            }
        };
    }

    //事件
    {
        ///选中行事件
        jart.grid.prototype.onCheck = function (row) { };

        ///单选中行事件
        jart.grid.prototype.onRadio = function (row) { };

        ///单击选择行事件
        jart.grid.prototype.onSelect = function (row, selected) { };

        ///排序事件
        jart.grid.prototype.onSort = function (column) { };
    }
    //控件初始化
    jart.grid.prototype.mRenderStart = function (node) {
        node.attr({ "align": "left", "class": "x-grid", "allowfilly": "0" }).css({ "overflow": "hidden", "clear": "both", "position": "relative" }).html(
        //主区域
        "<div gsn='main' filly=\"{padding:this.parent().children('div:visible').not(this).heights()}\" allowfilly='0'><table border='0' cellspacing='0' cellpadding='0' class='x-table-fixed'>" +
        //标题栏
            "<tr><td>" +
        //左标题
                "<table gsn='lhead' border='0' cellspacing='0' cellpadding='0' class='x-table-fixed' style='width:1px;'></table>" +
            "</td><td>" +
        //主标题
                "<div gsn='hwrap' style='overflow:hidden;width:100%;position:relative;'><table gsn='head' border='0' cellspacing='0' cellpadding='0' class='x-table-fixed'></table></div>" +
            "</td></tr>" +
        //内容区
            "<tr style='display:none;' gsn='listtr'><td valign='top'>" +
        //左内容
                "<div gsn='lwrap' style='overflow:hidden;min-height:25px;' filly=\"{padding:$(this).parent().parent().prev().children('td:first').outerHeight(true)}\" onfilly=\"this.children('div:last').showx(filled);\">" +
                    "<table gsn='llist' border='0' cellspacing='0' cellpadding='0' class='x-table-fixed' style='width:1px;' resizable='true'><tbody></tbody></table>" +
                    "<div style='height:100px;display:none;'></div>" +
                "</div>" +
            "</td><td valign='top'>" +
        //主内容
                "<div gsn='wrap' style='overflow:auto;width:100%;' filly=\"{padding:$(this).parent().parent().prev().children('td:first').outerHeight(true)}\">" +
                    "<table gsn='list' border='0' cellspacing='0' cellpadding='0' class='x-table-fixed' resizable='true'><tbody></tbody></table>" +
                "</div>" +
            "</td></tr>" +
        "</table></div>" +
        //移动线
        "<span gsn='move' style='position:absolute;left:0px;top:0px;bottom:0px;width:1px;_height:100%;background-color:red;display:none;' _display='inline-block'></span>" +
        //内容为空提示
        "<div gsn='emptytext' filly='{padding:this.parent().children('div:visible').not(this).heights()}'><label>当前列表内容为空</label></div>" +
        "<div gsn='pager' style='display:none;'></div>" +
        "</div>");
        var pager = node.children("div[gsn=pager]").pager();
        pager.onPageIndexChanged = function () {
            var ctl = this.node.parent().jart();
            if (ctl && ctl.type == "grid" && !ctl.first) ctl.reload(ctl.pageMode() == "remote");
        };
        pager.onPageSizeChanged = function () {
            var ctl = this.node.parent().jart();
            if (ctl && ctl.type == "grid" && !ctl.first) ctl.reload(ctl.pageMode() == "remote");
        };
        pager.onRefresh = function () {
            var ctl = this.node.parent().jart();
            if (ctl && ctl.type == "grid") ctl.reload(ctl.pageMode() == "remote");
        };
        node.find("table[gsn=lhead]").onresize = function () {
            var jq = $(this);
            jq.parent().width(jq.outerWidth(true));
        };
        var wrap = node.find("div[gsn=wrap]").scroll(function (e) {
            //让冻结列和表格头位置匹配
            var lwrap = $(this).parent().prev().children("div[gsn=lwrap]");
            var hwrap = $(this).parent().parent().prev().find("div[gsn=hwrap]");
            var top = this.scrollTop;
            var left = this.scrollLeft;
            lwrap[0].scrollTop = top;
            hwrap[0].scrollLeft = left;
        });
        node.find("table[gsn=llist]")[0].onresize = function () {
            onGridTableResized($(this).parents(".x-grid:first"));
        };
        node.find("table[gsn=list]")[0].onresize = function () {
            onGridTableResized($(this).parents(".x-grid:first"));
        };
        node.binds("input:checkbox[gsn=check]", "click", null, function (e) {
            var jq = $(this);
            var checks = jq.find("input:checkbox[gsn=check]");
            var checkall = jq.find("input:checkbox[gsn=checkall]");
            if (checks.length == checks.filter(":checked").length) checkall[0].checked = true;
            else checkall[0].checked = false;

            var ctl = jq.jart();
            var ids = ctl.checkedRowIds.split(",");
            ids.remove("");
            var id = e.targets.parents("tbody:first").attribute("nid");
            if (e.targets[0].checked) {
                if (!ids.contains(id)) ids.push(id);
            }
            else {
                ids.remove(id);
            }
            ctl.checkedRowIds = ids.join(",");
        });
        node.binds("input:checkbox[gsn=checkall]", "click", null, function (e) {
            var jq = $(this);
            var ctl = jq.jart();
            var checked = e.targets[0].checked;
            var ids = ctl.checkedRowIds.split(",");
            ids.remove("");
            jq.find("input:checkbox[gsn=check]").each(function () {
                this.checked = checked;
                var id = $(this).parents("tbody:first").attribute("nid");
                if (checked) {
                    if (!ids.contains(id)) ids.push(id);
                }
                else {
                    ids.remove(id);
                }
            });
            ctl.checkedRowIds = ids.join(",");
        });
        node.binds("tbody[gsn=gridrow]", "click", null, function (e) {
            var target = $(e.target);
            if (target.is("input:checkbox[gsn=check]") || target.is("input:radio[gsn=radio]")) return;
            var ctl = $(this).jart();
            var iid = e.targets.attr("gsnid");
            findRowByIId.call(ctl, iid).select();
        });
        node.binds("div.x-grid-head-th-div[sortable=true]", "click", null, function (e) {
            var ctl = $(this).jart();
            var td = e.targets.parents("th:first");
            var params = td.attribute("columnindex").split(",");
            var col = ctl[params[0]]()[params[1]][params[2]];
            var mode = ctl.sortMode();
            if (mode != "disabled") {
                if (col.sortfield || (mode == "local" && col.sorter)) {
                    var mysp = td.find("span[gsnsp=sorticon]");
                    if (mysp.showx()) {
                        if (mysp.attr("className") == "x-grid-sort-asc") {
                            mysp.attr("className", "x-grid-sort-desc");
                            ctl.sortOrder("desc");
                        }
                        else {
                            mysp.attr("className", "x-grid-sort-asc");
                            ctl.sortOrder("asc");
                        }
                    }
                    else {
                        ctl.node.find("span[gsnsp=sorticon]").showx(false);
                        mysp.showx(true).attr("className", "x-grid-sort-asc");
                        ctl.sortOrder("asc");
                    }
                    if (mode == "remote") {
                        ctl.sortField(col.sortfield);
                        ctl.reload(true);
                    }
                    else {
                        if (col.sortField) ctl.sortField(col.sortfield);
                        ctl.sort(col.sortfield || col.sorter, ctl.sortOrder());
                    }
                }
            }
        });
        node.binds("span[gsn=resizesp]", "mousedown", null, function (e) {
            //显示移动线
            var ctl = $(this).jart();
            var jq = e.targets;
            var x = e.clientX - ctl.node.offset().left;
            var line = ctl.node.children("span[gsn=move]").showx(true).css("left", x + "px");

            //找出要改变大小的分配列
            var ths = jq.parents("table:first").find("tr:first").children("th");
            for (var i = 0; i < ths.length; i++) {
                if ($(ths[i]).offset().left + ths[i].offsetWidth > e.clientX) {
                    ctl.__resizeColumn = ths[i];
                    ctl.__resizeColumnID = $(ths[i]).attribute("gsn");

                    //记住现在的宽度
                    ctl.__nowWidth = ths[i].offsetWidth;
                    break;
                }
            }

            line.dopull(e, 1);
        });
        node.children("span[gsn=move]").pull(function (e) {
            var jq = $(this);
            var ctl = jq.jart();
            var x = e.clientX - ctl.node.offset().left;
            jq.showx(true).css("left", x + "px");
            ctl.__nowWidth += e.dx;
        }).pullend(function (e) {
            var jq = $(this);
            var ctl = jq.jart();
            jq.showx(false);

            //获取拖动的长度并设置新长度
            var width = ctl.__nowWidth;
            var minWidth = $(ctl.__resizeColumn).attribute("min-width");
            if (!minWidth) minWidth = 20;
            if (width < minWidth) width = minWidth;
            ctl.node.find("th[gsn=" + ctl.__resizeColumnID + "]").width(width);

            //触发调整高度
            onGridTableResized(ctl.node);
        });

        this.rows = new gridRows(node);
        return node;
    };

    jart.grid.prototype.onLoadData = function (data) {
        if (this.pageMode() == "remote") {
            this.pager().totalCount(data.total);
        }
        this.bind(data.rows);
    };

    jart.grid.prototype.onBeforeLoadData = function () {
        if (!this.queryParams) this.queryParams = {};
        if (this.pageMode() == "remote") {
            this.queryParams.pageindex = this.pageIndex();
            this.queryParams.pagesize = this.pageSize();
        }
        this.queryParams.sort = this.sortField();
        this.queryParams.order = this.sortOrder();
    };

    jart.grid.prototype.blocker = function () {
        return this.node;
    };
})(jQuery, jart);

