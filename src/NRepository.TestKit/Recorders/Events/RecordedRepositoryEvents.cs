namespace NRepository.TestKit
{
    using System.Collections.Generic;
    using NRepository.Core;
    using NRepository.Core.Events;

    public class RecordedRepositoryEvents : RepositoryEventsHandlers
    {
        public RecordedRepositoryEvents()
        {
            EntityAddedEventHandler = new RecorderEventEntityAdded();
            EntityDeletedEventHandler = new RecorderEventEntityDeleted();
            EntityModifiedEventHandler = new RecorderEventEntityModified();
            RepositorySavedEventHandler = new RecorderEventSaved();
            RepositoryQueriedEventHandler = new RecorderEventQuery();
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

        public List<RepositoryQueryEvent> QueryEvents
        {
            get { return ((RecorderEventQuery)RepositoryQueriedEventHandler).QueryEvents; }
        }

        public void Reset()
        {
            QueryEvents.Clear();
            SavedEvents.Clear();
            ModifiedEvents.Clear();
            DeletedEvents.Clear();
            AddedEvents.Clear();
        }
    }
}
