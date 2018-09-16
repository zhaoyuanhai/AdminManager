using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AdminTemplate
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //页面路由,不经过控制器,直接访问视图
            routes.MapRoute(
                name: "PageRouter",
                url: "Page/{*path}",
                defaults: new
                {
                    controller = "Home",
                    action = "Page"
                });

            //标准增删改查路由
            routes.MapRoute(
                name: "EntityRouter",
                url: "Entity/{controller}/{action}/{query}");

            //标准路由
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
