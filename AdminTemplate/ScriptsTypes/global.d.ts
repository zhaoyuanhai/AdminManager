import Vue, { ComponentOptions } from 'vue';
import { DefaultData } from 'vue/types/options';

interface MyData {
    dialogVisible: boolean;
}

declare global {
    var VueInit: (vueOption: ComponentOptions<Vue, DefaultData<MyData>>) => void;
    var usePageJs: boolean;
    var pageUrl: string;

    interface Window {
        vue: Vue;
    }
}