using AutoMapper;
using ExxerProject.Companies.Core.Entities;
using ExxerProject.Web.Areas.Companies.Models.InquiriesViewModels;
using ExxerProject.Web.Areas.Companies.Models.SharedViewModels;

namespace ExxerProject.Web.Areas.Companies.Configurations
{
    public class AutoMapperCompaniesProfileConfiguration : Profile
    {
        public AutoMapperCompaniesProfileConfiguration()
        {
            // Companies area mappings.
            CreateMap<Inquiry, InquiryViewModel>();
            CreateMap<CreateViewModel, Inquiry>().ForMember(x => x.Attachments, opt => opt.Ignore());
            CreateMap<Employee, EmployeeViewModel>();
            CreateMap<InquiryEmployee, InquiryEmployeeViewModel>();
            CreateMap<Company, CompanyViewModel>();
            CreateMap<Attachment, AttachmentViewModel>();
            CreateMap<InfoRequest, InfoRequestViewModel>();
            CreateMap<Offer, OfferViewModel>();
        }
    }
}
