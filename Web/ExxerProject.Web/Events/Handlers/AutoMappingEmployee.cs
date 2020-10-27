using AutoMapper;
using ExxerProject.Companies.Core.Entities;

namespace ExxerProject.Web.Events.Handlers
{
    public class AutoMappingEmployee : Profile
    {
        public AutoMappingEmployee()
        {
            CreateMap<Employee, Accounting.Core.Entities.Employee>()
                    .ForMember(x => x.Paycheks, opt => opt.Ignore())
                    .ForMember(x => x.Company, opt => opt.Ignore())
                    .ForSourceMember(x => x.Company, opt => opt.DoNotValidate())
                    .ForSourceMember(x => x.InfoRequests, opt => opt.DoNotValidate());

            CreateMap<Employee, Projects.Core.Entities.Employee>()
                 .ForMember(x => x.Projects, opt => opt.Ignore())
                 .ForSourceMember(x => x.Company, opt => opt.DoNotValidate())
                 .ForSourceMember(x => x.InfoRequests, opt => opt.DoNotValidate());

            CreateMap<Employee, Scheduler.Core.Entities.Employee>()
                 .ForMember(x => x.Schedules, opt => opt.Ignore())
                 .ForMember(x => x.Paychecks, opt => opt.Ignore())
                 .ForMember(x => x.PayRate, opt => opt.Ignore())
                 .ForSourceMember(x => x.Company, opt => opt.DoNotValidate())
                 .ForSourceMember(x => x.InfoRequests, opt => opt.DoNotValidate());
        }
    }
}