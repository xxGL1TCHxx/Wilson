using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace ExxerProject.Companies.Data
{
    public class CompanyDbContextFactory : IDesignTimeDbContextFactory<CompanyDbContext>
    {
        public CompanyDbContext Create()
        {
            var builder = new DbContextOptionsBuilder<CompanyDbContext>();
            builder.UseSqlite("Data Source=MyData.sdf;");

            return new CompanyDbContext(builder.Options);
        }

        public CompanyDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<CompanyDbContext>();
            builder.UseSqlite("Data Source=MyData.sdf;");

            return new CompanyDbContext(builder.Options);
        }
    }
}