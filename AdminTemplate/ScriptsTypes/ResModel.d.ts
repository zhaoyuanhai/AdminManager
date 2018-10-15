interface ResponseError {
    /**错误消息 */
    Message: string;
    /**详细描述 */
    Description: string;
}

interface ResponseModel<T = any> {
    /**是否调用成功 */
    Success: boolean;
    /**响应码 */
    Code: string;
    /**错误列表 */
    Errors: Array<ResponseError>;
    /**第一条错误 */
    FirstError: ResponseError;
    /**返回的对象 */
    Data: T;
}