using AutoMapper;
using ExxerProject.Scheduler.Core.Entities;
using ExxerProject.Web.Areas.Scheduler.Models.HomeViewModels;
using ExxerProject.Web.Areas.Scheduler.Models.PayrollViewModels;
using ExxerProject.Web.Areas.Scheduler.Models.SharedViewModels;

namespace ExxerProject.Web.Areas.Scheduler.Configurations
{
    public class AutoMapperSchedulerProfileConfiguration : Profile
    {
        public AutoMapperSchedulerProfileConfiguration()
        {
            CreateMap<Employee, EmployeeViewModel>();
            CreateMap<Employee, EmployeeConciseViewModel>();
            CreateMap<Project, ProjectViewModel>();
            CreateMap<Schedule, ScheduleViewModel>()
                .ForMember(x => x.ProjectOptions, opt => opt.Ignore())
                .ForMember(x => x.ScheduleOptions, opt => opt.Ignore())
                .ForMember(x => x.ScheduleOptionName, opt => opt.Ignore());
            CreateMap<Paycheck, PaycheckViewModel>()
                .ForMember(x => x.WorkingHours, opt =>opt.MapFrom<WorkingHoursResolver<Paycheck, PaycheckViewModel>>())
                .ForMember(x => x.Period, opt =>opt.MapFrom<PeriodResolver<Paycheck, PaycheckViewModel>>())
                .ForMember(x => x.DaysOff, opt =>opt.MapFrom<DaysOffResolver<Paycheck, PaycheckViewModel>>());
        }
    }
}
