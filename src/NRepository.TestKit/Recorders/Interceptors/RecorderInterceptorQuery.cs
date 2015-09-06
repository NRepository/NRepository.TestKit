namespace NRepository.TestKit
{
    using System.Collections.Generic;
    using System.Linq;
    using NRepository.Core.Query;
    using NRepository.Core.Command;

    public class RecorderInterceptorQuery : IQueryInterceptor
    {
        public RecorderInterceptorQuery()
        {
            QueryResults = new List<object>();
        }

        public List<object> QueryResults
        {
            get;
            set;
        }

        public IQueryable<T> Query<T>(IQueryRepository repository, IQueryable<T> query, object additionalQueryData) where T : class
        {
            QueryResults.Add(query);
            return query;
        }
    }
}
