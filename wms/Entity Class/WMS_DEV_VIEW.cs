//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class WMS_DEV_VIEW
    {
        public int dev_id { get; set; }
        public string dev_name { get; set; }
        public string dev_model { get; set; }
        public string dev_serial { get; set; }
        public int stat_id { get; set; }
        public Nullable<System.DateTime> dev_firstsynced { get; set; }
        public Nullable<System.DateTime> dev_lastsynced { get; set; }
        public Nullable<System.DateTime> dev_registered { get; set; }
        public string stat_desc { get; set; }
        public string stat_desc2 { get; set; }
        public Nullable<int> dev_rgstrdby { get; set; }
        public Nullable<System.DateTime> dev_dateuptd { get; set; }
        public Nullable<int> dev_uptdby { get; set; }
        public string regby { get; set; }
        public string updby { get; set; }
    }
}
