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
    
    public partial class TBLSORU
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBLSORU()
        {
            this.TBLCEVAP = new HashSet<TBLCEVAP>();
        }
    
        public int ID { get; set; }
        public string BASLIK { get; set; }
        public string ICERIK { get; set; }
        public Nullable<int> KATEGORI { get; set; }
        public Nullable<int> HASTA { get; set; }
        public Nullable<System.DateTime> EKLEMETARIHI { get; set; }
        public Nullable<System.DateTime> DUZENLEMETARIHI { get; set; }
        public Nullable<bool> DURUM { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBLCEVAP> TBLCEVAP { get; set; }
        public virtual TBLKATEGORI TBLKATEGORI { get; set; }
        public virtual TBLUYEHASTA TBLUYEHASTA { get; set; }
    }
}
