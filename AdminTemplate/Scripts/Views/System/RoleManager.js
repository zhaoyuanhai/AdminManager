define(["require", "exports", "api"], function (require, exports, api_1) {
    "use strict";
    Object.defineProperty(exports, "__esModule", { value: true });
    VueInit({
        data: {
            tableData: [],
            formInline: {}
        },
        async mounted() {
            var result = await api_1.default.system.getRoleList();
            this.$data.tableData = result.Data.Datas;
        }
    });
});
//# sourceMappingURL=RoleManager.js.map