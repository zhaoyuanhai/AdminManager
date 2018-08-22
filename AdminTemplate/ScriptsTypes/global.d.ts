import Vue, { ComponentOptions } from 'vue';

declare global {
    var VueInit: (vueOption: ComponentOptions<Vue>) => void;
    var isPageJs: boolean;
    var pageUrl: string;
}