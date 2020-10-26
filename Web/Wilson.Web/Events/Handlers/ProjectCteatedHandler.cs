using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Wilson.Accounting.Data;
using Wilson.Companies.Data;
using Wilson.Projects.Core.Entities;
using Wilson.Scheduler.Data;
using Wilson.Web.Events.Interfaces;

namespace Wilson.Web.Events.Handlers
{
    public class ProjectCteatedHandler : Handler
    {
        private readonly IMapper _mapper;

        public ProjectCteatedHandler(IServiceProvider serviceProvider, IMapper mapper)
            : base(serviceProvider)
        {
            _mapper = mapper;
        }

        public async override Task Handle(IDomainEvent args)
        {
            var eventArgs = args as ProjectCreated;
            if (eventArgs == null)
            {
                throw new InvalidCastException();
            }

            var accDbContext = this.ServiceProvider.GetService<AccountingDbContext>();
            var schedulerDbContext = this.ServiceProvider.GetService<SchedulerDbContext>();
            var companyDbContext = this.ServiceProvider.GetService<CompanyDbContext>();

            if (eventArgs.Projects != null)
            {
                var companyProjects = _mapper.Map<IEnumerable<Project>, IEnumerable<Companies.Core.Entities.Project>>(eventArgs.Projects);
                var accProjects = _mapper.Map<IEnumerable<Project>, IEnumerable<Accounting.Core.Entities.Project>>(eventArgs.Projects);
                var schedulerProjects = _mapper.Map<IEnumerable<Project>, IEnumerable<Scheduler.Core.Entities.Project>>(eventArgs.Projects);

                await companyDbContext.Set<Companies.Core.Entities.Project>().AddRangeAsync(companyProjects);
                await accDbContext.Set<Accounting.Core.Entities.Project>().AddRangeAsync(accProjects);
                await schedulerDbContext.Set<Scheduler.Core.Entities.Project>().AddRangeAsync(schedulerProjects);
                foreach (var project in schedulerProjects)
                {
                    project.SetShortName();
                }
            }

            if (eventArgs.Project != null)
            {
                var companyProject = _mapper.Map<Project, Companies.Core.Entities.Project>(eventArgs.Project);
                var accProject = _mapper.Map<Project, Accounting.Core.Entities.Project>(eventArgs.Project);
                var schedulerProject = _mapper.Map<Project, Scheduler.Core.Entities.Project>(eventArgs.Project);
                schedulerProject.SetShortName();

                await companyDbContext.Set<Companies.Core.Entities.Project>().AddAsync(companyProject);
                await accDbContext.Set<Accounting.Core.Entities.Project>().AddAsync(accProject);
                await schedulerDbContext.Set<Scheduler.Core.Entities.Project>().AddAsync(schedulerProject);
            }

            await accDbContext.SaveChangesAsync();
            await schedulerDbContext.SaveChangesAsync();
            await companyDbContext.SaveChangesAsync();
        }
    }
}