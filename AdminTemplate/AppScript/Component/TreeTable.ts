import Vue from 'vue';
import common from 'common';

Vue.component("TreeTable", {
    data() {
        return {
            tableData: this.orderBy(this.$props.data)
        };
    },
    props: ["data", "name", "idName", "parentName"],
    mounted() {

    },
    methods: {
        /**
         * 获取缩进
         * @param item 对象
         */
        getIndent(item) {
            function recursion(item, index = 0): number {
                var r = this.tableData.find(x => x[this.idName] === item[this.parentName]);
                if (r) {
                    return recursion.call(this, r, ++index);
                }
                return index;
            }

            var arr = [];
            if (item[this.parentName]) {
                var r = recursion.call(this, item);
                for (let i = 0; i < r; i++) {
                    arr.push("");
                }
            }

            return arr;
        },

        /**
         * 排序树形结构
         * @param data 需要排序的数据
         */
        orderBy(data: Array<any>) {
            var temp = Array.from(data).map(function (item) {
                let obj = {
                    _expanded: true,
                    _isShow: true
                };

                for (let name in item) {
                    obj[name] = item[name];
                }
                return obj;
            });
            var _result = common.CompileTree(temp, null, this.idName, this.parentName);
            var result = common.Merge(_result);
            return result;
        },

        isFold(item) {
            return this.data.some(x => x[this.parentName] === item[this.idName]);
        },

        /**
         * 切换展开折叠
         * */
        toggle(item) {
            Array.from(this.tableData).forEach((x: any) => {
                if (x[this.parentName] === item[this.idName]) {
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
    template: `<el-table :data="tableData.filter(x=>x._isShow)" style="width: 100%">
                    <el-table-column label="展开/折叠">
                        <template slot-scope="scope">
                            <span v-for="item in getIndent(scope.row)">&nbsp;&nbsp;&nbsp;&nbsp;</span>
                                <i :class="{'el-icon-caret-right':scope.row._expanded===false,'el-icon-caret-bottom':scope.row._expanded===true }" style="cursor:pointer;" 
                                    v-if="isFold(scope.row)"
                                    @click="toggle(scope.row)"></i>
                                <i style="margin-left: 2px;" v-else></i>
                            <span>{{ scope.row[name] }}</span>
                        </template>
                    </el-table-column>
                    <slot></slot>
               </el-table>`
});