import Vue, { ComponentOptions } from 'vue';

interface Window {
    router: any;
    getRouter: (router: any) => void;
    MenuCompent: any;
    [propName: string]: any;
}

declare global {
    var VueInit: (vueOption: ComponentOptions<Vue>) => void;
}