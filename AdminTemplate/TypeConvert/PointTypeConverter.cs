using AdminTemplate.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Web;

namespace AdminTemplate.TypeConvert
{
    public class PointTypeConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string);
        }

        //public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        //{
        //    if (value is string)
        //    {
        //        return Point.Parse(value as string);
        //    }
        //    return base.ConvertFrom(context, culture, value);
        //}
    }
}