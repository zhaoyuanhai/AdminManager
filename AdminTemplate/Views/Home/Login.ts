import Vue from 'vue';
import Axios, { AxiosResponse } from 'axios';

interface ResModel {
    Success: boolean,
    Code: string,
    ErrorMsg: Array<{ Message: string, Description: string }>
}

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
            this.$refs.form.validate((valid) => {
                if (valid) {
                    Axios.post('/Home/Login', this.form).then(function (result: AxiosResponse<ResModel>) {
                        if (result.data.Success) {
                            location.href = "/";
                        } else {
                            alert(result.data.ErrorMsg);
                        }
                    });
                    alert('submit!');
                } else {
                    console.log('error submit!!');
                    return false;
                }
            });
        }
    }
})