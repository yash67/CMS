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
    public class CityManager : ICityManager
    {
        private ICityRepository _cityRepository;
        public CityManager(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }
        public List<CMS_CityMaster> GetCities()
        {
            List<CMS_CityMaster> cities = _cityRepository.GetCities();
            return cities;
        }
    }
}
