using AutoMapper;
using ExxerProject.Accounting.Core.Entities;
using ExxerProject.Accounting.Core.Entities.ValueObjects;
using ExxerProject.Web.Areas.Accounting.Models.HomeViewModels;
using ExxerProject.Web.Areas.Accounting.Models.SharedViewModels;

namespace ExxerProject.Web.Areas.Accounting.Configurations
{
    public class AutoMapperAccountingProfileConfiguration : Profile
    {
        public AutoMapperAccountingProfileConfiguration()
        {
            CreateMap<Employee, EmployeeViewModel>();
            CreateMap<Payment, PaymentViewModel>();
            CreateMap<Paycheck, PaycheckViewModel>()
                .ForMember(x => x.Payments, opt => opt.MapFrom<PaychekPaymentsResolver>())
                .ForMember(x => x.Period, opt => opt.MapFrom<PeriodResolver<Paycheck, PaycheckViewModel>>());
        }
    }
}