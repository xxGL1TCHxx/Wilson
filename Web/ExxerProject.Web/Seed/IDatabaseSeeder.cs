using Microsoft.Extensions.DependencyInjection;
using ExxerProject.Web.Events.Interfaces;

namespace ExxerProject.Web.Seed
{
    public interface IDatabaseSeeder
    {
        void Seed(IServiceScopeFactory services, IEventsFactory eventsFactory);
    }
}
