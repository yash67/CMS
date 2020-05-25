using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.BusinessEntities.ViewModel
{
    public class DealerServiceViewModel
    {
        public long DealerServiceId { get; set; }
        public long DealerId { get; set; }
        public long ServiceId { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
    }
}
