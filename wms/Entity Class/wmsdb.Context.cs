﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace wms.Entity_Class
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class wmsdb : DbContext
    {
        public wmsdb()
            : base("name=wmsdb")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<WMS_MSTR_CUST> WMS_MSTR_CUST { get; set; }
        public virtual DbSet<WMS_MSTR_INVTY> WMS_MSTR_INVTY { get; set; }
        public virtual DbSet<WMS_MSTR_SITE> WMS_MSTR_SITE { get; set; }
        public virtual DbSet<WMS_MSTR_SLSMAN> WMS_MSTR_SLSMAN { get; set; }
        public virtual DbSet<WMS_MSTR_USRS> WMS_MSTR_USRS { get; set; }
        public virtual DbSet<WMS_TYPE_SLSMAN> WMS_TYPE_SLSMAN { get; set; }
        public virtual DbSet<WMS_TYPE_USRS> WMS_TYPE_USRS { get; set; }
        public virtual DbSet<WMS_TYPE_STAT> WMS_TYPE_STAT { get; set; }
        public virtual DbSet<WMS_USRS_VIEW> WMS_USRS_VIEW { get; set; }
        public virtual DbSet<WMS_INVTY_VIEW> WMS_INVTY_VIEW { get; set; }
        public virtual DbSet<WMS_CUST_VIEW> WMS_CUST_VIEW { get; set; }
        public virtual DbSet<WMS_JRSLSMAN_VIEW> WMS_JRSLSMAN_VIEW { get; set; }
        public virtual DbSet<WMS_SITE_VIEW> WMS_SITE_VIEW { get; set; }
        public virtual DbSet<WMS_SLSMAN_VIEW> WMS_SLSMAN_VIEW { get; set; }
        public virtual DbSet<WMS_MSTR_JRSLSMAN> WMS_MSTR_JRSLSMAN { get; set; }
        public virtual DbSet<WMS_MSTR_S1MODULE> WMS_MSTR_S1MODULE { get; set; }
        public virtual DbSet<WMS_MSTR_S2MODULE> WMS_MSTR_S2MODULE { get; set; }
        public virtual DbSet<WMS_MSTR_LVL1M> WMS_MSTR_LVL1M { get; set; }
        public virtual DbSet<WMS_MSTR_LVL2M> WMS_MSTR_LVL2M { get; set; }
        public virtual DbSet<WMS_MSTR_LVL3M> WMS_MSTR_LVL3M { get; set; }
        public virtual DbSet<WMS_LVL1M_VIEW> WMS_LVL1M_VIEW { get; set; }
        public virtual DbSet<WMS_MSTR_MODULE> WMS_MSTR_MODULE { get; set; }
    }
}
