namespace NRepository.TestKit
{
    using System;
    using NRepository.Core.Command;

    public class RecorderInterceptorSaveCommand : ISaveCommandInterceptor
    {
        public int Counter
        {
            get;
            set;
        }

        public int Save(ICommandRepository repository, Func<int> saveFunc)
        {
            Counter++;
            return saveFunc();
        }

        public bool ThrowOriginalException
        {
            get { return true; }
        }
    }
}