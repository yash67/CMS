using CMS.BusinessEntities.ViewModel;
using CMS.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Project_Layout_Demo.Areas.User.Controllers
{
    public class UserController : Controller
    {
        private SendEmail sendEmail = new SendEmail();


        [HttpGet]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            //Session["Id"] = null;
            Session.Clear();
            return RedirectToAction("Login", "Home", new { area = "" });
        }

        [HttpGet]
        public async Task<ActionResult> DashBoard()
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
            string addressurl2 = "api/Category/GetCategories";
            List<CategoryViewModel> Categories = new List<CategoryViewModel>();
            HttpResponseMessage Res2 = await GlobalVariables.client.GetAsync(addressurl2);
            if (Res2.IsSuccessStatusCode)
            {
                var MainMEnuResponse = Res2.Content.ReadAsStringAsync().Result;
                Categories = JsonConvert.DeserializeObject<List<CategoryViewModel>>(MainMEnuResponse);

            }
            ViewBag.Categories = Categories;
            TempData["Categories1"] = Categories;

            string addressurl3 = "api/Service/GetServices";
            List<ServiceViewModel> Services = new List<ServiceViewModel>();
            HttpResponseMessage Res3 = await GlobalVariables.client.GetAsync(addressurl3);
            if (Res3.IsSuccessStatusCode)
            {
                var MainMEnuResponse = Res3.Content.ReadAsStringAsync().Result;
                Services = JsonConvert.DeserializeObject<List<ServiceViewModel>>(MainMEnuResponse);

            }
            ViewBag.Services = Services;
            return View();
            
        }

        [HttpPost]
        public async Task<ActionResult> QuoteList(FormCollection collection)
        {
            
                long From = Convert.ToInt64(collection["From"]);
            TempData["From"] = From;
                long To = Convert.ToInt64(collection["To"]);
            TempData["To"] = To;
            long CategoryId = Convert.ToInt64(collection["Category"]);
            TempData["CategoryId"] = CategoryId;
                long ServiceId = Convert.ToInt64(collection["Service"]);
            TempData["ServiceId"] = ServiceId;
                decimal Weight = Convert.ToDecimal(collection["weight"]);
                //ViewBag.Category = Category;

                string addressurl = "api/Dealer/GetDealerCompanyList?From=" + From + "&To=" + To + "&DealerProductId=" + CategoryId + "&DealerServiceId=" + ServiceId;
                HttpResponseMessage Res = await GlobalVariables.client.GetAsync(addressurl);
                List<DealerViewModel> dealers = new List<DealerViewModel>();
                if (Res.IsSuccessStatusCode)
                {
                    var MainMEnuResponse = Res.Content.ReadAsStringAsync().Result;
                    dealers = JsonConvert.DeserializeObject<List<DealerViewModel>>(MainMEnuResponse);
                }
                List<decimal> prices = new List<decimal>();
                foreach (DealerViewModel dealer in dealers)
                {
                    decimal price = dealer.PerCategoryPrice + dealer.PerServicePrice + dealer.PerKmPrice + dealer.PerKgPrice * Weight;
                    prices.Add(price);
                }
                TempData["Price"] = prices;
                TempData["Weight"] = Weight;
                return View(dealers);
            
        }
       
        // GET: User/User
        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Registration(UserViewModel userViewModel)
        {
            List<UserViewModel> users = new List<UserViewModel>();
            HttpResponseMessage Responce = await GlobalVariables.client.GetAsync("api/User/CheckUserEmail?chkemail=" + userViewModel.Email);
            if (Responce.IsSuccessStatusCode)
            {              
                userViewModel.Password = await hash(userViewModel.Password);
                userViewModel.Password.Replace('+', ' '); //.ToString().Replace('"','A'));  
                userViewModel.CreatedDate = DateTime.Now;
                userViewModel.RoleId = 3;
                var stringContent = new StringContent(JsonConvert.SerializeObject(userViewModel), Encoding.UTF8, "application/json");
                var addressUri = new Uri("api/User/InsertUser", UriKind.Relative);
                var Res = GlobalVariables.client.PostAsync(addressUri, stringContent).Result;
                if (Res.IsSuccessStatusCode)
                {   
                    string message = "<html><body>Your Account Successfully Created!!!<br><a href=\"LINK\">Click Here</a></body></html>";
                    var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, "/User/User/Verify?Email=" + userViewModel.Email + "");
                    message = message.Replace("LINK", link);
                    bool flag = await sendEmail.SendMail(userViewModel.Email, "Verify", message);
                    TempData["Verifylink"] = "Successfully send link";
                    return RedirectToAction("LogIn", "User");
                }
                
            }
            else
            {
                ModelState.AddModelError("Exits", "Email is already exits!");
            }
            return View("Registration", userViewModel);
        }

        public async Task<string> hash(string value)
        {
            //  System.Threading.Thread.Sleep(5000);
            string pass = value;
            //string address_url = "api/Users/HasePassword?password=" + pass;
            var response = await GlobalVariables.client.GetAsync("api/User/HashPassword?password=" + pass);
            if (response.IsSuccessStatusCode)
            {
                var hashpassword = response.Content.ReadAsStringAsync().Result;
                value = hashpassword.ToString().Trim('"');
            }
            // var fvalue = value;
            GlobalVariables.client.DefaultRequestHeaders.Clear();
            GlobalVariables.client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            // var stringContent = new StringContent(JsonConvert.SerializeObject(userViewModel), Encoding.UTF8, "application/json");
            return value;
        }

        [HttpGet]
        public async Task<ActionResult> Verify(string email)
        {
           
            string address = "api/User/UpdateUser?Email=" + email;
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

        [HttpGet]
        public async Task<ActionResult> AddressDetails()
        {
            if (Session["Email"] == null)
            {
                return RedirectToAction("Login", "Home", new { area = "" });
            }
            long From = Convert.ToInt64(TempData["From"].ToString());
            string addressurl = "api/City/GetCity?cityId=" + From;
            HttpResponseMessage Res = await GlobalVariables.client.GetAsync(addressurl);
            CityViewModel city = new CityViewModel();
            if (Res.IsSuccessStatusCode)
            {
                var MainMEnuResponse = Res.Content.ReadAsStringAsync().Result;
                city = JsonConvert.DeserializeObject<CityViewModel>(MainMEnuResponse);
            }
            ViewBag.From = city.CityName;
            long To = Convert.ToInt64(TempData["To"].ToString());
            addressurl = "api/City/GetCity?cityId=" + To;
            Res = await GlobalVariables.client.GetAsync(addressurl);
            if (Res.IsSuccessStatusCode)
            {
                var MainMEnuResponse = Res.Content.ReadAsStringAsync().Result;
                city = JsonConvert.DeserializeObject<CityViewModel>(MainMEnuResponse);
            }
            ViewBag.To = city.CityName;
            return View();
        }

        [HttpPost]
        public ActionResult Details(long dealerid, decimal price)
        {
            Session["dealerid"] = dealerid;
            TempData["Price"] = price;
            return RedirectToAction("AddressDetails");
        }

        [HttpPost]
        public ActionResult AddressDetails(AddressDetailsViewModel OrderInfo)
        {
            OrderInfo.CreatedDate = DateTime.Now;
            OrderInfo.UserId = Convert.ToInt64(Session["UID"]);
            OrderInfo.DealerId = Convert.ToInt64(Session["dealerid"]);
            OrderInfo.DealerProductId = Convert.ToInt64(TempData["CategoryId"]);
            OrderInfo.DealerServiceId = Convert.ToInt64(TempData["ServiceId"]);
            OrderInfo.PackageWeight = Convert.ToDecimal(TempData["Weight"]);
            OrderInfo.Price = Convert.ToDecimal(TempData["Price"]);
            TempData["Order"] = OrderInfo;
            return RedirectToAction("ShippingDetails", "User");
        }
        [HttpGet]
        public async Task<ActionResult> ShippingDetails()
        {
            long ServiceId = Convert.ToInt64(TempData["ServiceId"].ToString());
            string addressurl = "api/Service/GetService?serviceId=" + ServiceId;
            ServiceViewModel service = new ServiceViewModel();
            HttpResponseMessage Res = await GlobalVariables.client.GetAsync(addressurl);
            if (Res.IsSuccessStatusCode)
            {
                var MainMEnuResponse = Res.Content.ReadAsStringAsync().Result;
                service = JsonConvert.DeserializeObject<ServiceViewModel>(MainMEnuResponse);
            }
            ViewBag.Service = service.ServiceName;
            long CategoryId = Convert.ToInt64(TempData["CategoryId"].ToString());
            addressurl = "api/Category/GetCategory?categoryId=" + CategoryId;
            CategoryViewModel category = new CategoryViewModel();
            Res = await GlobalVariables.client.GetAsync(addressurl);
            if (Res.IsSuccessStatusCode)
            {
                var MainMEnuResponse = Res.Content.ReadAsStringAsync().Result;
                category = JsonConvert.DeserializeObject<CategoryViewModel>(MainMEnuResponse);
            }
            ViewBag.Category = category.CategoryName;
            return View();
        }

        [HttpPost]
        public ActionResult ShippingDetails(string confirm)
        {
            AddressDetailsViewModel OrderInfo = (AddressDetailsViewModel)TempData["Order"];
            var stringContent = new StringContent(JsonConvert.SerializeObject(OrderInfo), Encoding.UTF8, "application/json");
            var addressUri = new Uri("api/User/InsertAddressDetails", UriKind.Relative);
            var Res = GlobalVariables.client.PostAsync(addressUri, stringContent).Result;
            if (Res.IsSuccessStatusCode)
            {
                return RedirectToAction("ShippingDetails", "User");
            }
            return View();
        }
    }
}