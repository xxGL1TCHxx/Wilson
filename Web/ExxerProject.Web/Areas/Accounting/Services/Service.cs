using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using ExxerProject.Accounting.Data.DataAccess;
using ExxerProject.Accounting.Core.Entities;

namespace ExxerProject.Web.Areas.Accounting.Services
{
    public class Service : IService
    {
        public Service(IAccountingWorkData accountingWorkData, IMapper mapper)
        {
            this.AccountingWorkData = accountingWorkData;
            this.Mapper = mapper;            
        }

        public IAccountingWorkData AccountingWorkData { get; set; }

        public IMapper Mapper { get; set; }

        public async Task<List<SelectListItem>> GetEmployeeOptions()
        {
            var employees = await this.AccountingWorkData.Employees.FindAsync(e => !e.IsFired);
            return employees.Select(x => new SelectListItem() { Value = x.Id, Text = x.ToString() }).ToList();
        }
    }
}
