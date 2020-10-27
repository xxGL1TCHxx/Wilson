using System;
using System.Collections.Generic;
using ExxerProject.Companies.Core.Entities;
using ExxerProject.Web.Events.Interfaces;

namespace ExxerProject.Web.Events
{
    public class EmployeeCreated : IDomainEvent
    {
        public EmployeeCreated(Employee employee)
        {
            this.DateOccurred = DateTime.Now;
            this.Employee = employee;
        }

        public EmployeeCreated(IEnumerable<Employee> employees)
        {
            this.DateOccurred = DateTime.Now;
            this.Employees = employees;
        }        

        public DateTime DateOccurred { get; set; }

        public Employee Employee { get; set; }

        public IEnumerable<Employee> Employees { get; set; }
    }
}
