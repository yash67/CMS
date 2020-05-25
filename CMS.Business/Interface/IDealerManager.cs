using CMS.BusinessEntities.ViewModel;
using CMS.Data.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Business.Interface
{
    public interface IDealerManager
    {
        bool InsertDealer(DealerViewModel dealerViewModel);
        bool CheckDealerEmail(string email);
        bool UpdateDealer(string email);
        CMS_DealerInfo AuthorizeDealer(string email, string password);
        List<AddressDetailsViewModel> GetOrders(long id);
        bool InsertDealerCities(List<DealerCityViewModel> dealerCityViewModels);
        bool InsertDealerCategories(List<DealerCategoryViewModel> dealerCategoryViewModels);
        bool InsertDealerServices(List<DealerServiceViewModel> dealerServiceViewModels);
    }
}
