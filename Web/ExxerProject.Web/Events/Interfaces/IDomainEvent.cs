using System;

namespace ExxerProject.Web.Events.Interfaces
{
    public interface IDomainEvent
    {
        DateTime DateOccurred { get; }
    }
}
