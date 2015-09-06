namespace NRepository.TestKit
{
    using System.Collections.Generic;
    using NRepository.Core.Events;

    public class RecorderEventEntityAdded : IRepositorySubscribe<EntityAddedEvent>
    {
        public RecorderEventEntityAdded()
        {
            AddedEvents = new List<EntityAddedEvent>();
        }

        public List<EntityAddedEvent> AddedEvents
        {
            get;
            private set;
        }

        public void Handle(EntityAddedEvent entityAdded)
        {
            AddedEvents.Add(entityAdded);
        }
    }
}