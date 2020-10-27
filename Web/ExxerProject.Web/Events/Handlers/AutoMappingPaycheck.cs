using AutoMapper;
using ExxerProject.Scheduler.Core.Entities;

namespace ExxerProject.Web.Events.Handlers
{
    public class AutoMappingPaycheck : Profile
    {
        public AutoMappingPaycheck()
        {
            CreateMap<Paycheck, Accounting.Core.Entities.Paycheck>().ForMember(x => x.Employee, opt => opt.Ignore());
        }
    }
}