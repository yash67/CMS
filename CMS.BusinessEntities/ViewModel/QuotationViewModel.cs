
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.BusinessEntities.ViewModel
{
    public class QuotationViewModel
    {
        public long DealerId { get; set; }
        public long RoleId { get; set; }
        public string DealerName { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string CompanyAreaName { get; set; }
        public string CompanyCityName { get; set; }
        public int Pincode { get; set; }
        public string MobileNo { get; set; }
        public string RegistrationNo { get; set; } 
        public decimal PerCategoryPrice { get; set; }
        public decimal PerServicePrice { get; set; }
        public decimal PerKgPrice { get; set; }
        public decimal PerKmPrice { get; set; }
        public string CategoryName { get; set; }
        public string ServiceName { get; set; }
    }
}
