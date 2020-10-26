using AutoMapper;
using Wilson.Scheduler.Core.Entities;

namespace Wilson.Web.Events.Handlers
{
    public class AutoMappingPaycheck : Profile
    {
        public AutoMappingPaycheck()
        {
            CreateMap<Paycheck, Accounting.Core.Entities.Paycheck>().ForMember(x => x.Employee, opt => opt.Ignore());
        }
    }
}