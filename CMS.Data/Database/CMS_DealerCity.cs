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
    
    public partial class CMS_DealerCity
    {
        public long DealerCityId { get; set; }
        public long DealerId { get; set; }
        public long CityId { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
    
        public virtual CMS_CityMaster CMS_CityMaster { get; set; }
        public virtual CMS_DealerInfo CMS_DealerInfo { get; set; }
    }
}
