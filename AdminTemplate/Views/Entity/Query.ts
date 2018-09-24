import api from "api";

VueInit({
    data: {
        tableData: [],
        formInline: {}
    },
    async  mounted() {
        debugger;
        var result = await api.current.get({ pageing: { PageIndex: 1, PageSize: 10 } });
        this.tableData = result.Data;
    },
    methods: {
        
    }
});