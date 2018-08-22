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
require.config({
    baseUrl: '/Scripts',
    paths: {
        jquery: 'Lib/jquery-1.10.2',
        axios: 'Lib/axios',
        vue: 'Lib/vue',
        ELEMENT: 'Lib/elementui',
        api: 'AppScript/api'
    }
});
function renderPage(Vue, jquery, ELEMENT) {
    let vueOption = {
        el: "#v-app",
        data: {},
        methods: {
            _init_() {
                console.log("init");
            },
            _menuClick(url, id) {
                location.href = url;
            },
            create() {
            },
            modify() {
            },
            delete() {
            },
            select() {
            }
        }
    };
    Vue.use(ELEMENT);
    new Vue($.extend(true, vueOption, window.GetVueOption()));
}
if (isPageJs) {
    require(['vue',
        'jquery',
        'ELEMENT',
        '/Scripts/Views' + pageUrl + '.js'
    ], renderPage);
}
else {
    require(['vue', 'jquery', 'ELEMENT'], renderPage);
}
//# sourceMappingURL=main.js.map