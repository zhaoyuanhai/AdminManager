using AdminModels.Customs;
using AdminTemplate.Models;
using System;
using System.Web.Mvc;

namespace AdminTemplate.Controllers
{
    /// <summary>
    /// 根据实体 生成通用的页面处理
    /// 例如 增删改查 等.....
    /// </summary>
    public class EntityController : Controller
    {
        public Type EntityType
        {
            get
            {
                var strEntity = this.RouteData.Values["Entity"]?.ToString();
                if (strEntity != null)
                {
                    return Type.GetType(strEntity);
                }
                return null;
            }
        }

        public ActionResult Query(PageingModel pageing, ConditionModel[] condition)
        {
            if (Request.IsAjaxRequest())
            {
                
            }
            return View();
        }

        [HttpGet]
        public ActionResult Add()
        {
            if (Request.IsAjaxRequest())
            {
            }
            return View("AddOrEdit");
        }

        [HttpPost]
        public ActionResult Add(EntityModel model)
        {
            return Json(true);
        }

        [HttpGet]
        public ActionResult Edit()
        {
            if (Request.IsAjaxRequest())
            {
            }
            return View("AddOrEdit");
        }

        [HttpPost]
        public ActionResult Edit(EntityModel model)
        {
            return Json(true);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            return Json(true);
        }
    }
}