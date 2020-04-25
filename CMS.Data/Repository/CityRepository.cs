using CMS.Data.Database;
using CMS.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Data.Repository
{
    public class CityRepository : ICityRepository
    {
        private CMSEntities cMSEntities;
        public CityRepository()
        {
            cMSEntities = new CMSEntities();
        }
        public List<CMS_CityMaster> GetCities()
        {
            List<CMS_CityMaster> cities = cMSEntities.CMS_CityMaster.ToList();
            return cities;
        }

        public CMS_CityMaster GetCity(long cityid)
        {
            CMS_CityMaster city = cMSEntities.CMS_CityMaster.Find(cityid);
            return city;
        }
    }
}
