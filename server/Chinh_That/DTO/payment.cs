//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Chinh_That.DTO
{
    using System;
    using System.Collections.Generic;
    
    public partial class payment
    {
        public int id { get; set; }
        public Nullable<int> total_bill { get; set; }
        public Nullable<int> record_id { get; set; }
        public Nullable<System.DateTime> payment_time { get; set; }
        public Nullable<int> cash_given { get; set; }
        public Nullable<int> cash_return { get; set; }
    
        public virtual record record { get; set; }
    }
}
