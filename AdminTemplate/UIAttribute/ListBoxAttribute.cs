using System;
using System.Web.Mvc;

namespace AdminTemplate.UIAttribute
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ListBoxAttribute : ListAttribute
    {
        public ListBoxAttribute(string listName) : base(listName)
        { }

        public override void OnMetadataCreated(ModelMetadata metadata)
        {
            base.OnMetadataCreated(metadata);
            metadata.TemplateHint = "ListBox";
        }
    }
}