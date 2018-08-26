VueInit({
    methods: {
        btnClick() {
            top.vue.$alert('这是一段内容', '标题名称', {
                confirmButtonText: '确定'
            });
        },
        test() {
            const h = this.$createElement;
            var btn = h('el-button', {}, '按钮');
            this.$notify({
                title: '标题名称',
                message: h('i', { style: { color: "teal" } }, [btn])
            });

            
        }
    }
})