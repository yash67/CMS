using CMS.Business.Interface;
using CMS.Data.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CMS.WebAPI.Controllers
{
    public class ServiceController : ApiController
    {
        private IServiceManager _serviceManager;
        public ServiceController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }
        [HttpGet]
        public IHttpActionResult GetServices()
        {
            List<CMS_ServiceMaster> Services = _serviceManager.GetServices();
            if (Services == null)
            {
                return NotFound();                     
            }
            return Ok(Services);
        }
    }
}
