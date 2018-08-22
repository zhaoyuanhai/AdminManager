import Axios from 'axios';

class Api {
    system = {
        getMenuList() {
            return Axios.get<ResponseModel>("/System/", {});
        }
    } 
}

var api = new Api();

export default api;