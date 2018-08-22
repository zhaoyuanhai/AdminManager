define(["require", "exports", "axios"], function (require, exports, axios_1) {
    "use strict";
    Object.defineProperty(exports, "__esModule", { value: true });
    class Api {
        constructor() {
            this.system = {
                getMenuList() {
                    return axios_1.default.get("/System/", {});
                }
            };
        }
    }
    var api = new Api();
    exports.default = api;
});
//# sourceMappingURL=api.js.map