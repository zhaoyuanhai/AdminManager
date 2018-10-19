using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AdminTemplate.Vue;

namespace AdminTemplate.ViewExtends
{
    public abstract class CustomWebViewPage<TModel> : System.Web.Mvc.WebViewPage<TModel>
    {
        public string ControllerName
        {
            get
            {
                return ViewContext.RouteData.Values["controller"].ToString();
            }
        }

        public string ActionName
        {
            get
            {
                return ViewContext.RouteData.Values["action"].ToString();
            }
        }

        public VueElementUIHelper ElementUI
        {
            get
            {
                return new VueElementUIHelper(Html);
            }
        }
    }
}