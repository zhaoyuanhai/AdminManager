using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace AdminTemplate.ViewExtends
{
    public static class ViewExtend
    {
        private static IHtmlString UseTag(ViewContext context, string ext)
        {
            var server = context.HttpContext.Server;
            var routeData = context.RouteData;
            string controller = routeData.Values["controller"].ToString();
            string action = routeData.Values["action"].ToString();

            if (ext == ".js")
            {
                var vitruePath = $"/Scripts/Views/{controller}/{action}.js";
                if (File.Exists(server.MapPath("~" + vitruePath)))
                    return new MvcHtmlString($"<script src=\"{vitruePath}\"></script>");
            }
            else if (ext == ".css")
            {
                var vitruePath = $"/Views/{controller}/{action}.css";
                if (File.Exists(server.MapPath("~" + vitruePath)))
                    return new MvcHtmlString($"<link href=\"{vitruePath}\" rel=\"stylesheet\" />");
            }
            else if (string.IsNullOrWhiteSpace(ext))
            {
                return null;
            }
            else
            {
                throw new ArgumentException("ext参数只能为 .js or .css");
            }

            return null;
        }

        public static IHtmlString UsePageJs(this HtmlHelper htmlHelper)
        {
            return UseTag(htmlHelper.ViewContext, ".js");
        }

        public static IHtmlString UsePageCss(this HtmlHelper htmlHelper)
        {
            return UseTag(htmlHelper.ViewContext, ".css");
        }
    }
}