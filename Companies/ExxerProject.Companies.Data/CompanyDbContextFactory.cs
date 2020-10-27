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
            builder.UseSqlServer("Server=.;Database=ExxerProject;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new CompanyDbContext(builder.Options);
        }

        public CompanyDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<CompanyDbContext>();
            builder.UseSqlServer("Server=.;Database=ExxerProject;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new CompanyDbContext(builder.Options);
        }
    }
}