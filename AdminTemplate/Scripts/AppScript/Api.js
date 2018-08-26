define(["require", "exports", "axios"], function (require, exports, axios_1) {
    "use strict";
    Object.defineProperty(exports, "__esModule", { value: true });
    class Api {
        constructor() {
            this.system = {
                getMenuList() {
                    return new Promise((resolve, reject) => {
                        axios_1.default.get("/System/MenuList", {}).then((result) => {
                            resolve(result.data);
                        });
                    });
                },
                /**
                 * 登录接口
                 * @param form
                 */
                login(form) {
                    return axios_1.default.post('/Home/Login', form);
                }
            };
        }
    }
    var api = new Api();
    exports.default = api;
});
//# sourceMappingURL=api.js.map