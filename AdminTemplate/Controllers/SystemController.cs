using AdminServices.System;
using System.Web.Mvc;

namespace AdminTemplate.Controllers
{
    public class SystemController : BaseController
    {
        readonly IMenuService menuService;

        public SystemController(IMenuService menuService)
        {
            this.menuService = menuService;
        }

        #region 页面
        //[Authorize(Roles = "admin")]
        public ActionResult MenuManager() => View();

        //[Authorize(Roles = "admin")]
        public ActionResult UserManager() => View();

        //[Authorize(Roles = "admin")]
        public ActionResult AuthorityManager() => View();

        //[Authorize(Roles = "admin")]
        public ActionResult RoleManager() => View();

        //[Authorize(Roles = "admin")]
        public ActionResult UserGroupManager() => View();

        //[Authorize(Roles = "admin")]
        public ActionResult OperationLog() => View();
        #endregion

        [HttpGet]
        public ActionResult MenuList()
        {
            //menuService.SelectPage()
            return null;
            //return Json();
        }
    }
}