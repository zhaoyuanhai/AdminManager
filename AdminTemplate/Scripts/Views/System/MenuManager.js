var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : new P(function (resolve) { resolve(result.value); }).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
define(["require", "exports", "api", "common", "axios"], function (require, exports, api_1, common_1, axios_1) {
    "use strict";
    Object.defineProperty(exports, "__esModule", { value: true });
    VueInit({
        data: {
            dialogVisible: false,
            isMenuLoading: true,
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
            tableData: []
        },
        computed: {
            parentName() {
                if (this.$data.menuForm.ParentId) {
                    var menu = this.$data.menuList.find(x => x.Id == this.$data.menuForm.ParentId);
                    return "/" + menu.Title;
                }
                return "/";
            },
            menuTitle() {
                return this.$data.menuForm.Id ? "编辑菜单" : "添加菜单";
            }
        },
        mounted() {
            return __awaiter(this, void 0, void 0, function* () {
                var data = yield api_1.default.system.getMenuList();
                this.$data.menuList = data.Data;
                //设置菜单列表
                var treeData = common_1.default.CompileTree(data.Data, null, "Id", "ParentId", (item, arr) => {
                    return {
                        id: item.Id,
                        label: item.Title,
                        icon: item.Icon,
                        children: arr
                    };
                }, (a, b) => a.Order - b.Order);
                this.$data.menuTree = treeData;
            });
        },
        methods: {
            createMenu(parentMenu) {
                common_1.default.SetObjectPropEmptyString(this.$data.menuForm);
                if (parentMenu) {
                    this.$data.menuForm.ParentId = parentMenu.id;
                }
                this.$data.dialogVisible = true;
            },
            modifyMenu(parentMenu) {
                var menu = this.$data.menuList.find(x => x.Id == parentMenu.id);
                menu.ParentMenu = null;
                this.$data.menuForm = menu;
                this.$data.dialogVisible = true;
            },
            removeMenu(menu, node) {
                return __awaiter(this, void 0, void 0, function* () {
                    var result = yield this.$confirm("确定删除此菜单及其下菜单么?", "删除菜单");
                    if (result == 'confirm') {
                        var data = yield api_1.default.system.deleteMenu(menu.id);
                        if (data.Success) {
                            const parent = node.parent;
                            const children = parent.data.children; //|| parent.data;
                            const index = children.findIndex(d => d.id === menu.id);
                            children.splice(index, 1);
                            this.$message("菜单已删除");
                        }
                    }
                });
            },
            handleClose(done) {
                this.$confirm('确认关闭？')
                    .then(_ => {
                    done();
                })
                    .catch(_ => { });
            },
            btnSubmit() {
                this.$refs.menuForm.validate((isValid, fialFields) => __awaiter(this, void 0, void 0, function* () {
                    if (isValid) {
                        let loading = this.$loading({
                            target: this.$refs.menuDialog.$el,
                            background: common_1.Color.loading
                        });
                        let data = yield api_1.default.system.setMenu(this.$data.menuForm);
                        if (data.Success) {
                            let item = data.Data;
                            if (this.$data.menuForm.Id) {
                                let node = this.$refs.menuTree.getNode(data.Data.Id);
                                node.data.label = item.Title;
                                node.data.icon = item.Icon;
                                let menu = this.$data.menuList.find(x => x.Id === data.Data.Id);
                                menu.Title = data.Data.Title;
                                menu.Url = data.Data.Url;
                                menu.Icon = data.Data.Icon;
                            }
                            else {
                                let node = data.Data.ParentId ?
                                    this.$refs.menuTree.getNode(data.Data.ParentId) :
                                    this.$refs.menuTree.root;
                                this.$refs.menuTree.append({
                                    id: item.Id,
                                    label: item.Title,
                                    icon: item.Icon,
                                    children: []
                                }, node);
                                this.$data.menuList.push(data.Data);
                            }
                            loading.close();
                            this.$message("数据已修改!");
                            this.$data.dialogVisible = false;
                        }
                    }
                }));
            },
            nodeClick(data) {
                var parent = this.$data.menuList.find(x => x.Id === data.id);
                var children = this.$data.menuList.filter(x => x.ParentId === data.id);
                this.$data.tableData = children;
                this.$data.tableData.splice(0, 0, parent);
            },
            parentClassName({ row, rowIndex }) {
                if (rowIndex === 0) {
                    return 'parent-row';
                }
            },
            handleDrop(draggingNode, dropNode, dropType) {
                return __awaiter(this, void 0, void 0, function* () {
                    console.log('tree drop: ', dropNode.label, dropType);
                    var menu = this.$data.menuList.find(x => x.Id === draggingNode.data.id);
                    var target = this.$data.menuList.find(x => x.Id === dropNode.data.id);
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
                    var result = yield axios_1.default.all([api_1.default.system.setMenu(menu), api_1.default.system.setMenu(target)]);
                    this.$message("数据已修改");
                });
            }
        }
    });
});
//# sourceMappingURL=MenuManager.js.map