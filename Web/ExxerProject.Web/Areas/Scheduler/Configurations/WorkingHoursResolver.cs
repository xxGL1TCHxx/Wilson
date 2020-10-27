using AutoMapper;
using ExxerProject.Scheduler.Core.Entities.ValueObjects;
using ExxerProject.Web.Configurations;

namespace ExxerProject.Web.Areas.Scheduler.Configurations
{
    public class WorkingHoursResolver<TSource, TDestination> : IValueResolver<TSource, TDestination, WorkingHours>
    {
        public WorkingHours Resolve(TSource source, TDestination destination, WorkingHours destMember, ResolutionContext context)
        {
            return ProperyResolverFactory.Resolve<TSource, TDestination, WorkingHours>(source, destination, "WorkingHours") as WorkingHours;
        }
    }
}
