import api from "api";

VueInit({
    data: {
        form: {
        }
    },
    async mounted() {
        var data = await api.current.get();
        console.log(data);
    },
    methods: {}
})