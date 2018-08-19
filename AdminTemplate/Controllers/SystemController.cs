using System.Web.Mvc;

namespace AdminTemplate.Controllers
{
    public class SystemController : BaseController
    {
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
    }
}