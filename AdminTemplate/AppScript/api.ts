import Axios from 'axios';
import * as models from 'models';

class Api {
    system = {
        /**
         * 设置菜单
         * @param menu
         * @returns {Promise} 结果
         */
        setMenu(menu: models.MenuModel): Promise<ResponseModel<models.MenuModel>> {
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
        getMenuList(): Promise<ResponseModel<models.MenuModel[]>> {
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
        login<T = any>(form: models.LoginModel) {
            return Axios.post<ResponseModel<T>>('/Home/Login', form);
        },

        /**
         * 获取用户集合
         * @param pageModel 分页的查询参数
         */
        getUserList(pageModel?: models.PageingModel): Promise<ResponseModel<models.PageingModel<models.UserModel>>> {
            return new Promise((resolve, reject) => {
                Axios.get("/System/GetUserList", { params: pageModel }).then(result => {
                    resolve(result.data);
                });
            });
        },

        /**
         * 获取角色集合
         * @param pageModel
         */
        getRoleList(pageModel?: models.PageingModel): Promise<ResponseModel<models.PageingModel<models.RoleModel>>> {
            return new Promise((resolve, reject) => {
                Axios.get("/System/GetRoleList", { params: pageModel }).then(result => {
                    resolve(result.data);
                });
            });
        }
    }
}

var api = new Api();

export default api;

export var aa = 33;