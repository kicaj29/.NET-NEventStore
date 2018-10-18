using System;
using System.Collections.Generic;
using System.Text;

namespace NEventStore.FastReadModelRebuild.Standard20
{
    public interface IEventHandler<in T> where T : IDomainEvent
    {
        void Handle(T @event);
    }
}
