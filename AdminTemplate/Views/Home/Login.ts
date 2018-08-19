import Vue from 'vue';
import Axios, { AxiosResponse } from 'axios';

new Vue({
    el: "#v-app",
    data: {
        isLogin: false,
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
                    this.$data.isLogin = true;
                    var result = await Axios.post<ResponseModel>('/Home/Login', this.form);
                    if (result.data.Success) {
                        location.href = "/";
                    } else {
                        alert(result.data.ErrorMsg);
                    }
                    this.$data.isLogin = false;
                } else {
                    console.log('error submit!!');
                    return false;
                }
            });
        }
    }
})