using System;
using System.Collections.Generic;
using SMSGATEWAY.Domain.Core.Events;

namespace SMSGATEWAY.Infra.Data.Repository.EventSourcing
{
    public interface IEventStoreRepository : IDisposable
    {
        void Store(StoredEvent theEvent);
        IList<StoredEvent> All(Guid aggregateId);
    }
}
