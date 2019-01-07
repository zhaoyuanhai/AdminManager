define(["require", "exports", "AppScript/Component/TableTreeColumn", "vue"], function (require, exports, TableTreeColumn_1, vue_1) {
    "use strict";
    Object.defineProperty(exports, "__esModule", { value: true });
    vue_1.default.component("el-table-tree-column", TableTreeColumn_1.default);
    VueInit({
        data: {
            title: "测试弹出框",
            tableData: [{
                    id: 2,
                    pid: 1,
                    date: '2016-05-04',
                    name: '王小虎',
                    address: '上海市普陀区金沙江路 1517 弄'
                }, {
                    id: 3,
                    pid: 1,
                    date: '2016-05-01',
                    name: '王小虎',
                    address: '上海市普陀区金沙江路 1519 弄'
                }, {
                    id: 4,
                    pid: 1,
                    date: '2016-05-03',
                    name: '王小虎',
                    address: '上海市普陀区金沙江路 1516 弄'
                }, {
                    id: 1,
                    pid: null,
                    date: '2016-05-02',
                    name: '王小虎111',
                    address: '上海市普陀区金沙江路 1518 弄'
                }, {
                    id: 5,
                    pid: 2,
                    date: '2016-05-03',
                    name: '王小虎222',
                    address: '上海市普陀区金沙江路 1516 弄'
                }, {
                    id: 6,
                    pid: 2,
                    date: '2016-05-03',
                    name: '王小虎222',
                    address: '上海市普陀区金沙江路 1516 弄'
                }, {
                    id: 7,
                    pid: 3,
                    date: '2016-05-03',
                    name: '王小虎222',
                    address: '上海市普陀区金沙江路 1516 弄'
                }],
            model: {
                menus: trees
            }
        },
        methods: {
            btnClick: function () {
                top.vue.$alert('这是一段内容', '标题名称', {
                    confirmButtonText: '确定'
                });
            },
            test: function () {
                var h = this.$createElement;
                var btn = h('el-button', {}, '按钮');
                this.$notify({
                    title: '标题名称',
                    message: h('i', { style: { color: "teal" } }, [btn])
                });
            }
        }
    });
});
//# sourceMappingURL=Default.js.map