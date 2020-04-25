using CMS.Data.Database;
using CMS.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Data.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private CMSEntities cMSEntities;
        public CategoryRepository()
        {
            cMSEntities = new CMSEntities();
        }
        public List<CMS_ProductCategoryMaster> GetCategories()
        {
            List<CMS_ProductCategoryMaster> Categories= cMSEntities.CMS_ProductCategoryMaster.ToList();
            return Categories;
        }

        public CMS_ProductCategoryMaster GetCategory(long categoryid)
        {
            CMS_ProductCategoryMaster Category = cMSEntities.CMS_ProductCategoryMaster.Find(categoryid);
            return Category;
        }
    }
}
