(function (window) {
    window["exports"] = { __esModule: true };

    var nsVue = window["Vue"];
    nsVue["default"] = window["Vue"];

    var moduleDic = {
        vue: nsVue
    };

    window["require"] = function (name) {
        return moduleDic[name];
    }

})(window);