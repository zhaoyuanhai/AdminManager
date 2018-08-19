interface ResponseModel<T = any> {
    Success: boolean;
    Code: string;
    ErrorMsg: Array<{ Message: string, Description: string }>;
    Data: T[];
}