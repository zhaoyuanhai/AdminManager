using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminTemplate.Mapping
{
    public class TabeEntityAttribute : Attribute
    {
        public string TableName { get; set; }
    }
}