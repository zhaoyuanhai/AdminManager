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
            routes.RouteExistingFiles = true;
            routes.MapMvcAttributeRoutes();
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

            //标准增删改查路由,实体增删改查
            routes.MapRoute(
                name: "EntityRouter",
                url: "Entity/{action}/{entity}",
                defaults: new
                {
                    controller = "Entity"
                });

            //标准路由
            routes.MapRoute(
                name: "DefaultRouter",
                url: "{controller}/{action}/{id}",
                defaults: new
                {
                    controller = "Home",
                    action = "Index",
                    id = UrlParameter.Optional
                }
            );
        }
    }
}
