using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace NEventStore.FastReadModelRebuild.Standard20
{
    public class EventStreamObserver : IObserver<ICommit>
    {
        private EventDispatcher _dispatcher = new EventDispatcher(new ItemEventHandlers());
        
        public void OnCompleted()
        {
            
        }

        public void OnError(Exception error)
        {
            
        }

        public void OnNext(ICommit value)
        {
            var events = value.Events.Select(e => e.Body).Cast<IDomainEvent>();

            this._dispatcher.DispatchAllEvents(events);

            if (value.CheckpointToken == "198")
            {
                Debug.WriteLine(GlobalTimer.Timer.Stop());
            }
        }
    }
}
