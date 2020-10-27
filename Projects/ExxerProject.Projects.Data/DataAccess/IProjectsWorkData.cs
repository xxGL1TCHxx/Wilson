using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ExxerProject.Projects.Data.DataAccess.Repositories;
using ExxerProject.Projects.Core.Entities;

namespace ExxerProject.Projects.Data.DataAccess
{
    public interface IProjectsWorkData
    {
        IRepository<Employee> Employees { get; }
        IRepository<Company> Companies { get; }
        IRepository<Project> Projects { get; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        Task<int> CompleteAsync();

        int Complete();
    }
}
