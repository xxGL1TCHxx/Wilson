using System.Collections.Generic;
using AutoMapper;
using ExxerProject.Accounting.Core.Entities;
using ExxerProject.Web.Areas.Accounting.Models.HomeViewModels;
using ExxerProject.Web.Areas.Accounting.Models.SharedViewModels;
using ExxerProject.Accounting.Core.Entities.ValueObjects;

namespace ExxerProject.Web.Areas.Accounting.Configurations
{
    public class PaychekPaymentsResolver : IValueResolver<Paycheck, PaycheckViewModel, IEnumerable<PaymentViewModel>> 
    {

        public IEnumerable<PaymentViewModel> Resolve(
            Paycheck source, 
            PaycheckViewModel destination, 
            IEnumerable<PaymentViewModel> destMember,
            ResolutionContext context)
        {
            var payments = !string.IsNullOrEmpty(source.Payments) ? (ListOfPayments)source.Payments : ListOfPayments.Create();
            return context.Mapper.Map<IEnumerable<Payment>, IEnumerable<PaymentViewModel>>(payments);
        }
    }
}
