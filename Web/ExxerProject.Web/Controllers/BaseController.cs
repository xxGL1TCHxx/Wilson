using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ExxerProject.Accounting.Data.DataAccess;
using ExxerProject.Companies.Data.DataAccess;
using ExxerProject.Scheduler.Data.DataAccess;

namespace ExxerProject.Web.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        public BaseController(
            ICompanyWorkData companyWorkData, 
            ISchedulerWorkData schedulerWorkData,
            IAccountingWorkData accountingWorkData,
            IMapper mapper)
        {
            this.CompanyWorkData = companyWorkData;
            this.SchedulerWorkData = schedulerWorkData;
            this.AccountingWorkData = accountingWorkData;
            this.Mapper = mapper;
        }

        public ICompanyWorkData CompanyWorkData { get; set; }

        public ISchedulerWorkData SchedulerWorkData { get; set; }

        public IAccountingWorkData AccountingWorkData { get; set; }

        public IMapper Mapper { get; set; }
    }
}