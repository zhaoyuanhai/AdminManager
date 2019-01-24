//获取和设置vue的初始参数
(function () {
    var vueOption = {};
    //初始化vue的方法
    window.VueInit = function (_option) {
        vueOption = _option;
    };
    window.GetVueOption = function () {
        return vueOption;
    };
})();
//配置模块加载器
require.config({
    baseUrl: '/Scripts',
    paths: {
        jquery: 'Lib/jquery-1.10.2',
        axios: 'Lib/axios',
        vue: 'Lib/vue',
        ELEMENT: 'Lib/elementui',
        elementui: 'Lib/elementui',
        api: 'AppScript/api',
        common: 'AppScript/common'
    }
});
//渲染页面,初始化vue对象
function renderPage(Vue, jquery, ELEMENT) {
    var methods = {
        _menuClick: function (url, id) {
            if (url) {
                location.hash = url;
            }
        },
        _dialogClose: function () {
            this.$data.dialogVisible = false;
        },
        _pageingChange: function (current) {
        },
        _pageingSizeChange: function () {
        },
        $base: function () {
            var r = {};
            for (var name in methods) {
                if (name === "$base")
                    continue;
                r[name] = methods[name].bind(this);
            }
            return r;
        },
        dialogClose: function (done) {
            var _this = this;
            this.$confirm('取消会丢失所填写的数据，确认取消么？').then(function (_) {
                done(_this);
            }).catch(function (_) { });
        },
        submit: function (refForm) {
            var _this = this;
            var _self = this;
            this.$refs[refForm].validate(function (valid) {
                if (valid) {
                    if (typeof _this._submit === 'function')
                        _this._submit.call(_this, refForm);
                }
            });
        },
        create: function () {
            //this.$data.dialogTitle = "添加-" + this.$data.title;
            //this.$data.dialogVisible = true;
            //if (this.$refs.modelForm) {
            //    this.$refs.modelForm.resetFields();
            //}
            //this.modelForm = {};
            //if (typeof this._create === 'function')
            //    this._create.apply(this, arguments);
        },
        modify: function (model) {
            this.$data.dialogTitle = "编辑-" + this.$data.title;
            this.$data.dialogVisible = true;
            if (this.$refs.modelForm) {
                this.$refs.modelForm.resetFields();
            }
            this.modelForm = model;
            if (typeof this._modify === 'function') {
                this._modify.apply(this, arguments);
            }
        },
        remove: function () {
            var _this = this;
            var args = arguments;
            if (typeof this._remove === 'function')
                this.$confirm("确认删除么?", "删除-" + this.title).then(function () {
                    _this._remove.apply(_this, args);
                });
        },
        select: function () {
            if (typeof this._select === 'function')
                this._select.apply(this, arguments);
        },
        /**下载操作 */
        downLoad: function () {
            if (typeof this._downLoad === 'function')
                this._downLoad.apply(this, arguments);
        },
        /**弹出框提交操作 */
        dialogSubmit: function () {
        },
        /**
         * 关闭弹出框操作
         * @param done
         */
        handleClose: function (done) {
            var _this = this;
            this.$confirm('确认关闭？')
                .then(function (_) {
                done();
                _this.dialogVisible = false;
            })
                .catch(function (_) { });
        },
        /**取消弹出框操作 */
        handleCancel: function () {
            var _this = this;
            this.$confirm("取消会丢失所填写的数据，确认取消么？").then(function (_) {
                _this.dialogVisible = false;
            });
        }
    };
    var vueOption = {
        el: "#v-app",
        data: {
            //弹框默认隐藏
            dialogVisible: false,
            //弹框的标题
            dialogTitle: "",
            //分页总数
            pageingTotal: 0
        },
        methods: methods
    };
    Vue.use(ELEMENT);
    var vue = new Vue($.extend(true, vueOption, window.GetVueOption()));
    window["vue"] = vue;
}
//加载页面,如果当前页面有对应的js文件,就自动加载.
(function () {
    var arr = [
        "vue",
        "jquery",
        "ELEMENT",
        "/Scripts/AppScript/Component/TreeTable.js",
        "/Scripts/AppScript/Component/DataQuery.js"
    ];
    if (usePageJs) {
        arr.push('/Scripts/Views' + pageUrl + '.js');
    }
    require(arr, renderPage);
})();
//# sourceMappingURL=main.js.map