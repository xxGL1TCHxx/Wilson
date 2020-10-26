using AutoMapper;
using Wilson.Accounting.Core.Entities;
using Wilson.Companies.Data;
using Wilson.Projects.Data;
using Wilson.Web.Events.Interfaces;

namespace Wilson.Web.Events.Handlers
{
    public class AutoMappingCompany : Profile
    {
        public AutoMappingCompany()
        {
            CreateMap<Company, Companies.Core.Entities.Company>()
                     .ForMember(x => x.Employees, opt => opt.Ignore())
                     .ForMember(x => x.Projects, opt => opt.Ignore())
                     .ForSourceMember(x => x.Employees, opt => opt.DoNotValidate())
                     .ForSourceMember(x => x.SaleInvoices, opt => opt.DoNotValidate())
                     .ForSourceMember(x => x.BuyInvoices, opt => opt.DoNotValidate());

            CreateMap<Company, Projects.Core.Entities.Company>()
                .ForSourceMember(x => x.Employees, opt => opt.DoNotValidate())
                .ForSourceMember(x => x.SaleInvoices, opt => opt.DoNotValidate())
                .ForSourceMember(x => x.BuyInvoices, opt => opt.DoNotValidate());
        }
    }
}