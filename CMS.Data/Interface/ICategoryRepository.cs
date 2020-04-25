using CMS.Data.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Data.Interface
{
    public interface ICategoryRepository
    {
        List<CMS_ProductCategoryMaster> GetCategories();
        CMS_ProductCategoryMaster GetCategory(long categoryid);
    }
}
