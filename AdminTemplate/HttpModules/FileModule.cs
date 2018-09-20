using AdminModels.Entities;
using AdminServices;
using System;
using System.Configuration;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace AdminTemplate.HttpModules
{
    public class FileModule : IHttpModule
    {
        private HttpApplication Context;

        private HttpServerUtility Server
        {
            get
            {
                return Context.Server;
            }
        }

        private HttpRequest Request
        {
            get
            {
                return Context.Request;
            }
        }

        private HttpResponse Response
        {
            get
            {
                return Context.Response;
            }
        }

        private readonly string FileRootPath;

        public FileModule()
        {
            FileRootPath = ConfigurationManager.AppSettings["FileRootPath"];
        }

        public void Dispose()
        {
        }

        public void Init(HttpApplication context)
        {
            this.Context = context;
            context.BeginRequest += Context_BeginRequest;
        }

        private void Context_BeginRequest(object sender, EventArgs e)
        {
            if (Request.Path.StartsWith(FileRootPath))
            {
                GenerateFile(Context.Request.Path);
                Response.End();
            }
        }

        /// <summary>
        /// 相应查找到的文件，查看目录下是否有此文件，如果没有在从数据库中查找，如果找到了就生成到对应的目录以便下次访问
        /// </summary>
        /// <param name="filePath">文件路径</param>
        private void GenerateFile(string filePath)
        {
            var fileService = DependencyResolver.Current.GetService<ISelectService<T_File>>();
            var absoultPath = Server.MapPath(filePath);

            if (!File.Exists(absoultPath))
            {
                var _path = filePath.Substring(FileRootPath.Length);
                var file = fileService.FirstOrDefault(x => x.Path == _path);
                if (file != null)
                {
                    using (var fileStream = new FileStream(Server.MapPath(filePath), FileMode.Create, FileAccess.Write))
                    {
                        fileStream.Write(file.Content, 0, file.Content.Length);
                    }
                }
            }

            if (File.Exists(absoultPath))
            {
                Response.WriteFile(absoultPath);
                return;
            }
            Response.Write("无法找到文件");
            Response.Flush();
            Response.End();
        }
    }
}