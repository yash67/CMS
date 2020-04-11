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

namespace Project_Layout_Demo.Areas.User.Controllers
{
    public class UserController : Controller
    {
        private SendEmail sendEmail = new SendEmail();
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
                userViewModel.Password = await hash(userViewModel.Password);//.ToString().Replace('"','A'));  
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
    }
}