using AutoMapper;
using CMS.Business.Interface;
using CMS.BusinessEntities.ViewModel;
using CMS.Data.Database;
using CMS.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Business.Manager
{
    public class ServiceManager : IServiceManager
    {
        private IServiceRepository _serviceRepository;

        public ServiceManager(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public ServiceViewModel GetService(long serviceid)
        {
            var Service = _serviceRepository.GetService(serviceid);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CMS_ServiceMaster, ServiceViewModel>();
            });
            IMapper mapper = config.CreateMapper();
            var ServiceViewModel1 = mapper.Map<CMS_ServiceMaster, ServiceViewModel>(Service);
            return ServiceViewModel1;
        }

        public List<CMS_ServiceMaster> GetServices()
        {
            List<CMS_ServiceMaster> Services = _serviceRepository.GetServices();
            return Services;
        }
    }
}
