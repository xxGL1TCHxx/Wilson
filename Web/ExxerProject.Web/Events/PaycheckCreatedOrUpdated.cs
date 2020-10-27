using System;
using System.Collections.Generic;
using ExxerProject.Scheduler.Core.Entities;
using ExxerProject.Web.Events.Interfaces;

namespace ExxerProject.Web.Events
{
    public class PaycheckCreatedOrUpdated : IDomainEvent
    {
        public PaycheckCreatedOrUpdated(Paycheck paycheck)
        {
            this.Paycheck = paycheck;
            this.DateOccurred = DateTime.Now;
        }

        public PaycheckCreatedOrUpdated(IEnumerable<Paycheck> paychecks)
        {
            this.Paychecks = paychecks;
            this.DateOccurred = DateTime.Now;
        }        

        public DateTime DateOccurred { get; private set; }

        public Paycheck Paycheck { get; set; }

        public IEnumerable<Paycheck> Paychecks { get; set; }
    }
}
