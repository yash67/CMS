using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.BusinessEntities.ViewModel
{
    public class AddressDetailsViewModel
    {
        public long OrderId { get; set; }
        public long DealerId { get; set; }
        public long UserId { get; set; }
        public string FromName { get; set; }
        public string FromAddressLine { get; set; }
        public string FromAreaName { get; set; }
        public string FromCityName { get; set; }
        public int FromPinCode { get; set; }
        public string FromMobileNo { get; set; }
        public string FromEmail { get; set; }
        public string ToName { get; set; }
        public string ToAddressLine { get; set; }
        public string ToAreaName { get; set; }
        public string ToCityName { get; set; }
        public int ToPinCode { get; set; }
        public string ToMobileNo { get; set; }
        public string ToEmail { get; set; }
        public decimal PackageWeight { get; set; }
        public long DealerProductId { get; set; }
        public long DealerServiceId { get; set; }
        public decimal Price { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }

    }
}
