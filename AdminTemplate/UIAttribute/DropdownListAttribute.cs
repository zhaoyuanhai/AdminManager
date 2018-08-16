using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace AdminTemplate.UIAttribute
{
    [AttributeUsage(AttributeTargets.Property)]
    public class DropdownListAttribute : ListAttribute
    {
        public DropdownListAttribute(string listName) :
            base(listName)
        { }

        public override void OnMetadataCreated(ModelMetadata metadata)
        {
            base.OnMetadataCreated(metadata);
            metadata.TemplateHint = "DropdownList";
        }
    }
}