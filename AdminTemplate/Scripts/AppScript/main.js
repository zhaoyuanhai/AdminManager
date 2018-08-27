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
        api: 'AppScript/api',
        common: 'AppScript/common'
    }
});
function renderPage(Vue, jquery, ELEMENT) {
    let vueOption = {
        el: "#v-app",
        methods: {
            _menuClick(url, id) {
                if (url) {
                    location.hash = url;
                }
            },
            create() {
            },
            modify() {
            },
            remove() {
            },
            select() {
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
        '/Scripts/Views' + pageUrl + '.js'
    ], renderPage);
}
else {
    require(['vue', 'jquery', 'ELEMENT'], renderPage);
}
//# sourceMappingURL=main.js.map