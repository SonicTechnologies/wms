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
    
    public partial class WMS_MSTR_S1MODULE
    {
        public int s1mod_id { get; set; }
        public int mod_id { get; set; }
        public string s1mod_name { get; set; }
        public System.DateTime s1mod_datecrtd { get; set; }
        public int s1mod_crtdby { get; set; }
        public Nullable<System.DateTime> s1mod_dateuptd { get; set; }
        public Nullable<int> s1mod_uptdby { get; set; }
        public int stat_id { get; set; }
    }
}
