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

        [HttpGet]
        public IHttpActionResult AuthorizeUser(string Email, string Password)
        {
            Password.ToString().Trim('"');
            if (Email == null)
            {
                return BadRequest("invalid data");
            }
            else
            {
                CMS_UserInfo cMS_UserInfo = _userManager.AuthorizeUser(Email, Password);
                if (cMS_UserInfo != null)
                {
                    return Ok(cMS_UserInfo);
                }
                return NotFound();
            }
            //var hasepassword= _userManager.Hash(Password);
            //var authorize = _userManager.AuthorizeUser(Email, Password);
            //if (authorize == false)
            //{
            //    return BadRequest();
            //}
            //else
            //{
            //    return Ok(authorize);
            //}
        }

        [HttpPost]
        public IHttpActionResult InsertAddressDetails(AddressDetailsViewModel OrderInfo)
        {
            bool status = _userManager.InsertAddressDetails(OrderInfo);
            if(status == false)
            {
                return NotFound();
            }
            return Ok();
        }


    }
}
