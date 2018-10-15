import Vue, { ComponentOptions } from 'vue';
import { DefaultData } from 'vue/types/options';

/**验证 */
interface Rule {
    //[name: string]: any;
    type?: "email" | "date" | "number" | "url" | "regexp" | "boolean" | "string";
    required?: boolean;
    message?: string;
    trigger?: "blur" | "change" | "click" | "input";
    pattern?: RegExp;
    validator?(rule, value, callback: (error?: Error) => void): any;
    min?: number;
    max?: number;
}

/**数据接口 */
interface DataInstance {
    [name: string]: any;
    /**验证 */
    rules?: { [name: string]: Array<Rule> };
    /**标题 */
    title?: string;
    /**表格数据 */
    tableData?: Array<any>;
    /**表单数据 */
    modelForm?: any;
    /**是否显示表单 */
    dialogVisible?: boolean;
}

type MyDatas<V> = DataInstance | ((this: V) => object);
type MyMethods<V> = {
    [key: string]: (this: V, ...args: any[]) => any;
    create?(): void;
    _create?(): void;

    modify?(): void;
    _modify?(): void;

    remove?(): void;
    _remove?(): void;

    submit?(): void;
    _submit?(): void;

    select?(): void;

    handleClose?(done: () => void): void;
};

declare global {
    var VueInit: (vueOption: ComponentOptions<Vue, MyDatas<Vue>, MyMethods<Vue>>) => void;
    var usePageJs: boolean;
    var pageUrl: string;

    interface Window {
        vue: Vue;
    }
}