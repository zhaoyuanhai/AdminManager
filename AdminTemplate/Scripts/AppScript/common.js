define(["require", "exports"], function (require, exports) {
    "use strict";
    Object.defineProperty(exports, "__esModule", { value: true });
    var Common = /** @class */ (function () {
        function Common() {
        }
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
        Common.CompileTree = function (array, fid, idName, fidName, itemFactory, orderFn) {
            if (itemFactory === void 0) { itemFactory = null; }
            if (orderFn === void 0) { orderFn = null; }
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
                var _loop_1 = function (i_1) {
                    var current = arr[i_1];
                    var obj = {
                        source: arr[i_1],
                        children: []
                    };
                    if (itemFactory != null) {
                        obj = itemFactory(arr[i_1], []);
                    }
                    objArr.push(obj);
                    var childArr = array.filter(function (x) { return x[fidName] == arr[i_1][idName]; });
                    if (orderFn != null)
                        childArr.sort(orderFn);
                    tree(childArr, obj.children);
                };
                for (var i_1 = 0; i_1 < arr.length; i_1++) {
                    _loop_1(i_1);
                }
            }
            var objArr = [];
            tree(tempArr, objArr);
            return objArr;
        };
        /**
         * 排序已组织好的树
         * @param arrTree 树结构
         * @param fid 父Id字段值
         * @param idName 父Id字段名称
         * @param fidName 父字段名称
         * @param orderFn 排序函数
         * @param isParent 是否为父元素添加isParent字段
         */
        Common.OrderByTree = function (arrTree, fid, idName, fidName, orderFn, isParent) {
            if (isParent === void 0) { isParent = false; }
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
        };
        /**
         * 合并已经组织好的树结构
         * @param array
         */
        Common.Merge = function (array) {
            var arr = [];
            (function merge(array) {
                for (var i = 0; i < array.length; i++) {
                    arr.push(array[i].source);
                    merge(array[i].children);
                }
            })(array);
            return arr;
        };
        /**
         * 设置对象的属性为空字符串
         * @param obj 对象
         * @returns {void}
         */
        Common.SetObjectPropEmptyString = function (obj) {
            if (obj != null)
                for (var name_1 in obj) {
                    if (typeof obj[name_1] === 'object') {
                        Common.SetObjectPropEmptyString(obj[name_1]);
                    }
                    else
                        obj[name_1] = "";
                }
        };
        /**
         * 将一个对象上的属性复制到自己身上,浅拷贝
         * @param self 当前对象
         * @param other 原对象
         */
        Common.SetObjectFrom = function (self, other) {
            for (var name_2 in other) {
                self[name_2] = other[name_2];
            }
        };
        return Common;
    }());
    exports.default = Common;
    var Color;
    (function (Color) {
        Color["loading"] = "rgba(0, 0, 0, 0.8)";
    })(Color = exports.Color || (exports.Color = {}));
});
//# sourceMappingURL=common.js.map