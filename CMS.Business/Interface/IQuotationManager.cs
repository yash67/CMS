using CMS.BusinessEntities.ViewModel;
using CMS.Data.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Business.Interface
{
    public interface IQuotationManager
    {
        List<QuotationViewModel> GetDealerCompanyList(long From, long To, long DealerProductId, long DealerServiceId);
    }
}
