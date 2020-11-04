using BlockbusterApp.src.Shared.Domain.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Shared.Infrastructure.Event
{
    public class EventProvider : IEventProvider
    {
        private List<DomainEvent> events;
        public EventProvider()
        {
            this.events = new List<DomainEvent>();
        }
        public void RecordEvents(List<DomainEvent> domainEvents)
        {
           foreach(DomainEvent domainEvent in domainEvents)
            {
                this.events.Add(domainEvent);
            }
        }

        public List<DomainEvent> ReleaseEvents()
        {
            List<DomainEvent> events = this.events;
            this.RemoveEvents();

            return events;
        }

        private void RemoveEvents()
        {
            this.events = new List<DomainEvent>();
        }
    }
}
