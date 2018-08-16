using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdminServices;
using AdminServices.System;
using AdminTemplate.Models;
using AdminServices.Common;
using System.Web.Security;

namespace AdminTemplate.Controllers
{
    public class HomeController : BaseController
    {
        readonly IUserService userService;
        readonly IValidateCodeService validateCode;
        readonly string verCodeSeccionKey = "VerCode";

        public HomeController(IUserService userService, IValidateCodeService validateCode)
        {
            this.userService = userService;
            this.validateCode = validateCode;
        }

        #region 页面
        public ActionResult Index() => View();

        [AllowAnonymous]
        public ActionResult Login() => View();
        #endregion

        [AllowAnonymous]
        public ActionResult CodeImage()
        {
            var code = validateCode.CreateValidateCode(4);
            Session[verCodeSeccionKey] = code;
            var stream = validateCode.CreateValidateGraphic(code);
            return File(stream, "image/png");
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginModel model)
        {
            var result = userService.Login(model.UserName, model.Password);
            if (result)
            {
                FormsAuthentication.SetAuthCookie(model.UserName, true, "/");
                return JsonSuccess();
            }
            return JsonError("登陆失败，用户名或者密码错误");
        }

        public ActionResult Page(string path)
        {
            return View("~/Views/" + path + ".cshtml");
        }
    }
}