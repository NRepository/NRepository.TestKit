namespace NRepository.TestKit
{
    using System.Collections.Generic;
    using NRepository.Core;

    public class RecordedInterceptorEvents : RepositoryInterceptors
    {
        public RecordedInterceptorEvents()
        {
            AddCommandInterceptor = new RecorderInterceptorAddCommand();
            ModifyCommandInterceptor = new RecorderInterceptorModifiyCommand();
            DeleteCommandInterceptor = new RecorderInterceptorDeleteCommand();
            SaveCommandInterceptor = new RecorderInterceptorSaveCommand();
            QueryInterceptor = new RecorderInterceptorQuery();
        }

        public IList<object> AddEntities
        {
            get { return ((RecorderInterceptorAddCommand)AddCommandInterceptor).Entities; }
        }

        public IList<object> ModifyEntities
        {
            get { return ((RecorderInterceptorModifiyCommand)ModifyCommandInterceptor).Entities; }
        }

        public IList<object> DeleteEntities
        {
            get { return ((RecorderInterceptorDeleteCommand)DeleteCommandInterceptor).Entities; }
        }

        public int SaveCount
        {
            get { return ((RecorderInterceptorSaveCommand)SaveCommandInterceptor).Counter; }
        }

        public IList<object> Queries
        {
            get { return ((RecorderInterceptorQuery)AddCommandInterceptor).QueryResults; }
        }

        public void Reset()
        {
            ((RecorderInterceptorSaveCommand)SaveCommandInterceptor).Counter = 0;

            AddEntities.Clear();
            ModifyEntities.Clear();
            DeleteEntities.Clear();
            AddEntities.Clear();
            Queries.Clear();
        }
    }
}
