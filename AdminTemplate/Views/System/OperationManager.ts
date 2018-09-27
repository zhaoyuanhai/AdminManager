import api from 'api';
import common from 'common';
import * as ms from 'Models';

VueInit({
    data: {
        tableData: [],
        formInline: {},
        modelTitle: "添加功能",
        dialogVisible: false,
        dataTotal: 0,
        formModel: {

        },
        rules: {
            Name: {
                required: true, message: "请输入名称", trigger: 'blur'
            },
            Event: {
                required: true, message: "请输入事件名", trigger: 'blur'
            }
        }
    },
    async mounted() {
        var result = await api.current.get<ms.PageingModel<ms.OperationModel>>();
        this.$data.tableData = result.Data.Datas;
        this.$data.dataTotal = result.Data.Total;
    },
    methods: {
        handleClose() {
            this.dialogVisible = false;
        },
        btnSubmit() {
            this.$refs.formModel.validate(async (isValid, fialFields) => {
                if (isValid) {
                    let result;
                    if (this.formModel.Id)
                        result = await api.system.modifyOperation(this.formModel);
                    else
                        result = await api.system.createOperation(this.formModel);

                    if (result.Success) {
                        if (this.formModel.Id) {
                            var model = this.tableData.find(x => x.Id === result.Data.Id);
                            common.SetObjectFrom(model, result.Data);
                        } else {
                            this.tableData.push(result.Data);
                        }
                        this.dialogVisible = false;
                    }
                }
            });
        },
        create() {
            this.dialogVisible = true;
        },
        modify(model) {
            this.dialogVisible = true;
            this.formModel = model;
        },
        async remove(model) {
            var confirm: any = await this.$confirm("确认删除此功能么?", "删除功能");
            if (confirm == "confirm") {
                var result = await api.system.removeOperation(model.Id);
                if (result.Success) {
                    var index = this.tableData.findIndex(x => x.Id === model.Id);
                    this.tableData.splice(index, 1);
                }
            }
        }
    }
});