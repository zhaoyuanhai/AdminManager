define(["require", "exports", "vue", "common"], function (require, exports, vue_1, common_1) {
    "use strict";
    Object.defineProperty(exports, "__esModule", { value: true });
    vue_1.default.component("TreeTable", {
        data: function () {
            return {
                tableData: this.orderBy(this.$props.data)
            };
        },
        props: ["data", "name", "idName", "parentName"],
        mounted: function () {
        },
        methods: {
            /**
             * 获取缩进
             * @param item 对象
             */
            getIndent: function (item) {
                function recursion(item, index) {
                    var _this = this;
                    if (index === void 0) { index = 0; }
                    var r = this.tableData.find(function (x) { return x[_this.idName] === item[_this.parentName]; });
                    if (r) {
                        return recursion.call(this, r, ++index);
                    }
                    return index;
                }
                var arr = [];
                if (item[this.parentName]) {
                    var r = recursion.call(this, item);
                    for (var i = 0; i < r; i++) {
                        arr.push("");
                    }
                }
                return arr;
            },
            /**
             * 排序树形结构
             * @param data 需要排序的数据
             */
            orderBy: function (data) {
                var temp = Array.from(data).map(function (item) {
                    var obj = {
                        _expanded: true,
                        _isShow: true
                    };
                    for (var name_1 in item) {
                        obj[name_1] = item[name_1];
                    }
                    return obj;
                });
                var _result = common_1.default.CompileTree(temp, null, this.idName, this.parentName);
                var result = common_1.default.Merge(_result);
                return result;
            },
            isFold: function (item) {
                var _this = this;
                return this.data.some(function (x) { return x[_this.parentName] === item[_this.idName]; });
            },
            /**
             * 切换展开折叠
             * */
            toggle: function (item) {
                var _this = this;
                Array.from(this.tableData).forEach(function (x) {
                    if (x[_this.parentName] === item[_this.idName]) {
                        x._isShow = !item._expanded;
                    }
                });
                this.$set(item, "_expanded", !item._expanded);
            }
        },
        watch: {
            data: function (val) {
                this.tableData = this.orderBy(val);
            }
        },
        template: "<el-table :data=\"tableData.filter(x=>x._isShow)\" style=\"width: 100%\">\n                    <el-table-column label=\"\u5C55\u5F00/\u6298\u53E0\">\n                        <template slot-scope=\"scope\">\n                            <span v-for=\"item in getIndent(scope.row)\">&nbsp;&nbsp;&nbsp;&nbsp;</span>\n                                <i :class=\"{'el-icon-caret-right':scope.row._expanded===false,'el-icon-caret-bottom':scope.row._expanded===true }\" style=\"cursor:pointer;\" \n                                    v-if=\"isFold(scope.row)\"\n                                    @click=\"toggle(scope.row)\"></i>\n                                <i style=\"margin-left: 2px;\" v-else></i>\n                            <span>{{ scope.row[name] }}</span>\n                        </template>\n                    </el-table-column>\n                    <slot></slot>\n               </el-table>"
    });
});
//# sourceMappingURL=TreeTable.js.map