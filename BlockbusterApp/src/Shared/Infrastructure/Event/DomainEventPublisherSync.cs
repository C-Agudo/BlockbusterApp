using BlockbusterApp.src.Shared.Domain.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Shared.Infrastructure.Event
{
    public class DomainEventPublisherSync : IDomainEventPublisher
    {
        private IEventBus eventBus;

        public DomainEventPublisherSync(IEventBus eventBus)
        {
            this.eventBus = eventBus;
        }

        public void Publish(DomainEvent domainEvent)
        {
            eventBus.Dispatch(domainEvent);
        }
    }
}
