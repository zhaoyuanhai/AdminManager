import api from 'api';

VueInit({
    data: {
        title: "用户",
        tableData: [],
        formInline: {},
        modelForm: {},
        rules: {

        }
    },
    async mounted() {
        let result = await api.system.getUserList({ PageIndex: 1, PageSize: 10 });
        this.$data.tableData = result.Data.Datas;
    },
    methods: {
        _create() {

        },

        handleClose(done) {
            this.$confirm('确认关闭？')
                .then(_ => {
                    done();
                })
                .catch(_ => { });
        },

        btnSubmit() {

        }
    }
});