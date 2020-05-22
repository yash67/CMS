using CMS.BusinessEntities.ViewModel;
using CMS.Data.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Business.Interface
{
    public interface IServiceManager
    {
        List<CMS_ServiceMaster> GetServices();
        ServiceViewModel GetService(long serviceid);

    }
}
