//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcSoruCevap.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBLCEVAP
    {
        public int ID { get; set; }
        public Nullable<int> SORU { get; set; }
        public string CEVAP { get; set; }
        public Nullable<int> DOKTOR { get; set; }
        public Nullable<System.DateTime> EKLENMETARIHI { get; set; }
        public Nullable<System.DateTime> DUZENLEMETARIHI { get; set; }
    
        public virtual TBLDOKTOR TBLDOKTOR { get; set; }
        public virtual TBLSORU TBLSORU { get; set; }
    }
}
