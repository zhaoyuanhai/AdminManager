import api from 'api';

VueInit({
    data: {
        title: "用户",
        roleDialogTitle: "分配权限",
        tableData: [],
        query: { userName: "" },
        formInline: {},
        modelForm: {},
        roleDialogVisable: false,
        roles: [],
        roleModel: {
            id: 0,
            roles: []
        },
        rules: {
            UserName: [
                { required: true, message: "用户名必填", trigger: "blur" },
                { min: 3, max: 20, message: "用户名长度必须在3-20个字符之间", trigger: "blur" },
                {
                    validator: async function (rule, value, callback) {
                        if (vue.$data.modelForm.Id)
                            callback();
                        else {
                            var result = await api.system.checkUserName(value);
                            if (result.Success) {
                                callback();
                            } else {
                                callback(new Error(result.Errors[0].Message));
                            }
                        }
                    },
                    trigger: "blur"
                }
            ],
            RealName: [
                { required: true, message: "真实姓名必填", trigger: "blur" }
            ],
            Mobile: [
                { pattern: /^1[34578]\d{9}$/, message: '手机号格式错误', trigger: "blur" }
            ],
            Email: [
                { type: 'email', max: 50, message: "邮箱格式不正确", trigger: "blur" }
            ]
        }
    },
    async mounted() {
        let result = await api.system.getUserList({ PageIndex: 1, PageSize: 10 });
        this.$data.tableData = result.Data.Datas;

        let roleResult = await api.system.getRoleAllList();
        this.roles = roleResult.Data.map(m => {
            return {
                key: m.Id,
                label: m.Name
            };
        });
    },
    methods: {
        toBlean(value) {
            return (value == undefined || value == null || value == 0) === false;
        },
        showRoleDialog(model) {
            this.roleDialogTitle = model.UserName + "-分配权限";
            this.roleModel.id = model.Id;
            this.roleModel.roles = model.Roles.map(m => m.Id);
            this.roleDialogVisable = true;
        },
        search() {
            this.$refs.dq.reload();
        },
        async setRole() {
            var result = await api.system.setUserRoles(this.roleModel.id, this.roleModel.roles);
            if (result.Success) {
                this.$message.success("数据已保存");
                this.roleDialogVisable = false;
                this.$refs.dq.reload();
            } else {
                this.$message.error(result.FirstError.Message);
            }
        },
        async _submit() {
            var result = await api.system.setUser(this.$data.modelForm);
            if (result.Success) {
                this.dialogVisible = false;
                this.$message.success("数据已保存");
                this.$refs.dq.reload();
            }
        }
    }
});