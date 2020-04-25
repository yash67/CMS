using CMS.Data.Database;
using CMS.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Data.Repository
{
    public class ServiceRepository : IServiceRepository
    {
        private CMSEntities cMSEntites;

        public ServiceRepository()
        {
            cMSEntites = new CMSEntities();
        }

        public List<CMS_ServiceMaster> GetServices()
        {
            List<CMS_ServiceMaster> Services = cMSEntites.CMS_ServiceMaster.ToList();
            return Services;
        }
    }
}
