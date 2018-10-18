using System;
using System.Collections.Generic;
using System.Text;

namespace NEventStore.FastReadModelRebuild.Standard20
{
    public class ItemCreatedEvent : IDomainEvent
    {
        public string AggregateId { get; set; }

        public string Prop1 { get; set; }

        public string Prop2 { get; set; }

        public string Prop3 { get; set; }
    }
}
