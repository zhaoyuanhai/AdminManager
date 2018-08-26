var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : new P(function (resolve) { resolve(result.value); }).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
define(["require", "exports", "api"], function (require, exports, api_1) {
    "use strict";
    Object.defineProperty(exports, "__esModule", { value: true });
    VueInit({
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
                this.$refs.form.validate((valid) => __awaiter(this, void 0, void 0, function* () {
                    if (valid) {
                        this.$data.isLogin = true;
                        var result = yield api_1.default.system.login(this.$data.form);
                        if (result.data.Success) {
                            location.href = "/#/Home/Default";
                        }
                        else {
                            alert(result.data.ErrorMsg);
                        }
                        this.$data.isLogin = false;
                    }
                    else {
                        console.log('error submit!!');
                        return false;
                    }
                }));
            }
        }
    });
});
//# sourceMappingURL=Login.js.map