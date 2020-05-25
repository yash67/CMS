using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.BusinessEntities.ViewModel
{
    public class DealerCategoryViewModel
    {
        public long DealerProductId { get; set; }
        public long DealerId { get; set; }
        public long CategoryId { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
    }
}
