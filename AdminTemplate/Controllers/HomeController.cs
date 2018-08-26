using AdminServices.Common;
using AdminServices.System;
using AdminTemplate.Models;
using System.Web.Mvc;
using System.Web.Security;

namespace AdminTemplate.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IUserService userService;
        private readonly IValidateCodeService validateCode;
        private readonly string verCodeSeccionKey = "VerCode";

        public HomeController(IUserService userService, IValidateCodeService validateCode)
        {
            this.userService = userService;
            this.validateCode = validateCode;
        }

        #region 页面

        public ActionResult Default() => View();

        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index() => View();

        /// <summary>
        /// 登录页
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public ActionResult Login() => View();

        #endregion 页面

        /// <summary>
        /// 验证码
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public ActionResult CodeImage()
        {
            var code = validateCode.CreateValidateCode(4);
            Session[verCodeSeccionKey] = code;
            var stream = validateCode.CreateValidateGraphic(code);
            return File(stream, "image/png");
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 直接返回页面视图
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public ActionResult Page(string path)
        {
            return View("~/Views/" + path + ".cshtml");
        }
    }
}