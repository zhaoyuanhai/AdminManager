import Axios from 'axios';

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
    ParentMenu: MenuModel;
}

class Api {
    system = {
        /**
         * 设置菜单
         * @param menu
         * @returns {Promise} 结果
         */
        setMenu(menu: MenuModel): Promise<ResponseModel<MenuModel>> {
            return new Promise((resolve, reject) => {
                Axios.post<ResponseModel>("/System/CreateModifyMenu", menu).then((result) => {
                    resolve(result.data);
                });
            });
        },

        /**
         * 获取菜单
         * @returns {Promise} 结果
         */
        getMenuList(): Promise<ResponseModel<MenuModel[]>> {
            return new Promise((resolve, reject) => {
                Axios.get<ResponseModel>("/System/MenuList").then(result => {
                    resolve(result.data);
                });
            });
        },

        /**
         * 删除菜单
         * @param id 菜单Id
         * @returns {Promise} 结果
         */
        deleteMenu(id: number): Promise<ResponseModel> {
            return new Promise((resolve, reject) => {
                Axios.get<ResponseModel>("/System/DeleteMenu", { params: { id: id } }).then(result => {
                    resolve(result.data);
                });
            });
        },

        /**
         * 登录接口
         * @param form
         * @returns {Promise} 结果
         */
        login<T = any>(form: LoginModel) {
            return Axios.post<ResponseModel<T>>('/Home/Login', form);
        }
    }
}

var api = new Api();

export default api;

export var aa = 33;