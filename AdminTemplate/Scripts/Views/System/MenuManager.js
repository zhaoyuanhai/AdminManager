VueInit({
    data: {
        dialogVisible: false,
        menuForm: {
            name: "",
            icon: "",
            parentId: ""
        },
        data6: [{
                id: 1,
                label: '一级 1',
                children: [{
                        id: 4,
                        label: '二级 1-1',
                        children: [{
                                id: 9,
                                label: '三级 1-1-1'
                            }, {
                                id: 10,
                                label: '三级 1-1-2'
                            }]
                    }]
            }, {
                id: 2,
                label: '一级 2',
                children: [{
                        id: 5,
                        label: '二级 2-1'
                    }, {
                        id: 6,
                        label: '二级 2-2'
                    }]
            }, {
                id: 3,
                label: '一级 3',
                children: [{
                        id: 7,
                        label: '二级 3-1'
                    }, {
                        id: 8,
                        label: '二级 3-2',
                        children: [{
                                id: 11,
                                label: '三级 3-2-1'
                            }, {
                                id: 12,
                                label: '三级 3-2-2'
                            }, {
                                id: 13,
                                label: '三级 3-2-3'
                            }]
                    }]
            }],
        defaultProps: {
            children: 'children',
            label: 'label'
        }
    },
    mounted: function () {
    },
    methods: {
        createMenu: function () {
            this.$data.dialogVisible = true;
        },
        handleClose: function (done) {
            this.$confirm('确认关闭？')
                .then(function (_) {
                done();
            })["catch"](function (_) { });
        },
        handleDragStart: function (node, ev) {
            console.log('drag start', node);
        },
        handleDragEnter: function (draggingNode, dropNode, ev) {
            console.log('tree drag enter: ', dropNode.label);
        },
        handleDragLeave: function (draggingNode, dropNode, ev) {
            console.log('tree drag leave: ', dropNode.label);
        },
        handleDragOver: function (draggingNode, dropNode, ev) {
            console.log('tree drag over: ', dropNode.label);
        },
        handleDragEnd: function (draggingNode, dropNode, dropType, ev) {
            console.log('tree drag end: ', dropNode && dropNode.label, dropType);
        },
        handleDrop: function (draggingNode, dropNode, dropType, ev) {
            console.log('tree drop: ', dropNode.label, dropType);
        },
        allowDrop: function (draggingNode, dropNode, type) {
            if (dropNode.data.label === '二级 3-1') {
                return type !== 'inner';
            }
            else {
                return true;
            }
        },
        allowDrag: function (draggingNode) {
            return draggingNode.data.label.indexOf('三级 3-2-2') === -1;
        }
    }
});
//# sourceMappingURL=MenuManager.js.map