(function (window) {
    const pages = [
        "/Pages/System/Abc"]


    for (let index = 0; i < pages; i++) {
        var url = pages[index];
        axios.get(url, {}, function (result) {

        });
    }



    const Foo = { template: '<div>foo</div>' }
    const Bar = { template: '<div>bar</div>' }

    const routes = [
        { path: '/foo', component: Foo },
        { path: '/bar', component: Bar }
    ]

    const router = new VueRouter({
        routes: routes // (缩写) 相当于 routes: routes
    });


    window.router = router;
})(window);