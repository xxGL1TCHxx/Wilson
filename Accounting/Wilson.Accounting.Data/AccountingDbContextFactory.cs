using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Wilson.Accounting.Data;

namespace Wilson.Accounting.DataEntityFrameworkCore
{
    public class AccountingDbContextFactory : IDesignTimeDbContextFactory<AccountingDbContext>
    {
        public AccountingDbContext Create()
        {
            var builder = new DbContextOptionsBuilder<AccountingDbContext>();
            builder.UseSqlServer("Server=.;Database=Wilson;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new AccountingDbContext(builder.Options);
        }

        public AccountingDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<AccountingDbContext>();
            builder.UseSqlServer("Server=.;Database=Wilson;Trusted_Connection=True;MultipleActiveResultSets=true");
            return new AccountingDbContext(builder.Options);
        }
    }
}