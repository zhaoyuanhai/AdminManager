import Vue, { ComponentOptions } from 'vue';
import 'jquery';

let vueOption: ComponentOptions<Vue> = {
    el: "#v-app",
    data: {},
    mounted() {

    },
    methods: {
        _menuClick(url, id) {
            location.href = url;
        },
        create() {

        },
        modify() {

        },
        delete() {

        },
        select() {

        }
    }
};

new Vue($.extend(true, vueOption, window.GetVueOption()));