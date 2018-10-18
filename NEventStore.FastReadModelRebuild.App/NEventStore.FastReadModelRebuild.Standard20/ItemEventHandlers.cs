using System;
using System.Collections.Generic;
using System.Text;

namespace NEventStore.FastReadModelRebuild.Standard20
{
    public class ItemEventHandlers : IEventHandler<ItemCreatedEvent>, 
        IEventHandler<ItemUpdatedEvent>
    {
        public void Handle(ItemCreatedEvent @event)
        {
            
        }

        public void Handle(ItemUpdatedEvent @event)
        {

        }
    }
}
