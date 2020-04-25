using AutoMapper;
using CMS.Business.Interface;
using CMS.BusinessEntities.ViewModel;
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

        public CategoryViewModel GetCategory(long categoryid)
        {
            var Category = _categoryRepository.GetCategory(categoryid);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CMS_ProductCategoryMaster, CategoryViewModel>();
            });
            IMapper mapper = config.CreateMapper();
            var CategoryViewModel1 = mapper.Map<CMS_ProductCategoryMaster, CategoryViewModel>(Category);
            return CategoryViewModel1;
        }
    }
}
