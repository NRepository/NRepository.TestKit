namespace NRepository.TestKit
{
    using System;

    [Flags]
    public enum EntityGeneratorOptions
    {
        None,
        IgnoreExceptions = 1,
        SetPrivateProperties = 2,
        IncrementDates = 3
    }
}
