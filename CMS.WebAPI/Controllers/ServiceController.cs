﻿using CMS.Business.Interface;
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

        [HttpGet]
        public IHttpActionResult GetService(long serviceid)
        {
            ServiceViewModel Service = _serviceManager.GetService(serviceid);
            if (Service == null)
            {
                return NotFound();
            }
            return Ok(Service);
        }
    }
}
