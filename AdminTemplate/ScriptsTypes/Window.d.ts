import Vue, { ComponentOptions } from 'vue';

interface Window {
    router: any;
    getRouter: (router: any) => void;
    MenuCompent: any;
}

declare global {
    var VueInit: (vueOption: ComponentOptions<Vue>) => void;
}