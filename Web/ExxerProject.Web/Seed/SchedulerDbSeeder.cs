using System.Collections.Generic;
using System.Linq;
using ExxerProject.Scheduler.Core.Entities;
using ExxerProject.Scheduler.Data;
using Microsoft.Extensions.DependencyInjection;
using ExxerProject.Web.Events.Interfaces;

namespace ExxerProject.Web.Seed
{
    public class SchedulerDbSeeder
    {
        private static IEnumerable<Schedule> schedules;

        /// <summary>
        /// Seeds the data for the Scheduler module.
        /// </summary>
        /// <param name="services">The service factory.</param>
        public static void Seed(IServiceScopeFactory services, IEventsFactory eventsFactory)
        {
            using (var scope = services.CreateScope())
            {
                var schedulerDb = scope.ServiceProvider.GetRequiredService<SchedulerDbContext>();

                // Keep the following methods in this exact order.
                SeedSchedules(schedulerDb, schedulerDb.Set<Schedule>().Any(), out schedules);

                schedulerDb.SaveChanges();
            }
        }

        private static void SeedSchedules(
            SchedulerDbContext schedulerDb,
            bool hasSchedules,
            out IEnumerable<Schedule> schedules)
        {
            if (!hasSchedules)
            {
                // TO DO Seed schedules.
                schedules = new List<Schedule>() { };

                schedulerDb.Schedules.AddRange(schedules);
            }
            else
            {
               schedules = schedulerDb.Schedules.ToList();
            }
        }
    }
}
