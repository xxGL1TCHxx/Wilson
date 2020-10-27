using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ExxerProject.Companies.Core.Entities;

namespace ExxerProject.Companies.Data.Configurations
{
    public class SettingsTypeConfiguration : EntityTypeConfiguration<Settings>
    {
        public SettingsTypeConfiguration(ModelBuilder modelBuilder)
        {
            this.Map(modelBuilder.Entity<Settings>());
        }

        public override void Map(EntityTypeBuilder<Settings> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasMaxLength(36);
            builder.Property(x => x.HomeCompanyId).HasMaxLength(36);
            builder.HasOne(x => x.HomeCompany).WithOne().HasForeignKey<Settings>(x => x.HomeCompanyId);
        }
    }
}
