define(["require", "exports", "vue", "jquery"], function (require, exports, vue_1) {
    "use strict";
    Object.defineProperty(exports, "__esModule", { value: true });
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
    new vue_1.default($.extend(true, vueOption, window.GetVueOption()));
});
//# sourceMappingURL=base.js.map