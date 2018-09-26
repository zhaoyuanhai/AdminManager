import api from "api";

VueInit({
    data: {

    },
    async mounted() {
        var datas = await api.current.get();
        console.log(datas);
    }
})