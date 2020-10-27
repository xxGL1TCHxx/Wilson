using System;
using System.Collections.Generic;
using ExxerProject.Accounting.Core.Entities;
using ExxerProject.Web.Events.Interfaces;

namespace ExxerProject.Web.Events
{
    public class CompanyCreated : IDomainEvent
    {
        public CompanyCreated(Company company)
        {
            this.Company = company;
            this.DateOccurred = DateTime.Now;
        }

        public CompanyCreated(IEnumerable<Company> companies)
        {
            this.Companies = companies;
            this.DateOccurred = DateTime.Now;
        }

        public DateTime DateOccurred { get; private set; }

        public Company Company { get; set; }

        public IEnumerable<Company> Companies { get; set; }
    }
}
