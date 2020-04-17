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
        List<DealerViewModel> GetDealerCompanyList(long From,long To,long DealerProductId,long DealerServiceId);
    }
}
