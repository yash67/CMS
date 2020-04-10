using CMS.Business.Interface;
using CMS.BusinessEntities.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CMS.WebAPI.Controllers
{
    public class UserController : ApiController
    {
        private IUserManager _userManager{get;set;}

        public UserController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public bool InsertUser(UserViewModel userViewModel)
        {
            return _userManager.UserRegistration(userViewModel);
        }
    }
}
