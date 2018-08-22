declare interface Window {
    VueInit(option: any);
    GetVueOption(): any;
}

(function () {
    window["exports"] = { __esModule: true };

    let moduleDic = {
        vue: { default: window["Vue"] },
        axios: { default: window["axios"] },
        jquery: { default: window["$"] }
    };

    window["require"] = function (name) {
        return moduleDic[name];
    }

    let vueOption = {};

    //初始化vue的方法
    window.VueInit = function (_option) {
        vueOption = _option;
    }

    window.GetVueOption = function () {
        return vueOption;
    }
})();