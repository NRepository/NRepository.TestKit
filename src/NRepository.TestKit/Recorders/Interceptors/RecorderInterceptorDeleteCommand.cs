namespace NRepository.TestKit
{
    using System;
    using System.Collections.Generic;
    using NRepository.Core.Command;

    public class RecorderInterceptorDeleteCommand : IDeleteCommandInterceptor
    {
        public RecorderInterceptorDeleteCommand()
        {
            Entities = new List<object>();
        }

        public List<object> Entities
        {
            get;
            set;
        }

        public void Delete<T>(ICommandRepository repository, Action<T> addAction, T entity) where T : class
        {
            Entities.Add(entity);
            addAction(entity);
        }
    }
}
