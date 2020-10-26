using System;
using System.Collections.Generic;
using Wilson.Companies.Core.Enumerations;

namespace Wilson.Web.Areas.Companies.Models.InquiriesViewModels
{
    public class EmployeeViewModel
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public override string ToString()
        {
            return this.FirstName + " " + this.LastName;
        }

        public string Email { get; set; }
        public string Phone { get; set; }
        public string PrivatePhone { get; set; }
        public string EmployeePosition { get; set; }

        public Array EmployeePositions()
        {
            return Enum.GetValues(typeof(Wilson.Companies.Core.Enumerations.EmployeePosition));
        }
    }
}