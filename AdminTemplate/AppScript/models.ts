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

export interface RoleModel {
    Id: number;
    Name: string;
    Description: string;
}

export interface UserModel {
    Id: number;
    UserName: string;
    RealName: string;
    Mobile: string;
    LoginCount: number;
    Roles: RoleModel[]
}

export interface PageingModel<T = any> {
    PageIndex: number;
    PageSize: number;
    PageCount?: number;
    Datas?: Array<T>
}