import Vue, { ComponentOptions } from 'vue';

declare global {
    var VueInit: (vueOption: ComponentOptions<Vue>) => void;
    var usePageJs: boolean;
    var pageUrl: string;

    interface Window {
        vue: Vue;
    }
}