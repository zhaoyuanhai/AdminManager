using System.Web.Mvc;

namespace AdminTemplate.ModelBinding
{
    public class ConditionModelProviderFactory : ValueProviderFactory
    {
        public override IValueProvider GetValueProvider(ControllerContext controllerContext)
        {
            return new ConditionModeValueProvider();
        }
    }
}