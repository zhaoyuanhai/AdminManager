using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminTemplate.Controllers
{
    /// <summary>
    /// 有关文件的处理
    /// </summary>
    [AllowAnonymous]
    public class FileController : BaseController
    {
        /// <summary>
        /// 上传文件路径
        /// </summary>
        /// <returns></returns>
        [Route("File/Upload/{*path}")]
        public ActionResult Upload(HttpPostedFileWrapper file, string path)
        {
            return Json(true);
        }

        /// <summary>
        /// 一次上传多个文件
        /// </summary>
        /// <returns></returns>
        [Route("File/UploadMultiple/{*path}")]
        public ActionResult UploadMultiple(HttpFileCollectionWrapper files, string path)
        {
            return Json(true);
        }

        /// <summary>
        /// 下载文件
        /// </summary>
        /// <returns></returns>

        public ActionResult DownloadFile(int id)
        {
            return Json("");
        }

        /// <summary>
        /// 下载多个文件
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public ActionResult DownloadFiles(int ids)
        {
            return Json("");
        }
    }
}