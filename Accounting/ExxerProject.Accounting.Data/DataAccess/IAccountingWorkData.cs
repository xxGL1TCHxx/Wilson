using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ExxerProject.Accounting.Data.DataAccess.Repositories;
using ExxerProject.Accounting.Core.Entities;

namespace ExxerProject.Accounting.Data.DataAccess
{
    public interface IAccountingWorkData
    {
        IRepository<Employee> Employees { get; }
        IRepository<Company> Companies { get; }
        IRepository<Invoice> Invoices { get; }
        IRepository<Storehouse> Storehouses { get; }
        IRepository<Bill> Bills { get; }        

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        Task<int> CompleteAsync();

        int Complete();
    }
}
