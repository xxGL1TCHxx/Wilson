using AutoMapper;
using ExxerProject.Accounting.Core.Entities.ValueObjects;
using ExxerProject.Web.Configurations;

namespace ExxerProject.Web.Areas.Accounting.Configurations
{
    public class PeriodResolver<TSource, TDestination> : IValueResolver<TSource, TDestination, Period>
    {
        public Period Resolve(TSource source, TDestination destination, Period destMember, ResolutionContext context)
        {
            return ProperyResolverFactory.Resolve<TSource, TDestination, Period>(source, destination, "Period") as Period;
        }
    }
}
