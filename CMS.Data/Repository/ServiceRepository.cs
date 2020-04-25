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

        public CMS_ServiceMaster GetService(long serviceid)
        {
            CMS_ServiceMaster Service = cMSEntites.CMS_ServiceMaster.Find(serviceid);
            return Service;
        }

        public List<CMS_ServiceMaster> GetServices()
        {
            List<CMS_ServiceMaster> Services = cMSEntites.CMS_ServiceMaster.ToList();
            return Services;
        }
    }
}
