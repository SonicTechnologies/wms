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
    
    public partial class WMS_INC_HEADER
    {
        public int inc_header_id { get; set; }
        public string billdoc { get; set; }
        public string date_rcvd { get; set; }
        public Nullable<int> rcvd_by { get; set; }
        public Nullable<System.DateTime> finished_date { get; set; }
        public Nullable<int> stat_id { get; set; }
    }
}