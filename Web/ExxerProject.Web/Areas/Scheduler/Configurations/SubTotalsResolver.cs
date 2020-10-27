using AutoMapper;
using ExxerProject.Accounting.Core.Entities.ValueObjects;
using ExxerProject.Web.Configurations;

namespace ExxerProject.Web.Areas.Scheduler.Configurations
{
    public class SubTotalsResolver<TSource, TDestination> : IValueResolver<TSource, TDestination, SubTotals>
    {
        public SubTotals Resolve(TSource source, TDestination destination, SubTotals destMember, ResolutionContext context)
        {
            return ProperyResolverFactory.Resolve<TSource, TDestination, SubTotals>(source, destination, "SubTotals") as SubTotals;
        }
    }
}
