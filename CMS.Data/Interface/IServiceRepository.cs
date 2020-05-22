using CMS.Data.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Data.Interface
{
    public interface IServiceRepository
    {
        List<CMS_ServiceMaster> GetServices();
        CMS_ServiceMaster GetService(long serviceid);
    }
}
