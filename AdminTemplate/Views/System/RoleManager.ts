import api from 'api';

VueInit({
    data: {
        title: "角色",
        tableData: [],
        formInline: {},
        modelForm: {},
        rules: {
            Name: [
                { required: true, message: "角色名称必填", trigger: "blur" },
                { max: 20, message: "长度不能超过20个字符", trigger: "blur" },
                {
                    validator: async function (rule, value, callback) {
                        var result = await api.system.checkRoleName(value, vue.modelForm.Id);
                        if (result.Success) {
                            callback();
                        } else {
                            callback(new Error(result.Errors[0].Message));
                        }
                    },
                    trigger: "blur"
                }
            ],
            Description: [
                { max: 200, message: "长度不能超过200个字符", trigger: "blur" }
            ]
        }
    },
    async mounted() {
        var result = await api.system.getRoleList();
        this.$data.tableData = result.Data.Datas;
    },
    methods: {
        async _submit() {
            var result = await api.system.setRole(this.modelForm);
            if (result.Success) {
                alert("ok");
            }
        }
    }
});