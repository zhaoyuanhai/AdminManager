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
    create?(this: V, ...args): any;
    _create?(this: V, ...args): any;

    modify?(this: V, ...args): any;
    _modify?(this: V, ...args): any;

    remove?(this: V, ...args): any;
    _remove?(this: V, ...args): any;

    submit?(this: V, ...args): any;
    _submit?(this: V, ...args): any;

    select?(this: V, ...args): any;

    handleClose?(done: () => void): void;
    dialogClose?(this: V, visable: boolean, done: () => void): void;
};

type CustomVueOption = ComponentOptions<Vue, MyDatas<Vue>, MyMethods<Vue>>;

declare global {
    var VueInit: (vueOption: CustomVueOption) => void;
    var usePageJs: boolean;
    var pageUrl: string;
    var vue: Vue;


    type TTTOption = {
        data: {},
        methods: {
            hello(this: {}, name: string)
        }
    };

    function TTT(t: TTTOption)

    interface Window {
        vue: Vue;
    }
}