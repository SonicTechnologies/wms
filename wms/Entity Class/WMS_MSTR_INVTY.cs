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
    
    public partial class WMS_MSTR_INVTY
    {
        public string invty_id { get; set; }
        public string invty_desc { get; set; }
        public string invty_barcode { get; set; }
        public string invty_casecode { get; set; }
        public int invty_ppu { get; set; }
        public string invty_cat1 { get; set; }
        public string invty_cat2 { get; set; }
        public string invty_cat3 { get; set; }
        public string invty_cat4 { get; set; }
        public string invty_brand { get; set; }
        public int stat_id { get; set; }
        public System.DateTime invty_datecrtd { get; set; }
        public Nullable<System.DateTime> invty_dateuptd { get; set; }
        public int invty_crtdby { get; set; }
        public Nullable<int> invty_uptdby { get; set; }
    }
}