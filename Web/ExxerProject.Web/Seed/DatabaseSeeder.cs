using Microsoft.Extensions.DependencyInjection;
using ExxerProject.Web.Events.Interfaces;

namespace ExxerProject.Web.Seed
{
    public class DatabaseSeeder : IDatabaseSeeder
    {
        public void Seed(IServiceScopeFactory services, IEventsFactory eventsFactory)
        {
            AccountingDbSeeder.Seed(services, eventsFactory);
            CompaniesDbSeeder.Seed(services, eventsFactory);
            ProjectsDbSeeder.Seed(services, eventsFactory);            
            SchedulerDbSeeder.Seed(services, eventsFactory);
        }
    }
}
