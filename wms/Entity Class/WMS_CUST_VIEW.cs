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
    
    public partial class WMS_CUST_VIEW
    {
        public string cust_id { get; set; }
        public string cust_name { get; set; }
        public string cust_address { get; set; }
        public string salesman_id { get; set; }
        public string site_id { get; set; }
        public Nullable<double> cust_latitude { get; set; }
        public Nullable<double> cust_longitude { get; set; }
        public int stat_id { get; set; }
        public string salesman_name { get; set; }
        public string stat_desc { get; set; }
        public string site_name { get; set; }
        public System.DateTime cust_datecrtd { get; set; }
        public Nullable<System.DateTime> cust_dateuptd { get; set; }
        public int cust_crtdby { get; set; }
        public Nullable<int> cust_uptdby { get; set; }
        public string crtdby { get; set; }
        public string uptdby { get; set; }
    }
}