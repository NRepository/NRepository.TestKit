namespace NRepository.TestKit
{
    using System.Collections.Generic;
    using NRepository.Core.Events;

    public class RecorderEventSaved : IRepositorySubscribe<RepositorySavedEvent>
    {
        public RecorderEventSaved()
        {
            SavedEvents = new List<RepositorySavedEvent>();
        }

        public List<RepositorySavedEvent> SavedEvents
        {
            get;
            private set;
        }
        
        public void Handle(RepositorySavedEvent savedEvent)
        {
            SavedEvents.Add(savedEvent);
        }
    }
}