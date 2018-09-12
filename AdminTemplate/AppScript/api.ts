import Axios from 'axios';
import * as models from 'models';

class Api {
    system = {
        /**
         * 设置菜单
         * @param menu
         * @returns {Promise} 结果
         */
        async setMenu(menu: models.MenuModel): Promise<ResponseModel<models.MenuModel>> {
            var result = await Axios.post<ResponseModel>("/System/CreateModifyMenu", menu);
            return result.data;
        },

        /**
         * 获取菜单
         * @returns {Promise} 结果
         */
        async getMenuList(): Promise<ResponseModel<models.MenuModel[]>> {
            var result = await Axios.get<ResponseModel>("/System/MenuList");
            return result.data;
        },

        /**
         * 删除菜单
         * @param id 菜单Id
         * @returns {Promise} 结果
         */
        async deleteMenu(id: number): Promise<ResponseModel> {
            var result = await Axios.get<ResponseModel>("/System/DeleteMenu", { params: { id: id } })
            return result.data;
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
        async getUserList(pageModel?: models.PageingModel): Promise<ResponseModel<models.PageingModel<models.UserModel>>> {
            var result = await Axios.get("/System/GetUserList", { params: pageModel });
            return result.data;
        },

        /**
         * 获取角色集合
         * @param pageModel
         */
        async getRoleList(pageModel?: models.PageingModel): Promise<ResponseModel<models.PageingModel<models.RoleModel>>> {
            var result = await Axios.get("/System/GetRoleList", { params: pageModel });
            return result.data;
        },

        /**
         * 获取功能集合
         * @param pageingModel
         */
        async getOperationList(pageingModel?: models.PageingModel): Promise<ResponseModel<models.PageingModel<models.OperationModel>>> {
            var result = await Axios.get("/System/OperationList", { params: pageingModel });
            return result.data;
        },
    }
}

var api = new Api();

export default api;

export var aa = 33;