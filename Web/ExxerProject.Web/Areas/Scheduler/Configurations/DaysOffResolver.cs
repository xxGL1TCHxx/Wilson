using AutoMapper;
using ExxerProject.Scheduler.Core.Entities.ValueObjects;
using ExxerProject.Web.Configurations;

namespace ExxerProject.Web.Areas.Scheduler.Configurations
{
    public class DaysOffResolver<TSource, TDestination> : IValueResolver<TSource, TDestination, DaysOff>
    {
        public DaysOff Resolve(TSource source, TDestination destination, DaysOff destMember, ResolutionContext context)
        {
            return ProperyResolverFactory.Resolve<TSource, TDestination, DaysOff>(source, destination, "DaysOff") as DaysOff;
        }
    }
}
