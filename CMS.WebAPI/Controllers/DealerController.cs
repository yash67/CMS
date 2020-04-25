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
    public class DealerController : ApiController
    {
        private IDealerManager _dealerManager;

        public DealerController(IDealerManager dealerManager)
        {
            _dealerManager = dealerManager;
        }


        [HttpGet]
        public IHttpActionResult GetDealerCompanyList(long From, long To, long DealerProductId, long DealerServiceId)
        {
            List<DealerViewModel> DealerCompanies = _dealerManager.GetDealerCompanyList(From,To,DealerProductId,DealerServiceId);
            if (DealerCompanies == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(DealerCompanies);
            }
        }

        [HttpGet]
        public IHttpActionResult GetOrders()
        {
            List<AddressDetailsViewModel> Orders = _dealerManager.GetOrders();
            if (Orders == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(Orders);
            }
        }
    }
}
