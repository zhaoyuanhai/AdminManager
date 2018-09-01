using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace AdminTemplate.JsonNet
{
    public class JsonNetResult : JsonResult
    {
        public JsonSerializerSettings Settings { get; private set; }

        public JsonNetResult()
        {
            this.Settings = new JsonSerializerSettings()
            {
                DateFormatString = "yyyy-MM-dd",
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                //ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
        }

        public override void ExecuteResult(ControllerContext context)
        {
            HttpResponseBase response = context.HttpContext.Response;
            response.ContentType = string.IsNullOrEmpty(this.ContentType) ? "application/json" : this.ContentType;

            if (this.ContentEncoding != null)
                response.ContentEncoding = this.ContentEncoding;
            if (this.Data == null)
                return;

            var scriptSerializer = JsonSerializer.Create(this.Settings);

            using (var sw = new StringWriter())
            {
                scriptSerializer.Serialize(sw, this.Data);
                response.Write(sw.ToString());
            }
        }
    }
}