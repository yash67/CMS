using CMS.BusinessEntities.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Project_Layout_Demo.Areas.Dealer.Controllers
{
    public class DealerController : Controller
    {
        // GET: Dealer/Dealer
        public async Task<ActionResult> Dashboard()
        {
            string addressurl = "api/Dealer/GetOrders";
            HttpResponseMessage Res = await GlobalVariables.client.GetAsync(addressurl);
            List<AddressDetailsViewModel> Orders = new List<AddressDetailsViewModel>();
            if (Res.IsSuccessStatusCode)
            {
                var MainMEnuResponse = Res.Content.ReadAsStringAsync().Result;
                Orders = JsonConvert.DeserializeObject<List<AddressDetailsViewModel>>(MainMEnuResponse);
            }
            return View(Orders);
        }
    }
}