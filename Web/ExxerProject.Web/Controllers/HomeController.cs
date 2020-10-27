using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ExxerProject.Accounting.Data.DataAccess;
using ExxerProject.Companies.Data.DataAccess;
using ExxerProject.Scheduler.Data.DataAccess;

namespace ExxerProject.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger logger;

        public HomeController(
            ICompanyWorkData companyWorkData, 
            ISchedulerWorkData schedulerWorkData,
            IAccountingWorkData accountingWorkData,
            IMapper mapper,
            ILoggerFactory loggerFactory)
            : base(companyWorkData, schedulerWorkData, accountingWorkData, mapper)
        {
            this.logger = loggerFactory.CreateLogger<HomeController>();
        }

        public IActionResult Index(string message)
        {
            ViewData["StatusMessage"] = message ?? "";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        } 
    }
}
