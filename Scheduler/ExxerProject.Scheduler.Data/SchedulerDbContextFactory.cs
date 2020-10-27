using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Design;

namespace ExxerProject.Scheduler.Data
{
    public class SchedulerDbContextFactory : IDesignTimeDbContextFactory<SchedulerDbContext>
    {
        public SchedulerDbContext Create()
        {
            var builder = new DbContextOptionsBuilder<SchedulerDbContext>();
            builder.UseSqlServer("Server=.;Database=ExxerProject;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new SchedulerDbContext(builder.Options);
        }

        public SchedulerDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<SchedulerDbContext>();
            builder.UseSqlServer("Server=.;Database=ExxerProject;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new SchedulerDbContext(builder.Options);
        }
    }
}