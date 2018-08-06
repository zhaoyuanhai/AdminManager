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

})(window);