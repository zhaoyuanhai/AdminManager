import Vue from 'vue';
import api from 'api'
import Common from 'common';

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
    async mounted() {
        var data = await api.system.getMenuList();
        this.$data.menuList = data.Data;

        //设置菜单列表
        var treeData = Common.CompileTree(data.Data, null, "Id", "ParentId", (item, arr) => {
            return {
                id: item.Id,
                label: item.Title,
                icon: item.Icon,
                children: arr
            }
        });
        this.$data.menuTree = treeData;

        //设置添加菜单的数据
        var menus = data.Data.filter(x => x.ParentId == null).map(item => {
            return {
                name: item.Title,
                value: item.Id
            };
        });
    },
    methods: {
        createMenu() {
            Common.SetObjectPropEmptyString(this.$data.menuForm);
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
            } else {
                return true;
            }
        },
        allowDrag(draggingNode) {
            return draggingNode.data.label.indexOf('三级 3-2-2') === -1;
        }
    }
});