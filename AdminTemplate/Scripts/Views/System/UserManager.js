define(["require", "exports", "api"], function (require, exports, api_1) {
    "use strict";
    Object.defineProperty(exports, "__esModule", { value: true });
    VueInit({
        data: {
            tableData: [],
            formInline: {}
        },
        async mounted() {
            let result = await api_1.default.system.getUserList({ PageIndex: 1, PageSize: 10 });
            this.$data.tableData = result.Data.Datas;
        }
    });
});
//# sourceMappingURL=UserManager.js.map