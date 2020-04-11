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

        [HttpGet]
        public IHttpActionResult CheckUserEmail(string chkemail)
        {
            //var customers = _userManager.CheckUserEmail(chkemail);
            if (chkemail == null)
            {
                return BadRequest("invalid data");
                // return NotFound();
            }
            else
            {
                if (_userManager.CheckUserEmail(chkemail))
                {
                    return Ok();
                }
                return NotFound();
            }
            //return Ok(customers);
        }

        [HttpGet]
        public string HashPassword([FromUri]string password)
        {
            return _userManager.Hash(password);
        }

        [HttpGet]
        public IHttpActionResult UpdateUser(string Email)
        {
            bool status = _userManager.UpdateUser(Email);
            if (status == false)
            {
                return BadRequest();
            }
            return Ok(status);
        }

    }
}
