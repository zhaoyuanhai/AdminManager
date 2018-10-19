using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;
using System.Text;

namespace AdminTemplate.Vue
{
    public abstract class OptionsBase
    {
        Type type;
        PropertyInfo[] propertyInfos;

        public string @ref { get; set; }

        public OptionsBase()
        {
            type = this.GetType();
            propertyInfos = type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
        }

        /// <summary>
        /// 获取属性字符串
        /// </summary>
        public string Attributes
        {
            get
            {
                List<string> attr = new List<string>();
                foreach (var prop in propertyInfos)
                {
                    string name, value;
                    if (prop.GetValue(this) != null)
                    {
                        name = HumpToShortline(prop.Name);
                        value = prop.GetValue(this).ToString();
                        if (value.Contains(":"))
                        {
                            var arr = value.Split(':');
                            name = $"v-bind:{name}{arr[0]}";
                            value = arr[1];
                            attr.Add($"{name}=\"" + value + "\"");
                        }
                        else if (value.Contains("@"))
                        {
                            var arr = value.Split('@');
                            name = $"v-on:{name}{arr[0]}";
                            value = arr[1];
                            attr.Add($"{name}=\"" + value + "\"");
                        }
                        else
                        {
                            attr.Add(name + "=\"" + value + "\"");
                        }
                    }
                }
                return attr.Count > 0 ? " " + string.Join(" ", attr) : string.Empty;
            }
        }

        /// <summary>
        /// 驼峰命名法转短横线
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public string HumpToShortline(string para)
        {
            StringBuilder sb = new StringBuilder();
            int temp = 0;//定位
            for (int i = 0; i < para.Length; i++)
            {
                var s = para[i].ToString();
                if (s == s.ToUpper())
                {
                    sb.Append("-" + s.ToLower());
                    temp += 1;
                }
                else
                    sb.Append(s);
            }
            return sb.ToString();
        }
    }
}