﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Demo21.Model
{ 
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Demo2021Entities : DbContext
    {
        private static Demo2021Entities _context;
        public Demo2021Entities()
            : base("name=Demo2021Entities")
        {
        }
        public static Demo2021Entities GetContext()
        {
            if (_context == null)
                _context = new Demo2021Entities();
            return _context;
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Agents> Agents { get; set; }
        public virtual DbSet<AgentTypes> AgentTypes { get; set; }
        public virtual DbSet<ProductRealization> ProductRealization { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<ProductType> ProductType { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
    }
}