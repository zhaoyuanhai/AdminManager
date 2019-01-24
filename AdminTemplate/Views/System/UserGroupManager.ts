import api from "api";

VueInit({
    data: {
        modelDialog: {
            title: "模块对象",
            visable: false
        },
        dialogVisible: false,
        title: "用户组",
        rules: {

        },
        modelForm: {},
        formInline: {

        },
        tableData: []
    },
    async mounted() {
        var result = await api.current.get();
        this.tableData = result.Data;
    },
    methods: {
        create(model) {
            this.modelDialog.visable = true;
        },

        modify(model) {
            this.modelDialog.visable = true;
        },

        remove(model) {
            alert(5);
        },

        submit(refForm) {
            alert(6);
        }
    }
})