import api from 'api';

VueInit({
    data: {
        tableData: [],
        formInline: {}
    },
    async mounted() {
        var result = await api.system.getRoleList();
        this.$data.tableData = result.Data.Datas;
    }
});