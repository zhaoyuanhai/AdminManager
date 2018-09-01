using AdminModels.Entities;
using AdminServices.System;
using System.Web.Mvc;
using AdminCommon;

namespace AdminTemplate.Controllers
{
    public class SystemController : BaseController
    {
        readonly IMenuService menuService;
        readonly IUserService userService;
        readonly IRoleService roleService;

        public SystemController(IMenuService menuService,
            IUserService userService,
            IRoleService roleService)
        {
            this.menuService = menuService;
            this.userService = userService;
            this.roleService = roleService;
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

        /// <summary>
        /// 返回菜单列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult MenuList()
        {
            var menus = menuService.Select();
            return JsonSuccess(menus);
        }

        /// <summary>
        /// 创建菜单
        /// </summary>
        /// <returns></returns>
        public ActionResult CreateModifyMenu(T_Menu menu)
        {
            if (menu.Id <= 0)
            {
                var count = menuService.Add(menu);
                if (count >= 1)
                {
                    return JsonSuccess(menu);
                }
                return JsonError("添加失败");
            }
            else
            {
                var model = menuService.Find(menu.Id);
                UpdateModel(model, null, new string[] { "_CreateDate" });
                var count = menuService.Modify(model);
                if (count > 0)
                {
                    return JsonSuccess(model);
                }
                return JsonError("修改失败");
            }
        }

        /// <summary>
        /// 删除菜单
        /// </summary>
        /// <returns></returns>
        public ActionResult DeleteMenu(int id)
        {
            var count = menuService.Delete(id);
            if (count >= 1)
            {
                return JsonSuccess();
            }
            else
                return JsonError("删除失败");
        }

        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <returns></returns>
        public ActionResult GetUserList(PageingModel pageing)
        {
            var datas = userService.SelectPage(pageing.PageIndex, pageing.PageSize);
            return JsonSuccess(datas);
        }

        /// <summary>
        /// 获取角色集合
        /// </summary>
        /// <returns></returns>
        public ActionResult GetRoleList(PageingModel pageing)
        {
            var datas = roleService.SelectPage(pageing.PageIndex, pageing.PageSize);
            return JsonSuccess(datas);
        }
    }
}