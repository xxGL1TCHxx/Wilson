using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ExxerProject.Companies.Core.Entities;
using ExxerProject.Companies.Data.DataAccess.Repositories;

namespace ExxerProject.Companies.Data.DataAccess
{
    public interface ICompanyWorkData
    {        
        IRepository<ApplicationUser> Users { get; }        
        IRepository<Company> Companies { get; }
        IRepository<Employee> Employees { get; }
        IRepository<Inquiry> Inquiries { get; }
        IRepository<Settings> Settings { get; }
        IRepository<RegistrationRequestMessage> RegistrationRequestMessages { get; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        Task<int> CompleteAsync();

        int Complete();
    }
}
