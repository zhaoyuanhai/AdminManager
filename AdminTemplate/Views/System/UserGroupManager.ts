import api from "api";

VueInit({
    data: {
        dialogVisible: false,
        title: "用户组",
        rules: {

        },
        formModel: {},
        formInline: {

        },
        tableData: []
    },
    async mounted() {
        var result = await api.current.get();
        this.tableData = result.Data;
    },
    methods: {
        _create(model) {
            alert(3);
        },

        _modify(model) {
            alert(3);
        },

        _remove(model) {
            alert(3);
        },

        btnSubmit() {
            
        }
    }
})