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
    
    public partial class FDR_GPLINES_VIEW
    {
        public int gpl_id { get; set; }
        public string inv_number { get; set; }
        public int gp_id { get; set; }
        public int rcv_id { get; set; }
        public Nullable<double> gpl_payment { get; set; }
        public Nullable<double> gpl_redamnt { get; set; }
        public Nullable<int> dels_id { get; set; }
        public string gp_name { get; set; }
        public int gp_srs { get; set; }
        public System.DateTime gp_deldate { get; set; }
        public System.DateTime gp_datecrtd { get; set; }
        public int drvr_id { get; set; }
        public int usr_id { get; set; }
        public int gpstat_id { get; set; }
        public string ord_number { get; set; }
        public string cust_name { get; set; }
        public double inv_amount { get; set; }
    }
}
