namespace NRepository.TestKit
{
    using System.Collections.Generic;
    using System.Linq;
    using NRepository.Core.Events;
    using NRepository.Core.Query; 

    public class InMemoryRecordedQueryRepository : InMemoryQueryRepository
    {
        private RecorderEventQuery _QueryEventsRecorder = new RecorderEventQuery();
        private RecorderInterceptorQuery _QueryInterceptorRecorder = new RecorderInterceptorQuery();

        public InMemoryRecordedQueryRepository(params object[] items)
            : this(items.ToList())
        {
        }

        public InMemoryRecordedQueryRepository(IEnumerable<object> entities)
            : base(entities)
        {
            base.QueryEventHandler = new QueryEventHandler(_QueryEventsRecorder);
            base.QueryInterceptor = _QueryInterceptorRecorder;
        }

        public List<RepositoryQueryEvent> QueryEvents
        {
            get { return _QueryEventsRecorder.QueryEvents; }
        }

        public List<object> QueryResults
        {
            get { return _QueryInterceptorRecorder.QueryResults; }
        } 
    }
}