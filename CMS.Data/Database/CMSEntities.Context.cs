﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CMSEntities : DbContext
    {
        public CMSEntities()
            : base("name=CMSEntities")
        {
            this.Configuration.ProxyCreationEnabled = false;
            this.Configuration.LazyLoadingEnabled = true;
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CMS_CityMaster> CMS_CityMaster { get; set; }
        public virtual DbSet<CMS_DealerCity> CMS_DealerCity { get; set; }
        public virtual DbSet<CMS_DealerRate> CMS_DealerRate { get; set; }
        public virtual DbSet<CMS_ProductCategoryMaster> CMS_ProductCategoryMaster { get; set; }
        public virtual DbSet<CMS_RoleMaster> CMS_RoleMaster { get; set; }
        public virtual DbSet<CMS_ServiceMaster> CMS_ServiceMaster { get; set; }
        public virtual DbSet<CMS_UserInfo> CMS_UserInfo { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<CMS_DealerInfo> CMS_DealerInfo { get; set; }
        public virtual DbSet<CMS_OrderInfo> CMS_OrderInfo { get; set; }
        public virtual DbSet<CMS_DealerService> CMS_DealerService { get; set; }
        public virtual DbSet<CMS_DealerProductCategory> CMS_DealerProductCategory { get; set; }
    }
}
