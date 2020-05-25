using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.BusinessEntities.ViewModel
{
    public class DealerCityViewModel
    {
        public long DealerCityId { get; set; }
        public long DealerId { get; set; }
        public long CityId { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
    }
}
