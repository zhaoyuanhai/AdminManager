import Vue from 'vue';
import api from 'api'
import Common, { Color } from 'common';
import Axios from 'axios';
import * as models from 'models';

interface NodeData {
    id: number;
    icon: string;
    label: string;
    children: Array<NodeData>
}

interface TreeNode extends NodeData {
    id: number;
    level: number;
    parent: TreeNode;
    data: NodeData;
    childNodes: Array<TreeNode>
}

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
    async mounted() {
        var data = await api.system.getMenuList();
        this.$data.menuList = data.Data;

        //设置菜单列表
        var treeData = Common.CompileTree<models.MenuModel, NodeData>(data.Data, null, "Id", "ParentId", (item, arr) => {
            return {
                id: item.Id,
                label: item.Title,
                icon: item.Icon,
                children: arr
            }
        }, (a, b) => a.Order - b.Order);
        this.$data.menuTree = treeData;
    },
    methods: {
        createMenu(parentMenu: NodeData) {
            Common.SetObjectPropEmptyString(this.$data.menuForm);
            if (parentMenu) {
                this.$data.menuForm.ParentId = parentMenu.id;
            }
            this.$data.dialogVisible = true;
        },
        modifyMenu(parentMenu: NodeData) {
            var menu = this.$data.menuList.find(x => x.Id == parentMenu.id);
            menu.ParentMenu = null;
            this.$data.menuForm = menu;
            this.$data.dialogVisible = true;
        },
        async removeMenu(menu: NodeData, node: TreeNode) {
            var result: any = await this.$confirm("确定删除此菜单及其下菜单么?", "删除菜单");
            if (result == 'confirm') {
                var data = await api.system.deleteMenu(menu.id);
                if (data.Success) {
                    const parent = node.parent;
                    const children = parent.data.children;//|| parent.data;
                    const index = children.findIndex(d => d.id === menu.id);
                    children.splice(index, 1);
                    this.$message("菜单已删除");
                }
            }
        },
        handleClose(done) {
            this.$confirm('确认关闭？')
                .then(_ => {
                    done();
                })
                .catch(_ => { });
        },
        btnSubmit() {
            this.$refs.menuForm.validate(async (isValid, fialFields) => {
                if (isValid) {
                    let loading = this.$loading({
                        target: this.$refs.menuDialog.$el,
                        background: Color.loading
                    });
                    let data = await api.system.setMenu(this.$data.menuForm);
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
                        } else {
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
            });
        },
        nodeClick(data: NodeData) {
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
        async handleDrop(draggingNode: TreeNode, dropNode: TreeNode, dropType) {
            var menu: models.MenuModel = this.$data.menuList.find(x => x.Id === draggingNode.data.id);
            var target: models.MenuModel = this.$data.menuList.find(x => x.Id === dropNode.data.id);

            if (dropType === 'inner') {
                menu.ParentId = target.Id;
            } else {
                menu.ParentId = target.ParentId;
            }

            menu.Order = target.Id;
            target.Order = menu.Id;

            menu.ParentMenu = null;
            target.ParentMenu = null;
            var result = await Axios.all([api.system.setMenu(menu), api.system.setMenu(target)]);
            this.$message("数据已修改");
        }
    }
});