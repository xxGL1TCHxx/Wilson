using AutoMapper;
using Wilson.Projects.Core.Entities;

namespace Wilson.Web.Events.Handlers
{
    public class AutoMappingProject : Profile
    {
        public AutoMappingProject()
        {
            // Companies Maps
            CreateMap<Project, Companies.Core.Entities.Project>()
                .ForMember(x => x.Contract, opt => opt.Ignore())
                .ForMember(x => x.Customer, opt => opt.Ignore())
                .ForSourceMember(x => x.Customer, opt => opt.DoNotValidate())
                .ForSourceMember(x => x.Manager, opt => opt.DoNotValidate());

            // Accounting Maps
            CreateMap<Project, Accounting.Core.Entities.Project>()
                .ForMember(x => x.Bills, opt => opt.Ignore())
                .ForMember(x => x.Customer, opt => opt.Ignore())
                .ForSourceMember(x => x.Customer, opt => opt.DoNotValidate())
                .ForSourceMember(x => x.Manager, opt => opt.DoNotValidate());

            // Scheduler Maps
            CreateMap<Project, Scheduler.Core.Entities.Project>()
                .ForSourceMember(x => x.Customer, opt => opt.DoNotValidate())
                .ForSourceMember(x => x.Manager, opt => opt.DoNotValidate());
        }
    }
}