using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AdminEngine;
using AdminModels.Customs;
using AdminTemplate.MetadataProviders;
using AdminTemplate.ModelBinding;

namespace AdminTemplate
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //启用容器
            EngineContext.Initialize(false);

            //ModelMetadataProviders.Current = new MyCustomModelMetadataProvider();
            ValueProviderFactories.Factories.Insert(0, new ConditionModelProviderFactory());
            ModelBinders.Binders.Add(typeof(ConditionModel), new ConditionModeBinder());
            ModelBinders.Binders.Add(typeof(ConditionModelCollection), new ConditionModelCollectionBinder());
        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }
    }
}
