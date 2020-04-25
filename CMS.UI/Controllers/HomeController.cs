using CMS.BusinessEntities.ViewModel;
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

namespace Project_Layout_Demo.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
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
            ViewBag.Services=Services;
            return View();
        }

        //public ActionResult UserRegistration()
        //{
        //    ViewBag.Message = "Your application description page.";
        //    //Comment
        //    //comment2
        //    return View();
        //}
        public ActionResult DealerRegistration()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            if (Session["Email"] != null)
            {
                Session["Email"] = null;
            }
            return View();
        }

        //[HttpPost]
        //public async Task<ActionResult> Login(UserViewModel userViewModel, string returnurl)
        //{
        //    List<UserViewModel> users = new List<UserViewModel>();
        //    userViewModel.Password = await hash(userViewModel.Password);
        //    userViewModel.Password.ToString().Trim('"');
        //    var stringContent = new StringContent(JsonConvert.SerializeObject(userViewModel.Password), Encoding.UTF8, "application/json");
        //    HttpResponseMessage Res = await GlobalVariables.client.GetAsync("api/Users/AuthorizeUser?Email=" + userViewModel.Email + "&Password=" + userViewModel.Password);
        //    if (Res.IsSuccessStatusCode)
        //    {

        //        HttpResponseMessage Response = await GlobalVariables.client.GetAsync("api/Users/GetAllUsers");
        //        if (Response.IsSuccessStatusCode)
        //        {
        //            var MainMEnuResponse = Response.Content.ReadAsStringAsync().Result;
        //            users = JsonConvert.DeserializeObject<List<UserViewModel>>(MainMEnuResponse);
        //        }
        //        var check = users.Where(x => x.UserType == true && x.Email == userViewModel.Email).FirstOrDefault();
        //        var chid = users.Where(x => x.Email == userViewModel.Email).FirstOrDefault();
        //        if (Url.IsLocalUrl(returnurl))
        //        {
        //            return Redirect(returnurl);
        //        }
        //        else if (check != null)
        //        {
        //            FormsAuthentication.SetAuthCookie(userViewModel.Email, true);
        //            Session["Email"] = userViewModel.Email;
        //            Session["aId"] = chid.Id;
        //            return Redirect("/Admin/Admin/Index");
        //        }
        //        else
        //        {
        //            FormsAuthentication.SetAuthCookie(userViewModel.Email, true);
        //            Session["Email"] = userViewModel.Email;
        //            Session["Id"] = chid.Id;
        //            return Redirect("/Customer/Customers/index");
        //        }
        //    }
        //    else
        //    {
        //        TempData["Message"] = "Password is Wrong";
        //    }
        //    return View(userViewModel);
        //}

        [HttpPost]
        public async Task<ActionResult> Login(string Email,string Password, int roletype, string returnurl)
        {
            //List<UserViewModel> users = new List<UserViewModel>();
            Password = await hash(Password);
            Password.ToString().Trim('"');
            Password.Replace('+', ' ');
            var stringContent = new StringContent(JsonConvert.SerializeObject(Password), Encoding.UTF8, "application/json");
            string addressurl = "";
            if (roletype == 2)
            {
                 addressurl = "api/Dealer/AuthorizeDealer?Email=" + Email + "&Password=" + Password;

                //Dealer
                return Redirect("/Dealer/Dealer/Dashboard");
            }
            else
            {
                addressurl = "api/User/AuthorizeUser?Email=" + Email + "&Password=" + Password;
                UserViewModel user;
                HttpResponseMessage Res = await GlobalVariables.client.GetAsync(addressurl);
                if (Res.IsSuccessStatusCode)
                {

                    //HttpResponseMessage Response = await GlobalVariables.client.GetAsync("api/Users/GetAllUsers");
                    // if (Response.IsSuccessStatusCode)
                    // {
                    //     var MainMEnuResponse = Response.Content.ReadAsStringAsync().Result;
                    //     users = JsonConvert.DeserializeObject<List<UserViewModel>>(MainMEnuResponse);
                    // }
                    //var check = users.Where(x => x.UserType == true && x.Email == userViewModel.Email).FirstOrDefault();
                    //var chid = users.Where(x => x.Email == userViewModel.Email).FirstOrDefault();
                    //if (Url.IsLocalUrl(returnurl))
                    //{
                    //    return Redirect(returnurl);
                    //}
                    //else if (check != null)
                    //{
                    //    FormsAuthentication.SetAuthCookie(userViewModel.Email, true);
                    var MainMEnuResponse = Res.Content.ReadAsStringAsync().Result;
                    user = JsonConvert.DeserializeObject<UserViewModel>(MainMEnuResponse);
                    Session["Email"] = Email;
                    Session["UId"] = user.UserId;
                    return RedirectToAction("Dashboard","User",new { area = "User" });
                }
                else
                {
                    TempData["Message"] = "Password is Wrong";
                }
            }
            
            return View();
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
        //[HttpGet]
        //public ActionResult forgotPassword()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public async Task<ActionResult> forgotPassword(string Email)
        //{
        //    string message = "";
        //    bool status = false;
        //    List<UserViewModel> users = new List<UserViewModel>();
        //    //HttpResponseMessage Responce = await GlobalVariables.client.GetAsync("api/Users/CheckEmail?chkemail=" + Email);
        //    HttpResponseMessage Responce = await GlobalVariables.client.GetAsync("api/Users/CheckUserEmail?chkemail=" + Email);

        //    if (Responce.IsSuccessStatusCode)
        //    {
        //        ModelState.AddModelError("NotExits", "Email is not exits!");

        //        #region cmt
        //        //HttpResponseMessage Res = await GlobalVariables.client.GetAsync("api/Users/GetAllUsers");
        //        //if (Res.IsSuccessStatusCode)
        //        //{
        //        //    var MainMEnuResponse = Res.Content.ReadAsStringAsync().Result;
        //        //    users = JsonConvert.DeserializeObject<List<UserViewModel>>(MainMEnuResponse);
        //        //}
        //        //var check = users.Where(a => a.Email == Email).FirstOrDefault();
        //        //if (check != null)
        //        //{
        //        #endregion
        //        //}
        //    }
        //    else
        //    {
        //        message = "<html><body><a href=\"LINK\">Reset Password Here</a></body></html>";
        //        var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, "/Register/ResetPassword?Email=" + Email + "");
        //        message = message.Replace("LINK", link);
        //        //bool flag = await sendEmail.SendMail(Email, "ResetPassword", message);
        //        TempData["link"] = "Successfully send link";
        //        return RedirectToAction("signIn", "Register");

        //    }
        //    //ViewBag.Message = message;
        //    return View();
        //}

    }
}