namespace NRepository.TestKit
{
    using System.Collections.Generic;
    using NRepository.Core.Events;

    public class RecorderEventQuery : IRepositorySubscribe<RepositoryQueryEvent>
    {
        public RecorderEventQuery()
        {
            QueryEvents = new List<RepositoryQueryEvent>();
        }

        public List<RepositoryQueryEvent> QueryEvents
        {
            get;
            private set;
        }

        public void Handle(RepositoryQueryEvent repositoryEvent)
        {
            QueryEvents.Add(repositoryEvent);
        }
    }
}
