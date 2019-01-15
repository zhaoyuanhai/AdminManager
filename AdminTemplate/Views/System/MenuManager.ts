import api, { ajax } from 'api'
import Common, { Color } from 'common';
import * as models from 'models';

interface NodeData {
    id: number;
    icon: string;
    label: string;
    children: Array<NodeData>,
    operations: Array<models.OperationModel>
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
        loading: {
            tree: true
        },
        treeLoading: true,
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

        var opList = await api.system.getOperationList({ PageSize: 20 });
        this.operationList = opList.Data.Datas;

        //设置菜单列表
        var treeData = Common.CompileTree<models.MenuModel, NodeData>(data.Data, null, "Id", "ParentId", (item, arr) => {
            return {
                id: item.Id,
                label: item.Title,
                icon: item.Icon,
                children: arr,
                operations: item.Operations
            }
        }, (a, b) => a.Order - b.Order);
        this.$data.menuTree = treeData;
        this.loading.tree = false;
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
            var result = await Promise.all([api.system.setMenu(menu), api.system.setMenu(target)]);
            this.$message("数据已修改");
        },
        setOperation(data: NodeData) {
            this.opDialog.visible = true;
            this.currentMenu = data;
            this.checkList = data.operations ? data.operations.map(op => op.Name) : [];
        },
        async saveOperation() {
            var ids = this.checkList.map(c => this.operationList.find(p => p.Name === c).Id);
            var result = await api.system.saveMenuOperation(this.currentMenu.id, ids);
            this.opDialog.visible = false;
            this.$message("数据已修改");
        }
    }
});