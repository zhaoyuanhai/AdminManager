import api from 'api';

VueInit({
    data: {
        tableData: [],
        formInline: {}
    },
    async mounted() {
        var result = await api.system.getOperationList();
        this.$data.tableData = result.Data.Datas;
    }
});