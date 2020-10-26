using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Wilson.Accounting.Core.Entities;
using Wilson.Companies.Data;
using Wilson.Projects.Data;
using Wilson.Web.Events.Interfaces;

namespace Wilson.Web.Events.Handlers
{
    public class CompanyCreatedHandler : Handler
    {
        private readonly IMapper _mapper;

        public CompanyCreatedHandler(IServiceProvider serviceProvider, IMapper mapper)
            : base(serviceProvider)
        {
            _mapper = mapper;
        }

        public async override Task Handle(IDomainEvent args)
        {
            var eventArgs = args as CompanyCreated;
            if (eventArgs == null)
            {
                throw new InvalidCastException();
            }

            var companyDbContext = this.ServiceProvider.GetService<CompanyDbContext>();
            var projectDbContext = this.ServiceProvider.GetService<ProjectsDbContext>();

            if (eventArgs.Companies != null)
            {
                var companyCompanies = _mapper.Map<IEnumerable<Company>, IEnumerable<Companies.Core.Entities.Company>>(eventArgs.Companies);
                foreach (var company in companyCompanies)
                {
                    company.ChangeShippingAddress(company.GetAddress());
                }

                var projectsCompanies = _mapper.Map<IEnumerable<Company>, IEnumerable<Projects.Core.Entities.Company>>(eventArgs.Companies);

                await companyDbContext.Set<Companies.Core.Entities.Company>().AddRangeAsync(companyCompanies);
                await projectDbContext.Set<Projects.Core.Entities.Company>().AddRangeAsync(projectsCompanies);
            }

            if (eventArgs.Company != null)
            {
                var companyCompany = _mapper.Map<Company, Companies.Core.Entities.Company>(eventArgs.Company);
                companyCompany.ChangeShippingAddress(companyCompany.GetAddress());

                var projectsCompany = _mapper.Map<Company, Projects.Core.Entities.Company>(eventArgs.Company);

                await companyDbContext.Set<Companies.Core.Entities.Company>().AddAsync(companyCompany);
                await projectDbContext.Set<Projects.Core.Entities.Company>().AddAsync(projectsCompany);
            }

            await companyDbContext.SaveChangesAsync();
            await projectDbContext.SaveChangesAsync();
        }
    }
}