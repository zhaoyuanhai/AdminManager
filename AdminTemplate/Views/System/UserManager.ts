﻿import api from 'api';

VueInit({
    data: {
        tableData: [],
        formInline: {}
    },
    async mounted() {
        let result = await api.system.getUserList({ PageIndex: 1, PageSize: 10 });
        this.$data.tableData = result.Data.Datas;
    }
});