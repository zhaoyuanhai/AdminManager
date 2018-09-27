import api from "api";

VueInit({
    data: {
        dialogVisible: false,
        groupTitle: "添加用户组",
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
        handleClose() {

        },

        setGroup() {
            this.$data.dialogVisible = true;
        },
        edit() {
            this.$data.dialogVisible = true;
        },

        btnSubmit() {

        }
    }
})