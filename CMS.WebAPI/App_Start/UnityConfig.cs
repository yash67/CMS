using CMS.Business.Interface;
using CMS.Business.Manager;
using CMS.Business.UnityResolverHelper;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace CMS.WebAPI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.AddNewExtension<UnityResolverHelper>();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IUserManager, UserManager>();
            container.RegisterType<ICityManager, CityManager>();
            container.RegisterType<ICategoryManager, CategoryManager>();
            container.RegisterType<IServiceManager, ServiceManager>();
            container.RegisterType<IDealerManager, DealerManager>();


            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}