define(["require", "exports", "axios"], function (require, exports, axios_1) {
    "use strict";
    Object.defineProperty(exports, "__esModule", { value: true });
    class Api {
        constructor() {
            this.system = {
                /**
                 * 设置菜单
                 * @param menu
                 * @returns {Promise} 结果
                 */
                setMenu(menu) {
                    return new Promise((resolve, reject) => {
                        axios_1.default.post("/System/CreateModifyMenu", menu).then((result) => {
                            resolve(result.data);
                        });
                    });
                },
                /**
                 * 获取菜单
                 * @returns {Promise} 结果
                 */
                getMenuList() {
                    return new Promise((resolve, reject) => {
                        axios_1.default.get("/System/MenuList").then(result => {
                            resolve(result.data);
                        });
                    });
                },
                /**
                 * 删除菜单
                 * @param id 菜单Id
                 * @returns {Promise} 结果
                 */
                deleteMenu(id) {
                    return new Promise((resolve, reject) => {
                        axios_1.default.get("/System/DeleteMenu", { params: { id: id } }).then(result => {
                            resolve(result.data);
                        });
                    });
                },
                /**
                 * 登录接口
                 * @param form
                 * @returns {Promise} 结果
                 */
                login(form) {
                    return axios_1.default.post('/Home/Login', form);
                },
                /**
                 * 获取用户集合
                 * @param pageModel 分页的查询参数
                 */
                getUserList(pageModel) {
                    return new Promise((resolve, reject) => {
                        axios_1.default.get("/System/GetUserList", { params: pageModel }).then(result => {
                            resolve(result.data);
                        });
                    });
                },
                /**
                 * 获取角色集合
                 * @param pageModel
                 */
                getRoleList(pageModel) {
                    return new Promise((resolve, reject) => {
                        axios_1.default.get("/System/GetRoleList", { params: pageModel }).then(result => {
                            resolve(result.data);
                        });
                    });
                }
            };
        }
    }
    var api = new Api();
    exports.default = api;
    exports.aa = 33;
});
//# sourceMappingURL=api.js.map