//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CMS.Data.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class CMS_DealerInfo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CMS_DealerInfo()
        {
            this.CMS_DealerCity = new HashSet<CMS_DealerCity>();
            this.CMS_DealerProductCategory = new HashSet<CMS_DealerProductCategory>();
            this.CMS_DealerRate = new HashSet<CMS_DealerRate>();
            this.CMS_DealerService = new HashSet<CMS_DealerService>();
            this.CMS_OrderInfo = new HashSet<CMS_OrderInfo>();
        }
    
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
        public int Status { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CMS_DealerCity> CMS_DealerCity { get; set; }
        public virtual CMS_RoleMaster CMS_RoleMaster { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CMS_DealerProductCategory> CMS_DealerProductCategory { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CMS_DealerRate> CMS_DealerRate { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CMS_DealerService> CMS_DealerService { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CMS_OrderInfo> CMS_OrderInfo { get; set; }
    }
}