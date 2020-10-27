using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using ExxerProject.Scheduler.Data.DataAccess;
using ExxerProject.Scheduler.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExxerProject.Web.Areas.Scheduler.Services
{
    public abstract class Service : IService
    {
        public Service(IMapper mapper)
        {
            this.Mapper = mapper;
        }

        public ISchedulerWorkData SchedulerWorkData { get; set; }

        public IMapper Mapper { get; set; }

        public async Task<IEnumerable<Employee>> Employees()
        {
            return await this.SchedulerWorkData.Employees
                .FindAsync(e => !e.IsFired, i => i
                .Include(x => x.Schedules)
                .ThenInclude(x => x.Project)
                .Include(x => x.PayRate)
                .Include(x => x.Paychecks));
        }

        public async Task<List<SelectListItem>> GetProjectOptions()
        {
            var projects = await this.SchedulerWorkData.Projects.FindAsync(x => x.IsActive);
            return projects.Select(x => new SelectListItem() { Value = x.Id, Text = x.ShortName }).ToList();
        }
        
        public async Task<List<SelectListItem>> GetEmployeeOptions()
        {
            var employees = await this.SchedulerWorkData.Employees.FindAsync(e => !e.IsFired);
            return employees.Select(x => new SelectListItem() { Value = x.Id, Text = x.ToString() }).ToList();
        }   
    }
}
