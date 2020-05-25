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

        [HttpPost]
        public IHttpActionResult InsertDealer(DealerViewModel dealerViewModel)
        {
            bool status = _dealerManager.InsertDealer(dealerViewModel);
            if (status == false)
            {
                return Json("Dealer Details not Inserted");
            }
            return Ok();
        }

        [HttpGet]
        public IHttpActionResult CheckDealerEmail(string email)
        {
            if (email == null)
            {
                return BadRequest("invalid data");
            }
            else
            {
                if (_dealerManager.CheckDealerEmail(email))
                {
                    return Ok();
                }
                return NotFound();
            }
        }

        [HttpGet]
        public IHttpActionResult UpdateDealer(string email)
        {
            bool status = _dealerManager.UpdateDealer(email);
            if (status == false)
            {
                return BadRequest();
            }
            return Ok(status);
        }

        [HttpGet]
        public IHttpActionResult AuthorizeDealer(string email, string password)
        {
            password.ToString().Trim('"');
            if (email == null)
            {
                return BadRequest("invalid data");
            }
            else
            {
               CMS_DealerInfo dealer = _dealerManager.AuthorizeDealer(email, password);
                if (dealer != null)
                {
                    return Ok(dealer);
                }
                return NotFound();
            }
        }

        [HttpPost]
        public IHttpActionResult InsertDealerCities(List<DealerCityViewModel> dealerCityViewModels)
        {
            bool status = _dealerManager.InsertDealerCities(dealerCityViewModels);
            if (status == false)
            {
                return Json("DealerCities not Inserted");
            }
            return Ok();
        }

        [HttpPost]
        public IHttpActionResult InsertDealerCategories(List<DealerCategoryViewModel> dealerCategoryViewModels)
        {
            bool status = _dealerManager.InsertDealerCategories(dealerCategoryViewModels);
            if (status == false)
            {
                return Json("DealerCategories not Inserted");
            }
            return Ok();
        }

        [HttpPost]
        public IHttpActionResult InsertDealerServices(List<DealerServiceViewModel> dealerServiceViewModels)
        {
            bool status = _dealerManager.InsertDealerServices(dealerServiceViewModels);
            if (status == false)
            {
                return Json("DealerServices not Inserted");
            }
            return Ok();
        }

        [HttpGet]
        public IHttpActionResult GetOrders(long id)
        {
            List<AddressDetailsViewModel> Orders = _dealerManager.GetOrders(id);
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
