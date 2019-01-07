define(["require", "exports", "vue", "axios"], function (require, exports, vue_1, axios_1) {
    "use strict";
    Object.defineProperty(exports, "__esModule", { value: true });
    vue_1.default.component("DataQuery", {
        data: function () {
            return {
                total: 0,
                pageIndex: 1,
                pageSize: 10,
            };
        },
        props: ["url", "query"],
        mounted: function () {
            this.queryData();
        },
        methods: {
            pageingChange: function () {
                this.queryData(this.pageIndex, this.pageSize);
            },
            pageingSizeChange: function () {
                this.queryData(this.pageIndex, this.pageSize);
            },
            reload: function () {
                this.queryData(this.pageIndex, this.pageSize);
            },
            queryData: function (pageIndex, pageSize) {
                var _this = this;
                if (pageIndex === void 0) { pageIndex = 1; }
                if (pageSize === void 0) { pageSize = 10; }
                var data = {
                    pageIndex: pageIndex,
                    pageSize: pageSize
                };
                for (var name in this.query) {
                    if (this.query[name])
                        data[name] = this.query[name];
                }
                axios_1.default.get(this.url, { params: data }).then(function (res) {
                    _this.$emit('input', res.data.Data.Datas);
                    _this.total = res.data.Data.Total;
                });
            }
        },
        template: "<div>\n                <slot></slot>\n                <el-pagination :background=\"false\"\n                               style=\"text-align:center;border-bottom:1px solid #f1f1f1\"\n                               layout=\"total, sizes, prev, pager, next, jumper\"\n                               :current-page=\"pageIndex\"\n                               :page-size=\"pageSize\"\n                               @current-change=\"pageingChange\"\n                               @size-change=\"pageingSizeChange\"\n                               :total=\"total\">\n                </el-pagination>\n               </div>"
    });
});
//# sourceMappingURL=DataQuery.js.map