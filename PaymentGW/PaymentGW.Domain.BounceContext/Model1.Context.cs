﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PaymentGW.Domain.BounceContext
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class PaymentGWDBEntities : DbContext
    {
        public PaymentGWDBEntities()
            : base("name=PaymentGWDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<t_card> t_card { get; set; }
    
        public virtual int IsCardNumberExists(string cardNumber, ObjectParameter result)
        {
            var cardNumberParameter = cardNumber != null ?
                new ObjectParameter("cardNumber", cardNumber) :
                new ObjectParameter("cardNumber", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("IsCardNumberExists", cardNumberParameter, result);
        }
    }
}