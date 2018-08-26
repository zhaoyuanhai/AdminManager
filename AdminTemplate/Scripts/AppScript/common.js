define(["require", "exports"], function (require, exports) {
    "use strict";
    Object.defineProperty(exports, "__esModule", { value: true });
    class Common {
        /**
         * 组织平面数据变成树形结构
         * @param array 平面结构的数据
         * @param fid 父节点的id值
         * @param idName Id字段名称
         * @param fidName 父Id字段名称
         * @param itemFactory
         * @param orderFn 排序函数
         */
        static CompileTree(array, fid, idName, fidName, itemFactory = null, orderFn = null) {
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
                    let obj = {
                        source: arr[i],
                        children: []
                    };
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
        static OrderByTree(arrTree, fid, idName, fidName, orderFn, isParent = false) {
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
        static Merge(array) {
            var arr = [];
            (function merge(array) {
                for (var i = 0; i < array.length; i++) {
                    arr.push(array[i].source);
                    merge(array[i].children);
                }
            })(array);
            return arr;
        }
        /**
         * 设置对象的属性为空字符串
         * @param obj 对象
         * @returns {void}
         */
        static SetObjectPropEmptyString(obj) {
            if (obj != null)
                for (let name in obj) {
                    if (typeof obj[name] === 'object') {
                        Common.SetObjectPropEmptyString(obj[name]);
                    }
                    else
                        obj[name] = "";
                }
        }
    }
    exports.default = Common;
});
//# sourceMappingURL=common.js.map