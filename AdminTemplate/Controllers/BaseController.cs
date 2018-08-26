using AdminTemplate.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace AdminTemplate.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        public BaseController()
        {

        }

        #region Json对象
        protected override JsonResult Json(object data, string contentType, Encoding contentEncoding)
        {
            return base.Json(data, contentType, contentEncoding, JsonRequestBehavior.AllowGet);
        }

        protected override JsonResult Json(object data, string contentType, Encoding contentEncoding, JsonRequestBehavior behavior)
        {
            return base.Json(data, contentType, contentEncoding, JsonRequestBehavior.AllowGet);
        }

        protected JsonResult JsonMessage(object data, bool success, string code, params string[] errorMsgs)
        {
            return Json(new JsonMessage()
            {
                Data = data,
                Success = success,
                Code = code,
                Errors = errorMsgs.Select(x => new ErrorMessage() { Message = x }).ToList()
            });
        }

        protected JsonResult JsonSuccess(object data, string code = null)
        {
            return JsonMessage(data, true, code);
        }

        protected JsonResult JsonSuccess(string code = null)
        {
            return JsonSuccess(null, code);
        }

        protected JsonResult JsonError(string code, params string[] errorMsgs)
        {
            return JsonMessage(null, false, code, errorMsgs);
        }

        protected JsonResult JsonError(params string[] errorMsgs)
        {
            return JsonError(null, errorMsgs);
        }

        protected JsonResult JsonError(string code, IList<ErrorMessage> errors)
        {
            return Json(new JsonMessage()
            {
                Code = code,
                Errors = errors
            });
        }
        #endregion
    }
}