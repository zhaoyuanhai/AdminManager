import Axios from 'axios';

namespace model {
    export interface LoginModel {
        userName: string;
        password: string;
        code: string;
    }

    export interface MenuModel {
        Id: number;
        Title: string;
        ParentId: number;
        Icon: string;
        Url: string;
        Order: number;
    }
}

class Api {
    system = {
        getMenuList(): Promise<ResponseModel<model.MenuModel>> {
            return new Promise((resolve, reject) => {
                Axios.get<ResponseModel>("/System/MenuList", {}).then((result) => {
                    resolve(result.data);
                });
            });
        },
        /**
         * 登录接口
         * @param form
         */
        login<T = any>(form: model.LoginModel) {
            return Axios.post<ResponseModel<T>>('/Home/Login', form);
        }
    }
}

var api = new Api();

export default api;