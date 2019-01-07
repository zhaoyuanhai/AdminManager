import Vue from 'vue';
import Axios from 'axios';

Vue.component("DataQuery", {
    data() {
        return {
            total: 0,
            pageIndex: 1,
            pageSize: 10,
        };
    },
    props: ["url", "query"],
    mounted() {
        this.queryData();
    },
    methods: {
        pageingChange() {
            this.queryData(this.pageIndex, this.pageSize);
        },
        pageingSizeChange() {
            this.queryData(this.pageIndex, this.pageSize);
        },
        reload() {
            this.queryData(this.pageIndex, this.pageSize);
        },
        queryData(pageIndex = 1, pageSize = 10) {
            var data = {
                pageIndex,
                pageSize
            };

            for (var name in this.query) {
                if (this.query[name])
                    data[name] = this.query[name];
            }

            Axios.get(this.url, { params: data }).then((res) => {
                this.$emit('input', res.data.Data.Datas);
                this.total = res.data.Data.Total;
            });
        }
    },
    template: `<div>
                <slot></slot>
                <el-pagination :background="false"
                               style="text-align:center;border-bottom:1px solid #f1f1f1"
                               layout="total, sizes, prev, pager, next, jumper"
                               :current-page="pageIndex"
                               :page-size="pageSize"
                               @current-change="pageingChange"
                               @size-change="pageingSizeChange"
                               :total="total">
                </el-pagination>
               </div>`
});