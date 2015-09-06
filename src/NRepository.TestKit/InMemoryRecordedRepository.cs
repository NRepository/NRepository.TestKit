using System;
namespace NRepository.TestKit
{
    using System.Collections.Generic;
    using System.Linq;
    using NRepository.Core; 

    public class InMemoryRecordedRepository : RepositoryBase
    {
        public InMemoryRecordedRepository(params object[] entities)
            : this(entities.ToList())
        {
        }

        public InMemoryRecordedRepository(ICollection<object> collection)
            : base(
              new InMemoryRecordedQueryRepository(collection),
              new InMemoryRecordedCommandRepository(collection))
        {
            ObjectContext = collection;
        }

        public new InMemoryRecordedCommandRepository CommandRepository
        {
            get { return (InMemoryRecordedCommandRepository)base.CommandRepository; }
        }

        public new InMemoryRecordedQueryRepository QueryRepository
        {
            get { return (InMemoryRecordedQueryRepository)base.QueryRepository; }
        }

        public IEnumerable<object> Items
        {
            get { return (IEnumerable<object>)ObjectContext; }
        }
    }
}
