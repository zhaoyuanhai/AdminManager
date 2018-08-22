"use strict";
exports.__esModule = true;
var vue_1 = require("vue");
require("jquery");
var vueOption = {
    el: "#v-app",
    data: {},
    mounted: function () {
    },
    methods: {
        _menuClick: function (url, id) {
            location.href = url;
        },
        create: function () {
        },
        modify: function () {
        },
        "delete": function () {
        },
        select: function () {
        }
    }
};
new vue_1["default"]($.extend(true, vueOption, window.GetVueOption()));
//# sourceMappingURL=Base.js.map