using System;
using System.Reflection;
using System.Text.RegularExpressions;

namespace AdminCommon
{
    /// <summary>
    /// Object对象的扩展
    /// </summary>
    public static class ObjectExtend
    {
        /// <summary>
        /// 复制当前对象的所有属性到目标对相中,按照名称进行赋值.
        /// 如果类型不匹配尝试转换,如果失败则报错;
        /// </summary>
        /// <param name="self"></param>
        /// <param name="target"></param>
        public static void CopyPropertiesTo(this object self, object target)
        {
            CopyPropertiesTo(self, target, new string[0]);
        }

        /// <summary>
        /// 复制当前对象的所有属性到目标对相中,按照名称进行赋值.
        /// 可以添加赋值的属性名称,或者过滤属性
        /// </summary>
        /// <param name="self">当前对象</param>
        /// <param name="target">目标属性</param>
        /// <param name="propertiesName">
        /// 需要赋值的属性名称,如果想要忽略某属性则使用["ignore properName"]的格式
        /// </param>
        public static void CopyPropertiesTo(this object self, object target, params string[] propertiesName)
        {
            if (self == null || target == null)
                throw new ArgumentException("self参数和target参数不能为null");

            var selfProperties = self.GetType().GetProperties();
            var targetType = target.GetType();
            var reg = new Regex("^ignore [_A-Za-z0-9]+$");

            void SetProperties(PropertyInfo property)
            {
                var targetProperty = targetType.GetProperty(property.Name, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
                if (targetProperty != null)
                {
                    if (targetProperty.PropertyType == property.PropertyType)
                    {
                        targetProperty.SetValue(target, property.GetValue(self));
                    }
                    else
                    {
                        var value = Convert.ChangeType(property.GetValue(self), targetProperty.PropertyType);
                        targetProperty.SetValue(target, value);
                    }
                }
            }

            foreach (var property in selfProperties)
            {
                if (propertiesName != null && propertiesName.Length > 0)
                {
                    foreach (var strProperty in propertiesName)
                    {
                        if (strProperty.StartsWith(" ") || strProperty.EndsWith(" "))
                        {
                            throw new ArgumentException("propertiesName 开头或者结尾不能包含空格");
                        }

                        if (reg.IsMatch(strProperty))
                            continue;

                        if (strProperty == property.Name)
                        {
                            SetProperties(property);
                        }
                    }
                }
                else
                {
                    SetProperties(property);
                }
            }
        }
    }
}
