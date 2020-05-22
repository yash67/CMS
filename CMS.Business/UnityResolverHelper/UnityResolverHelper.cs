using CMS.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Extension;
using Unity;
using CMS.Data.Repository;

namespace CMS.Business.UnityResolverHelper
{
    public class UnityResolverHelper : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<IUserRepository, UserRepository>();
            Container.RegisterType<ICityRepository, CityRepository>();
            Container.RegisterType<ICategoryRepository, CategoryRepository>();
            Container.RegisterType<IServiceRepository, ServiceRepository>();
            Container.RegisterType<IQuotationRepository, QuotationRepository>();
            Container.RegisterType<IDealerRepository, DealerRepository>();



        }
    }
}
