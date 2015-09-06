namespace NRepository.TestKit
{
    using System.Collections.Generic;
    using NRepository.Core.Events;

    public class RecorderEventEntityModified : IRepositorySubscribe<EntityModifiedEvent>
    {
        public RecorderEventEntityModified()
        {
            ModifiedEvents = new List<EntityModifiedEvent>();
        }

        public void Handle(EntityModifiedEvent modifiedEvent)
        {
            ModifiedEvents.Add(modifiedEvent);
        }

        public List<EntityModifiedEvent> ModifiedEvents
        {
            get;
            private set;
        }
    }
}
