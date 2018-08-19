(function (window) {
    window["exports"] = { __esModule: true };

    var nsVue = window["Vue"];
    nsVue["default"] = window["Vue"];

    var nsAxios = window["axios"];
    nsAxios["default"] = window["axios"];

    var moduleDic = {
        vue: nsVue,
        axios: nsAxios
    };

    window["require"] = function (name) {
        return moduleDic[name];
    }

    var vueOption = {};
    //初始化vue的方法
    window.VueInit = function (_option) {
        vueOption = _option;
    }

    window.GetVueOption = function () {
        return vueOption;
    }
})(window);