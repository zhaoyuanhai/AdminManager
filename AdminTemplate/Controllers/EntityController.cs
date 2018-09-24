using AdminModels.Customs;
using AdminServices.System;
using AdminTemplate.Message;
using AdminTemplate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using myMedata = AdminTemplate.MetadataProviders;

namespace AdminTemplate.Controllers
{
    /// <summary>
    /// 根据实体 生成通用的页面处理
    /// 例如 增删改查 等.....
    /// </summary>
    public class EntityController : BaseController
    {
        public Type EntityType
        {
            get
            {
                var strEntity = this.RouteData.Values["Entity"]?.ToString();
                if (strEntity != null)
                {
                    return Type.GetType($"AdminModels.Entities.T_{strEntity},AdminModels");
                }
                return null;
            }
        }

        /// <summary>
        /// 动态执行方法，并返回结果
        /// </summary>
        /// <param name="methodName"></param>
        /// <param name="params"></param>
        /// <returns></returns>
        private object ExecuteMethod(string methodName, Type[] paramsType, params object[] @params)
        {
            if (EntityType == null)
            {
                return new JsonMessage()
                {
                    Success = false,
                    Errors = new ErrorMessage[] {
                        new ErrorMessage(){  Message = "未找到地址User,请检查名称是否正确" }
                    }
                };
            }
            var type = typeof(IEntityService<>).MakeGenericType(EntityType);
            var entityService = DependencyResolver.Current.GetService(type);
            var method = entityService.GetType().GetMethods().First(x =>
            {
                var ps = x.GetParameters();
                var b = x.Name == methodName &&
                ps.Length == @params.Length;

                for (var i = 0; i < ps.Length; i++)
                {
                    b = b && paramsType[i] == ps[i].ParameterType;
                }
                return b;
            });

            if (method == null)
                throw new Exception($"没有找到方法{methodName},请检查方法名是否正确，或者参数类型和数量是否正确");
            return method.Invoke(entityService, @params);
        }

        /// <summary>
        /// 返回当前类型的Metadata数据
        /// </summary>
        /// <param name="metadata">Metadata数据</param>
        /// <param name="level">深度</param>
        /// <returns></returns>
        private myMedata.ModelMetadata GetTypeMetadata(ModelMetadata metadata = null, int level = 0)
        {
            if (level >= 3)
                return null;
            level++;

            if (metadata == null)
            {
                metadata = ModelMetadataProviders.Current.GetMetadataForType(new Func<object>(() =>
                {
                    return null;
                }), EntityType);
            }

            var myMetadata = new myMedata.ModelMetadata()
            {
                DisplayName = metadata.DisplayName,
                PropertyName = metadata.PropertyName,
                DataTypeName = metadata.DataTypeName,
                ShortDisplayName = metadata.ShortDisplayName,
                Description = metadata.Description,
                IsRequired = metadata.IsRequired,
                IsReadOnly = metadata.IsReadOnly,
                Model = metadata.Model,
                Container = metadata.Container,
            };

            foreach (var item in metadata.Properties)
            {
                var data = GetTypeMetadata(item, level);
                if (data != null)
                    myMetadata.Properties.Add(data);
            }

            return myMetadata;
        }

        public ActionResult Query(PageingModel pageing, ConditionModelCollection condition)
        {
            if (Request.IsAjaxRequest())
            {
                var name = nameof(IEntityService<dynamic>.SelectPage);
                var result = ExecuteMethod(name,
                    new Type[] { typeof(IExpressionLambdaModel), typeof(int), typeof(int) },
                    condition as IExpressionLambdaModel, pageing.PageIndex, pageing.PageSize);
                return JsonSuccess(result);
            }
            return View();
        }

        [HttpGet]
        public ActionResult Add()
        {
            var model = Activator.CreateInstance(EntityType);
            if (Request.IsAjaxRequest())
            {
                return JsonSuccess(model);
            }
            return View("AddOrEdit", model);
        }

        [HttpPost]
        public ActionResult Add(EntityModel model)
        {
            return Json(true);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (Request.IsAjaxRequest())
            {
                var name = nameof(IEntityService<dynamic>.Find);
                var result = ExecuteMethod(name, new Type[] { typeof(object[]) }, new object[] { id });
                return JsonSuccess(result);
            }
            return View("AddOrEdit");
        }

        [HttpPost]
        public ActionResult Edit(EntityModel model)
        {
            return Json(true);
        }

        [HttpGet]
        public ActionResult Detial(int id)
        {
            if (Request.IsAjaxRequest())
            {
                var name = nameof(IEntityService<dynamic>.Find);
                var result = ExecuteMethod(name, new Type[] { typeof(object[]) }, new object[] { id });
                return JsonSuccess(result);
            }
            return View();
        }

        [HttpDelete]
        public ActionResult Delete(int[] ids)
        {
            var methodName = nameof(IEntityService<dynamic>.Delete);
            ExecuteMethod(methodName, new Type[] { typeof(IEnumerable<int>) }, ids);
            return JsonSuccess(true);
        }
    }
}