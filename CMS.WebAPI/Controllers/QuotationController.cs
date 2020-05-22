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
    public class QuotationController : ApiController
    {
        private IQuotationManager _dealerManager;

        public QuotationController(IQuotationManager dealerManager)
        {
            _dealerManager = dealerManager;
        }


        [HttpGet]
        public IHttpActionResult GetDealerCompanyList(long From, long To, long DealerProductId, long DealerServiceId)
        {
            List<QuotationViewModel> DealerCompanies = _dealerManager.GetDealerCompanyList(From,To,DealerProductId,DealerServiceId);
            if (DealerCompanies == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(DealerCompanies);
            }
        }

       
    }
}
