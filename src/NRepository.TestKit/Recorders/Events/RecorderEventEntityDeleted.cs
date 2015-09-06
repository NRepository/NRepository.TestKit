namespace NRepository.TestKit
{
    using System.Collections.Generic;
    using NRepository.Core.Events;

    public class RecorderEventEntityDeleted : IRepositorySubscribe<EntityDeletedEvent>
    {
        public RecorderEventEntityDeleted()
        {
            DeletedEvents = new List<EntityDeletedEvent>();
        }

        public void Handle(EntityDeletedEvent deletedEvent)
        {
            DeletedEvents.Add(deletedEvent);
        }

        public List<EntityDeletedEvent> DeletedEvents
        {
            get;
            private set;
        }
    }
}
