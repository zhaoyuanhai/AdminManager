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
require.config({
    baseUrl: '/Scripts',
    paths: {
        jquery: 'Lib/jquery-1.10.2',
        axios: 'Lib/axios',
        vue: 'Lib/vue',
        ELEMENT: 'Lib/elementui',
        'elementui': 'Lib/elementui',
        api: 'AppScript/api',
        common: 'AppScript/common'
    }
});
function renderPage(Vue, jquery, ELEMENT, treeTable) {
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
        methods: {
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
            create: function () {
                this.$data.dialogTitle = "添加-" + this.$data.title;
                this.$data.dialogVisible = true;
                if (typeof this._create === 'function')
                    this._create.apply(this, arguments);
            },
            modify: function () {
                this.$data.dialogTitle = "编辑-" + this.$data.title;
                this.$data.dialogVisible = true;
                if (typeof this._modify === 'function')
                    this._modify.apply(this, arguments);
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
            downLoad: function () {
                if (typeof this._downLoad === 'function')
                    this._downLoad.apply(this, arguments);
            },
            dialogSubmit: function () {
            }
        }
    };
    Vue.use(ELEMENT);
    var vue = new Vue($.extend(true, vueOption, window.GetVueOption()));
    window["vue"] = vue;
}
if (usePageJs) {
    require(['vue',
        'jquery',
        'ELEMENT',
        '/Scripts/AppScript/Component/TreeTable.js',
        '/Scripts/Views' + pageUrl + '.js'
    ], renderPage);
}
else {
    require(['vue', 'jquery', 'ELEMENT'], renderPage);
}
//# sourceMappingURL=main.js.map