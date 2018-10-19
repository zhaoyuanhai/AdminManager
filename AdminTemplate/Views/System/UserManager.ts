import api from 'api';

VueInit({
    data: {
        title: "用户",
        tableData: [],
        formInline: {},
        modelForm: {},
        rules: {
            userName: [
                { required: true, message: "用户名必填", trigger: "blur" },
                { min: 3, max: 20, message: "用户名长度必须在3-20个字符之间", trigger: "blur" },
                {
                    validator: async function (rule, value, callback) {
                        var result = await api.system.checkUserName(value);
                        if (result.Success) {
                            callback();
                        } else {
                            callback(new Error(result.Errors[0].Message));
                        }
                    },
                    trigger: "blur"
                }
            ],
            realName: [
                { required: true, message: "真实姓名必填", trigger: "blur" }
            ],
            mobile: [
                { pattern: /^1[34578]\d{9}$/, message: '手机号格式错误', trigger: "blur" }
            ],
            email: [
                { type: 'email', max: 50, message: "邮箱格式不正确", trigger: "blur" }
            ]
        }
    },
    async mounted() {
        let result = await api.system.getUserList({ PageIndex: 1, PageSize: 10 });
        this.$data.tableData = result.Data.Datas;
    },
    methods: {
        async _submit() {
            var result = await api.system.setUser(this.$data.modelForm);
            if (result.Success) {
                alert('ok');
            }
        }
    }
});