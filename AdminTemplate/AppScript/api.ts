import Axios from 'axios';
import * as models from 'models';

Axios.interceptors.request.use(config => {
    config.headers["X-Requested-With"] = "XMLHttpRequest";
    return config;
}, error => {
    console.log(error);
});

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

        async createOperation<T = any>(data: models.OperationModel): Promise<ResponseModel<T>> {
            var result = await Axios.post("/System/CreateOperation", data);
            return result.data;
        },

        async modifyOperation(data: models.OperationModel) {
            var result = await Axios.post("/System/ModifyOperation", data);
            return result.data;
        },

        async removeOperation(id: number): Promise<ResponseModel<any>> {
            var result = await Axios.delete("/System/RemoveOperation", { params: { id } });
            return result.data;
        },

        /**
         * 检查用户名是否存在
         * @param userName 用户名
         */
        async checkUserName(userName: string): Promise<ResponseModel<any>> {
            var result = await Axios.get("/System/CheckUserName", { params: { userName: userName } });
            return result.data;
        },

        /**
         * 设置用户
         * @param user 用户数据
         */
        async setUser(user: models.UserModel): Promise<ResponseModel<any>> {
            let result = await Axios.post("/System/SetUser", user);
            return result.data;
        }
    }

    current = {
        async get<T = any>(data?: { pageing?: models.PageingModel, condition?: models.EntityModel[] }): Promise<ResponseModel<T>> {
            let result = await Axios.get("", { params: data });
            return result.data;
        },

        async post(data: any): Promise<ResponseModel<any>> {
            let result = await Axios.post("", data);
            return result.data;
        },

        async delete(data: any): Promise<ResponseModel<any>> {
            let result = await Axios.delete("", data);
            return result.data;
        },

        async put(data: any): Promise<ResponseModel<any>> {
            let result = await Axios.put("", data);
            return result.data;
        }
    }
}

var api = new Api();

export default api;

export var aa = 33;