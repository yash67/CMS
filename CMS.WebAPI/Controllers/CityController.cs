using CMS.Business.Interface;
using CMS.BusinessEntities.ViewModel;
using CMS.Data.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CMS.WebAPI.Controllers
{
    public class CityController : ApiController
    {
        private ICityManager _cityManager;
        public CityController(ICityManager cityManager)
        {
            _cityManager = cityManager;
        }
        [HttpGet]
        public IHttpActionResult GetCities()
        {
            List<CMS_CityMaster> cities = _cityManager.GetCities();
            if(cities == null)
            {
                return NotFound();
            }
            return Ok(cities);
        }

        [HttpGet]
        public IHttpActionResult GetCity(long cityid)
        {
            CityViewModel city = _cityManager.GetCity(cityid);
            if (city == null)
            {
                return NotFound();
            }
            return Ok(city);
        }

    }
}
