using AdminModels.Customs;
using AdminModels.Entities;
using AdminServices.System;
using System.Web.Mvc;

namespace AdminTemplate.Controllers
{
    public class SystemController : BaseController
    {
        private readonly IMenuService menuService;
        private readonly IUserService userService;
        private readonly IRoleService roleService;
        private readonly IOperationService operationService;

        public SystemController(IMenuService menuService,
            IUserService userService,
            IRoleService roleService,
            IOperationService operationService)
        {
            this.menuService = menuService;
            this.userService = userService;
            this.roleService = roleService;
            this.operationService = operationService;
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
        public ActionResult OperationManager() => View();

        //[Authorize(Roles = "admin")]
        public ActionResult Config() => View();

        //[Authorize(Roles = "admin")]
        public ActionResult OperationLog() => View();

        #endregion 页面

        #region 菜单接口

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

        #endregion 菜单接口

        #region 用户接口

        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <returns></returns>
        public ActionResult GetUserList(PageingModel pageing, ConditionModelCollection conditions)
        {
            var datas = userService.SelectPage(conditions, pageing.PageIndex, pageing.PageSize);
            return JsonSuccess(datas);
        }

        /// <summary>
        /// 设置用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public ActionResult SetUser(T_User user)
        {
            int count = 0;
            if (user.Id > 0)
                count = userService.Modify(user);
            else
                count = userService.Add(user);

            if (count > 0)
                return JsonSuccess(user);
            else
                return JsonError("添加或者修改失败，请联系管理员");
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult DeleteUser(int id)
        {
            var count = userService.Delete(id);
            if (count > 0)
                return JsonSuccess();
            else
                return JsonError("删除用户失败");
        }

        #endregion 用户接口

        #region 角色接口

        /// <summary>
        /// 获取角色集合
        /// </summary>
        /// <returns></returns>
        public ActionResult GetRoleList(PageingModel pageing)
        {
            var datas = roleService.SelectPage(pageing.PageIndex, pageing.PageSize);
            return JsonSuccess(datas);
        }

        public ActionResult SetRole(T_Role role)
        {
            int count;
            if (role.Id <= 0)
                count = roleService.Add(role);
            else
                count = roleService.Modify(role);
            return JsonSuccess(role);
        }

        public ActionResult DeleteRole(int id)
        {
            var count = roleService.Delete(id);
            if (count > 0)
                return JsonSuccess();
            else
                return JsonError("删除失败，请联系管理员");
        }

        #endregion 角色接口

        #region 功能接口

        public ActionResult OperationList(PageingModel pageing)
        {
            var datas = operationService.SelectPage(pageing.PageIndex, pageing.PageSize);
            return JsonSuccess(datas);
        }

        #endregion 功能接口
    }
}