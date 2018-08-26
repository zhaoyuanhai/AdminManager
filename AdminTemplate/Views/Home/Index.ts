VueInit({
    mounted() {
        $("#_frame").height($(".el-main").height() - 1);
        if (location.hash) {
            $("#_frame").attr("src", location.hash.substring(1));
        }
        window.addEventListener("hashchange", function (hashChangeEvent) {
            $("#_frame").attr("src", location.hash.substring(1));
        });
        window.addEventListener("resize", function () {
            $("#_frame").height($(".el-main").height() - 1);
        });
    }
});