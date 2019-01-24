declare var require: any;
declare interface Window {
    VueInit(option: any);
    GetVueOption(): any;
}

//获取和设置vue的初始参数
(function () {
    let vueOption = {};

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
    let methods = {
        _menuClick(url, id) {
            if (url) {
                location.hash = url;
            }
        },
        _dialogClose() {
            this.$data.dialogVisible = false;
        },
        _pageingChange(current: number) {

        },
        _pageingSizeChange() {

        },

        $base() {
            var r = {};
            for (var name in methods) {
                if (name === "$base")
                    continue;
                r[name] = methods[name].bind(this);
            }
            return r;
        },
        dialogClose(done) {
            this.$confirm('取消会丢失所填写的数据，确认取消么？').then(_ => {
                done(this);
            }).catch(_ => { });
        },
        submit(refForm) {
            var _self = this;
            this.$refs[refForm].validate((valid) => {
                if (valid) {
                    if (typeof this._submit === 'function')
                        this._submit.call(this, refForm);
                }
            });
        },
        create() {
            //this.$data.dialogTitle = "添加-" + this.$data.title;
            //this.$data.dialogVisible = true;
            //if (this.$refs.modelForm) {
            //    this.$refs.modelForm.resetFields();
            //}

            //this.modelForm = {};
            //if (typeof this._create === 'function')
            //    this._create.apply(this, arguments);
        },
        modify(model) {
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
        remove() {
            let args = arguments;
            if (typeof this._remove === 'function')
                this.$confirm("确认删除么?", "删除-" + this.title).then(() => {
                    this._remove.apply(this, args);
                });
        },
        select() {
            if (typeof this._select === 'function')
                this._select.apply(this, arguments);
        },

        /**下载操作 */
        downLoad() {
            if (typeof this._downLoad === 'function')
                this._downLoad.apply(this, arguments);
        },

        /**弹出框提交操作 */
        dialogSubmit() {

        },

        /**
         * 关闭弹出框操作
         * @param done
         */
        handleClose(done) {
            this.$confirm('确认关闭？')
                .then(_ => {
                    done();
                    this.dialogVisible = false;
                })
                .catch(_ => { });
        },

        /**取消弹出框操作 */
        handleCancel() {
            this.$confirm("取消会丢失所填写的数据，确认取消么？").then(_ => {
                this.dialogVisible = false;
            });
        }
    }

    let vueOption = {
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
    let arr = [
        "vue",
        "jquery",
        "ELEMENT",
        "/Scripts/AppScript/Component/TreeTable.js",
        "/Scripts/AppScript/Component/DataQuery.js"];
    if (usePageJs) {
        arr.push('/Scripts/Views' + pageUrl + '.js');
    }
    require(arr, renderPage);
})();