var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : new P(function (resolve) { resolve(result.value); }).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
var __generator = (this && this.__generator) || function (thisArg, body) {
    var _ = { label: 0, sent: function() { if (t[0] & 1) throw t[1]; return t[1]; }, trys: [], ops: [] }, f, y, t, g;
    return g = { next: verb(0), "throw": verb(1), "return": verb(2) }, typeof Symbol === "function" && (g[Symbol.iterator] = function() { return this; }), g;
    function verb(n) { return function (v) { return step([n, v]); }; }
    function step(op) {
        if (f) throw new TypeError("Generator is already executing.");
        while (_) try {
            if (f = 1, y && (t = op[0] & 2 ? y["return"] : op[0] ? y["throw"] || ((t = y["return"]) && t.call(y), 0) : y.next) && !(t = t.call(y, op[1])).done) return t;
            if (y = 0, t) op = [op[0] & 2, t.value];
            switch (op[0]) {
                case 0: case 1: t = op; break;
                case 4: _.label++; return { value: op[1], done: false };
                case 5: _.label++; y = op[1]; op = [0]; continue;
                case 7: op = _.ops.pop(); _.trys.pop(); continue;
                default:
                    if (!(t = _.trys, t = t.length > 0 && t[t.length - 1]) && (op[0] === 6 || op[0] === 2)) { _ = 0; continue; }
                    if (op[0] === 3 && (!t || (op[1] > t[0] && op[1] < t[3]))) { _.label = op[1]; break; }
                    if (op[0] === 6 && _.label < t[1]) { _.label = t[1]; t = op; break; }
                    if (t && _.label < t[2]) { _.label = t[2]; _.ops.push(op); break; }
                    if (t[2]) _.ops.pop();
                    _.trys.pop(); continue;
            }
            op = body.call(thisArg, _);
        } catch (e) { op = [6, e]; y = 0; } finally { f = t = 0; }
        if (op[0] & 5) throw op[1]; return { value: op[0] ? op[1] : void 0, done: true };
    }
};
define(["require", "exports", "axios"], function (require, exports, axios_1) {
    "use strict";
    Object.defineProperty(exports, "__esModule", { value: true });
    axios_1.default.interceptors.request.use(function (config) {
        config.headers["X-Requested-With"] = "XMLHttpRequest";
        return config;
    }, function (error) {
        console.log(error);
    });
    var Api = /** @class */ (function () {
        function Api() {
            this.system = {
                /**
                 * 设置菜单
                 * @param menu
                 * @returns {Promise} 结果
                 */
                setMenu: function (menu) {
                    return __awaiter(this, void 0, void 0, function () {
                        var result;
                        return __generator(this, function (_a) {
                            switch (_a.label) {
                                case 0: return [4 /*yield*/, axios_1.default.post("/System/CreateModifyMenu", menu)];
                                case 1:
                                    result = _a.sent();
                                    return [2 /*return*/, result.data];
                            }
                        });
                    });
                },
                /**
                 * 获取菜单
                 * @returns {Promise} 结果
                 */
                getMenuList: function () {
                    return __awaiter(this, void 0, void 0, function () {
                        var result;
                        return __generator(this, function (_a) {
                            switch (_a.label) {
                                case 0: return [4 /*yield*/, axios_1.default.get("/System/MenuList")];
                                case 1:
                                    result = _a.sent();
                                    return [2 /*return*/, result.data];
                            }
                        });
                    });
                },
                /**
                 * 删除菜单
                 * @param id 菜单Id
                 * @returns {Promise} 结果
                 */
                deleteMenu: function (id) {
                    return __awaiter(this, void 0, void 0, function () {
                        var result;
                        return __generator(this, function (_a) {
                            switch (_a.label) {
                                case 0: return [4 /*yield*/, axios_1.default.get("/System/DeleteMenu", { params: { id: id } })];
                                case 1:
                                    result = _a.sent();
                                    return [2 /*return*/, result.data];
                            }
                        });
                    });
                },
                /**
                 * 登录接口
                 * @param form
                 * @returns {Promise} 结果
                 */
                login: function (form) {
                    return axios_1.default.post('/Home/Login', form);
                },
                /**
                 * 获取用户集合
                 * @param pageModel 分页的查询参数
                 */
                getUserList: function (pageModel) {
                    return __awaiter(this, void 0, void 0, function () {
                        var result;
                        return __generator(this, function (_a) {
                            switch (_a.label) {
                                case 0: return [4 /*yield*/, axios_1.default.get("/System/GetUserList", { params: pageModel })];
                                case 1:
                                    result = _a.sent();
                                    return [2 /*return*/, result.data];
                            }
                        });
                    });
                },
                /**
                 * 获取角色集合
                 * @param pageModel
                 */
                getRoleList: function (pageModel) {
                    return __awaiter(this, void 0, void 0, function () {
                        var result;
                        return __generator(this, function (_a) {
                            switch (_a.label) {
                                case 0: return [4 /*yield*/, axios_1.default.get("/System/GetRoleList", { params: pageModel })];
                                case 1:
                                    result = _a.sent();
                                    return [2 /*return*/, result.data];
                            }
                        });
                    });
                },
                /**
                 * 获取功能集合
                 * @param pageingModel
                 */
                getOperationList: function (pageingModel) {
                    return __awaiter(this, void 0, void 0, function () {
                        var result;
                        return __generator(this, function (_a) {
                            switch (_a.label) {
                                case 0: return [4 /*yield*/, axios_1.default.get("/System/OperationList", { params: pageingModel })];
                                case 1:
                                    result = _a.sent();
                                    return [2 /*return*/, result.data];
                            }
                        });
                    });
                },
                createOperation: function (data) {
                    return __awaiter(this, void 0, void 0, function () {
                        var result;
                        return __generator(this, function (_a) {
                            switch (_a.label) {
                                case 0: return [4 /*yield*/, axios_1.default.post("/System/CreateOperation", data)];
                                case 1:
                                    result = _a.sent();
                                    return [2 /*return*/, result.data];
                            }
                        });
                    });
                },
                modifyOperation: function (data) {
                    return __awaiter(this, void 0, void 0, function () {
                        var result;
                        return __generator(this, function (_a) {
                            switch (_a.label) {
                                case 0: return [4 /*yield*/, axios_1.default.post("/System/ModifyOperation", data)];
                                case 1:
                                    result = _a.sent();
                                    return [2 /*return*/, result.data];
                            }
                        });
                    });
                },
                removeOperation: function (id) {
                    return __awaiter(this, void 0, void 0, function () {
                        var result;
                        return __generator(this, function (_a) {
                            switch (_a.label) {
                                case 0: return [4 /*yield*/, axios_1.default.delete("/System/RemoveOperation", { params: { id: id } })];
                                case 1:
                                    result = _a.sent();
                                    return [2 /*return*/, result.data];
                            }
                        });
                    });
                }
            };
            this.current = {
                get: function (data) {
                    return __awaiter(this, void 0, void 0, function () {
                        var result;
                        return __generator(this, function (_a) {
                            switch (_a.label) {
                                case 0: return [4 /*yield*/, axios_1.default.get("", { params: data })];
                                case 1:
                                    result = _a.sent();
                                    return [2 /*return*/, result.data];
                            }
                        });
                    });
                },
                post: function (data) {
                    return __awaiter(this, void 0, void 0, function () {
                        var result;
                        return __generator(this, function (_a) {
                            switch (_a.label) {
                                case 0: return [4 /*yield*/, axios_1.default.post("", data)];
                                case 1:
                                    result = _a.sent();
                                    return [2 /*return*/, result.data];
                            }
                        });
                    });
                },
                delete: function (data) {
                    return __awaiter(this, void 0, void 0, function () {
                        var result;
                        return __generator(this, function (_a) {
                            switch (_a.label) {
                                case 0: return [4 /*yield*/, axios_1.default.delete("", data)];
                                case 1:
                                    result = _a.sent();
                                    return [2 /*return*/, result.data];
                            }
                        });
                    });
                },
                put: function (data) {
                    return __awaiter(this, void 0, void 0, function () {
                        var result;
                        return __generator(this, function (_a) {
                            switch (_a.label) {
                                case 0: return [4 /*yield*/, axios_1.default.put("", data)];
                                case 1:
                                    result = _a.sent();
                                    return [2 /*return*/, result.data];
                            }
                        });
                    });
                }
            };
        }
        return Api;
    }());
    var api = new Api();
    exports.default = api;
    exports.aa = 33;
});
//# sourceMappingURL=api.js.map