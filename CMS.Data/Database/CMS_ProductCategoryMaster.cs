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
    
    public partial class CMS_ProductCategoryMaster
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CMS_ProductCategoryMaster()
        {
            this.CMS_DealerProductCategory = new HashSet<CMS_DealerProductCategory>();
        }
    
        public long CategoryId { get; set; }
        public string CategoryName { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CMS_DealerProductCategory> CMS_DealerProductCategory { get; set; }
    }
}
