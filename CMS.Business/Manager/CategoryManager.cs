using CMS.Business.Interface;
using CMS.Data.Database;
using CMS.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Business.Manager
{
    public class CategoryManager : ICategoryManager
    {
        private ICategoryRepository _categoryRepository;

        public CategoryManager(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public List<CMS_ProductCategoryMaster> GetCategories()
        {
            List<CMS_ProductCategoryMaster> Categories = _categoryRepository.GetCategories();
            return Categories;
        }
    }
}
