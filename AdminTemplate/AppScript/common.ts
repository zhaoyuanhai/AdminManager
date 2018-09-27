export default class Common {

    /**
     * 组织平面数据变成树形结构
     * @param T 数组类型项类型
     * @param M 组织成树形结构的类型
     * @param array 平面结构的数据
     * @param fid 父节点的id值
     * @param idName Id字段名称
     * @param fidName 父Id字段名称
     * @param itemFactory 
     * @param orderFn 排序函数
     */
    static CompileTree<T = any, M = { source: T, children: T }>(array: Array<T>, fid: any,
        idName: string,
        fidName: string,
        itemFactory: (item: T, children: Array<M>) => M = null,
        orderFn: (a: T, b: T) => number = null): Array<M> {
        var tempArr = [];
        for (var i = 0; i < array.length; i++) {
            if (array[i][fidName] == fid) {
                tempArr.push(array[i]);
            }
        }

        if (orderFn != null) {
            tempArr.sort(orderFn);
        }

        function tree(arr, objArr) {

            for (let i = 0; i < arr.length; i++) {
                let current = arr[i];

                let obj: any = {
                    source: arr[i],
                    children: []
                }
                if (itemFactory != null) {
                    obj = itemFactory(arr[i], []);
                }

                objArr.push(obj);
                let childArr = array.filter(function (x) { return x[fidName] == arr[i][idName]; });
                if (orderFn != null)
                    childArr.sort(orderFn);

                tree(childArr, obj.children);
            }
        }

        var objArr = [];
        tree(tempArr, objArr);
        return objArr;
    }

    /**
     * 排序已组织好的树
     * @param arrTree 树结构
     * @param fid 父Id字段值
     * @param idName 父Id字段名称
     * @param fidName 父字段名称
     * @param orderFn 排序函数
     * @param isParent 是否为父元素添加isParent字段
     */
    static OrderByTree(arrTree: Array<any>,
        fid: any,
        idName: string,
        fidName: string,
        orderFn: (a, b) => number,
        isParent: boolean = false) {
        if (!(arrTree instanceof Array))
            throw "必须为数组类型";

        var data = Common.CompileTree(arrTree, fid, idName, fidName, orderFn);

        var arr = [];
        function tree(data) {
            for (var i = 0; i < data.length; i++) {
                arr.push(data[i].source);
                if (data[i].children.length > 0) {
                    if (isParent)
                        arr[i].isParent = true;
                    tree(data[i].children);
                }
            }
        }

        tree(data);
        return arr;
    }

    /**
     * 合并已经组织好的树结构
     * @param array
     */
    static Merge(array: Array<any>): Array<any> {
        var arr = [];
        (function merge(array) {
            for (var i = 0; i < array.length; i++) {
                arr.push(array[i].source);
                merge(array[i].children);
            }
        })(array);
        return arr
    }

    /**
     * 设置对象的属性为空字符串
     * @param obj 对象
     * @returns {void}
     */
    static SetObjectPropEmptyString(obj: Object) {
        if (obj != null)
            for (let name in obj) {
                if (typeof obj[name] === 'object') {
                    Common.SetObjectPropEmptyString(obj[name]);
                } else
                    obj[name] = "";
            }
    }

    static SetObjectFrom(self, other) {
        for (let name in other) {
            self[name] = other[name];
        }
    }
}

export enum Color {
    loading = "rgba(0, 0, 0, 0.8)"
}