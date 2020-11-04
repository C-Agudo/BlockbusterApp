using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using BlockbusterApp.src.Shared.Domain.Event;
using BlockbusterApp.src.Shared.Infrastructure.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Shared.Infrastructure.Bus.Middleware
{
    public class EventDispatcherSyncMiddleware : MiddlewareHandler
    {
        private EventProvider eventProvider;
        private IDomainEventPublisher domainEventPublisher;
        public EventDispatcherSyncMiddleware(EventProvider eventProvider, IDomainEventPublisher domainEventPublisher)
        {
            this.eventProvider = eventProvider;
            this.domainEventPublisher = domainEventPublisher;
        }

        public override IResponse Handle(IRequest request)
        {
            List<DomainEvent> events = this.eventProvider.ReleaseEvents();
            foreach(DomainEvent domainEvent in events)
            {
                domainEventPublisher.Publish(domainEvent);
            }

            return null;
        }
    }
}
