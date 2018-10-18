using System;
using System.Collections.Generic;
using NEventStore.Client;
using NEventStore.Persistence.Sql.SqlDialects;

namespace NEventStore.FastReadModelRebuild.Standard20
{
    public class NEventStoreSample
    {
        private  IStoreEvents CreateNEventStore()
        {
            return Wireup.Init()
                .UsingSqlPersistence("EventStoreDB", "System.Data.SqlClient", @"Data Source = (localdb)\MSSQLLocalDB; Database = NEventStore; Integrated Security = SSPI; MultipleActiveResultSets = True")
                .WithDialect(new MsSqlDialect())
                .InitializeStorageEngine()
                // .UsingCustomSerialization(new CustomJsonSerializer())
                .Build();
        }

        private void InsertIntoStore(IStoreEvents store)
        {
            for (var x = 1; x < 100; x++)
            {
                var eC = new ItemCreatedEvent()
                {
                    AggregateId = x.ToString(),
                    Prop1 = x.ToString() + "prop1",
                    Prop2 = x.ToString() + "prop2",
                    Prop3 = x.ToString() + "prop3"
                };

                var eU = new ItemUpdatedEvent()
                {
                    AggregateId = x.ToString(),
                    Prop1 = x.ToString() + "prop1u",
                    Prop2 = x.ToString() + "prop2u",
                    Prop3 = x.ToString() + "prop3u"
                };

                using (var stream = store.OpenStream("0", eC.AggregateId, 0, int.MaxValue))
                {
                    stream.Add(new EventMessage() { Body = eC });
                    stream.CommitChanges(Guid.NewGuid());
                    stream.Add(new EventMessage() { Body = eU });
                    stream.CommitChanges(Guid.NewGuid());
                }
            }


        }

        private void Polling(IStoreEvents store)
        {
            var pollingClient = new PollingClient(store.Advanced, 5000);
            var observeCommits = pollingClient.ObserveFrom("0");
            var eventStreamObserver = new EventStreamObserver();
            observeCommits.Subscribe(eventStreamObserver);
            GlobalTimer.Timer.Start();
            observeCommits.Start();

        }

        public void Start()
        {
            var store = this.CreateNEventStore();
            // this.InsertIntoStore(store);
            this.Polling(store);

        }
    }
}
