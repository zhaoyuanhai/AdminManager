using AdminServicesRealization;
using Autofac;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AdminEngine
{
    /// <summary>
    /// 依赖注册
    /// </summary>
    public class ServiceDependencyRegistrar : IDependencyRegistrar
    {
        private string[] GetAssemblys
        {
            get
            {
                return new string[] {
                    nameof(AdminServices),
                    nameof(AdminServicesRealization),
                    nameof(AdminCommon) };
            }
        }

        /// <summary>
        /// 注册服务和接口
        /// </summary>
        /// <param name="builder">Container builder</param>
        /// <param name="typeFinder">Type finder</param>
        /// <param name="config">Config</param>
        public virtual void Register(ContainerBuilder builder, ITypeFinder typeFinder)
        {
            var dir = System.IO.Path.GetDirectoryName(this.GetType().Assembly.CodeBase).Replace("file:\\", string.Empty);

            var assemblys = GetAssemblys.Select(name => Assembly.LoadFrom($"{dir}/{name}.dll"));

            builder.RegisterAssemblyTypes(assemblys.ToArray())
                  .Where(w => w.Name.EndsWith("Service"))
                  .AsImplementedInterfaces().InstancePerRequest();
            //#region 服务层代码注册
            //builder.RegisterGeneric(typeof(BaseService<>)).As(typeof(IBaseService<>)).InstancePerLifetimeScope();
            //#region 权限相关
            //builder.RegisterType(typeof(AdminAccountService)).As(typeof(IAdminAccountService)).InstancePerLifetimeScope();
            //builder.RegisterType(typeof(AdminMenuService)).As(typeof(IAdminMenuService)).InstancePerLifetimeScope();

            //#endregion

            //#endregion
        }

        /// <summary>
        /// Order of this dependency registrar implementation
        /// </summary>
        public int Order
        {
            get { return 1; }
        }
    }
}