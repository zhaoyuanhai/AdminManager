var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : new P(function (resolve) { resolve(result.value); }).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
define(["require", "exports", "api", "common"], function (require, exports, api_1, common_1) {
    "use strict";
    Object.defineProperty(exports, "__esModule", { value: true });
    VueInit({
        data: {
            dialogVisible: false,
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
                ],
                Url: [
                    { required: true, message: "请输入连接地址", trigger: 'blur' }
                ]
            },
            menuTree: [],
            tableData: []
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
                });
                this.$data.menuTree = treeData;
                //设置添加菜单的数据
                var menus = data.Data.filter(x => x.ParentId == null).map(item => {
                    return {
                        name: item.Title,
                        value: item.Id
                    };
                });
            });
        },
        methods: {
            createMenu() {
                common_1.default.SetObjectPropEmptyString(this.$data.menuForm);
                this.$data.dialogVisible = true;
            },
            removeMenu(menu) {
            },
            append(data) {
                this.createMenu();
                //this.$data
            },
            remove(node, data) {
                const parent = node.parent;
                const children = parent.data.children || parent.data;
                const index = children.findIndex(d => d.id === data.id);
                children.splice(index, 1);
            },
            handleClose(done) {
                this.$confirm('确认关闭？')
                    .then(_ => {
                    done();
                })
                    .catch(_ => { });
            },
            btnSubmit() {
                this.$refs.menuForm.validate((isValid, fialFields) => {
                    if (isValid) {
                        this.$data.dialogVisible = false;
                    }
                });
            },
            handleDragStart(node, ev) {
                console.log('drag start', node);
            },
            handleDragEnter(draggingNode, dropNode, ev) {
                console.log('tree drag enter: ', dropNode.label);
            },
            handleDragLeave(draggingNode, dropNode, ev) {
                console.log('tree drag leave: ', dropNode.label);
            },
            handleDragOver(draggingNode, dropNode, ev) {
                console.log('tree drag over: ', dropNode.label);
            },
            handleDragEnd(draggingNode, dropNode, dropType, ev) {
                console.log('tree drag end: ', dropNode && dropNode.label, dropType);
            },
            handleDrop(draggingNode, dropNode, dropType, ev) {
                console.log('tree drop: ', dropNode.label, dropType);
            },
            allowDrop(draggingNode, dropNode, type) {
                if (dropNode.data.label === '二级 3-1') {
                    return type !== 'inner';
                }
                else {
                    return true;
                }
            },
            allowDrag(draggingNode) {
                return draggingNode.data.label.indexOf('三级 3-2-2') === -1;
            }
        }
    });
});
//# sourceMappingURL=MenuManager.js.map