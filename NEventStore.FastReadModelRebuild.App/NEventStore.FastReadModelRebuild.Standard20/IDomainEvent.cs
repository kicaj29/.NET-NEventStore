using System;
using System.Collections.Generic;
using System.Text;

namespace NEventStore.FastReadModelRebuild.Standard20
{
    public interface IDomainEvent
    {
        string AggregateId { get; set; }
    }
}
