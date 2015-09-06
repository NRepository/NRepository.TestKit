namespace NRepository.TestKit
{
    using System;
    using System.Collections.Generic;
    using NRepository.Core.Command;

    public class RecorderInterceptorAddCommand : IAddCommandInterceptor
    {
        public RecorderInterceptorAddCommand()
        {
            Entities = new List<object>();
        }

        public List<object> Entities
        {
            get;
            set;
        }

        public void Add<T>(ICommandRepository repository, Action<T> addAction, T entity) where T : class
        {
            Entities.Add(entity);
            addAction(entity);
        }
    }
}
