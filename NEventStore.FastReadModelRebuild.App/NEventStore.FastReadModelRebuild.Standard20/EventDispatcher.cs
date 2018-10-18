using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NEventStore.FastReadModelRebuild.Standard20
{
    public class EventDispatcher
    {
        private readonly ItemEventHandlers _handlers;

        // Simplified registering of single handler. In the future this should be extended to also allow PS to register new handlers.
        public EventDispatcher(ItemEventHandlers handlers)
        {
            _handlers = handlers;
        }

        public void DispatchAllEvents(IEnumerable<IDomainEvent> events)
        {
            foreach (var domainEvent in events)
            {
                DynamicDispatch(domainEvent);
            }
        }

        protected void Dispatch<T>(T @event) where T : IDomainEvent
        {
            if (_handlers is IEventHandler<T> handler)
                handler.Handle(@event);
        }

        protected void DynamicDispatch(IDomainEvent domainEvent)
        {
            var eventType = domainEvent.GetType();

            var method = typeof(EventDispatcher).GetRuntimeMethods().Single(m => m.Name == nameof(EventDispatcher.Dispatch))
                .MakeGenericMethod(eventType);

            method.Invoke(this, new[] { domainEvent });
        }
    }
}
