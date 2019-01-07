using System;
using System.Globalization;
using System.Web.Mvc;

namespace AdminTemplate.ModelBinding
{
    public class ConditionModeValueProvider : IValueProvider
    {
        public bool ContainsPrefix(string prefix)
        {
            return prefix.ToLower().IndexOf("condition") > -1;
        }

        ValueProviderResult IValueProvider.GetValue(string key)
        {
            if (ContainsPrefix(key))
                return new ValueProviderResult("China", "China", CultureInfo.InvariantCulture);
            else
                return null;
        }
    }
}