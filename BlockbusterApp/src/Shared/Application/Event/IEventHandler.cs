using BlockbusterApp.src.Shared.Domain.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Shared.Application.Event
{
    public interface IEventHandler
    {
        void Handle(DomainEvent domainEvent);
    }
}
