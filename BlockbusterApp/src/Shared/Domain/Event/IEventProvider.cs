using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Shared.Domain.Event
{
    public interface IEventProvider
    {
        void RecordEvents(List<DomainEvent> domainEvents);
        List<DomainEvent> ReleaseEvents();
    }
}
