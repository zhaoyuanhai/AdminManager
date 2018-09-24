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

export interface OperationModel {
    Id: number
    Name: string
    Event: string
    Icon: string
    ClassName: string
    _CreateDate: Date
    _UpdateDate: Date
}

export interface PageingModel<T = any> {
    PageIndex: number;
    PageSize: number;
    PageCount?: number;
    Datas?: Array<T>
}

export interface EntityModel {
    Field: string;
    Value: any;
    Group?: string;
    Op: Operation;
}

export enum Operation {
    equal = 1,
    notequal = 2
}