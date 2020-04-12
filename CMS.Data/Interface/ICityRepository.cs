using CMS.Data.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Data.Interface
{
   public interface ICityRepository
    {
        List<CMS_CityMaster> GetCities();
    }
}
