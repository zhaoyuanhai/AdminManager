import Vue from 'vue';
import Axios, { AxiosResponse } from 'axios';

new Vue({
    el: "#v-app",
    data: {
        form: {
            userName: "",
            password: "",
            code: ""
        },
        rules: {
            userName: [{ required: true, message: "用户名必填" }],
            password: [{ required: true, message: "密码必填" }],
            code: [{ required: true, message: "验证码必填" }]
        }
    },
    methods: {
        imgClick: function (e) {
            e.target.src = e.target.getAttribute("data-src") + "?r=" + Math.random();
        },
        loginSubmit: function () {
            this.$refs.form.validate(async (valid) => {
                if (valid) {
                    Axios.post('/Home/Login', this.form).then(function (result: AxiosResponse<ResponseModel>) {
                        if (result.data.Success) {
                            location.href = "/";
                        } else {
                            alert(result.data.ErrorMsg);
                        }
                    });

                    //var result: AxiosResponse<ResponseModel> = await Axios.post('/Home/Login', this.form);
                    //if (result.data.Success) {
                    //    location.href = "/";
                    //} else {
                    //    alert(result.data.ErrorMsg);
                    //}
                } else {
                    console.log('error submit!!');
                    return false;
                }
            });
        }
    }
})