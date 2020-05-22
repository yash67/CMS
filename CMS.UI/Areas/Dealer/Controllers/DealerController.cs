using CMS.BusinessEntities.ViewModel;
using CMS.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Project_Layout_Demo.Areas.Dealer.Controllers
{
    public class DealerController : Controller
    {
        private SendEmail sendEmail = new SendEmail();
      
       // GET: Dealer/Dealer
        [HttpGet]
        public async Task<ActionResult> Dashboard()
        {
            long id = Convert.ToInt64(Session["Did"]);
            string addressurl = "api/Dealer/GetOrders?id=" +id;
            HttpResponseMessage Res = await GlobalVariables.client.GetAsync(addressurl);
            List<AddressDetailsViewModel> Orders = new List<AddressDetailsViewModel>();
            if (Res.IsSuccessStatusCode)
            {
                var MainMEnuResponse = Res.Content.ReadAsStringAsync().Result;
                Orders = JsonConvert.DeserializeObject<List<AddressDetailsViewModel>>(MainMEnuResponse);
            }
            return View(Orders);
        }

        [HttpGet]
        public async Task<ActionResult> AddDealerCity()
        {
            string addressurl = "api/City/GetCities";
            List<CityViewModel> cities = new List<CityViewModel>();
            HttpResponseMessage Res = await GlobalVariables.client.GetAsync(addressurl);
            if (Res.IsSuccessStatusCode)
            {
                var MainMEnuResponse = Res.Content.ReadAsStringAsync().Result;
                cities = JsonConvert.DeserializeObject<List<CityViewModel>>(MainMEnuResponse);

            }
            ViewBag.Cities = cities;
            return View();
        }
       
        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Registration(DealerViewModel dealerViewModel)
        {
            List<DealerViewModel> dealers = new List<DealerViewModel>();
            HttpResponseMessage Response = await GlobalVariables.client.GetAsync("api/Dealer/CheckDealerEmail?email=" + dealerViewModel.Email);
            if (Response.IsSuccessStatusCode)
            {
                dealerViewModel.Password =  hash(dealerViewModel.Password);
                dealerViewModel.Password.Replace('+', ' ');
                dealerViewModel.CreatedDate = DateTime.Now;
                dealerViewModel.RoleId = 2;
                var stringContent = new StringContent(JsonConvert.SerializeObject(dealerViewModel), Encoding.UTF8, "application/json");
                var addressUri = new Uri("api/Dealer/InsertDealer", UriKind.Relative);
                var Res = GlobalVariables.client.PostAsync(addressUri, stringContent).Result;
                if (Res.IsSuccessStatusCode)
                {
                    string message = "<html><body>Your Account Successfully Created!!!<br><a href=\"LINK\">Click Here</a></body></html>";
                    var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, "/Dealer/Dealer/Verify?email=" + dealerViewModel.Email + "");
                    message = message.Replace("LINK", link);
                    bool flag = await sendEmail.SendMail(dealerViewModel.Email, "Verify", message);
                    TempData["Verifylink"] = "Successfully send link";
                    return RedirectToAction("LogIn", "User");
                }
            }
            else
            {
                ModelState.AddModelError("Exits", "Email is already exits!");
            }

            return View();
        }

        public string hash(string value)
        {
            return Convert.ToBase64String(
                System.Security.Cryptography.SHA256.Create()
                .ComputeHash(Encoding.UTF8.GetBytes(value))
                ).Replace('"', ' ');
        }

        [HttpGet]
        public async Task<ActionResult> Verify(string email)
        {
            string address = "api/Dealer/UpdateDealer?email=" + email;
            HttpResponseMessage Res = await GlobalVariables.client.GetAsync(address);
            if (Res.IsSuccessStatusCode)
            {
                //var MainMEnuResponse = Res.Content.ReadAsStringAsync().Result;
                return View("~/Areas/User/Views/User/Verify.cshtml");
            }
            else
            {
                return Content("Something Went Wrong");
            }
        }


      
    }
}