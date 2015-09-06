namespace NRepository.TestKit
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using NRepository.Core.Command;

    public class InMemoryRecordedCommandRepository : InMemoryCommandRepository
    {
        private RecorderEventHandlers _CommandEventHandlers = new RecorderEventHandlers();
        private RecorderInterceptorCommands _CommandInterceptors = new RecorderInterceptorCommands();

        public InMemoryRecordedCommandRepository(params object[] entities)
            : this(entities.ToList())
        {
        }

        public InMemoryRecordedCommandRepository(ICollection<object> entities)
            : base(entities)
        {
            base.EventHandlers = _CommandEventHandlers;
            base.CommandInterceptors = _CommandInterceptors;
        }

        public RecorderEventHandlers CommandEvents
        {
            get { return _CommandEventHandlers; }
        }
    }
}
