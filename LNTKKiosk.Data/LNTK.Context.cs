﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LNTKKiosk.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class LNTKEntities : DbContext
    {
        public LNTKEntities()
            : base("name=LNTKEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Code> Codes { get; set; }
        public virtual DbSet<CodeCategory> CodeCategories { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<EventProduct> EventProducts { get; set; }
        public virtual DbSet<Grocery> Groceries { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<OrderStock> OrderStocks { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Recipe> Recipes { get; set; }
        public virtual DbSet<Stock> Stocks { get; set; }
    }
}