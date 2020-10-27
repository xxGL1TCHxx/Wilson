using System;
using System.Threading.Tasks;
using ExxerProject.Web.Events.Interfaces;

namespace ExxerProject.Web.Events.Handlers
{
    public abstract class Handler : IHandle<IDomainEvent>
    {
        public Handler(IServiceProvider serviceProvider)
        {
            this.ServiceProvider = serviceProvider;
        }

        public IServiceProvider ServiceProvider { get; set; }

        public abstract Task Handle(IDomainEvent args);
    }
}
