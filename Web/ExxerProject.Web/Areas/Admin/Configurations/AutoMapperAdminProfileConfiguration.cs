using AutoMapper;
using ExxerProject.Companies.Core.Entities;
using ExxerProject.Web.Areas.Admin.Models.ControlPanelViewModels;

namespace ExxerProject.Web.Areas.Admin.Configurations
{
    public class AutoMapperAdminProfileConfiguration : Profile
    {
        public AutoMapperAdminProfileConfiguration()
        {
            CreateMap<ApplicationUser, ShortUserViewModel>();
        }
    }
}
