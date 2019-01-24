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
define(["require", "exports", "api", "common"], function (require, exports, api_1, common_1) {
    "use strict";
    Object.defineProperty(exports, "__esModule", { value: true });
    VueInit({
        data: {
            loading: {
                tree: true
            },
            treeLoading: true,
            menuDialog: {
                visable: false
            },
            opDialog: {
                visible: false,
                title: "编辑功能"
            },
            menuForm: {
                Id: "",
                Title: "",
                Icon: "",
                ParentId: "",
                Order: "",
                Url: ""
            },
            menuList: [],
            rules: {
                Title: [
                    { required: true, message: "请输入菜单名称", trigger: 'blur' }
                ]
            },
            menuTree: [],
            tableData: [],
            operationList: [],
            checkList: [],
            currentMenu: {}
        },
        computed: {
            parentName: function () {
                var _this = this;
                if (this.$data.menuForm.ParentId) {
                    var menu = this.$data.menuList.find(function (x) { return x.Id == _this.$data.menuForm.ParentId; });
                    return "/" + menu.Title;
                }
                return "/";
            },
            menuDialogTitle: function () {
                return this.$data.menuForm.Id ? "编辑菜单" : "添加菜单";
            }
        },
        mounted: function () {
            return __awaiter(this, void 0, void 0, function () {
                var data, opList, treeData;
                return __generator(this, function (_a) {
                    switch (_a.label) {
                        case 0: return [4 /*yield*/, api_1.default.system.getMenuList()];
                        case 1:
                            data = _a.sent();
                            this.$data.menuList = data.Data;
                            return [4 /*yield*/, api_1.default.system.getOperationList({ PageSize: 20 })];
                        case 2:
                            opList = _a.sent();
                            this.operationList = opList.Data.Datas;
                            treeData = common_1.default.CompileTree(data.Data, null, "Id", "ParentId", function (item, arr) {
                                return {
                                    id: item.Id,
                                    label: item.Title,
                                    icon: item.Icon,
                                    children: arr,
                                    operations: item.Operations
                                };
                            }, function (a, b) { return a.Order - b.Order; });
                            this.$data.menuTree = treeData;
                            this.loading.tree = false;
                            return [2 /*return*/];
                    }
                });
            });
        },
        methods: {
            createMenu: function (parentMenu) {
                common_1.default.SetObjectPropEmptyString(this.$data.menuForm);
                if (parentMenu) {
                    this.$data.menuForm.ParentId = parentMenu.id;
                }
                this.$data.menuDialog.visable = true;
            },
            modifyMenu: function (parentMenu) {
                var menu = this.$data.menuList.find(function (x) { return x.Id == parentMenu.id; });
                menu.ParentMenu = null;
                this.$data.menuForm = menu;
                this.$data.menuDialog.visable = true;
            },
            btnSubmit: function () {
                var _this = this;
                this.$refs.menuForm.validate(function (isValid, fialFields) { return __awaiter(_this, void 0, void 0, function () {
                    var loading, data_1, item, node, menu, node;
                    return __generator(this, function (_a) {
                        switch (_a.label) {
                            case 0:
                                if (!isValid) return [3 /*break*/, 2];
                                loading = this.$loading({
                                    target: this.$refs.menuDialog.$el,
                                    background: common_1.Color.loading
                                });
                                return [4 /*yield*/, api_1.default.system.setMenu(this.$data.menuForm)];
                            case 1:
                                data_1 = _a.sent();
                                if (data_1.Success) {
                                    item = data_1.Data;
                                    if (this.$data.menuForm.Id) {
                                        node = this.$refs.menuTree.getNode(data_1.Data.Id);
                                        node.data.label = item.Title;
                                        node.data.icon = item.Icon;
                                        menu = this.$data.menuList.find(function (x) { return x.Id === data_1.Data.Id; });
                                        menu.Title = data_1.Data.Title;
                                        menu.Url = data_1.Data.Url;
                                        menu.Icon = data_1.Data.Icon;
                                    }
                                    else {
                                        node = data_1.Data.ParentId ?
                                            this.$refs.menuTree.getNode(data_1.Data.ParentId) :
                                            this.$refs.menuTree.root;
                                        this.$refs.menuTree.append({
                                            id: item.Id,
                                            label: item.Title,
                                            icon: item.Icon,
                                            children: []
                                        }, node);
                                        this.$data.menuList.push(data_1.Data);
                                    }
                                    loading.close();
                                    this.$message("数据已修改!");
                                    this.$data.menuDialog.visable = false;
                                }
                                _a.label = 2;
                            case 2: return [2 /*return*/];
                        }
                    });
                }); });
            },
            nodeClick: function (data) {
                var parent = this.$data.menuList.find(function (x) { return x.Id === data.id; });
                var children = this.$data.menuList.filter(function (x) { return x.ParentId === data.id; });
                this.$data.tableData = children;
                this.$data.tableData.splice(0, 0, parent);
            },
            parentClassName: function (_a) {
                var row = _a.row, rowIndex = _a.rowIndex;
                if (rowIndex === 0) {
                    return 'parent-row';
                }
            },
            setOperation: function (data) {
                this.opDialog.visible = true;
                this.currentMenu = data;
                this.checkList = data.operations ? data.operations.map(function (op) { return op.Name; }) : [];
            },
            removeMenu: function (menu, node) {
                return __awaiter(this, void 0, void 0, function () {
                    var result, data, parent_1, children, index;
                    return __generator(this, function (_a) {
                        switch (_a.label) {
                            case 0: return [4 /*yield*/, this.$confirm("确定删除此菜单及其下菜单么?", "删除菜单")];
                            case 1:
                                result = _a.sent();
                                if (!(result == 'confirm')) return [3 /*break*/, 3];
                                return [4 /*yield*/, api_1.default.system.deleteMenu(menu.id)];
                            case 2:
                                data = _a.sent();
                                if (data.Success) {
                                    parent_1 = node.parent;
                                    children = parent_1.data.children;
                                    index = children.findIndex(function (d) { return d.id === menu.id; });
                                    children.splice(index, 1);
                                    this.$message("菜单已删除");
                                }
                                _a.label = 3;
                            case 3: return [2 /*return*/];
                        }
                    });
                });
            },
            handleDrop: function (draggingNode, dropNode, dropType) {
                return __awaiter(this, void 0, void 0, function () {
                    var menu, target, result;
                    return __generator(this, function (_a) {
                        switch (_a.label) {
                            case 0:
                                menu = this.$data.menuList.find(function (x) { return x.Id === draggingNode.data.id; });
                                target = this.$data.menuList.find(function (x) { return x.Id === dropNode.data.id; });
                                if (dropType === 'inner') {
                                    menu.ParentId = target.Id;
                                }
                                else {
                                    menu.ParentId = target.ParentId;
                                }
                                menu.Order = target.Id;
                                target.Order = menu.Id;
                                menu.ParentMenu = null;
                                target.ParentMenu = null;
                                return [4 /*yield*/, Promise.all([api_1.default.system.setMenu(menu), api_1.default.system.setMenu(target)])];
                            case 1:
                                result = _a.sent();
                                this.$message("数据已修改");
                                return [2 /*return*/];
                        }
                    });
                });
            },
            saveOperation: function () {
                return __awaiter(this, void 0, void 0, function () {
                    var ids, result;
                    var _this = this;
                    return __generator(this, function (_a) {
                        switch (_a.label) {
                            case 0:
                                ids = this.checkList.map(function (c) { return _this.operationList.find(function (p) { return p.Name === c; }).Id; });
                                return [4 /*yield*/, api_1.default.system.saveMenuOperation(this.currentMenu.id, ids)];
                            case 1:
                                result = _a.sent();
                                this.opDialog.visible = false;
                                this.$message("数据已修改");
                                return [2 /*return*/];
                        }
                    });
                });
            },
        }
    });
});
//# sourceMappingURL=MenuManager.js.map