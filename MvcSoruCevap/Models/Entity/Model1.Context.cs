﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class SORUCEVAPEntities : DbContext
    {
        public SORUCEVAPEntities()
            : base("name=SORUCEVAPEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TBLCEVAP> TBLCEVAP { get; set; }
        public virtual DbSet<TBLDOKTOR> TBLDOKTOR { get; set; }
        public virtual DbSet<TBLHAREKET> TBLHAREKET { get; set; }
        public virtual DbSet<TBLKATEGORI> TBLKATEGORI { get; set; }
        public virtual DbSet<TBLSORU> TBLSORU { get; set; }
        public virtual DbSet<TBLUYEHASTA> TBLUYEHASTA { get; set; }
        public virtual DbSet<TBLILETISIM> TBLILETISIM { get; set; }
        public virtual DbSet<TBLMESAJLAR> TBLMESAJLAR { get; set; }
        public virtual DbSet<TBLDUYURU> TBLDUYURU { get; set; }
    
        public virtual ObjectResult<string> EnAktifHasta()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("EnAktifHasta");
        }
    
        public virtual ObjectResult<string> EnAktifDoktor()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("EnAktifDoktor");
        }
    
        public virtual ObjectResult<string> EnSıkSoru()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("EnSıkSoru");
        }
    }
}