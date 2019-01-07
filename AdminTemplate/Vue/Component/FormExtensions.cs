using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminTemplate.Vue.Component
{
    public static class FormExtensions
    {
        public static MvcVueForm BeginForm(this VueElementUIHelper helper)
        {
            return new MvcVueForm(helper.Html.ViewContext);
        }
    }

    public class MvcVueForm : IDisposable
    {
        private ViewContext viewContext;

        public MvcVueForm(ViewContext viewContext)
        {
            this.viewContext = viewContext;
            viewContext.Writer.Write("<el-form>");
        }

        public void Dispose()
        {
            viewContext.Writer.Write("</el-form>");
        }
    }
}