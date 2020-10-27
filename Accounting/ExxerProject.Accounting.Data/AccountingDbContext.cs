using System;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using ExxerProject.Accounting.Core.Entities;
using ExxerProject.Accounting.Data.Configurations;

namespace ExxerProject.Accounting.Data
{
    public class AccountingDbContext : DbContext
    {
        public AccountingDbContext(DbContextOptions<AccountingDbContext> options) 
            : base(options)
        {
        }

        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<Storehouse> Storehouses { get; set; }
        public virtual DbSet<Bill> Bills { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema("Accounting");
            this.RegesterEntityTypeConfigurations(builder);

            base.OnModelCreating(builder);
        }

        private void RegesterEntityTypeConfigurations(ModelBuilder builder)
        {
            var typesToRegister = Assembly.Load(new AssemblyName("ExxerProject.Accounting.Data")).GetTypes().Where(
                type => type.GetTypeInfo().BaseType != null &&
                !type.GetTypeInfo().IsAbstract &&
                typeof(IEntityTypeConfiguration).IsAssignableFrom(type));

            foreach (var type in typesToRegister)
            {
                Activator.CreateInstance(type, builder);
            }
        }
    }
}
