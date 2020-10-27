using Microsoft.Extensions.DependencyInjection;

namespace ExxerProject.Web.Seed
{
    public interface IRolesSeder
    {
        void Seed(IServiceScopeFactory services);
    }
}
