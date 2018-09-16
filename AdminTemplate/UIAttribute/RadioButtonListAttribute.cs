using System;
using System.Web.Mvc;

namespace AdminTemplate.UIAttribute
{
    [AttributeUsage(AttributeTargets.Property)]
    public class RadioButtonListAttribute : ListAttribute
    {
        public RadioButtonListAttribute(string listName)
            : base(listName)
        { }

        public override void OnMetadataCreated(ModelMetadata metadata)
        {
            base.OnMetadataCreated(metadata);
            metadata.TemplateHint = "RadioButtonList";
        }
    }
}