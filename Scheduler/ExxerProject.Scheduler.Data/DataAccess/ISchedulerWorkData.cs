using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ExxerProject.Scheduler.Data.DataAccess.Repositories;
using ExxerProject.Scheduler.Core.Entities;

namespace ExxerProject.Scheduler.Data.DataAccess
{
    public interface ISchedulerWorkData
    {
        IRepository<Employee> Employees { get; }
        IRepository<Schedule> Schedules { get; }
        IRepository<Project> Projects { get; }
        IRepository<PayRate> PayRates { get; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        Task<int> CompleteAsync();

        int Complete();
    }
}
