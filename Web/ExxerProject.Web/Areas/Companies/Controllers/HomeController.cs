using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ExxerProject.Companies.Data.DataAccess;

namespace ExxerProject.Web.Areas.Companies.Controllers
{
    public class HomeController : CompanyBaseController
    {
        public HomeController(ICompanyWorkData companyWorkData, IMapper mapper)
            : base(companyWorkData, mapper)
        {
        }

        //
        // GET: Companies/Home/Index
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }        
    }
}
