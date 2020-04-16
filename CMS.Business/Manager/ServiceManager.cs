using CMS.Business.Interface;
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

        public List<CMS_ServiceMaster> GetServices()
        {
            List<CMS_ServiceMaster> Services = _serviceRepository.GetServices();
            return Services;
        }
    }
}
