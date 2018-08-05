using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdminServices;
using AdminServices.System;

namespace AdminTemplate.Controllers
{
    public class HomeController : Controller
    {
        readonly IUserService userService;

        //public HomeController()
        //{
        //    this.userService = DependencyResolver.Current.GetService<IUserService>();
        //}

        public HomeController(IUserService userService)
        {
            this.userService = userService;
        }

        public ActionResult Index()
        {
            var users = this.userService.Select();
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}