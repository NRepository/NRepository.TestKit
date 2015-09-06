namespace NRepository.TestKit
{
    using System.Collections.Generic;
    using NRepository.Core.Events;
    using NRepository.Core.Command;

    public class RecorderEventHandlers : CommandEventsHandlers
    {
        public RecorderEventHandlers()
        {
            EntityAddedEventHandler = new RecorderEventEntityAdded();
            EntityDeletedEventHandler = new RecorderEventEntityDeleted();
            EntityModifiedEventHandler = new RecorderEventEntityModified();
            RepositorySavedEventHandler = new RecorderEventSaved();
        }

        public List<EntityAddedEvent> AddedEvents
        {
            get { return ((RecorderEventEntityAdded)EntityAddedEventHandler).AddedEvents; }
        }

        public List<EntityDeletedEvent> DeletedEvents
        {
            get { return ((RecorderEventEntityDeleted)EntityDeletedEventHandler).DeletedEvents; }
        }

        public List<EntityModifiedEvent> ModifiedEvents
        {
            get { return ((RecorderEventEntityModified)EntityModifiedEventHandler).ModifiedEvents; }
        }

        public List<RepositorySavedEvent> SavedEvents
        {
            get { return ((RecorderEventSaved)RepositorySavedEventHandler).SavedEvents; }
        }
    }
}