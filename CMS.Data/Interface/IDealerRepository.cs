using CMS.BusinessEntities.ViewModel;
using CMS.Data.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Data.Interface
{
    public interface IDealerRepository
    {
        bool InsertDealer(CMS_DealerInfo dealer);
        bool CheckDealerEmail(string email);
        CMS_DealerInfo GetDealer(string email);
        bool UpdateDealer(CMS_DealerInfo dealer);
        CMS_DealerInfo AuthorizeDealer(string Email, string Password);
        List<AddressDetailsViewModel> GetOrders(long id);

    }
}
