"use strict";
exports.__esModule = true;
var vue_1 = require("vue");
var axios_1 = require("axios");
new vue_1["default"]({
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
            var _this = this;
            this.$refs.form.validate(function (valid) {
                if (valid) {
                    axios_1["default"].post('/Home/Login', _this.form).then(function (result) {
                        if (result.data.Success) {
                            location.href = "/";
                        }
                        else {
                            alert(result.data.ErrorMsg);
                        }
                    });
                    alert('submit!');
                }
                else {
                    console.log('error submit!!');
                    return false;
                }
            });
        }
    }
});
//# sourceMappingURL=Login.js.map