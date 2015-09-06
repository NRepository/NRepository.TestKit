namespace NRepository.TestKit
{
    using System.Collections.Generic;
    using NRepository.Core.Events;
    using NRepository.Core.Command;

    public class RecorderInterceptorCommands : CommandInterceptors
    {
        public RecorderInterceptorCommands()
        {
            base.AddCommandInterceptor = new RecorderInterceptorAddCommand();
            base.DeleteCommandInterceptor = new RecorderInterceptorDeleteCommand();
            base.ModifyCommandInterceptor = new RecorderInterceptorModifiyCommand();
            base.SaveCommandInterceptor = new RecorderInterceptorSaveCommand();
        }

        public IEnumerable<object> AddEntities
        {
            get { return ((RecorderInterceptorAddCommand)AddCommandInterceptor).Entities; }
        }

        public IEnumerable<object> ModifyEntities
        {
            get { return ((RecorderInterceptorModifiyCommand)ModifyCommandInterceptor).Entities; }
        }

        public IEnumerable<object> DeleteEntities
        {
            get { return ((RecorderInterceptorDeleteCommand)DeleteCommandInterceptor).Entities; }
        }

        public int SaveCount
        {
            get { return ((RecorderInterceptorSaveCommand)SaveCommandInterceptor).Counter; }
        }
    }
}
