using CMS.Business.Interface;
using CMS.Data.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CMS.WebAPI.Controllers
{
    public class CategoryController : ApiController
    {
        private ICategoryManager _categoryManager;

        public CategoryController(ICategoryManager categoryManager)
        {
            _categoryManager = categoryManager;
        }

        [HttpGet]
        public IHttpActionResult GetCategories()
        {
            List<CMS_ProductCategoryMaster> Categories = _categoryManager.GetCategories();
            if (Categories == null)
            {
                return NotFound();
            }
            return Ok(Categories);
        }
    }
}
