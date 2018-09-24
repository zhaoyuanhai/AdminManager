using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace AdminTemplate.MetadataProviders
{
    public class MyCustomModelMetadataProvider : DataAnnotationsModelMetadataProvider
    {
        protected override System.Web.Mvc.ModelMetadata CreateMetadata(IEnumerable<Attribute> attributes,
            Type containerType,
            Func<object> modelAccessor,
            Type modelType,
            string propertyName)
        {
            return base.CreateMetadata(attributes, containerType, modelAccessor, modelType, propertyName);
        }
    }
}